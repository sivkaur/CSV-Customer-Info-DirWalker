using System;
using System.Diagnostics;
using System.IO;
using CsvHelper;

namespace ProgAssign1{
    public class DirWalker{
        public static void TraverseDirectoryStructure(string parentDirectoryPath){
            
            //Fetching all subdirectores 
            string[] subDirectoriesList = Directory.GetDirectories(parentDirectoryPath);
            if(subDirectoriesList == null ) return;
            foreach (string subDirectoryPath in subDirectoriesList)
            {
                if (Directory.Exists(subDirectoryPath))
                {
                    Console.WriteLine($"INFO: Inside {subDirectoryPath} directory");
                    //Calling the function recursively to fetch all subdirectories 
                    TraverseDirectoryStructure(subDirectoryPath);
                }
            }
        
            Console.WriteLine($"INFO: Processing files in {parentDirectoryPath} directory");
            string[] filesList = Directory.GetFiles(parentDirectoryPath);
            
            foreach (string file in filesList){
                string fileExtension = Path.GetExtension(file);
                if (fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    //Parsing the file if it's extension in .csv
                    Console.WriteLine("");
                    Console.WriteLine($"INFO: Processing started for {file} file");
                    ParseCSV.ProcessCSVFile(file);
                }
            }
            
        }

    }
}