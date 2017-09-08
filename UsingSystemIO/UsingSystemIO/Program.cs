using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingSystemIO.BLL;

namespace UsingSystemIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataDelimittingPractice Start = new DataDelimittingPractice();
            //Start.ReadingData();

            DriveInfoPractice StartDrive = new DriveInfoPractice();
            StartDrive.LoopingThroughDrives();
        }
    }
}
