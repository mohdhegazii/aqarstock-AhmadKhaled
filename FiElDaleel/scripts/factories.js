brokerApp.factory('brokerFactory', ['$http', function($http) {

    var generalURL = 'http://www.aqarstock.com/Services/GeneralService.svc/';
    var realestateURL='http://www.aqarstock.com/Services/RealEstateService.svc/';

    var brokerFactory = {};

    brokerFactory.getDistricts = function () {
        return $http.get(generalURL+'Districts');
    };
    brokerFactory.getRealEstates = function (pageIndex,pageSize) {
        return $http.get(realestateURL+'RealEstates/'+pageIndex+'/'+pageSize);
    };
    /*
    dataFactory.getCustomer = function (id) {
        return $http.get(urlBase + '/' + id);
    };

    dataFactory.insertCustomer = function (cust) {
        return $http.post(urlBase, cust);
    };

    dataFactory.updateCustomer = function (cust) {
        return $http.put(urlBase + '/' + cust.ID, cust)
    };

    dataFactory.deleteCustomer = function (id) {
        return $http.delete(urlBase + '/' + id);
    };

    dataFactory.getOrders = function (id) {
        return $http.get(urlBase + '/' + id + '/orders');
    };*/

    return brokerFactory;
}]);
