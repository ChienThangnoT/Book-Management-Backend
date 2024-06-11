using AutoMapper;
using BookManagement.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Service.Mapper
{
    public partial class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap(typeof(Pagination<>), typeof(Pagination<>));

            CategoryMapperConfigs();
            BookMapperConfigs();
            DiscountMapperConfigs();
            OrderDetailMapperConfigs();
            OrderMapperConfigs();
        }
        partial void CategoryMapperConfigs();
        partial void BookMapperConfigs();
        partial void DiscountMapperConfigs();
        partial void OrderMapperConfigs();
        partial void OrderDetailMapperConfigs();
    }
}
