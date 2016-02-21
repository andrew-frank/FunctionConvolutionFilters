using lab1_filters.Filters;
using lab1_filters.Filters.Convolution_Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1_filters.Filters.Function_Filters;

namespace lab1_filters {
    class FiltersViewModel 
    {
        public FiltersViewModel() {
            IList = new List<Filter>();
            IList.Add(new IdentityFilter());
            IList.Add(new BlurFilter());
            IList.Add(new EdgeDetectionFilter());
            IList.Add(new EmbossFilter());
            IList.Add(new GaussianSmoothFilter());
            IList.Add(new SharpenFilter());
            IList.Add(new BrightnessFilter());
            IList.Add(new ContrastFilter());
            IList.Add(new NegationFilter());
            IList.Add(new GammaFilter());
        }

        public List<Filter> IList { get; set; }
    }
}
