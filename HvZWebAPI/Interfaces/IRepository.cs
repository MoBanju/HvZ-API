namespace HvZWebAPI.Interfaces;

public interface IRepository<T>
{

    /// <summary>
    /// Gets an entity based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<T> GetById(int id);
    /// <summary>
    /// Gets all the entities
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<T>> GetAll();
    /// <summary>
    /// Adds a new eninty to the database
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<T?> Add(T entity);
    /// <summary>
    /// Updates an exsisting entity to be overwritten with a given entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Task<bool> Update(T entity);
    /// <summary>
    /// Deletes the entity with the given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> Delete(int id);


}
