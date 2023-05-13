namespace Ex03.GarageLogic
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
            switch(i_Colour.ToLower())
            {
                case "white":
                    colour = eColour.White;
                    break;
                case "black":
                    colour = eColour.Black;
                    break;
                case "yellow":
                    colour = eColour.Yellow;
                    break;
                case "red":
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
                case "2":
                    doorCount = eDoorCount.Two;
                    break;
                case "Three":
                case "3":
                    doorCount = eDoorCount.Three;
                    break;
                case "Four":
                case "4":
                    doorCount = eDoorCount.Four;
                    break;
                case "Five":
                case "5":
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
