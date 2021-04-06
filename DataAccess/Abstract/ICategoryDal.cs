using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal
    {
        List<Category> GetAll();

        void Add(Category Category);
        void Update(Category Category);
        void Delete(Category Category);

        List<Category> GetAllByCategory(int catttegoryId);

    }
}
