namespace Garage
{
    public class GarageManager
    {
        private static GarageManager? instance = null;
        List<VehicleInGarage> m_VehiclesInGarage;
        Dictionary<string, Vehicle> m_LicenseNum2Vehicle;

        /// <summary>
        /// implements the singleton dp
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

        public void UpdateExistingVehicleStatus(string i_LicenseNum, string i_status)
        {
            VehicleInGarage.eStatus newStatus = VehicleInGarage.eStatusFromString(i_status);
            
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

        //public void InsertNewVehicle() {}

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
                    eFilter =null;
                    break;
            }
            
            return getVehiclesByFilter(eFilter);
        }

        private List<string> getVehiclesByFilter(VehicleInGarage.eStatus? filter)
        {
            List<string> result = new List<string>();
            foreach (VehicleInGarage vehicle in m_VehiclesInGarage)
            {
                if (vehicle.Status == filter)
                {
                    result.Append(vehicle.LicenseNum);
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
            PetroleumPowerSource.ePetrolType ePetroltype = PetroleumPowerSource.PetrolTypeFromString(i_FuelType);
            
            m_LicenseNum2Vehicle.TryGetValue(i_LicenseNum, out var vehicle);
            if (vehicle != null )
            {
                if (vehicle.Powersource.GetType().Name.Equals("PetroleumPowerSource") == false)
                {
                    throw new ArgumentException($"The vehicle with license no. {i_LicenseNum} is not a petroleum powered vehicle!");
                }
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
            m_LicenseNum2Vehicle.TryGetValue(i_LicenseNum, out var vehicle);
            if (vehicle != null )
            {
                if (vehicle.Powersource.GetType().Name.Equals("EnergyPowerSource") == false)
                {
                    throw new ArgumentException($"The vehicle with license no. {i_LicenseNum} is not an electric powered vehicle!");
                }

                vehicle.Powersource.Fill(i_Quantity);
                return;
            }
            throw new VehicleNotExistsException(i_LicenseNum);
        } 
    }
}
