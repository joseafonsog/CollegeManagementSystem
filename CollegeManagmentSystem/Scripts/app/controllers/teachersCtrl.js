(function () {
    'use strict';

    angular
        .module('app')
        .controller('teachersCtrl', ['$scope', 'teachersService', function ($scope, teachersService) {
            $scope.teachers = [];

            getData();

            function getData() {
                teachersService.getTeachers().then(function (result) {
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
        .controller('teacherAddCtrl', ['$scope', '$location', '$routeParams', 'teachersService', function ($scope, $location, $routeParams, teachersService) {

            $scope.teacher = {};
            $scope.id = $routeParams.id;

            console.log($scope.id);

            if (!$scope.id || $scope.id === 'new') {
                console.log("new");
                $scope.submit = function (teacher) {
                    teachersService.addTeacher(teacher).then(function () {
                        toastr.success('Teacher created successfully!');
                        $location.path('/teachers');
                    }, function () {
                        toastr.error('Error in creating teacher');
                    });
                };
            } else {
                teachersService.getTeacherById($scope.id).then(function (result) {
                    console.log(result);
                    $scope.teacher = result;
                });

                $scope.submit = function (teacher) {
                    teachersService.editTeacher($scope.id, teacher).then(function () {
                        toastr.success('Teacher updated successfully!');
                        $location.path('/teachers');
                    }, function () {
                        toastr.error('Error in updating teacher');
                    });
                };
            }
        }]);
})();
