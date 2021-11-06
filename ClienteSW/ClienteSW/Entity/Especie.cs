using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteSW.Entity
{
    public class Especie
    {
        private String id;
        private String nombre;
        private double estadoRegistro;
        private DateTime fechaModificacion;

        public Especie(string id, string nombre, double estadoRegistro, DateTime fechaModificacion)
        {
            this.id = id;
            this.nombre = nombre;
            this.estadoRegistro = estadoRegistro;
            this.fechaModificacion = fechaModificacion;
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double EstadoRegistro { get => estadoRegistro; set => estadoRegistro = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
    }
}