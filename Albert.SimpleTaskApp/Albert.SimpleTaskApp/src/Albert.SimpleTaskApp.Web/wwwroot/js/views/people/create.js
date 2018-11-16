(function ($) {
    $(function () {
        var _$form = $('#PersonCreationForm');

        _$form.find('input:first').focus();

        _$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();

                abp.services.app.person.create(input)
                    .done(function () {
                        location.href = '/People';
                    });
            });
    });
})(jQuery);