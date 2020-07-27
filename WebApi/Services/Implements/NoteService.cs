using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Repositories.Interfaces;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implements
{
    public class NoteService : INoteService
    {
        private readonly IGenericRepository<Notes> _noteRepository;
        public NoteService(IGenericRepository<Notes> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<IEnumerable<Notes>> GetAllNote()
        {
            return await _noteRepository.GetAll();
        }
    }
}
