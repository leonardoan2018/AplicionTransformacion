﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHojaDatos.aspx.cs" Inherits="AplicacionTransformacion.Forms.FrmHojaDatos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>

        function verificarEntradaCategoria() {
            $("p").remove();
            var verificarVacios = "true";

            if (document.getElementById("<%= txtNombreCategoria.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar la categoria</p>");
                verificarVacios = "false";
            }
            if (verificarVacios == "false") {
                $("#myModalMensaje").modal('show');
                return false;
            }
            else { return true }
        }


        function verificarEntradaSubcategoria() {
            $("p").remove();
            var verificarVacios = "true";

            if (document.getElementById("<%= txtNombreSubcategoria.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar la subcategoria</p>");
                verificarVacios = "false";
            }

            if (verificarVacios == "false") {
                $("#myModalMensaje").modal('show');
                return false;
            }
            else { return true }
        }

        function verificarEntradaItemSubCategoria() {
            $("p").remove();
            var verificarVacios = "true";

            if (document.getElementById("<%= txtNombreItem.ClientID %>").value == '') {
                $("#contenidoPopudMensaje").append("<p>- Debe ingresar un nombre</p>");
                verificarVacios = "false";
            }

            if (document.getElementById("<%= txtDescripcionItem.ClientID %>").value == '') {
                   $("#contenidoPopudMensaje").append("<p>- Debe ingresar una descripción</p>");
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


    <div class="container row top-buffer fuenteTitulo">
        Hoja de datos 
    </div>


    <%-- Categoría --%>

    <div class="row top-buffer ">
        <div class="container">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <a class="fuenteTituloAcordion" data-toggle="collapse" href="#collCategoria">Categoria</a>
                    </div>
                    <div id="collCategoria" class="panel-collapse collapse">

                        <asp:UpdatePanel ID="upGeneral" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="container row top-buffer">
                                    <div class="col-xs-12 col-md-6">
                                        <asp:Label ID="Label5" runat="server" Text="Aplicaciones" CssClass="fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-signal" aria-hidden="true"></i></span>
                                            <asp:DropDownList ID="dpAplicacion" runat="server" CssClass="form-control input-md" OnSelectedIndexChanged="dpAplicacion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-md-6">
                                        <asp:Label ID="Label1" runat="server" Text="Nombre de la categoría" CssClass="form-label fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-tag" aria-hidden="true"></i></span>
                                            <asp:TextBox ID="txtNombreCategoria" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                        </div>
                                    </div>


                                </div>

                                <div class="container row top-buffer">
                                    <div class="col-xs-12 col-md-6">
                                        <div class="input-group">
                                            <asp:LinkButton ID="btnCrearCategoria" runat="server" CssClass="btn btnEstilo" OnClick="btnCrearCategoria_Click" OnClientClick="return verificarEntradaCategoria()"><span aria-hidden="true" class="glyphicon glyphicon-book"></span> Registrar </asp:LinkButton>

                                            <asp:LinkButton ID="btnActualizarCategoria" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="btnActualizarCategoria_Click" OnClientClick="return verificarEntradaCategoria()" Visible="false"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span> Guardar</asp:LinkButton>

                                            <asp:LinkButton ID="btnCancelarCategoria" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="btnCancelarCategoria_Click"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span> Cancelar </asp:LinkButton>

                                        </div>
                                    </div>
                                </div>

                                <div class="container row top-buffer fuenteSubtitulo">
                                    Lista Categorias
                                </div>

                                <div class="top-buffer table-responsive">
                                    <div class="col-xs-12">
                                        <asp:GridView ID="gvCategoria" runat="server" AutoGenerateColumns="False"
                                            GridLines="None" CssClass="table table-hover table-striped" DataKeyNames="Id" OnRowDataBound="gvCategoria_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="Categoria_ID" Visible="False" />

                                                <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla fuenteTextoNormal">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="ltralNo" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal"></asp:BoundField>

                                                <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgbttEditarCategoria" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Editar" OnClick="imgbttEditarCategoria_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="imgbttEliminarCategoria" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Eliminar" OnClick="imgbttEliminarCategoria_Click"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
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

    <%-- Subcategoria --%>

    <div class="row top-buffer ">
        <div class="container">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <a class="fuenteTituloAcordion" data-toggle="collapse" href="#collSubcate">Subcategoria</a>
                    </div>
                    <div id="collSubcate" class="panel-collapse collapse">

                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <asp:Panel ID="pnlSubcategoria" runat="server" Visible="true">

                                    <div class="container row top-buffer">

                                        <div class="col-xs-12 col-md-6">
                                            <asp:Label ID="Label22" runat="server" Text="Categorias" CssClass="fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-signal" aria-hidden="true"></i></span>
                                                <asp:DropDownList ID="dpCategoriaSubcategoria" runat="server" CssClass="form-control input-md"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-md-6">
                                            <asp:Label ID="Label7" runat="server" Text="Nombre de la subcategoría" CssClass="form-label fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-tag" aria-hidden="true"></i></span>
                                                <asp:TextBox ID="txtNombreSubcategoria" runat="server" CssClass="form-control input-md"></asp:TextBox>
                                            </div>
                                        </div>


                                    </div>


                                    <div class="container row top-buffer">
                                        <div class="col-xs-12 col-md-6">
                                            <div class="input-group">
                                                <asp:LinkButton ID="btnCrearSubcategoria" runat="server" CssClass="btn btnEstilo" OnClick="btnCrearSubcategoria_Click" OnClientClick="return verificarEntradaSubcategoria()"><span aria-hidden="true" class="glyphicon glyphicon-book"></span> Registrar </asp:LinkButton>

                                                <asp:LinkButton ID="btnActualizarSubcategoria" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="btnActualizarSubcategoria_Click" OnClientClick="return verificarEntradaSubcategoria()" Visible="false"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span> Guardar</asp:LinkButton>

                                                <asp:LinkButton ID="btnCancelarSubcategoria" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="btnCancelarSubcategoria_Click"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span> Cancelar </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>



                                    <div class="container row top-buffer fuenteSubtitulo">
                                        Lista Subcategorias
                                    </div>

                                    <div class="top-buffer table-responsive">
                                        <div class="col-xs-12">
                                            <asp:GridView ID="gvSubcategoria" runat="server" AutoGenerateColumns="False"
                                                DataKeyNames="Id" GridLines="None" CssClass="table table-hover table-striped" OnRowDataBound="gvSubcategoria_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="subCategoria_ID" Visible="False" />

                                                    <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla fuenteTextoNormal">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltralNo" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="NombreCategoria" HeaderText="Categoria" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal"></asp:BoundField>

                                                    <asp:BoundField DataField="NombreSubcategoria" HeaderText="Subcategoria" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal"></asp:BoundField>

                                                    <asp:TemplateField HeaderText="Detalle" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="imgbDetalleSubcategoria" runat="server" CssClass="btn btn-default btn-sm" OnClick="imgbDetalleSubcategoria_Click"><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="imgbttEditarSubcategoria" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Editar" OnClick="imgbttEditarSubcategoria_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="imgbttEliminarSubcategoria" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Eliminar" OnClick="imgbttEliminarSubcategoria_Click"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
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

                                </asp:Panel>

                                <asp:Panel ID="pnlDetalleSubcategoria" runat="server" Visible="false">

                                    <div class="row container top-buffer">
                                        <div class="container">
                                            <asp:LinkButton ID="lbtVolverSubcategorias" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Regresar a la lista de Contenidos" OnClick="lbtVolverSubcategorias_Click"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="container row fuenteSubtitulo">
                                        <asp:Label ID="lblDetalleSubcategoria" runat="server" Text="Ambiente" CssClass="fuenteSubtitulo"></asp:Label>
                                    </div>

                                    <div class="container row top-buffer">

                                        <div class="col-xs-12 col-md-6">
                                            <asp:Label ID="Label4" runat="server" Text="Ambiente" CssClass="fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:DropDownList ID="dpAmbientes" runat="server" CssClass="form-control input-md" AutoPostBack="true" OnSelectedIndexChanged="dpAmbientes_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-md-6">
                                            <asp:Label ID="Label2" runat="server" Text="Nombre" CssClass="form-label fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:TextBox ID="txtNombreItem" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="container row top-buffer">

                                        <div class="col-xs-12">
                                            <asp:Label ID="Label3" runat="server" Text="Descripción" CssClass="form-label fuenteTextoNormal"></asp:Label>
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></i></span>
                                                <asp:TextBox ID="txtDescripcionItem" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="container row top-buffer">
                                        <div class="col-xs-12 col-md-6">
                                            <div class="input-group">
                                                <asp:LinkButton ID="lbtCrearItemSub" runat="server" CssClass="btn btnEstilo" OnClick="lbtCrearItemSub_Click" OnClientClick="return verificarEntradaItemSubCategoria()"><span aria-hidden="true" class="glyphicon glyphicon-book"></span> Registrar </asp:LinkButton>

                                                <asp:LinkButton ID="lbtEditarItemSub" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="lbtEditarItemSub_Click" OnClientClick="return verificarEntradaItemSubCategoria()" Visible="false"><span aria-hidden="true" class="glyphicon glyphicon-floppy-disk"></span> Guardar</asp:LinkButton>

                                                <asp:LinkButton ID="lbtCancelarItemSub" runat="server" CssClass="btn btnEstilo espacioBotones" OnClick="lbtCancelarItemSub_Click"><span aria-hidden="true" class="glyphicon glyphicon-remove"></span> Cancelar </asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="container row top-buffer fuenteSubtitulo">
                                        Items de la Subcategoria
                                    </div>

                                    <div class="top-buffer table-responsive">
                                        <div class="col-xs-12">
                                            <asp:GridView ID="gvItemSubcategoria" runat="server" AutoGenerateColumns="False"
                                                GridLines="None" CssClass="table table-hover table-striped" DataKeyNames="Id" OnRowDataBound="gvCategoria_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="Id" HeaderText="Categoria_ID" Visible="False" />

                                                    <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla fuenteTextoNormal">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="ltralNo" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="Ambiente" HeaderText="Ambiente" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal"></asp:BoundField>

                                                    <asp:BoundField DataField="NombreItem" HeaderText="Nombre" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal"></asp:BoundField>

                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="fuenteTextoNormal"></asp:BoundField>

                                                    <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="imgbttEditarItemSub" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Editar" OnClick="imgbttEditarItemSub_Click"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Eliminar" HeaderStyle-CssClass="headerGrilla" ItemStyle-CssClass="headerGrilla">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="imgbttEliminarItemSub" runat="server" CssClass="btn btn-default btn-sm" ToolTip="Eliminar" OnClick="imgbttEliminarItemSub_Click"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
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

                                </asp:Panel>


                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <%-- Reporte --%>

    <div class="row top-buffer ">
        <div class="container">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <a class="fuenteTituloAcordion" data-toggle="collapse" href="#collReporte">Reporte</a>
                    </div>
                    <div id="collReporte" class="panel-collapse collapse">


                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>

                                <div class="container row top-buffer">
                                    <div class="col-xs-12 col-md-4">
                                        <asp:Label ID="Label6" runat="server" Text="Categorias" CssClass="fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-signal" aria-hidden="true"></i></span>
                                            <asp:DropDownList ID="dpCategoriaReporte" runat="server" CssClass="form-control input-md" OnSelectedIndexChanged="dpCategoriaReporte_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-md-4">
                                        <asp:Label ID="Label8" runat="server" Text="Subcategorias" CssClass="fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-signal" aria-hidden="true"></i></span>
                                            <asp:DropDownList ID="dpSubcategoriaReporte" runat="server" CssClass="form-control input-md"></asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-md-4">
                                        <asp:Label ID="Label9" runat="server" Text="Ambientes" CssClass="fuenteTextoNormal"></asp:Label>
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-signal" aria-hidden="true"></i></span>
                                            <asp:DropDownList ID="dpAmbienteReporte" runat="server" CssClass="form-control input-md"></asp:DropDownList>
                                        </div>
                                    </div>


                                </div>

                                <div class="container row top-buffer">
                                    <div class="col-xs-12 col-md-2">
                                        <div class="input-group">
                                            <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass="btn btn-success" OnClick="btnGenerar_Click" />
                                        </div>
                                    </div>
                                </div>

                                <div class="container row top-buffer fuenteSubtitulo">
                                    <asp:Label ID="lblSubtituloReporte" runat="server" Text="Hoja de datos" Visible="false"></asp:Label>
                                </div>

                                <div class="row top-buffer">
                                    <div class="col-md-offset-2">

                                        <asp:Panel ID="pnlHojaDatos" CssClass="pnlReporte" ScrollBars="Auto" runat="server" Height="1px">


                                            <rsweb:ReportViewer ID="rvReporteHojaDatos" runat="server" Width="800px" Height="780px" CssClass="rvReporte">
                                                <LocalReport ReportPath="Reportes\ReporteHojaDatos.rdlc"></LocalReport>
                                            </rsweb:ReportViewer>

                                        </asp:Panel>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class="top-buffer">
    </div>

    <div class="top-buffer">
    </div>

</asp:Content>

