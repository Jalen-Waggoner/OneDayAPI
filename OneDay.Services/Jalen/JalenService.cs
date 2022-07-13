using System.Security.Claims;
using System.Threading.Tasks;
using OneDay.Data;
using OneDay.Models.Jalen;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace OneDay.Services.Jalen;
    public class JalenService : IJalenService
    {
        private readonly int _jalenId;
        private readonly ApplicationDbContext _dbContext;
        public JalenService (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateJalenAsync(JalenCreate request)
        {
            var jalenEntity = new JalenEntity
            {
                Name = request.Name,
                Content = request.Content,
            };

            _dbContext.Jalens.Add(jalenEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }


    }