using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using Data;

namespace Web.Models.DocumentsVM
{
    public class DocumentsViewModel
    {
    }

    public class UploadDocumentsViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime Date { get; set; }
        public int? DocumentTypeId { get; set; }
        public IFormFile File { set; get; }
        public Guid? PoliticalPartyId { get; set; }
        public int? LanguageId { get; set; }
        public Guid? CandidatePoliticPartyId { get; set; }
        public Guid? ObserversApplicationId { get; set; }
        public Guid? PollingStationChangeId { get; set; }
        public Guid? PollingCenterChangeId { get; set; }
        public Guid? SpecialNeedsVotersId { get; set; }
        public Guid? EmployeeId { get; set; }
        public Guid? ObserverOrganizationId { get; set; }
        public Guid? ObserverOrganizationPersonId { get; set; }
        public Guid? AbroadVotersId { get; set; }
        public Guid? ConditionalVoterId { get; set; }

        public string SimpleName { get; set; }
        public bool IsSeen { get; set; }
    }

    public class UploadDownloadableDocumentsViewModel
    {
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ElectionId { get; set; }
        public bool IsRequired { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }
        public ServiceType ServiceId { get; set; }
        public string InformationText { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
    }


    public class ShowDownloadableDocumentsViewModel
    {
        public IEnumerable<DownloadableDocumentsViewModel> DownloadableDocuments { get; set; }
        public int DocumetTypeId { get; set; }
        public int? ElectionIdSearch { get; set; }
        public int ListTypeId { get; set; }
        public int? ElectionId { get; set; }
        public ServiceType ServiceId { get; set; }
    }

    public class DownloadableDocumentsViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string FileName { get; set; }
        public string ElectionName { get; set; }


        public bool IsRequired { get; set; }
        public bool IsActive { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string InformationText { get; set; }
        public string ImageUrl { get; set; }


    }


    public class DownloadableDocuments4CompontentsViewModel
    {
        public int StartIndex { get; set; }
        public List<DownloadableDocumentsViewModel> docs { get; set; }

        public DownloadableDocuments4CompontentsViewModel()
        {
                docs = new List<DownloadableDocumentsViewModel>();
        }
    }
    public class EditDownloadableDocumentsViewModel
    {
        public Guid Id { get; set; }
        public bool IsRequired { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }
        public ServiceType ServiceId { get; set; }
        public string InformationText { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }

    }

    public class EmployeeContractDocumentsViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string DocumentName { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string FileName { get; set; }

    }

    public class DownloadDocumentsZipFileViewModel
    {
        public string FileName { get; set; }
    }


    public class ChangeDocumentViewModel
    {
        public Guid Id { get; set; }
    }


    public class SendEmailForRefusedViewModel
    {
        public string ToEmail { get; set; }
        public DocEmailViewModel docEmail { get; set; }
    }

    public class DocEmailViewModel
    {
        public List<string> Desc { get; set; }
        public List<string> typeName { get; set; }
    }

}





public class InserDoc4PolitaclPartyRegViewModel
{
    public Guid Id { get; set; }
    public string Path { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public int DocumentTypeId { get; set; }
    public IFormFile file { set; get; }
    public string DocumentName { get { return file?.FileName; } set { } }
    public Guid? PoliticalPartyId { get; set; }
    public int? LanguageId { get; set; } = 1;

}
public class UploadFileVpnvViewModel
{
    public IFormFile File { set; get; }
    public int DocumentTypeId { get; set; }
    public string DocumentName { get { return (File != null ? File.FileName : null); } set { } }

}