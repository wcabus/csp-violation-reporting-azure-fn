using System;
using Newtonsoft.Json;

namespace CspReportUriFns.Models
{
    public class Violation
    {
        [JsonProperty("csp-report")]
        public CspReportDocument CspReport { get; set; }
    }

    public class CspReportDocument
    {
        private string _documentUri;

        [JsonProperty("authority")]
        public string Authority { get; set; }

        [JsonProperty("document-uri")]
        public string DocumentUri
        {
            get => _documentUri;
            set
            {
                _documentUri = value;

                var uri = new Uri(value);
                Authority = uri.Authority;
            }
        }

        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        [JsonProperty("blocked-uri")]
        public string BlockedUri { get; set; }

        [JsonProperty("effective-directive")]
        public string EffectiveDirective { get; set; }

        [JsonProperty("violated-directive")]
        public string ViolatedDirective { get; set; }

        [JsonProperty("original-policy")]
        public string OriginalPolicy { get; set; }

        [JsonProperty("status-code")]
        public int StatusCode { get; set; }

        [JsonProperty("source-file")]
        public string SourceFile { get; set; }

        [JsonProperty("line-number")]
        public int? LineNumber { get; set; }

        [JsonProperty("column-number")]
        public int? ColumnNumber { get; set; }
    }
}
