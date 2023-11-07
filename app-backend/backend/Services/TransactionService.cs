using System.Threading.Tasks;
using backend.Models;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace backend.Services.Interfaces
{
    public class TransactionService : ITransactionService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<TransactionService> logger;

        private IConfiguration configuration { get; }

        private readonly string accountApi;

        public TransactionService(IHttpClientFactory httpClientFactory,
            ILogger<TransactionService> logger,
            IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
            this.configuration = configuration;
            accountApi = $"{configuration["AccountApiUrl"]}{configuration["AccountApiVersion"]}{configuration["AccountApiTransactions"]}";
        }

        public async Task<List<TransactionModel>> AllTransactions()
        {
            try
            {
                var response = new List<TransactionModel>();
                var request = new HttpRequest(HttpMethod.Get, accountApi)
                var httpClient = httpClientFactory.CreateClient(); 
                var httpResponse = await httpClient.SendAsync(request);
                
                if(httpResponse.IsSuccessStatusCode){
                    using var stream = await httpResponse.Content.ReadAsStreamAsync();

                    response = await JsonConvert.DeserializeObject<List<TransactionModel>>(stream);
                }

                return response;
            }
            catch (Exception ex) 
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<TransactionModel> CreateTransactions(TransactionModel transactionModel)
        {
            try
            {
                var response = new TransactionModel();
                var content = JsonConvert.SerializeObject(transactionModel);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                
                var httpClient = httpClientFactory.CreateClient(); 
                var httpResponse = await httpClient.PostAsync(accountApi, content);
                
                if(httpResponse.IsSuccessStatusCode){
                    using var stream = await httpResponse.Content.ReadAsStreamAsync();

                    response = await JsonConvert.DeserializeObject<TransactionModel>(stream);
                }

                return response;
            }
            catch (Exception ex) 
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}