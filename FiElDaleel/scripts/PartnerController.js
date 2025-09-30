var brokerApp = angular.module('brokerApp', ['ui.router', 'ngAnimate', 'ngResource']);

brokerApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
      $urlRouterProvider.otherwise('/');
 
    $locationProvider.hashPrefix('!');
});

brokerApp.controller('PartnerUnitsController', function ($scope, $stateParams, $state, $location, BrokerServices) {
    alert("testPartner");
});
