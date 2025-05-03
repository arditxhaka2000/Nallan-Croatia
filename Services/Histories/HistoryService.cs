using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Histories
{
    public class HistoryService : IHistoryService
    {
        private readonly IUserRepository<History> _unitOfWork; 

        public HistoryService(IUserRepository<History> unityOfWork)
        {
            _unitOfWork = unityOfWork;
        }

        public IEnumerable<History> GetAll()
        {
            return this._unitOfWork.Get();
        }

        public IQueryable<History> GetByObjectId(Guid objectId)
        {
            return _unitOfWork.GetAsQueryable(x => x.HistoryParentId == objectId);
        }

        public IEnumerable<History> GetByObjectId(DateTime date)
        {
            return _unitOfWork.GetAsQueryable(x => x.Date == date);
        }


        public IEnumerable<History> GetDistincAll()
        {
            var rez = this._unitOfWork.GetAsQueryable()
                                      .GroupBy(x => new { x.HistoryParentId })
                                      .Select(x => x.FirstOrDefault());

            return rez.OrderByDescending(x => x.Date)
                       .Select(x =>
                               new History
                               {
                                   ActionName = x.ActionName,
                                   TableName = x.TableName,
                                   Date = x.Date,
                                   ObjectId = x.ObjectId,
                                   username = x.username,
                                   HistoryParentId = x.HistoryParentId
                               });
        }

        public IEnumerable<string> GetAllTablesDistincAll()
        {

            var rez = this._unitOfWork.GetAsNoTracking()
                       .Select(x => x.TableName).Distinct();

            return rez;
        }
    }
}
