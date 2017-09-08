using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingSystemIO
{
    public class ProgramFlow
    {
        string path = @".\List.txt";
        string lineOfText;

        public void FileCreator()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

        }

        public void FileWriter()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Fantastic");
                writer.WriteLine("Craziness");
                writer.WriteLine("Green");
                writer.WriteLine("Yellow");
            }
        }

        public void FileReader()
        {
            using(StreamReader reader = new StreamReader(path))
            {
                while((lineOfText = reader.ReadLine()) != null)
                {
                    Console.WriteLine(lineOfText);
                }
            }
        }

    }
}
