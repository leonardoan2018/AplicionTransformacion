<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmPasosAmbientes.aspx.cs" Inherits="AplicacionTransformacion.Forms.FrmPasosAmbientes" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentContenido" runat="server">

    <script>

        function pageLoad() {
            $.datepicker.setDefaults($.datepicker.regional["es-ES"]);

            $("#<%= txtFechaPaso.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy',
                maxDate: (0)
            });
        }

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

        function abrirModalAdjuntar() {
            $("#modalAdjuntos").modal('show');

        }
        //$(document).ready(function () {
        //    $("#imgbtAgregarApoyoPaso").click(function () {
        //        var objGrupoApoyo = document.getElementById("ContentContenido_ddlGrupoApoyo");
        //        var idGrupoApoyo = objGrupoApoyo.options[objGrupoApoyo.selectedIndex].value;
        //        var GrupoApoyo = objGrupoApoyo.options[objGrupoApoyo.selectedIndex].text;
        //        var PersonaApoyo = $("#ContentContenido_txtNomPersonaApoyo").val();
        //        var TelefonoPersonaApoyo = $("#ContentContenido_txtTelPersonaApoyo").val();
        //        var markup = "<tr><td><input type='checkbox' name='record'></td><td style=" + "visibility:hidden" + ">" + idGrupoApoyo + "</td><td>" + GrupoApoyo + "</td><td>" + PersonaApoyo + "</td><td>" + TelefonoPersonaApoyo + "</td></tr>";
        //        $("table tbody").append(markup);
        //    });

        //    // Find and remove selected table rows
        //    $(".delete-row").click(function () {
        //        $("table tbody").find('input[name="record"]').each(function () {
        //            if ($(this).is(":checked")) {
        //                $(this).parents("tr").remove();
        //            }
        //        });
        //    });
        //});

    </script>

    <div class="container row top-buffer fuenteTitulo">
        Pasos entre ambiente preproductivos y productivos
   
    </div>

    <asp:UpdatePanel ID="upPasosAmbientes" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <%--Informacion de los pasos entre ambientes--%>
            <asp:Panel ID="pnlInfoPasos1" runat="server">

                <div class="container row top-buffer fuenteSubtitulo">
                    Información
                </div>

                <div class="container top-buffer">
                    <asp:LinkButton ID="btnvolverInfoPasos" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Regresar" OnClick="btnvolverInfoPasos_Click" Visible="false"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                </div>

                <div class="container row top-buffer">

                    <div class="col-xs-12 col-md-4">
                        <asp:Label ID="lblNombreAplicacion" runat="server" Text="Nombre" CssClass="fuenteTextoNormal"></asp:Label>

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

                    <div class="col-xs-12 col-md-3">
                        <asp:Label ID="Label2" runat="server" Text="Fecha de Instalación" CssClass="fuenteTextoNormal"></asp:Label>
                        <div class="input-group date" data-provide="datepicker">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-barcode" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtFechaPaso" runat="server" CssClass="form-control input-md"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-md-3">
                        <asp:Label ID="lblNroOC" runat="server" Text="Número OC" CssClass="fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtNroOC" runat="server" CssClass="form-control input-group-md"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-md-3">
                        <asp:Label ID="lblNumHarvest" runat="server" Text="Numero Harvest" CssClass="fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtNumHarvest" runat="server" CssClass="form-control input-group-md fuenteTextoNormal"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-md-3">
                        <asp:Label ID="lblResultado" runat="server" Text="Resultado" CssClass="fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:DropDownList ID="ddlResultado" runat="server" CssClass="form-control input-group-md">
                                <asp:ListItem>Seleccione un valor...</asp:ListItem>
                                <asp:ListItem>Pendiente Ejecución</asp:ListItem>
                                <asp:ListItem>Exitoso</asp:ListItem>
                                <asp:ListItem>Fallido</asp:ListItem>
                                <asp:ListItem>Cancelado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>

                <div class="container row top-buffer">

                    <div class="col-xs-12 col-md-12">
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" CssClass="fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtDescripcionPaso" runat="server" Rows="2" TextMode="MultiLine" CssClass="form-control fuenteTextoNormal"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="container row top-buffer">
                    <%--Botones--%>
                    <div class="col-xs-12 col-md-8 top-buffer">

                        <div class="input-group">

                            <asp:LinkButton ID="btnGuardarInfoPaso" runat="server" CssClass="btn btn-btnEstilo" OnClick="btnGuardarInfoPaso_Click" OnClientClick="return verificarEntradas()"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span> Guardar</asp:LinkButton>

                            <asp:LinkButton ID="btnGuardarEdicionPaso" runat="server" CssClass="btn btn-btnEstilo " OnClick="btnGuardarEdicionPaso_Click" Visible="false" OnClientClick="return verificarEntradas()"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span> Guardar**</asp:LinkButton>

                            <asp:LinkButton ID="btnConsultarInfoPasos" runat="server" CssClass="btn btn-btnEstilo espacioBotones" OnClick="btnConsultarInfoPasos_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span> Consultar</asp:LinkButton>

                            <asp:LinkButton ID="btnLimpiar" runat="server" CssClass="btn btn-btnEstilo espacioBotones" OnClick="btnLimpiar_Click"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span> Limpiar</asp:LinkButton>

                            <asp:LinkButton ID="lbtGruposApoyo" runat="server" CssClass="btn btn-btnEstilo espacioBotones" OnClick="lbtGruposApoyo_Click" Visible="false"><span aria-hidden="true" class="glyphicon glyphicon-dashboard"></span> Grupos Apoyo</asp:LinkButton>

                            <%--          <button class="btn btn-default espacioBotones" data-toggle="collapse" data-target="#collapseAreasApoyo" type="button"><span aria-hidden="true" class="glyphicon glyphicon-eye-open"></span>Grupos Apoyo</button>--%>
                        </div>
                    </div>

                </div>

                <%-- Ingreso de areas que apoyan los pasos--%>
                <asp:Panel ID="pnlApoyoPasos" runat="server" Visible="false">

                    <div class="container row top-buffer fuenteSubtitulo">
                        Información Grupos de Apoyo
                    </div>

                    <div class="container row top-buffer">

                        <div class="col-xs-12 col-md-4">
                            <asp:Label ID="lblGrupoApoyo" runat="server" Text="Grupo de Apoyo" CssClass="fuenteTextoNormal"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                <asp:DropDownList ID="ddlGrupoApoyo" runat="server" CssClass="form-control input-group-md"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-xs-12 col-md-4">
                            <asp:Label ID="lblNomPersonaApoyo" runat="server" Text="Nombre Persona Apoyo" CssClass="fuenteTextoNormal"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                <asp:TextBox ID="txtNomPersonaApoyo" runat="server" CssClass="form-control input-group-md fuenteTextoNormal"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-xs-12 col-md-2">
                            <asp:Label ID="lblTelPersonaApoyo" runat="server" Text="Telefono Persona Apoyo" CssClass="fuenteTextoNormal"></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                <asp:TextBox ID="txtTelPersonaApoyo" runat="server" CssClass="form-control input-group-md fuenteTextoNormal"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-xs-12 col-md-2">

                            <asp:Label ID="lblAgregarApoyo" runat="server" Text="Agregar nuevo apoyo" CssClass="fuenteTextoNormal"></asp:Label>

                            <asp:LinkButton ID="btnAgregarApoyoPaso" runat="server" CssClass="btn btn-default espacioBotones" OnClick="btnAgregarApoyoPaso_Click"><span aria-hidden="true" class="glyphicon glyphicon-plus"></span>Agregar</asp:LinkButton>
                        </div>

                    </div>

                    <%--<%--GridView para personas que apoyan el paso entre ambientes--%>


                    <div class=" row container top-buffer fuenteSubtitulo">
                        Grupos de apoyo                                                              
                    </div>

                    <div class="container row top-buffer">

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
            </asp:Panel>


            <asp:Panel ID="pnlAdjuntos" runat="server" Visible="false">
                <asp:UpdatePanel ID="upGrillaAdjuntos" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <div class="container row fuenteSubtitulo top-buffer">
                            Lista de Adjuntos
               
                        </div>


                        <div class="container row top-buffer">
                            <div class="col-xs-12">
                                <asp:LinkButton ID="btnAdjuntarArchivosPaso" runat="server" CssClass="btn btn-btnEstilo " OnClientClick="abrirModalAdjuntar()"><span aria-hidden="true" class="glyphicon glyphicon-cloud-upload"></span> Cargar Archivos</asp:LinkButton>
                            </div>
                        </div>



                        <div class="container row top-buffer">

                            <div class="col-xs-12 top-buffer">
                                <asp:GridView ID="gvAdjuntos" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-striped" DataKeyNames="Ruta"
                                    GridLines="None" ShowFooter="True" OnRowDataBound="gvAdjuntos_RowDataBound" HeaderStyle-HorizontalAlign="Center">
                                    <Columns>
                                        <asp:BoundField DataField="Id" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>


                                        <asp:TemplateField HeaderText="No.">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltralNo" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre ">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="imgbttEliminarAdjuntoDetalle" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEliminarAdjuntoDetalle_Click"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Descargar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla fuenteTextoNormal" HeaderStyle-Width="1%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="imgbttDescargar" runat="server" CssClass="btn btn-default btn-sm" ToolTip="descargar" OnClick="imgbttDescargar_Click"><span class="glyphicon glyphicon-cloud-download"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <EmptyDataTemplate>
                                        <asp:Label ID="lbGVVacio" runat="server" Text="No se encontraron datos." />
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>

                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="gvAdjuntos" />
                    </Triggers>
                </asp:UpdatePanel>

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



            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Modal adjuntos-->
    <asp:Panel ID="pnAdjuntar" CssClass="Pnlmensajes" runat="server">

        <div class="container">
            <div class="modal fade" id="modalAdjuntos" role="dialog">

                <div class="modal-dialog">


                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Adjuntar Archivos </h4>
                        </div>
                        <div id="contenidoPopudAdjuntos" class="modal-body">

                            <div class="row top-buffer">
                                <div class="col-xs-12">

                                    <div class="row top-buffer">

                                        <div class="col-xs-12 col-md-6">
                                            <asp:Label ID="Label18" runat="server" Text="Evidencia" CssClass="form-label fuenteTextoNormal"></asp:Label>
                                            <asp:FileUpload ID="fileUpload" runat="server" AllowMultiple="true" />
                                        </div>
                                    </div>

                                </div>

                            </div>

                            <div class="row top-buffer">
                                <div class="col-xs-12">
                                    <asp:LinkButton ID="lbtCargarArchivos" runat="server" CssClass="btn btn-btnEstilo " OnClick="lbtCargarArchivos_Click"><span aria-hidden="true" class="glyphicon glyphicon-cloud-upload"></span> Cargar </asp:LinkButton>

                                    <asp:LinkButton ID="lnkbAdjuntar" runat="server" CssClass="btn btn-btnEstilo espacioBotones" OnClick="lnkbAdjuntar_Click"><span aria-hidden="true" class="glyphicon glyphicon-paperclip"></span> Adjuntar </asp:LinkButton>

                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-xs-12">
                                    <asp:ListBox ID="lbxArchivosAdjuntos" runat="server" SelectionMode="Multiple" Width="100%"></asp:ListBox>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-xs-12">
                                    <asp:LinkButton ID="lbtEliminarAdjunto" runat="server" CssClass="btn btn-btnEstilo" OnClick="lbtEliminarAdjunto_Click"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span> Eliminar </asp:LinkButton>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal" id="btnCerrarAdjunetos">Cerrar</button>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </asp:Panel>
</asp:Content>
