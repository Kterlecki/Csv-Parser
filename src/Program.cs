
using Csv_Parser;



var path = @"D:\Users\terlek\projects\Csv-Parser\src\TestFile.cv";

var csvDataParser = new CsvParser(path);
csvDataParser.ExtractDataFromFiles();

