namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private static GarageManager? instance = null;
        List<VehicleInGarage> m_VehiclesInGarage;
        Dictionary<string, Vehicle> m_LicenseNum2Vehicle;

        /// <summary>
        /// Implements the singleton design pattern
        ///  to interact with the manager, use getManager to obtain a reference
        /// </summary>
        private GarageManager()
        {
            m_VehiclesInGarage = new List<VehicleInGarage>();
            m_LicenseNum2Vehicle = new Dictionary<string,Vehicle>();
        }
     
        public static GarageManager getManager()
        {
            if (instance == null) 
            {
                instance = new GarageManager();
            }
            
            return instance;
        }

        public void UpdateExistingVehicleStatus(string i_LicenseNum, string i_Status)
        {
            VehicleInGarage.eStatus newStatus = VehicleInGarage.eStatusFromString(i_Status);
            
            foreach (VehicleInGarage vehicle in m_VehiclesInGarage)
            {
                if (vehicle.LicenseNum.Equals(i_LicenseNum))
                {
                    vehicle.Status = newStatus;
                    return;
                }
            }

            throw new VehicleNotExistsException(i_LicenseNum);
        }

        public void InsertNewVehicle(VehicleCreationBlueprint i_Blueprint) 
        {
            Vehicle newVehicle = VehicleCreator.CreateVehicle(i_Blueprint);
            VehicleInGarage newVehicleInGarage = new VehicleInGarage(i_Blueprint.OwnerName, i_Blueprint.OwnerPhone, i_Blueprint.License);
            
            m_VehiclesInGarage.Add(newVehicleInGarage);
            m_LicenseNum2Vehicle.Add(i_Blueprint.License, newVehicle);
        }

        public List<string> GetAllVehiclesLicense(string i_fitler = "")
        {
            VehicleInGarage.eStatus? eFilter = null;

            switch (i_fitler)
            {
                case "PreService":
                    eFilter = VehicleInGarage.eStatus.PreService;
                    break;
                case "PostService":
                    eFilter = VehicleInGarage.eStatus.PostService;
                    break;
                case "Paid":
                    eFilter = VehicleInGarage.eStatus.Paid;
                    break;
                default:
                    eFilter = null;
                    break;
            }
            
            return getVehiclesByFilter(eFilter);
        }

        private List<string> getVehiclesByFilter(VehicleInGarage.eStatus? filter)
        {
            List<string> result = new List<string>();

            foreach (VehicleInGarage vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Status == filter || filter == null)
                {
                    result.Add(vehicle.LicenseNum);
                }
            }
            
            return result;
        }

        public void InflateTyresToMaximum(string i_LicenseNum)
        {
            m_LicenseNum2Vehicle.TryGetValue(i_LicenseNum, out var vehicle);
            if (vehicle != null)
            {
                foreach (Wheel wheel in vehicle.Wheels)
                {
                    wheel.Inflate(wheel.GetPressureDeltaFromMaximum());
                }
                return;
            }
            
            throw new VehicleNotExistsException(i_LicenseNum);
        }

        public void FillTankWithQuantity(string i_LicenseNum, float i_Quantity, string i_FuelType)
        {
            m_LicenseNum2Vehicle.TryGetValue(i_LicenseNum, out var vehicle);
            if (vehicle != null )
            {
                if (vehicle.Powersource.GetType().Name.Equals("PetroleumPowerSource") == false)
                {
                    throw new ArgumentException($"The vehicle with license no. {i_LicenseNum} is not a petroleum powered vehicle!");
                }
                
                PetroleumPowerSource.ePetrolType ePetroltype = PetroleumPowerSource.PetrolTypeFromString(i_FuelType);
                
                PetroleumPowerSource.ePetrolType ePetType = (vehicle.Powersource as PetroleumPowerSource).PetrolType;
                if (ePetType.Equals(ePetroltype) == false)
                {
                    throw new ArgumentException($"The vehicle with license no. {i_LicenseNum} is running on {ePetType} but {i_FuelType} was selected.");
                }
                
                vehicle.Powersource.Fill(i_Quantity);

                return;
            }
            
            throw new VehicleNotExistsException(i_LicenseNum);
        }

        public void ChargeBatteryWithQuantity(string i_LicenseNum, float i_Quantity)
        {
            float timeInHours = i_Quantity / 60;
            
            m_LicenseNum2Vehicle.TryGetValue(i_LicenseNum, out var vehicle);
            if (vehicle != null )
            {
                if (vehicle.Powersource.GetType().Name.Equals("ElectricPowerSource") == false)
                {
                    throw new ArgumentException($"The vehicle with license no. {i_LicenseNum} is not an electric powered vehicle!");
                }

                vehicle.Powersource.Fill(timeInHours);

                return;
            }
            
            throw new VehicleNotExistsException(i_LicenseNum);
        } 

        public string GetVehicleDataByLicenseNum(string i_LicenseNum)
        {
            VehicleInGarage vehicleInGarage = null;
            
            foreach (VehicleInGarage vehicle in m_VehiclesInGarage)
            {
                if (vehicle.LicenseNum.Equals(i_LicenseNum))
                {
                    vehicleInGarage = vehicle;
                    break;
                }
            }
            
            if (vehicleInGarage == null)
            {
                throw new VehicleNotExistsException(i_LicenseNum);
            }
           
            return m_LicenseNum2Vehicle[i_LicenseNum].ToString();
        }
    }
}
