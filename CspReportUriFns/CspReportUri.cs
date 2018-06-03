using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Threading.Tasks;
using CspReportUriFns.Models;

namespace CspReportUriFns
{
    public static class CspReportUri
    {
        [FunctionName(nameof(CspReportUri))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "csp-violations")]HttpRequest req, 
            [CosmosDB("CSP", "Violations", CreateIfNotExists = true, PartitionKey = "/authority")]IAsyncCollector<CspReportDocument> documents,
            TraceWriter log)
        {
            var json = await req.ReadAsStringAsync();
            log.Info(json);

            var violation = JsonConvert.DeserializeObject<Violation>(json);
            var reportDocument = violation.CspReport;

            await documents.AddAsync(reportDocument);

            return new StatusCodeResult(204);
        }
    }
}
