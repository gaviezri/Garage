namespace Garage
{
    internal class Bike : Vehicle
    {
        private readonly eLicenseType m_LicenseType;
        private readonly int m_EngineCapacity;
    
        public Bike(string i_Model, string i_LicenseNumber, float i_PercentageOfEnergyLeft, 
            Wheel[] i_Wheels, PowerSource i_PowerSource, eLicenseType i_LicenseType, int i_EngineCapacity) : 
            base(i_Model, i_LicenseNumber, i_PercentageOfEnergyLeft, i_Wheels, i_PowerSource)
        {
            m_LicenseType = i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
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

