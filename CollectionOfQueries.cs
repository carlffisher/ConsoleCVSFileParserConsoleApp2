using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.Generic;

namespace ConsoleCSVFileParserConsoleApp2
{    
    public class CollectionOfQueries
    {
        public static ArrayList ProcessQuery(List<PersonRecord> personRecords, int query_id)
        {
            // a collection of specific queries ...

            switch (query_id)
            {
                case 1: // "Esq" in company_name
                
                var result1 = from s in personRecords
                              where s.company_name!.Contains("Esq") 
                              group s by s.company_name into sg
                              from record_group in sg
                              orderby record_group.first_name, record_group.last_name, record_group.company_name
                              select new
                              {
                                  TotalEsqInCoName = personRecords!.Count(s => s.company_name!.Contains("Esq")),
                                  PersonsPositionInList = personRecords!.FindIndex(c => c.first_name == record_group.first_name),
                                  record_group.first_name,
                                  record_group.last_name,
                                  CompanyName = record_group.company_name
                              };

                ArrayList arlist1 = new(result1.ToList());

                return arlist1;
                

                case 2: // "Derbyshire" in county
                    
                    var result2 = from s in personRecords
                                  where s.county!.Contains("Derbyshire")
                                  group s by s.county into sg
                                  from record_group in sg
                                  orderby record_group.first_name, record_group.last_name, record_group.company_name
                                  select new
                                  {
                                      CountOfPersonsResidentIncounty = personRecords!.Count(s => s.county!.Contains("Derbyshire")),
                                      PersonsPositionInList = personRecords!.FindIndex(c => c.first_name == record_group.first_name),
                                      record_group.first_name,
                                      record_group.last_name,
                                      CompanyName = record_group.company_name
                                  };


                    ArrayList arlist2 = new(result2.ToList());

                    return arlist2;


                case 3: // Find 3 Digit Address Number

                    // Unimplemented
                     
                    ArrayList arlist3 = new();

                    return arlist3;

                case 4: // URL >  35 characters

                    var result4 = from s in personRecords
                                  where s.web!.Length > 35
                                  group s by s.first_name into sg
                                  from record_group in sg
                                  orderby record_group.first_name, record_group.last_name, record_group.company_name
                                  select new
                                  {
                                      CountOfPersonsWithEmailAddOver35Chars = personRecords!.Count(s => s.web!.Length > 35),
                                      PersonsPositionInList = personRecords!.FindIndex(c => c.first_name == record_group.first_name),
                                      record_group.first_name,
                                      record_group.last_name,
                                      CompanyName = record_group.company_name
                                  };

                    ArrayList arlist4 = new(result4.ToList());
                    return arlist4;

                case 5: // Start of postcode has 1 digit

                    // Unimplemented

                    ArrayList arlist5 = new();

                    return arlist5;

                case 6: // Phone number 1 is > Phone number 2 

                    var result6 = from s in personRecords
                                  where s.phone1!.CompareTo(s.phone2) >= 0
                                  group s by s.first_name into sg
                                  from record_group in sg
                                  orderby record_group.first_name, record_group.last_name, record_group.company_name
                                  select new
                                  {
                                      CountOfPersonsWithPhone1GreaterThanPhone2 = personRecords!.Count(s => s.phone1!.CompareTo(s.phone2) >= 0),
                                      PersonsPositionInList = personRecords!.FindIndex(c => c.first_name == record_group.first_name),
                                      record_group.first_name,
                                      record_group.last_name,
                                      CompanyName = record_group.company_name
                                  };

                    ArrayList arlist6 = new(result6.ToList());

                    return arlist6;


                default:
                    Console.WriteLine("Error: Unknown query_id: {0} ", query_id);
                    return null!;
            }
        }
    } 
}
