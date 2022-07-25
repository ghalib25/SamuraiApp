#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data.DTO;
using SamuraiApp.Data;
using SamuraiApp.Data.Interface;
using SamuraiApp.Domain;
using Microsoft.AspNetCore.Authorization;

namespace SamuraiApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SwordsController : ControllerBase
    {
        private readonly ISword _swords;
        private readonly IMapper _mapper;

        public SwordsController(ISword swords, IMapper mapper)
        {
            _swords = swords;
            _mapper = mapper;
        }

        // GET: api/Swords
        [HttpGet]
        public async Task<IEnumerable<SwordDTO>> GetSwords()
        {
            var results = await _swords.GetAll();
            var output = _mapper.Map<IEnumerable<SwordDTO>>(results);

            return output;
        }

        // GET: api/Swords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SwordDTO>> GetSwordById(int id)
        {
            var result = await _swords.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<SwordDTO>(result));
        }

        // PUT: api/Swords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSword(int id, SwordAddDTO swordAddDTO)
        {
            try
            {
                var updatesword = _mapper.Map<Sword>(swordAddDTO);
                var result = await _swords.Update(id, updatesword);
                var swordDTO = _mapper.Map<SwordDTO>(result);
                return Ok(swordDTO);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/Swords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sword>> PostSword(SwordAddDTO swordAddDTO)
        {
            try
            {
                var newsword = _mapper.Map<Sword>(swordAddDTO);
                var result = await _swords.Insert(newsword);
                var swordDTO = _mapper.Map<SwordDTO>(result);

                return CreatedAtAction("GetSwordById", new { Id = result.Id }, swordDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/SwordElement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("SwordElement")]
        public async Task<ActionResult<Sword>> PostSwordElement(SwordElementAddDTO swordElementAddDTO)
        {
            /*var mapSword = _mapper.Map<Sword>(swordElementAddDTO.swordAddDTO);

            var newSword = await _swords.Insert(mapSword);

            var swordDTO = _mapper.Map<SwordDTO>(newSword);

            var mapElement = _mapper.Map<Element>(swordElementAddDTO.elementAddDTOs);

            List<ElementAddDTO> ElementList = new List<ElementAddDTO>();
            foreach (var element in swordElementAddDTO.elementAddDTOs)
            {
                //if (element.Name == null)ElementList.Add(element);
                if (element.Name == null){
                    var newElement = _mapper.Map<Element>(element);
                    ElementList.Add(element);
                    var El = await _swords.InsertElement(newElement);
                    var Elements = _mapper.Map<ElementDTO>(El);
                }
                else
                    Console.WriteLine("Element yang ada input sudah ada");
            }
            
            //var newElement = await _swords.InsertElement(mapElement);
            //var elementDTO = _mapper.Map<ElementDTO>(newElement);

            //List<Array> ElementList = new List<Array>();

            //Array[] elements = { await _swords.InsertElement(mapElement) };

            //ElementList.AddRange(elements);

            //var elementDTO = _mapper.Map<ElementDTO>(ElementList);

            return CreatedAtAction(nameof(GetSwordById), new { id = newSword.Id }, swordDTO);*/
            try
            {
                List<int> elementid = new List<int>();
                var newSword = _mapper.Map<Sword>(swordElementAddDTO.swordAddDTO);
                var result = await _swords.Insert(newSword);
                var swordDTO = _mapper.Map<SwordDTO>(result);
                foreach (var element in swordElementAddDTO.elementAddDTOs)
                {
                    if (element.Name == null)
                    {
                        var newElement = _mapper.Map<Element>(element);
                        var elemen = await _swords.InsertElement(newElement);
                        var elemens = _mapper.Map<ElementDTO>(elemen);
                        elementid.Add(elemen.Id);
                    }
                    else
                    {
                        Console.WriteLine("Element yang ada input sudah ada");
                    }
                }
                foreach (var ele in elementid)
                {
                    var swordele = new SwordElement
                    {
                        SwordId = result.Id,
                        ElementId = ele
                    };
                    await _swords.InsertSwordElement(swordele);
                }
                return CreatedAtRoute("GetSwordById", new {id = result.Id}, swordDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Swords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSword(int id)
        {
            try
            {
                await _swords.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
