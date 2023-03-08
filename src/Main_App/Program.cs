/* ==>(This is the birthday calender's main app)<==
 * 
 * AUTHOR: Abdul Jawad Mansour
 * VERSION: 1.0
 * 
 * The "Program" class defines the main strucktue of the app
 * 
 * NOTICE: this program is supposed to run automatically on OP startup and not manually by the User
 * 
 * WARNING: any changes to this class may results in undifined behavior and effect the functionality of the app 
 */

namespace Birthday_Calender_Main_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Program's properties
            Console.WindowHeight = 25;
            Console.WindowWidth = 100;
            Console.Title = "Happy birthday!!!";

            // Create a list of person's that were added to the save file, and another list of persons that have there birthday today
            var Persons_List = Person_Data.getPersonsList();
            var Birthday_List = new List<Person>();

            // Get the date of today  
            int Day = DateOnly.FromDateTime(DateTime.Now).Day;
            int Month = DateOnly.FromDateTime(DateTime.Now).Month;
            int Year = DateOnly.FromDateTime(DateTime.Now).Year;

            // Get the directory of the save file
            string SAVE_FILE_DIRECTORY = Path.GetDirectoryName(Directory.GetCurrentDirectory()) + @"\Save.csv";

            // If a save file doesn't exist. the program closes immediately 
            if (!File.Exists(SAVE_FILE_DIRECTORY))
            {
                Console.WriteLine("The save file does not exist");
                Environment.Exit(0);
            }

            // If there is no data in the save file, the program closes immediately
            if (Persons_List.Count == 0)
            {
                Console.WriteLine("The save file is empty");
                Environment.Exit(0);
            }
            
            // A Loop will go through the Person's list
            for (int i = 0; i < Persons_List.Count; i++)
            {
                // Get the Birthdate of the person
                int BirthDay = Persons_List[i].Geburtsdatum.Day;
                int BirthMonth = Persons_List[i].Geburtsdatum.Month;
                int BirthYear = Persons_List[i].Geburtsdatum.Year;

                // If someone's birthday matches the current date, he/she will be added to the birthday list
                if (BirthDay == Day && BirthMonth == Month && BirthYear <= Year)
                {
                    Birthday_List.Add(Persons_List[i]);
                }
            }

            // If no one has his birthday today, the program closes immediately
            if (Birthday_List.Count == 0)
            {
                Environment.Exit(0);
            }

            // A happy birthday picture will be presented to the ones that have there birthday today
            Person.printtMassage(Birthday_List);

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}