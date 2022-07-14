$(document).ready(function () {
    $('button[data-ref^="modal"]').click(function () {
        if ($(this).data('ref') == 'modal') {
            $('#user-modal').modal('show');
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
        }
        $('#modal-save-button').click(function () {
            $('#form_submission').click();
        });
    });
    
});