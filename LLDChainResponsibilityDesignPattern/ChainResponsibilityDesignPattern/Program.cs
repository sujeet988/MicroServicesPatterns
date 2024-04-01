namespace ChainResponsibilityDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var infoLogProcessor = new InfoLogProcessor();
            var DebugLogProcessor = new DebugLogProcessor();
            var ErrorLogProcessor = new ErrorLogProcessor();

            infoLogProcessor.NextHandler= DebugLogProcessor;
            DebugLogProcessor.NextHandler= ErrorLogProcessor;

            infoLogProcessor.Log(LogProcessor.ERROR, "exception happens");
            infoLogProcessor.Log(LogProcessor.DEBUG, "need to debug this ");
            infoLogProcessor.Log(LogProcessor.INFO, "just for info ");
            Console.ReadLine();
        }
    }
}