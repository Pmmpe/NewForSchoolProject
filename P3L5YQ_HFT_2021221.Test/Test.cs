namespace P3L5YQ_HFT_2021221.Test
{
    using NUnit.Framework;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using P3L5YQ_HFT_2021221.Logic;
    using P3L5YQ_HFT_2021221.Repository;
    using P3L5YQ_HFT_2021221.Models;
    using P3L5YQ_HFT_2021221.Models.HelperClasses;

    [TestFixture]
    public class Test
    {
        CarLogic carLogic;
        EngineLogic engineLogic;
        TrimLevelLogic trimLevelLogic;
        [SetUp]
        public void Init()
        {

            var mockEngineRepository = new Mock<IEngineRepository>();
            #region Engines
            Engine ST170 = new Engine() { EngineId = 1, Enginename = "ST1701", EngineType = "ST170", Fuelage = FuelType.Petrol, EruroRating = EmissionRate.E3, Displacement = 2000, Torque = 144.4, PowerOutput = 170 };
            Engine RS170 = new Engine() { EngineId = 2, Enginename = "RS1701", EngineType = "RS170", Fuelage = FuelType.Petrol, EruroRating = EmissionRate.E3, Displacement = 2000, Torque = 179.8, PowerOutput = 215 };
            Engine Zetec1_4 = new Engine() { EngineId = 3, Enginename = "ZT1401", EngineType = "Ztec 1.4", Fuelage = FuelType.Petrol, EruroRating = EmissionRate.E3, Displacement = 1399, Torque = 101.2, PowerOutput = 75 };
            Engine Zetec1_6 = new Engine() { EngineId = 4, Enginename = "ZT1601", EngineType = "ZTec 1.6", Fuelage = FuelType.Petrol, EruroRating = EmissionRate.E3, Displacement = 1598, Torque = 123.7, PowerOutput = 101 };
            Engine Duratec1_4 = new Engine() { EngineId = 5, Enginename = "DT1401", EngineType = "Duratec 1.4", Fuelage = FuelType.Petrol, EruroRating = EmissionRate.E4, Displacement = 1398, Torque = 110.6, PowerOutput = 95 };
            Engine Duratec1_6 = new Engine() { EngineId = 6, Enginename = "DT1601", EngineType = "Duratec 1.6", Fuelage = FuelType.Petrol, EruroRating = EmissionRate.E4, Displacement = 1598, Torque = 129.1, PowerOutput = 110 };
            Engine DTCI1_4 = new Engine() { EngineId = 7, Enginename = "DTC1401", EngineType = "DTCi 1.4", Fuelage = FuelType.Gasoline, EruroRating = EmissionRate.E4, Displacement = 1510, Torque = 159.1, PowerOutput = 110 };
            Engine DTCI1_8 = new Engine() { EngineId = 8, Enginename = "DTC1801", EngineType = "TDCi 1.8", Fuelage = FuelType.Gasoline, EruroRating = EmissionRate.E4, Displacement = 1591, Torque = 179.1, PowerOutput = 136 };
            Engine DTCI2_0 = new Engine() { EngineId = 9, Enginename = "DT2001", EngineType = "TDCi 2.0", Fuelage = FuelType.Gasoline, EruroRating = EmissionRate.E4, Displacement = 1996, Torque = 199.1, PowerOutput = 176 };
            List<Engine> engines = new List<Engine>{ ST170,RS170, Zetec1_4, Zetec1_6, Duratec1_4, Duratec1_6,
                                                     DTCI1_4,DTCI1_8,DTCI2_0};
            #endregion
            mockEngineRepository.Setup(mockEngines => mockEngines.GetAll())
                .Returns(engines.AsQueryable());


            var mockTrimLevelRepository = new Mock<ITrimLevelRepository>(MockBehavior.Loose);
            #region TrimLevels
            TrimLevel GhiaFiveWagon = new TrimLevel() { TrimPackageId = 1, TrimPackageName = "GH5W", AC = true, TwozoneAutomaticAC = true, AlloWheels = false, AlcantaraInterrior = true, RoofRack = true, WeightHook = true, Chasis = ChasisType.Wagon, NumberofDoors = ChasisSize.Five };
            TrimLevel GhiaFiveSedan = new TrimLevel() { TrimPackageId = 2, TrimPackageName = "GH5S", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = true, RoofRack = false, WeightHook = true, Chasis = ChasisType.Sedan, NumberofDoors = ChasisSize.Five };
            TrimLevel GhiaThreeHatch = new TrimLevel() { TrimPackageId = 3, TrimPackageName = "GH3H", AC = true, TwozoneAutomaticAC = true, AlloWheels = true, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            TrimLevel GhiaFiveHatch = new TrimLevel() { TrimPackageId = 4, TrimPackageName = "GH5H", AC = true, TwozoneAutomaticAC = true, AlloWheels = false, AlcantaraInterrior = true, RoofRack = false, WeightHook = true, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Five };
            TrimLevel AmbienceThreeHatch = new TrimLevel() { TrimPackageId = 5, TrimPackageName = "AM3H", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = true, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            TrimLevel AmbienceFiveWagon = new TrimLevel() { TrimPackageId = 6, TrimPackageName = "AM5W", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = true, WeightHook = true, Chasis = ChasisType.Wagon, NumberofDoors = ChasisSize.Five };
            TrimLevel AmbienceFiveHatch = new TrimLevel() { TrimPackageId = 7, TrimPackageName = "AM5H", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Five };
            TrimLevel AmbienceFiveSedan = new TrimLevel() { TrimPackageId = 8, TrimPackageName = "AM5S", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = true, Chasis = ChasisType.Sedan, NumberofDoors = ChasisSize.Five };
            TrimLevel LariettFiveWagon = new TrimLevel() { TrimPackageId = 9, TrimPackageName = "LR5W", AC = true, TwozoneAutomaticAC = true, AlloWheels = true, AlcantaraInterrior = true, RoofRack = false, WeightHook = true, Chasis = ChasisType.Wagon, NumberofDoors = ChasisSize.Five };
            TrimLevel LariettThreeSedan = new TrimLevel() { TrimPackageId = 10, TrimPackageName = "LR3S", AC = false, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Sedan, NumberofDoors = ChasisSize.Three };
            TrimLevel LariettFiveSedan = new TrimLevel() { TrimPackageId = 11, TrimPackageName = "LR5S", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Sedan, NumberofDoors = ChasisSize.Five };
            TrimLevel LariettTreeHatch = new TrimLevel() { TrimPackageId = 12, TrimPackageName = "LR3H", AC = false, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            TrimLevel ST1701 = new TrimLevel() { TrimPackageId = 13, TrimPackageName = "ST1701", AC = true, TwozoneAutomaticAC = true, AlloWheels = true, AlcantaraInterrior = true, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            TrimLevel RS1701 = new TrimLevel() { TrimPackageId = 14, TrimPackageName = "RS1701", AC = true, TwozoneAutomaticAC = true, AlloWheels = true, AlcantaraInterrior = true, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            List<TrimLevel> trimLevels = new List<TrimLevel>() { GhiaFiveWagon,GhiaFiveSedan, GhiaThreeHatch, GhiaFiveHatch,
                                                                AmbienceThreeHatch,AmbienceFiveWagon,AmbienceFiveHatch,AmbienceFiveSedan,
                                                                LariettFiveWagon,LariettThreeSedan,LariettFiveSedan,LariettTreeHatch,
                                                                ST1701,RS1701};
            #endregion
            mockTrimLevelRepository.Setup(mockTrims => mockTrims.GetAll())
                .Returns(trimLevels.AsQueryable());

            var mockCarRepository = new Mock<ICarRepository>();
            #region Cars
            Car FocusST170 = new Car() { CarId = 1, EngineId = ST170.EngineId, Engine = ST170, TrimPackageId = ST1701.TrimPackageId, Type = "Focus ST170", Mileage = 61300, Condition = true, Price = 750000, ChasisColor = Color.Blue, ManufDate = 2001, Equipment = ST1701 };
            Car FocusRS170 = new Car() { CarId = 2, EngineId = RS170.EngineId, Engine = RS170, TrimPackageId = RS1701.TrimPackageId, Type = "Focus RS170", Mileage = 47890, Condition = true, Price = 2200000, ChasisColor = Color.Orange, ManufDate = 2002, Equipment = RS1701 };
            Car Ztec1_4h = new Car() { CarId = 3, EngineId = Zetec1_4.EngineId, Engine = Zetec1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia 1.4", Mileage = 7650, Condition = true, Price = 387000, ChasisColor = Color.DeepRed, ManufDate = 2003, Equipment = GhiaFiveHatch };
            Car Ztec1_4w = new Car() { CarId = 4, EngineId = Zetec1_4.EngineId, Engine = Zetec1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia 1.4", Mileage = 456123, Condition = true, Price = 490000, ChasisColor = Color.GlossBlack, ManufDate = 2004, Equipment = GhiaFiveHatch };
            Car Ztec1_4s = new Car() { CarId = 5, EngineId = Zetec1_4.EngineId, Engine = Zetec1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience 1.4", Mileage = 198432, Condition = true, Price = 510000, ChasisColor = Color.Green, ManufDate = 2001, Equipment = GhiaFiveHatch };
            Car ZTec1_6h = new Car() { CarId = 6, EngineId = Zetec1_4.EngineId, Engine = Zetec1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia 1.6", Mileage = 75132, Condition = true, Price = 750000, ChasisColor = Color.PearlWhite, ManufDate = 2000, Equipment = GhiaFiveHatch };
            Car ZTec1_6w = new Car() { CarId = 7, EngineId = Zetec1_6.EngineId, Engine = Zetec1_6, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia 1.6", Mileage = 54232, Condition = true, Price = 895000, ChasisColor = Color.GlossBlack, ManufDate = 2001, Equipment = GhiaFiveHatch };
            Car ZTec1_6s = new Car() { CarId = 8, EngineId = Zetec1_6.EngineId, Engine = Zetec1_6, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia 1.6", Mileage = 0, Condition = false, Price = 3600000, ChasisColor = Color.PearlWhite, ManufDate = 2005, Equipment = GhiaFiveHatch };
            Car DT1_4h = new Car() { CarId = 9, EngineId = Zetec1_6.EngineId, Engine = Zetec1_6, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia Dtec 1.4", Mileage = 32123, Condition = true, Price = 192000, ChasisColor = Color.PearlWhite, ManufDate = 2005, Equipment = GhiaFiveHatch };
            Car DT1_4w = new Car() { CarId = 10, EngineId = Zetec1_6.EngineId, Engine = Zetec1_6, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Lariett Dtec 1.4", Mileage = 431234, Condition = true, Price = 319000, ChasisColor = Color.Red, ManufDate = 2002, Equipment = GhiaFiveHatch };
            Car DT1_4s = new Car() { CarId = 11, EngineId = Zetec1_4.EngineId, Engine = Zetec1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience Dtec 1.4", Mileage = 232341, Condition = true, Price = 825000, ChasisColor = Color.Red, ManufDate = 2009, Equipment = GhiaFiveHatch };
            Car DT1_6h = new Car() { CarId = 12, EngineId = Zetec1_4.EngineId, Engine = Zetec1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience Dtec 1.6", Mileage = 123413, Condition = true, Price = 578000, ChasisColor = Color.Shempgane, ManufDate = 2010, Equipment = GhiaFiveHatch };
            Car DT1_6w = new Car() { CarId = 13, EngineId = Zetec1_4.EngineId, Engine = Zetec1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience Dtec 1,6", Mileage = 0, Condition = false, Price = 2990000, ChasisColor = Color.Yellow, ManufDate = 2001, Equipment = GhiaFiveHatch };
            Car DT1_6s = new Car() { CarId = 14, EngineId = Zetec1_4.EngineId, Engine = Zetec1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia Dteec 1.6", Mileage = 31678, Condition = true, Price = 510000, ChasisColor = Color.Yellow, ManufDate = 1999, Equipment = GhiaFiveHatch };
            Car DTC1_4h = new Car() { CarId = 15, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Lariett TDCi 1.4", Mileage = 0, Condition = false, Price = 3290000, ChasisColor = Color.Shempgane, ManufDate = 1999, Equipment = GhiaFiveHatch };
            Car DTC1_4w = new Car() { CarId = 16, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience TDCi 1.4", Mileage = 123542, Condition = true, Price = 600000, ChasisColor = Color.White, ManufDate = 1998, Equipment = GhiaFiveHatch };
            Car DTC1_4s = new Car() { CarId = 17, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Lariett TDCi 1.4", Mileage = 234254, Condition = true, Price = 575000, ChasisColor = Color.DeepRed, ManufDate = 2000, Equipment = GhiaFiveHatch };
            Car DTC1_8h = new Car() { CarId = 18, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience TDCI 1.8", Mileage = 125002, Condition = true, Price = 550000, ChasisColor = Color.Green, ManufDate = 2001, Equipment = GhiaFiveHatch };
            Car DTC1_8w = new Car() { CarId = 19, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience TDCi 1.8", Mileage = 178900, Condition = false, Price = 3690000, ChasisColor = Color.White, ManufDate = 2002, Equipment = GhiaFiveHatch };
            Car DTC1_8s = new Car() { CarId = 20, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia TDCi 1.8", Mileage = 237100, Condition = true, Price = 490000, ChasisColor = Color.PearlBlack, ManufDate = 2003, Equipment = GhiaFiveHatch };
            Car DTC2_0h = new Car() { CarId = 21, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia TDCi 2.0", Mileage = 0, Condition = false, Price = 3990000, ChasisColor = Color.GlossBlack, ManufDate = 2006, Equipment = GhiaFiveHatch };
            Car DTC2_0w = new Car() { CarId = 22, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia TDCi 2.0", Mileage = 78900, Condition = true, Price = 600000, ChasisColor = Color.Red, ManufDate = 2006, Equipment = GhiaFiveHatch };
            Car DTC2_0s = new Car() { CarId = 23, EngineId = DTCI1_4.EngineId, Engine = DTCI1_4, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience TDCi 2.0", Mileage = 0, Condition = false, Price = 4299000, ChasisColor = Color.Orange, ManufDate = 2009, Equipment = GhiaFiveHatch };
            List<Car> cars = new List<Car>{FocusRS170, FocusST170, Ztec1_4h, Ztec1_4w, Ztec1_4s, ZTec1_6h, ZTec1_6w, ZTec1_6s,
                DT1_4h, DT1_4w, DT1_4s, DT1_6h, DT1_6w, DT1_6s, DTC1_4h, DTC1_4w, DTC1_4s, DTC1_8h, DTC1_8w,
                DTC2_0h, DTC2_0w, DTC2_0s };
            #endregion
            mockCarRepository.Setup(mockCars => mockCars.GetAll())
                .Returns(cars.AsQueryable());
            mockCarRepository.Setup(mockCars => mockCars.Read(It.IsAny<int>()))
                .Returns<int>(id => cars.FirstOrDefault(c => c.CarId == id));
            mockEngineRepository.Setup(mockEngines => mockEngines.Read(It.IsAny<int>()))
                .Returns<int>(id => engines.FirstOrDefault(e => e.EngineId == id));
            mockTrimLevelRepository.Setup(mocTrimLevels => mocTrimLevels.Read(It.IsAny<int>()))
                .Returns<int>(id => trimLevels.FirstOrDefault(t => t.TrimPackageId == id));
            mockTrimLevelRepository.Setup(mocTrimLevels => mocTrimLevels.Delete(It.IsAny<int>()))
                .Callback<int>(id =>  trimLevels.RemoveAll(x => x.TrimPackageId == id));

            engineLogic = new EngineLogic(mockEngineRepository.Object);
            trimLevelLogic = new TrimLevelLogic(mockTrimLevelRepository.Object);
            carLogic = new CarLogic(mockCarRepository.Object);
        }
        
        [Test]
        public void CarCreate()
        {
            Car car = new Car();
            Assert.That(() =>
            {
                carLogic.Create(car);
            }, Throws.Exception);
        }

        [Test]
        public void EngineCreate()
        {
            Engine engine = new Engine();
            Assert.That(() =>
            {
                engineLogic.Create(engine);
            }, Throws.Exception);
        }

        [Test]
        public void TrimCreate()
        {
            TrimLevel trimLevel = new TrimLevel();
            Assert.That(() =>
            {
                trimLevelLogic.Create(trimLevel);
            }, Throws.Exception);
        }

        [Test]
        public void CarRead()
        {
            var result = carLogic.Read(1);
            Assert.That(result.Type, Is.EqualTo("Focus ST170"));
        }

        [Test]
        public void EngineRead()
        {
            var result = engineLogic.Read(1);
            Assert.That(result.Fuelage, Is.EqualTo(FuelType.Petrol));
        }

        [Test]
        public void TrimLevelRead()
        {

            var result = trimLevelLogic.Read(1);
            Console.WriteLine(result == null ? "y" : "n" );
            Assert.That(result.Chasis, Is.EqualTo(ChasisType.Wagon));
        }
        [Test]
        public void TrimLevelDelete()
        {
            #region TrimLevels
            TrimLevel GhiaFiveWagon = new TrimLevel() { TrimPackageId = 1, TrimPackageName = "GH5W", AC = true, TwozoneAutomaticAC = true, AlloWheels = false, AlcantaraInterrior = true, RoofRack = true, WeightHook = true, Chasis = ChasisType.Wagon, NumberofDoors = ChasisSize.Five };
            TrimLevel GhiaFiveSedan = new TrimLevel() { TrimPackageId = 2, TrimPackageName = "GH5S", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = true, RoofRack = false, WeightHook = true, Chasis = ChasisType.Sedan, NumberofDoors = ChasisSize.Five };
            TrimLevel GhiaThreeHatch = new TrimLevel() { TrimPackageId = 3, TrimPackageName = "GH3H", AC = true, TwozoneAutomaticAC = true, AlloWheels = true, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            TrimLevel GhiaFiveHatch = new TrimLevel() { TrimPackageId = 4, TrimPackageName = "GH5H", AC = true, TwozoneAutomaticAC = true, AlloWheels = false, AlcantaraInterrior = true, RoofRack = false, WeightHook = true, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Five };
            TrimLevel AmbienceThreeHatch = new TrimLevel() { TrimPackageId = 5, TrimPackageName = "AM3H", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = true, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            TrimLevel AmbienceFiveWagon = new TrimLevel() { TrimPackageId = 6, TrimPackageName = "AM5W", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = true, WeightHook = true, Chasis = ChasisType.Wagon, NumberofDoors = ChasisSize.Five };
            TrimLevel AmbienceFiveHatch = new TrimLevel() { TrimPackageId = 7, TrimPackageName = "AM5H", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Five };
            TrimLevel AmbienceFiveSedan = new TrimLevel() { TrimPackageId = 8, TrimPackageName = "AM5S", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = true, Chasis = ChasisType.Sedan, NumberofDoors = ChasisSize.Five };
            TrimLevel LariettFiveWagon = new TrimLevel() { TrimPackageId = 9, TrimPackageName = "LR5W", AC = true, TwozoneAutomaticAC = true, AlloWheels = true, AlcantaraInterrior = true, RoofRack = false, WeightHook = true, Chasis = ChasisType.Wagon, NumberofDoors = ChasisSize.Five };
            TrimLevel LariettThreeSedan = new TrimLevel() { TrimPackageId = 10, TrimPackageName = "LR3S", AC = false, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Sedan, NumberofDoors = ChasisSize.Three };
            TrimLevel LariettFiveSedan = new TrimLevel() { TrimPackageId = 11, TrimPackageName = "LR5S", AC = true, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Sedan, NumberofDoors = ChasisSize.Five };
            TrimLevel LariettTreeHatch = new TrimLevel() { TrimPackageId = 12, TrimPackageName = "LR3H", AC = false, TwozoneAutomaticAC = false, AlloWheels = false, AlcantaraInterrior = false, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            TrimLevel ST1701 = new TrimLevel() { TrimPackageId = 13, TrimPackageName = "ST1701", AC = true, TwozoneAutomaticAC = true, AlloWheels = true, AlcantaraInterrior = true, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            TrimLevel RS1701 = new TrimLevel() { TrimPackageId = 14, TrimPackageName = "RS1701", AC = true, TwozoneAutomaticAC = true, AlloWheels = true, AlcantaraInterrior = true, RoofRack = false, WeightHook = false, Chasis = ChasisType.Hatchback, NumberofDoors = ChasisSize.Three };
            List<TrimLevel> testtrimLevels = new List<TrimLevel>() { GhiaFiveWagon,GhiaFiveSedan, GhiaThreeHatch, GhiaFiveHatch,
                                                                AmbienceThreeHatch,AmbienceFiveWagon,AmbienceFiveHatch,AmbienceFiveSedan,
                                                                LariettFiveWagon,LariettThreeSedan,LariettFiveSedan,LariettTreeHatch,
                                                                ST1701,RS1701};
            #endregion

            List<TrimLevel> allTrim = trimLevelLogic.ReadAll().ToArray().ToList();
            trimLevelLogic.Delete(1);
            List<TrimLevel> deletedTrim = trimLevelLogic.ReadAll().ToArray().ToList();
            
            Assert.That(allTrim.Any(x => x.TrimPackageId == 1));
            Assert.That(deletedTrim.Any(x => x.TrimPackageId == 1) == false);
        }
        [Test]
        public void TestGetAvgOdometerStateByEngineType()
        {
            //Engine Type RS1701 AVG Odometer state: 47890
            //Engine Type ST1701 AVG Odometer state: 61300
            //Engine Type ZT1401 AVG Odometer state: 140596.125
            //Engine Type ZT1601 AVG Odometer state: 129397.25
            //Engine Type DTC1401 AVG Odometer state: 92574.75
            var result = carLogic.GetAvgOdometerStateByEngineType();
            List<OdometerByEngineType> expected = new List<OdometerByEngineType>();
            expected.Add(new OdometerByEngineType() { engineType = "RS1701", avgOdometerState = 47890 });
            expected.Add(new OdometerByEngineType() { engineType = "ST1701", avgOdometerState = 61300 });
            expected.Add(new OdometerByEngineType() { engineType = "ZT1401", avgOdometerState = 140596.125 });
            expected.Add(new OdometerByEngineType() { engineType = "ZT1601", avgOdometerState = 129397.25 });
            expected.Add(new OdometerByEngineType() { engineType = "DTC1401", avgOdometerState = 92574.75 });

            Assert.That(expected.Count, Is.EqualTo(result.Count));
            Assert.That(expected[0].engineType, Is.EqualTo(result[0].engineType));
            Assert.That(expected[0].avgOdometerState, Is.EqualTo(result[0].avgOdometerState));
            Assert.That(expected[1].engineType, Is.EqualTo(result[1].engineType));
            Assert.That(expected[1].avgOdometerState, Is.EqualTo(result[1].avgOdometerState));
            Assert.That(expected[2].engineType, Is.EqualTo(result[2].engineType));
            Assert.That(expected[2].avgOdometerState, Is.EqualTo(result[2].avgOdometerState));
            Assert.That(expected[3].engineType, Is.EqualTo(result[3].engineType));
            Assert.That(expected[3].avgOdometerState, Is.EqualTo(result[3].avgOdometerState));
            Assert.That(expected[4].engineType, Is.EqualTo(result[4].engineType));
            Assert.That(expected[4].avgOdometerState, Is.EqualTo(result[4].avgOdometerState));
        }
        [Test]
        public void TestGetAvgPriceByCarChasisType()
        {
            //Chasis type: Hatchback AVG Price: 1481363.6363636365

            List<ChassisTypeAVGPrice> expected = new List<ChassisTypeAVGPrice>();
            expected.Add(new ChassisTypeAVGPrice() { chasisType = ChasisType.Hatchback, avgPrice = 1481363.6363636365 });


            var result = carLogic.GetAvgPriceByCarChasisType();
            Assert.That(expected.Count, Is.EqualTo(result.Count));
            Assert.That(expected[0].chasisType, Is.EqualTo(result[0].chasisType));
            Assert.That(expected[0].avgPrice, Is.EqualTo(result[0].avgPrice));
        }
        [Test]
        public void TestGetAverageMileageByFuelType()
        {
            List<AverageMileageByFuelType> expected = new List<AverageMileageByFuelType>();
            //Fuel type: Petrol AVG mileage: 125110
            //Fuel type: Gasoline AVG mileage: 92575
            expected.Add(new AverageMileageByFuelType() { fuelType = FuelType.Petrol, avgMileage = 125111});
            expected.Add(new AverageMileageByFuelType() { fuelType = FuelType.Gasoline, avgMileage = 92575 });

            var result = carLogic.GetAverageMileageByFuelType();
            Assert.That(expected.Count, Is.EqualTo(result.Count));
            Assert.That(expected[0].fuelType, Is.EqualTo(result[0].fuelType));
            Assert.That(expected[0].avgMileage, Is.EqualTo(result[0].avgMileage));
            Assert.That(expected[1].fuelType, Is.EqualTo(result[1].fuelType));
            Assert.That(expected[1].avgMileage, Is.EqualTo(result[1].avgMileage));
        }
        [Test]
        public void TestSoldCarsByFuelType()
        {
            //FuelType: Petrol number of sold cars: 14
            //FuelType: Gasoline number of sold cars: 9
            List<SoldCarsbyFuelType> expected = new List<SoldCarsbyFuelType>();
            expected.Add(new SoldCarsbyFuelType() { fuelType = FuelType.Petrol, numberofSoldCars = 14 });
            expected.Add(new SoldCarsbyFuelType() { fuelType = FuelType.Gasoline, numberofSoldCars = 8 });

            var result = carLogic.SoldCarsByFuelType();
            Assert.That(expected.Count, Is.EqualTo(result.Count));
            Assert.That(expected[0].fuelType, Is.EqualTo(result[0].fuelType));
            Assert.That(expected[0].numberofSoldCars, Is.EqualTo(result[0].numberofSoldCars));
            Assert.That(expected[1].fuelType, Is.EqualTo(result[1].fuelType));
            Assert.That(expected[1].numberofSoldCars, Is.EqualTo(result[1].numberofSoldCars));
        }
        [Test]
        public void GetAVGManufDateByFuelType()
        {
            //Fueltype: Petrol AVG manufacture date: 2003,0714285714287
            //Fueltype: Gasoline AVG manufacture date: 2002,6666666666667
            List<AVGManufDateByFuelType> expected = new List<AVGManufDateByFuelType>();
            expected.Add(new AVGManufDateByFuelType() { fuelType = FuelType.Petrol, avgManufDate = 2003.0714285714287 });
            expected.Add(new AVGManufDateByFuelType() { fuelType = FuelType.Gasoline, avgManufDate = 2002.625 });

            var result = carLogic.GetAVGManufDateByFuelType();
            Assert.That(result.Count, Is.EqualTo(expected.Count));
            Assert.That(result[0].fuelType, Is.EqualTo(expected[0].fuelType));
            Assert.That(result[1].fuelType, Is.EqualTo(expected[1].fuelType));
            Assert.That(result[0].avgManufDate, Is.EqualTo(expected[0].avgManufDate));
            Assert.That(result[1].avgManufDate, Is.EqualTo(expected[1].avgManufDate));
        }

    }
}
