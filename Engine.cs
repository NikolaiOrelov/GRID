using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRID
{
    public class Engine
    {
        public void Run()
        {
            RaceTower raceTower = new RaceTower();
            int totalLapsNumber = int.Parse(Console.ReadLine());
            int trackLenght = int.Parse(Console.ReadLine());
            
            raceTower.SetTrackInfo(totalLapsNumber, trackLenght);

            List<string> input = Console.ReadLine().Split().ToList();
            bool IsFinished = false;
            while (!IsFinished)
            {
                switch (input[0])
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(input.Skip(1).ToList());
                        break;
                    case "Leaderboard":
                        string leaderboard = raceTower.GetLeaderboard();
                        Console.WriteLine(leaderboard);
                        break;
                    case "CompleteLaps":
                        string output = raceTower.CompleteLaps(input.Skip(1).ToList());
                        List<string> forCheck = output.Split().ToList();
                        if (forCheck[1] == "wins")
                        {
                            IsFinished = true;
                        }
                        Console.WriteLine(output);
                        break;
                    case "Box":
                        raceTower.DriverBoxes(input.Skip(1).ToList());
                        break;
                }
                if (!IsFinished)
                {
                    input = Console.ReadLine().Split().ToList();
                }
            }
        }
    }
}
