using Microsoft.EntityFrameworkCore.Storage;
using MyTestAPI.Models;

namespace MyTestAPI.Repositories
{
    public interface IHangHoaRepository
    {
        public Task<List<HangHoaModel>> GetAllHangHoaAsync();
        public Task<HangHoaModel> GetHangHoaAsync(int id);
        public Task<int> AddHangHoaAsync(HangHoaModel model);
        public Task UpdateHangHoaAsync(int id, HangHoaModel model);
        public Task DeleteHangHoaAsync(int id);
    }
}
