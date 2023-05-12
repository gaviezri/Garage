namespace Garage
{
    internal class Car : Vehicle
    {
        private readonly eColour r_Colour;
        private readonly eDoorCount r_DoorCount;

        internal Car(string i_Model, string i_LicenseNumber, Wheel[] i_Wheels, PowerSource i_PowerSource,
            eColour i_Colour, eDoorCount i_DoorCount) : 
            base(i_Model, i_LicenseNumber, i_Wheels, i_PowerSource)
        {
            r_Colour = i_Colour;
            r_DoorCount = i_DoorCount;
        }

        internal static eColour ColourFromString(string i_Colour)
        {
            eColour colour;
            switch(i_Colour)
            {
                case "White":
                    colour = eColour.White;
                    break;
                case "Black":
                    colour = eColour.Black;
                    break;
                case "Yellow":
                    colour = eColour.Yellow;
                    break;
                case "Red":
                    colour = eColour.Red;
                    break;
                default:
                    throw new ArgumentException("Invalid colour");
            }
            return colour;
        }

        internal static eDoorCount DoorCountFromString(string i_DoourCount)
        {
            eDoorCount doorCount;
            switch(i_DoourCount)
            {
                case "Two":
                    doorCount = eDoorCount.Two;
                    break;
                case "Three":
                    doorCount = eDoorCount.Three;
                    break;
                case "Four":
                    doorCount = eDoorCount.Four;
                    break;
                case "Five":
                    doorCount = eDoorCount.Five;
                    break;
                default:
                    throw new ArgumentException("Invalid door count");
            }
            return doorCount;
        }

        internal enum eColour
        {
            White,
            Black,
            Yellow,
            Red
        }

        internal enum eDoorCount
        {
            Two,
            Three,
            Four,
            Five
        }

        public override string ToString()
        {

            return "Car" + $"\nColour: {r_Colour}\nDoor Count: {r_DoorCount}\n" + base.ToString();
        }
    }
}
