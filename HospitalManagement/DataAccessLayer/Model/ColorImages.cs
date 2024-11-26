using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.DataAccessLayer.Model
{
    [Table("ColorImages")]
    public  class ColorImages
    {
        [Key]
        public int ColorImagesId { get; set; }
        public string ColorImagesName { get; set; }
        public string? ColorName { get; set; }
        public string? ColorNamePicker { get; set; }
        public string ColorImagesImg { get; set; }
        public int StockId { get; set; }
    }
}
