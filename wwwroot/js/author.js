var datatable;
$(document).ready(function () {
    $(".dropdown-toggle").dropdown();
    datatable = $('#user_table').DataTable({
        destroy: true,
        paging: true,
        scrollX: true,
        lengthChange: true,
        searching: true,
        ordering: true
        
    });

    $('button[data-ref^="modal"]').click(function () {
        var button_text = $(this).text();
        if ($(this).data('ref') == "modal") {
            if ($(this).data('action') == "read") {
                $('#user-modal').find('.btn-primary').hide();
                var id = $(this).attr('data-id');
                var url = $(this).attr('data-url');
                $('.modal-title').html(button_text);
                $.ajax({
                    type: "GET",
                    url: url,
                    data: { id: id },
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (response) {
                        $('#user-modal').find('.modal-body').html(response);

                    }

                });
            }
            if ($(this).data('action') == "update") {
                var url = $(this).attr('data-url');
                var id = $(this).attr('data-id');

                $('.modal-title').html(button_text);
                $('#user-modal').find('.btn-primary').show();
                $.ajax({
                    type: "GET",
                    url: url,
                    data: { id: id },
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (response) {
                        $('#user-modal').find('.modal-body').html(response);
                        $('#form-submission').hide();
                    }
                });

                $('#modal-save-button').on('click', function (event) {
                    $('.user-form').submit();
                    datatable.ajax.reload();
                });
            }
            if ($(this).data('action') == "create") {
                var url = $(this).attr('data-url');
                $('#user-modal').find('.btn-primary').show();
                $('.modal-title').html(button_text);
                $.ajax({
                    type: "GET",
                    url: url,
                    contentType: "application/json; charset=utf-8",
                    dataType: "html",
                    success: function (response) {
                        $('#user-modal').find('.modal-body').html(response);
                        $('#form-submission').hide();
                        
                    }
                });
                
                $('#modal-save-button').on('click', function (event) {
                    $('.user-form').submit();
                    datatable.ajax.reload();
                });
            }
            $('#user-modal').modal('show');
        }
            

        
        
    });
});