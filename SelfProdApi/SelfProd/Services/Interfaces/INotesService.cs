using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelfProd.Contracts.Notes;

namespace SelfProd.Services.Interfaces
{
    public interface INotesService
    {
        Task<NoteDto> GetById(int id);
        Task<ICollection<NoteDto>> GetAll();
        Task<NoteDto> Create(NewNoteDto newNote);
    }
}
