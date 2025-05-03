using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Web.Infrastructure;
using X.PagedList;

namespace Web.Controllers
{
    [Authorize]
    [MiddlewareFilter(typeof(LocalizationPipeline))]
    public class UserChangeHistoryController : BaseController
    {
        private readonly IMapper _mapper;
     
        private readonly IHttpContextAccessor _httpContextAccessor;

        //public UserChangeHistoryController(IUserChangeHistoryService userChangeHistoryService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        //{
        //    _mapper = mapper;
        //    _httpContextAccessor = httpContextAccessor;
        //}

        //public IActionResult Index(int page = 1, string searchName = null, string lawNr = null)
        //{
        //    var pageSize = 10;

        //    IEnumerable<UserChangeHistory> userchangesdb = new List<UserChangeHistory>();

        //    if (User.IsInRole("Administrator"))
        //    {
        //        userchangesdb = _userChangeHistoryService.GetAllByUserId(searchName, lawNr).ToPagedList(page, pageSize);
        //    }
        //    else
        //    {
        //        userchangesdb = _userChangeHistoryService.GetByUserId(UserId, lawNr).ToPagedList(page, pageSize);
        //    }

        //    var userchanges = _mapper.Map<List<GetUserChangeHistoryViewModel>>(userchangesdb);
        //    ViewBag.List = userchangesdb;
        //    ViewBag.searchName = searchName;
        //    ViewBag.lawNr = lawNr;
        //    return View(userchanges);
        //}

        //public IActionResult Detail(ChangeType changeType, Guid RootId, Guid NodeId, Guid RootTranslationId, Guid NodeTranslationId)
        //{

        //    switch (changeType)
        //    {
        //        case ChangeType.Root:
        //            {
        //                var root = _rootService.GetById(RootId);
        //                return RedirectToAction("Search", "Root", new { LawNr = root.LawNr });
        //            }
        //        case ChangeType.RootTranslation:
        //            {
        //                var roottran = _rootTranslationService.GetById(RootTranslationId);
        //                return RedirectToAction("Translation", "Node", new { RootId = roottran.RootId });
        //            }
        //        case ChangeType.Node:
        //            { return RedirectToAction("Edit", "Node", new { NodeId = NodeId }); }
        //        case ChangeType.NodeTranslation:
        //            {
        //                var nodetran = _nodeTranslationService.GetById(NodeTranslationId);
        //                return RedirectToAction("Translation", "Node", new { NodeId = nodetran.NodeId, RootId = nodetran.Node.RootId });
        //            }
        //        default: { return RedirectToAction("UserChangeHistory", "Index"); }
        //    }

        //}
    }
}
