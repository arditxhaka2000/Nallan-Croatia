using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services.Histories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Controllers;
using Web.Models.Histories;
using Web.Providers;

namespace Web.Components
{
    [Authorize]
    public class HistoriesController : BaseController
    {
        private readonly ApplicationContext _context;
        private readonly IHistoryService _historyService;
        private readonly IMapper _mapper;


        public HistoriesController(IHistoryService historyService, IMapper mapper, ApplicationContext context)
        {
            _historyService = historyService;
            _mapper = mapper;
            _context = context;
        }
        // GET: Histories
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    GetHistoriesViewModel model = new GetHistoriesViewModel();
        //    model.Tables = _historyService.GetAllTablesDistincAll().ToList();
        //    model.Histories = Mapper.Map<List<GetHistoryViewModel>>(_historyService.GetDistincAll().ToList());
        //    return View(model);
        //} 
        public JsonResult GetDetail(string objectId)
        {
            Guid objId = new Guid(objectId);
            List<GetHistoryDetailViewModel> historyDetails = new List<GetHistoryDetailViewModel>();

            historyDetails = _mapper.Map<List<GetHistoryDetailViewModel>>(_historyService.GetByObjectId(objId).ToList());

            return Json(historyDetails);

        }

        public IActionResult Index(int page = 1, string username = null, string tablename = null, string fromdate = null, string todate = null, int oldMode = 0)
        {
            int pageSize = 10;

            GetHistoriesViewModel model = new GetHistoriesViewModel();
            model.SelectedTable = tablename;
            model.SearchTo = todate;
            model.SearchFrom = fromdate;
            model.SearchUserName = username;

            model.Tables = _historyService.GetAllTablesDistincAll().ToList();

            HistoryProvider statisticProvider = new HistoryProvider(_context, _mapper);
            var pagedListData = statisticProvider.GetAll(username, tablename, fromdate, todate, page, pageSize);
            if (oldMode == 2)
            {
                pagedListData = statisticProvider.GetAll2(username, tablename, fromdate, todate, page, pageSize);
            }
            model.IPagedListHistories = pagedListData;
            return View(model);

        }
    }
}
