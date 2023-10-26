using AutoMapper;
using MyTestAPI.Data;
using MyTestAPI.Models;

namespace MyTestAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<HangHoa, HangHoaModel>().ReverseMap();
        }
    }
}
