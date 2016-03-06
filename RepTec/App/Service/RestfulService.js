'use strict';

var services = angular.module('repTec.restfulService', ['ngResource']);

services.factory('RepairersFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Repairers', {}, {
            query: { method: 'GET', isArray: true },
            create: { method: 'POST' }
        });
    }
]);

services.factory('RepairerFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Repairers/:id', {}, {
            show: { method: 'GET' },
            update: { method: 'PUT', params: { id: '@id' } },
            delete: { method: 'DELETE', params: { id: '@id' } }
        });
    }
]);

services.factory('NomenclatureFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Nomenclature', {}, {
            query: { method: 'GET', isArray: true },
            create: { method: 'POST' }
        });
    }
]);

services.factory('NomenclatureUnitFactory', ['$resource',
    function ($resource) {
        return $resource('/api/Nomenclature/:id', {}, {
            show: { method: 'GET' },
            update: { method: 'PUT', params: { id: '@id' } },
            delete: { method: 'DELETE', params: { id: '@id' } }
        });
    }
]);

services.factory('NomenclatureTypesFactory', ['$resource',
    function ($resource) {
        return $resource('/api/NomenclatureTypes', {}, {
            query: { method: 'GET', isArray: true },
        });
    }
]);