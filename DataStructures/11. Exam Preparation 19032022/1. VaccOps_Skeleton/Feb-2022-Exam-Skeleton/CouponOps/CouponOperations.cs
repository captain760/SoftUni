namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CouponOps.Models;
    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private Dictionary<string, Coupon> coupons = new Dictionary<string, Coupon>();
        private Dictionary<string, Website> sites = new Dictionary<string, Website>();

        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!Exist(website) || Exist(coupon)) throw new ArgumentException();
            sites[website.Domain].Coupons.Add(coupon);
            coupons.Add(coupon.Code, coupon);
        }
        

        public bool Exist(Website website)
        {
            return sites.ContainsKey(website.Domain);
        }

        public bool Exist(Coupon coupon)
        {
            return coupons.ContainsKey(coupon.Code);
        }

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if(!Exist(website)) throw new ArgumentException();
            return sites[website.Domain].Coupons;
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
        {
            return coupons.Values.OrderByDescending(x=>x.Validity).ThenByDescending(x=>x.DiscountPercentage);
        }

        public IEnumerable<Website> GetSites()
        {
            return sites.Values;
        }

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
        {
           return sites.Values.OrderBy(x=>x.UsersCount).ThenByDescending(x=>x.Coupons.Count);
        }

        public void RegisterSite(Website website)
        {
            if (Exist(website))
            {
                throw new ArgumentException();
            }
            sites.Add(website.Domain, website);
        }

        public Coupon RemoveCoupon(string code)
        {
            if (!coupons.ContainsKey(code))
            {
                throw new ArgumentException();
            }
            foreach ( var s in sites.Values)
            {
                if (s.Coupons.Contains(coupons[code]))
                {
                    s.Coupons.Remove(coupons[code]);
                }
            }
            var coupToRemove = coupons[code];
            coupons.Remove(code);
            return coupToRemove;
        }

        public Website RemoveWebsite(string domain)
        {
            if (!sites.ContainsKey(domain))
            {
                throw new ArgumentException();
            }
            Website siteToRemove = sites[domain];
            foreach (var coup in sites[domain].Coupons)
            {
                coupons.Remove(coup.Code);
            }
            sites.Remove(domain);
            return siteToRemove;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!Exist(website) || !Exist(coupon))
            {
                throw new ArgumentException();
            }
            if (!sites[website.Domain].Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }
            sites[website.Domain].Coupons.Remove(coupon);
            coupons.Remove(coupon.Code);
        }
    }
}
