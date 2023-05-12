namespace Garage
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base($"Value is out of range. Valid range is: {i_MinValue} - {i_MaxValue}")
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
