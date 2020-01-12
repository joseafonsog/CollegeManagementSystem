(function () {
    'use strict';

    angular
        .module('app')
        .factory('studentsService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getStudents = function () {
                var deferred = $q.defer();

                $http.get('/Students/GetAll').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.getStudentById = function (id) {
                var deferred = $q.defer();

                $http.get('/Students/GetById/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.getStudentDetails = function (id) {
                var deferred = $q.defer();

                $http.get('/Students/Details/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.addStudent = function (student) {
                var deferred = $q.defer();

                $http.post('/Students/Create', student).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.editStudent = function (id, student) {
                var deferred = $q.defer();

                $http.put('/Students/Edit/' + id, student).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.deleteStudent = function (id) {
                var deferred = $q.defer();

                $http.delete('/Students/Delete/' + id).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            return service;

        }]);
})();