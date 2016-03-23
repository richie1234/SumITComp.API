using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SumITComp.Repository;
using SumITComp.Repository.Entities;


namespace SumITComp.API.Models
{
    public class SumITCompContextInitializer : CreateDatabaseIfNotExists<SumITCompAPIContext>
    {
        protected override void Seed(SumITCompAPIContext context)
        {
            var products = new List<Product>
            {

                new Product() {
                    Title = "DELL Inspiron i3452-5600BLK 14.0 Laptop with Windows 10 System",
                    Price = 10.50m,
                    Description = "NON TOUCH Inspiron 14 (3452) - Black cover. 14.0-inch HD (1366 x 768) Truelife LED-Backlit Display. Intel Celeron Processor N3050 (2M Cache, up to 2.16 GHz). 2GB Single Channel DDR3 1600MHz (2GBx1). 32GB eMMC. WinHome Entry Ntbk OneDrive 10. Intel HD Graphics. No Optical Drive. 3-in-1 Media Card Reader and USB 3.0. Bluetooth tied to wireless card. 802.11bgn + Bluetooth 4.0, 2.4 GHz, 1x1. Stereo speakers + MaxxAudio. Standard Keyboard, English. 40 WHr, 4-Cell Battery (removable). 45 Watt AC Adaptor. Power Cord, US/CAN"},

                new Product()
                {
                    Title = "HP Stream 11-r010nr 11.6-Inch Notebook (Intel Celeron Processor, 2GB RAM, 32 GB Hard Drive, Windows 10 Home 64",
                    Price =20,
                    Description = "Looking for a notebook that can keep up with your busy day? The HP Stream is the hard-working, smartly-designed notebook that's light on price."
                },
                new Product()
                {
                    Title = "ASUS F555LA-AB31 15.6-inch Full-HD Laptop (Core i3, 4GB RAM, 500GB HDD) with Windows 10",
                    Price = 30,
                    Description = "ASUS F555LA-AB31 15.6 FHD (19201080), matte, Laptop (Black), Intel Core i3-5010U 2.1GHz Broad well , 4GB DDR3L (1600MHz) , 500GB 5400RPM, DL DVDRW/CD-RW, 802.11AC, Bluetooth 4.0, Windows 10 (64bit)"
                
                },

                new Product()
                {
                    Title = "Apple A1181 Macbook 13.3 Laptop Intel C2D 2.4GHz 2GB 160GB DVDRW OSX10.5 MB403LL",
                    Price = 40,
                    Description = "macbook intel core 2 duo 2.0ghz or 1.83 ghz 2g of ram, comes with 60g to 80g hd."

                },

                new Product() {
                    Title = "Samsung Chromebook 2 11.6 Inch Laptop (Intel Celeron, 2 GB, 16 GB SSD, Silver)",
                    Price = 30,
                    Description = "The Chromebook 2 achieves simple perfection starting with its premium design. The leather-like cover is richly textured, upgrading its slim and sleek design further. Even more impressive is how productive it is. Its HD resolution screen, optimized video conferencing, and enhanced processor enable outstanding performance, especially with Wi-Fi speeds that are three times faster than before."
                },

                new Product() {
                    Title = "2016 NEW Edition Acer Aspire One 11 Cloudbook 11.6-inch Laptop, Intel Dual-Core Processor, 2GB RAM, 16GB SSD",
                    Price = 70,
                    Description = "tay productive and connected to what matters wherever you are with the Acer Aspire Cloudbook. This lightweight 11-inch laptop comes with 100GB of free OneDrive storage for two years, and with Windows 10 you get easy ways to snap apps in place, create new desktops, and work and play across all your devices."},
                                  
                new Product() {

                    Title = "2016 New Edition Lenovo 15.6-inch Premium Laptop, AMD Dual-Core Processor, 4GB Memory, 500GB Hard Drive, HD LED...",
                    Price = 70,
                    Description = "500GB hard drive for serviceable file storage space Holds your growing collection of digital photos, music and videos. 5400 rpm spindle speed for standard read/ write times.AMD Radeon R5 graphics Integrated graphics chipset with shared video memory provides solid image quality for Internet use, movies, basic photo editing and casual gaming."},

                new Product() {

                    Title = "HP 15-F211WM 15.6-Inch Touchscreen Laptop (Intel Celeron N2840, Dual Core, 4GB, 500GB HDD, DVD-RW, WIFI, HDMI",
                    Price = 90,
                    Description = "HP 15-F211WM Touchscreen Laptop Dual Core 4GB 500GB DVD-RW 15.6 HDMI Win 10"},

                new Product() {

                    Title = "Acer Chromebook, 11.6-inch HD, CB3-131-C3SZ (Intel Celeron, 2GB, 16GB, White)",
                    Price = 100,
                    Description = "Acer CB3-131-C3SZ Chromebook comes with these high level specs: Intel Celeron N2840 Dual-Core Processor 2.16GHz with Intel Burst Technology up to 2.58GHz, Google Chrome Operating System, 11.6 HD ComfyViewTM Widescreen IPS LED-backlit Display, Intel HD Graphics, 2048MB DDR3L SDRAM Memory, 16GB Internal Storage, Secure Digital (SD) card reader, 802.11AC Wi-Fi featuring MIMO technology (Dual-Band 2.4GHz and 5GHz), Bluetooth 4.0, Built-In HD Webcam, 1 - USB 3.0 Port, 1-USB 2.0 Port, 1 - HDMI Port, 3-Cell Li-Polymer Battery (3220 mAh), Up to 9-hours Battery Life, 2.43 lbs. | 1.1 kg (system unit only) (NX.G85AA.001)"},

            };

            products.ForEach(b => context.Products.Add(b));
            context.SaveChanges();



            //var order = new Order() { Customer = "John Doe", OrderDate = new DateTime(2014, 7, 10) };
            //var details = new List<OrderDetail>()
            //{
            //    new OrderDetail() {Product = products[0], Quantity = 1, Order = order},
            //    new OrderDetail() {Product = products[2], Quantity = 2, Order = order},
            //    new OrderDetail() {Product = products[1], Quantity = 3, Order = order}

            //};
            //context.Orders.Add(order);
            //details.ForEach(o => context.OrderDetails.Add(o));
            //context.SaveChanges();

            //order = new Order() { Customer = "Joe Smith", OrderDate = new DateTime(2014, 9, 18) };
            //details = new List<OrderDetail>()
            //{
            //    new OrderDetail() {Product = products[1], Quantity = 1, Order =  order},
            //    new OrderDetail() {Product = products[1], Quantity = 1, Order =  order}, 
            //    new OrderDetail() {Product = products[3], Quantity = 12, Order =  order},
            //    new OrderDetail() {Product = products[4], Quantity = 3, Order =  order}
            //};
            //context.Orders.Add(order);
            //details.ForEach(o => context.OrderDetails.Add(o));
            //context.SaveChanges();

            //order = new Order() { Customer = "Ward Bell", OrderDate = new DateTime(2014, 12, 25) };
            //details = new List<OrderDetail>()
            //{
            //    new OrderDetail() {Product = products[2], Quantity = 1, Order =  order},
            //    new OrderDetail() {Product = products[4], Quantity = 1, Order =  order},
            //    new OrderDetail() {Product = products[3], Quantity = 1, Order =  order},
            //    new OrderDetail() {Product = products[1], Quantity = 3, Order =  order}
            //};

            //context.Orders.Add(order);
            //details.ForEach(od => context.OrderDetails.Add(od));
            //context.SaveChanges();
            

            base.Seed(context);

        }
    }
}