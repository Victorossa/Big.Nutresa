function showMask(title, message) {
    $('.title').html(title);
    $('.messageModal').html(message);
    $('#modal-generic').modal('show');
}
