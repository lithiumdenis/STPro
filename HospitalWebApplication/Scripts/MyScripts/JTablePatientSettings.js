$(document).ready(function () {

    //Prepare jtable plugin
    $('#PatientTableContainer').jtable({
        title: 'Пациенты',
        paging: true, //Enables paging
        pageSize: 10, //Actually this is not needed since default value is 10.
        sorting: true, //Enables sorting

        defaultSorting: 'Surname ASC', //Default sorting on first load.
        actions: {
            listAction: '/HospitalWebForm.aspx/PatientList',
            createAction: '/HospitalWebForm.aspx/CreatePatient',
            updateAction: '/HospitalWebForm.aspx/UpdatePatient',
            deleteAction: '/HospitalWebForm.aspx/DeletePatient'
        },
        fields: {
            Id: {
                title: 'ID',
                key: true,
                create: false,
                edit: false,
                list: true
            },
            Surname: {
                title: 'Фамилия',
                width: '23%'
            },
            Name: {
                title: 'Имя',
                width: '23%'
            },
            Age: {
                title: 'Возраст',
                width: '10%'
            },
            Gender: {
                title: 'Пол',
                width: '15%',
                options: { 'Male': 'Мужской', 'Female': 'Женский' }
            },
            Contraindications: {
                title: 'Противопоказания',
                width: '25%'
            }
        }
    });

    //Load doctors list from server
    $('#PatientTableContainer').jtable('load');
});