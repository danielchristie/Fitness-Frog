using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_frog {
    class Program {
        static void Main(string[] args) {
            int userGoal = getGoal();
            programLoop(userGoal); // call method to inquire for session goal
        }

        static void programLoop(int userGoal) {
            ConsoleKeyInfo k;  // System key press object
            int runningTotal = 0; // total minutes for the entire current session
            bool run = true;
            // Main program Loop
            while (run) {
                // Keypress Loop
                do {
                    // Display the running total to the screen
                    showTotal(userGoal, runningTotal);
                    displayOptions();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    k = Console.ReadKey();

                    if (k.Key == ConsoleKey.A) {
                        getMin();
                        string response = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        runningTotal = addMin(userGoal, response, runningTotal);
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
        }

        static void displayOptions() {
            // Display the options to user
            Console.WriteLine("\n\nPress the <A> key to add additional minutes: \nPress the <Q> key to exit program: ");
        }

        static void askGoal() {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please indicate how many minutes you plan to exercise for this session?\n");
        }

        static void showTotal(int userGoal, int runningTotal) {
            string strSupport = "";
            if (runningTotal >= 100) {
                strSupport = "\nVery good start, keep on going, you are doing great!";
            } else if (runningTotal >= (userGoal)) {
                strSupport = "\nWhew! The hard part is behind you now. Come on, you are doing great!";
            } else if (runningTotal >= 300) {
                strSupport = "\nExcellent work, you are over half way there. You got this!";
            } else if (runningTotal >= 400) {
                strSupport = "\nCome on you are so close to being done. You can do it!";
            }
            Console.Clear();
            // Display the running total to the screen
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You have been exercising a total of " + runningTotal + " out of " + userGoal + " minutes.");
            Console.WriteLine(strSupport);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void getMin() {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            // Prompt the user for minutes exercised
            Console.Write("Please type in the additional minutes that you have exercised: \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        static int addMin(int userGoal, string response, int runningTotal) {
            int newMin = 0; // new set of minutes
            try {
                Int32.TryParse(response, out newMin);  // Safely convert user's response to int
                if (newMin <= 0) {
                    Console.ForegroundColor = ConsoleColor.Red; // Indicate the error to the user
                    Console.WriteLine("\n" + response + " is an invalid number. \nYou must type in a numeric value.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Press any key to continue...");
                    Console.Read();
                    Console.Read();
                }
                runningTotal = (newMin + runningTotal); // Add minutes exercised to the running total
                showTotal(userGoal, runningTotal); // display new total
                return runningTotal; // return the new running total back to the main program loop
            }
            catch {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red; // Indicate the error to the user
                Console.WriteLine("Something has gone terribly wrong, press the <Enter> key to exit program...");
                Console.Read();
                Console.ForegroundColor = ConsoleColor.White;
                return runningTotal;
            }
        }

        static int getGoal() {
            int userGoal = 0;
            while (userGoal == 0) {
                askGoal();
                string reply = Console.ReadLine();
                try {
                    Int32.TryParse(reply, out userGoal);  // Safely convert user's response to int
                    if (userGoal <= 0) {
                        Console.ForegroundColor = ConsoleColor.Red; // Indicate the error to the user
                        Console.WriteLine("\n" + reply + " is an invalid number. \nYou must type in a numeric value.");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Press any key to continue...");
                        Console.Read();
                        Console.Read();
                    }
                }
                catch {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red; // Indicate the error to the user
                    Console.WriteLine("Something has gone terribly wrong, press the <Enter> key to exit program...");
                    Console.Read();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return userGoal;
        }
    }
}
