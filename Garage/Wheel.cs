namespace Garage
{
    internal class Wheel
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
            if (i_Amount < 0 || (i_Amount + m_CurrentPressure > r_MaximumPressure) )
            {
                // throw new ValueOutOfRangeException("...");
            }
            m_CurrentPressure += i_Amount;
        }
    }
}
