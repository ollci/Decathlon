using System;
using System.Collections.Generic;

#nullable disable

namespace Entity.Library.Entity
{
    public partial class FavouriteMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? UserId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual User User { get; set; }
    }
}
