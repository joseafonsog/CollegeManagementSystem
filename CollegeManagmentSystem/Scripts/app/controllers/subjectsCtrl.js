(function () {
    'use strict';

    angular
        .module('app')
        .controller('subjectsCtrl', ['$scope', 'subjectsService', function ($scope, subjectsService) {
            $scope.subjects = [];
            $scope.loading = false;

            getData();

            function getData() {
                $scope.loading = true;
                subjectsService.getSubjects().then(function (result) {
                    $scope.loading = false;
                    $scope.subjects = result;
                });
            }

            $scope.deleteSubject = function (id) {
                subjectsService.deleteSubject(id).then(function () {
                    toastr.success('Subject deleted successfully!');
                    getData();
                }, function () {
                    toastr.error('Error in deleting subject');
                });
            };
        }])
        .controller('subjectDetailsCtrl', ['$scope', '$location', '$routeParams', 'subjectsService', function ($scope, $location, $routeParams, subjectsService) {
            $scope.subject = {};
            $scope.loading = false;
            var id = $routeParams.id;

            getData();

            function getData() {
                $scope.loading = true;
                subjectsService.getSubjectDetails(id).then(function (result) {
                    $scope.loading = false;
                    $scope.subject = result;
                });
            }

        }])
        .controller('subjectAddCtrl', ['$scope', '$location', '$routeParams', 'subjectsService', 'teachersService', 'coursesService', function ($scope, $location, $routeParams, subjectsService, teachersService, coursesService) {

            $scope.subject = {};
            $scope.id = $routeParams.id;
            $scope.loading = false;
            $scope.loadingCourses = true;
            $scope.loadingTeachers = true;
            $scope.courses = [];
            $scope.teachers = [];

            coursesService.getCourses().then(function (result) {
                $scope.loadingCourses = false;
                $scope.courses = result;
            });

            teachersService.getFreeTeachers().then(function (result) {
                $scope.loadingTeachers = false;
                $scope.teachers = result;
            });


            if (!$scope.id || $scope.id === 'new') {
                $scope.submit = function (subject) {
                    $scope.loading = true;
                    subjectsService.addSubject(subject).then(function () {
                        $scope.loading = false;
                        toastr.success('Subject created successfully!');
                        $location.path('/subjects');
                    }, function () {
                        $scope.loading = false;
                        toastr.error('Error in creating subject');
                    });
                };
            } else {
                $scope.loading = true;
                subjectsService.getSubjectById($scope.id).then(function (result) {
                    $scope.loading = false;
                    $scope.subject = result;
                });

                $scope.submit = function (subject) {
                    $scope.loading = true;
                    subjectsService.editSubject($scope.id, subject).then(function () {
                        $scope.loading = false;
                        toastr.success('Subject updated successfully!');
                        $location.path('/subjects');
                    }, function () {
                        $scope.loading = false;
                        toastr.error('Error in updating subject');
                    });
                };
            }
        }]);
})();
