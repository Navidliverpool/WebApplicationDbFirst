//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.IO;
//using System.Linq;
//using System.Web;

//namespace WebApplicationDbFirst.Models.Services
//{
//    public class ContentRepository
//    {
//        private readonly NavEcommerceDBfirstEntities db = new NavEcommerceDBfirstEntities();
//        public int UploadImageInDataBase(HttpPostedFileBase file, MotorcycleVM motorcycleVM)
//        {
//            motorcycleVM.Image = ConvertToBytes(file);
//            var Content = new Motorcycle
//            {
//                Image = motorcycleVM.Image
                
//            };
//            db.Motorcycles.Add(Content);
//            int i = db.SaveChanges();
//            if (i == 1)
//            {
//                return 1;
//            }
//            else
//            {
//                return 0;
//            }
//        }

//        public byte[] ConvertToBytes(HttpPostedFileBase image)
//        {
//            byte[] imageBytes = null;
//            BinaryReader reader = new BinaryReader(image.InputStream);
//            imageBytes = reader.ReadBytes((int)image.ContentLength);
//            return imageBytes;
//        }
//    }
//}