namespace Garage
{
    internal class VehicleInGarage
    {
        internal enum eStatus
        {
            PreService,
            PostService,
            Paid
        }
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;
        private readonly string r_LicenseNum;
        private eStatus m_Status;

        internal string LicenseNum
        {
            get { return r_LicenseNum;}    
        }

        internal eStatus Status
        {
            get { return m_Status;  }
            set { m_Status = value; }
        }

        internal VehicleInGarage(string i_OwnerName, string i_OwnerPhone, string i_LicenseNum)
        {
            r_LicenseNum = i_LicenseNum;
            r_OwnerName = i_OwnerName;  
            r_OwnerPhone = i_OwnerPhone;
            m_Status = eStatus.PreService;
        }
        
        internal static eStatus eStatusFromString(string str)
        {   
            eStatus value;
            switch (str)
            {
                case "PreService":
                    value = eStatus.PreService;
                    break;
                case "PostService":
                    value = eStatus.PostService;
                    break;
                case "Paid":
                    value = eStatus.Paid;
                    break;
                default:
                    throw new ArgumentException(string.Format("eStatus is not parseable from {0}", str));
            }
            return value;
        }
        
    }
}
