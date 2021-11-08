
using ClienteSW.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteSW
{
    public partial class GUIEliminarPersonaje : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LbtnCrearJugador_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUICrearJugador.aspx");

        }

        protected void LbtnEliminarJugador_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIEliminarJugador.aspx");
        }

        protected void LbtnActualizarJugador_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIActualizarJugador.aspx");
        }

        protected void LbtnCrearPersonaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUICrearPersonaje.aspx");
        }

        protected void LbtinEliminarPersonaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIEliminarPersonaje.aspx");
        }

        protected void LbtnActualizarPersonaje_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIActualizarPersonaje.aspx");
        }

        protected void LbtnirListar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIListarJugadores.aspx");
        }

        protected void LbtnirGraficar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIGrafica.aspx");
        }
        protected void LbtnGraficarP_Click(object sender, EventArgs e)
        {
            Response.Redirect("GUIListarPersonajes.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            String id = txtId.Text.Trim();

            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";
            Personaje personaje;

            id = txtId.Text;
            uri = "https://bi-app-postgress.herokuapp.com/app/api/personaje/" + id;
            res = webClient.DownloadString(uri);

            personaje = JsonConvert.DeserializeObject<Personaje>(res);
            int pos = res.IndexOf(":{") + 1;
            int posF = res.IndexOf("},\"jugador\":")+ 1;
            String jsonEspecie = res.Substring(pos, posF - pos );

            pos = res.IndexOf("\"jugador\":") + 10;
            posF = res.IndexOf("},\"estadoRegistro\"") + 1;

            String jsonJugador = res.Substring(pos , posF - pos);

            Jugador jugador1;
            Especie especie1;
            jugador1 = JsonConvert.DeserializeObject<Jugador>(jsonJugador);
            especie1 = JsonConvert.DeserializeObject<Especie>(jsonEspecie);

            personaje.Especieid = especie1;
            personaje.Jugadorid = jugador1;
            try
            {

                txtNombre.Text = personaje.Nombre;
                txtFuerza.Text = Convert.ToString(personaje.Fuerza);
                txtMana.Text = Convert.ToString(personaje.Mana);
                txtEnergia.Text = Convert.ToString(personaje.Energia);
                txtEspecie.Text = personaje.Especieid.Id;
                txtJugador.Text = personaje.Jugadorid.Id;


            }
            catch(Exception xe)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No esta mi pana" + "');", true);
            }
            
            
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            string idd = txtId.Text.Trim();
            try
            {

                WebClient webClient;
                webClient = new WebClient();
                String uri = "";
                String res = "";
                String id;
                Personaje personaje;

                id = txtId.Text;
                uri = "https://bi-app-postgress.herokuapp.com/app/api/personaje/delete/" + id;
                res = webClient.UploadString(uri, "DELETE", "");

                ClientScript.RegisterStartupScript(this.GetType(), "Eliminacion", "alert('" + "Se elimino el personaje mi pana" + "');", true);
                txtNombre.Text = "";
                txtFuerza.Text = "";
                txtMana.Text = "";
                txtEnergia.Text = "";
                txtEspecie.Text = "";
                txtJugador.Text = "";
                txtId.Focus();
            }
            catch(Exception xe)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No se pudo elminar mi pana" + "');", true);
            }
            
        }

        
    }
}