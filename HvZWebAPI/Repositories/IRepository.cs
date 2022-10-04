namespace HvZWebAPI.Repositories;

public interface IRepository<T>
{

    public Task<T> GetById(int id);
    public Task<IEnumerable<T>> GetAll();
    public Task<bool> Add(T entity);
    public Task<bool> Update(T entity);
    public Task<Task> Delete(T entity);


}
