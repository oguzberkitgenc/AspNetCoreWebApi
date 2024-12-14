using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacivar", Price = 15 },
                new Book { Id = 2, Title = "Kürk Mantollu Madonna", Price = 150 },
                new Book { Id = 3, Title = "Böyle söyledi zerdüşt", Price = 225 }
                );
        }
    }
}
