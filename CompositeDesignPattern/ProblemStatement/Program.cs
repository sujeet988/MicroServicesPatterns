namespace ProblemStatement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Problem Statement of composite design pattern ");
            Directory movieDirectory = new Directory("Movie");

            File border = new File("Border");
            movieDirectory.add(border);

            Directory comedyMovieDirectory = new Directory("ComedyMovie");
            File hulchul = new File("Hulchul");
            comedyMovieDirectory.add(hulchul);
            movieDirectory.add(comedyMovieDirectory);
            movieDirectory.ls();
        }
    }
}