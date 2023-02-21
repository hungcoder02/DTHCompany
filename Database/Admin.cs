namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Required]
        //[StringLength(255)]
        //[DataType(DataType.Password)]
        //[Compare("Password")]
        //public string ConfirmPassword { get; set; }

            }
}
