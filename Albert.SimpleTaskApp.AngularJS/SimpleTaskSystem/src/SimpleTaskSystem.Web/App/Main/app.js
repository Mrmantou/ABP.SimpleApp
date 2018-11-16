(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    //app.config([
    //    '$stateProvider', '$urlRouterProvider', '$locationProvider', '$qProvider',
    //    function ($stateProvider, $urlRouterProvider, $locationProvider, $qProvider) {
    //        $locationProvider.hashPrefix('');
    //        $urlRouterProvider.otherwise('/');
    //        $qProvider.errorOnUnhandledRejections(false);

    //        $stateProvider
    //            .state('home', {
    //                url: '/',
    //                templateUrl: '/App/Main/views/home/home.cshtml',
    //                menu: 'Home' //Matches to name of 'Home' menu in SimpleTaskSystemNavigationProvider
    //            })
    //            .state('about', {
    //                url: '/about',
    //                templateUrl: '/App/Main/views/about/about.cshtml',
    //                menu: 'About' //Matches to name of 'About' menu in SimpleTaskSystemNavigationProvider
    //            });
    //    }
    //]);
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('tasklist', {
                    url: '/',
                    templateUrl: '/App/Main/views/task/list.cshtml',
                    menu: 'TaskList' //Matches to name of 'TaskList' menu in SimpleTaskSystemNavigationProvider
                })
                .state('newtask', {
                    url: '/new',
                    templateUrl: '/App/Main/views/task/new.cshtml',
                    menu: 'NewTask' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                });
        }
    ]);
})();