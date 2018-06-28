using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Avassy.AspNetCore.Mvc.InvisibleReCaptcha
{
    /// <summary>
    /// The validation service class for the reCaptcha response.
    /// </summary>
    public class ReCaptchaValidationService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string _url;

        private readonly string _secretKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReCaptchaValidationService"/> class.
        /// </summary>
        /// <param name="secretKey">The secret key you acquired in the Google developer console.</param>
        public ReCaptchaValidationService(string secretKey)
        {
            this._secretKey = secretKey;
            this._url = "https://www.google.com/recaptcha/api/siteverify";
        }

        /// <summary>
        /// Validates the specified reCaptcha response.
        /// </summary>
        /// <param name="reCaptchaResponse">The reCaptcha response.</param>
        /// <returns></returns>
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

    /// <summary>
    /// The reCaptcha validation result class.
    /// </summary>
    public class ReCaptchaValidationResult
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
