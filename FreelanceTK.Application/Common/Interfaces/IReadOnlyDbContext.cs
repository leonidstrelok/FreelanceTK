using System.Linq;

namespace FreelanceTK.Application.Common.Interfaces
{
    public interface IReadOnlyDbContext
    {
        IQueryable<T> Query<T>() where T : class;
    }
}
