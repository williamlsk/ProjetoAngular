using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAngular.Domain;

namespace ProjetoAngular.Persistence.Contracts
{
    public interface IPalestrantePersistence
    {
        //PALESTRANTES
        Task<Palestrante[]> GetAllPalestranteByNameAsync(string nome, bool incluirEvento);
        Task<Palestrante[]> GetAllPalestranteAsync(bool incluirEvento);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool incluirEvento);

    }
}