using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageManager
    {
        private static GarageManager? instance = null;
        List<VehicleInGarage> m_VehiclesInGarage;
        //Dictionary<string, Vehicle> m_LicenseNum2Vehicle;

        // implements the singleton dp
        private GarageManager()
        {
            m_VehiclesInGarage = new List<VehicleInGarage>();
            //m_LicenseNum2Vehicle = new Dictionary<string,Vehicle>();
        }
        // to interact with the manager, use this method to obtain a reference
        public GarageManager getManager()
        {
            if (instance == null) 
            {
                instance = new GarageManager();
            }
            return instance;
        }



    }
}
