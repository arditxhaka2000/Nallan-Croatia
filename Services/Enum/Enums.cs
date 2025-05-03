using System;
using System.Collections.Generic;
using System.Text;

namespace System.Collections.Generic
{
    public static class ListTypeEnum
    {
        public const int ElectionType = 1,//ex: Zgj. lokale, komunale, asamble komunale 
            Gender = 3, // ex: M , F
            PollingCenterChangeDecision = 4,// Ndrrimi i qendres se votimit: Ne SHqyrtim, Aprovim, Refuzim
            DocumentType = 5, // ex :  Regjistrimi i partisë politike ,  	Regjistrimi i partisë politike, etc
            PersonType = 6, //ex: person kontaktues, perfaqesues i partis etj.
            TypePoliticalParty = 10,//ex : parti politike parlamentare, koalucion, etc.
            PoliticalPartyDecision = 19, // ex: Dobet, mesatar, shume mire, shkelqyeshem...
            PollingCenterChangeDocType = 28, // Polling center change document types
                                             //     AbroadVoterType = 100,//32,
            AbroadVoterType = 32,
            ContactPerson = 23,
            AbroadUserRefuzionReason = 90,//34
            CitizenInitiative = 33,//Aplikim si iniciative qytetare
            Decision_Approve = 3,
            DiplomaticRelationType = 110,
            PollingCenterChangesRefuzionReason = 120,//34B
            Decision_Refuse = 4,
            VPNVTypes = 121,
            DecisionPoliticalParty = 122,// vendimi per partite politike ex. C'regjistrim, aporvimi etj...
            CategoriesVPNV = 123,
            NursingHomes = 124,
            Hospital = 125,
            Shelters = 126,
            SpecialNeedsVotersRefuzionReason = 130;
    }

}
namespace Services.Enum
{

    public static class ListItemType
    {
        //vendim per ndryshim
        public const int Amendment = 5,
            AimofProject = 2,
            Shareholders = 3,
            DocumentType = 4;

    }

    public struct LanguagesEnum
    {
        public const int AL = 1, EN = 2, SR = 3, TR = 4, BS = 5;
    }

    public enum Mode
    {
        CanView = 1,
        CanEit = 2,
        CanDelete = 3
    }
    public static class VotersType
    {
        public const int
            Regularly = 96,
            Abroad = 97,
            LimitedAbilities = 98;
    }


    // public enum  ServiceType
    //{
    //        PoliticalParty = 1,
    //        ObserverApplications = 2,
    //        VPNV = 3,
    //        AbroadVoters = 4,
    //        SpecialNeedsVoters = 5  
    //}




    public static class AbroadVoterType
    {
        public const int Embassy = 20,
            Post = 21;

    }

    public class LanguagesDictionary
    {
        public static Dictionary<string, int> LanguagesAsDictionary()
        {
            var dict = new Dictionary<string, int>();

            dict.Add("SQ", LanguagesEnum.AL);
            dict.Add("EN", LanguagesEnum.EN);
            dict.Add("SR", LanguagesEnum.SR);
            dict.Add("TR", LanguagesEnum.TR);
            dict.Add("BS", LanguagesEnum.BS);
            return dict;
        }
        public static Dictionary<int?, string> GetCodeFromLanguageId()
        {
            var dict = new Dictionary<int?, string>();
            dict.Add(LanguagesEnum.AL, "sq");
            dict.Add(LanguagesEnum.EN, "en");
            dict.Add(LanguagesEnum.SR, "sr");
            dict.Add(LanguagesEnum.TR, "tr");
            dict.Add(LanguagesEnum.BS, "bs");
            return dict;
        }

    }
    public class MunicipalitiesDictonary
    {
        public static Dictionary<string, int?> municipalitiesDictonary()
        {
            var dict = new Dictionary<string, int?>();

            dict.Add("Deçan", 1);
            dict.Add("Gjakovë", 2);
            dict.Add("Gllogoc", 3);
            dict.Add("Gjilan", 4);
            dict.Add("Dragash", 5);
            dict.Add("Istog", 6);
            dict.Add("Kaçanik", 7);
            dict.Add("Klinë", 8);
            dict.Add("Fushë Kosovë", 9);
            dict.Add("Kamenicë", 10);
            dict.Add("Mitrovicë", 11);
            dict.Add("Leposaviq", 12);
            dict.Add("Lipjan", 13);
            dict.Add("Novobërdë", 14);
            dict.Add("Obiliq", 15);
            dict.Add("Rahovec", 16);
            dict.Add("Pejë", 17);
            dict.Add("Podujevë", 18);
            dict.Add("Prishtinë", 19);
            dict.Add("Prizren", 20);
            dict.Add("Skënderaj", 21);
            dict.Add("Shtime", 22);
            dict.Add("Shtërpcë", 23);
            dict.Add("Suharekë", 24);
            dict.Add("Ferizaj", 25);
            dict.Add("Viti", 26);
            dict.Add("Vushtrri", 27);
            dict.Add("Zubin Potok", 28);
            dict.Add("Zveçan", 29);
            dict.Add("Malishevë", 30);
            dict.Add("Hani i Elezit", 31);
            dict.Add("Mamushë", 32);
            dict.Add("Junik", 33);
            dict.Add("Kllokot", 34);
            dict.Add("Graçanicë", 35);
            dict.Add("Ranillug", 36);
            dict.Add("Partesh", 37);
            dict.Add("Mitrovica e Veriut", 38);


            return dict;
        }

    }

}

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    //TODO: duhet me i shtu listen e kontrollereve tone
    public enum ControllerEnum
    {
        Users,
        List,
        Localization,
        Document,
        Administration,
        ProductProduct,
        Municipality,
        CandidateDetailPoliticParty,
        CandidateOpositeGender,
        CandidatePoliticalPartyCoalition,
        CandidatePoliticalPartyPerson,
        CandidatePoliticalPartySupport,
        CandidatePoliticParty,
        SignatureCard,
        PoliticalParty,
        PollingCenter,
        Voters,
        Election,
        Employee,
        EmployeeAttachments,
        EmployeeEducationTraining,
        EmployeeEvaluate,
        EmployeeEvaluateTraining,
        EmployeeLanguageSkill,
        Employeement,
        EmployeeReference,
        EmployeeSkill,
        EmployeeWorkExperience,
        ObserversApplication,
        Report,
        UserChangeHistory,
        SpecialNeedsVoter,
        AbroadVoter,
        PoliticalParty_ListOfCitizenInciatives, 
        PoliticalParty_ListOfIndipedentCandidate,
        PollingCenterChangeList,
        SpecialNeedsVoters,
        ListOfRequestsAbroadVoters,
        ServicesConfigurations,
        Emails,
        Reports

    }

    public enum ServiceConfigurationName
    {
        FindChangePollingCenter = 1008,
        PoliticalPartyRegister = 1009,
        VPNVRegister = 1010,
        AbroadVoters = 1011,
        ApplyForParticipation = 1012,
        ApplyForCertification = 1013,
        ApplyForJob = 1014,
        KVV = 1015,
        ApplyForObservers = 1016
    }
}
