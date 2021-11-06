using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteSW.Entity
{
    public class Personaje
    {
        private String id;
        private String nombre;
        private double fuerza;
        private double mana;
        private double energia;
        private Especie especieid;
        private Jugador jugadorid;
        private double estadoRegistro;
        private DateTime fechaModificacion;

        public Personaje(string id, string nombre, double fuerza, double mana, double energia, Especie especieid, Jugador jugadorid, double estadoRegistro, DateTime fechaModificacion)
        {
            this.id = id;
            this.nombre = nombre;
            this.fuerza = fuerza;
            this.mana = mana;
            this.energia = energia;
            this.especieid = especieid;
            this.jugadorid = jugadorid;
            this.estadoRegistro = estadoRegistro;
            this.fechaModificacion = fechaModificacion;
        }
        public Personaje()
        {

        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Fuerza { get => fuerza; set => fuerza = value; }
        public double Mana { get => mana; set => mana = value; }
        public double Energia { get => energia; set => energia = value; }
        public Especie Especieid { get => especieid; set => especieid = value; }
        public Jugador Jugadorid { get => jugadorid; set => jugadorid = value; }
        public double EstadoRegistro { get => estadoRegistro; set => estadoRegistro = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
    }
}