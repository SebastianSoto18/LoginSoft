namespace SoftTechChallenge.Infraestructure.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    void Remove(T entity);
    void Update(T entity);
    Task SaveChangesAsync();
    Task<bool> ExistAsync(int id);
}