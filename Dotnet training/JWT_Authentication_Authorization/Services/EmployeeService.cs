using JWT_Authentication_Authorization.Context;
using JWT_Authentication_Authorization.Interfaces;
using JWT_Authentication_Authorization.Models;
using System;
using System.Collections.Generic;

namespace JWT_Authentication_Authorization.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly JWTContext _context;

        public EmployeeService(JWTContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            var emp = _context.Employees.Add(employee);
            _context.SaveChanges();
            return emp.Entity;
        }

        public List<Employee> GetEmployeeList()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }
    }
}
