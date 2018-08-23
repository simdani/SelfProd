using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfProd.Constants;
using SelfProd.Contracts.Notes;
using SelfProd.Services.Interfaces;

namespace SelfProd.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        [Produces(typeof(NoteDto[]))]
        public async Task<IActionResult> Get()
        {
            var notes = await _notesService.GetAll();
            return Ok(notes);
        }

        [HttpGet("{id}", Name = nameof(RoutingEnum.GetNote))]
        [Produces(typeof(NoteDto))]
        public async Task<IActionResult> Get(int id)
        {
            var note = await _notesService.GetById(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpPost]
        [Produces(typeof(NoteDto))]
        public async Task<IActionResult> Post([FromBody] NewNoteDto newNote)
        {
            var createdNote = await _notesService.Create(newNote);
            var noteUri = CreateResourceUri(createdNote.Id);

            return Created(noteUri, createdNote);
        }

        private Uri CreateResourceUri(int id)
        {
            return new Uri(Url.Link(nameof(RoutingEnum.GetNote) ,new {id}));
        }
    }
}
