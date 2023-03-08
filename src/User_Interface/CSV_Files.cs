/* The "CSV_Files" class provides the necessary tools to manipulate and change csv files 
 * 
 * WARNING: any changes to this class may results in undifined behavior and effect the functionality of the app
*/

namespace Birthday_Calender_User_Interface
{
    internal class CSV_Files
    {
        // This method create a new save file in the local directory
        public static void Create(string filePath)
        {
            bool RESTART;
            do
            {
                try
                {
                    RESTART = false;

                    // Create a save file 
                    using (File.Create(filePath));
                }
                catch (Exception ex)
                {
                    // This error will appear if something goes wrong
                    RESTART = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Environment.NewLine}An error has occurred: " + ex.Message);
                    Console.ReadKey();
                }

            } while (RESTART);
        }

        // This method will add the person' information to the save file 
        public static void add(string filePath)
        {
            bool RESTART;
            do
            {
                try
                {
                    RESTART = false;

                    // The User will enter the person's date: [
                    Console.Write("Please enter the person's first name: ");
                    string Vorname = User_Input.getName();

                    Console.Write($"{Environment.NewLine}Please enter the person's last name: ");
                    string Nachname = User_Input.getName();

                    Console.Write($"{Environment.NewLine}Please enter the person's birthdate [dd/mm/yy | dd.mm.yy]: ");
                    string Datum = Convert.ToString(User_Input.getDate());

                    Console.Write($"{Environment.NewLine}Please enter the Person's gender [m/w]: ");
                    char Geschlecht = User_Input.getGender();

                    // Create a StreamWriter Object that writes the data to the save file 
                    using (System.IO.StreamWriter Writer = new StreamWriter(filePath, true))
                    {
                        Writer.WriteLine(Vorname + "," + Nachname + "," + Datum + "," + Geschlecht);
                    }
                }
                catch (Exception ex)
                {
                    // This error will appear if something goes wrong
                    RESTART = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Environment.NewLine}An error has occurred: " + ex.Message);
                    Console.ReadKey();
                }

            } while (RESTART);
        }

        // This method will take the data of a csv file and import it to the save file 
        public static void Import(string filePath)
        {
            bool RESTART;
            do
            {
                try
                {
                    RESTART = false;

                    // The User will enter the path of the file he wants to import
                    Console.Write("Please enter the file path: ");
                    string ImportFilePath = User_Input.getFilePath();
                    string[] fileLines = System.IO.File.ReadAllLines(ImportFilePath);

                    // Create a StreamWriter object that will write the imported file's data to the save file
                    using (System.IO.StreamWriter Writer = new StreamWriter(filePath, true))
                    {
                        foreach (string line in fileLines)
                        {
                            Console.WriteLine(line);
                            Writer.WriteLine(line); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    // This error will appear if something goes wrong
                    RESTART= true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Environment.NewLine}An error has occurred: " + ex.Message);
                    Console.ReadKey();
                }

            } while (RESTART);
        }

        // This method will delete a certian person's data from the save file
        public static void Delete(string filePath)
        {
            bool RESTART;
            do
            {
                try 
                {
                    FileInfo file = new FileInfo(filePath);

                    if (file.Length != 0)
                    {
                        RESTART = false;

                        // The save file's data will be viewed
                        Text.viewSaveData();

                        // A list will be created, that contains the data lines of the save file  
                        List<string> List = File.ReadAllLines(filePath).ToList();

                        // The user must enter the line number of the data he wants to delete. The picked data will be removed from the list 
                        Console.Write($"{Environment.NewLine}enter the data line you to delete: ");
                        int LineNum = User_Input.getLineNumber(List);
                        List.RemoveAt(LineNum);

                        // Create a StreamWriter Object that will clears the save file and write back the list's content 
                        using (System.IO.StreamWriter Writer = new StreamWriter(filePath, false))
                        {
                            foreach (string line in List)
                            {
                                Writer.WriteLine(line);
                            }
                        }
                    }
                    else
                    {
                        // This error will appear if the save file is empty
                        RESTART = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("The save file is already empty...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    // This error will appear if somnething goes wrong
                    RESTART = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Environment.NewLine}An error has occurred: " + ex.Message);
                    Console.ReadKey();
                }

            } while (RESTART);
        }

        // This method will empty all the save file's content
        public static void Clear(string filePath)
        {
            bool RESTART;
            do
            {
                try
                {
                    FileInfo file = new FileInfo(filePath);

                    if (file.Length != 0)
                    {
                        RESTART = false;

                        // Deletes the save file, then a new one will be created
                        File.Delete(filePath);
                        File.WriteAllText(filePath, string.Empty);
                    }
                    else
                    {
                        // This error will appear if the file is empty
                        RESTART = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("The save file is already empty...");
                        Console.ReadKey();
                    } 
                }
                catch (Exception ex)
                {
                    // This error will appear if something goes wrong
                    RESTART = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Environment.NewLine}An error has occurred: " + ex.Message);
                    Console.ReadKey();
                }

            } while (RESTART);
        }
    }
}
