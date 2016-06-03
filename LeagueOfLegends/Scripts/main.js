
$( document ).ready(function() {


    $('.search-modal-btn').click(function () {
        $('.search-modal').fadeOut(300);
    })
    $('.search-btn').click(function () {
        $('.search-modal').fadeIn(300).promise().done(function () {
            $('.search-field').focus();
            block = false;
        });;
    })
    $('.menu-modal-btn').click(function () {
        $('.menu-modal').fadeOut(300);
    })
    $('.menu-btn').click(function () {
        $('.menu-modal').fadeIn(300);
    })
    $('.close-login-modal').click(function () {
        $('.login-modal').fadeOut(300)
    })
    $('.login-btn').click(function () {
        if($('.login-modal').is(':visible')) {
            $('.login-modal').fadeOut(300);
        } else {
            $('.login-modal').fadeIn(300);
        }

    })
});