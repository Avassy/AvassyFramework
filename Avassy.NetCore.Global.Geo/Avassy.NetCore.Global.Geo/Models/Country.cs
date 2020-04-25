using System.Collections.Generic;

namespace Avassy.NetCore.Global.Geo.Models
{
    public class Country : Data.Entities.Base
    {
        public string IsoCode { get; set; }
        
        public virtual IEnumerable<State> States { get; set; }
    }
}
