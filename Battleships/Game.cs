using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses
        public static int Play(string[] ships, string[] guesses)
        {
            Dictionary<int, string> game = new Dictionary<int, string>();
            int misses = 0;
            int strike = 0;
            //string[] sampleInput = new string[] { "3:2,3:5", "4:9,7:9" };
            //string[] tries = new string[] { "5:0", "3:3", "4:9", "3:5", "3:6", "3:2", "3:4" };
            for (int i = 0; i < ships.Length; i++)
            {
                string[] dstructure = ships[i].Split(',');
                string[] start = dstructure[0].Split(':');
                string[] end = dstructure[1].Split(':');
                int max;
                int min;
                if (start[0] == end[0]) //horizontal
                {
                    max = Math.Max(int.Parse(start[0] + start[1]), int.Parse(end[0] + end[1]));
                    min = Math.Min(int.Parse(start[0] + start[1]), int.Parse(end[0] + end[1]));
                    for (int x = min; x <= max; x++)
                    {
                        game.Add(x, $"Ship{i}");
                    }
                }
                else
                {
                    max = Math.Max(int.Parse(start[0] + start[1]), int.Parse(end[0] + end[1]));
                    min = Math.Min(int.Parse(start[0] + start[1]), int.Parse(end[0] + end[1]));
                    for (int x = min; x <= max; x += 10)
                    {
                        game.Add(x, $"Ship{i}");
                    }
                }
            }
            int numberofTries = guesses.Length;
            for (int i = 0; i < numberofTries; i++)
            {
                string[] coordinates = guesses[i].Split(':');
                int coor = int.Parse(coordinates[0] + coordinates[1]);
                if (game.ContainsKey(coor))
                {
                    game.Remove(coor);
                    strike++;
                }
                else
                {
                    misses++;
                }
            }
            Console.WriteLine($"Number of Strikes {strike}");
            Console.WriteLine($"Number of Misses {misses}");
            Console.WriteLine($"Number of Sink Boats {ships.Count() - game.Values.Distinct().Count()}");
            Console.WriteLine("Finish");
            return (ships.Count() - game.Values.Distinct().Count());
        }
    }
}
