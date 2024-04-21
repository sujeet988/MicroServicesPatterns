namespace SolutionFileSystemWithCompositeDesign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solution of file system using Composite design");
            Directory movieDirectory = new Directory("Movie");

            IFileSystem border = new File("Border");
            movieDirectory.Add(border);

            Directory comedyMovieDirectory = new Directory("ComedyMovie");
            File hulchul = new File("Hulchul");
            comedyMovieDirectory.Add(hulchul);
            movieDirectory.Add(comedyMovieDirectory);
            movieDirectory.ls();

            /* Output
             * Directory name Movie
               File name Border
               Directory name ComedyMovie
               File name Hulchul
             */
        }
    }
}