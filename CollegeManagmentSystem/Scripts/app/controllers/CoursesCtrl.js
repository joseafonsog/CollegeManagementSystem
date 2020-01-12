(function () {
    'use strict';

    angular
        .module('app')
        .controller('coursesCtrl', ['$scope', 'coursesService', function ($scope, coursesService) {
            $scope.courses = [];
            $scope.loading = false;

            getData();

            function getData() {
                $scope.loading = true;
                coursesService.getCoursesWithExtraData().then(function (result) {
                    $scope.loading = false;
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
        .controller('courseDetailsCtrl', ['$scope', '$location', '$routeParams', 'coursesService', function ($scope, $location, $routeParams, coursesService) {
            $scope.course = {};
            $scope.loading = false;
            var id = $routeParams.id;

            getData();

            function getData() {
                $scope.loading = true;
                coursesService.getCourseDetails(id).then(function (result) {
                    $scope.loading = false;
                    $scope.course = result;
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
            $scope.loading = false;

            if (!$scope.id || $scope.id === 'new') {
                $scope.submit = function (course) {
                    $scope.loading = true;
                    coursesService.addCourse(course).then(function () {
                        $scope.loading = false;
                        toastr.success('Course created successfully!');
                        $location.path('/courses');
                    }, function () {
                        $scope.loading = false;
                        toastr.error('Error in creating course');
                    });
                };
            } else {
                $scope.loading = true;
                coursesService.getCourseById($scope.id).then(function (result) {
                    $scope.loading = false;
                    $scope.course = result;
                });

                $scope.submit = function (course) {
                    $scope.loading = true;
                    coursesService.editCourse($scope.id, course).then(function () {
                        $scope.loading = false;
                        toastr.success('Course updated successfully!');
                        $location.path('/courses');
                    }, function () {
                        $scope.loading = false;
                        toastr.error('Error in updating course');
                    });
                };
            }
        }]);
})();
