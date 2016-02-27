'use strict';

angular.module('repTec', [
  'ngRoute',
  'repTec.view1',
  'repTec.view2'
]).

config(['$routeProvider', function ($routeProvider) {
    $routeProvider.otherwise({ redirectTo: '/view1' });
}]);