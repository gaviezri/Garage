using System.Threading.Channels;
using Garage;

namespace UserInterface
{
    public class UserInterface
    {
        const string k_LineDeleter = "                                                    \n                                                ";
        const int k_MainMenuFirst = 1;
        const int k_MainMenuLast = 8;
        const int k_FilterMenuFirst = 1;
        const int k_FilterMenuLast = 4;
        const int k_StatusMenuFirst = 1;
        const int k_StatusMenuLast = 3;
        
        public void StartInteraction()
        {
            GarageManager garageManager = GarageManager.getManager();
            bool isQuit = false;
            
            while (!isQuit)
            {
                showMainMenu();
                int userInput = getUserInput(k_MainMenuFirst, k_MainMenuLast);
                performAction(garageManager, userInput, out isQuit);
                switch (userInput)
                {
                    
                }
            }
        }

        private static int getUserInput(int i_LowerBound, int i_UpperBound)
        {
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            bool isValidInput = false;
            int result = 0;

            Console.Write("Selection: ");
            while (!isValidInput)
            {
                string input = Console.ReadLine();
                try
                {
                    int inputAsInt = int.Parse(input);
                    if (inputAsInt >= i_LowerBound && inputAsInt <= i_UpperBound)
                    {
                        isValidInput = true;
                        result = inputAsInt;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("{0} is not a not number between {1} and {2}", input,
                            i_LowerBound, i_UpperBound));
                    }
                }
                catch (ArgumentException exception)
                {
                    Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.Write(k_LineDeleter);
                    Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.WriteLine(exception.Message);
                    Console.Write("Please try again: ");
                    continue;
                }
                catch (Exception exception)
                {
                    Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.Write(k_LineDeleter);
                    Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.Write("Invalid input. Please try again: ");
                    continue;
                }

                isValidInput = true;
            }

            return result;
        }

        private static void showMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to our garage!");
            Console.WriteLine("=============================");
            Console.WriteLine("Please choose an action:");
            Console.WriteLine("1. Insert a vehicle to the garage");
            Console.WriteLine("2. List all vehicles' license numbers in the garage");
            Console.WriteLine("3. Change a vehicle's status");
            Console.WriteLine("4. Inflate a vehicle's tyres to maximum capacity");
            Console.WriteLine("5. Fill a gas-powered vehicle's tank");
            Console.WriteLine("6. Charge an electric-powered vehicle's battery");
            Console.WriteLine("7. Show all details of a vehicle");
            Console.WriteLine("8. Quit");
        }

        private void performAction(GarageManager i_GarageManager, int i_UserInput, out bool o_IsQuit)
        {
            o_IsQuit = false;
            switch (i_UserInput)
            {
                case 1:
                    insertVehicleToGarage(i_GarageManager);
                    break;
                case 2:
                    listAllLicenseNumbers(i_GarageManager);
                    break;
                case 3:
                    changeExistingVehicleStatus(i_GarageManager);
                    break;
                case 4:
                    inflateTyresToMaximum(i_GarageManager);
                    break;
                case 5:
                    fillGasTankWithQuantity(i_GarageManager);
                    break;
                case 6:
                    chargeBatteryWithQuantity(i_GarageManager);
                    break;
                case 7:
                    // showVehicleDetails
                case 8:
                    o_IsQuit = true;
                    break;
            }
        }

        private void insertVehicleToGarage(GarageManager i_GarageManager)
        {
            Console.WriteLine("Please enter a vehicle's license number");
            string inputLicenseNumber = Console.ReadLine();
            
            try
            {
                changeExistingVehicleStatus(i_GarageManager, "PreService");
            }
            catch (VehicleNotExistsException exception)
            {
                
            }
        }

        private void listAllLicenseNumbers(GarageManager i_GarageManager)
        {
            string statusFilter = convertInputToStatus(getStatusFilter());
            List<string> licenseNumbers = i_GarageManager.GetAllVehiclesLicense(statusFilter);
            
            foreach (var licenseNumber in licenseNumbers)
            {
                Console.WriteLine(licenseNumber);
            }
            
            pressAnyKeyToContinue();
        }

        private void inflateTyresToMaximum(GarageManager i_GarageManager)
        {
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            string licenseNumber;
            
            while (true)
            {
                try
                {
                    licenseNumber = getLicenseNumber();
                    i_GarageManager.InflateTyresToMaximum(licenseNumber);
                    break;
                }
                catch (VehicleNotExistsException exception)
                {
                    resetInput(originalCursorLeft, originalCursorTop);
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Please try again:");
                }
            }
            
            Console.WriteLine("Tyres inflated successfully!");
            pressAnyKeyToContinue();
        }

        private void fillGasTankWithQuantity(GarageManager i_GarageManager)
        {
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            string licenseNumber;
            float quantityToFill;
            string fuelType;
            
            while (true)
            {
                try
                {
                    licenseNumber = getLicenseNumber();
                    quantityToFill = getGasQuantity();
                    fuelType = getFuelType();
                    i_GarageManager.FillTankWithQuantity(licenseNumber, quantityToFill, fuelType);
                    break;
                }
                catch (Exception exception)
                {
                    resetInput(originalCursorLeft, originalCursorTop);
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Please try again:");
                }
            }
            
            Console.WriteLine("Gas tank filled successfully!");
            pressAnyKeyToContinue();
        }
        
        private void chargeBatteryWithQuantity(GarageManager i_GarageManager)
        {
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            string licenseNumber;
            float quantityToCharge;

            while (true)
            {
                try
                {
                    licenseNumber = getLicenseNumber();
                    quantityToCharge = getQuantityToCharge();
                    i_GarageManager.ChargeBatteryWithQuantity(licenseNumber, quantityToCharge);
                    break;
                }
                catch (Exception exception)
                {
                    resetInput(originalCursorLeft, originalCursorTop);
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Please try again:");
                }
            }
            
            Console.WriteLine("Gas tank filled successfully!");
            pressAnyKeyToContinue();
        }

        private static int getStatusFilter()
        {
            Console.Clear();
            Console.WriteLine("Choose a status to filter on or choose no filter");
            Console.WriteLine("1. In service");
            Console.WriteLine("2. Post service");
            Console.WriteLine("3. Paid for");
            Console.WriteLine("4. No filter");
            return getUserInput(k_FilterMenuFirst, k_FilterMenuLast);
        }
        
        private static string getStatus()
        {
            Console.Clear();
            Console.WriteLine("Choose a status:");
            Console.WriteLine("1. In service");
            Console.WriteLine("2. Post service");
            Console.WriteLine("3. Paid for");
            return convertInputToStatus(getUserInput(k_StatusMenuFirst, k_StatusMenuLast));
        }

        private static string convertInputToStatus(int i_InputStatusFilter)
        {
            string statusFilter = "";
            
            switch (i_InputStatusFilter)
            {
                case 1:
                    statusFilter = "PreService";
                    break;
                case 2:
                    statusFilter = "PostService";
                    break;
                case 3:
                    statusFilter = "Paid";
                    break;
            }

            return statusFilter;
        }

        private void changeExistingVehicleStatus(GarageManager i_GarageManager, string i_Status="")
        {
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            string licenseNumber;
            string newStatus;

            while (true)
            {
                try
                {
                    licenseNumber = getLicenseNumber();
                    if (i_Status != "")
                    {
                        newStatus = getStatus();
                    }
                    else
                    {
                        newStatus = i_Status;
                    }

                    i_GarageManager.UpdateExistingVehicleStatus(licenseNumber, newStatus);
                    break;
                }
                catch (VehicleNotExistsException exception)
                {
                    if (i_Status != "")
                    {
                        throw exception;
                    }
                    
                    resetInput(originalCursorLeft, originalCursorTop);
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Please try again:");
                }
                catch (Exception exception)
                {
                    resetInput(originalCursorLeft, originalCursorTop);
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Please try again:");
                }
            }
            
            Console.WriteLine("Status changed successfully!");
            pressAnyKeyToContinue();
        }

        private static string getLicenseNumber()
        {
            Console.WriteLine("Please enter a vehicle's license number:");
            return Console.ReadLine();
        }
        
        private static string getFuelType()
        {
            Console.WriteLine("Please enter fuel type:");
            return Console.ReadLine();
        }

        private static float getGasQuantity()
        {
            Console.WriteLine("Please enter amount of gas:");
            string quantityInput =  Console.ReadLine();

            if (!float.TryParse(quantityInput, out float gasQuantity))
            {
                gasQuantity = -1;
            }

            return gasQuantity;
        }
        
        private static float getQuantityToCharge()
        {
            Console.WriteLine("Please enter amount of time in minutes to charge:");
            string quantityInput =  Console.ReadLine();

            if (!float.TryParse(quantityInput, out float gasQuantity))
            {
                gasQuantity = -1;
            }

            return gasQuantity;
        }

        private static void resetInput(int i_OriginalCursorLeft, int i_OriginalCursorTop)
        {
            Console.SetCursorPosition(i_OriginalCursorLeft, i_OriginalCursorTop);
            Console.Write(k_LineDeleter);
            Console.SetCursorPosition(i_OriginalCursorLeft, i_OriginalCursorTop);
        }

        private static void pressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey(true);
        }
    }
}

