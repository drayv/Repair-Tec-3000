'use strict';

angular.module('repTec.repairRequests', ['ngRoute'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/repair-requests', { templateUrl: '/app/RepairRequests/RepairRequests.html', controller: 'RepairRequestsCtrl' });
    $routeProvider.when('/repair-request/:id', { templateUrl: '/app/RepairRequests/EditRepairRequest.html', controller: 'EditRepairRequestCtrl' });
    $routeProvider.when('/add-repair-request', { templateUrl: '/app/RepairRequests/AddRepairRequest.html', controller: 'AddRepairRequestCtrl' });
}])

.filter('startFrom', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
})

.controller('EditRepairRequestCtrl', ['$scope', 'RepairRequestFactory', 'RepairStatusesFactory', 'NomenclatureFactory',
    'RepairersFactory', '$location', '$routeParams', '$timeout', function ($scope, RepairRequestFactory,
        RepairStatusesFactory, NomenclatureFactory, RepairersFactory, $location, $routeParams, $timeout) {

        $scope.equipmentSearch = {};
        $scope.equipmentSearch.Type = {};
        $scope.equipmentSearch.Type.Name = 'Оборудование';

        RepairRequestFactory.show({ id: $routeParams.id }).$promise.then(function (result) {
            $scope.repairRequest = result;

            RepairStatusesFactory.query().$promise.then(function (result) {
                $scope.repairStatuses = result;

                $timeout(function () {
                    $('#status').val($scope.repairRequest.Status.Id);
                    $('.ui.dropdown').dropdown();
                }, 0);
            });

            NomenclatureFactory.query().$promise.then(function (result) {
                $scope.nomenclature = result;

                $timeout(function () {
                    $('#equipmentToBeRepaired').val($scope.repairRequest.EquipmentToBeRepaired.Id);
                    $('.ui.dropdown').dropdown();
                }, 0);
            });

            RepairersFactory.query().$promise.then(function (result) {
                $scope.repairers = result;
                
                $timeout(function () {
                    $('#repairer').val($scope.repairRequest.Repairer.Id);
                    $('.ui.dropdown').dropdown();
                }, 0);
            });

        });

        $scope.setStatus = function (id) {
            $scope.repairRequest.Status.Id = id;
        };

        $scope.setEquipmentToBeRepaired = function (id) {
            $scope.repairRequest.EquipmentToBeRepaired.Id = id;
        };

        $scope.setRepairer = function (id) {
            $scope.repairRequest.Repairer.Id = id;
        };

        $scope.updateRepairRequest = function () {
            if ($scope.repairRequest.Status.Id && $scope.repairRequest.EquipmentToBeRepaired.Id
                   && $scope.repairRequest.Repairer.Id && $scope.repairRequest.Adress) {
                RepairRequestFactory.update({
                    id: $scope.repairRequest.Id
                }, $scope.repairRequest).$promise.then(function (result) {
                    $location.path('/repair-requests');
                });
            } else {
                $('.ui.form').form({
                    fields: {
                        Status: 'empty', EquipmentToBeRepaired: 'empty',
                        Repairer: 'empty', Adress: 'empty'
                    }
                });
            }
        };

        $scope.cancel = function () {
            $location.path('/repair-requests');
        };
    }
])

.controller('AddRepairRequestCtrl', ['$scope', 'RepairRequestsFactory', 'NomenclatureFactory', 'RepairStatusesFactory', 'RepairersFactory', '$location',
     function ($scope, RepairRequestsFactory, NomenclatureFactory, RepairStatusesFactory, RepairersFactory, $location) {
         $scope.repairRequest = {};
         $scope.repairRequest.Status = {};
         $scope.repairRequest.EquipmentToBeRepaired = {};
         $scope.repairRequest.Repairer = {};
         $scope.equipmentSearch = {};
         $scope.equipmentSearch.Type = {};
         $scope.equipmentSearch.Type.Name = 'Оборудование';

         RepairStatusesFactory.query().$promise.then(function (result) {
             $scope.repairStatuses = result;
             $('.ui.dropdown').dropdown();
         });

         NomenclatureFactory.query().$promise.then(function (result) {
             $scope.nomenclature = result;
             $('.ui.dropdown').dropdown();
         });

         RepairersFactory.query().$promise.then(function (result) {
             $scope.repairers = result;
             $('.ui.dropdown').dropdown();
         });

         $scope.setStatus = function (id) {
             $scope.repairRequest.Status.Id = id;
         };

         $scope.setEquipmentToBeRepaired = function (id) {
             $scope.repairRequest.EquipmentToBeRepaired.Id = id;
         };

         $scope.setRepairer = function (id) {
             $scope.repairRequest.Repairer.Id = id;
         };

         $scope.createNewRepairRequest = function () {
             if ($scope.repairRequest.Status.Id && $scope.repairRequest.EquipmentToBeRepaired.Id
                    && $scope.repairRequest.Repairer.Id && $scope.repairRequest.Adress) {
                 RepairRequestsFactory.create($scope.repairRequest).$promise.then(function (result) {
                     $location.path('/repair-requests');
                 });
             } else {
                 $('.ui.form').form({
                     fields: {
                         Status: 'empty', EquipmentToBeRepaired: 'empty',
                         Repairer: 'empty', Adress: 'empty'
                     }
                 });
             }
         };

         $scope.cancel = function () {
             $location.path('/repair-requests');
         };
     }
])

.controller('RepairRequestsCtrl', ['$scope', 'RepairRequestsFactory', 'RepairRequestFactory', 'HelperService', '$location', '$filter',
    function ($scope, RepairRequestsFactory, RepairRequestFactory, HelperService, $location, $filter) {
        $scope.currentPage = 0;
        $scope.itemsPerPage = 10;
        $scope.repairRequests = RepairRequestsFactory.query();
        $scope.filteredItems = $scope.repairRequests;

        $scope.editRepairRequest = function (id) {
            $location.path('/repair-request/' + id);
        };

        $scope.deleteRepairRequest = function (id) {
            RepairRequestFactory.delete({ id: id }).$promise.then(function (result) {
                RepairRequestsFactory.query().$promise.then(function (result) {
                    $scope.repairRequests = result;
                    $scope.filteredItems = $scope.repairRequests;
                    if ($scope.currentPage > $scope.numberOfPages() - 1) {
                        $scope.currentPage = $scope.numberOfPages() - 1;
                    }
                    $scope.query = "";
                });
            });
        };

        $scope.createNewRepairRequest = function () {
            $location.path('/add-repair-request');
        };

        $scope.search = function () {
            $scope.filteredItems = $filter('filter')($scope.repairRequests, function (item) {
                if (HelperService.searchMatch(item["Status"]["Name"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["Repairer"]["Name"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch($filter('date')(item["Date"], "dd-MM-yyyy"), $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["Name"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["Adress"], $scope.query)) {
                    return true;
                } else if (HelperService.searchMatch(item["EquipmentToBeRepaired"]["Name"], $scope.query)) {
                    return true;
                }
                return false;
            });
            $scope.currentPage = 0;
        };

        HelperService.addPaginationMethodsToScope($scope);
    }
]);