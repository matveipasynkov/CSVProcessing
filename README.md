# CSVProcessing
This is my second project, which was assigned as homework in university. The console application is stored in KDZ_Program, the class library in LibraryOfProcessing

## Main Assignment
Develop a solution containing a console application project and a class library,
including static classes for working with CSV file data.

## Console application 
#### 1. Request from the user the absolute path to the file with csv data (station-rate.csv). To retrieve data from the file, use the Read method of the CsvProcessing class from the class library.

#### 2. After retrieving data from the file, provide the user with an on-screen menu whose items are responsible for manipulating the file and its data:
	a. sampling by values of NameOfStation, Line, NameOfStation and Month fields. To organize the sampling use methods of the DataProcessing class from the class library. Specific values of fields for organizing the sampling get from the user. The result should be displayed on the screen in a tabular, readable form. If the result is empty, notify the user.
	b. sorting by field values: Year in ascending order, NameOfStation in alphabetical order. To organize sorting use methods of DataProcessing class from the class library. The sorting result should be displayed on the screen in tabular, readable form.
	c. save the results of selections and sorting in a csv-file using overloaded Write methods of CsvProcessing class (the rules of working with the file contents are specified in the “Class Library” section). It is required to use both overloads: for writing a single line - one, for writing an array of lines - the second. The file structure, i.e. the set of fields, should be identical to the original one, including headers. The console application being developed must load data from any file created by it without errors. The name of the file and the need to save the data should be requested from the user after displaying the data on the screen. Save the file next to the console application executable. If the user specifies an incorrect file name, notify the user and prompt for re-entry.
  
#### 3. Realize handling of all exceptional situations that may occur when working with called methods, including methods of the library being developed within the project.
## Class Library
#### 1. CsvProcessing class: contains methods for reading and writing data to csv file. To store the path to the file in the class use a static field fPath, the data of this field is accessed by all methods:
	• The "Read" method returns an array of strings (string[]) of the file accessed by fPath. If the file is missing or its structure does not match the variant, the method throws an exception with the ArgumentNullException type.
	• The "Write" method is responsible for writing data to a file and has two overloads:
		- Method with parameters: string (string) and new file path "nPath". The method adds (without erasing the data already written to the file) to the end of the file the data from the parameter string after the last line, if the file by nPath is already present on disk. If the file is not present, it must be created at the specified path. The method does not create files whose path is specified incorrectly, so you need to implement a variant of program notification for the calling code yourself.
		- The method with the string array parameter (string[]) writes new data passed in the string array parameter into the file already existing on the fPath path, erasing its original contents. If there is no file at path fPath, it must be created at the specified path. The method does not create files whose path is specified incorrectly, so you need to implement a variant of program notification for the calling code yourself.
#### 2. The DataProcessing class contains methods for working with data obtained from a file: methods for obtaining samples and methods for sorting by field data. Methods of ordering and columns for filtering:
	Filtering: NameOfStation, Line, NameOfStation and Month (two columns at the same time).
	Sorting: Year in ascending order, NameOfStation alphabetically.
## Compatibility and quality requirements for the main task
	1) all program code must be written in the C# programming language, taking into account the use of .net 6.0;
	2) the source code must contain comments explaining non-obvious fragments and solutions, code summary, description of code goals (see materials of lecture 1, module 1);
	3) identifiers used in the program must conform to the rules and conventions of C# identifier naming (https://learn.microsoft.com/ruru/dotnet/csharp/fundamentals/coding-style/identifier-names);
	4) the code submitted for testing must conform to Microsoft's general C# code conventions (https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/coding-style/codingconventions); 
	5) when the library project folder is moved (copied / transferred to another device), the files must be opened by the program as successfully as on the creator's computer, i.e. on a relative path;
 	6) text data, including data in Russian, are successfully decoded when presented to the user and are human-readable;
	7) the program does not allow the user to solve tasks until correct data are entered from the keyboard;
	8) the console application handles exceptional situations related to (1) input and conversion / conversion of data both from the keyboard and from files; (2) creation, initialization, access to array and string elements; (3) calling library methods.
	9) the class library submitted for testing must solve all the tasks and compile successfully.
	10) only arrays (type derived from Array) should be used as data structures.
	11) it is forbidden to use third-party libraries and nuget packages to work with csv-files, the code must be prepared independently.
	12) the console application must handle emergency situations and contain a loop to repeat the solution.
	13) each library method can be used separately from the console application code, for example, when inserting it into another project and accessing the library methods from it using the reference to the library and the method signature specified in the task.
## Additional comments
  There are gaps and empty fields in the data. You don't need to display such data, but you need to take them into account if they occur during sorting or filtering. For example, they should be placed at the beginning or end of the list when sorting.
