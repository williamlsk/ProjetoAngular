using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoAngular.Domain;
using ProjetoAngular.Persistence.Context;
using ProjetoAngular.Persistence.Contracts;

namespace ProjetoAngular.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {
        private readonly ProjetoAngularContext _context;

        public PalestrantePersistence(ProjetoAngularContext context)
        {
            _context = context;    
        }
       
        public async Task<Palestrante[]> GetAllPalestranteAsync(bool incluirEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                                            .Include(e => e.RedeSocial);
            
            if(incluirEvento)
            {
                query = query.Include(e => e.PalestranteEvento).ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);
                     
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestranteByNameAsync(string nome, bool incluirEvento = false)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                                            .Include(p => p.RedeSocial);
            
            if(incluirEvento)
            {
                query = query.Include(e => e.PalestranteEvento).ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Nome.ToLower().Contains(nome.ToLower()));
                     
            return await query.ToArrayAsync();
        }


        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluirEvento)
        {
            IQueryable<Palestrante> query = _context.Palestrante
                                            .Include(p => p.RedeSocial);
            
            if(incluirEvento)
            {
                query = query.Include(e => e.PalestranteEvento).ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Id == palestranteId);
                     
            return await query.FirstOrDefaultAsync();
        }

    }
}