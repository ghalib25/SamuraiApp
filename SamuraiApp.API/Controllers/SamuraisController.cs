using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamuraiApp.Data.DTO;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace samuraiApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class samuraisController : ControllerBase
    {
        
        private readonly ISamurai _samurais;
        private readonly IMapper _mapper;
        
        public samuraisController(ISamurai samurais, IMapper mapper)
        {
            _samurais = samurais;
            _mapper = mapper;
        }

        // GET: api/<samuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiDTO>> Get()
        {
            //List<samuraiDTO> samuraiDTOs = new List<samuraiDTO> ();
            //var  results = await _samurais.GetAll();
            //foreach(var result in results)
            //{
            //    samuraiDTOs.Add(new samuraiDTO
            //    {
            //        Id = result.Id,
            //        Name = result.Name,
            //    });
            //}

            //return samuraiDTOs;

            var results = await _samurais.GetAll();
            var output = _mapper.Map<IEnumerable<SamuraiDTO>>(results);

            return output;
        }

        // GET api/<samuraisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SamuraiDTO>> GetById(int id)
        {
            var result = await _samurais.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<SamuraiDTO>(result));
        }

        // POST api/<samuraisController>
        [HttpPost]
        public async Task<ActionResult> Post(SamuraiAddDTO samuraiAddDTO)
        {
            try
            {
                var newsamurai = _mapper.Map<Samurai>(samuraiAddDTO);
                var result = await _samurais.Insert(newsamurai);
                var samuraiDTO = _mapper.Map<SamuraiDTO>(result);

                return CreatedAtAction("GetById", new { Id = result.Id }, samuraiDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<samuraisController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SamuraiDTO>> Put(int id, SamuraiAddDTO samuraiAddDTO)
        {
            try
            {
                var updatesamurai = _mapper.Map<Samurai>(samuraiAddDTO);
                var result = await _samurais.Update(id, updatesamurai);
                var samuraiDTO = _mapper.Map<SamuraiDTO>(result);
                return Ok(samuraiDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<samuraisController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _samurais.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
