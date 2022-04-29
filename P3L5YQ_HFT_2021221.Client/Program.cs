using System;
using P3L5YQ_HFT_2021221.Client;
using P3L5YQ_HFT_2021221.Models;
using System.Collections.Generic;
using ConsoleTools;
using P3L5YQ_HFT_2021221.Models.HelperClasses;

namespace P3L5YQ_HFT_2021221
{
    class Program
    {

        #region ListAlls
        protected static void ListAllEngine(RestService restServices)
        {
            Console.Clear();
            var generalisedItem = restServices.Get<Engine>("engine");
            generalisedItem.ForEach(engine => Console.WriteLine("EngineID: " + engine.EngineId + "Engine Type: " + engine.EngineType + "Engine Name: " + engine.Enginename + "Displacement: " + engine.Displacement + "Fueltype: " + engine.Fuelage + "Eurorating: " + engine.EruroRating + "Power outpot (hp), Torque (Nm): " + engine.PowerOutput, engine.Torque));
            Console.WriteLine("\nPress any key to get back!");
            Console.ReadLine();
        }
        protected static void ListAllTrimLevel(RestService restServices)
        {
            Console.Clear();
            var generalisedItem = restServices.Get<TrimLevel>("trimlevel");
            generalisedItem.ForEach(trimLevel => Console.WriteLine("Trimlevel name: " + trimLevel.TrimPackageName + "AC(y/n): " + trimLevel.AC.ToString() + "AlcantaraInterrior(y/n): " + trimLevel.AlcantaraInterrior + "Chasis type: " + trimLevel.Chasis.ToString() + "Number of doors: " + trimLevel.NumberofDoors));
            Console.WriteLine("\nPress any key to get back!");
            Console.ReadLine();
        }
        protected static void ListAllCar(RestService restServices)
        {
            Console.Clear();
            var generalisedItem = restServices.Get<Car>("car");
            generalisedItem.ForEach(car => Console.WriteLine("CarID: " + car.CarId + "Type: " + car.Type /*+ "Manufyear: " + car.ManufDate + "Condition(New:Y/N): " + car.Condition + "Price: " + car.Price + "Mileage: " + car.Mileage + "Color: " + car.ChasisColor*/));
            Console.WriteLine("\nPress any key to get back!");
            Console.ReadLine();
        }
        #endregion

        #region CarCrudMethods
        protected static void CarCreate(RestService restServices)
        {
            Car newCar = new Car();
            #region CarId
            int cid = 0;
            do
            {
                Console.WriteLine("Please give a car ID between 1 and 999 (int):");
                cid = Convert.ToInt32(Console.ReadLine());
            } while (!(cid > 0 && cid < 1000));
            newCar.EngineId = cid;
            #endregion
            #region EngineId
            int carpckg = 0;
            do
            {
                Console.WriteLine("Please give an engine ID between 1 and 9 (int):");
                carpckg = Convert.ToInt32(Console.ReadLine());
            } while (!(carpckg > 0 && carpckg < 10));
            newCar.EngineId = carpckg;
            #endregion
            #region TrimPackageId
            int pckg = 0;
            do
            {
                Console.WriteLine("Please give an equipment ID 1 and 14 (int):");
                pckg = Convert.ToInt32(Console.ReadLine());
            } while (!(pckg > 0 && pckg < 15));
            newCar.TrimPackageId = pckg;
            #endregion
            #region Type
            Console.WriteLine("Please type in the cars type (string):");
            newCar.Type = Console.ReadLine();
            #endregion
            #region Mileage
            Console.WriteLine("Please give in the cars mileage (int):");
            newCar.Mileage = Convert.ToInt32(Console.ReadLine());
            #endregion
            #region Condition
            Console.WriteLine("Press 1 for Condition.New, press 2 for Condition.Old (boolean):");
            int state = Convert.ToInt32(Console.ReadLine());
            if (state == 1)
            {
                newCar.Condition = true;
            }
            if (state == 2)
            {
                newCar.Condition = false;
            }
            #endregion
            #region Price
            int prc = 0;
            do
            {
                Console.WriteLine("Please give a price for the car (int):");
                prc = Convert.ToInt32(Console.ReadLine());
            } while (!(pckg > int.MinValue && prc < int.MaxValue));
            newCar.TrimPackageId = prc;
            #endregion
            #region Color
            Console.WriteLine("Press 1 for Black, press 2 for White (if case, then color)");
            int selector = Convert.ToInt32(Console.ReadLine());
            Color color;
            if (selector == 1)
            {
                color = Color.GlossBlack;
            }
            else if (selector == 2)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Red;
            }
            newCar.ChasisColor = color;
            #endregion
            #region MfDate
            Console.WriteLine("Please give in the cars manuf year (int):");
            int mfDate = Convert.ToInt32(Console.ReadLine());
            newCar.ManufDate = mfDate;
            #endregion
            restServices.Post(newCar, "car");
        }
        protected static void CarRead(RestService restServices)
        {
            Console.WriteLine("Please give in the searched cars ID number (int):");
            int carid = Convert.ToInt32(Console.ReadLine());
            Car searchedCar = restServices.Get<Car>(carid, "car");
            Console.WriteLine($"Searched cars ID: {searchedCar.CarId}, Type: {searchedCar.Type}");
            Console.ReadKey();
        }
        protected static void CarUpdate(RestService restServices)
        {
            Console.WriteLine("Which car would you like to  Update?(Type in a valid ID number!)(int):");
            int updatedCarID = Convert.ToInt32(Console.ReadLine());
            Car newCar = new Car();
            #region Type
            Console.WriteLine("Please type in the cars type (string):");
            newCar.Type = Console.ReadLine();
            #endregion
            #region Mileage
            Console.WriteLine("Please give in the cars mileage (int):");
            newCar.Mileage = Convert.ToInt32(Console.ReadLine());
            #endregion
            #region Condition
            Console.WriteLine("Press 1 for Condition.New, press 2 for Condition.Old (boolean):");
            int state = Convert.ToInt32(Console.ReadLine());
            if (state == 1)
            {
                newCar.Condition = true;
            }
            if (state == 2)
            {
                newCar.Condition = false;
            }
            #endregion
            #region Price
            int prc = 0;
            do
            {
                Console.WriteLine("Please give a price for the car (int):");
                prc = Convert.ToInt32(Console.ReadLine());
            } while (!(prc > int.MinValue && prc < int.MaxValue));
            newCar.TrimPackageId = prc;
            #endregion
            #region Color
            Console.WriteLine("Press 1 for Black, press 2 for White (if case, then color)");
            int selector = Convert.ToInt32(Console.ReadLine());
            Color color;
            if (selector == 1)
            {
                color = Color.GlossBlack;
            }
            else if (selector == 2)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Red;
            }
            newCar.ChasisColor = color;
            #endregion
            #region MfDate
            Console.WriteLine("Please give in the cars manuf year (int):");
            int mfDate = Convert.ToInt32(Console.ReadLine());
            newCar.ManufDate = mfDate;
            #endregion
            restServices.Put(newCar, $"car/{updatedCarID}");
            Console.WriteLine("Update was sucessfull, press any key to continue.");
            Console.ReadKey();
        }
        protected static void CarDelete(RestService restServices)
        {
            Console.WriteLine("Please type in the cars ID that you wish to delete (int):");
            int carid = Convert.ToInt32(Console.ReadLine());
            restServices.Delete(carid, "car");
            Console.WriteLine("Delete method was sucessfull.");
        }
        #endregion

        #region EngineCrudMethods
        protected static void EngineCreate(RestService restServices)
        {
            Engine newEngine = new Engine();
            #region Enginename
            Console.WriteLine("Please give a proper engine name (string):");
            newEngine.Enginename = Console.ReadLine();
            #endregion
            #region EngineType
            Console.WriteLine("Please give a proper engine type (string):");
            newEngine.EngineType = Console.ReadLine();
            #endregion
            #region Fuelage
            Console.WriteLine("Press the number of the selected engine type: 1 - Petrol, 2 - Gasoline, 3 - LPG, 4- Electric (int):");
            int fuelage = Convert.ToInt32(Console.ReadLine());
            switch (fuelage)
            {
                case 1:
                    newEngine.Fuelage = FuelType.Petrol;
                    break;
                case 2:
                    newEngine.Fuelage = FuelType.Gasoline;
                    break;
                case 3:
                    newEngine.Fuelage = FuelType.LPG;
                    break;
                case 4:
                    newEngine.Fuelage = FuelType.Electric;
                    break;
            }
            #endregion
            #region EruroRating
            Console.WriteLine("Press the number of the selected EuroRating: 0 - N0ne, 1 - E1, 2 - E2, 3 - E3, 4 - E4, 5 - E5 (int):");
            int eurorating = Convert.ToInt32(Console.ReadLine());
            switch (eurorating)
            {
                case 0:
                    newEngine.EruroRating = EmissionRate.N0ne;
                    break;
                case 1:
                    newEngine.EruroRating = EmissionRate.E1;
                    break;
                case 2:
                    newEngine.EruroRating = EmissionRate.E2;
                    break;
                case 3:
                    newEngine.EruroRating = EmissionRate.E3;
                    break;
                case 4:
                    newEngine.EruroRating = EmissionRate.E4;
                    break;
                case 5:
                    newEngine.EruroRating = EmissionRate.E5;
                    break;
            }
            #endregion
            #region Displacement
            Console.WriteLine("Please give the proper displacement of the new engine (int):");
            newEngine.Displacement = Convert.ToDouble(Console.ReadLine());
            #endregion
            #region Torque
            Console.WriteLine("Please give the proper torque of the new engine (int):");
            newEngine.Torque = Convert.ToDouble(Console.ReadLine());
            #endregion
            #region PowerOutput
            Console.WriteLine("Please give the proper poweroutput of the new engine (int):");
            newEngine.PowerOutput = Convert.ToInt32(Console.ReadLine());
            #endregion
            restServices.Post(newEngine, "engine");
        }
        protected static void EngineRead(RestService restServices)
        {
            Console.WriteLine("Please give in the searched engines ID number (int):");
            int engineid = Convert.ToInt32(Console.ReadLine());
            Engine searchedEngine = restServices.Get<Engine>(engineid, "engine");
            Console.WriteLine($"Searched engines ID: {searchedEngine.EngineId}, Type: {searchedEngine.EngineType}");
            Console.ReadKey();
        }
        protected static void EngineUpdate(RestService restServices)
        {
            Console.WriteLine("Which Engine would you like to  Update?(Type in a valid ID number!)(int):");
            int updatedEngineID = Convert.ToInt32(Console.ReadLine());
            TrimLevel newTrimLevel = new TrimLevel();
            Engine newEngine = new Engine();
            #region Enginename
            Console.WriteLine("Please give a proper new engine name(string):");
            newEngine.Enginename = Console.ReadLine();
            #endregion
            #region EngineType
            Console.WriteLine("Please give a proper new engine type (string):");
            newEngine.EngineType = Console.ReadLine();
            #endregion
            #region Fuelage
            Console.WriteLine("Press the number of the selected new engine type: 1 - Petrol, 2 - Gasoline, 3 - LPG, 4- Electric (int):");
            int fuelage = Convert.ToInt32(Console.ReadLine());
            switch (fuelage)
            {
                case 1:
                    newEngine.Fuelage = FuelType.Petrol;
                    break;
                case 2:
                    newEngine.Fuelage = FuelType.Gasoline;
                    break;
                case 3:
                    newEngine.Fuelage = FuelType.LPG;
                    break;
                case 4:
                    newEngine.Fuelage = FuelType.Electric;
                    break;
            }
            #endregion
            #region EruroRating
            Console.WriteLine("Press the number of the selected new EuroRating: 0 - N0ne, 1 - E1, 2 - E2, 3 - E3, 4 - E4, 5 - E5 (int):");
            int eurorating = Convert.ToInt32(Console.ReadLine());
            switch (eurorating)
            {
                case 0:
                    newEngine.EruroRating = EmissionRate.N0ne;
                    break;
                case 1:
                    newEngine.EruroRating = EmissionRate.E1;
                    break;
                case 2:
                    newEngine.EruroRating = EmissionRate.E2;
                    break;
                case 3:
                    newEngine.EruroRating = EmissionRate.E3;
                    break;
                case 4:
                    newEngine.EruroRating = EmissionRate.E4;
                    break;
                case 5:
                    newEngine.EruroRating = EmissionRate.E5;
                    break;
            }
            #endregion
            #region Displacement
            Console.WriteLine("Please give the proper new displacement of the engine (int):");
            newEngine.Displacement = Convert.ToDouble(Console.ReadLine());
            #endregion
            #region Torque
            Console.WriteLine("Please give the proper new torque of the engine (int):");
            newEngine.Torque = Convert.ToDouble(Console.ReadLine());
            #endregion
            #region PowerOutput
            Console.WriteLine("Please give the proper new poweroutput of the engine (int):");
            newEngine.PowerOutput = Convert.ToInt32(Console.ReadLine());
            #endregion
            restServices.Put(newEngine, $"engine/{updatedEngineID}");
            Console.WriteLine("Update was sucessfull, press any key to continue.");
            Console.ReadKey();
        }
        protected static void EngineDelete(RestService restServices)
        {
            Console.WriteLine("Please type in the engines ID that you wish to delete:");
            int engineid = Convert.ToInt32(Console.ReadLine());
            restServices.Delete(engineid, "engine");
            Console.WriteLine("Delete method was sucessfull.");
        }
        #endregion

        #region TrimlevelCrudMethods
        protected static void TrimlevelCreate(RestService restServices)
        {
            TrimLevel newTrimLevel = new TrimLevel();
            //#region TrimPackageId
            //Console.WriteLine("Please type in a TrimPackageId (int):");
            //newTrimLevel.TrimPackageId = Convert.ToInt32(Console.ReadLine());
            //#endregion
            #region TrimPackageName
            Console.WriteLine("Please type in a TrimPackage name (string):");
            newTrimLevel.TrimPackageName = Console.ReadLine();
            #endregion
            #region AC
            Console.WriteLine("Press 1 for AC installed, press 2 for none AC (boolean):");
            int AC = Convert.ToInt32(Console.ReadLine());
            switch (AC)
            {
                case 1:
                    newTrimLevel.AC = true;
                    break;
                case 2:
                    newTrimLevel.AC = false;
                    break;
            }
            #endregion
            #region TwozoneAutomaticAC
            Console.WriteLine("Press 1 for TwozoneAutomaticAC installed, press 2 for none TwozoneAutomaticAC (boolean):");
            int TwozoneAutomaticAC = Convert.ToInt32(Console.ReadLine());
            switch (TwozoneAutomaticAC)
            {
                case 1:
                    newTrimLevel.TwozoneAutomaticAC = true;
                    break;
                case 2:
                    newTrimLevel.TwozoneAutomaticAC = false;
                    break;
            }
            #endregion
            #region AlloWheels
            Console.WriteLine("Press 1 for AlloWheels installed, press 2 for none AlloyWheels (boolean):");
            int AlloWheels = Convert.ToInt32(Console.ReadLine());
            switch (AlloWheels)
            {
                case 1:
                    newTrimLevel.AlloWheels = true;
                    break;
                case 2:
                    newTrimLevel.AlloWheels = false;
                    break;
            }
            #endregion
            #region AlcantaraInterrior
            Console.WriteLine("Press 1 for AlcantaraInterrior installed, press 2 for none AlcantaraInterrior (boolean):");
            int AlcantaraInterrior = Convert.ToInt32(Console.ReadLine());
            switch (AlcantaraInterrior)
            {
                case 1:
                    newTrimLevel.AlcantaraInterrior = true;
                    break;
                case 2:
                    newTrimLevel.AlcantaraInterrior = false;
                    break;
            }
            #endregion
            #region RoofRack
            Console.WriteLine("Press 1 for RoofRack installed, press 2 for none RoofRack (boolean):");
            int RoofRack = Convert.ToInt32(Console.ReadLine());
            switch (RoofRack)
            {
                case 1:
                    newTrimLevel.RoofRack = true;
                    break;
                case 2:
                    newTrimLevel.RoofRack = false;
                    break;
            }
            #endregion
            #region WeightHook
            Console.WriteLine("Press 1 for WeightHook installed, press 2 for none WeightHook (boolean):");
            int WeightHook = Convert.ToInt32(Console.ReadLine());
            switch (WeightHook)
            {
                case 1:
                    newTrimLevel.WeightHook = true;
                    break;
                case 2:
                    newTrimLevel.WeightHook = false;
                    break;
            }
            #endregion
            #region Chasis
            Console.WriteLine("Press the number of the selected chasis type (int): 1 - Coupe, 2 - Sedan, 3 - Hatchback, 4 - Wagon, 5 - SUV, 6 - Crossover");
            int Chasis = Convert.ToInt32(Console.ReadLine());
            switch (Chasis)
            {
                case 1:
                    newTrimLevel.Chasis = ChasisType.Coupe;
                    break;
                case 2:
                    newTrimLevel.Chasis = ChasisType.Sedan;
                    break;
                case 3:
                    newTrimLevel.Chasis = ChasisType.Hatchback;
                    break;
                case 4:
                    newTrimLevel.Chasis = ChasisType.Wagon;
                    break;
                case 5:
                    newTrimLevel.Chasis = ChasisType.SUV;
                    break;
                case 6:
                    newTrimLevel.Chasis = ChasisType.Crossover;
                    break;
            }
            #endregion
            #region NumberofDoors
            Console.WriteLine("Press the number of the selected doorset: 1 - Three, 2 - Five, 3 - Slide");
            int NumberofDoors = Convert.ToInt32(Console.ReadLine());
            switch (NumberofDoors)
            {
                case 1:
                    newTrimLevel.NumberofDoors = ChasisSize.Three;
                    break;
                case 2:
                    newTrimLevel.NumberofDoors = ChasisSize.Five;
                    break;
                case 3:
                    newTrimLevel.NumberofDoors = ChasisSize.Slide;
                    break;
            }
            #endregion
            restServices.Post(newTrimLevel, "trimlevel");
        }
        protected static void TrimlevelRead(RestService restServices)
        {
            Console.WriteLine("Please give in the searched TrimLevel package ID number:");
            int trimlevelid = Convert.ToInt32(Console.ReadLine());
            TrimLevel searchedTrimLevel = restServices.Get<TrimLevel>(trimlevelid, "trimlevel");
            Console.WriteLine($"Searched TrimLevel package ID: {searchedTrimLevel.TrimPackageId}, package name: {searchedTrimLevel.TrimPackageName}");
            Console.ReadKey();
        }
        protected static void TrimlevelUpdate(RestService restServices)
        {
            Console.WriteLine("Which TrimLevel would you like to  Update?(Type in a valid ID number!)(int):");
            TrimLevel newTrimLevel = new TrimLevel();
            int updatedTrimLevelID = Convert.ToInt32(Console.ReadLine());
            #region TrimPackageName
            Console.WriteLine("Please type in a new TrimPackage name (string):");
            newTrimLevel.TrimPackageName = Console.ReadLine();
            #endregion
            #region AC
            Console.WriteLine("Press 1 for AC installed, press 2 for none AC (boolean):");
            int AC = Convert.ToInt32(Console.ReadLine());
            switch (AC)
            {
                case 1:
                    newTrimLevel.AC = true;
                    break;
                case 2:
                    newTrimLevel.AC = false;
                    break;
            }
            #endregion
            #region TwozoneAutomaticAC
            Console.WriteLine("Press 1 for TwozoneAutomaticAC installed, press 2 for none TwozoneAutomaticAC (boolean):");
            int TwozoneAutomaticAC = Convert.ToInt32(Console.ReadLine());
            switch (TwozoneAutomaticAC)
            {
                case 1:
                    newTrimLevel.TwozoneAutomaticAC = true;
                    break;
                case 2:
                    newTrimLevel.TwozoneAutomaticAC = false;
                    break;
            }
            #endregion
            #region AlloWheels
            Console.WriteLine("Press 1 for AlloWheels installed, press 2 for none AlloyWheels (boolean):");
            int AlloWheels = Convert.ToInt32(Console.ReadLine());
            switch (AlloWheels)
            {
                case 1:
                    newTrimLevel.AlloWheels = true;
                    break;
                case 2:
                    newTrimLevel.AlloWheels = false;
                    break;
            }
            #endregion
            #region AlcantaraInterrior
            Console.WriteLine("Press 1 for AlcantaraInterrior installed, press 2 for none AlcantaraInterrior (boolean):");
            int AlcantaraInterrior = Convert.ToInt32(Console.ReadLine());
            switch (AlcantaraInterrior)
            {
                case 1:
                    newTrimLevel.AlcantaraInterrior = true;
                    break;
                case 2:
                    newTrimLevel.AlcantaraInterrior = false;
                    break;
            }
            #endregion
            #region RoofRack
            Console.WriteLine("Press 1 for RoofRack installed, press 2 for none RoofRack (boolean):");
            int RoofRack = Convert.ToInt32(Console.ReadLine());
            switch (RoofRack)
            {
                case 1:
                    newTrimLevel.RoofRack = true;
                    break;
                case 2:
                    newTrimLevel.RoofRack = false;
                    break;
            }
            #endregion
            #region WeightHook
            Console.WriteLine("Press 1 for WeightHook installed, press 2 for none WeightHook (boolean):");
            int WeightHook = Convert.ToInt32(Console.ReadLine());
            switch (WeightHook)
            {
                case 1:
                    newTrimLevel.WeightHook = true;
                    break;
                case 2:
                    newTrimLevel.WeightHook = false;
                    break;
            }
            #endregion
            #region Chasis
            Console.WriteLine("Press the number of the selected new chasis type (int): 1 - Coupe, 2 - Sedan, 3 - Hatchback, 4 - Wagon, 5 - SUV, 6 - Crossover");
            int Chasis = Convert.ToInt32(Console.ReadLine());
            switch (Chasis)
            {
                case 1:
                    newTrimLevel.Chasis = ChasisType.Coupe;
                    break;
                case 2:
                    newTrimLevel.Chasis = ChasisType.Sedan;
                    break;
                case 3:
                    newTrimLevel.Chasis = ChasisType.Hatchback;
                    break;
                case 4:
                    newTrimLevel.Chasis = ChasisType.Wagon;
                    break;
                case 5:
                    newTrimLevel.Chasis = ChasisType.SUV;
                    break;
                case 6:
                    newTrimLevel.Chasis = ChasisType.Crossover;
                    break;
            }
            #endregion
            #region NumberofDoors
            Console.WriteLine("Press the number of the selected new doorset: 1 - Three, 2 - Five, 3 - Slide");
            int NumberofDoors = Convert.ToInt32(Console.ReadLine());
            switch (NumberofDoors)
            {
                case 1:
                    newTrimLevel.NumberofDoors = ChasisSize.Three;
                    break;
                case 2:
                    newTrimLevel.NumberofDoors = ChasisSize.Five;
                    break;
                case 3:
                    newTrimLevel.NumberofDoors = ChasisSize.Slide;
                    break;
            }
            #endregion
            restServices.Put(newTrimLevel, $"trimlevel/{updatedTrimLevelID}");
            Console.WriteLine("Update was sucessfull, press any key to continue.");
            Console.ReadKey();
        }
        protected static void TrimlevelDelete(RestService restServices)
        {
            Console.WriteLine("Please type in the TrimLevel package ID that you wish to delete:");
            int trimlevelid = Convert.ToInt32(Console.ReadLine());
            restServices.Delete(trimlevelid, "trimlevel");
            Console.WriteLine("Delete method was sucessfull.");
        }
        #endregion

        #region NoneCruds
        protected static void GetAvgOdometerStateByEngineType(RestService restServices)
        {
            List< OdometerByEngineType> list = restServices.Get<OdometerByEngineType>("stat/GetAvgOdometerStateByEngineType");
            foreach (var item in list)
            {
                Console.WriteLine("Engine Type"+ item.engineType + " AVG Odometer state: " + item.avgOdometerState);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        protected static void GetAvgPriceByCarChasisType(RestService restServices)
        {
            List<ChassisTypeAVGPrice> list = restServices.Get<ChassisTypeAVGPrice>("stat/GetAvgPriceByCarChasisType");
            foreach (var item in list)
            {
                Console.WriteLine("Chasis type: " + item.chasisType + " AVG Price: " + item.avgPrice);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        protected static void GetAverageMileageByFuelType(RestService restServices)
        {
            List<AverageMileageByFuelType> list = restServices.Get<AverageMileageByFuelType>("stat/GetAverageMileageByFuelType");
            foreach (var item in list)
            {
                Console.WriteLine("Fuel type: " + item.fuelType + " AVG mileage: " + item.avgMileage);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        protected static void SoldCarsByFuelType(RestService restServices)
        {
            List<SoldCarsbyFuelType> list = restServices.Get<SoldCarsbyFuelType>("stat/SoldCarsByFuelType");
            foreach (var item in list)
            {
                Console.WriteLine("FuelType: " + item.fuelType + " number of sold cars: " + item.numberofSoldCars);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        protected static void GetAVGManufDateByFuelType(RestService restServices)
        {
            List<AVGManufDateByFuelType> list = restServices.Get<AVGManufDateByFuelType>("stat/GetAVGManufDateByFuelType");
            foreach (var item in list)
            {
                Console.WriteLine("Fueltype: " + item.fuelType + " AVG manufacture date: " + item.avgManufDate);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        #endregion
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(3000);
            RestService restServices = new RestService("http://localhost:24817");   
            var noneCruds = new ConsoleMenu()
                .Add("GetAvgOdometerStateByEngineType", () => GetAvgOdometerStateByEngineType(restServices))
                .Add("GetAvgPriceByCarChasisType", () => GetAvgPriceByCarChasisType(restServices))
                .Add("GetAverageMileageByFuelType", () => GetAverageMileageByFuelType(restServices))
                .Add("SoldCarsByFuelType", () => SoldCarsByFuelType(restServices))
                .Add("GetAVGManufDateByFuelType", () => GetAVGManufDateByFuelType(restServices))
                .Add("Back to previous menu list!", ConsoleMenu.Close);
            var carCrud = new ConsoleMenu()
                .Add("Create car!", () => CarCreate(restServices))
                .Add("Read car!", () => CarRead(restServices))
                .Add("Update car!", () => CarUpdate(restServices))
                .Add("Delete car!", () => CarDelete(restServices))
                .Add("Back to previous menu list!", ConsoleMenu.Close);
            var engineCrud = new ConsoleMenu()
               .Add("Create engine!", () => EngineCreate(restServices))
               .Add("Read car!", () => EngineRead(restServices))
               .Add("Update engine!", () => EngineUpdate(restServices))
               .Add("Delete engine!", () => EngineDelete(restServices))
               .Add("Back to previous menu list!", ConsoleMenu.Close);
            var trimlevelCrud = new ConsoleMenu()
               .Add("Create trimlevel!", () => TrimlevelCreate(restServices))
               .Add("Read trimlevel!", () => TrimlevelRead(restServices))
               .Add("Update trimlevel!", () => TrimlevelUpdate(restServices))
               .Add("Delete trimlevel!", () => TrimlevelDelete(restServices))
               .Add("Back to previous menu list!", ConsoleMenu.Close);
            var crudMenu = new ConsoleMenu()
                .Add("Car CRUD!", () => carCrud.Show())
                .Add("Engine CRUD!", () => engineCrud.Show())
                .Add("TrimLevel CRUD!", () => trimlevelCrud.Show())
                .Add("Back to previous menu list", ConsoleMenu.Close);
            var mainMenu = new ConsoleMenu()
                .Add("List every car!", () => ListAllCar(restServices))
                .Add("List every engine.", () => ListAllEngine(restServices))
                .Add("List every trimlevel", () => ListAllTrimLevel(restServices))
                .Add("List everything.", () =>
                {
                    ListAllCar(restServices);
                    ListAllEngine(restServices);
                    ListAllTrimLevel(restServices);
                })
                .Add("Crud menus!", () => crudMenu.Show())
                .Add("None crud menus!", () => noneCruds.Show())
                .Add("Back", ConsoleMenu.Close);
            mainMenu.Show();
        }
    }
}
