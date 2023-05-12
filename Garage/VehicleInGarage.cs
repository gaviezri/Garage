namespace Garage
{
    internal class VehicleInGarage
    {
        internal enum eStatus
        {
            preService,
            postService,
            Paid
        }
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;
        private readonly string r_LicenseNum;
        private eStatus m_status { get; set;}

        internal VehicleInGarage(string i_OwnerName, string i_OwnerPhone, string i_LicenseNum)
        {
            r_LicenseNum = i_LicenseNum;
            r_OwnerName = i_OwnerName;  
            r_OwnerPhone = i_OwnerPhone;
            m_status = eStatus.preService;
        }

    }
}
