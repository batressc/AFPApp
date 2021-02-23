using AFPApp.Entities;
using AFPApp.Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFPApp.BusinessLogic.Interfaces {
    public interface IAfiliadoBusinessLogic {
        Task<BusinessResult<List<AfiliadoDisplayDto>>> GetAll();
        Task<BusinessResult<AfiliadoDisplayDto>> GetSpecific(int id);
        Task<BusinessResult<AfiliadoDisplayDto>> Create(AfiliadoCreateDto data);
        Task<BusinessResult<AfiliadoDisplayDto>> Update(int id, AfiliadoUpdateDto data);
        Task<BusinessResult<AfiliadoDisplayDto>> Delete(int id);
    }
}
