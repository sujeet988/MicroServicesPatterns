using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemStatement
{
    public class Directory
    {
      public  String directoryName;
        List<Object> objectList;

        public Directory(String name)
        {
            this.directoryName = name;
            objectList = new List<object>();
        }

        public void add(Object obj)
        {
            objectList.Add(obj);
        }

        public void ls()
        {
            Console.WriteLine("Directory Name: " + directoryName);
            foreach (Object obj in objectList)
            {

                if (obj is File)
                {
                    ((File)obj).ls();
                }
                else if (obj is Directory)
                {
                    ((Directory)obj).ls();
                }
            }
    }
}
}
