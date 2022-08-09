using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Input
            //CreateMap<ImportSupplierDTO, Supplier>();
            CreateMap<ImportPartDTO, Part>();
            CreateMap<ImportCustomerDTO, Customer>();
            CreateMap<ImportSaleDTO, Sale>();
            //Output
            CreateMap<Car, ExportCarDTO>();
            CreateMap<Car, ExportBMWCarsDTO>();
            CreateMap<Supplier, ExportSupplierDTO>()
                .ForMember(d=>d.PartsCount,
                mo=>mo.MapFrom(s=>s.Parts.Count));
        }
    }
}
