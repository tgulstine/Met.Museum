
namespace Met.Museum.Data
{
    public interface IDataService<T> where T : BaseEntity
    {
        Task Save(T entity);
    }
}