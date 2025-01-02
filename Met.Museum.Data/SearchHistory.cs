using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Met.Museum.Data
{
    public class SearchHistory : BaseEntity
    {
        public Uri? SearchUrl { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
