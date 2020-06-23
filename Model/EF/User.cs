namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Ta�i khoa�n")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name = "M��t kh��u")]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Ho� t�n")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "�i�a chi�")]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "�i��n thoa�i")]
        public string Phone { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Tra�ng tha�i")]
        public bool Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
