using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkWithDotnet6.Models;
using UnitOfWorkWithDotnet6.UOW;

namespace UnitOfWorkWithDotnet6.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        //The following variable will hold the IUnitOfWork Instance
        private readonly IUnitOfWork _unitOfWork;
        protected ResponseDto _response;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _response = new ResponseDto();
        }

        // GET: Employees
        [HttpGet("GetEmpNames")]
        public async Task<object> GetEmpNames()
        {

            try
            {
                var employees = await _unitOfWork.Employees.GetAllEmployeesAsync();
                _response.Result = employees;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        // get details
        [HttpGet("GetEmployeeById/{id}")]
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
        [HttpPost("AddEmployee")]
        public async Task<object> Create([FromBody] EmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                Employee e = new Employee();
                e.Name = employee.Name;
                e.Email= employee.Email;
                e.DepartmentId = employee.DepartmentId;
                e.Position= employee.Position;

                try
                {
                    //Begin The Tranaction
                    _unitOfWork.CreateTransaction();
                    //Use Generic Reposiory to Insert a new employee
                    await _unitOfWork.Employees.InsertAsync(e);
                    //Save Changes to database
                    await _unitOfWork.Save();
                    //Commit the Changes to database
                    _unitOfWork.Commit();
                    _response.Result = employee;


                }
                catch (Exception ex)
                {
                    //Rollback Transaction
                    _unitOfWork.Rollback();
                    //Log The Exception
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { ex.ToString() };
                }
            }
            return _response;

        }

        [HttpPost("UpdateEmployee/{id}")]
        public async Task<object> Edit(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (id != employeeDto.EmployeeId)
            {
                return NotFound();
            }
            Employee employee = await _unitOfWork.Employees.GetEmployeeByIdAsync(Convert.ToInt32(id));
            employee.Name= employeeDto.Name;
            employee.Email= employeeDto.Email;
            employee.Position= employeeDto.Position;
            employee.DepartmentId= employeeDto.DepartmentId;


            if (ModelState.IsValid)
            {
                try
                {
                    //Begin The Tranaction
                    _unitOfWork.CreateTransaction();
                    //Use Generic Reposiory to Insert a new employee
                    await _unitOfWork.Employees.UpdateAsync(employee);
                    //Save Changes to database
                    await _unitOfWork.Save();
                    //Commit the Changes to database
                    _unitOfWork.Commit();
                    _response.Result = employee;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    //Rollback Transaction
                    _unitOfWork.Rollback();
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { ex.ToString() };
                }
            }
            return _response;
        }

        [HttpPost("DeleteEmployee/{id}")]
        public async Task<object> DeleteConfirmed(int id)
        {
            //Begin The Tranaction
            _unitOfWork.CreateTransaction();
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee != null)
            {
                try
                {
                    await _unitOfWork.Employees.DeleteAsync(id);
                    //Save Changes to database
                    await _unitOfWork.Save();
                    //Commit the Changes to database
                    _unitOfWork.Commit();
                    _response.Result = id;
                }
                catch (Exception ex)
                {
                    //Rollback Transaction
                    _unitOfWork.Rollback();
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string>() { ex.ToString() };
                }
            }
            return _response;
        }


    }
}




