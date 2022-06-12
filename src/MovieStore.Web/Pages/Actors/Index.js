$(function () {
    var l = abp.localization.getResource('MovieStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Actors/CreateActorModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Actors/EditActorModal');


    //Search and Fillter
    //get the value of the search input
    var getFilter = function () {
        return {
            filter: $("input[name='Search'").val()
        };
    };
    // End Search Function
    var dataTable = $('#ActorsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[0, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(
                movieStore.actors.actor.getList, getFilter),//pass the filter to the GetList method
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('MovieStore.Actors.Edit'), //CHECK for the PERMISSION
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('MovieStore.Actors.Delete'),
                                    confirmMessage: function (data) {
                                        return l('ActorDeletionConfirmationMessage',
                                            data.record.name);
                                    },
                                    action: function (data) {
                                        movieStore.actors.actor
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
                    title: l('ActorName'),
                    data: "actorName"
                },
                {
                    //TODO: Work with Picture with JQ
                    title: l('ActorPicture'),
                    data: "actorPicture"
                },
                {
                    title: l('MovieName'),
                    data: "movieName",
                    orderable: false
                },
               
              
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

    $('#NewActorButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
