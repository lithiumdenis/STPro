$(document).ready(function () {

    //Prepare jtable plugin
    $('#ReceptionTableContainer').jtable({
        title: 'Приёмы',
        paging: true, //Enables paging
        pageSize: 10, //Actually this is not needed since default value is 10.
        sorting: true, //Enables sorting
        defaultDateFormat: 'DD, dd-M-y',

        defaultSorting: 'Doctor_Id ASC', //Default sorting on first load.
        actions: {
            listAction: '/HospitalWebForm.aspx/ReceptionList',
            createAction: '/HospitalWebForm.aspx/CreateReception',
            updateAction: '/HospitalWebForm.aspx/UpdateReception',
            deleteAction: '/HospitalWebForm.aspx/DeleteReception'
        },
        fields: {
            Id: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Doctor_Id: {
                title: 'ID доктора',
                width: '23%'
            },
            Patient_Id: {
                title: 'ID пациента',
                width: '23%'
            },
            Date: {
                title: 'Дата приёма',
                width: '25%',
                type: 'date',
                //displayFormat: 'dd MM yy',
                edit: true
            }
        }
    });

    //Load doctors list from server
    $('#ReceptionTableContainer').jtable('load');
});