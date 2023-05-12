using static Garage.Car;
using static Garage.PetroleumPowerSource;
using static Garage.Motorcycle;

namespace Garage
{
    public class VehicleCreationBlueprint
    {   
        Dictionary<string, object> data = new();

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


        //public float MaxAirPressure
        //{
        //    get { return (float)data["MaxAirPressure"]; }
        //    set { data.Add("MaxAirPressure", value); }
        //}


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
            get { return (string)data["VehicleType"]; }
            set { data.Add("VehicleType", VehicleTypeFromString(value)); }
        }

        public string PowerSource
        {
            get { return (string)data["PowerSource"]; }
            set { data.Add("PowerSource", PowerSourceFromString(value)); }
        }

        public string CarColour
        {
            get { return (string)data["CarColour"]; }
            set { data.Add("CarColour", ColourFromString(value)); }
        }

        public string CarDoorCount
        {
            get { return (string)data["CarDoorCount"]; }
            set { data.Add("CarDoorCount", DoorCountFromString(value)); }
        }

        public string MotorcycleLicenseType
        {
            get { return (string)data["MotorcycleLicenseType"]; }
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
        
        public int TruckTrunkCapacity
        {
            get { return (int)data["TruckTrunkCapacity"]; }
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

        private float getCapacityBasedOnEnergy(float i_PetrolValue, float i_ElectricValue)
        {
            return data["PowerSource"].Equals(ePowerSource.Petrol) ? i_PetrolValue : i_ElectricValue;
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
        //public float MaxEnergyCapacity
        //{
        //    get { return (float)data["MaxEnergyCapacity"]; }
        //    set { data.Add("MaxEnergyCapacity", value); }
        //}

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

        public static ePowerSource PowerSourceFromString(string i_PowerSource)
        {
            ePowerSource powerSource;
            switch (i_PowerSource)
            {
                case "Electric":
                    powerSource = ePowerSource.Electric;
                    break;
                case "Petrol":
                    powerSource = ePowerSource.Petrol;
                    break;
                default:
                    throw new ArgumentException("Invalid power source");
            }
            return powerSource;
        }

        public static eVehicleType VehicleTypeFromString(string i_VehicleType)
        {
            eVehicleType vehicleType;
            switch (i_VehicleType)
            {
                case "Car":
                    vehicleType = eVehicleType.Car;
                    break;
                case "Motorcycle":
                    vehicleType = eVehicleType.Motorcycle;
                    break;
                case "Truck":
                    vehicleType = eVehicleType.Truck;
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
            return vehicleType;
        }
    }   
}
