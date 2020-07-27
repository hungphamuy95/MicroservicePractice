using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Services.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<Notes>> GetAllNote();
    }
}
