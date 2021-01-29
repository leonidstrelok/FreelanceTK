using System;

namespace FreelanceTK.Domain.Common
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}
