using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework2SQLLibrary
{
    public partial class Users
    {
        public Users()
        {
            Request = new HashSet<Request>();
        }

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(30)]
        public string Lastname { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public bool? IsReviewer { get; set; }
        [Required]
        public bool? IsAdmin { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Request> Request { get; set; }
    }
}
