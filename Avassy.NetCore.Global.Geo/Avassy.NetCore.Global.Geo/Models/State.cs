namespace Avassy.NetCore.Global.Geo.Models
{
    public class State : Base
    {
        public string Code { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }
    }
}
