/*The "Person_Data" class provides necessary tools for controcting "Person" objects
 * 
 * WARNING: any changes to this class may results in undifined behavior and effect the functionality of the app
 */

namespace Birthday_Calender_Main_App
{
    internal class Person_Data
    {
        // This method will read the content lines of the save file and assign them to a newly contructed person's objekts, than returns the objects as a list  
        public static List<Person> getPersonsList()
        {
            // Create a new person's object list
            List<Person> PERSONS_LIST = new List<Person>();

            // Get the directory of the save file
            string SAVE_FILE_DIRECTORY = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + @"\Save.csv";

            // Get the number of person's in the save file
            int LINES_COUNT = File.ReadAllLines(SAVE_FILE_DIRECTORY).Length;
            
            // Create a list for every data type the person object has and add the data column to it's designated 
            List<string> Vorname = getColumn(1);
            List<string> Nachname = getColumn(2);
            List<string> Geburtsdatum = getColumn(3);
            List<string> Geschlecht = getColumn(4);

            // A loop will create a person object for every data line in the save file and assign it's data parameters to it
            try
            {
                for (int i = 0; i < LINES_COUNT; i++)
                {
                    var Person = new Person(Vorname[i], Nachname[i], Geburtsdatum[i], Geschlecht[i]);
                    PERSONS_LIST.Add(Person);
                }
            }
            catch
            {
                // This error will appear if the save file is corrupted
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error has occurred: the save file was tampered with");

                Console.Write($"{Environment.NewLine}Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            
            return PERSONS_LIST;
        }

        // This method will read the save file's data columns and returns them a a list 
        public static List<string> getColumn(int ColumbLine)
        {
            // Get the directory of the save file
            string SAVE_FILE_DIRECTORY = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + @"\Save.csv";

            // Create a new list for storing the data column
            List<string> DATA_LIST = new List<string>();

            // Create a string array, that contains every data line in the save file 
            string[] LINES = File.ReadAllLines(SAVE_FILE_DIRECTORY);

            // A loop will go through the array and extract the chosen column's data from the array an add it to the list
            try
            {
                for (int i = 0; i < LINES.Length; i++)
                {
                    string[] RAW_DATA = LINES[i].Split(',');
                    DATA_LIST.Add(RAW_DATA[ColumbLine - 1]);
                }
            }
            catch
            {
                // This error will appear if the save file is corrupted
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error has occurred: the save file was tampered with" );

                Console.Write($"{Environment.NewLine}Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            return DATA_LIST;
        }
    }
}
