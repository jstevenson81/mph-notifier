using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace jkas.notfier.function
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
            var repo = new Repository("litecoin", "a82d2318d78cb455e8acfc200ea0f0e6b16682adf161ea836573e14523422d89");
            var data = await repo.GetUserTransactions();
            log.Info(JsonConvert.SerializeObject(data));

        }
    }
}
