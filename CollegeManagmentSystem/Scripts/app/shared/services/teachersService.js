(function () {
    'use strict';

    angular
        .module('app')
        .factory('teachersService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getTeachers = function () {
                var deferred = $q.defer();

                $http.get('/Teachers/Index').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.getFreeTeachers = function () {
                var deferred = $q.defer();

                $http.get('/Teachers/FreeTeachers').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.getTeacherById = function (id) {
                var deferred = $q.defer();

                $http.get('/Teachers/Details/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.addTeacher = function (teacher) {
                var deferred = $q.defer();

                $http.post('/Teachers/Create', teacher).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.editTeacher = function (id, teacher) {
                var deferred = $q.defer();

                $http.put('/Teachers/Edit/' + id, teacher).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.deleteTeacher = function (id) {
                var deferred = $q.defer();

                $http.delete('/Teachers/Delete/' + id).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            return service;

        }]);
})();