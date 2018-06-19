using CaptchaGen;
using CodeCarvings.Piczard;
using CodeCarvings.Piczard.Filters.Watermarks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Long.Utilities
{
    public static class ImgHelper
    {

        public static void GenerateWatermark()
        {
            ImageWatermark imgWatermark = new ImageWatermark(@"C:\Program Files\longCode\LongRoom\Long.Test\img\star.ico");
            imgWatermark.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;//水印位置
            imgWatermark.Alpha = 50;//透明度，需要水印图片是背景透明的png图片
            ImageProcessingJob jobNormal = new ImageProcessingJob();
            jobNormal.Filters.Add(imgWatermark);//添加水印
            jobNormal.Filters.Add(new FixedResizeConstraint(600, 600));//限制图片的大小，避免生成大图。如果想原图大小处理，就不用加这个Filter
            jobNormal.SaveProcessedImageToFileSystem(@"C:\Program Files\longCode\LongRoom\Long.Test\img\test.png", @"C:\Program Files\longCode\LongRoom\Long.Test\img\cool.png");
        }

        public static void GenerateProcessedImage()
        {
            ImageProcessingJob jobNormal = new ImageProcessingJob();
            jobNormal.Filters.Add(new FixedResizeConstraint(200, 200));//限制图片的大小，避免生成大图。如果想原图大小处理，就不用加这个Filter
            jobNormal.SaveProcessedImageToFileSystem(@"C:\Program Files\longCode\LongRoom\Long.Test\img\dalong.png", @"C:\Program Files\longCode\LongRoom\Long.Test\img\dalong2.png");
        }

        public static void GenerateCaptchaCodeImage()
        {
            using (MemoryStream ms = ImageFactory.GenerateImage("AB12", 60, 100, 20, 6))
            using (FileStream fs = File.OpenWrite(@"C:\Program Files\longCode\LongRoom\Long.Test\img\1.jpg"))
            {
                ms.CopyTo(fs);
            }

        }
    }
}
