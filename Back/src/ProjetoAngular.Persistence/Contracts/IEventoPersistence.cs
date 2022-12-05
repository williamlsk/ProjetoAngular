using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAngular.Domain;

namespace ProjetoAngular.Persistence.Contracts
{
    public interface IEventoPersistence
    {
        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrante);
    }
}