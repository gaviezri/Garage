namespace Garage
{
    internal abstract class PowerSource
    {
        internal abstract void Fill(float i_Amount);
        protected static bool AmountInRange(float i_Amount, float i_Current, float i_Max)
        {
            return i_Amount > 0 && ((i_Amount + i_Current) <= i_Max);
        }
    }
}
