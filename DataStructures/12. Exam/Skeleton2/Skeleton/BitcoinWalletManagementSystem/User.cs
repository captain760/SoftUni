using System.Collections.Generic;

namespace BitcoinWalletManagementSystem
{
    public class User
    {
        
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Wallet> Wallets { get; set; } =new List<Wallet>();
    }
}