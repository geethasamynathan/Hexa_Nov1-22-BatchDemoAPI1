using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI1.Models;

namespace DemoAPI1.Repository
{
    public class MockDepartmentRepo : IDepartmentRepo
    {
        private DepartmentEmployeeContext context=new DepartmentEmployeeContext();
       
        string AddNewDepartment(Department department)
        {
            string result = department.DepartmentName +"Added successfully";
            context.Departments.Add(department);
            context.SaveChanges();
            return result;
        }

        string IDepartmentRepo.AddNewDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        string  DeleteDepartment(int id)
        {
            string result;
            Department dept = context.Departments.FirstOrDefault(d => d.DepartmentId == id);
            if (dept != null)
            {
                context.Departments.Remove(dept);
                context.SaveChanges();
                result = id + " is Deleted";
            }
            else
            {
                result = "The given Department id is not exist";
            }
            return result;
        }

        string IDepartmentRepo.DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Department> IDepartmentRepo.GetAllDepartments()
        {
            List<Department> departments = context.Departments.ToList();
            return departments;
        }

        Department GetDepartmentById(int id)
        {
            
            Department dept = context.Departments.FirstOrDefault(d => d.DepartmentId == id);
             return dept;
        }

        Department IDepartmentRepo.GetDepartmentById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Department> GetDepartmentByLocation(string location)
        {
            var dept = context.Departments.Where(d => d.Location == location).ToList();
            return dept; 
        }

        IEnumerable<Department> IDepartmentRepo.GetDepartmentByLocation(string location)
        {
            throw new NotImplementedException();
        }

        string UpdateDepartmentDetails(Department department)
        {
            string result;
            Department dept = context.Departments.FirstOrDefault(d => d.DepartmentId == department.DepartmentId);
            if (dept != null)
            {
                dept = department;
                context.SaveChanges();
                result = department.DepartmentId + " is Updaated";
            }
            else
            {
                result = "The given Department id is not exist";
            }
            return result;
        }

        string IDepartmentRepo.UpdateDepartmentDetails(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
