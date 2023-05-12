namespace Garage
{
    internal class Car : Vehicle
    {
        private readonly eColour r_Colour;
        private readonly eDoorCount r_DoorCount;

        public Car(string i_Model, string i_LicenseNumber, float i_PercentageOfEnergyLeft, 
            Wheel[] i_Wheels, PowerSource i_PowerSource, eColour i_Colour, eDoorCount i_DoorCount) : 
            base(i_Model, i_LicenseNumber, i_PercentageOfEnergyLeft, i_Wheels, i_PowerSource)
        {
            r_Colour = i_Colour;
            r_DoorCount = i_DoorCount;
        }

        public enum eColour
        {
            White,
            Black,
            Yellow,
            Red
        }
        
        public enum eDoorCount
        {
            Two,
            Three,
            Four,
            Five
        }
    }
}
