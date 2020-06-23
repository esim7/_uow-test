using Domain.Model;
using Infrastructure.DataBase.Interfaces;
using Infrastructure.EntityFramework;

namespace Infrastructure.DataBase.EFImplementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AutomobileDataContext _context;
        public IRepository<Automobile> Automobiles { get; set; }

        public EFUnitOfWork(IRepository<Automobile>automobiles, AutomobileDataContext context)
        {
            _context = context;
            Automobiles = automobiles;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Commit();
            }
        }

        public void Rollback()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }
    }
}