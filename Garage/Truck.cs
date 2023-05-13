namespace Garage
{
    internal class Truck : Vehicle
    {
        private readonly bool r_isDeliveringHazardousMaterials;
        private readonly float r_TrunkCapacity;

        internal Truck(string i_Model, string i_LicenseNumber, Wheel[] i_Wheels,
            PowerSource i_PowerSource, bool i_isDeliveringHazardousMaterials, float i_TrunkCapacity) : 
            base(i_Model, i_LicenseNumber, i_Wheels, i_PowerSource)
        {
            r_isDeliveringHazardousMaterials = i_isDeliveringHazardousMaterials;
            r_TrunkCapacity = i_TrunkCapacity;
        }

        public override string ToString()
        {
            return "Truck" +
                   $"Delivers Hazardous Materials: {r_isDeliveringHazardousMaterials}\n" +
                   $"Trunk Volume: {r_TrunkCapacity}\n" +
                   base.ToString();
        }
    }
}