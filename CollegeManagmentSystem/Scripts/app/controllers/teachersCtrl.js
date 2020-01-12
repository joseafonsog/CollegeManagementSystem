(function () {
    'use strict';

    angular
        .module('app')
        .controller('teachersCtrl', ['$scope', 'teachersService', function ($scope, teachersService) {
            $scope.teachers = [];
            $scope.loading = false;

            getData();

            function getData() {
                $scope.loading = true;
                teachersService.getTeachers().then(function (result) {
                    $scope.loading = false;
                    $scope.teachers = result;
                });
            }

            $scope.deleteTeacher = function (id) {
                teachersService.deleteTeacher(id).then(function () {
                    toastr.success('Teacher deleted successfully!');
                    getData();
                }, function () {
                    toastr.error('Error in deleting teacher');
                });
            };
        }])
        .controller('teacherDetailsCtrl', ['$scope', '$location', '$routeParams', 'teachersService', function ($scope, $location, $routeParams, teachersService) {
            $scope.teacher = {};
            $scope.loading = false;
            var id = $routeParams.id;

            getData();

            function getData() {
                $scope.loading = true;
                teachersService.getTeacherDetails(id).then(function (result) {
                    $scope.loading = false;
                    $scope.teacher = result;
                });
            }

        }])
        .controller('teacherAddCtrl', ['$scope', '$location', '$routeParams', 'teachersService', function ($scope, $location, $routeParams, teachersService) {

            $scope.teacher = {};
            $scope.id = $routeParams.id;
            $scope.loading = false;

            if (!$scope.id || $scope.id === 'new') {
                $scope.submit = function (teacher) {
                    $scope.loading = true;
                    teachersService.addTeacher(teacher).then(function () {
                        $scope.loading = false;
                        toastr.success('Teacher created successfully!');
                        $location.path('/teachers');
                    }, function () {
                        $scope.loading = false;
                        toastr.error('Error in creating teacher');
                    });
                };
            } else {
                $scope.loading = true;
                teachersService.getTeacherById($scope.id).then(function (result) {
                    $scope.loading = false;
                    $scope.teacher = result;
                });

                $scope.submit = function (teacher) {
                    $scope.loading = true;
                    teachersService.editTeacher($scope.id, teacher).then(function () {
                        $scope.loading = false;
                        toastr.success('Teacher updated successfully!');
                        $location.path('/teachers');
                    }, function () {
                        $scope.loading = false;
                        toastr.error('Error in updating teacher');
                    });
                };
            }
        }]);
})();
