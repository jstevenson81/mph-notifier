using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace jkas.notfier.function
{
    public class Repository
    {
        public string ApiUrl { get; }
        public Repository(string coin, string apiKey)
        {
            ApiUrl = $"https://{coin}.miningpoolhub.com/index.php?api_key={apiKey}";
        }
        public async Task<MiningPoolHubData> GetUserTransactions()
        {
            var client = new RestClient(ApiUrl);
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("page", "api");
            request.AddQueryParameter("action", "getusertransactions");

            var reponse = await client.ExecuteTaskAsync(request);
            var data = JsonConvert.DeserializeObject<MiningPoolHubData>(reponse.Content);
            return data;

        }
    }

    public class Transaction
    {
        public int id { get; set; }
        public string username { get; set; }
        public string type { get; set; }
        public double amount { get; set; }
        public string coin_address { get; set; }
        public string timestamp { get; set; }
        public string txid { get; set; }
        public object height { get; set; }
        public object blockhash { get; set; }
        public object confirmations { get; set; }
    }

    public class Data
    {
        public IList<Transaction> transactions { get; set; }

        public Data()
        {
            transactions = new List<Transaction>();
        }
    }

    public class GetUserTransactions
    {
        public string version { get; set; }
        public double runtime { get; set; }
        public Data data { get; set; }
    }

    public class MiningPoolHubData
    {
        public GetUserTransactions GetUserTransactions { get; set; }
    }
}
