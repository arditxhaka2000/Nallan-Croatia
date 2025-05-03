using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Histories
{
    public interface IHistoryService
    {
        IEnumerable<History> GetAll();
        IEnumerable<History> GetDistincAll();
        IQueryable<History> GetByObjectId(Guid ObjectId);
        IEnumerable<History> GetByObjectId(DateTime ObjectId);
        IEnumerable<string> GetAllTablesDistincAll();
    }
}
