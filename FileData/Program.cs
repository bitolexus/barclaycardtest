using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;
using FileManager;
using System.Configuration;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string action;
            string filePath;
            IOperation operation = (IOperation)new Operation();
            try
            {
                if (args.Length == operation.GetCommands)
                {
                    action = args[0];
                    filePath = args[1];
                    var result = operation.Invoker(action, filePath);
                    Console.WriteLine("Output: {0}", result);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
