using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_frog {
    class Program {
        static void Main(string[] args) {
            // initialize the variables
            int runningTotal = 0; // total minutes for the entire current session
            ConsoleKeyInfo k;  // System key press object
            bool run = true;

            // Mian program Loop
            while (run) {
                // Keypress Loop
                do {
                    // Display the running total to the screen
                    showTotal(runningTotal);
                    displayOptions();
                    k = Console.ReadKey();

                    if (k.Key == ConsoleKey.A) {
                        getMin();
                        string response = Console.ReadLine();
                        runningTotal = addMin(response, runningTotal);
                        continue;
                    }
                    if (k.Key == ConsoleKey.Q) {
                        run = false;
                        Environment.Exit(0); // exit the program
                    }
                    if (k.Key != ConsoleKey.A && k.Key != ConsoleKey.Q) {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red; // Indicate the error to the user
                        Console.WriteLine("\n<" + k.Key + "> is an invalid selection. ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        Console.Read();
                    }
                } while (k.Key != ConsoleKey.A && k.Key != ConsoleKey.Q);
            } // end of Main program's do/while loop
        } // end Void Main

        static void displayOptions() {
            // Display the options to user
            Console.WriteLine("\n\nPress the <A> key to add additional minutes: \nPress the <Q> key to exit program: ");
        }

       static void showTotal(int runningTotal) {
            Console.Clear();
            // Display the running total to the screen
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You have been exercising a total of " + runningTotal + " minutes.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void getMin() {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            // Prompt the user for minutes exercised
            Console.Write("Please type in the additional minutes that you have exercied: ");
        }

        static int addMin(string response, int runningTotal) {
            int newMin = 0; // new set of minutes
            try {
                Int32.TryParse(response, out newMin);  // Safely convert user's response to int
                runningTotal = (newMin + runningTotal); // Add minutes exercised to running total
                showTotal(runningTotal);
                return runningTotal;
            }
            catch {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red; // Indicate the error to the user
                Console.WriteLine("Something has gone terribly wrong, press the <Enter> key to exit program...");
                Console.ForegroundColor = ConsoleColor.White;
                return runningTotal;
            }
        }
    }
}
