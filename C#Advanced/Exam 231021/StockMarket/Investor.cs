using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio = new List<Stock>();
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            var Portfolio = new List<Stock>();
        }
        public IReadOnlyCollection<Stock> Portfolio => portfolio;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get {return Portfolio.Count; } }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization>10000 && this.MoneyToInvest>=stock.PricePerShare)
            {
                portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (portfolio.Any(x=>x.CompanyName == companyName))
            {
                Stock stockToSell = portfolio.Where(x => x.CompanyName == companyName).First();
                if (sellPrice>=stockToSell.PricePerShare)
                {
                    portfolio.Remove(stockToSell);
                    this.MoneyToInvest += sellPrice;
                    return $"{companyName} was sold.";
                }
                else
                {
                    return $"Cannot sell {companyName}.";
                }
            }
            else
            {
                return $"{companyName} does not exist.";
            }
        }
        public Stock FindStock(string companyName)
        {
            return portfolio.Where(x => x.CompanyName == companyName).FirstOrDefault();
        }
        public Stock FindBiggestCompany()
        {
            return portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }
        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
