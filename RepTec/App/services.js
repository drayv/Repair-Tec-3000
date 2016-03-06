﻿'use strict';

var services = angular.module('repTec.services', ['ngResource']);

services.factory('RepairersFactory', function ($resource) {
    return $resource('/api/Repairers', {}, {
        query: { method: 'GET', isArray: true },
        create: { method: 'POST' }
    })
});

services.factory('RepairerFactory', function ($resource) {
    return $resource('/api/Repairers/:id', {}, {
        show: { method: 'GET' },
        update: { method: 'PUT', params: { id: '@id' } },
        delete: { method: 'DELETE', params: { id: '@id' } }
    })
});