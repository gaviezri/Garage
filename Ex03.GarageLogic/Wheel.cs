namespace Ex03.GarageLogic
{
    internal class Wheel : Fillable
    {
        private string m_Manufacturer;
        private float m_CurrentPressure;
        private readonly float r_MaximumPressure;

        internal Wheel(string i_Manufacturer, float i_CurrentPressure, float i_MaximumPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentPressure = i_CurrentPressure;
            r_MaximumPressure = i_MaximumPressure;  
        }

        internal override bool AmountInRange(float i_Amount)
        {
            return i_Amount > 0 && (i_Amount + m_CurrentPressure) <= r_MaximumPressure;
        }

        internal void Inflate(float i_Amount)
        {
            if (AmountInRange(i_Amount))
            {
                m_CurrentPressure += i_Amount;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaximumPressure - m_CurrentPressure);
            }
        }
        internal float  GetPressureDeltaFromMaximum() { return r_MaximumPressure - m_CurrentPressure;}

        public override string ToString()
        {
            return $"\nManufactured By: {m_Manufacturer}\nPressure: {m_CurrentPressure}\nMax Pressure: {r_MaximumPressure}";
        }
    }

}
