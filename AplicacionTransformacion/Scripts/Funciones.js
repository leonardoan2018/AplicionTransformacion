function ValidarLetra(e) {
    var tecla = e.keyCode;
    if ((tecla > 34 && tecla < 41 || tecla == 8 || tecla == 9 || tecla == 46)) {
        return true;
    }
    tecla = (document.all) ? e.keyCode : e.which;
    patron = /[A-ZÑa-zñ\s]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}





function ValidEntrada(e) {
    if (window.event) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return ((tecla > 47 && tecla < 58));
    }
    else {
        var tecla = e.keyCode;
        if (tecla > 0) {
            return ((tecla > 34 && tecla < 41 || tecla == 8 || tecla == 46));
        }
        else {
            tecla = e.which;
            return ((tecla > 47 && tecla < 58));
        }
    }
}

function ValidEntradaDecimal(e) {
    if (window.event) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return ((tecla > 47 && tecla < 58 || tecla == 44));
    }
    else {
        var tecla = e.keyCode;
        if (tecla > 0) {
            return ((tecla > 34 && tecla < 41 || tecla == 8 || tecla == 46 || tecla == 188 || tecla == 9));
        }
        else {
            tecla = e.which;
            return ((tecla > 47 && tecla < 58 || tecla == 44));
        }
    }
}

function ValidNum(e) {
    if (window.event) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return ((tecla > 47 && tecla < 58));
    } else {
        var tecla = e.keyCode;
        if (tecla > 0) {
            return ((tecla > 34 && tecla < 41 || tecla == 8 || tecla == 9 || tecla == 46));
        } else {
            tecla = e.which;
            return ((tecla > 47 && tecla < 58));
        }
    }
}



function ValidarDigitoVerifiEntidad(sender, args) {
    var documentoIdentifica = document.getElementById('ContenidoPrincipal_txtNumDocumento').value.trim();
    var digitoVerfi = document.getElementById('ContenidoPrincipal_txtDv').value.trim();

    if (documentoIdentifica.length > 0 && digitoVerfi.length > 0) {
        var numerosPirmos = [3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53, 59, 67, 71];
        var suma = 0;

        for (var i = documentoIdentifica.length - 1 ; i >= 0; i--) {
            suma += documentoIdentifica.charAt(i) * numerosPirmos[documentoIdentifica.length - 1 - i];
        }

        var residuo = suma % 11;
        var dvVerifi = 0;
        if (residuo == 0)
            dvVerifi = 0;
        else if (residuo == 1)
            dvVerifi = 1;
        else
            dvVerifi = 11 - residuo;

        if (digitoVerfi == dvVerifi)
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    else
        args.IsValid = true;
}

function ValidarDigitoVerifiTerce(sender, args) {
    var documentoIdentifica = document.getElementById('ContenidoPrincipal_txtNumDocumentoTercero').value.trim();
    var digitoVerfi = document.getElementById('ContenidoPrincipal_txtDvTercero').value.trim();

    if (documentoIdentifica.length > 0 && digitoVerfi.length > 0) {
        var numerosPirmos = [3, 7, 13, 17, 19, 23, 29, 37, 41, 43, 47, 53, 59, 67, 71];
        var suma = 0;

        for (var i = documentoIdentifica.length - 1 ; i >= 0; i--) {
            suma += documentoIdentifica.charAt(i) * numerosPirmos[documentoIdentifica.length - 1 - i];
        }

        var residuo = suma % 11;
        var dvVerifi = 0;
        if (residuo == 0)
            dvVerifi = 0;
        else if (residuo == 1)
            dvVerifi = 1;
        else
            dvVerifi = 11 - residuo;

        if (digitoVerfi == dvVerifi)
            args.IsValid = true;
        else
            args.IsValid = false;
    }
    else
        args.IsValid = true;
}

function AgregarARecaudadoresAsignados(sender, args) {
    var rolesDisponibles = document.getElementById('ContenidoPrincipal_lstBoxRecaudaDisponible');
    var rolSeleccionado = rolesDisponibles.selectedIndex;
    if (!(rolSeleccionado < 0) && rolSeleccionado < rolesDisponibles.options.length) {
        args.IsValid = true;
        return;
    }
    args.IsValid = false;
}

function AgregarARecaudadoresDisponibles(sender, args) {
    var rolesAsignados = document.getElementById('ContenidoPrincipal_lstBoxRecaudaAsignado');
    var rolSeleccionado = rolesAsignados.selectedIndex;
    if (!(rolSeleccionado < 0) && rolSeleccionado < rolesAsignados.options.length) {
        args.IsValid = true;
        return;
    }
    args.IsValid = false;
}

function ValidarListaRecaudadoresDisponible(sender, args) {
    var val = document.getElementById("ContenidoPrincipal_lstBoxRecaudaAsignado");
    var listinputs = val.getElementsByTagName("option");
    if (listinputs.length < 1) {
        args.IsValid = false;
        return;
    }
    args.IsValid = true;
}

function ValidarListaRecaudadores(sender, args) {
    var val = document.getElementById("ContenidoPrincipal_lstBoxRecaudadores");
    var listinputs = val.getElementsByTagName("option");
    if (listinputs.length < 1) {
        args.IsValid = false;
        return;
    }
    args.IsValid = true;
}

function verificarPorcentaje(input, e) {
    var tecla = e.keyCode;
    if (true) {
        if (tecla > 47 && tecla < 58 || tecla > 95 && tecla < 106 || tecla == 188) {
            var porcentaje = input.value;
            var contarComa = 0;
            var porcentajeNuevo = '';
            for (var i = 0; i < porcentaje.length; i++) {
                if (porcentaje.charAt(i) == ',') {
                    contarComa++;
                    if (contarComa <= 1) {
                        porcentajeNuevo += porcentaje.charAt(i);
                    }
                }
                else
                    porcentajeNuevo += porcentaje.charAt(i);
            }
            input.value = porcentajeNuevo;
        }
    }
}

function formatearNumeroMoneda(input, e) {
    var tecla = e.keyCode;
    if (tecla > 47 && tecla < 58 || tecla > 95 && tecla < 106 || tecla == 8 || tecla == 46) {
        var num = input.value.replace(/\$/g, '');
        num = num.replace(/\./g, '');
        num = num.replace(/\ /g, '');
        var contar = 0;
        var numero = '';
        for (var i = num.length - 1; i >= 0; i--) {
            contar++;
            numero += num.charAt(i);
            if (contar == 3 && i > 0) {
                numero += '.';
                contar = 0;
            }
        }
        input.value = '$' + numero.split('').reverse().join('');
        
    }
}

    function ValidarCuotas(sender, args) {
        var cuotas = parseInt(document.getElementById('ContenidoPrincipal_txtNumCuotas').value);

        if (cuotas > 0 && cuotas <= 36) {
            args.IsValid = true;
            return;
        }
        else {
            args.IsValid = false;
            return;
        }
    }

    function ValidarValorTotal(sender, args) {
        var txtValorTotal = parseInt(document.getElementById('ContenidoPrincipal_txtValorTotal').value.replace(/\$/g, '').replace(/\./g, '').replace(/\ /g, ''));
        if (txtValorTotal > 0) {
            args.IsValid = true;
            return;
        }
        else {
            args.IsValid = false;
            return;
        }
    }

    function ValidarValorCuota(sender, args) {
        var txtValorCuota = parseInt(document.getElementById('ContenidoPrincipal_txtNuevoValor').value.replace(/\$/g, '').replace(/\./g, '').replace(/\ /g, ''));
        var txtValorTotal = parseInt(document.getElementById('ContenidoPrincipal_txtValorTotal').value.replace(/\$/g, '').replace(/\./g, '').replace(/\ /g, ''));

        if (txtValorCuota > 0 && txtValorCuota <= txtValorTotal) {
            args.IsValid = true;
            return;
        }

        else {
            args.IsValid = false;
            return;
        }
    }

    function ValidarValorCuotasAcuerdo(sender, args) {
        var gvCuotasAcuerdo = document.getElementById('ContenidoPrincipal_gvAcuerdoPago');
        var txtValorTotal = document.getElementById('ContenidoPrincipal_txtValorTotal').value.replace(/\$/g, '').replace(/\./g, '').replace(/\ /g, '');
        if (gvCuotasAcuerdo == null) {
            args.IsValid = false;
            return;
        }
        else {
            var filasGrid = gvCuotasAcuerdo.getElementsByTagName('tr');
            if (filasGrid.length > 0) {
                var totalCuotas = 0;
                for (var i = 0; i < filasGrid.length; i++) {
                    var linkGvCuota = document.getElementById('ContenidoPrincipal_gvAcuerdoPago_lnkBttValorCuota_' + i);
                    if (linkGvCuota != null) {
                        linkGvCuota = linkGvCuota.text.replace(/\$/g, '').replace(/\./g, '').replace(/\ /g, '');
                        totalCuotas += parseInt(linkGvCuota);
                    }
                }
                if (totalCuotas == txtValorTotal) {
                    args.IsValid = true;
                    return;
                }
                else {
                    args.IsValid = false;
                    return;
                }
            }
            else {
                args.IsValid = false;
                return;
            }
        }
    }

    function ValidarFechasCierre(sender, args) {
        var txtFechaDesde = document.getElementById("ContenidoPrincipal_txtFechaDesde");
        var txtFechaHasta = document.getElementById("ContenidoPrincipal_txtFechaHasta");
        var textoDesde = txtFechaDesde.value;
        var textoHasta = txtFechaHasta.value;

        if (textoDesde.length > 0) {
            var seccionesFecha = textoDesde.split("/");
            var dia = seccionesFecha[0];
            var mes = seccionesFecha[1] - 1;
            var anio = seccionesFecha[2];

            var fechaDesde = new Date(anio, mes, dia);
        }
        else {
            args.IsValid = true;
            return;
        }

        if (textoHasta.length > 0) {
            var seccionesFecha = textoHasta.split("/");
            var dia = seccionesFecha[0];
            var mes = seccionesFecha[1] - 1;
            var anio = seccionesFecha[2];

            var fechaHasta = new Date(anio, mes, dia);
        }
        else {
            args.IsValid = true;
            return;
        }

        if (fechaDesde < fechaHasta) {
            args.IsValid = true;
            return;
        }
        else {
            args.IsValid = false;
            return;
        }
    }



    function ValidarGvGestion(sender, args) {
        var gridGestion = document.getElementById('ContenidoPrincipal_gvGestion');

        if (gridGestion == null) {
            args.IsValid = false;
            return;
        }
        else {
            var filasGrid = gridGestion.getElementsByTagName('tr');

            if (filasGrid.length > 0) {
                for (i = 0; i < filasGrid.length; i++) {
                    var chequeo = filasGrid[i].getElementsByTagName("input");
                    for (j = 0; j < chequeo.length; j++) {
                        if (chequeo[j].checked) {
                            args.IsValid = true;
                            return;
                        }
                    }
                }
                args.IsValid = false;
                return;
            }
            else {
                args.IsValid = false;
                return;
            }
        }

    }

    function ValidarGvDeudas(sender, args) {
        var gridGestion = document.getElementById('ContenidoPrincipal_gvDeudas');

        if (gridGestion == null) {
            args.IsValid = false;
            return;
        }
        else {
            var filasGrid = gridGestion.getElementsByTagName('tr');

            if (filasGrid.length > 0) {
                for (i = 0; i < filasGrid.length; i++) {
                    var chequeo = filasGrid[i].getElementsByTagName("input");
                    for (j = 0; j < chequeo.length; j++) {
                        if (chequeo[j].checked) {
                            args.IsValid = true;
                            return;
                        }
                    }
                }
                args.IsValid = false;
                return;
            }
            else {
                args.IsValid = false;
                return;
            }
        }

    }

    function ValidarTotalDeudas(sender, args) {
        var Total = 0;
        var gridGestion = document.getElementById('ContenidoPrincipal_gvDeudas');
        var txtValor = document.getElementById('ContenidoPrincipal_txtValorTotal').value.replace(/\$/g, '').replace(/\./g, '').replace(/\ /g, '');

        if (txtValor == "") {
            args.IsValid = true;
            return;
        }
        else {

            if (gridGestion == null) {
                args.IsValid = true;
                return;
            }
            else {
                var filasGrid = gridGestion.getElementsByTagName('tr');

                if (filasGrid.length > 0) {
                    for (i = 0; i < filasGrid.length; i++) {
                        var columnasFila = filasGrid[i].getElementsByTagName('td');
                        var chequeo = filasGrid[i].getElementsByTagName("input");

                        for (k = 0; k < chequeo.length; k++) {
                            if (chequeo[j].checked) {
                                Total += Number(columnasFila[2].innerHTML.replace(/\$/g, '').replace(/\./g, '').replace(/\ /g, '')) + Number(columnasFila[3].innerHTML.replace(/\$/g, '').replace(/\./g, '').replace(/\ /g, ''));
                            }
                        }
                    }

                    if (Total >= txtValor) {
                        args.IsValid = true;
                    }
                    else {
                        args.IsValid = false;
                    }

                    return;
                }
                else {
                    args.IsValid = true;
                    return;
                }
            }

        }

    }

    function ValidarMayorCero(sender, args) {
        var txtValor = document.getElementById('ContenidoPrincipal_txtValorTotal');
        if (txtValor.value == "" || txtValor.valueOf > 0) {
            args.IsValid = true;
            return;
        }
        else if (txtValor.value <= 0) {
            args.IsValid = false;
            return;
        }
    }

    function ValidarFechaCom(sender, args) {
        var txtFecha = document.getElementById("ContenidoPrincipal_txtFechaComp");
        var texto = txtFecha.value;

        if (texto.length > 0) {
            var seccionesFecha = texto.split("/");
            var dia = seccionesFecha[0];
            var mes = seccionesFecha[1] - 1;
            var anio = seccionesFecha[2];

            var fechaComp = new Date(anio, mes, dia);
            var fechaActual = new Date();

            if (fechaComp > fechaActual) {
                args.IsValid = true;
                return;
            }
            else {
                args.IsValid = false;
                return;
            }
        }
        else {
            args.IsValid = true;
            return;
        }

    }

    function ValidarFechaVisita(sender, args) {
        var txtFecha = document.getElementById("ContenidoPrincipal_txtFechaVisita");
        var texto = txtFecha.value;

        if (texto.length > 0) {
            var seccionesFecha = texto.split("/");
            var dia = seccionesFecha[0];
            var mes = seccionesFecha[1] - 1;
            var anio = seccionesFecha[2];

            var fechaComp = new Date(anio, mes, dia);
            var fechaActual = new Date();

            if (fechaComp > fechaActual) {
                args.IsValid = true;
                return;
            }
            else {
                args.IsValid = false;
                return;
            }
        }
        else {
            args.IsValid = true;
            return;
        }

    }





    function refrescarControl(objeto) {
        __doPostBack('objeto', '');
    };

    function recorrerGrilla() {
        var grid = document.getElementById("ContenidoPrincipal_gvRegistrosDetalleRec");
        var cell;
        if (grid.rows.length > 0) {
            for (i = 1; i < grid.rows.length - 1; i++) {
                cell = grid.rows[i].cells[4];
                if (cell.children[0].firstChild.checked) {
                    return true;
                }
            }
        }
        return false;
    }

    function comprobarCamposChequeados() {
        if (recorrerGrilla() == true) {
            return confirm('¿Está seguro de eliminar los campos seleccionados?');
        }
        else {
            alert('Debe seleccionar registros para eliminar')
            return false;
        }
    }


    function VerificarNavegador() {
        var navegadores = "OPR/18.0;Firefox/26.0;Chrome/28.0;IE/10.0;Safari/534.57";
        var compatible = true;
        var totalNavegadores = navegadores.split(";");
        var navegadorActual;
        var versionAComparar;


        for (var i = 0; i < totalNavegadores.length; i++) {
            var partesNavegador = totalNavegadores[i].split("/");
            var nombreNavegador = partesNavegador[0];
            var versionNavegador = partesNavegador[1];

            if (nombreNavegador == 'IE') {
                if (navigator.userAgent.indexOf("Trident") != -1) {
                    navegadorActual = nombreNavegador;
                    versionAComparar = versionNavegador;
                    break;
                }
                else
                {
                    navegadorActual = "Desconocido";
                }
            }
            else {
                if (navigator.userAgent.indexOf(nombreNavegador) != -1) {
                    navegadorActual = nombreNavegador;
                    versionAComparar = versionNavegador;
                    break;
                }
                else
                {
                    navegadorActual = "Desconocido";
                }
            }
        }

        if (navegadorActual != 'Desconocido') {
            VerificarVersionNav(navegadorActual, versionNavegador);
        }
        else
        {
            var lbMensajeNav = document.getElementsByClassName("lbMensajeNav")[0];
            lbMensajeNav.innerText('Es posible que su navegador no sea compatible con la aplicación');
        }

    }

    function VerificarVersionNav(navegador, versionACompaprar)
    {
        var numeropuntos=0;
        var numerocifras = 0;
        var caracteresPermiridos = '0123456789.';
        var versionActual = '';
        var indiceInicial;
        var indice;
        if (navegador == 'IE') {
            if (navigator.userAgent.indexOf("MSIE") != -1) {
                indice = navigator.userAgent.indexOf("MSIE");
                indiceInicial = indice + "MSIE".length + 1;

            }
            else {
                indice = navigator.userAgent.indexOf("rv:");
                indiceInicial = indice + "rv:".length;
            }

        }
        else
        {
            indice = navigator.userAgent.indexOf(navegador+"/");
            indiceInicial = indice + (navegador + "/").length;

        }

        for (i = indiceInicial; i < navigator.userAgent.length; i++) {
            if (numeropuntos < 1) {
                if (versionActual.length < 4) {
                    if (caracteresPermiridos.indexOf(navigator.userAgent[i]) != -1) {
                        versionActual += navigator.userAgent[i];
                    }
                    else
                    {
                        break;
                    }
                }
                else {
                    break;
                }

                if (navigator.userAgent[i] == '.') {
                    numeropuntos++;
                }
            }
            else {
                if (numerocifras < 3) {
                    if (caracteresPermiridos.indexOf(navigator.userAgent[i]) != -1) {
                        if (navigator.userAgent[i] == '.') {
                            break;
                        }
                        else {
                            versionActual += navigator.userAgent[i]
                            numerocifras++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        var valorActual = parseFloat(versionActual);
        var valorComparado = parseFloat(versionACompaprar);
        var lbMensajeNav = document.getElementsByClassName("lbMensajeNav")[0];
        if (valorActual < valorComparado) {
            lbMensajeNav.innerText = "El navegador no tiene compatibilidad con la aplicación, esta es compatible desde la version: " + versionACompaprar;
        }
        else
        {
            lbMensajeNav.innerText = "";
        }        
    }


      



