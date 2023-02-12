using Csv_Parser.CustomException;
using Csv_Parser.models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv_Parser
{
    public class CsvParser
    {

        private string _filePath;
        private List<FileData> fileDataList = new List<FileData>();

        public CsvParser(string path)
        {
            _filePath = path;
        }

        public static bool IsFileCsv(string file)
        {
            string extention = Path.GetExtension(file);
            return extention.Equals(".csv", StringComparison.OrdinalIgnoreCase);
        }

        public List<FileData> ExtractDataFromFiles()
        {
            try
            {
                IsFileCsv(_filePath);
                using (TextFieldParser csvParser = new TextFieldParser(_filePath))
                {
                    csvParser.SetDelimiters(new string[] {","});

                    csvParser.ReadLine();
                    while(!csvParser.EndOfData)
                    {
                        string[]? fields = csvParser.ReadFields();
                        if (fields is not null)
                        {
                            FileData fileData = new FileData()
                            {
                                Name = fields[0],
                                Description = fields[1],
                                Quantity = fields[2],
                            };
                            fileDataList.Add(fileData);
                        }
                    }
                    foreach (var file in fileDataList)
                    {
                        Console.WriteLine(file.Name);
                        Console.WriteLine(file.Description);
                        Console.WriteLine(file.Quantity);
                    }
                    return fileDataList;
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }


    }
}
