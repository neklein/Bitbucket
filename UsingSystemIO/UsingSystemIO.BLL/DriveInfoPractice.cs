using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingSystemIO.BLL
{
    public class DriveInfoPractice
    {
        DriveInfo oneDrive = new DriveInfo("C");
        DriveInfo[] allDrives = DriveInfo.GetDrives();

        public void LoopingThroughDrives()
        {
            foreach (var drive in allDrives)
            {
                //[1] print sizes
                Console.WriteLine(drive.AvailableFreeSpace);
                Console.WriteLine(drive.TotalFreeSpace);
                Console.WriteLine(drive.TotalSize);
                Console.WriteLine();

                // [2] Format and type
                Console.WriteLine(drive.DriveFormat);
                Console.WriteLine(drive.DriveType);
                Console.WriteLine();

                // [3]
                Console.WriteLine(drive.Name);
                Console.WriteLine(drive.RootDirectory);
                Console.WriteLine(drive.VolumeLabel);
                Console.WriteLine();

                Console.WriteLine(drive.IsReady);
            }
        }
    }   
}
