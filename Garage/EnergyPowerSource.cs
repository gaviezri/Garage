namespace Garage
{
    internal class EnergyPowerSource : PowerSource
    {
        private float m_RemainingBattery { get; set; }
        private readonly float m_MaximumBattery;

        internal EnergyPowerSource(float i_remainingBattery, float i_maximumBattery)
        {
            m_RemainingBattery = i_remainingBattery;
            m_MaximumBattery = i_maximumBattery;
        }

        internal override void Fill(float i_Amount)
        {
            if (AmountInRange(i_Amount,m_RemainingBattery,m_MaximumBattery))
            {
                m_RemainingBattery += i_Amount;
            }
            else 
            {
                // throw new ValueOutOfRange(...)
            }

        }
    }
}
