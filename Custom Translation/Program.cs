using System.Text;
using System.Text.Unicode;

namespace Custom_Translation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine(@"Choose a number to select language (or 'E' to quit):
--------------------------------
English to Georgian  1
Georgian to English  2");
                
                //Console.WriteLine(" English to Georgian  1");
                //Console.WriteLine(" Georgian to English  2");

                var response = Console.ReadLine().ToLower();
                if (response == "e")
                {
                    isRunning = false;
                }

                else if (response == "1")
                {
                    var path = "C:\\Users\\user\\source\\repos\\ConsoleApp4\\Custom Translation\\EN-KA.txt";


                    var translations = LoadTranslations(path);


                    Console.WriteLine("Enter an English word to translate:");
                    var englishInput = Console.ReadLine().ToLower();

                    if (translations.ContainsKey(englishInput))
                    {
                        Console.WriteLine($"The Georgian translation of '{englishInput}' is: {translations[englishInput]}");
                    }
                    else
                    {
                        Console.WriteLine($"'{englishInput}' word doesn't exist in dictionary! would you like it to add? (Y/N)");
                        var addResponse = Console.ReadLine().ToLower();

                        if (addResponse == "y")
                        {
                            Console.WriteLine("Enter the Georgian translation:");
                            var georgianTranslation = Console.ReadLine().ToLower();

                            File.AppendAllText(path, $"{englishInput}={georgianTranslation}", Encoding.UTF8);
                            Console.WriteLine("Word added to the dictionary.");
                        }
                        else
                        {
                            Console.WriteLine("Word not added to the dictionary.");
                        }
                    }

                }
                else if (response == "2")
                {
                    var path = "C:\\Users\\user\\source\\repos\\ConsoleApp4\\Custom Translation\\KA-EN.txt";
                    var translations = LoadTranslations(path);
                    Console.WriteLine("Enter a Georgian word to translate:");
                    var georgianInput = Console.ReadLine();
                    if (translations.ContainsKey(georgianInput))
                    {
                        Console.WriteLine($"The English translation of '{georgianInput}' is: {translations[georgianInput]}");
                    }
                    else
                    {
                        Console.WriteLine($"'{georgianInput}' word doesn't exist in dictionary! would you like it to add? (Y/N)");
                        var addResponse = Console.ReadLine().ToLower();
                        if (addResponse == "y")
                        {
                            Console.WriteLine("Enter the English translation:");
                            var englishTranslation = Console.ReadLine().ToLower();
                            File.AppendAllText(path, $"{georgianInput}={englishTranslation}", Encoding.UTF8);
                        }
                        else
                        {
                            Console.WriteLine("Word not added to the dictionary.");
                        }
                    }

                }

            }

            static Dictionary<string, string> LoadTranslations(string filePath)
            {
                Dictionary<string, string> translations = new Dictionary<string, string>();
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string englishWord = parts[0].Trim();
                            string georgianWord = parts[1].Trim();
                            translations[englishWord] = georgianWord;
                        }
                    }
                }
                return translations;
            }
        }
    }
}
