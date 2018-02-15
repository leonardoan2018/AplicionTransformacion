<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmPasosAmbientes.aspx.cs" Inherits="AplicacionTransformacion.Forms.FrmPasosAmbientes" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentContenido" runat="server">

    <script>

        function MostrarMensaje(mensajePopup) {
            $("p").remove();
            $("#contenidoPopudMensaje").append("<p>" + mensajePopup + "</p>");
            $("#myModalMensaje").modal('show');
        }

        function verificarEntradas() {
            $("p").remove();
            var verificarVacios = "true";

        <%--    if (document.getElementById("<%= txtFechaPaso.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar una fecha para el paso</p>");
                verificarVacios = "false";
            }--%>

            if (document.getElementById("<%= txtNroOC.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar la Orden de Cambio (OC)</p>");
                verificarVacios = "false";
            }

            if (document.getElementById("<%= txtNumHarvest.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar el número del paquete Harvest</p>");
                verificarVacios = "false";
            }

            if (document.getElementById("<%= ddlResultado.ClientID %>").value == 'Seleccione un valor...') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar un estado valido para el campo Resultado</p>");
                verificarVacios = "false";
            }

            if (verificarVacios == "false") {
                $("#myModalMensaje").modal('show');
                return false;
            }
            else { return true }
        }

    </script>

    <div class="container row top-buffer fuenteTitulo">
        Pasos entre ambiente preproductivos y productivos
   
    </div>

    <%-- Aplicaciones --%>
    <div class="row">
        <div class="container">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <a class="fuenteTituloAcordion" data-toggle="collapse" href="#collapsePasosAmbientes">Pasos entre Ambientes</a>
                    </div>

                    <div id="collapsePasosAmbientes" class="panel-collapse collapse">
                        <asp:UpdatePanel ID="upPasosAmbientes" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <asp:Panel ID="pnlInfoPasos1" runat="server">

                                    <%--Informacion de los pasos entre ambientes--%>
                                    <div class="container row top-buffer fuenteSubtitulo">
                                        Información
                               
                                    </div>

                                    <div class="container row top-buffer">

                                        <div class="col-xs-12 col-md-4">
                                            <asp:Label ID="lblNombreAplicacion" runat="server" Text="Nombre Aplicación" CssClass="fuenteTextoNormal"></asp:Label>

                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:DropDownList ID="ddlNomAplicacion" runat="server" CssClass="form-control input-group-md"></asp:DropDownList>

                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-md-4">
                                            <asp:Label ID="lblUsuario" runat="server" Text="Persona a cargo del paso" CssClass="fuenteTextoNormal"></asp:Label>

                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>

                                                <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-control input-group-md"></asp:DropDownList>

                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-md-4">
                                            <asp:Label ID="lblAmbiente" runat="server" Text="Ambiente" CssClass="fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:DropDownList ID="ddlAmbiente" runat="server" CssClass="form-control input-group-md">
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="container row top-buffer">

                                        <div class="col-xs-12 col-md-4">
                                            <asp:Label ID="lblFechaInstalacion" runat="server" Text="Fecha de Instalación" CssClass="fuenteTextoNormal"></asp:Label>

                                            <div class="input-group">

                                                <asp:TextBox ID="txtFechaPaso" runat="server" Visible="false" CssClass="form-control input-group-md fuenteTextoNormal"></asp:TextBox>

                                                <asp:LinkButton ID="imgCalendario" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgCalendario_Click"><span class="glyphicon glyphicon-calendar"></span></asp:LinkButton>

                                                <asp:Calendar ID="clrFechaPaso" runat="server" Visible="false" OnSelectionChanged="clrFechaPaso_SelectionChanged"></asp:Calendar>

                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-md-4">
                                            <asp:Label ID="lblNroOC" runat="server" Text="Número OC" CssClass="fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:TextBox ID="txtNroOC" runat="server" CssClass="form-control input-group-md"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-md-4">
                                            <asp:Label ID="lblNumHarvest" runat="server" Text="Numero Harvest" CssClass="fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:TextBox ID="txtNumHarvest" runat="server" CssClass="form-control input-group-md fuenteTextoNormal"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="container row top-buffer">

                                        <div class="col-xs-12 col-md-8">
                                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" CssClass="fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:TextBox ID="txtDescripcionPaso" runat="server" Rows="4" TextMode="MultiLine" CssClass="form-control fuenteTextoNormal"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-md-4">
                                            <asp:Label ID="lblResultado" runat="server" Text="Resultado" CssClass="fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:DropDownList ID="ddlResultado" runat="server" CssClass="form-control input-group-md">
                                                    <asp:ListItem>Seleccione un valor...</asp:ListItem>
                                                    <asp:ListItem>Exitoso</asp:ListItem>
                                                    <asp:ListItem>Fallido</asp:ListItem>
                                                    <asp:ListItem>Cancelado</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <%--Botones--%>
                                        <div class="col-xs-12 col-md-4 top-buffer">
                                            <div class="input-group">
                                                <asp:LinkButton ID="btnGuardarInfoPaso" runat="server" CssClass="btn btnEstilo " OnClick="btnGuardarInfoPaso_Click" OnClientClick="return verificarEntradas()"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span>Guardar</asp:LinkButton>

                                                <asp:LinkButton ID="btnGuardarEdicionPaso" runat="server" CssClass="btn btnEstilo " OnClick="btnGuardarEdicionPaso_Click" Visible="false" OnClientClick="return verificarEntradas()"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span>Guardar**</asp:LinkButton>

                                                <asp:LinkButton ID="btnConsultarInfoPasos" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="btnConsultarInfoPasos_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span>Consultar</asp:LinkButton>

                                                <asp:LinkButton ID="btnLimpiar" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="btnLimpiar_Click"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span>Limpiar</asp:LinkButton>

                                            </div>
                                        </div>
                                    </div>

                                </asp:Panel>

                                <asp:Panel ID="pnlInfoPasos2" runat="server">

                                    <div class="container row top-buffer fuenteSubtitulo">
                                        Listado de pasos entre ambientes                              
                                    </div>
                                    <%--GridView para ver la información de los pasos entre ambientes--%>
                                    <div class="container row top-buffer">
                                        <div class="col-xs-12 top-buffer">
                                            <asp:GridView ID="gvInfoPasos" runat="server" AutoGenerateColumns="False"
                                                CssClass="container table table-hover table-striped" DataKeyNames="Id"
                                                GridLines="None" ShowFooter="True" Width="100%" OnRowDataBound="gvInfoPasos_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />

                                                    <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" HeaderStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltralNo" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="NombreAplicacion" HeaderText="Aplicación" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre analista a cargo" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="NombreAmbiente" HeaderText="Ambiente" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="FechaInstalacion" HeaderText="Fecha Instalación" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="NumeroOC" HeaderText="Numero OC" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Harvest" HeaderText="Numero Harvest" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Resultado" HeaderText="Resultado" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="imgbttEditarInfoPaso" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEditarInfoPaso_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="imgbttEliminarInfoPaso" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEliminarInfoPaso_Click"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Detalle" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="imgbttDetalleInfoPaso" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttDetalleInfoPaso_Click"><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lbGVVacio" runat="server" Text="No se encontraron datos." />
                                                </EmptyDataTemplate>
                                                <RowStyle HorizontalAlign="Left" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    </div>
                                </div>
                                   
                                </asp:Panel>


                                <asp:Panel ID="pnlApoyoPasos" runat="server" Visible="false">

                                    <div class="container row top-buffer fuenteSubtitulo">
                                        Grupos de apoyo                            
                                    </div>

                                    <%--GridView para personas que apoyan el paso entre ambientes--%>

                                    <div class="container">
                                        <asp:LinkButton ID="btnvolverInfoPasos" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Regresar" OnClick="btnvolverInfoPasos_Click"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    </div>

                                    <div class="container row top-buffer">
                                        <div class="col-xs-12 top-buffer">
                                            <asp:GridView ID="gvApoyoPasos" runat="server" AutoGenerateColumns="False"
                                                CssClass="container table table-hover table-striped" DataKeyNames="Id"
                                                GridLines="None" ShowFooter="True" Width="100%" OnRowDataBound="gvInfoPasos_RowDataBound">
                                                <Columns>

                                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />

                                                    <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" HeaderStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltralNo" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:BoundField DataField="NombreArea" HeaderText="Grupo de Apoyo" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="PersonaApoyo" HeaderText="Persona que Apoya" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="TelefonoContacto" HeaderText="Telefono de Contacto" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <asp:Label ID="lbGVVacio" runat="server" Text="No se encontraron datos." />
                                                </EmptyDataTemplate>
                                                <RowStyle HorizontalAlign="Left" />
                                            </asp:GridView>
                                        </div>
                                </asp:Panel>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
