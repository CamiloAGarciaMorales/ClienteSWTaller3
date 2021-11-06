using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteSW.Entity
{
    public class Jugador
    {
        private String id;
        private String cuenta;
        private String contrasena;
        private String apodo;
        private String email;
        private int estRegistro;
        private DateTime fechaModificacion;

        public Jugador(string id, string cuenta, string contrasena, string apodo, string email, int estRegistro, DateTime fechaModificacion)
        {
            this.id = id;
            this.cuenta = cuenta;
            this.contrasena = contrasena;
            this.apodo = apodo;
            this.email = email;
            this.estRegistro = estRegistro;
            this.fechaModificacion = fechaModificacion;
        }

        public string Id { get => id; set => id = value; }
        public string Cuenta { get => cuenta; set => cuenta = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public string Email { get => email; set => email = value; }
        public int EstRegistro { get => estRegistro; set => estRegistro = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
    }
}