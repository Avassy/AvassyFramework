using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Avassy.AspNetCore.Mvc.InvisibleReCaptcha.Models
{
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
