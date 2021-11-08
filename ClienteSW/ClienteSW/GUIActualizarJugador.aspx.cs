
using ClienteSW.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteSW
{
    public partial class GUIActualizarJugador : System.Web.UI.Page
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
            String uri = "";
            String res = "";
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
            }
            catch (Exception xe)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No esta mi pana" + "');", true);
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            String id;
            String cuen;
            String con;
            String apo;
            String email;
            int reg = 1;
            DateTime da = DateTime.Now;


            Jugador jugador;
            String uri;
            HttpClient cliente;
            HttpContent contenido;
            HttpResponseMessage res;
            String JugJson = "";

            id = txtId.Text.Trim();
            cuen = txtCuenta.Text.Trim();
            con = txtContrasena.Text.Trim();
            apo = txtApodo.Text.Trim();
            email = txtEmail.Text.Trim();

            try
            {
                jugador = new Jugador(id, cuen, con, apo, email, reg, da);

                JugJson = "{'id':'" + id + "','cuenta':'" + cuen + "','contrasena':'" + con + "','apodo':'" + apo + "','email':'" + email + "','estadoRegistro':" + reg + ",'fechaModificacion':'" + da.ToString("yyyy-MM-dd") + "'}";
                JugJson = JugJson.Replace((char)39, (char)34);

                cliente = new HttpClient();
                uri = "https://bi-app-postgress.herokuapp.com/app/api/jugador/update/" + id;
                cliente.BaseAddress = new Uri(uri);
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                contenido = new StringContent(JugJson, UTF8Encoding.UTF8, "application/json");
                cliente.PutAsync(uri, contenido);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se creo el jugador" + "');", true);
                txtId.Text = "";
                txtCuenta.Text = "";
                txtApodo.Text = "";
                txtContrasena.Text = "";
                txtEmail.Text = "";
                txtId.Focus();
            }
            catch (Exception xe)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No se pudo insertar mi pana" + "');", true);
            }

        }

    }
}