using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfProd.Entities;
using SelfProd.Entities.Models;

namespace SelfProd.Repositories
{
    public class NotesRepository : RepositoryBase<Note>
    {
        protected override DbSet<Note> ItemSet { get; }
        public NotesRepository(DataContext context) : base(context)
        {
            ItemSet = context.Notes;
        }

        protected override IQueryable<Note> IncludeDependencies(IQueryable<Note> queryable)
        {
            return queryable;
        }
    }
}
