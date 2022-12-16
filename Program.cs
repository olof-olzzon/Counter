using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Counter
{
    class Program
    {
        public static string[] args;
        Program(string[] args)
        {
            Program.args = args;
        }
        private void Run()
        {
            try
            {
                /*
                 * Problem: filnamnet är default Case Insensitive => fel sökargument
                 * 
                 * Case Sensitive kan kopplas in i Windows på en tom katalog: 
                 * > fsutil.exe file setCaseSensitiveInfo "C:\my folder" enable
                 * 
                 */

                if (args.Length == 0)
                {
                    Console.WriteLine("No filename");
                }
                else
                {
                    string name = Path.GetFileNameWithoutExtension(args[0]);
                    string[] lines = File.ReadAllLines(args[0]);
                    int counter = lines.Sum(s => (s.Length - s.Replace(name, "").Length) / name.Length);

                    Console.WriteLine("found " + counter);
                }          
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Program program = new Program(args);
            program.Run();
        }
    }
}