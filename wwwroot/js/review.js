$(document).ready(function () {
    $('#review_table').DataTable({
        destroy: true,
        paging: true,
        scrollX: true,
        lengthChange: true,
        searching: true,
        ordering: true
    });

    $('button[data-ref^="modal"]').click(function () {
        if ($(this).data('ref') == 'modal') {
            $('#user-modal').modal('show');
            if ($(".btn-danger")[0]) {
                $('#modal-save-button').removeClass('btn-danger');
                $('#modal-save-button').addClass('btn-primary');
                $('#modal-save-button').html('Save Changes');
            }
            
            

            //------------EDIT--------------------//
            if ($(this).data('action') == 'update') {
                $('#modal-save-button').show();
                var url = $(this).attr('data-url');
                var id = $(this).attr('data-id');
                $.ajax({
                    type: "POST",
                    url: url + "?id=" + id,
                    data: { id: id },
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (response) {
                        $('#user-modal').find('.modal-body').html(response);
                    }
                });

                $('#modal-save-button').click(function () {
                    $('#form_submission').click();
                });
            }

            //-----------DETAILS-----------------//
            if ($(this).data('action') == 'read') {
                $('#modal-save-button').hide();
                var url = $(this).attr('data-url');
                var id = $(this).attr('data-id');
                $.ajax({
                    type: "POST",
                    url: url + "?id=" + id,
                    data: { id: id },
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        $('#user-modal').find('.modal-body').html(response);
                    }
                });
            }

            //-------DELETE---------------------//
            if ($(this).data('action') == 'delete') {
                $('#modal-save-button').show();
                var url = $(this).attr('data-url');
                var id = $(this).attr('data-id');
                $('#user-modal').find('.modal-body').html("<p class = 'h6'>Are you sure you want to delete this review?</p>");
                $('#modal-save-button').removeClass('btn-primary');
                $('#modal-save-button').addClass('btn-danger');
                $('#modal-save-button').html('Delete');
                $('#modal-save-button').click(function () {
                    $.ajax({
                        type: "POST",
                        url: url + "?id=" + id,
                        success: function (response) {
                            $('#user-modal').modal('hide');
                        }
                    });
                });
            }
        }
    });
});