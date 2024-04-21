using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionFileSystemWithCompositeDesign
{
    /*
     * this class is also called leaf operation as there no further child
     */
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
