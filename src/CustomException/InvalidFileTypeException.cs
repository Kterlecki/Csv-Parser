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
    }
}
