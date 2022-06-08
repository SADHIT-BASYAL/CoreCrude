using Crudeoperation.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudeoperation.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbcontext db;
        public ICategoryRepository Category { get; private set; }

        public IProductRepository Product { get; private set; }

        public UnitOfWork(ApplicationDbcontext db)
        {
            this.db = db;
            this.Category = new CategoryRepository(db);
            this.Product = new ProductRepository(db);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}