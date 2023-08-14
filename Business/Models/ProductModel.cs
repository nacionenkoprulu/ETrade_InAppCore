#nullable disable

using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{

    //Bunda da id ve Guid olmasını istiyoruz bu sebeple RecordBase'den miras alıyoruz. Entity'deki referans olmayan özellikleri modele getir.
    public class ProductModel : RecordBase 
    {
        #region ENTITY OZELLIKLERI

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public double UnitPrice { get; set; }

        public int StockAmount { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int? CategoryId { get; set; }

        #endregion

        //-----------------------------------------------------------------------------------

        #region Sayfaların ihtiyacı olan özellikler

        public string UnitPriceDisplay { get; set; }

        #endregion

    }
}
