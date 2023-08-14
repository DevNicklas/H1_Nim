using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Amount of matches on the table
            byte amountTableMatches = 7;

            // Determines which turn it is
            bool playerTurn = true;

            // Keeps the game going until there is 1 or less matches left
            while (amountTableMatches > 1)
            {
                Console.Clear();

                // Player's turn
                if (playerTurn)
                {
                    // Amount of matches to subtract from the table
                    byte subtractMatches = 0;

                    // Loops until the user gives an number greater than 0 and less than 4 and
                    // the amount of matches on the table
                    while(subtractMatches == 0)
                    {
                        // Writes out the amount of matches on the table
                        Console.WriteLine("Matches on the table: " + amountTableMatches);
                        Console.WriteLine("Write the number of matches you want to take off the table:");

                        // Checks if the user input is an byte, is less than 4 and
                        // amount of matches on the table
                        if (byte.TryParse(Console.ReadLine(), out subtractMatches) && subtractMatches < 4 && subtractMatches < amountTableMatches)
                        {
                            amountTableMatches -= subtractMatches;
                        }

                        // Writes an error when the user gives a wrong input
                        else
                        {
                            subtractMatches = 0;

                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("The number has to be greater than 0 and less 4 and the amount of matches on the table\n");
                            Console.ResetColor();
                        }
                    }
                }

                // Computer's turn
                else
                {
                    // Writes out the amount of matches on the table
                    Console.Clear();
                    Console.WriteLine("Matches on the table: " + amountTableMatches);
                    Console.WriteLine("The computer is gonna remove an amount of matches, please wait:");

                    // Waits 3.5 seconds or 3500 ms before doing something else
                    // This is giving the user a better experience, its mostly for design
                    System.Threading.Thread.Sleep(3500);

                    // Subtracts an random number between 1 and the amount of matches on the table
                    Random rand = new Random();
                    amountTableMatches -= (byte)rand.Next(1, amountTableMatches);
                }

                // Switches between the turns
                playerTurn = !playerTurn;
            }

            Console.Clear();

            // If the computer wins
            if (playerTurn)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You lost against the computer");
            }

            // If the player wins
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You won against the computer. Congratulations");
            }
            Console.ReadKey();
        }
    }
}
