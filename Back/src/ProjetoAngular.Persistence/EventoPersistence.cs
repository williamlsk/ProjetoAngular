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
    public class EventoPersistence : IEventoPersistence
    {
        private readonly ProjetoAngularContext _context;

        public EventoPersistence(ProjetoAngularContext context)
        {
            _context = context;
        }
        
        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = _context.Evento
                                            .Include(e => e.Lote)
                                            .Include(e => e.RedeSocial);
            
            if(incluirPalestrante )
            {
                    query = query.Include(e => e.PalestranteEvento).ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);

            
            return await query.AsNoTracking().ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoid, bool incluirPalestrante = false)
        {
             IQueryable<Evento> query = _context.Evento
                                            .Include(e => e.Lote)
                                            .Include(e => e.RedeSocial);
            
            if(incluirPalestrante)
            {
                query = query.Include(e => e.PalestranteEvento)
                             .ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == eventoid);
            
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
            IQueryable<Evento> query = _context.Evento
                                            .Include(e => e.Lote)
                                            .Include(e => e.RedeSocial);
            
            if(incluirPalestrante)
            {
                query = query.Include(e => e.PalestranteEvento).ThenInclude(pe => pe.Palestrante);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            
            return await query.AsNoTracking().ToArrayAsync();
        }

        

    }
}