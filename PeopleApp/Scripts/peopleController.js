(function () {
    'use strict';

    var controllerId = 'peopleController';

    angular.module('PeopleApp').controller(controllerId,
        ['$scope', 'peopleFactory', peopleController]);

    function peopleController($scope, peopleFactory) {
        $scope.people = [];
        $scope.person = [];
        $scope.personDetailIndex = 0;
        $scope.searchCriteria = "";

        $scope.searchClick = function () {
            // show the progress bar then wait 3 seconds to 
            // simulate a slow load
            showProgress();
            setTimeout(function () { retrievePeople(); }, 3000);
        };

        $scope.findPersonIndex = function (Id) {
            var index = $scope.people.findIndex(x => x.Id == Id);
            $scope.personDetailIndex = index;
        };


        function retrievePeople() {
            peopleFactory.getPeople($scope.searchCriteria).then(
                // callback for successful http request
                function success(response) {
                    $scope.people = response.data;
                    hideProgress();
                },
                //callback for error in http request
                function error(response) {
                    // error handling
                    hideProgress();
                }
            );
        };

        peopleFactory.getPeople("").then(
            // callback for successful http request
            function success(response) {
                $scope.people = response.data;
                hideProgress();
            },
            //callback for error in http request
            function error(response) {
                // error handling
                hideProgress();
            }
        );
    }
})();