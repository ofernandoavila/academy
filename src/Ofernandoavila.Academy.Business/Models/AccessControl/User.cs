using Ofernandoavila.Academy.Business.Models.Parameters;
using Ofernandoavila.Academy.Business.Utils.Security;
using Ofernandoavila.Academy.Business.Validations.AccessControl;

namespace Ofernandoavila.Academy.Business.Models.AccessControl
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool FirstAccess { get; set; }
        public DateTime SignUpDate { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
        public Guid SessionId { get; set; }
        public IEnumerable<Session> Session { get; set; }

        public User() { }

        public User(Guid id, string name, string email, string password, Guid roleId)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            FirstAccess = true;
            RoleId = roleId;
            Activate();
        }

        public override bool IsValid()
        {
            ValidationResult = new UserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool IsValid(string password)
        {
            Password = password;

            ValidationResult = new UsuarioPasswordValidation().Validate(this);
            return ValidationResult.IsValid;
        }
        public void EncryptPassword(string senha)
        {
            Password = SHA256Criptografy.Encrypt(senha);
        }
    }
}
