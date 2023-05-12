namespace Garage
{
    internal class ElectricPowerSource : PowerSource
    {
        private float m_RemainingBattery { get; set; }
        private readonly float r_MaximumBattery;

        internal ElectricPowerSource(float i_remainingBattery, float i_maximumBattery)
        {
            m_RemainingBattery = i_remainingBattery;
            r_MaximumBattery = i_maximumBattery;
        }

        internal override bool AmountInRange(float i_Amount)
        {
            return i_Amount > 0 && (m_RemainingBattery + i_Amount) < r_MaximumBattery;
        }

        internal override void Fill(float i_Amount)
        {
            if (AmountInRange(i_Amount))
            {
                m_RemainingBattery += i_Amount;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_RemainingBattery);
            }
        }

        internal override float GetDeltaFromFullCapacity()
        {
            return r_MaximumBattery - m_RemainingBattery;
        }

        public override string ToString()
        {
            return "Electric Power Source\n" +
                   $"Remaining Battery: {m_RemainingBattery}\n" +
                   $"Maximum Battery: {r_MaximumBattery}\n";
        }
    }
}
