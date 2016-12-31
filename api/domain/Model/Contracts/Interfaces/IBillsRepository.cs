using domain.Model.Entities;
using System.Collections.Generic;

namespace domain.Model.Contracts.Interfaces
{
    public interface IBillsRepository
    {
        IEnumerable<Bill> List();

        Bill Get(int id);

        int Update(Bill bill);

        void Delete(int id);

        int Create(Bill bill);

        void SetPaid(int id);
    }
}
