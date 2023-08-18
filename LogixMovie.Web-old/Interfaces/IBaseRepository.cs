namespace Logix_Movie_Application.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(int id);
    }
}
