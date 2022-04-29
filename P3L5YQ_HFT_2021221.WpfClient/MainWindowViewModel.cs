namespace P3L5YQ_HFT_2021221.WpfClient
{
    using Microsoft.Toolkit.Mvvm.ComponentModel;
    using Microsoft.Toolkit.Mvvm.Input;
    using P3L5YQ_HFT_2021221.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    public class MainWindowViewModel : ObservableRecipient
    {
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RestCollection<Car> Cars { get; set; }
        public RestCollection<Engine> Engines { get; set; }
        public RestCollection<TrimLevel> TrimLevels { get; set; }

        private Car selectedCar;
        private Engine selectedEngine;
        private TrimLevel selectedTrimLevel;

        #region ICommands
        public ICommand CreateCarCommand { get; set; }
        public ICommand CreateEngineCommand { get; set; }
        public ICommand CreateTrimLevelCommand { get; set; }
        public ICommand DeleteCarCommand { get; set; }
        public ICommand DeleteEngineCommand { get; set; }
        public ICommand DeleteTrimLevelCommand { get; set; }
        public ICommand UpdateCarCommand { get; set; }
        public ICommand UpdateEngineCommand { get; set; }
        public ICommand UpdateTrimLevelCommand { get; set; }
        #endregion

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                if (value != null)
                {
                    selectedCar = new Car()
                    {
                        CarId = value.CarId,
                        EngineId = value.EngineId,
                        TrimPackageId = value.TrimPackageId,
                        Mileage = value.Mileage,
                        ChasisColor = value.ChasisColor,
                        ManufDate = value.ManufDate,
                        Condition = value.Condition,
                        Type = value.Type,
                        Price = value.Price
                    };
                }
                OnPropertyChanged();
                (DeleteCarCommand as RelayCommand).NotifyCanExecuteChanged();
            }

        }
        public Engine SelectedEngine
        {
            get { return selectedEngine; }
            set
            {
                if (value != null)
                {
                    selectedEngine = new Engine()
                    {
                        EngineId = value.EngineId,
                        Enginename = value.Enginename,
                        EngineType = value.EngineType,
                        EruroRating = value.EruroRating,
                        Displacement = value.Displacement,
                        Fuelage = value.Fuelage,
                        PowerOutput = value.PowerOutput,
                        Torque = value.Torque
                    };
                }
                OnPropertyChanged();
                (DeleteEngineCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public TrimLevel SelectedTrimLevel
        {
            get { return selectedTrimLevel; }
            set
            {
                if (value != null)
                {
                    selectedTrimLevel = new TrimLevel()
                    {
                        TrimPackageId = value.TrimPackageId,
                        TrimPackageName = value.TrimPackageName,
                        AC = value.AC,
                        TwozoneAutomaticAC = value.TwozoneAutomaticAC,
                        AlloWheels = value.AlloWheels,
                        AlcantaraInterrior = value.AlcantaraInterrior,
                        RoofRack = value.RoofRack,
                        WeightHook = value.WeightHook,
                        Chasis = value.Chasis,
                        NumberofDoors = value.NumberofDoors
                    };
                }
                OnPropertyChanged();
                (DeleteTrimLevelCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public MainWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Cars = new RestCollection<Car>("https://localhost:44336", "/car", "hub");
                Engines = new RestCollection<Engine>("https://localhost:44336", "/engine", "hub");
                TrimLevels = new RestCollection<TrimLevel>("https://localhost:44336", "/trimlevel", "hub");
                #region CarCommands
                CreateCarCommand = new RelayCommand(() =>
                {
                    Cars.Add(new Car() { EngineId = selectedCar.EngineId, TrimPackageId = selectedCar.TrimPackageId, Type = selectedCar.Type, Mileage = selectedCar.Mileage, Condition = selectedCar.Condition, Price = selectedCar.Price, ChasisColor = selectedCar.ChasisColor, ManufDate = selectedCar.ManufDate });

                });

                DeleteCarCommand = new RelayCommand(() =>
                {
                    Cars.Delete(selectedCar.CarId);
                },
                () =>
                {
                    return SelectedCar != null;
                });

                UpdateCarCommand = new RelayCommand(() =>
                {
                    Cars.Update(SelectedCar, SelectedCar.CarId);
                });
                #endregion
                #region EngineCommands
                CreateEngineCommand = new RelayCommand(() =>
                {
                    Engines.Add(new Engine() { Enginename = selectedEngine.Enginename, EngineType = selectedEngine.EngineType, Fuelage = selectedEngine.Fuelage, EruroRating = selectedEngine.EruroRating, Displacement = selectedEngine.Displacement, Torque = selectedEngine.Torque, PowerOutput = selectedEngine.PowerOutput });
                });

                DeleteEngineCommand = new RelayCommand(() =>
                {
                    Engines.Delete(selectedEngine.EngineId);
                },
                () =>
                {
                    return SelectedEngine != null;
                });

                UpdateEngineCommand = new RelayCommand(() =>
                {
                    Engines.Update(SelectedEngine, SelectedEngine.EngineId);
                });
                #endregion
                #region TrimLevelCommands
                CreateTrimLevelCommand = new RelayCommand(() =>
                {
                    TrimLevels.Add(new TrimLevel() { TrimPackageName = selectedTrimLevel.TrimPackageName, AC = selectedTrimLevel.AC, TwozoneAutomaticAC = selectedTrimLevel.TwozoneAutomaticAC, AlloWheels = selectedTrimLevel.AlloWheels, AlcantaraInterrior = selectedTrimLevel.AlcantaraInterrior, RoofRack = selectedTrimLevel.RoofRack, WeightHook = selectedTrimLevel.RoofRack, Chasis = selectedTrimLevel.Chasis, NumberofDoors = selectedTrimLevel.NumberofDoors });

                });

                DeleteTrimLevelCommand = new RelayCommand(() =>
                {
                    TrimLevels.Delete(selectedTrimLevel.TrimPackageId);
                },
                () =>
                {
                    return SelectedTrimLevel != null;
                });

                UpdateTrimLevelCommand = new RelayCommand(() =>
                {
                    TrimLevels.Update(SelectedTrimLevel, SelectedTrimLevel.TrimPackageId);
                });
                #endregion
            }
            SelectedCar = new Car();
            SelectedEngine = new Engine();
            SelectedTrimLevel = new TrimLevel();
        }
    }
}
   

