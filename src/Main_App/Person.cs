/* The "Person" class is for representing the Person's data in the save file as "Objects"
 * 
 * WARNING: any changes to this class may results in undifined behavior and effect the functionality of the app
 */

namespace Birthday_Calender_Main_App
{
    internal class Person
    {
        // Person's properties
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateOnly Geburtsdatum { get; set; }
        public int Alter { get; set; }
        public char Geschlecht { get; set; }

        // Persons's object constructor
        public Person(string vorname, string nachname, string datum, string gesclecht)
        {
            // When constructing an person object, the parameters will be set as attributs of the object 
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsdatum = DateOnly.Parse(datum);
            this.Geschlecht = Convert.ToChar(gesclecht);
            this.Alter = DateOnly.FromDateTime(DateTime.Now).Year - Geburtsdatum.Year;
        }

        public static void printtMassage(List<Person> BIRTHDAY_LIST)
        {
            for (int j = 0; j < BIRTHDAY_LIST.Count; j++)
            {
                if (BIRTHDAY_LIST[j].Geschlecht == 'm')
                {
                    // Set color blue if it is a male
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    // Set Violet if it is a female
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }

                // Print the birthday massage
                Console.WriteLine("                        .-\"\"\"-.\r\n                       / .===. \\\r\n                       \\/ 6 6 \\/\r\n                       ( \\___/ )\r\n  _________________ooo__\\_____/_____________________\r\n /                                                  \\\r\n  Hey, I Just wish " + BIRTHDAY_LIST[j].Vorname + " " + BIRTHDAY_LIST[j].Nachname + " a Happy " + BIRTHDAY_LIST[j].Alter + " Birthday.  \r\n \\______________________________ooo_________________/\r\n                       |  |  |\r\n                       |_ | _|\r\n                       |  |  |\r\n                       |__|__|\r\n                       /-'Y'-\\\r\n                      (__/ \\__)");
                Console.WriteLine();
            }
        }
    }
}
