namespace EventSystem.Data.Common.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    public class DbRepository<T> : DbGenericRepository<T, int>, IDbRepository<T>
      where T : BaseModel<int>
    {
        public DbRepository(DbContext context)
            : base(context)
        {
        }

        public T GetById(int id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
