using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionFileSystemWithCompositeDesign
{
    /*
     * this class is also called composite object because it perfrom opeation and Added

     */
    public class Directory : IFileSystem
    {
        string directoryName= string.Empty;
        List<IFileSystem> fileSystemList;
        public Directory(string name)
        {
            this.directoryName = name;
            fileSystemList = new List<IFileSystem>();
        }
        public void Add(IFileSystem fileSystemObj)
        {
            fileSystemList.Add(fileSystemObj);
        }
         
        public void ls()
        {
            Console.WriteLine("Directory name " + directoryName);

            foreach (IFileSystem fileSystemObj in fileSystemList)
            {
                fileSystemObj.ls();
            }
        }
    }
}
