let noFileNameEntered = '<strong>Внимательно!</strong> Вы не ввели название файла.';

$(function () {
    function convertBytesToMegaBytes(value) {
        return !isNaN(value) ? (value / 1024 / 1024).toFixed(2) : 0;
    }

    function showAlert(message) {
        $(".alert.alert-danger").html(message).removeClass("hidden");
    }
    // prevent choose file dialog, if no entered name
    $(".inputFile").on("click", function (event) {
        if ($(".inputFileName").val().length == 0) {
            showAlert(noFileNameEntered);

            // stop event propagation
            event.preventDefault();
            return false;
        }
        else {
            $(".alert.alert-danger").addClass("hidden");
        }
    });

    // make file uploading directly after file slected
    $(".inputFile").change(function () {
        let collectedData = new FormData($('form')[0]);
        collectedData.append("customFileName", $('.inputFileName').val());
        $.ajax({
            url: '/api/upload',
            type: 'POST',

            data: new FormData($('form')[0]),

            cache: false,
            contentType: false,
            processData: false,

            xhr: function () {
                var myXhr = $.ajaxSettings.xhr();
                if (myXhr.upload) {
                    myXhr.upload.addEventListener('progress', onProgressFunction, false);
                }
                return myXhr;
            }
        }).done(function (data) {
            $('.modal').removeClass('fade').show();
            $('.modal-file-size').html(convertBytesToMegaBytes(data.size) + 'Mb');
            $('.modal-entered-file-name').html(data.customFileName);
            $('.modal-initial-file-name').html(data.initialName);
            $('.modal-saved-file-name').html(data.localFileName);
        }).fail(function (error) {
                console.log(error.responseText);
                showAlert(error.responseText);
        });
    });

    $('button[data-dismiss]').on('click', function () { $('.modal').addClass('fade').hide(); });

    onProgressFunction = function (args) {
        $('.current-info').removeClass('hidden');
        $('.size').html(convertBytesToMegaBytes(args.total) + 'Mb');
        $('.loaded').html(convertBytesToMegaBytes(args.loaded) + 'Mb');
    };
});