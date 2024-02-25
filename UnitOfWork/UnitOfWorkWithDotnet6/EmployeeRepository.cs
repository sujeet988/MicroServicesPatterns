﻿using Microsoft.EntityFrameworkCore;
using UnitOfWorkWithDotnet6.Interfaces;
using UnitOfWorkWithDotnet6.Models;

namespace UnitOfWorkWithDotnet6
{

    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EFCoreDbContext context) : base(context) { }

        //Returns all employees from the database including the Department Data
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
            //return await _context.Employees.ToListAsync();
        }

        //Retrieves a single employee by their ID along with Department data.
        public async Task<Employee?> GetEmployeeByIdAsync(int EmployeeID)
        {
            var employee = await _context.Employees
               .Include(e => e.Department)
               .FirstOrDefaultAsync(m => m.EmployeeId == EmployeeID);
            return employee;
        }

        //Retrieves Employees by Departmentid
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int DepartmentId)
        {
            return await _context.Employees
                .Where(emp => emp.DepartmentId == DepartmentId)
                .Include(e => e.Department).ToListAsync();
        }
    }
}
