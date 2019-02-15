using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;
using Ninject;
using System.Configuration;

namespace FileManager
{
    public class Operation: IOperation
    {
        public string Invoker(string action, string filePath)
        {
            FileDetails file = new FileDetails();
            switch (action.ToLower())
            {
                case "-v": return GetFileVersion(filePath);
                case "--v": return GetFileVersion(filePath);
                case "/v": return GetFileVersion(filePath);
                case "-s": return GetFileSize(filePath).ToString();
                case "--s": return GetFileSize(filePath).ToString();
                case "/s": return GetFileSize(filePath).ToString();
                default: throw new ArgumentException("Invalid command");
            }
        }

        public int GetCommands
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfCommands"].ToString());
            }
        }

        private string GetFileVersion(string filePath)
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<FileDetails>().To<FileDetails>();
                var file = kernel.Get<FileDetails>();
                string version = file.Version(filePath);
                return version;
            }
        }

        private int GetFileSize(string filePath)
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.Bind<FileDetails>().To<FileDetails>();
                var file = kernel.Get<FileDetails>();
                int size = file.Size(filePath);
                return size;
            }
        }
    }
}
