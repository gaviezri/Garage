using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private readonly string r_Model;
        private readonly string r_LicenseNumber;
        private List<Wheel> m_Wheels;
        private PowerSource m_PowerSource;

      

        public Vehicle(string i_Model, string i_LicenseNumber,
            Wheel[] i_Wheels, PowerSource i_PowerSource)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            m_Wheels = new List<Wheel>(i_Wheels);
            m_PowerSource = i_PowerSource;
        }

        internal PowerSource Powersource
        {
            get { return m_PowerSource; }
        }

        internal List<Wheel> Wheels { get { return m_Wheels; } }

        public void Fill(float i_AmountToFile)
        {
            m_PowerSource.Fill(i_AmountToFile);
        }

        public void InflateTyre(Dictionary<Wheel, float> i_WheelsInflation)
        {
            foreach (var wheelAndAmountToInflate in i_WheelsInflation)
            {
                wheelAndAmountToInflate.Key.Inflate(wheelAndAmountToInflate.Value);
            }
        }

        public override string ToString()
        {   
            StringBuilder sb = new StringBuilder();
            foreach (Wheel wheel in m_Wheels)
            {
                sb.AppendLine(wheel.ToString());
            }
            return $"Model: {r_Model}\nLicense No.: {r_LicenseNumber}\nWheels details:\n{sb}\n{m_PowerSource}";
        }
    }
}

