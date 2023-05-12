using static Garage.Car;
using static Garage.PetroleumPowerSource;
using static Garage.Motorcycle;

namespace Garage
{
    public class VehicleCreationBlueprint
    {
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

        Dictionary<string, object> data = new();


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

        public int NumOfWheels
        {
            get { return (int)data["NumOfWheels"]; }
            set { data.Add("NumOfWheels", value); }
        }

        public float MaxAirPressure
        {
            get { return (float)data["MaxAirPressure"]; }
            set { data.Add("MaxAirPressure", value); }
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

        public float MaxEnergyCapacity
        {
            get { return (float)data["MaxEnergyCapacity"]; }
            set { data.Add("MaxEnergyCapacity", value); }
        }

        public float CurrentEnergyLevel
        {
            get { return (float)data["CurrentEnergyLevel"]; }
            set { data.Add("CurrentEnergyLevel", value); }
        }

        public ePetrolType PetrolType
        {
            get { return data["PetrolType"]; }
            set { data.Add("PetrolType", PetrolTypeFromString(value)); }
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

    }   
}
