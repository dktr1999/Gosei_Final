using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.ShiftOffers.Configuration
{
    internal class ShiftOfferConfigurations
    {
        public const int DateMaxLength = 100;

        public static void Configure(EntityTypeBuilder<ShiftOffer> entityBuilder)
        {
            entityBuilder.ToTable("ShiftOffers");
            entityBuilder.Property(e => e.Date).IsRequired().HasMaxLength(DateMaxLength);
        }
    }
}
