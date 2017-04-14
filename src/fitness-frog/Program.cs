using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_frog {
    class Program {
        static void Main(string[] args) {
            // initialize the variables
            int newMin; // total minutes for the current set
            int runningTotal = 0; // total minutes for the entire current session
            ConsoleKeyInfo k; // convert OS system keypress to variable for future comparison

            // Loop until the user enters a valid number of minutes greater than the initial 0 minutes
            while (runningTotal <= 0) {
                // Prompt the user for minutes exercised
                Console.Write("How minutes you have exercied? ");
                var response = Console.ReadLine();
                try {
                    Int32.TryParse(response, out newMin);  // Safely convert user's response to int
                    runningTotal = (newMin + runningTotal); // Add minutes exercised to running total
                    //Console.WriteLine("you entered: " + newMin + " and the type: " + newMin.GetType());
                }
                catch {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red; // Indicate the error to the user
                    Console.WriteLine("Something has gone terribly wrong, press the <Enter> key to exit program...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            // Display the running total to the screen
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You have been exercising a total of " + runningTotal + " minutes.");
            Console.ForegroundColor = ConsoleColor.White;


            // Query the user and receive their keypress
            Console.WriteLine("\n\nPress the <SPACEBAR> key to continue: \nPress the <Q> key to exit program: ");
            k = Console.ReadKey(true);

            // Pass the next keypress to see if 
            WaitForKey(k.Key);

        }

        static void WaitForKey(ConsoleKey k) {
            // Call this and pass in the next keypress event to see if Q or Spacebar key was pressed
            // Repeat these processes until the user indicates a valid response
            while (k != ConsoleKey.Spacebar && k != ConsoleKey.Q) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red; // Indicate the error to the user
                Console.WriteLine("\n<" + k + "> is an invalid selection. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress the <SPACEBAR> key to continue: \nPress the <Q> key to exit program: ");
            }

            while (k == ConsoleKey.Spacebar || k == ConsoleKey.Q) {
                if (k == ConsoleKey.Spacebar) {
                    Console.WriteLine("Pressed Spacebar!");
                    Console.ReadLine();
                }
                if (k == ConsoleKey.Q) {
                    Environment.Exit(0);
                }
            }
        }
    }
}
