using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ErrorLog
    {

        private static ErrorLog instance = new ErrorLog();

        public static ErrorLog getInstance()
        {
            return instance;
        }

        ErrorLog()
        {

        }

        public void ErrorLogWrite(List<string> Error)
        {
            DataHandler.FileHandlerTxt FHandler = new DataHandler.FileHandlerTxt();
            FHandler.appendDataToTextFile(Error);
        }
    }
}
