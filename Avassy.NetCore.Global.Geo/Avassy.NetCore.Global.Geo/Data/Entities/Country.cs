using System;
using System.Collections.Generic;
using System.Text;

namespace Avassy.NetCore.Global.Geo.Data.Entities
{
    public class Country : Base
    {

        public Country()
        {
            
        }

        public Country(string isoCode, string name, int id)
        {
            this.IsoCode = isoCode;
            this.Name = name;
            this.Id = id;
        }

        public Country(string isoCode, string name, int id, string phoneNumberPrefix) : this(isoCode, name, id)
        {
            this.PhoneNumberPrefix = phoneNumberPrefix;
        }

        public string IsoCode { get; set; }

        public string PhoneNumberPrefix { get; set; }

        public virtual IEnumerable<State> States { get; set; }
    }
}
