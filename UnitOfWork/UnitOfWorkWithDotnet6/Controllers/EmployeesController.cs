using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitOfWorkWithDotnet6.Models;
using UnitOfWorkWithDotnet6.UOW;

namespace UnitOfWorkWithDotnet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //The following variable will hold the IUnitOfWork Instance
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Employees
        [HttpGet(Name = "GetEmpNames")]
        public async Task<IActionResult> GetEmpNames()
        {
            //Use Employee Repository to Fetch all the employees along with the Department Data
            var employees = await _unitOfWork.Employees.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // GET: Employees/Details/5
        [HttpGet(Name = "Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Use Employee Repository to Fetch Employees along with the Department Data by Employee Id
            var employee = await _unitOfWork.Employees.GetEmployeeByIdAsync(Convert.ToInt32(id));
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("CreateEmpdata")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Begin The Tranaction
                    _unitOfWork.CreateTransaction();
                    //Use Generic Reposiory to Insert a new employee
                    await _unitOfWork.Employees.InsertAsync(employee);
                    //Call SaveAsync to Insert the data into the database
                    //await _repository.SaveAsync();
                    //Save Changes to database
                    await _unitOfWork.Save();
                    //Commit the Changes to database
                    _unitOfWork.Commit();


                }
                catch (Exception)
                {
                    //Rollback Transaction
                    _unitOfWork.Rollback();
                    //Log The Exception
                }
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromBody] Employee employee)
        {
           

        }
    }



}
