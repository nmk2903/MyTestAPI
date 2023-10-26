using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTestAPI.Models;
using MyTestAPI.Repositories;

namespace MyTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoasController : ControllerBase
    {
        private readonly IHangHoaRepository _hangHoaRepo;

        public HangHoasController(IHangHoaRepository hangHoaRepository)
        {
            _hangHoaRepo = hangHoaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetALlHangHoas()
        {
            try
            {
                return Ok(await _hangHoaRepo.GetAllHangHoaAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetHangHoaById(int id)
        {
            var hangHoa = await _hangHoaRepo.GetHangHoaAsync(id);
            return hangHoa == null ? NotFound() : Ok(hangHoa);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewHangHoa(HangHoaModel model)
        {
            try
            {
                var newHangHoaId = await _hangHoaRepo.AddHangHoaAsync(model);
                return CreatedAtAction(nameof(GetHangHoaById), new { controller = "HangHoas", newHangHoaId });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateHangHoa(int id, HangHoaModel model)
        {
            try
            {
                if( id != model.MaHh)
                {
                    return NotFound();
                }
                await _hangHoaRepo.UpdateHangHoaAsync(id, model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteHangHoa(int id)
        {
            await _hangHoaRepo.DeleteHangHoaAsync(id);
            return Ok();
        }
    }
}
