using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Negocio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user) // Me va a validar cada vez que necesite si tengo una sesión activa.
        {
            Trainee trainee = user != null ? (Trainee)user : null;
            if (trainee != null && trainee.Id != 0) // Si vos te logueaste...
                return true; // Si la sesión está activa.
            else
                return false; // Si la sesión NO está activa.
        }
        public static bool esAdmin(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null;
            return trainee != null ? trainee.Admin : false ; //La prop admin es un bool.
        }
    }
}
