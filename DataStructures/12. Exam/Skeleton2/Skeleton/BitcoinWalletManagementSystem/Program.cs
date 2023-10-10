using System;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var bwm = new BitcoinWalletManager();
            var user1 = new User { Id = "user1" };
            var user2 = new User { Id = "user2" };
            var user3 = new User { Id = "user3" };

            bwm.CreateUser(user1);
            bwm.CreateUser(user2);
            bwm.CreateUser(user3);

            var user1Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user1.Id, Balance = 1000 };
            var user2Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user2.Id, Balance = 1000 };
            var user3Wallet = new Wallet { Id = Guid.NewGuid().ToString(), UserId = user3.Id, Balance = 1000 };

            bwm.CreateWallet(user1Wallet);
            bwm.CreateWallet(user2Wallet);
            bwm.CreateWallet(user3Wallet);

            var transaction1 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = "ffvvf",
                Amount = 100,
                Timestamp = DateTime.Now,
            };

            var transaction2 = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                SenderWalletId = user1Wallet.Id,
                ReceiverWalletId = user3Wallet.Id,
                Amount = 100,
                Timestamp = DateTime.Now,
            };

            bwm.PerformTransaction(transaction1);
            bwm.PerformTransaction(transaction2);

            var user1Transactions = bwm.GetTransactionsByUser(user1.Id);
            var user2Transactions = bwm.GetWalletsSortedByBalanceDescending();
            var user3Transactions = bwm.GetUsersSortedByBalanceDescending();
            var user4Transactions = bwm.GetUsersByTransactionCount();

            Console.WriteLine(string.Join(", ", user4Transactions.Select(x=>x.Id)));
        }
    }
}