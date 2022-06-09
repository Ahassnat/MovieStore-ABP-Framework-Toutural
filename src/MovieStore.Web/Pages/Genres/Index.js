$(function () {
    var l = abp.localization.getResource('MovieStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Genres/CreateGenreModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Genres/EditGenreModal');


    //Search and Fillter
    //get the value of the search input
    var getFilter = function () {
        return {
            filter: $("input[name='Search'").val()
        };
    };
    // End Search Function
    var dataTable = $('#GenresTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                movieStore.genres.genre.getList, getFilter),//pass the filter to the GetList method
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('MovieStore.Genres.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('MovieStore.Genres.Delete'),
                                    confirmMessage: function (data) {
                                        return l('GenreDeletionConfirmationMessage',
                                            data.record.name);
                                    },
                                    action: function (data) {
                                        movieStore.genres.genre
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
                    title: l('Name'),
                    data: "name"
                }
            ]
        })
    );

    $("input[name='Search'").keyup(function () {
        dataTable.ajax.reload();
    });
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewGenreButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
