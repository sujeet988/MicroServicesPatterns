namespace AsyncAwaitTask
{
    internal class Program
    {

        // Thread-blocking, parallel execution
        // Starts both tasks in parallel but blocks the thread using .Result.
        public async Task GetEmployeeDataParallelBlockingAsync()
        {
            Employee emp = new Employee();

            var nameTask = emp.GetEmployeeNameAsync();
            var idTask = emp.GetEmployeeId(101);

            Console.WriteLine($"Employee Name: {nameTask.Result}, Employee ID: {idTask.Result}");
            Console.WriteLine("ended");
        }

        // Thread-blocking, parallel execution
        // Starts both tasks in parallel and blocks the thread using Task.WaitAll.
        public void GetEmployeeDataParallelBlocking()
        {
            Employee emp = new Employee();
            var nameTask = emp.GetEmployeeNameAsync();
            var idTask = emp.GetEmployeeId(101);

            Task.WaitAll(nameTask, idTask);

            Console.WriteLine($"Employee Name: {nameTask.Result}, Employee ID: {idTask.Result}");
        }

        // Not thread-blocking, sequential execution
        // Awaits each task one after another (not parallel).
        public async void GetEmployeeDataSequentialAsync()
        {
            Employee emp = new Employee();
            var name = await emp.GetEmployeeNameAsync();
            Console.WriteLine($"Employee Name: {name}");

            if (name != null)
            {
                var id = await emp.GetEmployeeId(101);
                Console.WriteLine($"Employee ID: {id}");
            }
        }

        // Not thread-blocking, parallel execution
        // Starts both tasks in parallel and awaits both to complete.
        public async Task GetEmployeeDataParallelAsync()
        {
            Employee emp = new Employee();

            var nameTask = emp.GetEmployeeNameAsync();
            var idTask = emp.GetEmployeeId(101);

            await Task.WhenAll(nameTask, idTask);

            Console.WriteLine($"Employee Name: {nameTask.Result}, Employee ID: {idTask.Result}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" Async vs await");
            Program p = new Program();
            p. GetEmployeeDataParallelBlockingAsync();
            Console.ReadLine();
        }
    }
}
