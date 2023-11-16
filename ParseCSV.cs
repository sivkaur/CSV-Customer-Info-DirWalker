using System;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Diagnostics;

namespace ProgAssign1
{
    public class ParseCSV{
        public static void ProcessCSVFile(string inputCsvFile){
            try
            {
                using (var fileReader = new StreamReader(inputCsvFile))
                using (var csvParser = new CsvReader(fileReader, new CsvConfiguration(CultureInfo.InvariantCulture){
                    MissingFieldFound = null
                }))
                
                using (var dataWriter = new StreamWriter(GlobalVariables.resultFilePath, true))
                using (var csvWriter = new CsvWriter(dataWriter, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    if(GlobalVariables.addHeaders){
                        
                        // Add header to the csv file
                        Console.WriteLine($"INFO: Adding headers in the output.csv file");
                        csvWriter.WriteRecord(new { FirstName = "First Name", LastName = "Last Name", StreetNumber = "Street Number", Street = "Street", City = "City", Province = "Province", PostalCode = "Postal Code", Country = "Country", PhoneNumber = "Phone Number", EmailAddress = "email Address", Date = "Date" });
                        csvWriter.NextRecord();
                        GlobalVariables.addHeaders = false;
                    }

                    var customerRecords = csvParser.GetRecords<Customer>(); 
                    foreach (var customer in customerRecords){
                        if(Validate(customer)){

                            // add customer record to csv file
                            Console.WriteLine($"INFO: Adding valid record in output.csv");
                            csvWriter.WriteRecord(customer);
                            csvWriter.WriteField(ExtractDate(inputCsvFile));
                            csvWriter.NextRecord();
    
                            GlobalVariables.validRowsCount++;

                        }
                        else{
                            GlobalVariables.skippedRowsCount++;
                        }
                    }
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The file or directory cannot be found: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("The file or directory cannot be found: "+ ex.Message);
            }
            catch (DriveNotFoundException ex)
            {
                Console.WriteLine("The drive specified in 'path' is invalid: " + ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("You do not have permission to create this file: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown expection occured: " + ex.Message);
            }
            
        }

        private static string ExtractDate(string inputCsvFile){
            string[] pathDetails = inputCsvFile.Split("\\");
            string date = "";
            
            if(pathDetails.Length > 2){
                string day, month, year;
                year = pathDetails[pathDetails.Length - 4];
                month = pathDetails[pathDetails.Length - 3];
                day = pathDetails[pathDetails.Length - 2];
                
                date = year+"/"+month+"/"+day;

                if (!Regex.IsMatch(date, @"^\d+\/\d+\/\d+$")){
                    date = "";
                 }
            }
            return date;
        }
        private static bool Validate(Customer record){
            //check if the record is valid or not [should not have a null or empty value]
            if(string.IsNullOrEmpty(record.FirstName) || string.IsNullOrEmpty(record.LastName) || string.IsNullOrEmpty(record.StreetNumber) || string.IsNullOrEmpty(record.Street) || string.IsNullOrEmpty(record.City) || string.IsNullOrEmpty(record.Province) || string.IsNullOrEmpty(record.PostalCode) || string.IsNullOrEmpty(record.Country) || string.IsNullOrEmpty(record.PhoneNumber) || string.IsNullOrEmpty(record.EmailAddress)){
                Console.WriteLine($"INFO: Record skipped -> details: FirstName {record.FirstName} | LastName {record.LastName} | PhoneNumber {record.PhoneNumber}");                
                return false;
            }
            return true;
        }
    }
}