using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.ShiftOffers
{
    public class ShiftOfferAppService : FinalProjectAppServiceBase, IShiftOfferAppService
    {
        private readonly IRepository<ShiftOffer> _shiftofferRepository;


        public ShiftOfferAppService(IRepository<ShiftOffer> shiftofferRepository)
        {
            _shiftofferRepository = shiftofferRepository;
        }

        public async Task<ListResultDto<ShiftOfferListDto>> GetAllShift()
        {
            var shifts = await _shiftofferRepository
                .GetAll()
                .ToListAsync();

            var dtos = ObjectMapper.Map<List<ShiftOfferListDto>>(shifts);

            return new ListResultDto<ShiftOfferListDto>(dtos);
        }
    }
}
