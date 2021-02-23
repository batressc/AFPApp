using AFPApp.BusinessLogic.Interfaces;
using AFPApp.DataAccess.Model;
using AFPApp.Entities;
using AFPApp.Entities.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFPApp.BusinessLogic.Implements {
    public class AfiliadoBusinessLogic : IAfiliadoBusinessLogic {
        private readonly AFPAppDbContext _da;
        private readonly IMapper _mapper;

        public AfiliadoBusinessLogic(AFPAppDbContext da, IMapper mapper) {
            _da = da;
            _mapper = mapper;
        }

        public async Task<BusinessResult<List<AfiliadoDisplayDto>>> GetAll() {
            BusinessResult<List<AfiliadoDisplayDto>> blResult = new BusinessResult<List<AfiliadoDisplayDto>> {
                Result = await _mapper.ProjectTo<AfiliadoDisplayDto>(_da.Afiliado).ToListAsync(),
                Message = "Afiliados recuperados exitosamente",
                Control = BusinessControl.OK
            };
            return blResult;
        }

        public async Task<BusinessResult<AfiliadoDisplayDto>> GetSpecific(int id) {
            BusinessResult<AfiliadoDisplayDto> blResult = new BusinessResult<AfiliadoDisplayDto>();
            Afiliado data = await _da.Afiliado.FindAsync(id);
            if (data != null) {
                blResult.Result = _mapper.Map<AfiliadoDisplayDto>(data);
                blResult.Message = "Afiliado encontrado exitosamente";
                blResult.Control = BusinessControl.OK;
            } else {
                blResult.Message = "No se encontró al afiliado especificado";
                blResult.Control = BusinessControl.NotFound;
            }
            return blResult;
        }

        public async Task<BusinessResult<AfiliadoDisplayDto>> Create(AfiliadoCreateDto data) {
            BusinessResult<AfiliadoDisplayDto> blResult = new BusinessResult<AfiliadoDisplayDto>() {
                Message = "No se realizó el registro del nuevo afiliado",
                Control = BusinessControl.NotExecuted
            };
            Afiliado legacyAfiliado = await _da.Afiliado.Where(x => x.Nombre == data.Nombre && x.Apellido == data.Apellido).SingleOrDefaultAsync();
            if (legacyAfiliado != null) {
                blResult.Message = $"El afiliado \"{data.Nombre} {data.Apellido}\" ya se encuentra registrado";
                blResult.Control = BusinessControl.Exists;
                return blResult;
            }
            Afiliado newAfiliado = _mapper.Map<Afiliado>(data);
            await _da.Afiliado.AddAsync(newAfiliado);
            if (await _da.SaveChangesAsync() > 0) {
                blResult.Result = _mapper.Map<AfiliadoDisplayDto>(newAfiliado);
                blResult.Message = "Afiliado registrado exitosamente";
                blResult.Control = BusinessControl.OK;
            }            
            return blResult;
        }

        public async Task<BusinessResult<AfiliadoDisplayDto>> Update(int id, AfiliadoUpdateDto data) {
            BusinessResult<AfiliadoDisplayDto> blResult = new BusinessResult<AfiliadoDisplayDto>() {
                Message = "No se realizó la actualización del afiliado",
                Control = BusinessControl.NotExecuted
            };
            Afiliado legacyAfiliado = await _da.Afiliado.FindAsync(id);
            if (legacyAfiliado == null) {
                blResult.Message = "No se encontró al afiliado especificado";
                blResult.Control = BusinessControl.NotFound;
                return blResult;
            }
            _mapper.Map(data, legacyAfiliado);
            if (await _da.SaveChangesAsync() > 0) {
                blResult.Result = _mapper.Map<AfiliadoDisplayDto>(legacyAfiliado);
                blResult.Message = "Afiliado actualizado exitosamente";
                blResult.Control = BusinessControl.OK;
            }
            return blResult;
        }

        public async Task<BusinessResult<AfiliadoDisplayDto>> Delete(int id) {
            BusinessResult<AfiliadoDisplayDto> blResult = new BusinessResult<AfiliadoDisplayDto>() {
                Message = "No se realizó la eliminación del afiliado",
                Control = BusinessControl.NotExecuted
            };
            Afiliado legacyAfiliado = await _da.Afiliado.FindAsync(id);
            if (legacyAfiliado == null) {
                blResult.Message = "No se encontró al afiliado especificado";
                blResult.Control = BusinessControl.NotFound;
                return blResult;
            }
            _da.Remove(legacyAfiliado);
            if (await _da.SaveChangesAsync() > 0) {
                blResult.Result = _mapper.Map<AfiliadoDisplayDto>(legacyAfiliado);
                blResult.Message = "Afiliado eliminado exitosamente";
                blResult.Control = BusinessControl.OK;
            }
            return blResult;
        }
    }
}
