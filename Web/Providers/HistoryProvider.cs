using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Histories;
using X.PagedList;

namespace Web.Providers
{
    public class HistoryProvider
    {
        private readonly ApplicationContext _context;
        internal DbSet<History> _dbSet;

        private readonly IMapper _mapper;

        public HistoryProvider(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            this._dbSet = _context.Set<History>();
            _mapper = mapper;
        }
        public PagedList<GetHistoryViewModel> GetAll2(string username, string tablename, string fromdate, string todate, int pageNumber, int pageSize)
        {
            var dbset = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(username))
            {
                dbset = dbset.Where(x => x.username.Equals(username));
            }

            if (!string.IsNullOrEmpty(tablename))
            {
                dbset = dbset.Where(x => x.TableName.Equals(tablename));
            }

            if (!string.IsNullOrEmpty(fromdate))
            {
                DateTime date = Convert.ToDateTime(fromdate);
                dbset = dbset.Where(o => o.Date >= date);
            }

            if (!string.IsNullOrEmpty(todate))
            {
                DateTime date = Convert.ToDateTime(todate);
                dbset = dbset.Where(o => o.Date <= date);
            }

            //dbset = dbset.AsNoTracking()
            //      .GroupBy(x => new { x.HistoryParentId })
            //      .Select(x => x.FirstOrDefault());
            var sqlquery = dbset.AsNoTracking().GroupBy(x => new { x.HistoryParentId }).Select(x => x.FirstOrDefault()).OrderByDescending(x => x.Date).AsQueryable();

            return new PagedList<GetHistoryViewModel>(_mapper.Map<IList<GetHistoryViewModel>>(sqlquery), pageNumber, pageSize);
        }
        public PagedList<GetHistoryViewModel> GetAll(string username, string tablename, string fromdate, string todate, int pageNumber, int pageSize)
        {
            var dbset = _dbSet.AsQueryable();
            string whereq = "where (1=1) ";

            if (!string.IsNullOrEmpty(username))
            {
                whereq += $"AND username ='{username}' ";// dbset.Where(x => x.username.Equals(username));
            }

            if (!string.IsNullOrEmpty(tablename))
            {
                whereq += $"AND TableName ='{tablename}' ";// dbset = dbset.Where(x => x.TableName.Equals(tablename));
            }

            if (!string.IsNullOrEmpty(fromdate))
            {
                DateTime date = Convert.ToDateTime(fromdate);
                whereq += $"AND Date >='{date:MM/dd/yyyy}' ";// dbset = dbset.Where(o => DbFunctions.TruncateTime(o.Date) >= date);
            }

            if (!string.IsNullOrEmpty(todate))
            {
                DateTime date = Convert.ToDateTime(todate);
                whereq += $"AND Date <='{date:MM/dd/yyyy}' ";//dbset = dbset.Where(o => DbFunctions.TruncateTime(o.Date) <= date);
            }




            dbset = _context.Histories.FromSqlRaw($@"SELECT h.HistoryParentId, h.actionname, h.tablename, u.FirstName +' '+u.LastName as username,h.objectid,h.HistoryId, h.ColumnName, 
															'' OldValue, '' NewValue,h.date ,'' UserId, ipAddress ipAddress,pcName pcName,
																		'' CreateBy,'' LastUpdateBy,cast('false' as bit) IsDeleted, h.DeletedDate, h.DateCreated,NULL 'CreatedById', h.Date 'CreatedDate',NULL 'DeletedById',NULL 'LastChangedById', h.Date 'LastChangedDate'   FROM 
                                                                (
			                                                                SELECT distinct HistoryParentId,  actionname, tablename,max(username) as username , objectId, Min(HistoryId) as HistoryId,'' ColumnName, 
																		'' OldValue, '' NewValue,max(date) date ,'' UserId,
																		'' CreateBy,'' LastUpdateBy,cast('false' as bit) IsDeleted, max(date) DeletedDate, max(date) DateCreated, Min(ipAddress) as ipAddress,MAX(pcName)   pcName                                                        
																		FROM Histories  {whereq} 
                                                            GROUP BY HistoryParentId, actionname, tablename, objectId
															) h
															left join aspnetusers u on h.username = u.Id
                                                    ").AsQueryable();

            //dbset = _context.Histories.FromSqlRaw($@"SELECT distinct HistoryParentId,  actionname, tablename,max(username) as username , objectId, Min(HistoryId) as HistoryId,'' ColumnName, 
            //                                                '' OldValue, '' NewValue,max(date) date ,'' UserId,
            //                                                '' CreateBy,'' LastUpdateBy,cast('false' as bit) IsDeleted, max(date) DeletedDate, max(date) DateCreated                                                           
            //                                                FROM Histories {whereq} 
            //                                                GROUP BY HistoryParentId, actionname, tablename, objectId
            //                                                ").AsQueryable();

            dbset = dbset.OrderByDescending(x => x.Date);

            return new PagedList<GetHistoryViewModel>(_mapper.Map<IList<GetHistoryViewModel>>(dbset), pageNumber, pageSize);


            //  return new PagedList<History>(dbset, pageNumber, pageSize);
        }
    }
}
