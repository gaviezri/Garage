namespace Garage
{
    internal class Truck : Vehicle
    {
        private bool m_isDeliveringHazardousMatriels;
        private int m_TrunkCapacity;

        public Truck(string i_Model, string i_LicenseNumber, float i_PercentageOfEnergyLeft, 
            Wheel[] i_Wheels, PowerSource i_PowerSource, bool i_isDeliveringHazardousMatriels, int i_TrunkCapacity) : 
            base(i_Model, i_LicenseNumber, i_PercentageOfEnergyLeft, i_Wheels, i_PowerSource)
        {
            m_isDeliveringHazardousMatriels = i_isDeliveringHazardousMatriels;
            m_TrunkCapacity = i_TrunkCapacity;
        }
    }
}