using FinalProject.ShiftOffers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.EntityFrameworkCore.Seed.ShiftOffers
{
    internal class DefaultShiftOffersBuilder
    {
        public readonly FinalProjectDbContext _context;
        public DefaultShiftOffersBuilder(FinalProjectDbContext context) 
        {
            _context = context;
        }

        public void Create()
        {
            var shift_offers = new List<ShiftOffer>
            {
                new ShiftOffer(1, DateTime.Now, DateTime.Now, "Monday", 1)
            };

            foreach (var shift in shift_offers) 
            {
                var existingShiftOffer = _context.ShiftOffers.IgnoreQueryFilters().FirstOrDefault(s => s.Id == shift.Id);

                if(existingShiftOffer == null) { _context.ShiftOffers.Add(shift); }
            }
            _context.SaveChanges();
        }
    }
}
