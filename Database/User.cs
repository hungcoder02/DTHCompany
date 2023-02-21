namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int CustomerId { get; set; }
        

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        public string Fullname { get; set; }

        [Required]
        [Range(100000000000, 9999999999999999999, ErrorMessage = "must be between 12 and 19 digits")]
        public string Cardnumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Adress { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Contactnumber { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public System.DateTime Ssd { get; set; }

        public int? PackageId { get; set; }

        public virtual PackageDetail PackageDetail { get; set; }
    }
}
