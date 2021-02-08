using System;
using System.Threading;
using System.Threading.Tasks;

namespace FreelanceTK.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        /// <summary>
        /// Создает нового работника
        /// </summary>
        /// <param name="userName">Имя работника</param>
        /// <param name="email">Почта работника</param>
        /// <param name="password">Пароль работника</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> CreateUserAsync(string userName, string email, string password, bool needChangePassword = true, CancellationToken cancellationToken = default);
        /// <summary>
        /// Блокировка работник
        /// </summary>
        /// <param name="userId">Id работника</param>
        /// <param name="until">Дата конца блокировки</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task LockUserAsync(string userId, DateTimeOffset? until, CancellationToken cancellationToken = default);
        /// <summary>
        /// Разблокировка работника
        /// </summary>
        /// <param name="userId">Id работника</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Добавление утверждение для работника
        /// </summary>
        /// <param name="userId">Id работника</param>
        /// <param name="claimType">Тип утверждения</param>
        /// <param name="claimValue">Значение утверждение</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddToClaimAsync(string userId, string claimType, string claimValue, CancellationToken cancellationToken = default);
        /// <summary>
        /// Установить email для пользователя
        /// </summary>
        /// <param name="userId">Id работника</param>
        /// <param name="email">Новый Email</param>
        /// <returns></returns>
        Task SetConfirmedEmailAsync(string userId, string email);
        /// <summary>
        /// Добавление утверждение для работника
        /// </summary>
        /// <param name="userId">Id работника</param>
        /// <param name="claimType">Тип утверждения</param>
        /// <param name="claimValue">Значение утверждение</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddToClaimAsync(string userId, string claimType, int claimValue, CancellationToken cancellationToken = default);
        /// <summary>
        /// Изменение пароля для работника
        /// </summary>
        /// <param name="userId">Id работника</param>
        /// <param name="newPassword">Новый пароль </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ChangeUserPassword(string userId, string newPassword, CancellationToken cancellationToken = default);
        /// <summary>
        /// Сменить логин пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="userName">Новый логин</param>
        /// <returns></returns>
        Task UpdateUsernameAsync(string userId, string userName);
        /// <summary>
        /// Получить дату окончания блокировки
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<(DateTimeOffset? lockoutEnd, bool isLockedout, bool isEnabled)> GetLockoutInfo(string userId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Обновить информацию о блокировке
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="until"></param>
        /// <param name="lockoutEnabled"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateLockoutInfo(string userId, DateTimeOffset? until, bool lockoutEnabled, CancellationToken cancellationToken = default);
    }
}
