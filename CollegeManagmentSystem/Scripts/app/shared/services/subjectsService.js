(function () {
    'use strict';

    angular
        .module('app')
        .factory('subjectsService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getSubjects = function () {
                var deferred = $q.defer();

                $http.get('/Subjects/Index').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.getSubjectById = function (id) {
                var deferred = $q.defer();

                $http.get('/Subjects/Details/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.addSubject = function (subject) {
                var deferred = $q.defer();

                $http.post('/Subjects/Create', subject).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.editSubject = function (id, subject) {
                var deferred = $q.defer();

                $http.put('/Subjects/Edit/' + id, subject).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.deleteSubject = function (id) {
                var deferred = $q.defer();

                $http.delete('/Subjects/Delete/' + id).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            return service;

        }]);
})();