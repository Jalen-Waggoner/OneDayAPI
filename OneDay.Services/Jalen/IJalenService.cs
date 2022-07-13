using OneDay.Models.Jalen;
namespace OneDay.Services.Jalen;

    public interface IJalenService
    {
        // Task<IEnumerable<JalenListItem>> GetAllJalensAsync();
        Task<bool> CreateJalenAsync(JalenCreate request);
    }