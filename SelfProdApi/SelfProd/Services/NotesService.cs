using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SelfProd.Contracts.Notes;
using SelfProd.Entities.Models;
using SelfProd.Repositories.Interfaces;
using SelfProd.Services.Interfaces;

namespace SelfProd.Services
{
    public class NotesService : INotesService
    {
        private readonly IRepository<Note> _repository;
        private readonly IMapper _mapper;

        public NotesService(IRepository<Note> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NoteDto> GetById(int id)
        {
            var note = await _repository.GetById(id);
            var noteDto = _mapper.Map<NoteDto>(note);
            return noteDto;
        }

        public async Task<ICollection<NoteDto>> GetAll()
        {
            var notes = await _repository.GetAll();
            var notesDto = _mapper.Map<NoteDto[]>(notes);
            return notesDto;
        }

        public async Task<NoteDto> Create(NewNoteDto newNote)
        {
            if (newNote == null) throw new ArgumentNullException(nameof(newNote));

            var note = _mapper.Map<Note>(newNote);
            await _repository.Create(note);

            var noteDto = _mapper.Map<NoteDto>(note);
            return noteDto;
        }
    }
}
