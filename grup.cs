namespace QUIZPROGRAM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("grup")]
    public partial class grup
    {
        public int ID { get; set; }

        public int? A { get; set; }

        public int? B { get; set; }

        public int? C { get; set; }

        public int? D { get; set; }

        public int? E { get; set; }

        public int? F { get; set; }

        public int? G { get; set; }

        public int? L { get; set; }

        [StringLength(1)]
        public string SORU { get; set; }
    }
}
