#nullable disable

//Nulleble disable yapmasaydık Name prop'u zorunlu olacaktı. Yanına ? koyman gerekecekti. Bunu kolaylaştırmış olduk

using AppCore.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Product : RecordBase
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; } //Zorunlu değil. Ama referans tipleri dataAnation ile zorunlu hale getirebilirsin
                                         //NotNull Nvarchar200 şeklinde oluşturacak

        [StringLength(500)]
        public string Description { get; set; } //BU zorunlu değil şuanda.

        public double UnitPrice { get; set; } //Değer tipler için zorunlu değilse soru işareti(int?) koymalısın. Şuan zorunlu

        public int StockAmount { get; set; } //Zorunlu

        public DateTime? ExpirationDate { get; set; } //Zorunlu değil. Son kullanma tarihi olanlar için girilebilir


        public int? CategoryId { get; set; } //Bir ürünün yalnızca bir kategorisi olacak. Kategori zorunlu değil.


        //Nulleble disable tanımladığın için şuan bu da zorunlu değil.
        public Category Category { get; set; } //Foreign Key tanımlıyorsan referansını da mutlaka ekle. İlişkileri kullanabilmek için.
        



    }
}
