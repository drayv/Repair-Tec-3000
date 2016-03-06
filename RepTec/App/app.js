'use strict';

angular.module('repTec', [
  'ngRoute',
  'repTec.services',
  'repTec.helpers',
  'repTec.view1',
  'repTec.repairers'
]).

config(['$routeProvider', function ($routeProvider) {
    $routeProvider.otherwise({ redirectTo: '/view1' });
}]);