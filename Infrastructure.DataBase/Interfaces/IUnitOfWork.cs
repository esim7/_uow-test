using Domain.Model;

namespace Infrastructure.DataBase.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Automobile> Automobiles { get; set; }

        void Save();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}