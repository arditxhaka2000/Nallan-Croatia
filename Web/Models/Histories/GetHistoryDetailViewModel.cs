using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Web.Models.Histories
{
    public class GetHistoryDetailViewModel
    {
        public ActionName ActionName { get; set; }
        public DateTime? Date { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string UserUserName { get; set; }
        public string PcName { get; set; } 
        public string IpAddress { get; set; }
    }

    public class GetHistoriesViewModel
    {
        public GetHistoriesViewModel()
        {
            Histories = new List<GetHistoryViewModel>();
            Tables = new List<string>();
        }

        public IList<string> Tables { get; set; }
        public string SelectedTable { get; set; }
        public string SearchUserName { get; set; }
        public string SearchFrom { get; set; }
        public string SearchTo { get; set; }
        public IList<GetHistoryViewModel> Histories { get; set; }
        public IPagedList<GetHistoryViewModel> IPagedListHistories { get; set; }

    }

    public class GetHistoryViewModel
    {
        public ActionName ActionName { get; set; }
        public DateTime Date { get; set; }
        public string TableName { get; set; }
        public string username { get; set; }
        public string ObjectId { get; set; }
        public Guid HistoryId { get; set; }
        public Guid HistoryParentId { get; set; }
        public string PcName { get; set; }
        public string IpAddress { get; set; }
    }

    public class HistoryViewModel
    {
        public Guid HistoryId { get; set; }

        public Guid HistoryParentId { get; set; }

        public ActionName ActionName { get; set; }

        public string TableName { get; set; }

        public Guid ObjectId { get; set; }

        public string ColumnName { get; set; }


        public DateTime Date { get; set; }

        public string username { get; set; }

    }
}
