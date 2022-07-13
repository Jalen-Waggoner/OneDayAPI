using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneDay.Data;
using OneDay.Models.UserFloria;

namespace OneDay.Services
{
    public class FloriaService : IFloriaService
    {
        private readonly ApplicationDbContext _context;
        public FloriaService (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateNewComment(UserFloria comment)
        {
            var entity = new FloriaEntity
            {
                Title= comment.Title,
                Content= comment.Content,
            };

            _context.Florias.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<FloriaDetail> GetCommentByIdAsync (int commentId)
        {
            var entity = await _context.Florias.FindAsync(commentId);
            if(entity is null)
                return null;
            
            return entity is null ? null : new FloriaDetail
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content
            };
        }
        
        }
    }

    
