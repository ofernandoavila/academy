using Ofernandoavila.Academy.Business.Models.Enumerator;

namespace Ofernandoavila.Academy.Business.Utils.Dictionary
{
    public static class EnumDictionary
    {
        public static Dictionary<int, Guid> RoleDictionary()
        {
            return new Dictionary<int, Guid>
            {
                { (int)RoleEnum.System, Guid.Parse("3dab84b7-76f5-46eb-863b-9df45e93c0df") },
                { (int)RoleEnum.Administrator, Guid.Parse("f8ae9b0f-9e16-418c-8eab-2b7429e4523c") },
                { (int)RoleEnum.CourseCreator, Guid.Parse("f7deba1e-d9ae-4b41-bbed-ee293abd8628") },
                { (int)RoleEnum.Student, Guid.Parse("3e4196d5-faad-493f-b054-6b8396163953") },
            };
        }
    }
}
