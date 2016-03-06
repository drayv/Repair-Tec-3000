'use strict';

angular.module('repTec.helpers', ['ngRoute'])

.factory("HelperService", function () {
    return {
        addPaginationMethodsToScope: function (scope) {
            scope.prevPage = function () {
                if (scope.currentPage > 0) {
                    scope.currentPage--;
                }
            };

            scope.nextPage = function () {
                if (scope.currentPage < scope.numberOfPages() - 1) {
                    scope.currentPage++;
                }
            };

            scope.startingItem = function () {
                return scope.currentPage * scope.itemsPerPage;
            }

            scope.numberOfPages = function () {
                return Math.ceil(scope.filteredItems.length / scope.itemsPerPage);
            }
        },
        searchMatch: function (haystack, needle) {
            if (!needle) {
                return true;
            }
            return haystack.toLowerCase().indexOf(needle.toLowerCase()) !== -1;
        }
    }
});