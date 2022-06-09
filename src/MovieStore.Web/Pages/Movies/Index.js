$(function () {
    var l = abp.localization.getResource('MovieStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Movies/CreateMovieModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Movies/EditMovieModal');
    var dataTable = $('#MoviesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                movieStore.movies.movie.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
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

                }
            ]
        })
    );

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
