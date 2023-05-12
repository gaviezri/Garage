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

        internal PetroleumPowerSource(float i_RemainingTank, float i_MaximumTank, ePetrolType i_Type)
        {
            m_RemainingTank = i_RemainingTank;
            r_MaximumTank = i_MaximumTank;
            m_Type = i_Type;
        }
        
        internal override void Fill(float i_Amount)
        {
            if(AmountInRange(i_Amount, m_RemainingTank, r_MaximumTank))
            {
                m_RemainingTank += i_Amount;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_RemainingTank);
            }
        }
    }
}
