using Microsoft.AspNetCore.Mvc;

namespace PrjtA.Controllers
{
    public class MediaController : Controller
    {
        private readonly ILogger<MediaController> _logger;
        private readonly IWebHostEnvironment _environment;
        public MediaController(ILogger<MediaController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }
        /*****  Slider Images *****/
      
       public ActionResult SlideImg(int id = 0)
        {
            string dir = Path.Combine("wwwroot", "DATA/IMG/SLIDER");

            var path = "";
            string imgpath = "";
            DirectoryInfo d = new DirectoryInfo(dir);
            if (d.Exists)
            {
                foreach (FileInfo file in d.GetFiles("*.*"))
                {
                    if (file.Name.EndsWith(".jpg") || file.Name.EndsWith(".jpeg") || file.Name.EndsWith(".png"))
                    {
                        if (file.Name.StartsWith("slide-" + id + "-"))
                        {
                            imgpath = file.Name;
                            break;
                        }
                    }
                }
            }

            if (imgpath.Trim() != "")
            {
                path = Path.Combine(dir, imgpath);
                FileInfo imgfile = new FileInfo(imgpath);

                byte[] fileContent = System.IO.File.ReadAllBytes(path);

                if (imgfile.Name.EndsWith(".jpg"))
                    return base.File(fileContent, "image/jpeg");
                else if (imgfile.Name.EndsWith(".jpeg"))
                    return base.File(fileContent, "image/jpeg");
                else
                    return base.File(fileContent, "image/png");
            }
            else
            {
                path = Path.Combine("wwwroot", "images/noimage.png");
                byte[] fileContent = System.IO.File.ReadAllBytes(path);
                return File(fileContent, "image/png");
            }
        }
    }
}
