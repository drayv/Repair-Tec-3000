'use strict';

angular.module('repTec', [
  'ngRoute',
  'repTec.restfulService',
  'repTec.helpers',
  'repTec.repairRequests',
  'repTec.repairers',
  'repTec.nomenclature'
]).

config(['$routeProvider', function ($routeProvider) {
    $routeProvider.otherwise({ redirectTo: '/repair-requests' });
}]);