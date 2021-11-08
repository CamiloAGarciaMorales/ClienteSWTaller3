
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
    public partial class WebForm2 : System.Web.UI.Page
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
        protected void Principal(object sender, EventArgs e)
        {
            Response.Redirect("GUIPrincipal.aspx");
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            WebClient webClient;
            webClient = new WebClient();  
            String uri ="";
            String res="";
            String id;
            Jugador jugador;

            id = txtId.Text;
            uri = "https://bi-app-postgress.herokuapp.com/app/api/jugador/" + id;
            res = webClient.DownloadString(uri);

            jugador = JsonConvert.DeserializeObject<Jugador>(res);
            try
            {
                txtCuenta.Text = jugador.Cuenta;
                txtEmail.Text = jugador.Email;
                txtContrasena.Text = jugador.Contrasena;
                txtApodo.Text = jugador.Apodo;
            }catch(Exception xe)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No esta mi pana" + "');", true);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string idd = txtId.Text.Trim();

            try
            {

                WebClient webClient;
                webClient = new WebClient();
                String uri = "";
                String res = "";
                String id;
                Jugador jugador;

                id = txtId.Text;
                uri = "https://bi-app-postgress.herokuapp.com/app/api/jugador/delete/" + id;
                res = webClient.UploadString(uri, "DELETE", "");


                ClientScript.RegisterStartupScript(this.GetType(), "Eliminacion", "alert('" + "Se elimino el jugador mi pana" + "');", true);
                txtCuenta.Text = "";
                txtEmail.Text = "";
                txtContrasena.Text = "";
                txtApodo.Text = "";
                txtId.Focus();
            }
            catch(Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No se pudo eliminar mi pana" + "');", true);
            }
           
        }

       
    }
}