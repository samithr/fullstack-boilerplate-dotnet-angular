using Microsoft.AspNetCore.Mvc;
using backend.Models;

namespace backend.Services.Interfaces
{
    public class ITransactionService
    {
        Task<List<TransactionModel>> AllTransactions();
        Task<TransactionModel> CreateTransactions(TransactionModel transactionModel);
    }
}