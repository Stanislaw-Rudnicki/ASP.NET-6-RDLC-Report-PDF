// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

jQuery(function ($) {
    $("#Card").mask("9999 9999 9999 9999");
    $("#Phone").mask("+38 (099) 999-99-99");

    $(':required').one('blur keydown', function () {
        $(this).addClass('touched');
            });
    });
