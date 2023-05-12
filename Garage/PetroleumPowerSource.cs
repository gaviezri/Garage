namespace Garage
{
    internal class PetroleumPowerSource : PowerSource
    {
        internal enum ePetrolType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
        
        private float m_RemainingTank;
        private readonly float r_MaximumTank;
        private ePetrolType m_Type;

        public ePetrolType PetrolType { get { return m_Type; } }

        internal PetroleumPowerSource(float i_RemainingTank, float i_MaximumTank, string i_Type)
        {
            m_RemainingTank = i_RemainingTank;
            r_MaximumTank = i_MaximumTank;
            m_Type = PetrolTypeFromString(i_Type);
        }

        internal override bool AmountInRange(float i_Amount)
        {
            return i_Amount > 0 && (i_Amount + m_RemainingTank) < r_MaximumTank;
        }
        internal override void Fill(float i_Amount)
        {
            if(AmountInRange(i_Amount))
            {
                m_RemainingTank += i_Amount;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_RemainingTank);
            }
        }

        internal override float GetDeltaFromFullCapacity()
        {
            return r_MaximumTank - m_RemainingTank;
        }

        internal static ePetrolType PetrolTypeFromString(string str)
        {
            ePetrolType ePet;
            switch(str)
            {
                case "Soler":
                    ePet = ePetrolType.Soler;
                    break;
                case "Octan95":
                    ePet = ePetrolType.Octan95;
                    break;
                case "Octan96":
                    ePet = ePetrolType.Octan96;
                    break;
                case "Octan98":
                    ePet = ePetrolType.Octan98;
                    break;
                default:
                    throw new ArgumentException($"ePetrolType is not parseable from \"{str}\"");
            }
            return ePet;
        }
    }
}
