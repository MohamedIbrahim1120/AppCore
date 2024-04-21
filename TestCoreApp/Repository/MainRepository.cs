using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestCoreApp.Date;
using TestCoreApp.Models;
using TestCoreApp.Repository.Base;

namespace TestCoreApp.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context)
        {
            this.context = context;
        }

        protected AppDbContext context;

        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Selectone(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if(agers.Length>0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {

            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return await query.ToListAsync();
        }


        //  Add Update And Delete
        //---------------------------------------------------------------------------------

        public void AddOne(T MyItem)
        {
            context.Set<T>().Add(MyItem);
            context.SaveChanges();
        }

        public void UpdateOne(T MyItem)
        {
            context.Set<T>().Update(MyItem);
            context.SaveChanges();
        }

        public void DeleteOne(T MyItem)
        {
            context.Set<T>().Remove(MyItem);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> MyList)
        {
            context.Set<T>().AddRange(MyList);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> MyList)
        {
            context.Set<T>().UpdateRange(MyList);
            context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> MyList)
        {
            context.Set<T>().RemoveRange(MyList);
            context.SaveChanges();
        }
    }
}