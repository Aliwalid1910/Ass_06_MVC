using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly IEmployeeRepositorie _employeeRepositorie;
        private readonly IDepartmentRepositorie _departmentRepositorie;
        private readonly ApplicationDbContext _dbContext;


        public UnitOfWork(IEmployeeRepositorie employeeRepositorie , IDepartmentRepositorie departmentRepositorie ,ApplicationDbContext dbContext) 
        {
            _employeeRepositorie = employeeRepositorie;
            _departmentRepositorie = departmentRepositorie;
            _dbContext = dbContext;
            
        }
        public IEmployeeRepositorie EmployeeRepositorie => _employeeRepositorie;

        public IDepartmentRepositorie DepartmentRepositorie => _departmentRepositorie;

        public int SaveChanges { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        int IUnitOfWork.SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
