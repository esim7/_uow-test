using System.Collections.Generic;
using System.Linq;
using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataBase.EFImplementations
{
    public class AutomobilesRepository : IRepository<Automobile>
    {
        private readonly AutomobileDataContext _context;

        public AutomobilesRepository(AutomobileDataContext context)
        {
            _context = context;
        }
        
        public Automobile Get(int? id)
        {
            return _context.Automobiles.Find(id);
        }

        public IList<Automobile> GetAll()
        {
            return _context.Automobiles.ToList();
        }

        public Automobile Create(Automobile entity)
        {
            var auto = _context.Automobiles.Add(entity);
            return auto.Entity;
        }

        public Automobile Edit(Automobile entity)
        {
            var auto = _context.Automobiles.Find(entity.Id);
            if (auto != null)
            {
                auto.Brand = entity.Brand;
                auto.Color = entity.Color;
                auto.BodyType = entity.BodyType;
                auto.Power = entity.Power;
            }
            return auto;
        }

        public void Remove(Automobile entity)
        {
            _context.Automobiles.Remove(entity);
        }
    }
}