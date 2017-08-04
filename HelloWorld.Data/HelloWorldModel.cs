namespace HelloWorld.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HelloWorldModel : DbContext
    {
        public HelloWorldModel()
            : base("name=HelloWorldModel")
        {
        }

        public DbSet<DataInputs> DataInputs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataInputs>()
               .Property(e => e.DataInputText)
               .IsUnicode(false);

        }
    }
}
