<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmAdministacion.aspx.cs" Inherits="AplicacionTransformacion.Forms.FrmAdministacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/Transversal.js"></script>


    <script>

        function verificarEntradasAplicacion() {
            $("p").remove();
            var verificarVacios = "true";

            if (document.getElementById("<%= txtNombreAplicacion.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar el nombre de la aplicación</p>");
                verificarVacios = "false";
            }

            if (document.getElementById("<%= txtAW.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar el AW de la aplicaón</p>");
                verificarVacios = "false";
            }


            if (verificarVacios == "false") {
                $("#myModalMensaje").modal('show');
                return false;
            }
            else { return true }

        }

        function verificarEntradaTema() {
            $("p").remove();
            var verificarVacios = "true";

            if (document.getElementById("<%= txtNombreTema.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar el contenido</p>");
                verificarVacios = "false";
            }

            if (verificarVacios == "false") {
                $("#myModalMensaje").modal('show');
                return false;
            }
            else { return true }

        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContenido" runat="server">

    <div class="container row top-buffer fuenteTitulo">
        Aplicaciones Nuevo Titulo
    </div>

    <%-- Aplicaciones --%>
    <div class="row">
        <div class="container">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <a class="fuenteTituloAcordion" data-toggle="collapse" href="#collapseApliciones">Aplicaciones</a>
                    </div>

                    <div id="collapseApliciones" class="panel-collapse collapse">
                        <asp:UpdatePanel ID="upAplicaciones" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="container row top-buffer fuenteSubtitulo">
                                    Aplicaciones
                                </div>

                                <div class="container row top-buffer">
                                    <div class="col-xs-12 col-md-6">
                                        <asp:Label ID="lblNombreAplicacion" runat="server" Text="Nombre" CssClass="fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="txtNombreAplicacion" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-md-6">
                                        <asp:Label ID="lblAW" runat="server" Text="AW" CssClass="fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="txtAW" runat="server" CssClass="form-control input-group-md"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="container row top-buffer">
                                    <div class="col-xs-12 ">
                                        <div class="input-group">

                                            <asp:LinkButton ID="btnCrearAplicacion" runat="server" CssClass="btn btnEstilo" OnClick="btnCrearAplicacion_Click" OnClientClick="return verificarEntradasAplicacion()"><span aria-hidden="true" class="glyphicon glyphicon-book"></span> Registrar </asp:LinkButton>

                                            <asp:LinkButton ID="btnActualizarAplicacion" runat="server" CssClass="btn  btnEstilo espacioBotones" OnClick="btnActualizarAplicacion_Click" OnClientClick="return verificarEntradasAplicacion()" Visible="false"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span> Guardar</asp:LinkButton>

                                            <asp:LinkButton ID="btnCancelarAplicacion" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="btnCancelarAplicacion_Click"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span> Cancelar </asp:LinkButton>
                                        </div>
                                    </div>

                                </div>

                                <div class="container row top-buffer fuenteSubtitulo">
                                    Lista de Aplicaciones
                                </div>


                                <div class="container row top-buffer">
                                    <div class="col-xs-12">
                                        <asp:GridView ID="gvAplicaciones" runat="server" AutoGenerateColumns="False"
                                            CssClass="container table table-hover table-striped" DataKeyNames="Id"
                                            GridLines="None" ShowFooter="True" Width="100%" OnRowDataBound="gvAplicaciones_DataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="IdAplicacion" Visible="False" />

                                                <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" HeaderStyle-Width="1%">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltralNo" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="AW" HeaderText="AW" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgbttEditarAplicacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEditarAplicacion_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgbttEliminarAplicacion" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEliminarAplicacion_Click"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lbGVVacio" runat="server" Text="No se encontraron datos." />
                                            </EmptyDataTemplate>
                                            <RowStyle HorizontalAlign="Left" />

                                        </asp:GridView>
                                    </div>
                                </div>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Temas --%>
    <div class="row top-buffer">
        <div class="container">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <a class="fuenteTituloAcordion" data-toggle="collapse" href="#collapseTemas">Temas</a>
                    </div>

                    <div id="collapseTemas" class="panel-collapse collapse">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="container row top-buffer fuenteSubtitulo">
                                    Temas
                                </div>

                                <div class="container row top-buffer">
                                    <div class="col-xs-12 col-md-6">
                                        <asp:Label ID="Label1" runat="server" Text="Aplicación" CssClass="fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                            <asp:DropDownList ID="dpAplicacionesTema" runat="server" CssClass="form-control input-md" AutoPostBack="true" OnSelectedIndexChanged="dpAplicacionesTema_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-md-6">
                                        <asp:Label ID="Label2" runat="server" Text="Nombre" CssClass="fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="txtNombreTema" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="container row top-buffer">
                                    <div class="col-xs-12 ">
                                        <div class="input-group">

                                            <asp:LinkButton ID="lbtCrearTema" runat="server" CssClass="btn btnEstilo" OnClick="lbtCrearTema_Click" OnClientClick="return verificarEntradaTema()"><span aria-hidden="true" class="glyphicon glyphicon-book"></span> Registrar </asp:LinkButton>

                                            <asp:LinkButton ID="lbtEditarTema" runat="server" CssClass="btn  btnEstilo espacioBotones" OnClick="lbtEditarTema_Click" OnClientClick="return verificarEntradaTema()" Visible="false"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span> Guardar</asp:LinkButton>

                                            <asp:LinkButton ID="lbtCancelarTema" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="lbtCancelarTema_Click"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span> Cancelar </asp:LinkButton>
                                        </div>
                                    </div>

                                </div>

                                <div class="container row top-buffer fuenteSubtitulo">
                                    Lista de Temas
                                </div>


                                <div class="container row top-buffer">
                                    <div class="col-xs-12">
                                        <asp:GridView ID="gvTemas" runat="server" AutoGenerateColumns="False"
                                            CssClass="container table table-hover table-striped" DataKeyNames="Id"
                                            GridLines="None" ShowFooter="True" Width="100%" OnRowDataBound="gvTemas_DataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="IdContenido" Visible="False" />

                                                <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" HeaderStyle-Width="1%">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltralNo" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="IdAplicacion" HeaderText="IdAplicacion" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgbttEditarTema" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEditarTema_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgbttEliminarTema" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEliminarTema_Click"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <EmptyDataTemplate>
                                                <asp:Label ID="lbGVVacio" runat="server" Text="No se encontraron datos." />
                                            </EmptyDataTemplate>
                                            <RowStyle HorizontalAlign="Left" />

                                        </asp:GridView>
                                    </div>
                                </div>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
