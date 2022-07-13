using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OneDay.Data;
using OneDay.Models.Jalen;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace OneDay.Services.Jalen;
    public class JalenService : IJalenService
    {
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

        public async Task<JalenDetail> GetJalenByIdAsync(int jalenId)
        {
            var jalenEntity = await _dbContext.Jalens.FindAsync(jalenId);
            
            return jalenEntity is null ? null : new JalenDetail
            {
                Id = jalenEntity.Id,
                Name = jalenEntity.Name,
                Content = jalenEntity.Content
            };
        }
    }