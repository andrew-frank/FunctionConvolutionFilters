using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace lab1_filters.Filters.Function_Filters {
    sealed class BrightnessFilter : FunctionFilter, IFunctionFilterOffset
    {
        public override string FilterName {
            get { return "Brightness"; }
        }

        private double offset = 0;

        public double Offset {
            get { return offset; }
            set { offset = value; }
        }

        public override WriteableBitmap ApplyFunctionFilter(System.Windows.Media.Imaging.BitmapImage originalBitmapImage) 
        {
            WriteableBitmap writableImage = new WriteableBitmap(originalBitmapImage);
            byte[] byteArr = writableImage.WriteableBitMapImageToArray();

            int num = 0;
            for (int i = 0; i < byteArr.Length; i++) {
                num = (int)(byteArr[i] + this.Offset);

                num = (num < 0 ? 0 : num);
                num = (num > 255 ? 255 : num);

                byteArr[i] = (byte)num;
            }

            WriteableBitmap result = originalBitmapImage.ByteArrayToWritableBitmap(byteArr);
            return result;
        }
    }
}
