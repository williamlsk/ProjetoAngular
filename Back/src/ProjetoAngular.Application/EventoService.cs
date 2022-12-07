using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoAngular.Application.Contracts;
using ProjetoAngular.Domain;
using ProjetoAngular.Persistence.Contracts;

namespace ProjetoAngular.Application
{
    public class EventoService : IEventoService
    {
        private readonly IBasePersistence _basePersistence;
        private readonly IEventoPersistence _eventoPersistence;

        public EventoService(IBasePersistence basePersistence, IEventoPersistence eventoPersistence)
        {
            _basePersistence = basePersistence;
            _eventoPersistence = eventoPersistence;
        }

        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _basePersistence.Add<Evento>(model);

                if (await _basePersistence.SaveChangesAsync())
                {
                    return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
                }

                return null;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

         public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
           try
           {
            var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);
            
            if (evento==null) return null;

            model.Id = evento.Id;
            _basePersistence.Update(model);
            
            if (await _basePersistence.SaveChangesAsync())
            {
                return await _eventoPersistence.GetEventoByIdAsync(model.Id, false);
            }

            return null;
           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }

        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
             try
           {
            var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, false);
            
            if (evento==null) throw new Exception("Evento para delete não encontrado!");

            _basePersistence.Delete<Evento>(evento);
            
            return await _basePersistence.SaveChangesAsync();

           }
           catch (Exception ex)
           {
                throw new Exception(ex.Message);
           }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool incluirPalestrante = false)
        {
            try
            {
                var evento = await _eventoPersistence.GetAllEventosAsync(incluirPalestrante);

                if (evento == null) return null;

                return evento;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante = false)
        {
             try
            {
                var evento = await _eventoPersistence.GetAllEventosByTemaAsync(tema, incluirPalestrante);

                if (evento == null) return null;

                return evento;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool incluirPalestrante = false)
        {
             try
            {
                var evento = await _eventoPersistence.GetEventoByIdAsync(eventoId, incluirPalestrante);

                if (evento == null) return null;

                return evento;

            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

       
    }
}