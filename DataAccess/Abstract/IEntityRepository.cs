using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Entities.Abstract;

namespace DataAccess.Abstract
{

    // generic constraint
    // class: referans tip olabilir demek
    // IEntity: IEntity olabilir veya IEntity implemente eden başka bir class olabilir
    // new: sadece newlenebilir olanalrı()IEntity newlenemez çünkü interface)
    public interface IEntityRepository<T> where T:class
    {
      
        List<T> GetAll(Expression<Func<T, bool>> filter =null); 
        T Get(Expression <Func<T, bool>> filter);  
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

 
    }
}
