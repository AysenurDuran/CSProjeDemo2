using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2
{
    public abstract class Personel
    {
        public string Name { get; set; }
        public abstract string Title { get; }
        public abstract decimal HourlyWage { get; }
        public int WorkHours { get; set; }
        public abstract decimal CalculateSalary();
    }
}
