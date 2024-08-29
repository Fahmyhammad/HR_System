using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Domin.Entity
{
    public class Employee
    {
        public string Id {  get; set; }
        public string Name { get; set; }
        public string Address {  get; set; }
        public string PhoneNumber {  get; set; }
        public Helper.Gender Genders { get; set; }
        public string Nationality {  get; set; }
        public DateTime Date { get; set; }
        public string NationalID {  get; set; }
        public decimal HourlyPrice { get; set; }
        public DateTime RetirementDate {  get; set; }
        public decimal Salary {  get; set; }
        //الحضور
        public DateTime AttendanceTime {  get; set; }
        // الانصراف
        public DateTime DepartureDate { get; set;}
    }
}
