<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmTemasContenido.aspx.cs" Inherits="AplicacionTransformacion.Forms.FrmTemasContenido" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <script>

  <%--      $(document).ready(function () {

            $.datepicker.setDefaults($.datepicker.regional["es"]);

            $("#<%= txtFechaHallazgo.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy',
                maxDate: (0)
            });


        });--%>


        function verificarEntradaContenido() {
            $("p").remove();
            var verificarVacios = "true";

            if (document.getElementById("<%= txtNombreContenido.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar el contenido</p>");
                verificarVacios = "false";
            }

            if (document.getElementById("<%= txtDescripcionContenido.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar una descripción para el contenido</p>");
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentContenido" runat="server">


<%--    <div class="container row">

        <div class="col-xs-12 col-md-2">
            <asp:Label ID="Label5" runat="server" Text="Fecha hallazgo" CssClass="fuenteTextoNormal"></asp:Label>
            <div class="input-group date" data-provide="datepicker">
                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar" aria-hidden="true"></i></span>
                <asp:TextBox ID="txtFechaHallazgo" runat="server" CssClass="form-control input-md"></asp:TextBox>
            </div>
        </div>
    </div>--%>

    <asp:UpdatePanel ID="upAplicacionesTemas" runat="server">
        <ContentTemplate>

            <asp:Panel ID="pnlTemas" runat="server">

                <div class="container row top-buffer fuenteTitulo">
                    Temas
                </div>

                <div class="container row top-buffer">
                    <div class="col-xs-12 col-md-6">
                        <asp:Label ID="lblAplicaciones" runat="server" Text="Aplicaciones" CssClass="fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:DropDownList ID="dpAplicaciones" runat="server" CssClass="form-control input-md" AutoPostBack="true" OnSelectedIndexChanged="dpAplicaciones_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-xs-12 col-md-6">
                    </div>
                </div>

                <div class="container row top-buffer fuenteSubtitulo">
                    Lista de Temas
                </div>

                <div class="container row top-buffer">
                    <div class="col-xs-12">
                        <asp:GridView ID="gvTemas" runat="server" AutoGenerateColumns="False"
                            CssClass="container table table-hover table-striped" DataKeyNames="Id"
                            GridLines="None" ShowFooter="True" Width="100%" OnRowDataBound="gvTemas_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="IdAplicacion" HeaderText="IdAplicacion" Visible="False" />
                                <asp:BoundField DataField="IdTema" HeaderText="IdTema" Visible="False" />

                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltralIdAplicacion" runat="server" Text='<%# Eval("IdAplicacion")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltralNo" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Contenidos" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="imgbContenidos" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbContenidos_Click"><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
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

            <asp:Panel ID="pnlContenidos" runat="server" Visible="false">

                <div class="row container top-buffer">
                    <div class="container">
                        <asp:LinkButton ID="btnvolverTemas" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Regresar a la lista de Temas" OnClick="btnvolverTemas_Click"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                    </div>
                </div>

                <div class="container row fuenteSubtitulo">
                    <asp:Label ID="lblTituloContenido" runat="server" Text="" CssClass="form-label fuenteSubtitulo"></asp:Label>
                </div>

                <div class="container row">
                    <div class="col-xs-12 col-md-6">
                        <asp:Label ID="lblItemTema" runat="server" Text="Nuevo Contenido" CssClass="form-label fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtNombreContenido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="container row">
                    <div class="col-xs-12">
                        <asp:Label ID="Label4" runat="server" Text="Descripción" CssClass="form-label fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtDescripcionContenido" Rows="4" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="container row top-buffer">
                    <div class="col-xs-12 ">
                        <div class="input-group">

                            <asp:LinkButton ID="lbtCrearContenido" runat="server" CssClass="btn btnEstilo" OnClick="lbtCrearContenido_Click" OnClientClick="return verificarEntradaContenido()"><span aria-hidden="true" class="glyphicon glyphicon-book"></span> Registrar </asp:LinkButton>

                            <asp:LinkButton ID="lbtEditarContenido" runat="server" CssClass="btn  btnEstilo espacioBotones" OnClick="lbtEditarContenido_Click" OnClientClick="return verificarEntradaContenido()" Visible="false"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span> Guardar</asp:LinkButton>

                            <asp:LinkButton ID="lbtCancelarContenido" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="lbtCancelarContenido_Click"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span> Cancelar </asp:LinkButton>
                        </div>
                    </div>

                </div>

                <div class="container row top-buffer fuenteSubtitulo">
                    Lista de Contenidos 
                </div>

                <div class="container row top-buffer">
                    <div class="col-xs-12 col-md-4">
                        <asp:Label ID="Label1" runat="server" Text="Criterio Busqueda" CssClass="fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:DropDownList ID="dpCriterioBusqueda" runat="server" CssClass="form-control input-md" AutoPostBack="true">
                                <asp:ListItem Value="Todo">Todo</asp:ListItem>
                                <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
                                <asp:ListItem Value="Descripcion">Descripción</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-xs-12 col-md-6 top-buffer">
                        <div class="input-group top-buffer">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtNombreCriterioBusqueda" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-md-2 top-buffer">
                        <div class="input-group top-buffer">
                            <asp:LinkButton ID="lbtBuscarCriterio" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="lbtBuscarCriterio_Click"><span aria-hidden="true" class="glyphicon glyphicon-search"></span> Buscar </asp:LinkButton>
                        </div>
                    </div>

                </div>

                <div class="container row top-buffer">
                    <div class="col-xs-12">
                        <asp:GridView ID="gvContenidos" runat="server" AutoGenerateColumns="False"
                            CssClass="container table table-hover table-striped" DataKeyNames="Id"
                            GridLines="None" ShowFooter="True" Width="100%" OnRowDataBound="gvContenidos_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="IdAplicacion" HeaderText="IdAplicacion" Visible="False" />

                                <asp:BoundField DataField="IdTema" HeaderText="IdTema" Visible="False" />

                                <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal" HeaderStyle-Width="1%">
                                    <ItemTemplate>
                                        <asp:Literal ID="ltralNo" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal">
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="imgbttEditarItemContenido" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEditarItemContenido_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="imgbttEliminarItemContenido" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbttEliminarItemContenido_Click"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Detalle" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="imgbDetalleContenido" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbDetalleContenido_Click"><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
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

            <asp:Panel ID="pnlDetalleContenido" runat="server" Visible="false">

                <div class="row container top-buffer">
                    <div class="container">
                        <asp:LinkButton ID="lbtVolverContenidos" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Regresar a la lista de Contenidos" OnClick="lbtVolverContenidos_Click"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                    </div>
                </div>

                <div class="container row fuenteSubtitulo">
                    Detalle Contenido
                </div>

                <div class="container row top-buffer">
                    <div class="col-xs-12 col-md-6">
                        <asp:Label ID="Label2" runat="server" Text="Nuevo Contenido" CssClass="form-label fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtDetalleNombreContenido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="container row">
                    <div class="col-xs-12">
                        <asp:Label ID="Label3" runat="server" Text="Descripción" CssClass="form-label fuenteTextoNormal"></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                            <asp:TextBox ID="txtDetalleDescripcionContenido" Rows="4" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>




            </asp:Panel>



            <asp:Panel ID="pnlAdjuntos" runat="server" Visible="false">

                <div class="container row fuenteSubtitulo top-buffer">
                    Lista de Adjuntos
                </div>

                <div class="container row top-buffer">
                    <div class="col-xs-12">
                        <asp:LinkButton ID="lbtAbrirModalAdjuntos" runat="server" CssClass="btn btnEstilo " OnClientClick="abrirModalAdjuntar()"><span aria-hidden="true" class="glyphicon glyphicon-cloud-upload"></span> Cargar Archivos</asp:LinkButton>
                    </div>
                </div>

                <asp:UpdatePanel ID="upGrillaAdjuntos" runat="server">
                    <ContentTemplate>



                        <div class="container row top-buffer">

                            <div class="col-xs-12 top-buffer">
                                <asp:GridView ID="gvAdjuntos" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-hover table-striped" DataKeyNames="RutaAdjunto"
                                    GridLines="None" ShowFooter="True" OnRowDataBound="gvAdjuntos_RowDataBound" HeaderStyle-HorizontalAlign="Center">
                                    <Columns>
                                        <asp:BoundField DataField="Id">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:BoundField>


                                        <asp:TemplateField HeaderText="No.">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltralNo" runat="server" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>


                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre ">
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
                                    <asp:LinkButton ID="lbtCargarArchivos" runat="server" CssClass="btn btnEstilo " OnClick="lbtCargarArchivos_Click"><span aria-hidden="true" class="glyphicon glyphicon-cloud-upload"></span> Cargar </asp:LinkButton>

                                    <asp:LinkButton ID="lnkbAdjuntar" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="lnkbAdjuntar_Click"><span aria-hidden="true" class="glyphicon glyphicon-paperclip"></span> Adjuntar </asp:LinkButton>

                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-xs-12">
                                    <asp:ListBox ID="lbxArchivosAdjuntos" runat="server" SelectionMode="Multiple" Width="100%"></asp:ListBox>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-xs-12">
                                    <asp:LinkButton ID="lbtEliminarAdjunto" runat="server" CssClass="btn btnEstilo" OnClick="lbtEliminarAdjunto_Click"><span aria-hidden="true" class="glyphicon glyphicon-trash"></span> Eliminar </asp:LinkButton>
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
