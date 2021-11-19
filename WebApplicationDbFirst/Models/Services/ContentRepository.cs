using System.IO;
using System.Web;
using WebApplicationDbFirst.Entities;

namespace WebApplicationDbFirst.Models.Services
{
    public class ContentRepository
    {
        private readonly NavEcommerceDBfirstEntities2 db = new NavEcommerceDBfirstEntities2();
        public void UploadImageInDataBase(HttpPostedFileBase file, MotorcycleVM motorcycleVM)
        {
            motorcycleVM.Motorcycle.Image = ConvertToBytes(file);
            var Content = new Motorcycle
            {
                Image = motorcycleVM.Motorcycle.Image

            };
            db.Motorcycles.Add(Content);
            //int i = db.SaveChanges();
            //if (i == 1)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}