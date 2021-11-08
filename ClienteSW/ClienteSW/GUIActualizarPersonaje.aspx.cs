
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
    public partial class GUIActualizarPersonaje : System.Web.UI.Page
    {

        Jugador jugador1;
        Especie especie1;

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
            int posF = res.IndexOf("},\"jugador\":") + 1;
            String jsonEspecie = res.Substring(pos, posF - pos);

            pos = res.IndexOf("\"jugador\":") + 10;
            posF = res.IndexOf("},\"estadoRegistro\"") + 1;

            String jsonJugador = res.Substring(pos, posF - pos);

            
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
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No se encontro mi pana" + "');", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            String id;
            String nom;
            double fue;
            double mana;
            double ener;
            
            double reg = 1;
            DateTime da = DateTime.Now;

            id = txtId.Text.Trim();

            WebClient webClient;
            webClient = new WebClient();
            String uri = "";
            String res = "";
            Personaje personaje;


            uri = "https://bi-app-postgress.herokuapp.com/app/api/personaje/" + id;
            res = webClient.DownloadString(uri);
            Personaje perso;

            HttpClient cliente;
            HttpContent contenido;

            String perJson = "";

            id = txtId.Text.Trim();
            nom = txtNombre.Text.Trim();
            fue = Convert.ToDouble(txtFuerza.Text.Trim());
            mana = Convert.ToDouble(txtMana.Text.Trim());
            ener = Convert.ToDouble(txtEnergia.Text.Trim());

            int pos = res.IndexOf(":{") + 1;
            int posF = res.IndexOf("},\"jugador\":") + 1;
            String jsonEspecie = res.Substring(pos, posF - pos);

            pos = res.IndexOf("\"jugador\":") + 10;
            posF = res.IndexOf("},\"estadoRegistro\"") + 1;

            String jsonJugador = res.Substring(pos, posF - pos);


            jugador1 = JsonConvert.DeserializeObject<Jugador>(jsonJugador);
            especie1 = JsonConvert.DeserializeObject<Especie>(jsonEspecie);

            

            try
            {
                perso = new Personaje(id, nom, fue, mana, ener, especie1, jugador1, reg, da);
                perso.Especieid = especie1;
                perso.Jugadorid = jugador1;
                perJson = "{'id':'" + id +
                    "','nombre':'" + nom +
                    "','fuerza':'" + fue +
                    "','mana':'" + mana +
                    "','energia':'" + ener +
                    "','especie':{" +
                        "'id':'" + especie1.Id +
                        "','nombre':'" + especie1.Nombre +
                        "','estadoRegistro':" + especie1.EstadoRegistro +
                        ",'fechaModificacion':'" + especie1.FechaModificacion.ToString("yyyy-MM-dd") + "'}," +
                    "'jugador':{" +
                        "'id':'" + jugador1.Id +
                        "','cuenta':'" + jugador1.Cuenta +
                        "','contrasena':'" + jugador1.Contrasena +
                        "','apodo':'" + jugador1.Apodo +
                        "','email':'" + jugador1.Email +
                        "','estadoRegistro':" + jugador1.EstRegistro +
                        ",'fechaModificacion':'" + jugador1.FechaModificacion.ToString("yyyy-MM-dd") + "'}" +
                    ",'estadoRegistro':" + reg +
                    ",'fechaModificacion':'" +
                      da.ToString("yyyy-MM-dd") + "'}";
                perJson = perJson.Replace((char)39, (char)34);

                cliente = new HttpClient();
                uri = "https://bi-app-postgress.herokuapp.com/app/api/personaje/update/" + id;
                cliente.BaseAddress = new Uri(uri);
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                contenido = new StringContent(perJson, UTF8Encoding.UTF8, "application/json");
                cliente.PutAsync(uri, contenido);
                ClientScript.RegisterStartupScript(this.GetType(), "Felicidades Shinji", "alert('" + "Se creo el Personaje" + "');", true);
                txtId.Text = "";
                txtNombre.Text = "";
                txtFuerza.Text = "";
                txtMana.Text = "";
                txtEnergia.Text = "";
                txtId.Focus();
            }
            catch (Exception xe)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No se pudo insertar mi pana" + "');", true);
            }
        }

        
    }
}