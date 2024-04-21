using System.Linq.Expressions;

namespace TestCoreApp.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);

        T Selectone(Expression<Func<T, bool>> match);

        IEnumerable<T> FindAll();


        IEnumerable<T> FindAll(params string[] agers);


        Task<T> FindByIdAsync(int id);


       Task<IEnumerable<T>> FindAllAsync();


        Task<IEnumerable<T>> FindAllAsync(params string[] agers);


        void AddOne(T MyItem);


        void UpdateOne(T MyItem);


        void DeleteOne(T MyItem);


        void AddList(IEnumerable<T> MyList);


        void UpdateList(IEnumerable<T> MyList);


        void DeleteList(IEnumerable<T> MyList);

    }
}
