using Demo1.Data;
using Demo1.Repo.Abstraction;

namespace Demo1.Repo.Implementation
{
    public class GenaricRepo<T> : IGenaric<T> where T : class
    {
        private readonly AppDbContext _Context;
        public GenaricRepo(AppDbContext context)
        {
            _Context = context;
        }
        public void Add(T entity)
        {
            _Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
          _Context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
          var s =  _Context.Set<T>().ToList();
            return s;
        }

        public T GetById(int id)
        {
          var s =  _Context.Set<T>().Find(id);
            return s;

        }

        public int save()
        {
          var s= _Context.SaveChanges();
            return s;
        }

        public void Update(T entity)
        {
           _Context.Set<T>().Update(entity);
        }
    }
}
