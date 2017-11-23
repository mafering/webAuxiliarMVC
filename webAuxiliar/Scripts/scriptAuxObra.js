$(function () {
    var $grid = $('#jqGridAux');
    getColumnIndexByName = function ($grid, columnName) {
        var cm = $grid.jqGrid('getGridParam', 'colModel'), i, l = cm.length;
        for (i = 0; i < l; i++) {
            if (cm[i].name === columnName) {
                return i; // return the index
            }
        }
        return -1;
    },
    $grid.jqGrid(
    {
        url: '/AuxObra/getAuxObra/',
        datatype: 'json',
        mtype: 'Get',
        postData:
        {
            beginDate: function () { return $('#txtFechaDesde').val() },
            endDate: function () { return $('#txtFechaHasta').val() }
        },
        colNames: ['Acciones', 'Numero Aux', 'Año', 'Ced/Ruc', 'Contratista', 'Objeto Contrato', 'Partida', 'Monto', 'Fecha'],
        colModel:
        [
            {
                key: false,
                name: 'act', index: 'act', width: '25%', align: 'center', search: false, sortable: false, formatter: 'actions',
                formatoptions:
                {
                    keys: false, // we want use [Enter] key to save the row and [Esc] to cancel editing.
                    editbutton: false,
                    editformbutton: false,
                    delbutton: false
                    //delOptions: myDelOptions
                }
            },
            { key: true, name: 'NumeroAux', index: 'by_numeroAux', editable: false, width: '30%', align: "center", sortable: true, firstsortorder: 'desc' },
            { key: false, name: 'AnioCto', index: 'by_anioCto', editable: false, width: '20%', align: "center", sortable: true },
            { key: false, name: 'CedRuc', index: 'by_cedRuc', editable: false, width: '30%', sortable: true },
            { key: false, name: 'Contratista', index: 'by_contratista', editable: false, width: 50, sortable: true, resizable: true },
            { key: false, name: 'ObjetoCto', index: 'by_objetoCto', editable: false, width: 150, height: 'auto', sortable: false },
            { key: false, name: 'Partida', index: 'by_partida', editable: false, width: 30, align: "center" },
            {
                key: false, name: 'MontoCto', index: 'by_montoCto', width: 30, align: 'right', formatter: 'currency',
                formatoptios:
                {
                    thousandsSeparator: ',',
                    decimalSeparator: '.',
                    decimalPlaces: 2,
                    prefix: '$ ',
                    //suffix: '',
                    defaultValue: '$ 0.00'
                }
            },
            { key: false, name: 'FechaCto', index: 'by_fechaObra', editable: false, width: 30, align: 'center' }
        ],
        iconSet: "fontAwesome",
        loadonce: false,
        //styleUI: 'Bootstrap',
        sortname: 'by_numeroAux',
        sortorder: 'desc',
        rowNum: 20,
        rowList: [20, 40, 60, 80, 100],
        height: '100%',
        viewrecords: true,
        caption: 'Registros Auxiliar Obras',
        emptyrecords: 'No hay registros de auxiliares disponibles para mostrar',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            id: "0",
            subgrid: {repeatitems: false}
        },
        autowidth: true,
        rownumbers: true,
        multiselect: false,
        pager: '#jqGridAuxPag',

        //*INICIO: subGrid*//
        subGrid: true,
        //subGridOptions: {
        //    "plusicon": "ui-icon-triangle-1-e",
        //    "minusicon": "ui-icon-triangle-1-s",
        //    "openicon": "ui-icon-arrowreturn-1-e",
        //    "reloadOnExpand": false,
        //    "selectOnExpand": true
        //},
        
        subGridRowExpanded: function(subgrid_id, row_id) 
        {
            var subgrid_table_id, pager_id;
            subgrid_table_id = subgrid_id + '_t';
            pager_id = 'p_' + subgrid_table_id;

            $("#" + subgrid_id).html("<table id='" + subgrid_table_id + "' class='scroll'></table><div id='" + pager_id + "' class='scroll'></div>");

            $('#' + subgrid_table_id).jqGrid(
            {
                url: '/AuxObra/getAuxObraDet/',
                datatype: 'json',
                mtype: 'Get',
                postData:
                {
                    auxObraID: function () { return row_id; },
                },
                name: [],
                colNames: ['', 'Planilla', 'Doc Referencia', 'Concepto', 'Fecha Pago', 'Valor Entregado', 'Valor Devengado', 'Valor Multa', 'Valor Planilla', 'Valor Reajuste', 'Valor Finanzas'],
                colModel:
                [
                    { name: 'NumeroAux', index: 'by_numeroAux', hidden: true},
                    { name: 'NumeroPla', index: 'by_numeroPla', editable: false, width: '15%', align: "center", sortable: true, firstsortorder: 'desc' },
                    { name: 'DocReferencia', index: 'by_docRef', editable: false, width: '30%', align: "center", sortable: true },
                    { name: 'Concepto', index: 'by_conceptoc', editable: false, width: '100%', sortable: true },
                    { name: 'FechaPago', index: 'by_fechaPago', editable: false, width: 25, align: 'center' },
                    {
                        name: 'ValorEntregado', width: 25, align: 'right', formatter: 'currency',
                        formatoptios:
                        {
                            thousandsSeparator: ',',
                            decimalSeparator: '.',
                            decimalPlaces: 2,
                            prefix: '$ ',
                            //suffix: '',
                            defaultValue: '$ 0.00'
                        }
                    },
                    { //Valor Devengado
                        name: 'RetencionPla', width: 25, align: 'right', formatter: 'currency',
                        formatoptios:
                        {
                            thousandsSeparator: ',',
                            decimalSeparator: '.',
                            decimalPlaces: 2,
                            prefix: '$ ',
                            //suffix: '',
                            defaultValue: '$ 0.00'
                        }
                    },
                    {
                        name: 'ValorMulta', width: 25, align: 'right', formatter: 'currency',
                        formatoptios:
                        {
                            thousandsSeparator: ',',
                            decimalSeparator: '.',
                            decimalPlaces: 2,
                            prefix: '$ ',
                            //suffix: '',
                            defaultValue: '$ 0.00'
                        }
                    },
                    {
                        name: 'ValorPlanilla', width: 25, align: 'right', formatter: 'currency',
                        formatoptios:
                        {
                            thousandsSeparator: ',',
                            decimalSeparator: '.',
                            decimalPlaces: 2,
                            prefix: '$ ',
                            //suffix: '',
                            defaultValue: '$ 0.00'
                        }
                    },
                    {
                        name: 'ValorReajuste', width: 25, align: 'right', formatter: 'currency',
                        formatoptios:
                        {
                            thousandsSeparator: ',',
                            decimalSeparator: '.',
                            decimalPlaces: 2,
                            prefix: '$ ',
                            //suffix: '',
                            defaultValue: '$ 0.00'
                        }
                    },
                    {
                        name: 'ValorFinanzas', width: 25, align: 'right', formatter: 'currency',
                        formatoptios:
                        {
                            thousandsSeparator: ',',
                            decimalSeparator: '.',
                            decimalPlaces: 2,
                            prefix: '$ ',
                            //suffix: '',
                            defaultValue: '$ 0.00'
                        }
                    },
                ],
                rowNum: 10,
                sortname: 'by_numeroPla',
                autowidth: true,
                pager: pager_id,
                viewrecords: true,
                caption: 'Detalle de Planilla de Onra',
                emptyrecords: 'No hay registros de plniaññas disponibles para mostrar',
                jsonReader: {
                    root: "rows",
                    page: "page",
                    total: "total",
                    records: "records",
                    id: "0",
                    repeatitems: false
                },
            });
            $("#" + subgrid_table_id).jqGrid('navGrid', "#" + pager_id, { edit: false, add: false, del: false });
        
        },

        //*FIN: subGrid*//

        //*INICIO: Opción+Icono Imprimir*//
        loadComplete: function ()
        {
            var iCol = getColumnIndexByName($grid, 'act');
            $(this).find(">tbody>tr.jqgrow>td:nth-child(" + (iCol + 1) + ")")
                .each(function () {
                    $("<div>", {
                        title: "Imprimir",
                        mouseover: function () {
                            $(this).addClass('ui-state-hover');
                        },
                        mouseout: function () {
                            $(this).removeClass('ui-state-hover');
                        },
                        click: function (e) {
                            //alert("'Custom' button is clicked in the rowis=" +
                            //    $(e.target).closest("tr.jqgrow").attr("id") + " !");

                            //INICIO script reporte //
                            var rptAuxObra = $(e.target).closest("tr.jqgrow").attr("id") //rowKey; //$("#rptAuxObra").val();
                            var src = '../Reportes/rptViewer.aspx?';
                            src = src + "rptAuxObra=" + rptAuxObra
                            var iframe = '<iframe id="myReportFrame" width="100%" height="800px" scrolling="no" frameborder="0" src="' + src + '" allowfullscreen></iframe>';
                            $("#divReport").html(iframe);
                            //FIN script reporte //


                        }
                    }
                  ).css({ "margin-right": "5px", float: "left", cursor: "pointer" })
                   .addClass("ui-pg-div ui-inline-custom")
                   .append('<span class="ui-icon ui-icon-print"></span>')
                   .prependTo($(this).children("div"));
                })
        },
        //*FIN: Opción+Icono Imprimir*//

        
                
    }).navGrid('#jqGridAuxPag', { edit: false, add: false, del: false, search: true, searchtext: "Buscar Auxiliar", refresh: true, view: false },
        {}, //default setting for edit
        {}, //default setting for add
        {}, //default setting for delete
        {
            closeOnEscape: true, closeAfterSearch: true, ignoreCase: true,
            multipleSearch: false, multipleGroup: false, showQuery: false,
            sopt: ['cn', 'eq', 'ne'], defaultSearch: 'cn',
        })
        
         //add custom button to export the data to excel
        .jqGrid('navButtonAdd', '#jqGridAuxPag',
        {
            caption: "Exportar Excel ",
            buttonicon: 'fa-file-excel-o', //'ui-icon-transfer-e-w',
            position: 'last',
            onClickButton: exportExcel  // () { exportExcel();}
        })
        //.jqGrid('navButtonAdd', '#jqGridAuxPag',
        //{
        //    caption: "Exportar PDF ",
        //    buttonicon: 'ui-icon-document',
        //    //position: 'last',
        //    onClickButton: exportPDF  // () { exportExcel();}
        //})

});

function exportExcel()
{
    $("#jqGridAux").jqGrid("exportToExcel",
    {
        includeLabels: true,
        includeGroupHeader: true,
        includeFooter: true,
        fileName: "jqGridExport.xlsx",
        mimetype: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        maxlength: 40,
        onBeforeExport: null,
        replaceStr: null
    })
}

function exportPDF()
{
    $("#jqGridAux").jqGrid("exportToPdf",
    {
        title: null,
        orientation: 'portrait',
        pageSize: 'A4',
        description: null,
        onBeforeExport: null,
        download: 'download',
        includeLabels: true,
        includeGroupHeader: true,
        includeFooter: true,
        fileName: "AuxObra.pdf",
        mimetype: "application/pdf"
    })
}

function getSelectRows()
{
    var gridRow = $("#jqGridAux");
    var rowKey = gridRow.getGridParam("selrow");

    //INICIO script reporte //
    var rptAuxObra = rowKey; //$("#rptAuxObra").val();
    var src = '../Reportes/rptViewer.aspx?';
    src = src + "rptAuxObra=" + rptAuxObra
    var iframe = '<iframe id="myReportFrame" width="100%" height="800px" scrolling="no" frameborder="0" src="' + src + '" allowfullscreen></iframe>';
    $("#divReport").html(iframe);
    //FIN script reporte //

    //if (!rowKey)
    //    alert("No hay filas seleccionadas");
    //else
    //{
    //    var selectedIDs = gridRow.getGridParam("selarrrow");
    //    var result = "";
    //    for (var i = 0; i < selectedIDs.length; i++)
    //    {
    //        result += selectedIDs[i] + ",";
    //    }

  
    //    alert(result);
    //}
}