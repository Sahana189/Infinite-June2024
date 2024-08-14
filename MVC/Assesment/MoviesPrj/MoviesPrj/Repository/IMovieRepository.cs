using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPrj.Repository
{
    public interface IMovieRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); 
        T GetById(object id);     
        void Insert(T entity);    
        void Update(T entity);   
        void Delete(object id);   
        void Save();              
    }
}

