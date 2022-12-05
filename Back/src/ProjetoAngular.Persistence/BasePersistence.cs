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
    public class BasePersistence : IBasePersistence
    {
        private readonly ProjetoAngularContext _context;

        public BasePersistence(ProjetoAngularContext context)
        {
            _context = context;    
        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        
    }
}