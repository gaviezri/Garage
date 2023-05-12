namespace Garage
{
    internal class Truck : Vehicle
    {
        private readonly bool r_isDeliveringHazardousMatriels;
        private readonly int r_TrunkCapacity;

        public Truck(string i_Model, string i_LicenseNumber, float i_PercentageOfEnergyLeft, 
            Wheel[] i_Wheels, PowerSource i_PowerSource, bool i_isDeliveringHazardousMatriels, int i_TrunkCapacity) : 
            base(i_Model, i_LicenseNumber, i_PercentageOfEnergyLeft, i_Wheels, i_PowerSource)
        {
            r_isDeliveringHazardousMatriels = i_isDeliveringHazardousMatriels;
            r_TrunkCapacity = i_TrunkCapacity;
        }
    }
}