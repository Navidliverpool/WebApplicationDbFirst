//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace WebApplicationDbFirst.Models.Services
//{
//    public class UploadImageToDb 
//    {
//        public void UploadImageToDbImplementation(string fileTitle)
//        {
//            //NavEcommerceDBfirstEntities db = new NavEcommerceDBfirstEntities();
//            try
//            {
//                HttpPostedFileBase file = Request.Files[0];
//                byte[] imageSize = new byte[file.ContentLength];
//                file.InputStream.Read(imageSize, 0, (int)file.ContentLength);
//                MotorcycleVM image = new MotorcycleVM()
//                {
//                    Name = file.FileName.Split('\\').Last(),
//                    Size = file.ContentLength,
//                    Title = fileTitle,
//                    ID = 1,
//                    Image1 = imageSize
//                };
//            }
//            catch (Exception e)
//            {
//                ModelState.AddModelError("uploadError", e);
//            }
//        }
//    }
//}