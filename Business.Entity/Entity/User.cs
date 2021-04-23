using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Library.Entity
{
    public partial class User
    {
        public User()
        {
            FavouriteMovies = new HashSet<FavouriteMovie>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<FavouriteMovie> FavouriteMovies { get; set; }
    }
}
