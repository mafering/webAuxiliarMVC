$(function () {
    //var self = this;
    //var fd = $('#txtFechaDesde').val();
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
        url: '/AuxServicio/getAuxServicio/',
        datatype: 'json',
        mtype: 'Get',
        postData:
        {
            beginDate: function () { return $('#txtFechaDesde').val() },
            endDate: function () { return $('#txtFechaHasta').val() }
        },
        colNames: ['Acciones', 'Auxiliar', 'Año', 'Ced/Ruc', 'Contratista', 'Objeto Servicio', 'Partida', 'Monto', 'Fecha' ],
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
            { key: false, name: 'AnioCto', index: 'by_anioCto', editable: false, width: '30%', align: "center", sortable: true },
            { key: false, name: 'CedRuc', index: 'by_cedRuc', editable: false, width: '43%', sortable: true },
            { key: false, name: 'Contratista', index: 'by_contratista', editable: false, width: 55, sortable: true, resizable: true },
            { key: false, name: 'ObjetoCto', index: 'by_objetoCto', editable: false, width: 155, height: 'auto', sortable: false },
            { key: false, name: 'Partida', index: 'by_partida', editable: false, width: 25, align: 'center' },
            {
              key: false, name: 'MontoCto', index: 'by_montoCto', width: 40, align: 'right', template: 'number',
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
            { key: false, name: 'FechaCto', index: 'by_fechaServ', editable: false, width: 30, align: 'center' }
        ],
        iconSet: "fontAwesome",
        //loadonce: false,
        sortname: 'by_numeroAux',
        sortorder: 'desc',
        rowNum: 20,
        rowList: [20, 40, 60, 80, 100],
        height: '100%',
        viewrecords: true,
        caption: 'Registros Auxiliar Bienes y Servicios',
        emptyrecords: 'No hay registros de auxiliares disponibles para mostrar',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            id: "0"
        },
        autowidth: true,
        rownumbers: true,
        multiselect: true,
        pager: '#jqGridAuxPag',



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
            buttonicon: 'ui-icon-transfer-e-w',
            position: 'last',
            onClickButton: exportExcel  // () { exportExcel();}
        })
        .jqGrid('navButtonAdd', '#jqGridAuxPag',
        {
            caption: "Exportar PDF ",
            buttonicon: 'ui-icon-document',
            //position: 'last',
            onClickButton: exportPDF  // () { exportExcel();}
        })

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

    if (!rowKey)
        alert("No hay filas seleccionadas");
    else
    {
        var selectedIDs = gridRow.getGridParam("selarrrow");
        var result = "";
        for (var i = 0; i < selectedIDs.length; i++)
        {
            result += selectedIDs[i] + ",";
        }
        alert(result);
    }
}