using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneDay.Models;
using OneDay.Models.UserFloria;


namespace OneDay.Services
{
    public interface IFloriaService
    {
        Task<bool> CreateNewComment(UserFloria model);
        Task<FloriaDetail> GetCommentByIdAsync(int userId);
    }
}