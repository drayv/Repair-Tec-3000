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

.controller('EditNomenclatureCtrl', ['$scope', 'NomenclatureUnitFactory', 'NomenclatureTypesFactory', 'HelperService', '$location', '$routeParams', '$timeout',
     function ($scope, NomenclatureUnitFactory, NomenclatureTypesFactory, HelperService, $location, $routeParams, $timeout) {

         HelperService.activateMenu('#nomenclature-menu-item');
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
             var price = parseFloat($scope.nomenclature.Price.toString().replace(",", "."));
             $scope.nomenclature.Price = price;

             if ($scope.nomenclature.Type.Id && $scope.nomenclature.Name && price != null) {
                 NomenclatureUnitFactory.update({
                     id: $scope.nomenclature.Id
                 }, $scope.nomenclature).$promise.then(function (result) {
                     $location.path('/nomenclature');
                 });
             } else {
                 $('.ui.form').form({
                     on: 'blur',
                     fields: {
                         Name: {
                             identifier: 'Name',
                             rules: [{ type: 'empty', prompt: 'Введите наименование!' }]
                         },
                         Type: {
                             identifier: 'Type',
                             rules: [{ type: 'empty', prompt: 'Выбирете тип!' }]
                         },
                         Price: {
                             identifier: 'Price',
                             rules: [{ type: 'regExp[/^([0-9]{0,8}((,)[0-9]{0,2}))$/]', prompt: 'Формат цены: разделитьль: запятая, два знака после запятой как максимум.' }]
                         }
                     }
                 });
             }
         };

         $scope.cancel = function () {
             $location.path('/nomenclature');
         };
     }
])

.controller('AddNomenclatureCtrl', ['$scope', 'NomenclatureFactory', 'NomenclatureTypesFactory', 'HelperService', '$location',
     function ($scope, NomenclatureFactory, NomenclatureTypesFactory, HelperService, $location) {

         HelperService.activateMenu('#nomenclature-menu-item');

         NomenclatureTypesFactory.query().$promise.then(function (result) {
             $scope.nomenclatureTypes = result;
             $scope.nomenclature = {};
             $scope.nomenclature.Type = {};
             $scope.nomenclature.Price = 0;
             $('.ui.dropdown').dropdown();
         });

         $scope.setNomenclatureType = function (id) {
             $scope.nomenclature.Type.Id = id;
         };

         $scope.createNewNomenclature = function () {
             var price = parseFloat($scope.nomenclature.Price.toString().replace(",", "."));
             $scope.nomenclature.Price = price;

             if ($scope.nomenclature.Type.Id && $scope.nomenclature.Name && price != null) {
                 NomenclatureFactory.create($scope.nomenclature).$promise.then(function (result) {
                     $location.path('/nomenclature');
                 });
             } else {
                 $('.ui.form').form({
                     on: 'blur',
                     fields: {
                         Name: {
                             identifier: 'Name',
                             rules: [{ type: 'empty', prompt: 'Введите наименование!' }]
                         },
                         Type: {
                             identifier: 'Type',
                             rules: [{ type: 'empty', prompt: 'Выбирете тип!' }]
                         },
                         Price: {
                             identifier: 'Price',
                             rules: [{ type: 'regExp[/^([0-9]{0,8}((,)[0-9]{0,2}))$/]', prompt: 'Формат цены: разделитьль: запятая, два знака после запятой как максимум.' }]
                         }
                     }
                 });
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
        $scope.itemsPerPage = 10;
        $scope.nomenclature = NomenclatureFactory.query();
        $scope.filteredItems = $scope.nomenclature;

        HelperService.activateMenu('#nomenclature-menu-item');

        $scope.editNomenclature = function (id) {
            $location.path('/nomenclature/' + id);
        };

        $scope.deleteNomenclature = function (id) {
            NomenclatureUnitFactory.delete({ id: id }).$promise.then(function (result) {
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