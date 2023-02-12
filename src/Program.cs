
using Csv_Parser;



var path = @".\TestFile.csv";

var csvDataParser = new CsvParser(path);

csvDataParser.ExtractDataFromFiles();
csvDataParser.PrintList();



