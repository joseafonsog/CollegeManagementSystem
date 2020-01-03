(function () {
    'use strict';

    angular
        .module('app')
        .controller('studentsCtrl', ['$scope', 'studentsService', function ($scope, studentsService) {
            $scope.students = [];

            getData();

            function getData() {
                studentsService.getStudents().then(function (result) {
                    $scope.students = result;
                });
            }

            $scope.deleteStudent = function (id) {
                studentsService.deleteStudent(id).then(function () {
                    toastr.success('Student deleted successfully!');
                    getData();
                }, function () {
                    toastr.error('Error in deleting student');
                });
            };
        }])
        .controller('studentAddCtrl', ['$scope', '$location', '$routeParams', 'studentsService', function ($scope, $location, $routeParams, studentsService) {

            $scope.student = {};
            $scope.id = $routeParams.id;

            console.log($scope.id);

            if (!$scope.id || $scope.id === 'new') {
                console.log("new");
                $scope.submit = function (student) {
                    studentsService.addStudent(student).then(function () {
                        toastr.success('Student created successfully!');
                        $location.path('/students');
                    }, function () {
                        toastr.error('Error in creating student');
                    });
                };
            } else {
                studentsService.getStudentById($scope.id).then(function (result) {
                    console.log(result);
                    $scope.student = result;
                });

                $scope.submit = function (student) {
                    studentsService.editStudent($scope.id, student).then(function () {
                        toastr.success('Student updated successfully!');
                        $location.path('/students');
                    }, function () {
                        toastr.error('Error in updating student');
                    });
                };
            }
        }]);
})();
