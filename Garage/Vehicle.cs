namespace Garage
{
    internal abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private float m_PercentageOfEnergyLeft;
        private Wheel[] m_Wheels;
        private PowerSource m_PowerSource;

        public Vehicle(string i_Model, string i_LicenseNumber, float i_PercentageOfEnergyLeft, 
            Wheel[] i_Wheels, PowerSource i_PowerSource)
        {
            m_Model = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            m_PercentageOfEnergyLeft = i_PercentageOfEnergyLeft;
            m_Wheels = i_Wheels;
            m_PowerSource = i_PowerSource;
        }

        public void Fill(float i_AmountToFile)
        {
            try
            {
                m_PowerSource.Fill(i_AmountToFile);
            }
            catch (ValueOutOfRangeException exception)
            {
                
            }
        }

        public void InflateTyre(Dictionary<Wheel, float> i_WheelsInflation)
        {
            try
            {
                foreach (var wheelAndAmountToInflate in i_WheelsInflation)
                {
                    wheelAndAmountToInflate.Key.Inflate(wheelAndAmountToInflate.Value);
                }
            }
            catch (ValueOutOfRangeException exception)
            {
                
            }
        }
    }
}

