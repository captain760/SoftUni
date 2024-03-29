using System.Collections.Generic;

namespace BitcoinWalletManagementSystem
{
    public class Wallet
    {
        
        public string Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public long Balance { get; set; } 

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}