namespace Met.Museum.Data
{
    public class DataService<T> : IDataService<T> where T : BaseEntity
    {
        public async Task Save(T entity)
        {
            using var context = new MetDbContext();

            var repository = new Repository<T>(context);
            repository.Add(entity);
            await repository.SaveAsync();
        }
    }
}