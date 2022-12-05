using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAngular.Domain;

namespace ProjetoAngular.Application.Contracts
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);
        Task<Evento> UpdateEvento(int eventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false);
        Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrante = false);
    }
}