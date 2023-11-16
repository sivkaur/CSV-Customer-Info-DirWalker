using System.Diagnostics;

public class GlobalVariables
{
    public static int validRowsCount = 0;
    public static int skippedRowsCount = 0;
    public static bool addHeaders = true;
    public static string logFilePath = "C:\\Users\\sivle\\Desktop\\5510_SWE\\assignment\\logs\\logFile.txt";
    public static string inputDataPath = "C:\\Users\\sivle\\Desktop\\5510_SWE\\assignment\\SampleData";
    public static string resultFilePath = "C:\\Users\\sivle\\Desktop\\5510_SWE\\assignment\\Output\\output.csv";
}

namespace ProgAssign1
{
    class Program{
        static void Main(string[] args){

            Stopwatch timer = new Stopwatch();
            timer.Start();

            using (StreamWriter logFileWriter = new StreamWriter(GlobalVariables.logFilePath, true)){
                
                Console.SetOut(logFileWriter);
                Console.WriteLine("INFO: Process execution started");
                
                //Changing the directory to directory having input data 
                Directory.SetCurrentDirectory(GlobalVariables.inputDataPath);
                string currentDirectory = Directory.GetCurrentDirectory();
                

                //Traversing directories to get all (csv) files
                DirWalker.TraverseDirectoryStructure(currentDirectory);

                timer.Stop();

                TimeSpan executionTime = timer.Elapsed;
                Console.WriteLine($"INFO: execution time: {executionTime}");
                Console.WriteLine($"INFO: Total number of rows processed: {GlobalVariables.validRowsCount}");
                Console.WriteLine($"INFO: Total number of rows skipped: {GlobalVariables.skippedRowsCount}");
                Console.WriteLine("INFO: Process execution finished");
                Console.WriteLine("INFO: Process execution ended");
            }
            
        }
        
    }
}