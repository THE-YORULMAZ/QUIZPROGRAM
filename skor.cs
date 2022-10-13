namespace QUIZPROGRAM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("skor")]
    public partial class skor
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string GRUP_ADI { get; set; }

        public int? SORU_SAYISI { get; set; }

        public int? D_CEVAP { get; set; }

        public int? Y_CEVAP { get; set; }

        public int? PUAN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OYUN_TARIHI { get; set; }

        [StringLength(100)]
        public string OYUNCU_1 { get; set; }

        [StringLength(100)]
        public string OYUNCU_2 { get; set; }

        [StringLength(100)]
        public string OYUNCU_3 { get; set; }
    }
}
