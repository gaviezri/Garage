namespace Garage
{
    internal class PetroleumPowerSource : PowerSource
    {
        internal enum PetrolType
        {
            Soler, Octan95, Octan96, Octan98
        }
        
        private float m_RemainingTank;
        private readonly float m_MaximumTank;
        private PetrolType m_Type;

        internal PetroleumPowerSource(float i_RemainingTank, float i_MaximumTank, PetrolType i_Type)
        {
            m_RemainingTank = i_RemainingTank;
            m_MaximumTank = i_MaximumTank;
            m_Type = i_Type;
        }
        internal override void Fill(float i_Amount)
        {
            if(AmountInRange(i_Amount, m_RemainingTank, m_MaximumTank))
            {
                m_RemainingTank += i_Amount;
            }
            else
            {
                // throw new ValueOutOfRange(...)
            }
        }
    }
}
