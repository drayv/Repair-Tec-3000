'use strict';

angular.module('repTec.repairers', ['ngRoute'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/repairers', { templateUrl: '/app/repairers/Repairers.html', controller: 'RepairersCtrl' });
    $routeProvider.when('/repairer/:id', { templateUrl: '/app/repairers/EditRepairer.html', controller: 'EditRepairerCtrl' });
    $routeProvider.when('/add-repairer', { templateUrl: '/app/repairers/AddRepairer.html', controller: 'AddRepairerCtrl' });
}])

.filter('startFrom', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
})

.controller('EditRepairerCtrl', ['$scope', 'RepairerFactory', '$location', '$routeParams',
     function ($scope, RepairerFactory, $location, $routeParams) {
         $scope.updateRepairer = function () {
             RepairerFactory.update({
                 id: $scope.repairer.Id
             }, $scope.repairer).$promise.then(function (result) {
                 $location.path('/repairers');
             });
         };

         $scope.cancel = function () {
             $location.path('/repairers');
         };

         $scope.repairer = RepairerFactory.show({ id: $routeParams.id });
     }
])

.controller('AddRepairerCtrl', ['$scope', 'RepairersFactory', '$location',
     function ($scope, RepairersFactory, $location) {
         $scope.createNewRepairer = function () {
             RepairersFactory.create($scope.repairer).$promise.then(function (result) {
                 $location.path('/repairers');
             })
         };

         $scope.cancel = function () {
             $location.path('/repairers');
         };
     }
])

.controller('RepairersCtrl', ['$scope', 'RepairersFactory', 'RepairerFactory', 'HelperService', '$location', '$filter',
    function ($scope, RepairersFactory, RepairerFactory, HelperService, $location, $filter) {
        $scope.currentPage = 0;
        $scope.itemsPerPage = 5;
        $scope.repairers = RepairersFactory.query();
        $scope.filteredItems = $scope.repairers;

        $scope.editRepairer = function (id) {
            $location.path('/repairer/' + id);
        };

        $scope.deleteRepairer = function (userId) {
            RepairerFactory.delete({ id: userId }).$promise.then(function (result) {
                RepairersFactory.query().$promise.then(function (result) {
                    $scope.repairers = result;
                    $scope.filteredItems = $scope.repairers;
                    if ($scope.currentPage > $scope.numberOfPages() - 1) {
                        $scope.currentPage = $scope.numberOfPages() - 1;
                    }
                    $scope.query = "";
                });
            });
        };

        $scope.createNewRepairer = function () {
            $location.path('/add-repairer');
        };

        $scope.search = function () {
            $scope.filteredItems = $filter('filter')($scope.repairers, function (item) {
                if (HelperService.searchMatch(item["Name"], $scope.query)) {
                    return true;
                }
                return false;
            });
            $scope.currentPage = 0;
        };

        HelperService.addPaginationMethodsToScope($scope);
    }
]);