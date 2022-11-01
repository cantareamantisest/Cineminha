// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Show modal.
$(function () {
    var placeHolderElement = $('#placeHolderModal');

    $(document).on('click', 'button[data-toggle="ajax-modal"]', function (event) {
        var url = $(this).data('url');
        var decodeUrl = decodeURIComponent(url);
        $.get(decodeUrl).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal(
                {
                    backdrop: 'static',
                    keyboard: false
                }, 'show');
        })
    })

    placeHolderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = new FormData(form.get(0));

        $.ajax({ url: actionUrl, method: 'post', data: dataToSend, processData: false, contentType: false }).done(function (data) {
            var newBody = $('.modal-body', data);
            placeHolderElement.find('.modal-body').replaceWith(newBody);

            var isValid = newBody.find('[name="IsValid"]').val() === 'True';
            if (isValid) {
                placeHolderElement.find('.modal').modal('hide');
            }
        });
    });

    placeHolderElement.on('hidden.bs.modal', function () {
        location.reload(true);
    })
})