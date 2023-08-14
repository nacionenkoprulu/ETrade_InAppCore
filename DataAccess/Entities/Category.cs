#nullable disable
//Nulleble disable yapmasaydık Name prop'u zorunlu olacaktı. Yanına ? koyman gerekecekti. Bunu kolaylaştırmış olduk


using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Category : RecordBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } //Bunu zorunlu hale getirmiş olduk.

        public string Description { get; set; } //Zorunlu değil

        public List<Product> Products { get; set; } //Bir kategoride birden fazla ürün olabilir.

    }
}
