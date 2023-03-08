/* ==>(This Program ist the command-line user interface app for the birthday calender project)<== 
 * 
 * AUTHOR: Abdul Jawad Mansour
 * VERSION: 1.0
 * 
 * The "Program" class defines the main structure of the app
 * 
 * WARNING: any changes to this class may results in undifined behavior and effect the functionality of the app 
*/

namespace Birthday_Calender_User_Interface
{
    internal class Program
    {
        // The "main" method is the entry point of the program
        static void Main(string[] args)
        {
            // Clearing the terminal
            Console.Clear();

            // Program's properties
            Console.WindowHeight = 35;
            Console.WindowWidth = 140;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Geburtstags_Kalender (User Interface)";

            // Get the directory of the save file
            string SAVE_FILE_DIRECTORY = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + @"\Save.csv";

            // Needed information
            int OPERATION_NUMBER;
            bool RESTART;

            // Here is where the actual program begins
            do
            {
                /*-----------------------------------------------------(Part 1)-----------------------------------------------------*/

                Console.WriteLine("Welcome to our surprise Birthday Calender!");

                // Check if the save file exists in local directory
                if (!System.IO.File.Exists(SAVE_FILE_DIRECTORY))
                {
                    // If the save file doesn't exist, a new one will be created
                    Console.Write($"{Environment.NewLine}Checking For save file: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Missing");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    CSV_Files.Create(SAVE_FILE_DIRECTORY);
                    Console.WriteLine($"   ==>   [A new file has been created]{Environment.NewLine}");
                }
                else
                {
                    // If the save file exists, no new file will be created
                    Console.Write($"{Environment.NewLine}Checking For save file: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Found");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"   ==>   [A new file is not needed]{Environment.NewLine}");
                }

                /*-----------------------------------------------------(Part 2)-----------------------------------------------------*/

                // Print the save file's data and the avaliable operations for the User
                Text.viewSaveData();
                Text.printOperations();

                // The user enteres the number of the operation he wants to proceed
                Console.Write($"{Environment.NewLine}Enter your desired operation: ");
                OPERATION_NUMBER = User_Input.getOperNumber();

                // Navigate to the selected operation and run it
                navOperation(OPERATION_NUMBER);

                // Print the end massage 
                endMassage(OPERATION_NUMBER);

                /*-----------------------------------------------------(Part 3)-----------------------------------------------------*/

                // Asks the user if he wants to go back to menu or to exit
                Console.Write($"{Environment.NewLine}Return to menu? [y|n]: ");
                RESTART = User_Input.getConfermation();

                if (RESTART == true)
                {
                    // If the user enters "YES", the program will restart form the beginning 
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Yellow;
                }
                else
                {
                    // If thw user Enters "NO", the program will close
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press any key to exit...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                }


            } while (RESTART);
        }

        // This navigator method takes the entered operation from the user and executes it
        public static void navOperation(int operationNumber) 
        {
            // Get the directory of the save file
            string SAVE_FILE_DIRECTORY = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + @"\Save.csv";

            bool RESTART;
            do
            {
                switch (operationNumber)
                {
                    case 1: // This operation will add a new person's data to the save file
                        RESTART = false;
                        Console.Clear();
                        Console.WriteLine($"Adding data:{Environment.NewLine}");
                        CSV_Files.add(SAVE_FILE_DIRECTORY);
                        break;

                    case 2: // This operation will import an another csv file's content to to the save file
                        RESTART = false;
                        Console.Clear();
                        Console.WriteLine($"Importing data:{Environment.NewLine}");
                        CSV_Files.Import(SAVE_FILE_DIRECTORY);
                        break;

                    case 3: // This operation will delete the dat of a certian person from the save file 
                        RESTART = false;
                        Console.Clear();
                        Console.WriteLine($"Deleting data:{Environment.NewLine}");
                        CSV_Files.Delete(SAVE_FILE_DIRECTORY);
                        break;

                    case 4: // This Operation will delete all the save file's content
                        RESTART = false;
                        Console.Clear();
                        Console.WriteLine($"Clearing data:{Environment.NewLine}");
                        CSV_Files.Clear(SAVE_FILE_DIRECTORY);
                        break;

                    default:
                        // This error will appear if the operation number is not associated with an existing operation
                        RESTART = true;
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine($"The number you entered is worng{Environment.NewLine}");

                        // The User will be asked to reenter the operation number and the precess will restart
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Text.viewSaveData();
                        Console.WriteLine($"{Environment.NewLine}| 1 - Add | | 2 - Import | | 3 - Delete | | 4 - Clear |");
                        Console.Write($"{Environment.NewLine}please reenter the operaton you want: ");
                        operationNumber = User_Input.getOperNumber();
                        break;
                }

            } while (RESTART);     
        }

        // This method, after the chiosen operaton is finished, will tell The User that everything worked fine
        public static void endMassage(int operationNumber)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            switch (operationNumber)
            {
                // Depending on the chosen operation, the end massage will differ
                case 1:
                    Console.WriteLine("The data has been successfully added");
                    break;
                case 2:
                    Console.WriteLine("The data has been successfully imported");
                    break;
                case 3:
                    Console.WriteLine("The data has been successfully deleted");
                    break;
                case 4:
                    Console.WriteLine("The data has been successfully cleared");
                    break;
            }
        }
    }
}