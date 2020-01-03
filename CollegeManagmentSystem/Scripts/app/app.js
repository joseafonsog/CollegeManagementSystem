(function () {
    'use strict';

    angular
        .module('app', [
            'ngRoute'
        ])
        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

            $locationProvider.hashPrefix('');

            $routeProvider
                .when('/courses', {
                    controller: 'coursesCtrl',
                    templateUrl: '/Scripts/app/templates/courses.html'
                })
                .when('/courses/:id', {
                    controller: 'courseAddCtrl',
                    templateUrl: '/Scripts/app/templates/courseAdd.html'
                })
                .when('/students', {
                    controller: 'studentsCtrl',
                    templateUrl: '/Scripts/app/templates/students.html'
                })
                .when('/students/:id', {
                    controller: 'studentAddCtrl',
                    templateUrl: '/Scripts/app/templates/studentAdd.html'
                })
                .when('/subjects', {
                    controller: 'subjectsCtrl',
                    templateUrl: '/Scripts/app/templates/subjects.html'
                })
                .when('/subjects/:id', {
                    controller: 'subjectAddCtrl',
                    templateUrl: '/Scripts/app/templates/subjectAdd.html'
                })
                .when('/teachers', {
                    controller: 'teachersCtrl',
                    templateUrl: '/Scripts/app/templates/teachers.html'
                })
                .when('/teachers/:id', {
                    controller: 'teacherAddCtrl',
                    templateUrl: '/Scripts/app/templates/teacherAdd.html'
                })
                .otherwise({ redirectTo: '/' });
        }]);
})();