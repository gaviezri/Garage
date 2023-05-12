namespace Garage
{
    internal abstract class PowerSource : Fillable
    {
        internal abstract void Fill(float i_Amount);
        internal abstract float GetDeltaFromFullCapacity();
    }
}
