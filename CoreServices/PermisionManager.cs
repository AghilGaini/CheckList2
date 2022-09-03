using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices
{
    public static class PermisionManager
    {

        public static class Permisions
        {
            #region Security
            public const string Security_Users_HTTPGet = "C4AE3354-8AB9-4400-8F64-48F096DFDDE8";
            public const string Security_Roles_HTTPGet = "9A510F05-D201-4186-A776-854BB3714D2B";
            public const string Security_Permisions_HTTPGet = "07A4FBFF-9D77-4513-9898-FBA8D9113C55";
            public const string Security_Permisions_HTTPPost = "9C730A53-7FD2-4D36-9C54-4FC72A875A52";
            public const string Security_UserRole_HTTPGet = "C936E5CA-474F-4935-902A-FECA70191835";
            public const string Security_UserRole_HTTPPost = "CBDE4094-DFA1-43CB-9E29-816D3715DB4D";
            #endregion
        }

        public static List<KeyValuePair<string, string>> GetPermisions()
        {
            var type = typeof(Permisions);
            var fields = type.GetFields();
            var permisions = new List<KeyValuePair<string, string>>();

            foreach (var item in fields)
            {
                var value = item.GetValue(type);
                var name = item.Name.Replace("_", " ");
                permisions.Add(new KeyValuePair<string, string>(name, value.ToString()));
            }

            return permisions;

        }

        public static async Task SetPermisions(IUnitOfWork context)
        {
            var databasePermisions = await context._permision.GetAllAsync();
            var newPermisions = new List<PermisionDomain>();

            var projectPermisions = GetPermisions();

            foreach (var item in projectPermisions)
            {
                if (!databasePermisions.Any(r => r.Value == item.Value))
                {
                    newPermisions.Add(new PermisionDomain()
                    {
                        Title = item.Key,
                        Value = item.Value,
                    });
                }
            }

            if (await context._permision.AddRangeAsync(newPermisions))
            {
                context.Complete();
            }

        }


    }
}
