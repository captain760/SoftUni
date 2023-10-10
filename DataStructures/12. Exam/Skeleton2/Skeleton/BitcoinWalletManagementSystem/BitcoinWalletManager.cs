using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWalletManagementSystem
{
    public class BitcoinWalletManager : IBitcoinWalletManager
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Wallet> wallets = new Dictionary<string, Wallet>();
        private Dictionary<string, Transaction> transactions = new Dictionary<string, Transaction>();
        public void CreateUser(User user)
        {
            users.Add(user.Id, user);
        }

        public void CreateWallet(Wallet wallet)
        {
            wallets.Add(wallet.Id, wallet);
            users[wallet.UserId].Wallets.Add(wallet);
        }

        public bool ContainsUser(User user)
        {
            return users.ContainsKey(user.Id);
        }

        public bool ContainsWallet(Wallet wallet)
        {
            return wallets.ContainsKey(wallet.Id);
        }

        public IEnumerable<Wallet> GetWalletsByUser(string userId)
        {
            return users[userId].Wallets;
        }

        public void PerformTransaction(Transaction transaction)
        {
            if (!wallets.ContainsKey(transaction.SenderWalletId) || !wallets.ContainsKey(transaction.ReceiverWalletId))
            {
                throw new ArgumentException();
            }
            if (wallets[transaction.SenderWalletId].Balance<transaction.Amount)
            {
                throw new ArgumentException();
            }
            wallets[transaction.SenderWalletId].Balance -= transaction.Amount;
            wallets[transaction.ReceiverWalletId].Balance += transaction.Amount;
            
            transactions.Add(transaction.Id, transaction);
            
        }

        public IEnumerable<Transaction> GetTransactionsByUser(string userId)
        {
            var wId = wallets.FirstOrDefault(y => y.Value.UserId == userId).Key;
            var trs = new List<Transaction>();
            foreach (var tr in transactions.Values)
            {
                if (tr.SenderWalletId == wId || tr.ReceiverWalletId == wId)
                {
                    trs.Add(tr);
                }
            }
            return trs;
            //return transactions.Values.Where(x => x.SenderWalletId == wId || x.ReceiverWalletId == wId);
            
        }

        public IEnumerable<Wallet> GetWalletsSortedByBalanceDescending()
        {
            return wallets.Values.OrderByDescending(x=>x.Balance);
        }

        public IEnumerable<User> GetUsersSortedByBalanceDescending()
        {
            return users.Values.OrderByDescending(x=>x.Wallets.Sum(y=>y.Balance));
        }

        public IEnumerable<User> GetUsersByTransactionCount()
        {
            return users.Values.OrderByDescending(x => transactions.Count(y => y.Value.ReceiverWalletId==x.Wallets.FirstOrDefault(z => z.UserId == x.Id).Id || y.Value.SenderWalletId == x.Wallets.FirstOrDefault(z => z.UserId == x.Id).Id));
        }
    }
}