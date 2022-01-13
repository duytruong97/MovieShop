using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? Email { get; set; }
        public String? HashedPassword { get; set; }
        public String? Salt { get; set; }
        public String? PhoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDate { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public bool? Islocked { get; set; }
        public int? AccessFailedCount { get; set; }




        public List<Purchase> MoviesOfPurchase { get; set; }
        public List<Favorite> FavoriteMoviesOfUsers{ get; set; }



        public List<UserRole> RolesOfUser { get; set; }
        public List<Review> ReviewsOfUser { get; set;}
    }
}
