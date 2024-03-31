﻿namespace Ecomerce.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task PostAsync(T entity);
        Task PutAsync(T entity);
        Task DeleteAsync(int id);
    }
}
