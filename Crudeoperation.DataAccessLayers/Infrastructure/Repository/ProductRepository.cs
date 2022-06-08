using Crudeoperation.DataAccessLayer.Infrastructure.IRepository;
using Crudoperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudeoperation.DataAccessLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbcontext db;

        public ProductRepository(ApplicationDbcontext db) : base(db)
        {
            this.db = db;
        }

        public void Update(Product product)
        {
            var ProductDB = db.Products.FirstOrDefault(x => x.Id == product.Id);
            if (ProductDB != null)
            {
                ProductDB.Name = product.Name;
                ProductDB.Description = product.Description;
                ProductDB.Price = product.Price;
                if (ProductDB.ImageUrl != null)
                {
                    ProductDB.ImageUrl = product.ImageUrl;
                }
            }
        }
    }
}