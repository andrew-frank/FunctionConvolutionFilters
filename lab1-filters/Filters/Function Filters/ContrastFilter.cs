using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1_filters.Filters;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace lab1_filters.Filters.Function_Filters {
    sealed class ContrastFilter : FunctionFilter, IFunctionFilterOffset
    {
        public override string FilterName {
            get { return "Contrast"; }
        }


        private double offset = 0.0;

        public double Offset {
            get { return offset; }
            set { offset = value; }
        }

        public override WriteableBitmap ApplyFunctionFilter(System.Windows.Media.Imaging.BitmapImage originalBitmapImage) 
        {
            WriteableBitmap writableImage = new WriteableBitmap(originalBitmapImage);
            byte[] byteArr = writableImage.WriteableBitMapImageToArray();

            double pixel;
            Offset = (100 + Offset) / 100.0;
            for (int i = 0; i < byteArr.Length; i++) {
                pixel = ((double)byteArr[i]) / 255.0;
                pixel -= 0.5;
                pixel *= Offset;
                pixel += 0.5;
                pixel *= 255;

                pixel = (pixel < 0 ? 0 : pixel);
                pixel = (pixel > 255 ? 255 : pixel);

                byteArr[i] = (byte)pixel;
            }

            WriteableBitmap result = originalBitmapImage.ByteArrayToWritableBitmap(byteArr);
            return result;
        }
    }
}
