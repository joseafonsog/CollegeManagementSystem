(function () {
    'use strict';

    angular
        .module('app')
        .controller('subjectsCtrl', ['$scope', 'subjectsService', function ($scope, subjectsService) {
            $scope.subjects = [];

            getData();

            function getData() {
                subjectsService.getSubjects().then(function (result) {
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
        .controller('subjectAddCtrl', ['$scope', '$location', '$routeParams', 'subjectsService', 'teachersService', 'coursesService', function ($scope, $location, $routeParams, subjectsService, teachersService, coursesService) {

            $scope.subject = {};
            $scope.id = $routeParams.id;

            $scope.courses = [];
            $scope.teachers = [];

            coursesService.getCourses().then(function (result) {
                $scope.courses = result;
            });

            teachersService.getFreeTeachers().then(function (result) {
                $scope.teachers = result;
            });


            if (!$scope.id || $scope.id === 'new') {
                $scope.submit = function (subject) {
                    subjectsService.addSubject(subject).then(function () {
                        toastr.success('Subject created successfully!');
                        $location.path('/subjects');
                    }, function () {
                        toastr.error('Error in creating subject');
                    });
                };
            } else {
                subjectsService.getSubjectById($scope.id).then(function (result) {
                    console.log(result);
                    $scope.subject = result;
                });

                $scope.submit = function (subject) {
                    subjectsService.editSubject($scope.id, subject).then(function () {
                        toastr.success('Subject updated successfully!');
                        $location.path('/subjects');
                    }, function () {
                        toastr.error('Error in updating subject');
                    });
                };
            }
        }]);
})();
