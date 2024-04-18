
namespace DanderiTV.Layer.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> FindById(int ID);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity, int Id);
        Task<bool> Delete(T entity);



    }
}
