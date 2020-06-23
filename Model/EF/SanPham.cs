namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDon = new HashSet<ChiTietHoaDon>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã sản phẩm")]
        public string Code { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }
        [Display(Name = "Giá sản phẩm")]
        public decimal? Price { get; set; }
        [Display(Name = "Giá khuyến mãi")]
        public decimal? PromotionPrice { get; set; }
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }
        
        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Thời điểm tạo")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "Thời điểm sửa")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Đồ Nam")]
        public bool Gender { get; set; }
        [Display(Name = "Top hot")]
        public bool Top { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        [Display(Name = "Danh mục sản phẩm")]
        public long ID_DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        public virtual DanhMucSP DanhMucSP { get; set; }
    }
}
