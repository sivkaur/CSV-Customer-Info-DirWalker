# CSV-Customer-Info-DirWalker

## Overview
CSV-Customer-Info-DirWalker is a C# program designed to efficiently traverse a directory structure containing CSV files with customer information. The program utilizes the DirWalker.cs file to navigate through the dataset, implementing robust logging, error handling, and data processing functionalities.

## Features
### Logging System:
The program incorporates a logging system to capture both informational messages and all possible checked exceptions. This ensures comprehensive tracking and debugging capabilities.

### Handling Incomplete Records:
Incomplete records within the CSV files are identified and skipped during processing. Each skipped row is logged, providing a record of ignored data.

### Execution Summary Logging:
Upon completion of the traversal, the program logs key summary information, including the total execution time, total number of valid rows, and total number of skipped rows.

### Additional Data Column:
A date column in the format yyyy/mm/dd is added to the defined data structure within the directory. This enhances the dataset with additional temporal information.

### Result File:
The program generates a result file containing the output, which is submitted to the "Output" directory within the GitHub repository.

### Program Features

- **Program.cs**: This program calls the respective programs to read and write CSV data and keeps track of the execution time.
- **ParseCSV.cs**: This program reads data from a CSV file and writes it back to an output.csv after validating the data
- **DirWalker.cs**: This program recursively traverses the specified directory structure and fetches the respective '.csv' files.

### Notes
- Change the inputDataPath variable in Program.cs to your local directory for sample data
- Change the logFilePath variable in Program.cs to your local directory for log file
- Change the resultFilePath variable in Program.cs to your local directory for output file 
- This program was coded in a Windows. [For running it in MacBook, please replace the double back slash '\\' with forward '/' in the ExtractDate function in the ParseCSV.cs file."]
