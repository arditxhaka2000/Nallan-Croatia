using AutoMapper;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Services.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Components
{
    public class Languages : ViewComponent
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;
        private string _currentLanguage;

        public Languages(IMapper mapper, ILanguageService languageService)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var lang = CurrentLanguage;
            var dbResult = _languageService.GetAllActive();
            var model = new LanguageListViewModel();
            model.list = _mapper.Map<List<LanguageViewModel>>(dbResult);
            model.CurrentLanguage = lang;
            return View(model);
        }

        private string CurrentLanguage
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentLanguage))
                {
                    return _currentLanguage;
                }

                if (string.IsNullOrEmpty(_currentLanguage))
                {
                    var feature = HttpContext.Features.Get<IRequestCultureFeature>();
                    _currentLanguage = feature.RequestCulture.Culture.TwoLetterISOLanguageName.ToLower();
                }
                return _currentLanguage;
            }
        }
    }
}
