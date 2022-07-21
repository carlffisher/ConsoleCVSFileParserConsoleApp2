A program that parses a CSV file, and performs LINQ queries on the result.
Query results are output on the console.

Using package CSVHelper, each line of the CSV file is read into an instance of the class PersonRecord.

Property fields of PersonRecord reflect the CSV header fields names. Each field of a CSV record is assigned to a string.
Once all CSV data has been read, cleaned by CSVHelper and assigned to PersonRecord, the whole is returned as a List for Console display.

Users choose which LINQ query to execute at Console.
On doing so, a list of person records is  sent along with a query id to method CollectionOfQueries.ProcessQuery.
This executes a LINQ query on the person records and returns the result as an ArrayList.

The array contents are output to Console.



