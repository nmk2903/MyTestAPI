using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyTestAPI.Data;
using MyTestAPI.Models;

namespace MyTestAPI.Repositories
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public HangHoaRepository(MyDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddHangHoaAsync(HangHoaModel model)
        {
            var newHangHoa = _mapper.Map<HangHoa>(model);
            _context.hangHoas!.Add(newHangHoa);
            await _context.SaveChangesAsync();

            return newHangHoa.MaHh;
        }

        public async Task DeleteHangHoaAsync(int id)
        {
            var deleteHangHoa = _context.hangHoas!.SingleOrDefault(hh => hh.MaHh == id);
            if(deleteHangHoa != null)
            {
                _context.hangHoas!.Remove(deleteHangHoa!);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<HangHoaModel>> GetAllHangHoaAsync()
        {
            var HangHoas = await _context.hangHoas!.ToListAsync();
            return _mapper.Map<List<HangHoaModel>>(HangHoas);
        }

        public async Task<HangHoaModel> GetHangHoaAsync(int id)
        {
            var hangHoa = await _context.hangHoas!.FindAsync(id);
            return _mapper.Map<HangHoaModel>(hangHoa);
        }

        public async Task UpdateHangHoaAsync(int id, HangHoaModel model)
        {
            if(id == model.MaHh)
            {
                var updateHangHoa = _mapper.Map<HangHoa>(model);
                _context.hangHoas!.Update(updateHangHoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
