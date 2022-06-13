$(function () {
    var l = abp.localization.getResource('MovieStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Movies/CreateMovieModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Movies/EditMovieModal');


    //Search and Fillter
    //get the value of the search input
    //var getFilter = function () {
    //    return {
    //        filter: $("input[name='Search'").val()
    //    };
    //};

    var inputAction = function (requestData, dataTableSettings) {
        console.log(requestData);
        //return requestData;


        //console.log(dataTableSettings);
        // Serialize from data to json object
        return $("#form-search").serializeFormToObject();
    };
    // End Search Function
    var dataTable = $('#MoviesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                movieStore.movies.movie.getList, /*getFilter,*/ inputAction),//pass the filter to the GetList method
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('MovieStore.Movies.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('MovieStore.Movies.Delete'),
                                    confirmMessage: function (data) {
                                        return l('MovieDeletionConfirmationMessage',
                                            data.record.name);
                                    },
                                    action: function (data) {
                                        movieStore.movies.movie
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }

                            ]
                    }
                },
                {
                    title: l('Title'),
                    data: "title"
                },
                {
                    title: l('GenreName'),
                    data: "genreName",
                    orderable: false
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {

                    title: l('ReleaseDate'),
                    data: "releaseDate",
                    dataFormat: 'date'

                },
                /*Add the new actor button*/
                //{
                //    targets: 0,
                //    data: null,
                //    defaultContent: '<button >New Actor<button/>',
                //},
                //{
                //    targets: 0,
                //    text: l('Edit'),
                //    visible: abp.auth.isGranted('MovieStore.Movies.Edit'), //CHECK for the PERMISSION
                //    action: function (data) {
                //        editModal.open({ id: data.record.id });
                //    }
                //}
            ]
        })
    );

    //$("input[name='Search'").keyup(function () {
    //    dataTable.ajax.reload();
    //});
    $("#form-search").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
   
    $('#NewMovieButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    
});
