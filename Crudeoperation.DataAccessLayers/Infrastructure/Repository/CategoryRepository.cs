using Crudeoperation.DataAccessLayer.Infrastructure.IRepository;
using Crudeoperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudeoperation.DataAccessLayer.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbcontext db;

        public CategoryRepository(ApplicationDbcontext db) : base(db)
        {
            this.db = db;
        }

        public void Update(Category category)
        {
            var CategoryDB = db.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (CategoryDB != null)
            {
                CategoryDB.Name = category.Name;
                CategoryDB.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}