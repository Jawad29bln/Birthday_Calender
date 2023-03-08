/* The "User_Input" class provides the necessary tools for getting various informations from the User  
 * 
 *  WARNING: any changes to this class may results in undifined behavior and will damage the functionality of the app
*/

namespace Birthday_Calender_User_Interface
{
    internal class User_Input
    {
        // This method takes the operation number from the User and returns it
        public static int getOperNumber()
        {
            int NUMBER = 0;

            bool RESTART;
            do
            {
                try
                {
                    RESTART = false;

                    // Takes a intenger type
                    Console.ForegroundColor = ConsoleColor.White;
                    NUMBER = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                catch (Exception ex)
                {
                    // This error will appear if the user enters something false, like a letter or empty space
                    RESTART = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occurred: " + ex.Message + $"{Environment.NewLine}");

                    // The user will requested to reenter the Number
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Text.viewSaveData();
                    Text.printOperations();
                    Console.Write($"{Environment.NewLine}Please reenter your Operation: ");
                }

            } while (RESTART);

            return NUMBER;
        }

        // This method takes the save file's line number from the User and returns it
        public static int getLineNumber(List<string> List)
        {
            int NUMBER = 0;

            bool RESTART;
            do
            {
                try
                {
                    // Take an intenger type
                    Console.ForegroundColor = ConsoleColor.White;
                    NUMBER = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    if ((NUMBER) >= List.Count || NUMBER < 0) 
                    {
                        // This error will appear if the number is out of range 
                        RESTART = true;
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine($"An error has occurred: the Number is out of range{Environment.NewLine}");

                        // The user will be requested to reenter the number
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Text.viewSaveData();
                        Console.Write($"{Environment.NewLine}Please errnter the Line Number: ");
                    }
                    else
                    {
                        RESTART = false;
                    }
                }
                catch (Exception ex)
                {
                    // This method will appear if something goes wrong
                    RESTART = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error has occurred:" + ex.Message + $"{Environment.NewLine}");

                    // The user will be requested to reenter the number
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Text.viewSaveData();
                    Console.Write($"{Environment.NewLine}Please errnter the Line Number: ");
                }

            } while (RESTART);

            return NUMBER;
        }

        // This method will take file path from the user and returns it  
        public static string getFilePath() 
        {
            string PATH = "";

            bool RESTART;
            do
            {
                try
                {
                    // Takes a string type
                    Console.ForegroundColor = ConsoleColor.White;
                    PATH = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    if (!String.IsNullOrEmpty(PATH) && File.Exists(PATH))
                    {
                        RESTART = false;
                    }
                    else
                    {
                        // This error will appear if the entered file path is wrongly typed or if it doesn't exist or empty
                        RESTART = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error has occurred: it is not legit or doesn't exist");

                        // The user will be requested to reenter the 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{Environment.NewLine}Please reenter the path: ");
                    }
                }
                catch (Exception ex)
                {
                    // This error will appear if something goes wrong
                    RESTART = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occurred: " + ex.Message);

                    // The user will be requested to reenter the file path
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{Environment.NewLine}Please reenter the path: ");
                }

            } while (RESTART);

            return PATH;
        }

        // This methos takes the confermation from the user for returning to menu and returns it
        public static bool getConfermation()
        {
            bool USER_CONFIRMATION = false;

            bool RESTART;
            do
            {
                try
                {
                    // Takes a boolean type
                    Console.ForegroundColor = ConsoleColor.White;
                    string USER_INPUT = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    if (USER_INPUT == "y")
                    {
                        // Return true if User enters "Yes"
                        RESTART = false;
                        USER_CONFIRMATION = true;
                    }
                    else if (USER_INPUT == "n")
                    {
                        // Returns false if the User enters "No"
                        RESTART = false;
                        USER_CONFIRMATION = false;
                    }
                    else
                    {
                        // This error will appear if the user enters something that is not "y" (Yes) or "n" (No)
                        RESTART = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error has occurred: it is not legit");

                        // // The Use will be requested to reenter the confermation
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{Environment.NewLine}Please reenter the confermation [y|n]: ");
                    }
                }
                catch (Exception ex)
                {
                    // This error will appear if something goes wrong
                    RESTART = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occurred: " + ex.Message);

                    // The user will be requested to reenter the confermation 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{Environment.NewLine}Please reenter the confermation [y|n]: ");
                }

            } while (RESTART); 

            return USER_CONFIRMATION;
        }

        // This method takes the name of the person and returns it. works for first and last name
        public static string getName() 
        {
            string NAME = "";

            bool RESTART;
            do
            {
                try
                {
                    // Takes a string type
                    Console.ForegroundColor = ConsoleColor.White;
                    NAME = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    if (!String.IsNullOrEmpty(NAME)) 
                    {
                        RESTART = false;
                    }
                    else 
                    {
                        // This error will appear if the user enters a empty string
                        RESTART = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error has occurred: it is empty");

                        // The user will be requested to reenter the name
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{Environment.NewLine}Please reenter the name: ");
                    }
                }
                catch (Exception ex)
                {
                    // This error will appear if something goes wrong
                    RESTART = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occurred: " + ex.Message);

                    // The user will be requested to reenter the name 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{Environment.NewLine}Please reenter the name: ");
                }

            } while (RESTART);

            return NAME;
        }

        // This method takes the birthdate of the person as "DateOnly" object and returns it 
        public static DateOnly getDate() 
        {
            DateOnly DATE = new DateOnly();

            bool RESTART;
            do
            {
                try
                {
                    RESTART = false;

                    // Takes a string type and parses it to "DateOnly" object
                    Console.ForegroundColor= ConsoleColor.White;
                    DATE = DateOnly.Parse(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                catch (Exception ex)
                {
                    // This error will appear if the user enters a birthday that is in undefined or empty
                    RESTART = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occurred: " + ex.Message);

                    // The user will be requestet to enter the birthdate
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{Environment.NewLine}Please reenter the birthdate [dd/mm/yy - dd.mm.yy]: ");
                }

            } while (RESTART);

            return DATE;
        }
        
        // This method will take the person's gender form the User and returns it
        public static char getGender() 
        {
            char GENDER = ' ';

            bool RESTART;
            do
            {
                try
                {
                    // Takes a char type
                    Console.ForegroundColor = ConsoleColor.White;
                    GENDER = Console.ReadKey().KeyChar;
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    if (!Char.IsWhiteSpace(GENDER) && (GENDER == 'm' | GENDER == 'w')) 
                    {
                        RESTART = false;
                        return GENDER;
                    }
                    else 
                    {
                        // This error will appear if the user enters a gender, that is undefined or doesn't exist 
                        RESTART = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("An error has occurred: it is empty or something you made up... ");

                        // The User will be requested to reenter the gender 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{Environment.NewLine}Please reenter the gender [m/w]: ");
                    }
                }
                catch (Exception ex)
                {
                    // This error will appear if something goes wrong
                    RESTART = true;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occurred: " + ex.Message);

                    // The user will be requested to reenter the gender
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{Environment.NewLine}Please reenter the Gender: ");
                }

            } while (RESTART);

            return GENDER;
        } 
    }
}
