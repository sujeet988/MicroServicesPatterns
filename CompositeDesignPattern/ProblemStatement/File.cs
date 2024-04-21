using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatement
{
    public class File
    {
       public String fileName;

        public File(String name)
        {
            this.fileName = name;
        }

        public void ls()
        {
           Console.WriteLine ("file name " + fileName);
        }
    }
}
