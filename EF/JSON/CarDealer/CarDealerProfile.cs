
using AutoMapper;
using CarDealer.DTO.CarsDTO;
using CarDealer.DTO.CustomersDTO;
using CarDealer.DTO.PartsDTO;
using CarDealer.DTO.SalesDTO;
using CarDealer.DTO.SupplierDTO;
using CarDealer.Models;
using System.Globalization;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Imports
            this.CreateMap<ImportSupplierDTO, Supplier>();
            this.CreateMap<ImportPartsDTO, Part>();
            this.CreateMap<ImportCustomerDTO, Customer>();
            this.CreateMap<ImportSaleDTO, Sale>();

            //Exports
            this.CreateMap<Customer, ExportLocalSuppDTO>()
                .ForMember(d=>d.BirthDate,
                mo=>mo.MapFrom(s=>s.BirthDate.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture)));
            this.CreateMap<Car, ExportToyotaCarDTO>();
            
        }
    }
}
