'use strict';

angular.module('repTec', [
  'ngRoute',
  'repTec.restfulService',
  'repTec.helpers',
  'repTec.view1',
  'repTec.repairers',
  'repTec.nomenclature'
]).

config(['$routeProvider', function ($routeProvider) {
    $routeProvider.otherwise({ redirectTo: '/view1' });
}]);