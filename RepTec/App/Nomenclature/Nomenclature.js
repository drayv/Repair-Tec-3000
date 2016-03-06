'use strict';

angular.module('repTec.nomenclature', ['ngRoute'])

.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/nomenclature', { templateUrl: '/app/nomenclature/Nomenclature.html', controller: 'NomenclatureCtrl' });
    $routeProvider.when('/nomenclature/:id', { templateUrl: '/app/nomenclature/EditNomenclature.html', controller: 'EditNomenclatureCtrl' });
    $routeProvider.when('/add-nomenclature', { templateUrl: '/app/nomenclature/AddNomenclature.html', controller: 'AddNomenclatureCtrl' });
}])

.filter('startFrom', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
})

.controller('EditNomenclatureCtrl', ['$scope', 'NomenclatureUnitFactory', 'NomenclatureTypesFactory', '$location', '$routeParams', '$timeout',
     function ($scope, NomenclatureUnitFactory, NomenclatureTypesFactory, $location, $routeParams, $timeout) {
         NomenclatureTypesFactory.query().$promise.then(function (result) {
             $scope.nomenclatureTypes = result;
             NomenclatureUnitFactory.show({ id: $routeParams.id }).$promise.then(function (result) {
                 $scope.nomenclature = result;

                 $timeout(function () {
                     $('#nomenclatureType').val($scope.nomenclature.Type.Id);
                     $('.ui.dropdown').dropdown();
                 }, 0);
             });
         });

         $scope.setNomenclatureType = function (id) {
             $scope.nomenclature.Type.Id = id;
         };

         $scope.updateNomenclature = function () {
             if ($scope.nomenclature.Type.Id && $scope.nomenclature.Name) {
                 NomenclatureUnitFactory.update({
                     id: $scope.nomenclature.Id
                 }, $scope.nomenclature).$promise.then(function (result) {
                     $location.path('/nomenclature');
                 });
             } else {
                 $('.ui.form').form({ fields: { Name: 'empty', Type: 'empty' } });
             }
         };

         $scope.cancel = function () {
             $location.path('/nomenclature');
         };
     }
])

.controller('AddNomenclatureCtrl', ['$scope', 'NomenclatureFactory', 'NomenclatureTypesFactory', '$location',
     function ($scope, NomenclatureFactory, NomenclatureTypesFactory, $location) {
         NomenclatureTypesFactory.query().$promise.then(function (result) {
             $scope.nomenclatureTypes = result;
             $scope.nomenclature = {};
             $scope.nomenclature.Type = {};
             $('.ui.dropdown').dropdown();
         });

         $scope.setNomenclatureType = function (id) {
             $scope.nomenclature.Type.Id = id;
         };

         $scope.createNewNomenclature = function () {
             if ($scope.nomenclature.Type.Id && $scope.nomenclature.Name) {
                 NomenclatureFactory.create($scope.nomenclature).$promise.then(function (result) {
                     $location.path('/nomenclature');
                 });
             } else {
                 $('.ui.form').form({ fields: { Name: 'empty', Type: 'empty' } });
             }
         };

         $scope.cancel = function () {
             $location.path('/nomenclature');
         };
     }
])

.controller('NomenclatureCtrl', ['$scope', 'NomenclatureFactory', 'NomenclatureUnitFactory', 'HelperService', '$location', '$filter',
    function ($scope, NomenclatureFactory, NomenclatureUnitFactory, HelperService, $location, $filter) {
        $scope.currentPage = 0;
        $scope.itemsPerPage = 5;
        $scope.nomenclature = NomenclatureFactory.query();
        $scope.filteredItems = $scope.nomenclature;

        $scope.editNomenclature = function (id) {
            $location.path('/nomenclature/' + id);
        };

        $scope.deleteNomenclature = function (userId) {
            NomenclatureUnitFactory.delete({ id: userId }).$promise.then(function (result) {
                NomenclatureFactory.query().$promise.then(function (result) {
                    $scope.nomenclature = result;
                    $scope.filteredItems = $scope.nomenclature;
                    if ($scope.currentPage > $scope.numberOfPages() - 1) {
                        $scope.currentPage = $scope.numberOfPages() - 1;
                    }
                    $scope.query = "";
                });
            });
        };

        $scope.createNewNomenclature = function () {
            $location.path('/add-nomenclature');
        };

        $scope.search = function () {
            $scope.filteredItems = $filter('filter')($scope.nomenclature, function (item) {
                if (HelperService.searchMatch(item["Name"], $scope.query)) {
                    return true;
                }
                if (HelperService.searchMatch(item["Type"]["Name"], $scope.query)) {
                    return true;
                }
                return false;
            });
            $scope.currentPage = 0;
        };

        HelperService.addPaginationMethodsToScope($scope);
    }
]);