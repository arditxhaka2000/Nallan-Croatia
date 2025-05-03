using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace Web.Providers
{
    public class RecaptchaV3Helper
    {
        private readonly IConfiguration _configuration;

        public RecaptchaV3Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> IsReCaptchaValid(string token)
        {

            HttpClient _httpClient = new HttpClient();

            try
            {
                string _secretKey = _configuration.GetValue<string>("RecaptchaSettings:SecretKey");
                string RecaptchaVerifyUrl = "https://www.google.com/recaptcha/api/siteverify";

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("secret", _secretKey),
                    new KeyValuePair<string, string>("response", token)
                });

                using (var response = await _httpClient.PostAsync(RecaptchaVerifyUrl, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var captchaResponse = JObject.Parse(responseContent);
                        return (bool)captchaResponse["success"];
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return false;
            }
            finally
            {
                _httpClient.Dispose(); 
            }
        }

    }
}
