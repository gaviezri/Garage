namespace Garage
{
    internal class Motorcycle : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        internal Motorcycle(string i_Model, string i_LicenseNumber, Wheel[] i_Wheels,
            PowerSource i_PowerSource, eLicenseType i_LicenseType, int i_EngineCapacity) : 
            base(i_Model, i_LicenseNumber, i_Wheels, i_PowerSource)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        internal static eLicenseType LicenseTypeFromString(string i_LicenseType)
        {
            eLicenseType licenseType;
            switch(i_LicenseType)
            {
                case "A1":
                    licenseType = eLicenseType.A1;
                    break;
                case "A2":
                    licenseType = eLicenseType.A2;
                    break;
                case "AA":
                    licenseType = eLicenseType.AA;
                    break;
                case "B1":
                    licenseType = eLicenseType.B1;
                    break;
                default:
                    throw new ArgumentException("Invalid license type");
            }
            return licenseType;
        }

        internal enum eLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }
    }
}

