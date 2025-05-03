using Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.DocumentsVM;
using X.PagedList;

namespace Web.Models
{
    public class DocumentViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public bool IsRefusedByAbroadVoters { get; set; }
        public bool IsRefusedByPoliticalParty { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
        public int? TypeId { get; set; }
        public int? LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string SimpleName { get; set; }
        public int? DocumentTypeId { get; set; }
        public int CentralListId { get; set; }
        public string SeenByUserName { get;   set; }

        public bool IsSeen { get; set; } = false;
     
        public string  SeenByUserId { get; set; }
    }
    public class DocListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        //public virtual List<List> Lists { get; set; }
    }
    public class DocumentListViewModel
    {
        public List<SearchDocumentViewModel> SearchLists { get; set; }
        public List<DocumentViewModel> Documents { get; set; }
        public Guid RootId { get; set; }
        public int ProjectId { get; set; }
        public int SubProjectId { get; set; }
        public int SubProjectItemId { get; set; }
        public int SubprojectSubItemId { get; set; }

        public int PermitId { get; set; }
        public List<LanguageViewModel> Languages { get; internal set; }
        public int InvestmentCompanyId { get; internal set; }
        public int ShareholderId { get; internal set; }
        public string docName { get; set; }
    }

    public class AddUpdateDocumentViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime Date { get; set; }
        public int? TypeId { get; set; }
        public int? AccessId { get; set; }
        public int DocumentTypeId { get; set; }
        public IFormFile File { set; get; }
        public List<DocumentViewModel> Documents { get; set; }
        public Guid? RootId { get; set; }
        public Guid? PoliticalPartyId { get; set; }
        public int? LanguageId { get; set; }
        public int? ProjectId { get; set; }
        public int? SubProjectId { get; set; }
        public int? PermitId { get; set; }
        public int? InvestmentCompanyId { get; set; }
        public int? SubprojectSubItemId { get; set; }
        public int? ShareholderId { get; set; }

    }
    public class SearchDocumentViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime Date { get; set; }
        public Guid? RootId { get; set; }
    }

    public class ScrollDocumentViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
        public int? TypeId { get; set; }
        public int? LanguageId { get; set; }
        public string LanguageName { get; set; }

        public bool FileExists { get; set; }
        public LanguageViewModel Language { get; set; }

    }
    public class UploadFileForAnyTable
    {
        public List<UploadDataForFileViewModel> UploadDocuments { get; set; }
        public List<IFormFile> Files { get; set; }
    }

    public class UploadDataForFileViewModel
    {
        public int? DocumentTypeId { get; set; }
        public string PoliticalPartyId { get; set; }

    }
    public class ReturnMsgApiViewModel
    {
        public string RecordId { get; set; }
        public bool IsSucceed { get; set; }
    }
}
