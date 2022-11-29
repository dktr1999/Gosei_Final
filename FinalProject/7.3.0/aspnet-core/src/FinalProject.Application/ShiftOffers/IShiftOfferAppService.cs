using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.ShiftOffers
{
    public interface IShiftOfferAppService : IApplicationService
    {
        Task<ListResultDto<ShiftOfferListDto>> GetAllShift();
    }

    ///<Summary>
    /// Gets the answer
    ///</Summary>

    ///<Summary>
    /// Gets the answer
    ///</Summary>
    [AutoMapFrom(typeof(ShiftOffer))]
    public class ShiftOfferListDto : EntityDto
    {
        ///<Summary>
        /// Gets the answer
        ///</Summary>
        public int UserID { get; set; }
        ///<Summary>
        /// Gets the answer
        ///</Summary>
        public DateTime FromTime { get; set; }
        ///<Summary>
        /// Gets the answer
        ///</Summary>
        public DateTime ToTime { get; set; }
        ///<Summary>
        /// Gets the answer
        ///</Summary>
        public string Date { get; set; }
        ///<Summary>
        /// Gets the answer
        ///</Summary>
        public int AdditionalShiftID { get; set; }
    }
}
