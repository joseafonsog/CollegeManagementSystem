(function () {
    'use strict';

    angular
        .module('app')
        .controller('coursesCtrl', ['$scope', 'coursesService', function ($scope, coursesService) {
            $scope.courses = [];

            getData();

            function getData() {
                coursesService.getCourses().then(function (result) {
                    $scope.courses = result;
                });
            }

            $scope.deleteCourse = function (id) {
                coursesService.deleteCourse(id).then(function () {
                    toastr.success('Course deleted successfully!');
                    getData();
                }, function () {
                    toastr.error('Error in deleting course');
                });
            };
        }])
        .controller('courseAddCtrl', ['$scope', '$location', '$routeParams', 'coursesService', function ($scope, $location, $routeParams, coursesService) {

            $scope.course = {};
            $scope.id = $routeParams.id;

            console.log($scope.id);

            if (!$scope.id || $scope.id === 'new') {
                console.log("new");
                $scope.submit = function (course) {
                    coursesService.addCourse(course).then(function () {
                        toastr.success('Course created successfully!');
                        $location.path('/courses');
                    }, function () {
                        toastr.error('Error in creating course');
                    });
                };
            } else {
                coursesService.getCourseById($scope.id).then(function (result) {
                    console.log(result);
                    $scope.course = result;
                });

                $scope.submit = function (course) {
                    coursesService.editCourse($scope.id, course).then(function () {
                        toastr.success('Course updated successfully!');
                        $location.path('/courses');
                    }, function () {
                        toastr.error('Error in updating course');
                    });
                };
            }
        }]);
})();
