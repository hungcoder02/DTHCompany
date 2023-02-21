namespace Database
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    [Table("PackageDetail")]
    public partial class PackageDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PackageDetail()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int PackageId { get; set; }

        [Required]
        [StringLength(255)]
        public string Packagename { get; set; }

        public double Price { get; set; }

        [Required]
        [StringLength(255)]
        public string Descrip { get; set; }

        [StringLength(255)]
        [DisplayName("Upload Image")]
        public string Img { get; set; }

        public int? DnDId { get; set; }

        public virtual DnD DnD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
