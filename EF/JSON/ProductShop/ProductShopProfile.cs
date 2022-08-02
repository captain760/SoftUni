using ProductShop.DTOs.CategoryDTO;
using ProductShop.DTOs.CategoryProductDTO;
using ProductShop.DTOs.ProductDTO;
using ProductShop.DTOs.UserDTO;

using ProductShop.Models;

using AutoMapper;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //Imports
            this.CreateMap<ImportUserDTO, User>();
            this.CreateMap<ImportProductDTO, Product>();
            this.CreateMap<ImportCategoryDTO, Category>();
            this.CreateMap<ImportCategoryProductDTO, CategoryProduct>();

            //Exports
            this.CreateMap<Product, ExportProductInRangeDTO>()
                .ForMember(d=>d.SellerFullName,
                mo=>mo.MapFrom(s=>$"{s.Seller.FirstName} {s.Seller.LastName}"));
            //InnerDTO
            this.CreateMap<Product, ExportUserSoldProductsDTO>()
                .ForMember(d => d.BuyerFirstName,
                mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName,
                mo => mo.MapFrom(s => s.Buyer.LastName));
            //OuterDTO
            this.CreateMap<User,ExportUsersWithSoldProductsDTO>()
                .ForMember(d=>d.SoldProducts,
                mo=>mo.MapFrom(s=>s.ProductsSold.Where(p=>p.BuyerId.HasValue)));

            //AgregatedDTO
            this.CreateMap<Category, ExportCategoryByProductCountDTO>()
                .ForMember(d => d.Category,
                mo => mo.MapFrom(s => s.Name))
                .ForMember(d => d.ProductsCount,
                mo => mo.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice,
                mo => mo.MapFrom(s => $"{s.CategoryProducts.Average(p => p.Product.Price):f2}"))
                .ForMember(d => d.TotalRevenue,
                mo => mo.MapFrom(s =>$"{s.CategoryProducts.Sum(p => p.Product.Price):f2}"));
        }
    }
}
