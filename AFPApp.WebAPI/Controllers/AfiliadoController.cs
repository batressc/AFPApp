using AFPApp.BusinessLogic.Interfaces;
using AFPApp.Entities;
using AFPApp.Entities.Dto;
using AFPApp.WebAPI.CustomResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFPApp.WebAPI.Controllers {
    [Route("api/afiliado")]
    [ApiController]
    public class AfiliadoController : ControllerBase {
        private readonly IAfiliadoBusinessLogic _bl;

        public AfiliadoController(IAfiliadoBusinessLogic bl) {
            _bl = bl;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            BusinessResult<List<AfiliadoDisplayDto>> afiliados = await _bl.GetAll();
            return afiliados.Control switch {
                BusinessControl.OK => Ok(afiliados.Result),
                _ => new InternalServerErrorContentResult(afiliados.Message)
            };
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) {
            BusinessResult<AfiliadoDisplayDto> afiliado = await _bl.GetSpecific(id);
            return afiliado.Control switch {
                BusinessControl.OK => Ok(afiliado.Result),
                BusinessControl.NotFound => NotFound(afiliado.Message),
                BusinessControl.ClientError => BadRequest(afiliado.Message),
                _ => new InternalServerErrorContentResult(afiliado.Message)
            };
        }

        [HttpPost]
        public async Task<IActionResult> Post(AfiliadoCreateDto data) {
            BusinessResult<AfiliadoDisplayDto> afiliado = await _bl.Create(data);
            return afiliado.Control switch {
                BusinessControl.OK => CreatedAtAction("Get", new { id = afiliado.Result.Id }, afiliado.Result),
                BusinessControl.Exists => Conflict(afiliado.Message),
                BusinessControl.ClientError => BadRequest(afiliado.Message),
                _ => new InternalServerErrorContentResult(afiliado.Message)
            };
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, AfiliadoUpdateDto data) {
            BusinessResult<AfiliadoDisplayDto> afiliado = await _bl.Update(id, data);
            return afiliado.Control switch {
                BusinessControl.OK => Ok(afiliado.Result),
                BusinessControl.NotFound => NotFound(afiliado.Message),
                BusinessControl.ClientError => BadRequest(afiliado.Message),
                _ => new InternalServerErrorContentResult(afiliado.Message)
            };
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) {
            BusinessResult<AfiliadoDisplayDto> afiliado = await _bl.Delete(id);
            return afiliado.Control switch {
                BusinessControl.OK => Ok(afiliado.Result),
                BusinessControl.NotFound => NotFound(afiliado.Message),
                BusinessControl.ClientError => BadRequest(afiliado.Message),
                _ => new InternalServerErrorContentResult(afiliado.Message)
            };
        }
    }
}
