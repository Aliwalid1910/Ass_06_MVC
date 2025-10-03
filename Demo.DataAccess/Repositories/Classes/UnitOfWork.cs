using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly Lazy<IEmployeeRepositorie> _employeeRepositorie;
        private readonly Lazy<IDepartmentRepositorie> _departmentRepositorie;
        private readonly ApplicationDbContext _dbContext;


        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            _employeeRepositorie = new Lazy<IEmployeeRepositorie>(() => new EmployeeRepositorie(dbContext));
            _departmentRepositorie = new Lazy<IDepartmentRepositorie>(() => new DepartmentRepositorie(dbContext));
            _dbContext = dbContext;
            
        }
        public IEmployeeRepositorie EmployeeRepositorie => _employeeRepositorie.Value;

        public IDepartmentRepositorie DepartmentRepositorie => _departmentRepositorie.Value;

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
