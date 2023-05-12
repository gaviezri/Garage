namespace Garage
{
    internal class Bike : Vehicle
    {
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;
    
        public Bike(string i_Model, string i_LicenseNumber, float i_PercentageOfEnergyLeft, 
            Wheel[] i_Wheels, PowerSource i_PowerSource, eLicenseType i_LicenseType, int i_EngineCapacity) : 
            base(i_Model, i_LicenseNumber, i_PercentageOfEnergyLeft, i_Wheels, i_PowerSource)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }
    
        public enum eLicenseType
        {
            A1,
            A2,
            AA,
            B1
        }
    }
}

