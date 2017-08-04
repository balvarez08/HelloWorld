namespace HelloWorld.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class DataInputs
    {
        [Key]
        public int id { get; set; }
        public string DataInputText { get; set; }
    }
}
