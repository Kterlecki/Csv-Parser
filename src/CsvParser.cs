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

        private readonly string _filePath;
        private readonly List<FileData> fileDataList = new List<FileData>();

        public CsvParser(string path)
        {
            _filePath = path;
        }

        public bool IsFileCsv(string file)
        {
            string extention = Path.GetExtension(_filePath);
            if (extention.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect file type entered - {0}", extention);
                return false;
            }

        }

        public List<FileData> ExtractDataFromFiles()
        {
            if (!IsFileCsv(_filePath))
            {
                throw new InvalidFileTypeException(_filePath);
            }
            try
            {
                using (TextFieldParser csvParser = new TextFieldParser(_filePath))
                {
                    csvParser.SetDelimiters(new string[] { "," });

                    csvParser.ReadLine();
                    while (!csvParser.EndOfData)
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

                    return fileDataList;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidFileTypeException("Error occured while parsing the file", ex);
            }
        }

        public void PrintList()
        {
            foreach (var file in fileDataList)
            {
                Console.WriteLine(file.Name);
                Console.WriteLine(file.Description);
                Console.WriteLine(file.Quantity);
            }
        }
    }


}

