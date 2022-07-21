using System;
using CsvHelper;
using System.Collections;
using System.Globalization;
using System.Linq;

namespace ConsoleCSVFileParserConsoleApp2
{
    class Program
    {
        public static List<PersonRecord>? PersonRecords;

        private static readonly DirectoryInfo? DatasetPath =
        Directory.GetParent(Directory.GetParent(
           Directory.GetParent(
               Directory.GetParent(
                   Directory.GetCurrentDirectory())?
                   .ToString() ?? string.Empty)?.ToString()
           ?? string.Empty)?.ToString() ?? string.Empty);


        static void Main(string[] args)
        {
            string filePathString = DatasetPath + "/ConsoleCVSFileParserConsoleApp2/csv/input.csv";

            using (var reader = new StreamReader(filePathString!))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonRecords = csv.GetRecords<PersonRecord>().ToList();
            }

            Console.WriteLine("Enter 1 to return person records with Esq in their company name :");
            Console.WriteLine("Enter 2 to return person records with Derbyshire as their county of residence :");
            Console.WriteLine("Enter 3 to return person records with 3 digit number in address :");
            Console.WriteLine("Enter 4 to return person records with URL > 35 characters :");
            Console.WriteLine("Enter 5 to return person records with 1 digit in start of postcode :");
            Console.WriteLine("Enter 6 to return person records with Phone number 1  > Phone number 2 :");
            Console.WriteLine("Enter 7 to exit :");

            string? userInput;

            while ((userInput = Console.ReadLine()) != "7")
            {
                ArrayList resultarraylist = new();

                if (Convert.ToInt32(userInput) < 1 || Convert.ToInt32(userInput) > 7)
                {
                    Console.WriteLine("Try again");
                }
                else
                {
                    resultarraylist = CollectionOfQueries.ProcessQuery(PersonRecords, Convert.ToInt32(userInput)); //Send file and id of query

                    for (int i = 0; i < resultarraylist.Count; i++)
                        Console.WriteLine($"{resultarraylist[i]} ");
                }
            }
        }
    }
}