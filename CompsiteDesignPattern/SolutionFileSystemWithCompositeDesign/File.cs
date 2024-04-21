using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionFileSystemWithCompositeDesign
{
    public class File : IFileSystem
    {
        public string fileName { get; set; }
        public File(string fileName)
        {
            this.fileName = fileName;
        }

        public void ls()
        {
           Console.WriteLine("File name "+this.fileName);
        }
    }
}
