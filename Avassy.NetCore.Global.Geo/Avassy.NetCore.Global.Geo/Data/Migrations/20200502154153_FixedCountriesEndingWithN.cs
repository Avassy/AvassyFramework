using Microsoft.EntityFrameworkCore.Migrations;

namespace Avassy.NetCore.Global.Geo.Data.Migrations
{
    public partial class FixedCountriesEndingWithN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("Countries", "IsoCode", "AF", "Name", "Afghanistan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "AZ", "Name", "Azerbaijan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "BH", "Name", "Bahrain");
            migrationBuilder.UpdateData("Countries", "IsoCode", "BJ", "Name", "Benin");
            migrationBuilder.UpdateData("Countries", "IsoCode", "BT", "Name", "Buhtan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "CM", "Name", "Cameroon");
            migrationBuilder.UpdateData("Countries", "IsoCode", "ES", "Name", "Spain");
            migrationBuilder.UpdateData("Countries", "IsoCode", "GA", "Name", "Gabon");
            migrationBuilder.UpdateData("Countries", "IsoCode", "IM", "Name", "Isle Of Man");
            migrationBuilder.UpdateData("Countries", "IsoCode", "IR", "Name", "Iran");
            migrationBuilder.UpdateData("Countries", "IsoCode", "JO", "Name", "Jordan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "JP", "Name", "Japan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "KG", "Name", "Kyrgyzstan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "KZ", "Name", "Kazakhstan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "LB", "Name", "Lebanon");
            migrationBuilder.UpdateData("Countries", "IsoCode", "LI", "Name", "Liechtenstein");
            migrationBuilder.UpdateData("Countries", "IsoCode", "MF", "Name", "Saint Martin");
            migrationBuilder.UpdateData("Countries", "IsoCode", "OM", "Name", "Oman");
            migrationBuilder.UpdateData("Countries", "IsoCode", "PK", "Name", "Pakistan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "PM", "Name", "Saint Pierre And Miquelon");
            migrationBuilder.UpdateData("Countries", "IsoCode", "RE", "Name", "Reunion");
            migrationBuilder.UpdateData("Countries", "IsoCode", "PK", "Name", "Pakistan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "SD", "Name", "Sudan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "SE", "Name", "Sweden");
            migrationBuilder.UpdateData("Countries", "IsoCode", "SJ", "Name", "Svalbard And Jan Mayen");
            migrationBuilder.UpdateData("Countries", "IsoCode", "SS", "Name", "South Sudan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "SX", "Name", "Sint Maarten");
            migrationBuilder.UpdateData("Countries", "IsoCode", "TJ", "Name", "Tajikistan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "TM", "Name", "Turkmenistan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "TW", "Name", "Taiwan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "UZ", "Name", "Uzbekistan");
            migrationBuilder.UpdateData("Countries", "IsoCode", "YE", "Name", "Yemen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
