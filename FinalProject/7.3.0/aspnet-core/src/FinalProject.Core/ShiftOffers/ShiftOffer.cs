using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.ShiftOffers
{
    public class ShiftOffer : Entity
    {
        public int UserID { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string Date { get; set; }
        public int AdditionalShiftID { get; set; }

        public ShiftOffer(int userID, DateTime fromTime, DateTime toTime, string date, int additionalShiftID) : this()
        {
            UserID = userID;
            FromTime = fromTime;
            ToTime = toTime;
            Date = date;
            AdditionalShiftID = additionalShiftID;
        }

        public ShiftOffer()
        {
        }
    }
}
