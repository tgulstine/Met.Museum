
namespace Met.Museum.Data
{
    internal interface IRepository<T> where T : BaseEntity
    {
        void Add(in T entity);
        Task<int> SaveAsync();
    }
}