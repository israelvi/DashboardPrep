app.controller('districtController', function ($scope, $timeout) {
    $scope.m = {};
    $scope.lstDistricts = [{ id: 'L', value: 'Local' }, { id: 'F', value: 'Federal' }];
    $scope.district = $scope.lstDistricts[0];

    $scope.lstResults = [];
    $scope.electionParams = { Global: $scope.district.id };

    $scope.onDistrictChange = function() {
        $scope.electionParams.Global = $scope.district.id;
        $scope.lastUpdate($scope.electionParams);
    };

    $timeout(function () {

        var clientHub = $.connection.electionDayHub;

        $.connection.hub.logging = true;
        $.connection.hub.start().done(function () {
            $scope.lastUpdate($scope.electionParams);
        });

        clientHub.client.lastUpdateProp = function (model) {
            processUpdate(model);
        };

        $scope.lastUpdate = function (electionParams) {
            clientHub.server.lastUpdate(electionParams)
                .then(function (res) {
                    processUpdate(res.LstData);
                });
        };

        function processUpdate(model) {
            $scope.$apply(function () {
                $scope.lstResults = model;
            });
        };
    }, 100);
});