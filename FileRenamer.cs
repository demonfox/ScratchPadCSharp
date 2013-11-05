using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ScratchPad
{
    class FileRenamer
    {
        public static void Run(string srcDir, string[] partsToRemove)
        {
            DirectoryInfo dir = new DirectoryInfo(srcDir);
            FileInfo[] files = dir.GetFiles("*");
            Directory.SetCurrentDirectory(srcDir);
            foreach (FileInfo file in files)
            {
                string fileName = file.Name;
                foreach (string part in partsToRemove)
                {
                    fileName = fileName.Replace(part, "");
                }
                File.Move(file.Name, fileName);
            }
        }
    }
}
