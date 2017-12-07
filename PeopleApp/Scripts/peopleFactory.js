(function () {
    'use strict';

    var serviceId = 'peopleFactory';

    angular.module('PeopleApp').factory(serviceId,
        ['$http', peopleFactory]);

    function peopleFactory($http) {

        function getPeople(searchCriteria) {
            var apiString = '/api/people';

            if (typeof searchCriteria != 'undefined') {
                apiString = apiString + '/' + searchCriteria;
            };

            showProgress();
            setTimeout(function () { }, 3000);
            return $http.get(apiString);
            
        };


        var service = {
            getPeople: getPeople
        };

        return service;
    }
})();