﻿'use strict';

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

services.factory('RepairRequestsFactory', ['$resource',
    function ($resource) {
        return $resource('/api/RepairRequests', {}, {
            query: { method: 'GET', isArray: true },
            create: { method: 'POST' }
        });
    }
]);

services.factory('RepairRequestFactory', ['$resource',
    function ($resource) {
        return $resource('/api/RepairRequests/:id', {}, {
            show: { method: 'GET' },
            update: { method: 'PUT', params: { id: '@id' } },
            delete: { method: 'DELETE', params: { id: '@id' } }
        });
    }
]);

services.factory('RepairStatusesFactory', ['$resource',
    function ($resource) {
        return $resource('/api/RepairStatuses', {}, {
            query: { method: 'GET', isArray: true },
        });
    }
]);

services.factory('NomenclatureInRequest', ['$resource',
    function ($resource) {
        return $resource('/api/NomenclatureInRequest', {}, {
            create: { method: 'POST' }
        });
    }
]);

services.factory('NomenclatureUnitInRequest', ['$resource',
    function ($resource) {
        return $resource('/api/NomenclatureInRequest/:id', {}, {
            show: { method: 'GET', isArray: true },
            delete: { method: 'DELETE', params: { id: '@id' } }
        });
    }
]);