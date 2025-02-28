namespace StudentCenterApi._4___Interfaces.Repository;

public interface IGeneric<T>
{
    Task<ICollection<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Post(T entity);
    Task<T> Put(T entity);
    Task<bool> Delete(T entity);
}
