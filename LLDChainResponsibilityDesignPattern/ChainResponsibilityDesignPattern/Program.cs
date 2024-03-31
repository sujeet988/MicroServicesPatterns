namespace ChainResponsibilityDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LogProcessor logObject=new InfoLogProcessor(new DebugLogProcessor( new ErrorLogProcessor(null)));
            logObject.Log(LogProcessor.ERROR, "exception happens");
            logObject.Log(LogProcessor.DEBUG, "need to debug this ");
            logObject.Log(LogProcessor.INFO, "just for info ");
            Console.ReadLine();
        }
    }
}