function showMask(title, message) {
    $('.messageModal').html(message);    
    $('#modal-generic').modal('show');    
}
function showFirstLogin() {

    setTimeout(function () {
        $('#modal-v2').modal('show');
        $(".sclick-modal").slick('setPosition');
    }, 500);
   
}

function showTermsAndConditionsByRedemption(title,instruction,terms) {
    $('.messageTitleS').html(title);
    $('.messageinstruction').html(instruction);
    $('.messageTerms').html(terms);    
    $('#modal-terms-product').modal('show');
}
function ShowDefaultModal(title, terms) {
    $('.messageTitleDefault').html(title);
    
    $('.messageDefault').html(terms);
    $('#modal-default').modal('show');
}
