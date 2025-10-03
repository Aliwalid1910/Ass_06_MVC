using Demo.BusinessLogic.DTOS.EmployeeDTOS;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        // GET ALL
        IEnumerable<EmployeeDto> GetAllEmployees(string? EmployeeSearchName, bool withTracking = false);
        // GET BY ID
        EmployeeDetailsDto? GetEmployeeById(int id);
        // CREATE 
        int CreateEmployee(CreateEmployeeDto employeeDto);
        // UPDATE
        int UpdateEmployee(UpdatedEmployeeDto employeeDto);
        // DElETE
        bool DeleteEmployee(int id);


    }
}
