$(document).ready(function () {
    $('#author_table').DataTable({
        destroy: true,
        paging: true,
        scrollX: true,
        lengthChange: true,
        searching: true,
        ordering: true
    });

    $('button[data-ref^="modal"]').click(function () {
        var button_text = $(this).text();
        $('.modal-title').html(button_text);
        $('#modal-save-button').removeClass('btn-danger');
        $('#modal-save-button').addClass('btn - primary');
        $('#modal-save-button').html('Save Changes');
        if ($(this).data('ref') == 'modal') {

            //-----------DETAILS-----------------//
            if ($(this).data('action') == 'read') {
                $('#user-modal').find('.btn-primary').hide();
                var id = $(this).attr('data-id');
                var url = $(this).attr('data-url');

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
            }

            //------------EDIT--------------------//
            if ($(this).data('action') == 'update') {
                $('#user-modal').find('.btn-primary').show();
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
                        document.getElementById('user_password').type = "password";
                        $('#form-submission').hide();
                    }
                });

                $('#modal-save-button').click(function () {
                    $('#reviewer_form').submit();
                });
            }


            //-------CREATE---------------------//
            if ($(this).data('action') == 'create') {
                var url = $(this).attr('data-url');
                $.ajax({
                    type: "POST",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (response) {
                        $('#user-modal').find('.modal-body').html(response);
                        document.getElementById('user_password').type = "password";
                        $('#form-submission').hide();
                    }
                });
                $('#modal-save-button').click(function () {
                    $('#reviewer_form').submit();
                });
            }

            //-------DELETE---------------------//
            if ($(this).data('action') == 'delete') {
                var url = $(this).attr('data-url');
                var id = $(this).attr('data-id');
                $('#user-modal').find('.modal-body').html("<p class = 'h6'>Are you sure you want to delete this record?</p>");
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

            $('#user-modal').modal('show');
        }
    });
});