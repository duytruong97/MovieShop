using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        
        public Guid? PurchasedNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchasedateTime { get; set; }
        public int MovieID { get; set; }


        public Movie Movie { get; set; }
        public User User { get; set; }

        // modelBuilder.Entity<TodoItem>().Property(t => t.Id).HasColumnType("UniqueIdentifier");
    }
}
