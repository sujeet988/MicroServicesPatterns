using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        protected ResponseDto _response;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _response = new ResponseDto();
        }

        // GET: Employees
        [HttpGet(Name = "GetEmpNames")]
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<object> Create([FromBody] Employee employee)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<object> Edit(int id, [FromBody] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
            return RedirectToAction(nameof(Index));
        }


    }
}




