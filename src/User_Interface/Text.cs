/*The "Text" class provides the necessary tools for printing infromation for the User
 * 
*/

namespace Birthday_Calender_User_Interface
{
    internal class Text
    {
        // This method prints the save files's content to the console 
        public static void viewSaveData()
        {
            // Get the directory of the save file
            string SAVE_FILE_DIRECTORY = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + @"\Save.csv";

            // Create a list of all the data lines in the save file
            List<string> DATA = File.ReadAllLines(SAVE_FILE_DIRECTORY).ToList();

            // Create a FileInfo object. With it we can read the save file's content
            FileInfo FILE = new FileInfo(SAVE_FILE_DIRECTORY);

            if (FILE.Length != 0)
            {
                // Prints the List content to the console 
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Person's List: ");

                Console.ForegroundColor = ConsoleColor.Green;
                if (DATA.Count >= 3)
                {
                    Console.WriteLine("{0} FRIENDS :]", DATA.Count);
                }
                else
                {
                    Console.WriteLine("{0} FRIEND :]", DATA.Count);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.ForegroundColor= ConsoleColor.Gray;
                Console.WriteLine($"{Environment.NewLine}[Vorname],[Nachname],[Geburtsdatum],[Geschlecht]");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                for (int i = 0; i < DATA.Count; i++)
                {
                    Console.WriteLine((i + 1) + ": " + DATA[i]);
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                // If the save file is empty. The User will be reminded that he should touch grass...
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Person's List: ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO FRIENDS :(");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        // This method just prints the avaliable operations for the User to chose from 
        public static void printOperations()
        {
            Console.WriteLine($"{Environment.NewLine}| 1 - Add | | 2 - Import | | 3 - Delete | | 4 - Clear |");
        }
    }
}
