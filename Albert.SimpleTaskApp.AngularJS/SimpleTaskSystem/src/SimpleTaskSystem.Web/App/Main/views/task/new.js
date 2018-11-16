(function () {
    'use strict';

    angular
        .module('app')
        .controller('@new', @new);

    @new.$inject = ['$location'];

    function @new($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = '@new';

        activate();

        function activate() { }
    }
})();
