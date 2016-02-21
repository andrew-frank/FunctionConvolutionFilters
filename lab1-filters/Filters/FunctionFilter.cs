using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace lab1_filters.Filters 
{
    interface IFunctionFilterOffset 
    {
        double Offset {
            get;
            set;
        }
    }


    public abstract class FunctionFilter : Filter
    {
        public abstract WriteableBitmap ApplyFunctionFilter(BitmapImage originalBitmapImage);
    }
}