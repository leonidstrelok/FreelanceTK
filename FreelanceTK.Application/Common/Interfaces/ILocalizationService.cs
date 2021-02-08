namespace FreelanceTK.Application.Common.Interfaces
{
    public interface ILocalizationService
    {
        string this[string key] { get; }
        string StatusMustBeActive { get; }
        string ValueAlreadyExists { get; }
        string CascadeDependencyError { get; }
        string GetResource(string key);
    }
}
