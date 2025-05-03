using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Data.Privileges;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OA_Web.Models;
using Services.Enum;
using Web.Models;
using Web.Models.CombinedNodes;
using Web.Models.KeyWords;
using Web.Models.LinkedNode;
using Web.Models.Lists;
using Web.Models.Localizations;
using Web.Models.Nodes;
using Web.Models.RolesAndPrivileges;
using Web.Models.Userss;

namespace Web.Mapper
{
    public class MappingProfileOld : Profile
    {
        private int langId = 1;
        private string langCode = "sq";
        private string _date = "";
        private List<CombinedNode> _CNhis = new List<CombinedNode>();

        private readonly IHttpContextAccessor _httpContextAccessor;
        public MappingProfileOld(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public MappingProfile()
        {

            // Add as many of these lines as you need to map your objects
            CreateMap<Product, ProductViewModel>();
            CreateMap<List, ListViewModel>().ForMember(d => d.ListTranslations, opt => opt.MapFrom((c, d) => { GetCurrentLangId(); return c.ListTranslations?.Where(x => x.LanguageId == langId).ToList(); }));
            CreateMap<IdentityRole, RolesViewModel>().ForMember(d => d.Name, opt => opt.MapFrom(c => c.NormalizedName));

            CreateMap<List, GetListViewModel>().ForMember(d => d.Name, opt => opt.MapFrom((c, d) => { GetCurrentLangId(); return c.ListTranslations?.Where(x => x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }));
            CreateMap<Language, LanguageViewModel>();
            CreateMap<Language, LanguageViewModel>().ReverseMap();
            CreateMap<AddUpdateLanguageListViewModel, Language>();

            CreateMap<Localization, LocalizationViewModel>();
            CreateMap<Localization, LocalizationViewModel>().ReverseMap();
            CreateMap<CreateUpdateLocalizationViewModel, Localization>();
            CreateMap<UpdateLocalizationViewModel, Localization>();
            CreateMap<CreateUpdateLocalizationViewModel, UpdateLocalizationViewModel>();
            CreateMap<AddUpdateListViewModel, List>().ReverseMap();
            CreateMap<ListType, AdministrativeUnitsListTypesViewModel>();
            CreateMap<ListType, GetListViewModel>();
            CreateMap<List, AdministrativeUnitsListViewModel>();
            CreateMap<AddUpdateRootTranslationsViewModel, RootTranslation>().ReverseMap();
            CreateMap<AddNodeViewModel, Node>();
            CreateMap<Node, UpdateNodeWithIncludesViewModel>().ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => s.NodeTranslations.Where(x => x.LanguageId == s.Root.LanguageOfCreatonId).FirstOrDefault()))
                                                              .ForMember(d => d.LinkRootId, map => map.MapFrom((s, d) => s.RootId));



            CreateMap<UpdateNodeViewModel, Node>();
            CreateMap<AddNodeTranslatonViewModel, NodeTranslation>();
            CreateMap<UpdateNodeTranslatonViewModel, NodeTranslation>();

            CreateMap<List, ListNodeTypeViewModel>()
                    //.ForMember(d => d.LanguageAdd, opt => opt.MapFrom(c => string.Join(" ", c.ListTranslations.Select(x => "<span class='flag-icon flag-icon-"+x.Language.Code+"'></span>") )));
                    .ForMember(d => d.LanguageAdd, opt => opt.MapFrom(c => string.Join(", ", c.ListTranslations.Select(x => x.Language.Code))));

            CreateMap<ListTranslation, ListTranslationViewModel>();
            CreateMap<CreateAdministrativeUnits, List>();
            CreateMap<CreateAdministrativeUnits, ListTranslation>();
            CreateMap<AdministrativeUnitsOrderIndexViewModel, List>();
            CreateMap<UpdateNoteTypeListViewModel, List>();
            CreateMap<List, UpdateNoteTypeListViewModel>();
            CreateMap<AddNoteTypeListViewModel, List>();
            CreateMap<AddNoteTypeListViewModel, ListTranslation>();
            CreateMap<ListTranslation, AdministrativeListTranslationViewModel>();
            CreateMap<CreateListTranslationViewModel, ListTranslation>();
            CreateMap<ListTranslation, ListNodeTypeTranslationViewModel>();

            CreateMap<AddNodeTypeTranslationViewModel, ListTranslation>();
            CreateMap<EditNodeTypeTranslationViewModel, ListTranslation>();
            CreateMap<ListTranslation, EditNodeTypeTranslationViewModel>();
            CreateMap<Root, GetRoot4NoteViewModel>()
                .ForMember(d => d.LanguageAdd, opt => opt.MapFrom(c => string.Join(", ", c.RootTranslations.Select(x => x.Language.Code))))
                .ForMember(d => d.ValidDateFrom, opt => opt.MapFrom(c => c.ValidDateFrom.HasValue ? c.ValidDateFrom.Value.ToShortDateString() : ""))
                .ForMember(d => d.ValidDateTo, opt => opt.MapFrom(c => c.ValidDateTo.HasValue ? c.ValidDateTo.Value.ToShortDateString() : ""))
                .ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => s.RootTranslations.FirstOrDefault(x => x.LanguageId == d.LanguageOfCreatonId)))
                .ForMember(d => d.CountArticles, map => map.MapFrom((s, d) => s.Nodes?.Count(x => x.RootId == s.Id && x.NodeTypeId == NodeTypeEnum.Article)));


            CreateMap<Root, GetRootForLinkedNodes>()
               .ForMember(d => d.ValidDateFrom, opt => opt.MapFrom(c => c.ValidDateFrom.HasValue ? c.ValidDateFrom.Value.ToShortDateString() : ""))
               .ForMember(d => d.ValidDateTo, opt => opt.MapFrom(c => c.ValidDateTo.HasValue ? c.ValidDateTo.Value.ToShortDateString() : ""))
               .ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => s.RootTranslations.FirstOrDefault(x => x.LanguageId == d.LanguageOfCreatonId)));

            CreateMap<Root, GetRootDetail4ApiViewModel>()
                .ForMember(d => d.Nodes, opt => opt.MapFrom(c => c.Nodes.Where(x => x.Parent == null)));

            CreateMap<Root, GetRootDetailViewModel>()
                    .ForMember(d => d.Nodes, opt => opt.MapFrom(c => c.Nodes.Where(x => x.Parent == null).OrderBy(x => x.OrderIndex).ToList()))
                    //.ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => s.RootTranslations.FirstOrDefault(x => x.LanguageId == s.LanguageOfCreatonId)))
                    .ForMember(d => d.RootTranslation, opt => opt.MapFrom((s, d) => { GetCurrentLangId(); return s.RootTranslations?.FirstOrDefault(x => x.LanguageId == langId); }))
                    .ForMember(d => d.LegalDocs, opt => opt.MapFrom(c => c.LegalDocs.Where(x => x.RootTypeId == RootTypeEnum.Law)))
                    .ForMember(d => d.ByLawLegalDocs, opt => opt.MapFrom(c => c.LegalDocs.Where(x => x.RootTypeId == RootTypeEnum.ByLaw)))
                    .ForMember(d => d.ValidDateFrom, opt => opt.MapFrom(c => c.ValidDateFrom.HasValue ? c.ValidDateFrom.Value.ToShortDateString() : ""))
                    .ForMember(d => d.ValidDateTo, opt => opt.MapFrom(c => c.ValidDateTo.HasValue ? c.ValidDateTo.Value.ToShortDateString() : ""));


            //here
            CreateMap<Root, GetRootDetail4LegalDocViewModel>()
                    .ForMember(d => d.Nodes, opt => opt.MapFrom(c => c.Nodes.Where(x => x.Parent == null).OrderBy(x => x.OrderIndex).ToList()))//
                                                                                                                                               //.ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => s.RootTranslations.FirstOrDefault(x => x.LanguageId == s.LanguageOfCreatonId)));
                    .ForMember(d => d.RootTranslation, opt => opt.MapFrom((s, d) => { GetCurrentLangId(); return s.RootTranslations?.FirstOrDefault(x => x.LanguageId == langId); }))
                    .ForMember(d => d.ValidDateFrom, opt => opt.MapFrom(c => c.ValidDateFrom.HasValue ? c.ValidDateFrom.Value.ToShortDateString() : ""))
                    .ForMember(d => d.ValidDateTo, opt => opt.MapFrom(c => c.ValidDateTo.HasValue ? c.ValidDateTo.Value.ToShortDateString() : ""));

            CreateMap<Root, RootNodesTranslationCheckViewModel>()
                    .ForMember(d => d.Nodes, opt => opt.MapFrom(c => c.Nodes.Where(x => x.Parent == null)))
                    .ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => s.RootTranslations.FirstOrDefault(x => x.LanguageId == s.LanguageOfCreatonId)));

            CreateMap<Root, GetRootViewModel>().ForMember(d => d.LanguageAdd, opt => opt.MapFrom(c => string.Join(", ", c.RootTranslations.Select(x => x.Language.Code))))
                .ForMember(d => d.RootLanguageApplicables, opt => opt.MapFrom(c => string.Join(", ", c.RootLanguageApplicables.Select(x => x.LanguageId))))
                .ForMember(d => d.RootLanguageNameApplicables, opt => opt.MapFrom(c => string.Join(", ", c.RootLanguageApplicables.Select(x => x.Language.Name))))
                .ForMember(d => d.ValidDateFrom, opt => opt.MapFrom(c => c.ValidDateFrom.HasValue ? c.ValidDateFrom.Value.ToShortDateString() : ""))
                .ForMember(d => d.ValidDateTo, opt => opt.MapFrom(c => c.ValidDateTo.HasValue ? c.ValidDateTo.Value.ToShortDateString() : ""))
                .ForMember(d => d.PublicationDate, opt => opt.MapFrom(c => c.PublicationDate.HasValue ? c.PublicationDate.Value.ToShortDateString() : ""))
                .ForMember(d => d.ApplicableDate, opt => opt.MapFrom(c => c.ApplicableDate.HasValue ? c.ApplicableDate.Value.ToShortDateString() : ""))
                .ForMember(d => d.RootTypeLanguageAdd, opt => opt.MapFrom((c, d) => { GetCurrentLangId(); return c.RootType.ListTranslations.Where(x => x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }))
                .ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.RootTranslations?.FirstOrDefault(x => x.LanguageId == langId); }))
                .ForMember(d => d.RootTranslationWithOutCurrenLanguage, map => map.MapFrom((c, d) => c.RootTranslations?.Where(x => x.LanguageId == c.LanguageOfCreatonId && x.RootId == c.Id).FirstOrDefault()))
                .ForMember(d => d.RootField4AQCUIS, opt => opt.MapFrom(c => string.Join(", ", c.RootField4ACQUISs.Select(x => x.Field4ACQUISId))))
                .ForMember(d => d.RootTranslationWithOutCurrenLanguage, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.RootTranslations?.FirstOrDefault(x => x.LanguageId == langId && x.RootId == s.Id); }));



            CreateMap<Root, GetRoot4ApiViewModel>().ForMember(d => d.LanguageAdd, opt => opt.MapFrom(c => string.Join(", ", c.RootTranslations.Select(x => x.Language.Code))))
                .ForMember(d => d.RootLanguageNameApplicables, opt => opt.MapFrom(c => string.Join(", ", c.RootLanguageApplicables.Select(x => x.Language.Name))))
                .ForMember(d => d.ValidDateFrom, opt => opt.MapFrom(c => c.ValidDateFrom.HasValue ? c.ValidDateFrom.Value.ToShortDateString() : ""))
                .ForMember(d => d.ValidDateTo, opt => opt.MapFrom(c => c.ValidDateTo.HasValue ? c.ValidDateTo.Value.ToShortDateString() : ""))
                .ForMember(d => d.PublicationDate, opt => opt.MapFrom(c => c.PublicationDate.HasValue ? c.PublicationDate.Value.ToShortDateString() : ""))
                .ForMember(d => d.ApplicableDate, opt => opt.MapFrom(c => c.ApplicableDate.HasValue ? c.ApplicableDate.Value.ToShortDateString() : ""));


            CreateMap<List, List4NodeViewModel>()
                  .ForMember(d => d.ListTranslation, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.ListTranslations?.Where(x => x.LanguageId == langId).FirstOrDefault(); }));

            CreateMap<CreateRootViewModel, Root>();
            CreateMap<AddRootLanguageApplicableViewModel, RootLanguageApplicable>();
            CreateMap<RootLanguageApplicable, GetRootLanguageApplicableViewModel>();
            CreateMap<RootLanguageApplicable, GetRootTranslationsLanguageIdViewModel>();
            CreateMap<GetRootTranslationsLanguageIdViewModel, LanguageViewModel>();
            CreateMap<SearchRootViewModel, SearchRootDTO>();
            CreateMap<UpdateRootViewModel, Root>();

            CreateMap<RootTranslation, RootTranslationViewModel>();

            CreateMap<Root, RootDetailsViewModel>().ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.RootTranslations?.FirstOrDefault(x => x.LanguageId == langId); }))
                                                   .ForMember(d => d.RootLanguageNameApplicables, opt => opt.MapFrom(c => string.Join(", ", c.RootLanguageApplicables.Select(x => x.Language.Name))))
                                                   .ForMember(d => d.LegalDocs, opt => opt.MapFrom(c => c.LegalDocs.Where(x => x.RootTypeId == RootTypeEnum.Law)))
                                                   .ForMember(d => d.RelatedLegalDocs, opt => opt.MapFrom(c => c.RelatedLegalDocs.Where(x => x.RootTypeId == RootTypeEnum.Law)))
                                                   .ForMember(d => d.ByLawLegalDocs, opt => opt.MapFrom(c => c.LegalDocs.Where(x => x.RootTypeId == RootTypeEnum.ByLaw)))
                                                   .ForMember(d => d.ByLawRelatedLegalDocs, opt => opt.MapFrom(c => c.RelatedLegalDocs))
                                                   .ForMember(d => d.CountArticles, map => map.MapFrom((s, d) => s.Nodes.Count(x => x.RootId == s.Id && x.NodeTypeId == NodeTypeEnum.Article)));


            CreateMap<UpdateRootViewModel, RootTranslation>();
            CreateMap<RootTranslation, GetRootTranslation4RootViewModel>()
                 .ForMember(d => d.SubTitle, map => map.MapFrom(c => c.Title.Substring(0, c.Title.Length % 100)))
                 .ForMember(d => d.Title, map => map.MapFrom((c, d) => { GetCurrentLangId(); return c.Root?.RootTranslations?.Where(x => x.LanguageId == langId).Select(x => x.Title).FirstOrDefault(); }));

            CreateMap<RootTranslation, GetRootTranslation4RootDetailViewModel>()
                 .ForMember(d => d.SubTitle, map => map.MapFrom(c => c.Title.Substring(0, c.Title.Length % 100)));

            CreateMap<RootTranslation, GetRootTranslationViewModel>()
                .ForMember(d => d.TranslationStatusLanguageAdd, opt => opt.MapFrom(c => c.TranslationStatus.ListTranslations.Select(x => x.Name).FirstOrDefault()));
            //   .ForMember(d => d.DateFrom, opt => opt.MapFrom(c => c.ValidDateFrom.Value.ToShortDateString()))
            //   .ForMember(d => d.DateTo, opt => opt.MapFrom(c => c.ValidDateTo.HasValue ? c.ValidDateTo.Value.ToShortDateString() : ""))
            //.ForMember(d => d.RootTypeLanguageAdd, opt => opt.MapFrom(c => string.Join(", ", c.RootType.ListTranslations.Select(x => x.Name))));
            //Documents
            CreateMap<Document, DocumentViewModel>()
                     //.ForMember(d => d.FileName, opt => opt.MapFrom(c => c.Id.ToString() + GetCodeFromCurrentLangId() + Path.GetExtension(c.DocumentName)));
                     .ForMember(d => d.FileName, opt => opt.MapFrom(c => c.Id.ToString() + LanguagesDictionary.GetCodeFromLanguageId()[c.LanguageId] + Path.GetExtension(c.DocumentName)));
            CreateMap<AddUpdateDocumentViewModel, Document>();
            CreateMap<Document, AddUpdateDocumentViewModel>();



            CreateMap<Node, GetNode4RootDetailApiViewModel>();
            CreateMap<Node, GetNode4RootDetailViewModel>()
                                               .ForMember(d => d.Nodes, opt => opt.MapFrom(c => c.Nodes.OrderBy(x => x.OrderIndex).ToList()))//
                                                                                                                                             //.ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => s.NodeTranslations.FirstOrDefault(x => x.LanguageId == s.Root.LanguageOfCreatonId)))
                                               .ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.NodeTranslations?.FirstOrDefault(x => x.LanguageId == langId); }))
                                               .ForMember(d => d.LinkedNodes, map => map.MapFrom((s, d) => s?.LinkedNodes?.Where(x => !x.IsDeleted)))
                                               .ForMember(d => d.LinkedNodeLinkedNodes, map => map.MapFrom((s, d) => s?.LinkedNodeLinkedNodes?.Where(x => !x.IsDeleted)));

            CreateMap<Node, GetNode4EditedRootDetailViewModel>()
                                               .ForMember(d => d.Nodes, opt => opt.MapFrom(c => c.Nodes.OrderBy(x => x.OrderIndex).ToList()))//
                                                                                                                                             //.ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => s.NodeTranslations.FirstOrDefault(x => x.LanguageId == s.Root.LanguageOfCreatonId)))
                                               .ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s?.NodeTranslations.FirstOrDefault(x => x.LanguageId == langId); }))
                                               .ForMember(d => d.LinkedNodes, map => map.MapFrom((s, d) => s?.LinkedNodes.Where(x => !x.IsDeleted)))
                                               .ForMember(d => d.HasCombinedLinkedNode, map => map.MapFrom((s, d) => s?.LinkedNodeLinkedNodes.Any(x => x.IsCombined)))
                                               .ForMember(d => d.DateValidFrom, map => map.MapFrom((s, d) => (s.HasDifferentValidity ? s.DateFrom : s?.Root.ValidDateFrom).Value.ToString("dd/MM/yyyy")))
                                               .ForMember(d => d.LinkedNodeLinkedNodes, map => map.MapFrom((s, d) => s?.LinkedNodeLinkedNodes.Where(x => !x.IsDeleted)))
                                                //.ForMember(d => _date, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["Date"]));
                                                //.ForMember(d => d.DateValidFrom, opt => opt.UseDestinationValue(res => res.Context.Options.Items["Date"]));
                                                .ForMember(d => d.DateValidFrom, opt => opt.MapFrom((src, dest, destMember, context) => { initialDate(context); return context.Items["Date"]; }));




            CreateMap<Node, GetNode4RootDetail_LegalDocViewModel>()
                                                .ForMember(d => d.Nodes, opt => opt.MapFrom(c => c.Nodes.OrderBy(x => x.OrderIndex).ToList()))//
                                               .ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) =>
                                               {
                                                   GetCurrentLangId();
                                                   //var item = s.NodeTranslations?.FirstOrDefault(x => x.LanguageId == s.Root?.LanguageOfCreatonId);
                                                   var item = s.NodeTranslations?.FirstOrDefault(x => x.LanguageId == langId);
                                                   if (item == null)
                                                   {
                                                       item = new NodeTranslation();
                                                   }
                                                   return item;
                                               }));



            CreateMap<Node, NodesTranslationCheckViewModel>()
                                               .ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => s.NodeTranslations.FirstOrDefault(x => x.LanguageId == s.Root.LanguageOfCreatonId)));


            CreateMap<Node, GetNodeViewModel>().ForMember(d => d.DateFrom, opt => opt.MapFrom(c => c.DateFrom.HasValue ? c.DateFrom.Value.ToShortDateString() : ""))
                                               .ForMember(d => d.DateTo, opt => opt.MapFrom(c => c.DateTo.HasValue ? c.DateTo.Value.ToShortDateString() : ""))
                                               .ForMember(d => d.NodeTypeName, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.NodeType?.ListTranslations?.Where(x => x.LanguageId == langId).FirstOrDefault()?.Name; }))
                                               .ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.NodeTranslations.FirstOrDefault(x => x.LanguageId == langId); }));


            CreateMap<Node, GetNodeParentListViewModel>().ForMember(d => d.DateFrom, opt => opt.MapFrom(c => c.DateFrom.HasValue ? c.DateFrom.Value.ToShortDateString() : ""))
                                               .ForMember(d => d.DateTo, opt => opt.MapFrom(c => c.DateTo.HasValue ? c.DateTo.Value.ToShortDateString() : ""))
                                               .ForMember(d => d.NodeTypeName, map => map.MapFrom((s, d) => s.NodeType?.ListTranslations?.FirstOrDefault()?.Name))
                                               .ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => s.NodeTranslations.FirstOrDefault(x => x.LanguageId == s.Root.LanguageOfCreatonId)));



            CreateMap<NodeTranslation, GetNodeTranslatonViewModel>().ForMember(d => d.LanguageOfCreatonId, map => map.MapFrom((s, d) => s.Node.Root.LanguageOfCreatonId))
                                                                    .ForMember(d => d.TranslationStatusName, map => map.MapFrom((s, d) => { GetCurrentLangId(); return d.TranslationStatusListTranslations.Where(x => x.ListId == s.TranslationStatusId && x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }));

            CreateMap<NodeTranslation, EditableNodeTranslationsViewModel>();
            CreateMap<UpdateNodeViewModel, NodeTranslation>();

            CreateMap<AddNodeTypeTranslationViewModel, NodeTranslation>();
            CreateMap<Node, Node4NodeTranslationVewModel>();
            CreateMap<Node, NodeId4NodeTranslationVewModel>();

            CreateMap<CreateRootViewModel, RootTranslation>();

            CreateMap<LinkedNodes, LinkedNodes4RootDetailViewModel>()//.ForMember(d => d.ChangeType, map => map.MapFrom((s, d) => s.ChangeType.ListTranslations.Where(x => x.Id == s.ChangeTypeId).Select(x => x.Name).FirstOrDefault()));
                 .ForMember(x => x.ChangeTypeNameTransitive, map => map.MapFrom((s, d) => s.ChangeType?.ListTranslations.Select(x => x.NameTransitive).FirstOrDefault()))
                 .ForMember(x => x.LinkedNodeRootTitle, map => map.MapFrom((s, d) => s.LinkedNode?.Root?.RootTranslations?.Select(x => x.Title).FirstOrDefault()))
                  .ForMember(x => x.Contents, map => map.MapFrom((s, d) => s.LinkedNode.NodeTranslations.Select(x => x.Content).FirstOrDefault()))
                  .ForMember(x => x.NodeNumber, map => map.MapFrom((s, d) => s.Node?.Nodes?.Select(x => x.Number).FirstOrDefault()))
                  .ForMember(x => x.LinkedNodeNumber, map => map.MapFrom((s, d) => s.LinkedNode?.Nodes?.Select(x => x.Number).FirstOrDefault()));

            CreateMap<LinkedNodes, LinkedNodes4EditedRootDetailViewModel>().PreserveReferences()//.ForMember(d => d.ChangeType, map => map.MapFrom((s, d) => s.ChangeType.ListTranslations.Where(x => x.Id == s.ChangeTypeId).Select(x => x.Name).FirstOrDefault()));
                 .ForMember(x => x.ChangeTypeNameTransitive, map => map.MapFrom((s, d) => s.ChangeType?.ListTranslations.Select(x => x.NameTransitive).FirstOrDefault()))
                 .ForMember(x => x.LinkedNodeRootTitle, map => map.MapFrom((s, d) => s.LinkedNode?.Root?.RootTranslations?.Select(x => x.Title).FirstOrDefault()))
                  .ForMember(x => x.Contents, map => map.MapFrom((s, d) => s.LinkedNode.NodeTranslations.Select(x => x.Content).FirstOrDefault()))
                  .ForMember(x => x.NodeNumber, map => map.MapFrom((s, d) => s.Node?.Nodes?.Select(x => x.Number).FirstOrDefault()))
                  .ForMember(x => x.CombinedNode, map => map.MapFrom((s, d) => s.CombinedNodes?.LastOrDefault()))
                  .ForMember(x => x.LinkedNodeNumber, map => map.MapFrom((s, d) => s.LinkedNode?.Nodes?.Select(x => x.Number).FirstOrDefault()));

            CreateMap<LinkedNodes, LinkedNode2Nodes4EditedRootDetailViewModel>().PreserveReferences()
                 .ForMember(x => x.NodeContents, map => map.MapFrom((s, d) => s.Node.NodeTranslations.Select(x => x.Content).FirstOrDefault()))
                 .ForMember(x => x.NodeRootTitle, map => map.MapFrom((s, d) => (s.Node?.Root?.RootTranslations?.Select(x => x.Title).FirstOrDefault())))
                 .ForMember(x => x.CombinedNode, map => map.MapFrom((s, d) => (s.CombinedNodes?.LastOrDefault())))
                 .ForMember(x => x.CombineText, map => map.MapFrom((s, d) => GetCombinedText(s)))
                 .ForMember(x => x.ChangeTypeName, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.ChangeType?.ListTranslations?.Where(x => x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }));

            CreateMap<LinkedNodes, LinkedNode2Nodes4RootDetailViewModel>().PreserveReferences()
                 .ForMember(x => x.NodeContents, map => map.MapFrom((s, d) => s.Node.NodeTranslations.Select(x => x.Content).FirstOrDefault()))
                 .ForMember(x => x.NodeRootTitle, map => map.MapFrom((s, d) => (s.Node?.Root?.RootTranslations?.Select(x => x.Title).FirstOrDefault())))
                 .ForMember(x => x.ChangeTypeName, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.ChangeType?.ListTranslations?.Where(x => x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }));

            CreateMap<LinkedNodes, LinkedNodesViewModel>().ForMember(d => d.ChangeType, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.ChangeType?.ListTranslations?.Where(/*x => x.Id == d.ChangeTypeId &&*/ x => x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }));
            CreateMap<LinkedNodes, LinkedNodes4HistoryViewModel>()
                .ForMember(d => d.ChangeType, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.ChangeType?.ListTranslations?.Where(/*x => x.Id == d.ChangeTypeId &&*/ x => x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }))
                 .ForMember(x => x.ListLinkedNodes, map => map.MapFrom((s, d) => { _CNhis = new List<CombinedNode>(); GetSingleCombinedText(s); return _CNhis; }));

            CreateMap<AddLinkedNodesViewModel, LinkedNodes>();
            CreateMap<UpdateLinkedNodesViewModel, LinkedNodes>();
            CreateMap<Node, GetNodeForLinkedNodeViewModel>()
                .ForMember(d => d.Translation, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.NodeTranslations.FirstOrDefault(x => x.LanguageId == s.Root.LanguageOfCreatonId); }))
                 ;


            CreateMap<Node, NodeHasRtfViewModel>();
            CreateMap<Root, GetListViewModel>().ForMember(d => d.Name, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.LawNr + " - " + s.RootTranslations.Where(x => x.LanguageId == langId).Select(x => x.Title).FirstOrDefault(); }));
            CreateMap<RelatedLegalDocs, GetRootDetailRelatedLegalDocViewModel>();
            CreateMap<RelatedLegalDocs, GetRootDetailRelatedLegalDocByLawViewModel>()
                .ForMember(d => d.RootTypeName, map => NewMethod(map));
            //RootTypeName

            CreateMap<RelatedLegalDocs, GetRootRelatedLegalDocViewModel>()
                //.ForMember(d => d.RelatedLegalTypeName, opt => opt.MapFrom(c => string.Join(", ", c.RelatedLegalType.ListTranslations.Select(x => x.Name))))
                .ForMember(d => d.RelatedLegalTypeName, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.RelatedLegalType?.ListTranslations?.Where(x => x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }))
                .ForMember(d => d.LastChangedDate, opt => opt.MapFrom(c => c.LastChangedDate.ToShortDateString()))
                                //.ForMember(d => d.LegalTypeName, opt => opt.MapFrom(c => string.Join(", ", c.RelatedLegalType.ListTranslations.Select(x => x.Language.Name))));
                                .ForMember(d => d.LegalTypeName, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.RelatedLegalType?.ListTranslations?.Where(x => x.LanguageId == langId).Select(x => x.Name).FirstOrDefault(); }));

            CreateMap<AddRelatedLegalDocsViewModel, RelatedLegalDocs>();
            CreateMap<AddByLawRelatedLegalDocsViewModel, RelatedLegalDocs>();
            CreateMap<AddRelatedLegalDocsViewModel, AddByLawRelatedLegalDocsViewModel>();
            CreateMap<UpdateRelatedLegalDocsViewModel, RelatedLegalDocs>();
            CreateMap<UpdateByLawRelatedLegalDocsViewModel, RelatedLegalDocs>();
            CreateMap<UpdateRelatedLegalDocsViewModel, UpdateByLawRelatedLegalDocsViewModel>();


            CreateMap<Root, GetRootsPartialViewModel>()
             .ForMember(d => d.ValidDateFrom, opt => opt.MapFrom(c => c.ValidDateFrom.HasValue ? c.ValidDateFrom.Value.ToShortDateString() : ""))
             .ForMember(d => d.ValidDateTo, opt => opt.MapFrom(c => c.ValidDateTo.HasValue ? c.ValidDateTo.Value.ToShortDateString() : ""))
             .ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => s.RootTranslations.FirstOrDefault(x => x.LanguageId == d.LanguageOfCreatonId)));


            CreateMap<Node, GetNodeDetailsViewModel>().ForMember(d => d.NodeTranslations, map => map.MapFrom((s, d) => s.NodeTranslations.Where(x => x.LanguageId == s.Root.LanguageOfCreatonId).FirstOrDefault()));


            CreateMap<Node, GetNodeListViewModel>().ForMember(d => d.DateFrom, opt => opt.MapFrom(c => c.DateFrom.HasValue ? c.DateFrom.Value.ToShortDateString() : ""))
                                          .ForMember(d => d.DateTo, opt => opt.MapFrom(c => c.DateTo.HasValue ? c.DateTo.Value.ToShortDateString() : ""))
                                           .ForMember(d => d.EditableNodeTranslations, map => map.MapFrom((s, d) => s.NodeTranslations.FirstOrDefault(x => x.LanguageId == s.Root.LanguageOfCreatonId)))
                                          .ForMember(d => d.NodeTypeName, map => map.MapFrom((s, d) => s.NodeType?.ListTranslations?.FirstOrDefault()?.Name));
            CreateMap<AppUser, UsersViewModel>();
            CreateMap<AddUser, AppUser>();
            CreateMap<UpdateUser, AppUser>();
            CreateMap<ChangePasswordModel, AppUser>();
            CreateMap<UpdateProfileModel, AppUser>();
            CreateMap<AppUser, ProfileIndex>();
            //SearchPortal
            CreateMap<SearchViewModel, PostSearchViewModel>();

            CreateMap<AddUserChangeHistory4NodeViewModel, UserChangeHistory>();
            CreateMap<AddUserChangeHistory4NodeTranslationViewModel, UserChangeHistory>();
            CreateMap<AddUserChangeHistory4RootViewModel, UserChangeHistory>();
            CreateMap<AddUserChangeHistory4RootTranslationViewModel, UserChangeHistory>();
            CreateMap<UpdateUserChangeHistory4NodeViewModel, UserChangeHistory>();
            CreateMap<UserChangeHistory, GetUserChangeHistoryViewModel>()
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(c => c.CreatedDate.ToString("dd/MM/yyyy HH:mm")))
                .ForMember(d => d.UpdatedDate, opt => opt.MapFrom(c => c.LastChangedDate.ToString("dd/MM/yyyy HH:mm")));


            CreateMap<Root, GetRootDetail4DocScrollViewModel>()
                .ForMember(d => d.Nodes, opt => opt.MapFrom(c => c.Nodes.Where(x => x.Parent == null)))
                .ForMember(d => d.RootTranslation, map => map.MapFrom((s, d) => s.RootTranslations.FirstOrDefault(x => x.LanguageId == s.LanguageOfCreatonId)));

            CreateMap<AddRoot4FieldACQUISViewModel, RootField4ACQUIS>();
            CreateMap<int, AddRoot4FieldACQUISViewModel>().ForMember(d => d.Field4ACQUISId, opt => opt.MapFrom(c => c));


            CreateMap<Document, ScrollDocumentViewModel>()
                     .ForMember(d => d.FileName, opt => opt.MapFrom(c => c.Id.ToString() + GetCodeFromCurrentLangId() + Path.GetExtension(c.DocumentName)));

            CreateMap<RootTranslation, GetRootTranslation4RootWithOutCurrenLanguageViewModel>();
            CreateMap<DataInputQCLog, GetDataInputQCLogViewModel>().ForMember(d => d.CreatedDate, opt => opt.MapFrom(c => c.CreatedDate.ToString("dd/MM/yyyy HH:mm")));

            CreateMap<ActionRoot, GetActionRootViewModel>();
            CreateMap<ActionRoot, GetUserActionRootRestRightViewModel>().ForMember(d => d.Name, opt => opt.MapFrom(c => c.NameAl));

            CreateMap<UserActionRootRestRight, GetUserActionRootRestRightViewModel>();
            CreateMap<GetUserActionRootRestRightViewModel, UserActionRootRestRight>();
            CreateMap<IdentityRole, GetIdentityRoleViewModel>();


            CreateMap<AddCombinedNodeViewModels, CombinedNode>();
            CreateMap<CombinedNode, CombinedNodeViewModels>();
            CreateMap<CombinedNode, GetCombinedNode4EditedRootViewModel>();
            CreateMap<NodeTranslation, CombineNodeTranslatonViewModel>();
            CreateMap<UpdateCombinedNodeViewModels, CombinedNode>();
            CreateMap<CombinedNode, GetCombinedNode4SingleHistoryViewModels>()
                .ForMember(d => d.LinkedNodeNodeValidDateFrom, opt => opt.MapFrom((s, d) => d.LinkedNodeNodeRootValidDateFrom.HasValue ? d.LinkedNodeNodeRootValidDateFrom.Value.ToShortDateString() : ""));
            CreateMap<Node, GetNodeForLinkedNodeSingleHistoryViewModel>()
                                .ForMember(d => d.TranslationContent, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.NodeTranslations.FirstOrDefault(x => x.LanguageId == s.Root.LanguageOfCreatonId)?.Content; }));
            //CreateMap<Node, NodeHistoryViewModel>();

            CreateMap<KeyWord, KeyWordViewModels>().ForMember(d => d.KeyWordTranslations, map => map.MapFrom((s, d) => { GetCurrentLangId(); return s.KeyWordTranslations.FirstOrDefault(x => x.LanguageId == langId); }));
            CreateMap<AddKeyWordViewModels, KeyWord>();
            CreateMap<UpdateKeyWordViewModels, KeyWord>();
            CreateMap<UpdateKeyWordViewModels, KeyWordTranslation>();


            CreateMap<AddKeyWordViewModels, KeyWordTranslation>();
            CreateMap<AddKeyWordTranslationViewModels, KeyWordTranslation>();
            CreateMap<KeyWordTranslation, KeyWordTranslationViewModels>();
            CreateMap<UpdateKeyWordTranslationViewModels, KeyWordTranslation>();






        }
        private void initialDate(ResolutionContext context)
        {
            if (context != null && context.Items["Date"] != null)
            {
                _date = context.Items["Date"] + "";

            }
        }

        private string GetCombinedText(LinkedNodes s)
        {
            var date = _date;
            if (s.IsCombined && s.Node != null && s.Node.LinkedNodes != null)
            {
                var rez = "";
                var linkedNode = s.Node.LinkedNodes.Count() > 1 ? s.Node.LinkedNodes.FirstOrDefault(x => x.Id == s.Id) : s.Node.LinkedNodes.FirstOrDefault();
                //foreach (var item in s.Node.LinkedNodes)
                {
                    rez += GetCombined2Text(linkedNode, s.Id.ToString());
                }
                return rez;

            }
            else if (!s.IsCombined && s.Node != null)
            {
                _date = "";
                return s.Node?.NodeTranslations?.FirstOrDefault()?.Content;
            }
            else
            {
                _date = "";
                return s.CombinedNodes?.FirstOrDefault()?.Content;
            }
        }
        private void GetSingleCombinedText(LinkedNodes s)
        {
            var nextNote = s.Node?.LinkedNodeLinkedNodes?.FirstOrDefault()?.Node;

            if (nextNote != null && s.IsCombined && s.Node != null && s.Node.LinkedNodeLinkedNodes != null)
            {
                AddCombinet2List(s);
                GetSingleCombinedText(s.Node.LinkedNodeLinkedNodes.FirstOrDefault());
            }
            else
            {
                AddCombinet2List(s);
            }

            void AddCombinet2List(LinkedNodes s)
            {
                CombinedNode cn = s?.CombinedNodes?.FirstOrDefault();
                if (cn == null)
                {
                    cn = new CombinedNode();
                }
                cn.Content = s.Node?.NodeTranslations?.FirstOrDefault()?.Content;
                _CNhis.Add(cn);
            }
        }
        private string GetCombined2Text(LinkedNodes s, string LinkedNodeId = "")
        {
            bool hasFdt = DateTime.TryParse(_date, out DateTime dt);

            var nextNote = s.Node?.LinkedNodeLinkedNodes?.FirstOrDefault()?.Node;
            bool hasNodes = nextNote != null && nextNote.DateFrom.HasValue && hasFdt ? nextNote.DateFrom <= dt : true;

            if (s.Node != null && s.Node.LinkedNodeLinkedNodes != null && hasNodes)
            {
                bool hasntChild = s.Node.LinkedNodeLinkedNodes.FirstOrDefault()?.Node == null;
                if (hasntChild && s.IsCombined)
                {
                    _date = "";

                    // if (s.Id.ToString() == LinkedNodeId)
                    {
                        //return s.CombinedNodes.FirstOrDefault()?.Content + "," + s.CombinedNodes.FirstOrDefault()?.Id + " nodeId=" + s.NodeId + " LinkedNodeId=" + s.Id + " SLinkedNodeId=" + LinkedNodeId;
                        return s.CombinedNodes.FirstOrDefault()?.Content;
                    }
                    //else
                    //{
                    //    return "";
                    //}
                }
                else if (hasntChild && !s.IsCombined)// me i marr shenimet prejt Node-itg
                {
                    _date = "";
                    return s.Node?.NodeTranslations?.FirstOrDefault()?.Content;
                }
                else
                {
                    return GetCombined2Text(s.Node.LinkedNodes.FirstOrDefault(), s.Id.ToString());
                }


            }
            else if (!s.IsCombined && s.Node != null && !hasNodes)
            {
                _date = "";
                return s.Node?.NodeTranslations?.FirstOrDefault()?.Content;
            }
            else
            {
                return s.CombinedNodes?.FirstOrDefault()?.Content;
            }

        }

        private static void NewMethod(IMemberConfigurationExpression<RelatedLegalDocs, GetRootDetailRelatedLegalDocByLawViewModel, string> map)
        {
            map.MapFrom((s, d) =>
            {
                if (s.RelatedLegalType != null && s.RelatedLegalType.ListTranslations != null && s.RelatedLegalType.ListTranslations.Count() > 0)
                {
                    return s.RelatedLegalType.ListTranslations.Where(x => x.Id == s.RelatedLegalTypeId).Select(x => x.Name).FirstOrDefault();
                }
                return "";
            }
            );
        }

        private void GetCurrentLangId()
        {
            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName.ToUpperInvariant();

            langId = LanguagesDictionary.LanguagesAsDictionary()[lang];
        }

        private string GetCodeFromCurrentLangId()
        {
            GetCurrentLangId();
            langCode = LanguagesDictionary.GetCodeFromLanguageId()[langId];
            return langCode;
        }

        internal static T Map<T>(List<List> dbResult)
        {
            throw new NotImplementedException();
        }

    }
    public class CustomResolver : IValueResolver<Node, GetNode4EditedRootDetailViewModel, string>
    {
        public string Resolve(Node source, GetNode4EditedRootDetailViewModel destination, string member, ResolutionContext context)
        {
            return source.Notes;
        }


    }
    public interface IValueResolver<in TSource, in TDestination, TDestMember>
    {
        TDestMember Resolve(TSource source, TDestination destination, TDestMember destMember, ResolutionContext context);
    }
}
