namespace QUIZPROGRAM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sorular")]
    public partial class sorular
    {
        public int ID { get; set; }

        [Required]
        [StringLength(300)]
        public string SORU { get; set; }

        [Required]
        [StringLength(100)]
        public string A { get; set; }

        [Required]
        [StringLength(100)]
        public string B { get; set; }

        [Required]
        [StringLength(100)]
        public string C { get; set; }

        [Required]
        [StringLength(100)]
        public string D { get; set; }

        [Required]
        [StringLength(150)]
        public string DOGRU { get; set; }

        [Required]
        [StringLength(300)]
        public string KONUSU { get; set; }

        [Required]
        [StringLength(50)]
        public string SORUNUNSAYISI { get; set; }
    }
}
