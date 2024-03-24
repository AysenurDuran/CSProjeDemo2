using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Yonetici :Personel
    {
        public override string Title => "Yonetici";
        public override decimal HourlyWage => 500; // Minimum saatlik ücret

        // Yöneticiye verilen bonus miktarı
        public decimal Bonus { get; set; }

        public override decimal CalculateSalary()
        {
            // Bonus eklenerek maaş hesabı yapılır
            return (HourlyWage * WorkHours) + Bonus;
        }
    }
}
