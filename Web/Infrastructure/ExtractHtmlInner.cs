using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public static class ExtractHtmlInner
    {
        internal static string ExtractHtmlInnerText(string htmlText)
        {
            Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);

            string resultText = regex.Replace(htmlText + "", " ").Trim();
            resultText = resultText.Replace("&euml;", "ë").Trim();
            resultText = resultText.Replace("&Euml;", "Ë").Trim();
            resultText = resultText.Replace("&nbsp;", "").Trim();
            resultText = resultText.Replace("&ccedil;", "ç").Trim();
            resultText = resultText.Replace("&Ccedil;", "Ç").Trim();

            //RegexOptions options = RegexOptions.None;
            //Regex regex2 = new Regex(@"\s+");
            //resultText = regex.Replace(resultText, " ");

            return resultText;
        }

        internal static string ExtractHtmlInnerTextForInsert(string htmlText)
        {
            Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);

            string resultText = regex.Replace(htmlText + "", "").Trim();
            resultText = resultText.Replace("&euml;", "ë").Trim();
            resultText = resultText.Replace("&Euml;", "Ë").Trim();
            resultText = resultText.Replace("&nbsp;", "").Trim();
            resultText = resultText.Replace("&ccedil;", "ç").Trim();
            resultText = resultText.Replace("&Ccedil;", "Ç").Trim();

            //RegexOptions options = RegexOptions.None;
            //Regex regex2 = new Regex(@"\s+");
            //resultText = regex.Replace(resultText, " ");

            return resultText;
        }
    }
}
