﻿namespace Ex03.GarageLogic
{
    internal class VehicleCreator
    {
        internal static Vehicle CreateVehicle(VehicleCreationBlueprint i_Blueprint)
        {
            Vehicle vehicle = null;

            switch (i_Blueprint.VehicleType.ToLower())
            {
                case "car":
                    vehicle = createCar(i_Blueprint);
                    break;
                case "motorcycle":
                    vehicle = createMotorcycle(i_Blueprint);
                    break;
                case "truck":
                    vehicle = createTruck(i_Blueprint);
                    break;
            }
            
            return vehicle;
        }

        private static Car createCar(VehicleCreationBlueprint i_Blueprint)
        {
            return new Car(i_Blueprint.Model,
                           i_Blueprint.License,
                           createWheels(i_Blueprint),
                           createPowerSource(i_Blueprint),
                           Car.ColourFromString(i_Blueprint.CarColour),
                           Car.DoorCountFromString(i_Blueprint.CarDoorCount));
        }

        private static Motorcycle createMotorcycle(VehicleCreationBlueprint i_Blueprint)
        {
            return new Motorcycle(i_Blueprint.Model,
                                  i_Blueprint.License,
                                  createWheels(i_Blueprint),
                                  createPowerSource(i_Blueprint),
                                  Motorcycle.LicenseTypeFromString(i_Blueprint.MotorcycleLicenseType),
                                  i_Blueprint.MotorcycleEngineCapacity);
        }

        private static Truck createTruck(VehicleCreationBlueprint i_Blueprint)
        {
            return new Truck(i_Blueprint.Model,
                             i_Blueprint.License,
                             createWheels(i_Blueprint),
                             createPowerSource(i_Blueprint),
                             i_Blueprint.TruckIsDeliveringHazardousMaterials,
                             i_Blueprint.TruckTrunkCapacity);
        }

        private static PowerSource createPowerSource(VehicleCreationBlueprint i_Blueprint)
        {
            PowerSource powerSource;

            switch (i_Blueprint.PowerSource.ToLower())
            {
                case "electric":
                    powerSource = new ElectricPowerSource(i_Blueprint.CurrentEnergyLevel, i_Blueprint.GetMaxEnergyCapacity());
                    break;
                case "petrol":
                    powerSource = new PetroleumPowerSource(i_Blueprint.CurrentEnergyLevel, i_Blueprint.GetMaxEnergyCapacity(), i_Blueprint.GetPetrolType());
                    break;
                default:
                    throw new ArgumentException("Invalid power source");
            }
            
            return powerSource;
        }

        private static Wheel[] createWheels(VehicleCreationBlueprint i_Blueprint)
        {
            int numOfWheels = i_Blueprint.GetNumOfWheels();
            Wheel[] wheels = new Wheel[numOfWheels];

            for (int i = 0; i < numOfWheels; i++)
            {
                wheels[i] = new Wheel(i_Blueprint.WheelManufacturer, i_Blueprint.CurrentAirPressure, i_Blueprint.GetMaxAirPressure());
            }
            
            return wheels;
        }
    }
}
