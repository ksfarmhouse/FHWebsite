using System;
using System.IO;
using FHWebsite;

namespace AddUsers
{
    /// <summary>
    /// This is an app that will add users to the SQL database by reading names from a CSV file. 
    /// Note that there is a wrapper class called SqlTools in the FHWebsite namespace designed to run SQL commands.
    /// Also, use the connection string from FHWebsite to connect to the SQL database.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            string[] lines;
            if (args.Length == 0)
            {
                Console.Write("Enter the path of a CSV file: ");
                path = Console.ReadLine();
            }
            else
            {
                path = args[0];
            }

            Console.WriteLine("Reading file . . .");
            try
            {
                lines = File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                return;
            }
            
            foreach(string line in lines)
            {
                
            }

        }
    }
}