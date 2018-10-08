using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class RaceTower
    {
        private int totalLapsNumber;
        private int currentLap;
        private int trackLenght;
        private Dictionary<string ,Driver> activeRecers = new Dictionary<string, Driver>();
        private List<Driver> failedRacers = new List<Driver>();

        public RaceTower() { this.currentLap = 0; }

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.totalLapsNumber = lapsNumber;
            this.trackLenght = trackLength;
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            if (this.CheckDriver(commandArgs))
            {
                Tyre currentTyre = null;
                if (commandArgs[4] == "Ultrasoft")
                {
                    currentTyre = new UltrasoftTyre(double.Parse(commandArgs[5]), double.Parse(commandArgs[6]));
                }
                else if (commandArgs[4] == "Hard")
                {
                    currentTyre = new HardTyre(double.Parse(commandArgs[5]));
                }

                Car currentCar = new Car(int.Parse(commandArgs[2]), double.Parse(commandArgs[3]), currentTyre);

                Driver currentDriver = null;
                if (commandArgs[0] == "Aggressive")
                {
                    currentDriver = new AggressiveDriver(commandArgs[1], currentCar);
                }
                else if (commandArgs[0] == "Endurance")
                {
                    currentDriver = new EnduranceDriver(commandArgs[1], currentCar);
                }

                activeRecers.Add(currentDriver.Name, currentDriver);
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            Driver currentRacer = activeRecers[commandArgs[1]];
            currentRacer.TotalTime += 20;
            if (commandArgs[0] == "Refuel")
            {
                currentRacer.Car.FuelAmount += double.Parse(commandArgs[2]);
            }
            else if (commandArgs[0] == "ChangeTyres")
            {
                if (commandArgs[2] == "Hard")
                {
                    currentRacer.Car.Tyre = new HardTyre(double.Parse(commandArgs[3]));
                }
                else if (commandArgs[2] == "Ultrasoft")
                {
                    currentRacer.Car.Tyre = new UltrasoftTyre(double.Parse(commandArgs[3]), double.Parse(commandArgs[4]));
                }
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            int lapsToComplete = int.Parse(commandArgs[0]);

            for (int i = 0; i < lapsToComplete; i++)
            {
                foreach (Driver racer in activeRecers.Values)
                {
                    if (!failedRacers.Contains(racer))
                    {
                        racer.TotalTime += 60 / (trackLenght / racer.Speed);
                        racer.DriveCar(trackLenght);
                        if (racer.FailureReason == null)
                        {
                            racer.Degradate();
                        }

                        if (racer.FailureReason != null)
                        {
                            failedRacers.Add(racer);
                        }
                        else if (currentLap + 1 >= totalLapsNumber)
                        {
                            return $"{racer.Name} wins the race for {racer.TotalTime:f3} seconds.";
                        }
                    }
                }
                currentLap++;
            }

            return $"Lap {currentLap}/{totalLapsNumber}";
        }

        public string GetLeaderboard()
        {
            StringBuilder leaderboard = new StringBuilder();
            List<Driver> sortedActiveRacers = activeRecers.Values.OrderBy(d => d.TotalTime).ToList();
            List<Driver> sortedFailedRacers = failedRacers.OrderBy(d => d.TotalTime).ToList();
            int position = 1;

            foreach (var activeRacer in sortedActiveRacers)
            {
                leaderboard.AppendLine($"{position} {activeRacer.Name} {activeRacer.TotalTime:f3}");
                position++;
            }
            foreach (var failedRacer in sortedFailedRacers)
            {
                leaderboard.AppendLine($"{position} {failedRacer.Name} {failedRacer.FailureReason}");
                position++;
            }

            return leaderboard.ToString().Trim();
        }

        //Private Methods:
        private bool CheckDriver(List<string> commandArgs)
        {
            bool driverIsOK = true;

            if (commandArgs[0] != "Aggressive" && commandArgs[0] != "Endurance")
            {
                driverIsOK = false;
                return driverIsOK;
            }
            else if (commandArgs[1] == null)
            {
                driverIsOK = false;
                return driverIsOK;
            }
            else if (commandArgs[4] != "Ultrasoft" && commandArgs[4] != "Hard")
            {
                driverIsOK = false;
                return driverIsOK;
            }

            return driverIsOK;
        }
    }
}
