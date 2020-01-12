(function () {
    'use strict';

    angular
        .module('app')
        .factory('coursesService', ['$http', '$q', function ($http, $q) {
            var service = {};

            service.getCourses = function () {
                var deferred = $q.defer();

                $http.get('/Courses/GetAll').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.getCoursesWithExtraData = function () {
                var deferred = $q.defer();

                $http.get('/Courses/GetAllWithAdditionalData').then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.getCourseById = function (id) {
                var deferred = $q.defer();

                $http.get('/Courses/GetById/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.getCourseDetails = function (id) {
                var deferred = $q.defer();

                $http.get('/Courses/Details/' + id).then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.addCourse = function (course) {
                var deferred = $q.defer();

                $http.post('/Courses/Create', course).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.editCourse = function (id, course) {
                var deferred = $q.defer();

                $http.put('/Courses/Edit/' + id, course).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            service.deleteCourse = function (id) {
                var deferred = $q.defer();

                $http.delete('/Courses/Delete/' + id).then(function () {
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                });

                return deferred.promise;
            };

            return service;

        }]);
})();