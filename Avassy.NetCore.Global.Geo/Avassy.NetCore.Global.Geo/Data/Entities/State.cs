using System;
using System.Collections.Generic;
using System.Text;

namespace Avassy.NetCore.Global.Geo.Data.Entities
{
    public class State : Base
    {
        public State()
        {
            
        }

        public State(int id, string code, string name, int countryId)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
            this.CountryId = countryId;
        }

        public string Code { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
