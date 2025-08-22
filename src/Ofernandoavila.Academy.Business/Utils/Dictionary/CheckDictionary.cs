using Ofernandoavila.Academy.Business.Models.Enumerator;

namespace Ofernandoavila.Academy.Business.Utils.Dictionary
{
    public class CheckDictionary
    {
        public static bool ValidateRole(Guid role)
        {
            return EnumDictionary.RoleDictionary().ContainsValue(role);
        }

        public static int GetRoleEnum(Guid guid)
        {
            return EnumDictionary.RoleDictionary().FirstOrDefault( e => e.Value == guid).Key;
        }

        public static Guid GetRoleId(RoleEnum role)
        {
            return EnumDictionary.RoleDictionary().FirstOrDefault( e => e.Key == (int)role ).Value;
        }
    }
}
