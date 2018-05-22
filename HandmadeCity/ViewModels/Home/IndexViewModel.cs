using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandmadeCity.Data.Entities;

namespace HandmadeCity.ViewModels.Home
{
    public class IndexViewModel
    {
        public IList<Topic> Topics { get; set; }
    }
}
