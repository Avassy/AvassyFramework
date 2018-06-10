using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Avassy.AspNetCore.Mvc.ActionFilters.Services
{
    internal class ReCaptchaValidationService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string _url;

        private readonly string _secretKey;

        public ReCaptchaValidationService(string secretKey)
        {
            this._secretKey = secretKey;
            this._url = "https://www.google.com/recaptcha/api/siteverify";
        }

        public async Task<ReCaptchaValidationResult> Validate(string reCaptchaResponse)
        {
            var content = new FormUrlEncodedContent(
                new[]
                {
                    new KeyValuePair<string, string>("secret", this._secretKey),
                    new KeyValuePair<string, string>("response", reCaptchaResponse)
                });

            var response = await this._httpClient.PostAsync(this._url, content);

            return response?.Content == null ? null : JsonConvert.DeserializeObject<ReCaptchaValidationResult>(await response.Content.ReadAsStringAsync());
        }
    }

    internal class ReCaptchaValidationResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public DateTime ChallengeTimeStamp { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("error-codes")]
        public IEnumerable<string> ErrorCodes { get; set; }
    }
}
