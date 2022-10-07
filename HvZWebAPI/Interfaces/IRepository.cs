﻿namespace HvZWebAPI.Interfaces;

public interface IRepository<T>
{

    public Task<T> GetById(int id);
    public Task<IEnumerable<T>> GetAll();
    public Task<T?> Add(T entity);
    public Task<bool> Update(T entity);
    public Task<bool> Delete(T entity);


}
