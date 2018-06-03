using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHandler
{
    class FileHandlerTxt
    {
        private FileStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private string txtFilePath;

        /// <summary>
        /// Initialises a object of the FileHandler to write and read the data.
        /// </summary>
        /// <param name="txtFilePathParam">File path of the file</param>

        public FileHandlerTxt(string txtFilePathParam = "ErrorLog.txt")
        {
            this.txtFilePath = txtFilePathParam;
        }

        void CreateFileIfNotExists(string FileName)
        {
            try
            {
                stream = new FileStream(FileName, FileMode.Create);
            }
            catch (IOException)
            {
                appendDataToTextFile(new List<string> { string.Format("Cannot create {0}", FileName) });
            }
            finally
            {
                stream.Close();
            }


        }

        public void appendDataToTextFile(List<string> DataToAppend)
        {
            try
            {
                if (File.Exists(this.txtFilePath) == false)
                {
                    CreateFileIfNotExists(this.txtFilePath);
                }
                stream = new FileStream(this.txtFilePath, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(stream);

                foreach (string item in DataToAppend)
                {
                    writer.WriteLine(item);
                    writer.Flush();
                }
            }
            catch (FileNotFoundException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("The magical information capsule {0} could not be found, {1}", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (DirectoryNotFoundException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("The directory of magical information capsule {0} could not be found, {1}", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (IOException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("A magic disruption occured: {0} ({1})", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
        }
        
        public List<string> getRawDataFromTextFile()
        {
            List<string> rawData = new List<string>();

            try
            {
                stream = new FileStream(this.txtFilePath, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    rawData.Add(reader.ReadLine());
                }
            }
            catch (FileNotFoundException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("The magical information capsule {0} could not be found, {1}", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (DirectoryNotFoundException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("The directory of magical information capsule {0} could not be found, {1}", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (IOException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("A magic disruption occured: {0} ({1})", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            finally
            {
                reader.Close();
                stream.Close();
            }

            return rawData;
        }

        public void readDataToTextFile(List<string> RawDataToWrite)
        {
            try
            {
                stream = new FileStream(this.txtFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(stream);

                foreach (string item in RawDataToWrite)
                {
                    writer.WriteLine(item);
                    writer.Flush();
                }
            }
            catch (FileNotFoundException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("The magical information capsule {0} could not be found, {1}", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (DirectoryNotFoundException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("The directory of magical information capsule {0} could not be found, {1}", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (IOException)
            {
                FileHandlerTxt handleError = new FileHandlerTxt();
                handleError.appendDataToTextFile(new List<string>() { string.Format("A magic disruption occured: {0} ({1})", this.txtFilePath, DateTime.UtcNow.ToShortDateString()) });
            }
            finally
            {
                reader.Close();
                writer.Close();
            }
        }
    }
}
