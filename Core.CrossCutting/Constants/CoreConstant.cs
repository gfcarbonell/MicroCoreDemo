using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCutting.Constants
{
    public class CoreConstant
    {
        public const string CODE_USERNAME_PASSWORD_INVALID = "0000001";
        public const string CODE_EMAIL_PASSWORD_INVALID = "0000002";
        public const string CODE_CELLPHONE_PASSWORD_INVALID = "0000003";

        public const string MESSAGE_USERNAME_PASSWORD_INVALID = "Nombre de usuario o contraseña es incorrecto.";
        public const string MESSAGE_EMAIL_PASSWORD_INVALID = "Correo electrónico o contraseña es incorrecto.";
        public const string MESSAGE_CELLPHONE_PASSWORD_INVALID = "Número de celular o contraseña es incorrecto.";
    }
}
