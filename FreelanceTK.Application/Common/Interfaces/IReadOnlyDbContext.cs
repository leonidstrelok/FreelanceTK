using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelanceTK.Application.Common.Interfaces
{
    public interface IReadOnlyDbContext
    {
        IQueryable<T> Query<T>() where T : class;
    }
}
