using CsvHelper;
using FluentAssertions;
using System.Collections;
using System.Globalization;
using System.Linq;

namespace ConsoleCSVFileParserConsoleApp2
{
    public class Tests
    {
        public static List<PersonRecord>? PersonRecords;
        
        private static readonly DirectoryInfo? DatasetPath =
        Directory.GetParent(Directory.GetParent(
           Directory.GetParent(
               Directory.GetParent(
                   Directory.GetCurrentDirectory())?
                   .ToString() ?? string.Empty)?.ToString()
           ?? string.Empty)?.ToString() ?? string.Empty);


        public string filePathString = DatasetPath + "/ConsoleCVSFileParserConsoleApp2/csv/testcsvfile1.csv";

        [SetUp]
        public void Setup()
        { 
        
        }

        [Test]
        public void TestInitialise()
        {
            Assert.Pass();
        }

        [Test]
        public void TestUsingCSVHelperReadAKnownRecordFromCSVFile()
        {
            // Get s single person record from test file and check against expected contents of test record

            const int NUM_OF_ROWS = 1;

            string[] ExpectedPersonRecords =
            {
                "Aleshia",
                "Jones",
                "Alan D Rosenburg Cpa Pc Esq",
                "14 Taylor St",
                "St. Stephens Ward",
                "Derbyshire",
                "CT2 7PP",
                "01955-703596",
                "01944-369967",
                "atomkiewicz@hotmail.com",
                "http://www.alandrosenburgcpapc.co.uk"
            };

            using (var reader = new StreamReader(filePathString!))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonRecords = csv.GetRecords<PersonRecord>().ToList(); // Using CSVHelper package
            }

            PersonRecords.Should().NotContainNulls();
            PersonRecords.Count.Should().Be(NUM_OF_ROWS);

            PersonRecords[0].first_name.Should().Be(ExpectedPersonRecords[0]);
            PersonRecords[0].last_name.Should().Be(ExpectedPersonRecords[1]);
            PersonRecords[0].company_name.Should().Be(ExpectedPersonRecords[2]);
            PersonRecords[0].address.Should().Be(ExpectedPersonRecords[3]);
            PersonRecords[0].city.Should().Be(ExpectedPersonRecords[4]);
            PersonRecords[0].county.Should().Be(ExpectedPersonRecords[5]);
            PersonRecords[0].postal.Should().Be(ExpectedPersonRecords[6]);
            PersonRecords[0].phone1.Should().Be(ExpectedPersonRecords[7]);
            PersonRecords[0].phone2.Should().Be(ExpectedPersonRecords[8]);
            PersonRecords[0].email.Should().Be(ExpectedPersonRecords[9]);
            PersonRecords[0].web.Should().Be(ExpectedPersonRecords[10]);
        }

        [Test]
        public void TestReturnsCorrectPersonRecordsFromQuery1()
        {
            // Test for correct number and contents of PersonRecords on retrieval of data from query 1 
            // Number of persons with Esq in company name ...

            const int NUM_OF_ROWS = 1;
  
            using (var reader = new StreamReader(filePathString!))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonRecords = csv.GetRecords<PersonRecord>().ToList();
            }

            // Now, get returned data from query 1 ...

            var resultarraylist = CollectionOfQueries.ProcessQuery(PersonRecords, 1); //Send file and id of query

            resultarraylist.Should().NotBeNull();
            resultarraylist.Count.Should().Be(NUM_OF_ROWS);
            resultarraylist.Should().BeOfType<ArrayList>();

            for (int i = 0; i < resultarraylist.Count; i++)
                Console.WriteLine($"{resultarraylist[i]} ");
        }

        [Test]
        public void TestReturnsCorrectPersonRecordsFromQuery2()
        {

            // Test for correct number and contents of PersonRecords on retrieval of data from query 2 
            // Number of persons resident in Derbyshire ...

            const int NUM_OF_ROWS = 1;

            using (var reader = new StreamReader(filePathString!))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonRecords = csv.GetRecords<PersonRecord>().ToList();
            }

           
            // Now, get returned data from query 2 ...

            var resultarraylist = CollectionOfQueries.ProcessQuery(PersonRecords, 2); //Send file and id of query

            resultarraylist.Should().NotBeNull();
            resultarraylist.Count.Should().Be(NUM_OF_ROWS);
            resultarraylist.Should().BeOfType<ArrayList>();

            for (int i = 0; i < resultarraylist.Count; i++)
                Console.WriteLine($"{resultarraylist[i]} ");
        }

        [Test]
        public void TestReturnsCorrectPersonRecordsFromQuery3()
        {
            // Not implemented
            // Test for correct number and contents of PersonRecords on retrieval of data from query 3 
            // Every person whose house number is exactly three digits.

            const int NUM_OF_ROWS = 0;

            using (var reader = new StreamReader(filePathString!))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonRecords = csv.GetRecords<PersonRecord>().ToList();
            }


            // Now, get returned data from query 2 ...

            var resultarraylist = CollectionOfQueries.ProcessQuery(PersonRecords, 3); //Send file and id of query

            resultarraylist.Should().NotBeNull();
            resultarraylist.Count.Should().Be(NUM_OF_ROWS);
            resultarraylist.Should().BeOfType<ArrayList>();

            for (int i = 0; i < resultarraylist.Count; i++)
                Console.WriteLine($"{resultarraylist[i]} ");
        }

        [Test]
        public void TestReturnsCorrectPersonRecordsFromQuery4()
        {

            // Test for correct number and contents of PersonRecords on retrieval of data from query 4 
            // Every person whose website URL is longer than 35 characters ...

            const int NUM_OF_ROWS = 1;

            using (var reader = new StreamReader(filePathString!))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonRecords = csv.GetRecords<PersonRecord>().ToList();
            }


            // Now, get returned data from query 4 ...

            var resultarraylist = CollectionOfQueries.ProcessQuery(PersonRecords, 4); //Send file and id of query

            resultarraylist.Should().NotBeNull();
            resultarraylist.Count.Should().Be(NUM_OF_ROWS);
            resultarraylist.Should().BeOfType<ArrayList>();

            for (int i = 0; i < resultarraylist.Count; i++)
                Console.WriteLine($"{resultarraylist[i]} ");
        }

        [Test]
        public void TestReturnsCorrectPersonRecordsFromQuery5()
        {
            // Not implemented
            // Test for correct number and contents of PersonRecords on retrieval of data from query 5 
            // Every person whose postocde has single digit ...

            const int NUM_OF_ROWS = 0;

            using (var reader = new StreamReader(filePathString!))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonRecords = csv.GetRecords<PersonRecord>().ToList();
            }


            // Now, get returned data from query 4 ...

            var resultarraylist = CollectionOfQueries.ProcessQuery(PersonRecords, 5); //Send file and id of query

            resultarraylist.Should().NotBeNull();
            resultarraylist.Count.Should().Be(NUM_OF_ROWS);
            resultarraylist.Should().BeOfType<ArrayList>();

            for (int i = 0; i < resultarraylist.Count; i++)
                Console.WriteLine($"{resultarraylist[i]} ");
        }

        [Test]
        public void TestReturnsCorrectPersonRecordsFromQuery6()
        {
            // Test for correct number and contents of PersonRecords on retrieval of data from query 6 
            // Every person whose first phone number is numerically larger than their second phone number ...

            const int NUM_OF_ROWS = 1;

            using (var reader = new StreamReader(filePathString!))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonRecords = csv.GetRecords<PersonRecord>().ToList();
            }

            // Now, get returned data from query 6 ...

            var resultarraylist = CollectionOfQueries.ProcessQuery(PersonRecords, 6); //Send file and id of query

            resultarraylist.Should().NotBeNull();
            resultarraylist.Count.Should().Be(NUM_OF_ROWS);
            resultarraylist.Should().BeOfType<ArrayList>();

            for (int i = 0; i < resultarraylist.Count; i++)
                Console.WriteLine($"{resultarraylist[i]} ");
        }
    }
}