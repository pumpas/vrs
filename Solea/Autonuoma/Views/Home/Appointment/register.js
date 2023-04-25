$(document).ready(function () {
    $('#role').change(function () {
        if ($('#role').val() == 'Doctor') {
            $('#specialty').show();
        }
        else {
            $('#specialty').hide();
        }
    });
});
