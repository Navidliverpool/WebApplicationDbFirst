using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Hosting;
using WebApplicationDbFirst.Entities;

namespace WebApplicationDbFirst.Models.Services
{
    public class ResizeImages
    {
        private readonly NavEcommerceDBfirstEntities2 db = new NavEcommerceDBfirstEntities2();
        public void GetPhotoThumbnail(int realtyId, int width, int height)
        {
            // Loading photos’ info from database for specific Realty...
            //var photos = DocumentSession.Query<File>().Where(f => f.RealtyId == realtyId);
            var motorcycles = db.Motorcycles.Where(m => m.MotorcycleId == realtyId);
            if (motorcycles.Any())
            {
                var motor = motorcycles.First();

                new WebImage(motor.Image)
                    .Resize(width, height, false, true) // Resizing the image to 100x100 px on the fly...
                    .Crop(1, 1) // Cropping it to remove 1px border at top and left sides (bug in WebImage)
                    .Write();
            }

            // Loading a default photo for realties that don't have a Photo
            new webimage(hostingenvironment.mappath(@"~/content/images/dev7logo.png")).write();
        }
    }
}