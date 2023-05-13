namespace Ex03.GarageLogic
{
    public class VehicleNotExistsException : Exception
    {
        public VehicleNotExistsException(string i_LicenseNum) :
            base($"Vehicle with License No. {i_LicenseNum} does not exist in the garage.") { }

        public VehicleNotExistsException(string i_LicenseNUm, bool showLicense) :
            base(i_LicenseNUm) {}
    }
}
