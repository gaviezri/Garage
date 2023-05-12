namespace Garage
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

        internal void Inflate(float i_Amount)
        {
            if (Fillable.AmountInRange(i_Amount, m_CurrentPressure, r_MaximumPressure))
            {
                m_CurrentPressure += i_Amount;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaximumPressure - m_CurrentPressure);
            }
        }
        internal float  GetPressureDeltaFromMaximum() { return r_MaximumPressure-m_CurrentPressure;}
    }
}
