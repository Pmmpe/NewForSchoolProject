namespace P3L5YQ_HFT_2021221.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using P3L5YQ_HFT_2021221.Models;

    public class DealershipDbContext : DbContext
    {
        public DealershipDbContext()
        {
            this.Database.EnsureCreated();
        }
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Dealership.mdf;Integrated Security=True";
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }
        public virtual DbSet<TrimLevel> TrimLevel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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
            #endregion
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
            #endregion
            #region Cars
            Car FocusST170 = new Car() { CarId = 1, EngineId = ST170.EngineId, TrimPackageId = ST1701.TrimPackageId, Type = "Focus ST170", Mileage = 61300, Condition = true, Price = 750000, ChasisColor = Color.Blue, ManufDate = 2001 };
            Car FocusRS170 = new Car() { CarId = 2, EngineId = RS170.EngineId, TrimPackageId = RS1701.TrimPackageId, Type = "Focus RS170", Mileage = 47890, Condition = true, Price = 2200000, ChasisColor = Color.Orange, ManufDate = 2002 };
            Car Ztec1_4h = new Car() { CarId = 3, EngineId = Zetec1_4.EngineId, TrimPackageId = GhiaThreeHatch.TrimPackageId, Type = "Focus Ghia 1.4", Mileage = 7650, Condition = true, Price = 387000, ChasisColor = Color.DeepRed, ManufDate = 2003 };
            Car Ztec1_4w = new Car() { CarId = 4, EngineId = Zetec1_4.EngineId, TrimPackageId = GhiaFiveSedan.TrimPackageId, Type = "Focus Ghia 1.4", Mileage = 456123, Condition = true, Price = 490000, ChasisColor = Color.GlossBlack, ManufDate = 2004 };
            Car Ztec1_4s = new Car() { CarId = 5, EngineId = Zetec1_4.EngineId, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience 1.4", Mileage = 198432, Condition = true, Price = 510000, ChasisColor = Color.Green, ManufDate = 2001 };
            Car ZTec1_6h = new Car() { CarId = 6, EngineId = Zetec1_4.EngineId, TrimPackageId = AmbienceFiveSedan.TrimPackageId, Type = "Focus Ghia 1.6", Mileage = 75132, Condition = true, Price = 750000, ChasisColor = Color.PearlWhite, ManufDate = 2000 };
            Car ZTec1_6w = new Car() { CarId = 7, EngineId = Zetec1_6.EngineId, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia 1.6", Mileage = 54232, Condition = true, Price = 895000, ChasisColor = Color.GlossBlack, ManufDate = 2001 };
            Car ZTec1_6s = new Car() { CarId = 8, EngineId = Zetec1_6.EngineId, TrimPackageId = GhiaFiveSedan.TrimPackageId, Type = "Focus Ghia 1.6", Mileage = 0, Condition = false, Price = 3600000, ChasisColor = Color.PearlWhite, ManufDate = 2005 };
            Car DT1_4h = new Car() { CarId = 9, EngineId = Zetec1_6.EngineId, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia Dtec 1.4", Mileage = 32123, Condition = true, Price = 192000, ChasisColor = Color.PearlWhite, ManufDate = 2005 };
            Car DT1_4w = new Car() { CarId = 10, EngineId = Zetec1_6.EngineId, TrimPackageId = GhiaFiveWagon.TrimPackageId, Type = "Focus Lariett Dtec 1.4", Mileage = 431234, Condition = true, Price = 319000, ChasisColor = Color.Red, ManufDate = 2002 };
            Car DT1_4s = new Car() { CarId = 11, EngineId = Zetec1_4.EngineId, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience Dtec 1.4", Mileage = 232341, Condition = true, Price = 825000, ChasisColor = Color.Red, ManufDate = 2009 };
            Car DT1_6h = new Car() { CarId = 12, EngineId = Zetec1_4.EngineId, TrimPackageId = LariettThreeSedan.TrimPackageId, Type = "Focus Ambience Dtec 1.6", Mileage = 123413, Condition = true, Price = 578000, ChasisColor = Color.Shempgane, ManufDate = 2010 };
            Car DT1_6w = new Car() { CarId = 13, EngineId = Zetec1_4.EngineId, TrimPackageId = GhiaThreeHatch.TrimPackageId, Type = "Focus Ambience Dtec 1,6", Mileage = 0, Condition = false, Price = 2990000, ChasisColor = Color.Yellow, ManufDate = 2001 };
            Car DT1_6s = new Car() { CarId = 14, EngineId = Zetec1_4.EngineId, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia Dteec 1.6", Mileage = 31678, Condition = true, Price = 510000, ChasisColor = Color.Yellow, ManufDate = 1999 };
            Car DTC1_4h = new Car() { CarId = 15, EngineId = DTCI1_4.EngineId, TrimPackageId = AmbienceFiveWagon.TrimPackageId, Type = "Focus Lariett TDCi 1.4", Mileage = 0, Condition = false, Price = 3290000, ChasisColor = Color.Shempgane, ManufDate = 1999 };
            Car DTC1_4w = new Car() { CarId = 16, EngineId = DTCI1_4.EngineId, TrimPackageId = AmbienceFiveSedan.TrimPackageId, Type = "Focus Ambience TDCi 1.4", Mileage = 123542, Condition = true, Price = 600000, ChasisColor = Color.White, ManufDate = 1998 };
            Car DTC1_4s = new Car() { CarId = 17, EngineId = DTCI1_4.EngineId, TrimPackageId = AmbienceFiveHatch.TrimPackageId, Type = "Focus Lariett TDCi 1.4", Mileage = 234254, Condition = true, Price = 575000, ChasisColor = Color.DeepRed, ManufDate = 2000 };
            Car DTC1_8h = new Car() { CarId = 18, EngineId = DTCI1_4.EngineId, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ambience TDCI 1.8", Mileage = 125002, Condition = true, Price = 550000, ChasisColor = Color.Green, ManufDate = 2001 };
            Car DTC1_8w = new Car() { CarId = 19, EngineId = DTCI1_4.EngineId, TrimPackageId = LariettFiveSedan.TrimPackageId, Type = "Focus Ambience TDCi 1.8", Mileage = 178900, Condition = false, Price = 3690000, ChasisColor = Color.White, ManufDate = 2002 };
            Car DTC1_8s = new Car() { CarId = 20, EngineId = DTCI1_4.EngineId, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia TDCi 1.8", Mileage = 237100, Condition = true, Price = 490000, ChasisColor = Color.PearlBlack, ManufDate = 2003 };
            Car DTC2_0h = new Car() { CarId = 21, EngineId = DTCI1_4.EngineId, TrimPackageId = LariettFiveSedan.TrimPackageId, Type = "Focus Ghia TDCi 2.0", Mileage = 0, Condition = false, Price = 3990000, ChasisColor = Color.GlossBlack, ManufDate = 2006 };
            Car DTC2_0w = new Car() { CarId = 22, EngineId = DTCI1_4.EngineId, TrimPackageId = GhiaFiveHatch.TrimPackageId, Type = "Focus Ghia TDCi 2.0", Mileage = 78900, Condition = true, Price = 600000, ChasisColor = Color.Red, ManufDate = 2006 };
            Car DTC2_0s = new Car() { CarId = 23, EngineId = DTCI1_4.EngineId, TrimPackageId = LariettThreeSedan.TrimPackageId, Type = "Focus Ambience TDCi 2.0", Mileage = 0, Condition = false, Price = 4299000, ChasisColor = Color.Orange, ManufDate = 2009 };
             #endregion
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasOne(car => car.Equipment)
                    .WithMany(trimPackage => trimPackage.Cars)
                    .HasForeignKey(car => car.TrimPackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(Car => Car.Engine)
                    .WithMany(Engine => Engine.Cars)
                    .HasForeignKey(Car => Car.EngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Car>().HasData(FocusST170, FocusRS170, Ztec1_4h, Ztec1_4w, Ztec1_4s, ZTec1_6h, ZTec1_6w, ZTec1_6s, DT1_4h, DT1_4w, DT1_4s, DT1_6h, DT1_6w, DT1_6s, DTC1_4h, DTC1_4w, DTC1_4s, DTC1_8h, DTC1_8w, DTC1_8s, DTC2_0h, DTC2_0w, DTC2_0s);
            modelBuilder.Entity<TrimLevel>().HasData(RS1701 ,ST1701,GhiaFiveWagon, GhiaFiveSedan, GhiaThreeHatch, GhiaFiveHatch, AmbienceThreeHatch, AmbienceFiveWagon, AmbienceFiveHatch, AmbienceFiveSedan, LariettFiveWagon, LariettThreeSedan, LariettFiveSedan, LariettTreeHatch);
            modelBuilder.Entity<Engine>().HasData(ST170, RS170, Zetec1_4, Zetec1_6, Duratec1_4, Duratec1_6, DTCI1_4, DTCI1_8, DTCI2_0);
        }
    }
}