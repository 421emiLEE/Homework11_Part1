using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework11_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var boyNames = ReadNamesFromFile("boynames.txt");
            var girlNames = ReadNamesFromFile("girlnames.txt");

            Console.WriteLine("Enter a name to search:");
            string inputName = Console.ReadLine();

            if (boyNames.TryGetValue(inputName, out nameInformation boyinfo) && boyinfo.Rank <=1000)
            {
                var info = boyNames[inputName ];
                Console.WriteLine($"{inputName} is ranked {info.Rank} in popularity among boys with {info.Count} namings.");
            }
            else
            {
                Console.WriteLine($"{inputName} is not ranked among the top 1000 boy names.");
            }

            if (girlNames.TryGetValue(inputName, out nameInformation girlinfo) && girlinfo.Rank <= 1000)
            {
                var info = girlNames[inputName];
                Console.WriteLine($"{inputName} is ranked {info.Rank} in popularity among girls with {info.Count} namings.");
            }
            else
            {
                Console.WriteLine($"{inputName} is not ranked among the top 1000 girl names.");
            }



        } // outside of Main
        static Dictionary<string, nameInformation> ReadNamesFromFile(string fileName)
        {
            var names = new Dictionary<string, nameInformation>();
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    int rank = 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var parts = line.Split(' ');
                        if (parts.Length == 2)
                        {
                            string name = parts[0];
                            int count = int.Parse(parts[1]);
                            names[name] = new nameInformation { Rank = rank, Count = count };
                            rank++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The file {fileName} could not be read:");
                Console.WriteLine(e.Message);
            }
            return names;
        }

        class nameInformation
        {
            public int rank;
            public int count;

            //getter and setter for rank and count
            public int Rank
            {
                get { return rank; }
                set { rank = value; }
            }
            public int Count
            {
                get { return count; }
                set { count = value; }
            }



        }
    } // outside of Program
}

