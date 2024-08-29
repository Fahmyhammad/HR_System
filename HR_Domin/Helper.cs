using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Domin
{
    public static class Helper
    {
        public static string ErrorName {get;set;} = "يجب ادخال اسم المستخدم..";
        public static string ErrorAddress {get;set;} = "يجب ادخال العنوان";
        public static string ErrorMaxLenthe { get; set; } = "الحد لا يزيد عن عشرين حرف..";
        public static string ErrorMinLenthe { get; set; } = "الحد لا يقل عن ثلاث احرف";
        public static string ErrorRoleName { get; set; } = "يجب ادخال اسم الصلحة..";
        public static string ErrorEmail { get; set; } = "يجب ادخال البريد الالكتروني..";
        public static string ErrorEmailSuccessed { get; set; } = "يجب ادخال البريد الالكتروني بشكل صحيح..";
        public static string ErrorPassword { get; set; } = "يجب ادخال كلمة السر..";
        public static string ErrorCompPass { get; set; } = "يجب ادخال تاكيد كلمة السر..";
        public static string ErrorCompPassSuccessed { get; set; } = "كلمة السر غير مطابة..";
        public static string ErrorOldPassword { get; set; } = "يجب إدخال كلمة المرور القديمة.";
        public static string ErrorPhone { get; set; } = "يجب ادخال رقم الهاتف";
        public static string ErrorNationalID { get; set; } = "يجب ادخال الرقم القومي.";
        public static string ErrorMaxLenthePhone { get; set; } = "الحد لا يزيد عن احد عشر رقم..";
        public static string ErrorMinLenthePhone { get; set; } = "الحد لا يقل عن احد عشر رقم";
        public static string ErrorMaxLentheNational { get; set; } = "الحد لا يزيد عن اربعة عشر رقم..";
        public static string ErrorMinLentheNational { get; set; } = "الحد لا يقل عن اربعة عشر رقم";


        public enum Gender
        {
            ذكر,
            انثى
        }

        public enum TheAudience
        {
            حضور,
            غياب
        }


        public static string Admin { get; set; } = "Admin";
        public static string Editor { get; set; } = "الادارة";
        public static string Employees { get; set; } = "موظف";




        public const string Email = "fahmyroma690@gmail.com";
        public const string UserName = "fahmyroma690@gmail.com";
        public const string Name = "Fahmy Hammad";
        public const string Password ="Fahmy690@";

        public enum PermissionModuleName
        {
            Home,
            Accounts,
            Employees,
            GeneralSettings,
            OfficialVacations,
            Absence
        }


    }
}
