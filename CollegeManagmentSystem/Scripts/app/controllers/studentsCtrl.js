(function () {
    'use strict';

    angular
        .module('app')
        .controller('studentsCtrl', ['$scope', 'studentsService', function ($scope, studentsService) {
            $scope.students = [];
            $scope.loading = false;

            getData();

            function getData() {
                $scope.loading = true;
                studentsService.getStudents().then(function (result) {
                    $scope.loading = false;
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
        .controller('studentDetailsCtrl', ['$scope', '$location', '$routeParams', 'studentsService', function ($scope, $location, $routeParams, studentsService) {
            $scope.student = {};
            $scope.loading = false;
            var id = $routeParams.id;

            getData();

            function getData() {
                $scope.loading = true;
                studentsService.getStudentDetails(id).then(function (result) {
                    $scope.loading = false;
                    $scope.student = result;
                });
            }

        }])
        .controller('studentAddCtrl', ['$scope', '$location', '$routeParams', 'studentsService', 'subjectsService', 'coursesService', function ($scope, $location, $routeParams, studentsService, subjectsService, coursesService) {

            $scope.student = {};
            $scope.courses = [];
            $scope.subjects = [];
            $scope.id = $routeParams.id;
            $scope.loading = false;
            $scope.enrollForm = {};
            $scope.subjectsEnrolled = [];
            const unenrollSubjects = [];

            loadSelects();

            $scope.handleCourseSelection = function () {
                $scope.subjects = [];
                if ($scope.enrollForm && $scope.enrollForm.SubjectId) {
                    $scope.enrollForm.SubjectId = undefined;
                }

                subjectsService.getSubjectsByCourse($scope.enrollForm.CourseId).then(function (result) {
                    var subjectsId = [];
                    $scope.subjectsEnrolled.forEach(function (item, index) {
                        subjectsId.push(item.subject.Id);
                    });
                    $scope.subjects = result.filter(function (item) { return !subjectsId.includes(item.Id); });
                });
            };

            $scope.enroll = function () {

                var course = $scope.courses.find(function (item) { return item.Id === parseInt($scope.enrollForm.CourseId); });
                var subject = $scope.subjects.find(function (item) { return item.Id === parseInt($scope.enrollForm.SubjectId); });
                
                if (!course || !subject) return;

                $scope.subjectsEnrolled.push({
                    course: course,
                    subject: subject
                });


                $scope.subjects = $scope.subjects.filter(function (item) { return item.Id !== parseInt($scope.enrollForm.SubjectId); });

                if ($scope.subjects.length <= 0) {
                    $scope.courses = $scope.courses.filter(function (item) { return item.Id !== parseInt($scope.enrollForm.CourseId); });
                }

                clearEnrollForm();
            };



            $scope.unenroll = function (id) {

                if (!id) return;

                unenrollSubjects.push(parseInt(id));

                $scope.subjectsEnrolled = $scope.subjectsEnrolled.filter(function (item) { return item.subject.Id !== id; });
            };

            if (!$scope.id || $scope.id === 'new') {
                $scope.submit = function (student) {
                    $scope.loading = true;
                    student.EnrollSubjects = [];

                    $scope.subjectsEnrolled.forEach(function (item, index) {
                        student.EnrollSubjects.push(item.subject.Id);
                    });

                    studentsService.addStudent(student).then(function () {
                        $scope.loading = false;
                        toastr.success('Student created successfully!');
                        $location.path('/students');
                    }, function () {
                        $scope.loading = false;
                        toastr.error('Error in creating student');
                    });
                };
            } else {
                $scope.loading = true;
                studentsService.getStudentById($scope.id).then(function (result) {
                    $scope.loading = false;
                    $scope.student = result;
                });

                $scope.subjects = 

                $scope.submit = function (student) {
                    $scope.loading = true;
                    studentsService.editStudent($scope.id, student).then(function () {
                        $scope.loading = false;
                        toastr.success('Student updated successfully!');
                        $location.path('/students');
                    }, function () {
                        $scope.loading = false;
                        toastr.error('Error in updating student');
                    });
                };
            }

            function loadSelects() {
                coursesService.getCourses().then(function (result) {
                    $scope.courses = result;
                });
            }

            function clearEnrollForm() {
                $scope.enrollForm = {};
            }
        }]);
})();
