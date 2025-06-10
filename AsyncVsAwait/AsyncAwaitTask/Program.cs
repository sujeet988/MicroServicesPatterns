namespace AsyncAwaitTask
{
    internal class Program
    {

        // Thread -blocking
        // parallel execution
        public async Task GetDataParallelwithoutawait()
        {
            Employee emp = new Employee();

            var nameTask = emp.GetEmployeeNameAsync();
            var idTask = emp.GetEmployeeId(101);


            Console.WriteLine($"Employee Name: {nameTask.Result}, Employee ID: {idTask.Result}");
            Console.WriteLine("ended");
        }

        //thread-blocking
        // parallel execution
        public void GetDataParallel()
        {
            Employee emp = new Employee();
            var nameTask = emp.GetEmployeeNameAsync();
            var idTask = emp.GetEmployeeId(101);

            // Wait for both tasks to complete
            Task.WaitAll(nameTask, idTask);

            Console.WriteLine($"Employee Name: {nameTask.Result}, Employee ID: {idTask.Result}");
        }
        //Not thread-blocking
        public async void GetDataNotParallel()
        {
            Employee emp = new Employee();
            var nameTask = await emp.GetEmployeeNameAsync();
            Console.WriteLine($"Employee Name: {nameTask}");

            if (nameTask != null)
            {
                var idTask = await emp.GetEmployeeId(101);
                Console.WriteLine($"Employee id: {nameTask}");
            }
        }
        public async Task GetDataParallelAsync()
        {
            Employee emp = new Employee();

            var nameTask = emp.GetEmployeeNameAsync();
            var idTask = emp.GetEmployeeId(101);

            await Task.WhenAll(nameTask, idTask);

            Console.WriteLine($"Employee Name: {nameTask.Result}, Employee ID: {idTask.Result}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
