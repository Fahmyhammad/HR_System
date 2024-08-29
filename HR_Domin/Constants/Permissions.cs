using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HR_Domin.Helper;

namespace HR_Domin.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsFromModel(string moduel)
        {
            return new List<string>
            {
                $"Permissions.{moduel}.View",
                $"Permissions.{moduel}.Create",
                $"Permissions.{moduel}.Edit",
                $"Permissions.{moduel}.Delete",
            };
        }

        public static List<string> PermissionsList()
        {
            var allPermissions = new List<string>();

            foreach(var item in Enum.GetValues(typeof(PermissionModuleName)))
                allPermissions.AddRange(GeneratePermissionsFromModel(item.ToString()));
            return allPermissions;
        }

        public static class Home
        {
            public const string View = "Permissions.Home.View";
            public const string Create = "Permissions.Home.Create";
            public const string Edit = "Permissions.Home.Edit";
            public const string Delete = "Permissions.Home.Delete";
        }
        public static class Accounts
        {
            public const string View = "Permissions.Accounts.View";
            public const string Create = "Permissions.Accounts.Create";
            public const string Edit = "Permissions.Accounts.Edit";
            public const string Delete = "Permissions.Accounts.Delete";
        }
        public static class Employees
        {
            public const string View = "Permissions.Employees.View";
            public const string Create = "Permissions.Employees.Create";
            public const string Edit = "Permissions.Employees.Edit";
            public const string Delete = "Permissions.Employees.Delete";
        }
        public static class GeneralSettings
        {
            public const string View = "Permissions.GeneralSettings.View";
            public const string Create = "Permissions.GeneralSettings.Create";
            public const string Edit = "Permissions.GeneralSettings.Edit";
            public const string Delete = "Permissions.GeneralSettings.Delete";
        }

        public static class OfficialVacations
        {
            public const string View = "Permissions.OfficialVacations.View";
            public const string Create = "Permissions.OfficialVacations.Create";
            public const string Edit = "Permissions.OfficialVacations.Edit";
            public const string Delete = "Permissions.OfficialVacations.Delete";
        }
        public static class Absence
        {
            public const string View = "Permissions.Absence.View";
            public const string Create = "Permissions.Absence.Create";
            public const string Edit = "Permissions.Absence.Edit";
            public const string Delete = "Permissions.Absence.Delete";
        }
    }
}
