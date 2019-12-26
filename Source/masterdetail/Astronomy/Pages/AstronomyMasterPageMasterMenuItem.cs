using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astronomy.Pages
{

    public class AstronomyMasterPageMasterMenuItem
    {
        public AstronomyMasterPageMasterMenuItem()
        {
            TargetType = typeof(AstronomyMasterPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}