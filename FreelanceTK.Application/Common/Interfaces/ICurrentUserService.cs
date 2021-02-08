namespace FreelanceTK.Application.Common.Interfaces
{
    /// <summary>
    /// Сервис для получения идентификатора текущего авторизованного пользователя 
    /// </summary>
    public interface ICurrentUserService
    {
        string UserId { get; }
        int ApplicationUserId { get;  }
    }
}
