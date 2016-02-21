using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace lab1_filters.Filters.Function_Filters 
{
    class CustomFilter : FunctionFilter, IFunctionFilterOffset 
    {
        public override string FilterName {
            get { return "Custom Filter"; }
        }

        private double offset = 0;

        public double Offset 
        {
            get { return offset; }
            set { offset = value; }
        }

        private byte[] _customFunction;
        public byte[] CustomFunction {
            get { return _customFunction;  }
            set {
                if (value.Length == 256)
                    _customFunction = value;
                else
                    System.Diagnostics.Debug.WriteLine("wtf");
            }
        }


        public override WriteableBitmap ApplyFunctionFilter(System.Windows.Media.Imaging.BitmapImage originalBitmapImage) 
        {
            WriteableBitmap writableImage = new System.Windows.Media.Imaging.WriteableBitmap(originalBitmapImage);
            byte[] byteArr = writableImage.WriteableBitMapImageToArray();

            int num = 0;
            for (int i = 0; i < byteArr.Length; i++) {
                num = (int)(byteArr[i]);
                int val = (int)_customFunction[num] + (int)this.Offset;
                val = (val < 0 ? 0 : val);
                val = (val > 255 ? 255 : val);
                byteArr[i] = (byte)(val);
            }

            WriteableBitmap result = originalBitmapImage.ByteArrayToWritableBitmap(byteArr);
            return result;
        }
    }
}
