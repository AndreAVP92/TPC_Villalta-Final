<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="indexCliente.aspx.cs" Inherits="Vista.indexCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<section class="categoria contenedor" id="categorias">
            <h3>Nuestro listado de categorías</h3>
            <p class="after">Conoce las categorías especializadas</p>
            <br />
            <div class="card">
                <div class="content-card">
                    <div class="categoria">
                        <img src="img/005-support.png" alt="">
                    </div>
                    <div class="texto-categoria">
                        <h4>Carpintería</h4>
                        <p>Lorem bla bla bla bla bla.</p>
                    </div>
                </div>
                <div class="content-card">
                    <div class="categoria">
                        <img src="img/005-support.png" alt="">
                    </div>
                    <div class="texto-categoria">
                        <h4>Plomería</h4>
                        <p>Lorem bla bla bla bla bla.</p>
                    </div>
                </div>
                <div class="content-card">
                    <div class="categoria">
                        <img src="img/005-support.png" alt="">
                    </div>
                    <div class="texto-categoria">
                        <h4>Albañilería</h4>
                        <p>Lorem bla bla bla bla bla.</p>
                    </div>
                </div>
                <div class="content-card">
                    <div class="categoria">
                        <img src="img/005-support.png" alt="">
                    </div>
                    <div class="texto-categoria">
                        <h4>Pinturería</h4>
                        <p>Lorem bla bla bla bla bla.</p>
                    </div>
                </div>
            </div>
        </section>
        <section class="pasos" id="pasos">
            <div class="contenedor">
                <h3>¿Cómo funciona?</h3>
                <p class="after">Es fácil, sólo siga estos 3 pasos</p>
                <br />
                <div class="servicios">
                    <div class="caja-servicios">
                        <img src="img/001-call.png" alt="">
                        <h4>Soy un programador muy lento</h4>
                        <p>Lorem ipsum dolor sit amet consectetur</p>
                    </div>
                    <div class="caja-servicios">
                        <img src="img/005-support.png" alt="">
                        <h4>Soy un programador muy lento</h4>
                        <p>Lorem ipsum dolor sit amet consectetur</p>
                    </div>
                    <div class="caja-servicios">
                        <img src="img/002-clock.png" alt="">
                        <h4>Soy un programador muy lento</h4>
                        <p>Lorem ipsum dolor sit amet consectetur</p>
                    </div>
                </div>
            </div>
        </section>
        <section class="work contenedor" id="trabajo">
            <h3>Nuestro trabajo</h3>
            <p class="after">Vea las categorías especializadas</p>
            <div class="botones-work">
                <ul>
                    <li class="filter active" data-nombre='todos'>Todos</li>
                    <li class="filter" data-nombre='diseño'>Diseño</li>
                    <li class="filter" data-nombre='programacion'>Programacion</li>
                </ul>
            </div>
            <div class="galeria-work">
                <div class="cont-work programacion">
                    <div class="img-work">
                        <img src="img/plomero.jpg" alt="plomero">
                    </div>
                    <div class="textos-work">
                        <h4>Plomería</h4>
                    </div>
                </div>
                <div class="cont-work programacion">
                    <div class="img-work">
                        <img src="img/electricidad.jpg" alt="electricista">
                    </div>
                    <div class="textos-work">
                        <h4>Electricista</h4>
                    </div>
                </div>
                <div class="cont-work programacion">
                    <div class="img-work">
                        <img src="img/servicios.png" alt="servicios generales">
                    </div>
                    <div class="textos-work">
                        <h4>Servicios</h4>
                    </div>
                </div>
                <div class="cont-work diseño">
                    <div class="img-work">
                        <img src="img/constructor.png" alt="albañil">
                    </div>
                    <div class="textos-work">
                        <h4>Albañil</h4>
                    </div>
                </div>
            </div>
   </section>

</asp:Content>
