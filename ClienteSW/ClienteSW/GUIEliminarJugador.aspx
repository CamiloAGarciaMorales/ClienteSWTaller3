<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GUIEliminarJugador.aspx.cs" Inherits="ClienteSW.WebForm2" %>
<!doctype html>
<html lang="en">
    
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-F3w7mX95PdgyTmZZMECAngseQB83DfGTowi0iMjiWaeVhAn4FJkqJByhZMI3AhiU" crossorigin="anonymous">
   <%-- <link href="css/estilos.css" rel="stylesheet" />--%>
    <title>Eliminar Jugador</title>
  </head>
  <body>
      <form id="form2" runat="server" class="form-horizontal">
         <!-- Codigo menu barra -->
   <nav class="navbar navbar-expand-md navbar-dark bg-dark" aria-label="Fourth navbar example">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">Menu Principal</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarsExample04" aria-controls="navbarsExample04" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarsExample04">
        <ul class="navbar-nav me-auto mb-2 mb-md-0">
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="dropdown01" data-bs-toggle="dropdown" aria-expanded="false">Jugadores</a>
            <ul class="dropdown-menu" aria-labelledby="dropdown04">
              <li>
                  <asp:LinkButton ID="LbtnCrearJugador" runat="server" OnClick="LbtnCrearJugador_Click">Crear Jugador</asp:LinkButton>
              </li>
              <li><asp:LinkButton ID="LbtnEliminarJugador" runat="server" OnClick="LbtnEliminarJugador_Click">Eliminar Jugador</asp:LinkButton></li>
              <li><asp:LinkButton ID="LbtnActualizarJugador" runat="server" OnClick="LbtnActualizarJugador_Click">Actualizar Jugador</asp:LinkButton></li>
            </ul>
          </li>
         <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="dropdown02" data-bs-toggle="dropdown" aria-expanded="false">Personajes</a>
            <ul class="dropdown-menu" aria-labelledby="dropdown04">
              <li><asp:LinkButton ID="LbtnCrearPersonaje" runat="server" OnClick="LbtnCrearPersonaje_Click">Crear Personaje</asp:LinkButton></li>
              <li><asp:LinkButton ID="LbtinEliminarPersonaje" runat="server" OnClick="LbtinEliminarPersonaje_Click">Eliminar Personaje</asp:LinkButton></li>
              <li><asp:LinkButton ID="LbtnActualizarPersonaje" runat="server" OnClick="LbtnActualizarPersonaje_Click">Actualizar Personaje</asp:LinkButton></li>
            </ul>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle" href="#" id="dropdown03" data-bs-toggle="dropdown" aria-expanded="false">Listas</a>
            <ul class="dropdown-menu" aria-labelledby="dropdown04">
              <li><asp:LinkButton ID="LbtnirListar" runat="server" OnClick="LbtnirListar_Click">Listar</asp:LinkButton></li>
              <li><asp:LinkButton ID="LbtnirGraficar" runat="server" OnClick="LbtnirGraficar_Click">Graficar</asp:LinkButton></li>
                <li><asp:LinkButton ID="LbtnGraficarP" runat="server" OnClick="LbtnGraficarP_Click">Listar Personajes</asp:LinkButton></li>
            </ul>
          </li>

        </ul>    
      </div>
    </div>
  </nav>
      
      <div class="container well contenedor" >
          <div class="row">
              <div class="col-xs-12">
                  <h2>Eliminar Jugador</h2>
              </div>
          </div>
    <form id="form1" class="form-horizontal">

        <div class="form-group">
        <asp:Label ID="Label7" runat="server" Text="Id: " CssClass="control-label col-sm-2"></asp:Label>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ></asp:TextBox>
        </div> 
            <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Cuenta: " CssClass="control-label col-sm-2"></asp:Label></div>
            <div class="form-group">
                <asp:TextBox ID="txtCuenta" runat="server" CssClass="form-control"></asp:TextBox>
        </div>  
                <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Contrasena: " CssClass="control-label col-sm-2"></asp:Label></div>
            <div class="form-group">
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control"></asp:TextBox>
        </div>  
                    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Apodo: " CssClass="control-label col-sm-2"></asp:Label></div>
            <div class="form-group">
                <asp:TextBox ID="txtApodo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>  
           <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Email: " CssClass="control-label col-sm-2"></asp:Label></div>
            <div class="form-group">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        <div class="form-group">
            <asp:Button ID="btnCrear" runat="server" Text="Eliminar Jugador" CssClass="form-control btn btn-primary" BackColor="Black" OnClick="btnCrear_Click"  />
        </div>
         <br />
        <div class="form-group">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Jugador" CssClass="form-control btn btn-primary" BackColor="Black" OnClick="btnBuscar_Click"  />
        </div>



  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-/bQdsTh/da6pkI1MST/rWKFNjaCP5gBSY4sEBT38Q/9RBh9AH40zEOg7Hlq2THRZ" crossorigin="anonymous"></script>

    <!-- Option 2: Separate Popper and Bootstrap JS -->
    <!--
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.3/dist/umd/popper.min.js" integrity="sha384-W8fXfP3gkOKtndU4JGtKDvXbO53Wy8SZCQHczT5FMiiqmQfUpWbYdTil/SxwZgAN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.min.js" integrity="sha384-skAcpIdS7UcVUC05LJ9Dxay8AXcDYfBJqt1CJ85S/CFujBsIzCIv+l9liuYLaMQ/" crossorigin="anonymous"></script>
    -->

        </form>

  </div>
          </form>
  </body>
       
</html>