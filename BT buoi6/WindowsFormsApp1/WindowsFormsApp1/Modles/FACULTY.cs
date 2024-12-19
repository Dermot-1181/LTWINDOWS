namespace WindowsFormsApp1.Modles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FACULTY")]
    public partial class FACULTY
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FACULTYID { get; set; }

        [Required]
        [StringLength(200)]
        public string FACULTYNAME { get; set; }
    }
}
