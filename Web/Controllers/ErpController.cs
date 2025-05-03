using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Emails;
using Services.Orders;
using SimpleEmailApp.Services.EmailService;
using System.Collections.Generic;
using System.Linq;
using Web.Models;
using X.PagedList;

namespace Web.Controllers
{
    public class ErpController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IErpTempService _erpTempService;


        public ErpController(IMapper mapper, IErpTempService erpTempService)
        {
            _mapper = mapper;
            _erpTempService = erpTempService;
        }
        [Authorize]
        public IActionResult Index(int page =1)
        {
            int pageSize = 50;
            var model = new ListErpTempViewModel();
            var erpTemp = _erpTempService.GetAll().OrderByDescending(o => o.CreatedDate);
            model.Items = _mapper.Map<List<ErpTempViewModel>>(erpTemp).ToPagedList(page, pageSize);
            return View(model);
        }
    }
}
