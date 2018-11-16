(function ($) {
    $(function () {
        var _$taskStateCombobox = $('#TaskStateCombobox');

        _$taskStateCombobox.change(function () {
            location.href = 'Tasks?State=' + _$taskStateCombobox.val();
        });
    });
})(jQuery);