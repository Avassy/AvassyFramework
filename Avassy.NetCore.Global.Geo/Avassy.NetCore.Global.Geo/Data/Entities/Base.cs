using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace Avassy.NetCore.Global.Geo.Data.Entities
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
