namespace Demo1.Repo.Abstraction
{
    public interface IGenaric<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int save();

    }
}
