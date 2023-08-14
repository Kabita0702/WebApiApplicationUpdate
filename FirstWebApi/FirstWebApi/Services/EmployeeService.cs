using FirstWebApi.EmployeeData;
using FirstWebApi.Json;
using FirstWebApi.Models;

namespace FirstWebApi.Services
{
    public class EmployeeService
    {
        public Employee GetEmployee(int id)
        {
            var employeeList = StoreData.GetEmployeeData();
            var employee = employeeList.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                throw new Exception("Data not found");
            }
            return employee;
        }

        public Employee CreateEmployees(Employee inputRequest) 
        {
            var employeeList = StoreData.GetEmployeeData();
            var flag = employeeList.FirstOrDefault(item => item.Id == inputRequest.Id);
            if (flag != null)
            {
                throw new Exception("Already exist id");
            }
            Random random = new Random();
            inputRequest.Id = random.Next();
            employeeList.Add(inputRequest);
            StoreData.WriteEmployeeData(employeeList);
            return (inputRequest);
        }
    }
}
