using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public class Memur :Personel
    {
        public override string Title => "Memur";
        public override decimal HourlyWage { get; }

        // Memurun derecesine göre saatlik ücret belirlenir
        public Memur(int degree)
        {
            // Örnek olarak dereceye göre farklı ücretler atanmıştır
            switch (degree)
            {
                case 1:
                    HourlyWage = 400;
                    break;
                case 2:
                    HourlyWage = 450;
                    break;
                case 3:
                default:
                    HourlyWage = 500;
                    break;
            }
        }

        public override decimal CalculateSalary()
        {
            decimal totalSalary = 0;
            int normalHours = Math.Min(WorkHours, 180); // Maksimum 180 saatlik ücret hesabı

            // Normal çalışma saatlerinin maaşı hesaplanır
            totalSalary += normalHours * HourlyWage;

            // Eğer çalışma saati 180'den fazlaysa, fazla saatler için ek mesai ücreti eklenir
            if (WorkHours > 180)
            {
                int extraHours = WorkHours - 180;
                totalSalary += extraHours * (HourlyWage * 1.5m); // Ek mesai ücreti: saatlik ücretin 1.5 katı
            }

            return totalSalary;
        }
    }
}
