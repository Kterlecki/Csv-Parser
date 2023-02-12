using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csv_Parser.CustomException
{
    public class InvalidFileTypeException : Exception
    {
        private const string DefaultMessage = "File must be CSV format";

        public InvalidFileTypeException()
            : base(DefaultMessage) { }
        public InvalidFileTypeException(string fileName)
            : base($"{DefaultMessage}, File Given : {fileName}") { }
        public InvalidFileTypeException(string errorMessage ,Exception ex)
            : base($"{errorMessage} : {ex}") { }
    }
}
