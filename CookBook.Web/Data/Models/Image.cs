using System.ComponentModel.DataAnnotations;
using static CookBook.Web.Common.ModelConstants;

namespace CookBook.Web.Data.Models
{
    public class Image
    {
        [Key]
        [MaxLength(ModelIdMaxLength)]
        public Guid Id { get; set; }

        public byte[] DataBytes { get; set; }
    }
}
