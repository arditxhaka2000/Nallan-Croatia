using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    /// <summary>
    /// Get_ELI_Root4ApiV2 eshte verzioni 2 i api per ELI- standartin
    /// </summary>
    public class Get_ELI_Root4ApiV2
    {
        /// <summary>
        /// xk = country code
        /// </summary>
        public string jurisdiction { get; set; }
        /// <summary>
        /// md= institucioni, ministria e drejtesise, fusha agent ose subagent
        /// </summary>
        public string agent { get; set; }
        /// <summary>
        /// 2019 = viti i publikimit te ligjit
        /// </summary>
        public int pdy { get; set; }
        /// <summary>
        /// 04 = muaji i publikimit
        /// </summary>
        public int pdm { get; set; }
        /// <summary>
        /// 24 = dita e publikimit
        /// </summary>
        public int pdd { get; set; }
        /// <summary>
        /// law = lloji i ligjit {type}, {subtype}
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// {04}/L-001 = ligji {naturalidentifier}
        /// </summary>
        public string naturalidentifier { get; set; }
        /// <summary>
        /// 04/{L-001} = ligji {naturalidentifier_p2}
        /// </summary>
        public string naturalidentifier_p2 { get; set; }
        /// <summary>
        /// Noter = {level} - Pra i bjen qe munet me shkru noter, financa ose keywork dicka 
        /// </summary>
        public string level { get; set; }
        /// <summary>
        /// 2019-04-12 = point in time 
        /// </summary>
        public string pod { get; set; }
        /// <summary>
        /// BaseFormat = {version}
        /// </summary>
        public string version { get; set; }//
        public string lang { get; set; } //sq = language
        /// <summary>
        ///   pdf = formati pdf ose html
        /// </summary>
        public string format { get; set; }
        /*
         /eli/{jurisdiction}/{agent}/{sub-agent}/{year}/{month}/{day}/{type}/{natural identifier}/{level 1…}/{point in time}/{version}/{language}
         /{-eli}/{-xk}/{-md}/{2019}/{04}/{-24}/{law}/{noteri}/{2019-04-12}/{BaseFormat}/{sq}/{html} 
        xk = country code
        md= institucioni, ministria e drejtesise, fusha agent ose subagent
        2019 = viti i publikimit te ligjit
        04 = muaji i publikimit
        24 = dita e publikimit
        law = lloji i ligjit {type}, {subtype}
        04/L-001 = ligji {naturalidentifier}
        Noter = {level} - Pra i bjen qe munet me shkru noter, financa ose keywork dicka 
        2019-04-12 = point in time
        BaseFormat = {version}
        sq = language
        pdf = formati pdf ose html 
         */
    }
    /// <summary>
    /// model to get root by number
    /// </summary>
    public class Get_ELI_Root4ApiByNumer
    {

        /// <summary>
        /// 2019 = viti i publikimit te ligjit
        /// </summary>
        public int pdy { get; set; }
        /// <summary>
        /// 04 = muaji i publikimit
        /// </summary>
        public int pdm { get; set; }
        /// <summary>
        /// 24 = dita e publikimit
        /// </summary>
        public int pdd { get; set; }

        /// <summary>
        /// {04}/L-001 = ligji {naturalidentifier} (part 1 of LawNumer)
        /// </summary>
        public string naturalidentifier { get; set; }
        /// <summary>
        /// 04/{L-001} = ligji {naturalidentifier_p2} (part 2 of LawNumer)
        /// </summary>
        public string naturalidentifier_p2 { get; set; }

        public int nodetype { get; set; } //book,pharagraph ,... 
        public string lang { get; set; } //sq = language
        public string textSearchBy { get; set; }
        public Guid RootId { get; set; }

        public string lawNumer
        {
            get
            {

                string searchLawNr = naturalidentifier;
                if (!string.IsNullOrWhiteSpace(naturalidentifier_p2))
                {
                    searchLawNr = string.Concat(searchLawNr, @"/", naturalidentifier_p2);
                    //searchLawNr = searchLawNr.Replace(@"/", @"");
                }
                return searchLawNr;
            }
        }

        /*
         /eli/{year}/{month}/{day}/{natural identifier}/{language}
         /{-eli}/{2019}/{04}/{-24}/{02/l-265}/{sq}
        xk = country code
        2019 = viti i publikimit te ligjit
        04 = muaji i publikimit
        24 = dita e publikimit
        law = lloji i ligjit {type}, {subtype}
        04/L-001 = ligji {naturalidentifier}
        sq = language
         */
    }
}
