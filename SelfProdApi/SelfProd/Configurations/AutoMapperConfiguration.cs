using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SelfProd.Contracts.Notes;
using SelfProd.Entities.Models;

namespace SelfProd.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() : this("SelfProd") { }

        protected AutoMapperConfiguration(string name) : base(name)
        {
            CreateMap<NoteDto, Note>(MemberList.None);
            CreateMap<NewNoteDto, Note>(MemberList.None);
            CreateMap<Note, NoteDto>(MemberList.None);
        }
    }
}
