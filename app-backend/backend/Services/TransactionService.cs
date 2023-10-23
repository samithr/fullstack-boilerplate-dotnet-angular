namespace backend.Services.Interfaces
{
    public class TransactionService : ITransactionService
    {
        private readonly IHttpClientFactory httpClientFacoty;
        private readonly ILogger<TransactionService> logger;

        public TransactionService(IHttpClientFactory httpClientFacoty,
            ILogger<TransactionService> logger)
        {
            this.httpClientFactory = httpClientFacoty;
            this.logger = logger;
        }

        public Task<List<TransactionModel>> AllTransactions()
        {
            try
            {

            }
            catch (Exception ex) 
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        public Task<TransactionModel> CreateTransactions(TransactionModel transactionModel)
        {
            try
            {

            }
            catch (Exception ex) 
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}