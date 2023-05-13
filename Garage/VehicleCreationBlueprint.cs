using static Garage.Car;
using static Garage.PetroleumPowerSource;
using static Garage.Motorcycle;

namespace Garage
{
    public class VehicleCreationBlueprint
    {
        private Dictionary<string, object> data = new();
        public enum ePowerSource
        {
            Electric,
            Petrol
        }

        public enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }
        
        public string License
        {
            get { return (string)data["LicenseNum"]; }
            set { data.Add("LicenseNum", value); }
        }

        public string Model
        {
            get { return (string)data["Model"]; }
            set { data.Add("Model", value); }
        }

        public float CurrentAirPressure
        {
            get { return (float)data["CurrentAirPressure"]; }
            set { data.Add("CurrentAirPressure", value); }
        }

        public string WheelManufacturer
        {
            get { return (string)data["WheelManufacturer"]; }
            set { data.Add("WheelManufacturer", value); }
        }

        public float CurrentEnergyLevel
        {
            get { return (float)data["CurrentEnergyLevel"]; }
            set { data.Add("CurrentEnergyLevel", value); }
        }

        public string VehicleType
        {
            get { return data["VehicleType"].ToString(); }
            set { data.Add("VehicleType", VehicleTypeFromString(value)); }
        }

        public string PowerSource
        {
            get { return data["PowerSource"].ToString(); }
            set { data.Add("PowerSource", PowerSourceFromString(value)); }
        }

        public string CarColour
        {
            get { return data["CarColour"].ToString(); }
            set { data.Add("CarColour", ColourFromString(value)); }
        }

        public string CarDoorCount
        {
            get { return data["CarDoorCount"].ToString(); }
            set { data.Add("CarDoorCount", DoorCountFromString(value)); }
        }

        public string MotorcycleLicenseType
        {
            get { return data["MotorcycleLicenseType"].ToString(); }
            set { data.Add("MotorcycleLicenseType", LicenseTypeFromString(value)); }
        }
       
        public int MotorcycleEngineCapacity
        {
            get { return (int)data["MotorcycleEngineCapacity"]; }
            set { data.Add("MotorcycleEngineCapacity", value); }
        }
        
        public bool TruckIsDeliveringHazardousMaterials
        {
            get { return (bool)data["TruckIsDeliveringHazardousMaterials"]; }
            set { data.Add("TruckIsDeliveringHazardousMaterials", value); }
        }
        
        public float TruckTrunkCapacity
        {
            get { return (float)data["TruckTrunkCapacity"]; }
            set { data.Add("TruckTrunkCapacity", value); }

        }

        public string OwnerPhone
        {
            get { return (string)data["OwnerPhone"]; }
            set { data.Add("OwnerPhone", value); }
        }

        public string OwnerName
        {
            get { return (string)data["OwnerName"]; }
            set { data.Add("OwnerName", value); }
        }

        public void resetData()
        {
            data = new();
        }
        
        public string GetPetrolType()
        {
            string petrolType = string.Empty;
            switch (data["VehicleType"])
            {
                case eVehicleType.Car:
                    petrolType = "Octan95";
                    break;
                case eVehicleType.Motorcycle:
                    petrolType = "Octan98";
                    break;
                case eVehicleType.Truck:
                    petrolType = "Soler";
                    break;
            }
            return petrolType;
        }
        
        public float GetMaxEnergyCapacity()
        {
            float maxEnergyCapacity = 0;
            switch (data["VehicleType"])
            {
                case eVehicleType.Car:
                    maxEnergyCapacity = getCapacityBasedOnEnergy(46.0f, 5.2f);
                    break;
                case eVehicleType.Motorcycle:
                    maxEnergyCapacity = getCapacityBasedOnEnergy(6.4f, 2.6f); 
                    break;
                case eVehicleType.Truck:
                    maxEnergyCapacity = 135;
                    break;
            }
            return maxEnergyCapacity;
        }
        
        public static bool isDeliveringHazardousMaterialsFromString(string i_Input)
        {
            bool isDeliveringHazardousMaterials = false;
            switch (i_Input.ToLower())
            {
                case "yes":
                    isDeliveringHazardousMaterials = true;
                    break;
                case "no":
                    isDeliveringHazardousMaterials = false;
                    break;
                default:
                    throw new ArgumentException("Invalid answer on if truck is delivering hazardous materials");
            }

            return isDeliveringHazardousMaterials;
        }
        
        public static ePowerSource PowerSourceFromString(string i_PowerSource)
        {
            ePowerSource powerSource;
            switch (i_PowerSource.ToLower())
            {
                case "electric":
                    powerSource = ePowerSource.Electric;
                    break;
                case "petrol":
                    powerSource = ePowerSource.Petrol;
                    break;
                default:
                    throw new ArgumentException("Invalid power source");
            }
            return powerSource;
        }
        
        private float getCapacityBasedOnEnergy(float i_PetrolValue, float i_ElectricValue)
        {
            return data["PowerSource"].Equals(ePowerSource.Petrol) ? i_PetrolValue : i_ElectricValue;
        }

        public void EnsureNotExceedingMaxValues()
        {
            float maxAirPressure = GetMaxAirPressure();
            float maxEnergyLevel = GetMaxEnergyCapacity();
            
            if (CurrentAirPressure > maxAirPressure)
            {
                throw new ArgumentException(
                    string.Format("Current wheel air pressure - {0} exceeding the maximum of {1}", CurrentAirPressure, maxAirPressure));
            }
            
            if (CurrentEnergyLevel > maxEnergyLevel)
            {
                throw new ArgumentException(
                    string.Format("Current energy level remaining - {0} exceeding the maximum of {1}", CurrentEnergyLevel, maxEnergyLevel));
            }
        }
        
        public float GetMaxAirPressure()
        {
            float maxAirPressure = 0;
            switch (data["VehicleType"])
            {
                case eVehicleType.Car:
                    maxAirPressure = 33;
                    break;
                case eVehicleType.Motorcycle:
                    maxAirPressure = 31;
                    break;
                case eVehicleType.Truck:
                    maxAirPressure = 26;
                    break;
            }
            return maxAirPressure;
        }
        
        public int GetNumOfWheels()
        {
            int numOfWheels = 0;
            switch (data["VehicleType"])
            {
                case eVehicleType.Car:
                    numOfWheels = 5;
                    break;
                case eVehicleType.Motorcycle:
                    numOfWheels = 2;
                    break;
                case eVehicleType.Truck:
                    numOfWheels = 14;
                    break;
            }
            return numOfWheels;
        }

        public static eVehicleType VehicleTypeFromString(string i_VehicleType)
        {
            eVehicleType vehicleType;
            switch (i_VehicleType.ToLower())
            {
                case "car":
                    vehicleType = eVehicleType.Car;
                    break;
                case "motorcycle":
                    vehicleType = eVehicleType.Motorcycle;
                    break;
                case "truck":
                    vehicleType = eVehicleType.Truck;
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
            return vehicleType;
        }
    }   
}
