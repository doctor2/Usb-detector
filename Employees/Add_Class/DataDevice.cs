using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace Employees
{
   // [Serializable]
    [Table("DataDevice")]
    public class DataDevice
    {       
        public string Plug { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string MediaType { get; set; }
        public string Interface { get; set; }
        public string Capacity { get; set; }
        //[ Key]
        public DateTime Date { get; set; }
        //public string Date { get; set; }
    }
    public class ItemContext : DbContext
    {
        public ItemContext()
            : base("ItemConnection")
        {
          //  Database.SetInitializer<ItemContext>(new MyInitializer()); // то же написано в App.xaml.cs
        }
        public DbSet<DataDevice> History { get; set; }
    }

    public class MyInitializer
            : CreateDatabaseIfNotExists<ItemContext> 
    {
        protected override void Seed(ItemContext context)
        {
            //context.Comp.Add(new Computers() { ImagesPath = "/Content/Images/img1.jpg", Firm = "HP", Number = 1234567, Сharacteristics = "Частота процессора и тд и тп" });
            //context.Comp.Add(new Computers() { ImagesPath = "/Content/Images/img2.jpg", Firm = "Lenovo", Number = 1234563, Сharacteristics = "Частота процессора и тд и тп" });
            //context.Comp.Add(new Computers() { ImagesPath = "/Content/Images/img4.jpg", Firm = "ASUS", Number = 1234343, Сharacteristics = "Частота процессора и тд и тп" });

            //context.History.Add(new DataDevice()
            //{
            //    Plug = "Устройство подключено",
            //    Model = "dvsvds",
            //    Serial = "dsvsdvsdv",
            //    MediaType = "dvsvsdv",
            //    Interface = "dsvdvds",
            //    Capacity = "vsdvsdvsdv",
            //    Date = string.Format("{0:dd/MM/yy   H:mm:ss}", DateTime.Now)
            //});
           // context.SaveChanges();
            base.Seed(context);
         
        }
    }
}
