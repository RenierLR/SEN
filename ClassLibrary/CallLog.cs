using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CallLog
    {

        private static CallLog instance = new CallLog();

        public static CallLog getInstance()
        {
            return instance;
        }

        CallLog()
        {

        }

        public void CallLogWrite(List<string> Memo)
        {
            DataHandler.FileHandlerTxt FHandler = new DataHandler.FileHandlerTxt(string.Format("{0}.txt", DateTime.UtcNow.ToString("d-MMMM-yyyy_hh-mm-ss")));
            FHandler.appendDataToTextFile(Memo);
        }

    }
}
