
//date masked fields
$(document).ready(function () {
    $('.date').mask('00/00/0000');
});

//date picker fields
$('.datepicker').datepicker();


//on click text field do not hide navbar
$('.dropdown-menu  input').click(function (e) {
    e.stopPropagation();
});


jQuery(function ($) {
    $('div.btn-group[data-toggle-name]').each(function () {
        var group = $(this);
        var form = group.parents('form').eq(0);
        var name = group.attr('data-toggle-name');
        var hidden = $('input[name="' + name + '"]', form);
        $('button', group).each(function () {
            var button = $(this);
            button.live('click', function () {
                hidden.val($(this).val());
                alert(hidden.val());
            });
            if (button.val() == hidden.val()) {
                button.addClass('active');
            }
        });
    });
});