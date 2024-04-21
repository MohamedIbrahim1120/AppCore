using TestCoreApp.Date;
using TestCoreApp.Models;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            categories = new MainRepository<Category>(_context);
            Items = new MainRepository<Item>(_context);
            Employees = new EmpRepo(_context);
        }

        private readonly AppDbContext _context;

        public IRepository<Category> categories { get; private set; }

        public IRepository<Item> Items { get; private set; }

        public IEmpRepo Employees { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        } 

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
