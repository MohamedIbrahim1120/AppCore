﻿using TestCoreApp.Models;

namespace TestCoreApp.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> categories { get; }

        IRepository<Item> Items { get; }

        IEmpRepo Employees { get; }

       int CommitChanges();
       
        
    }
}
