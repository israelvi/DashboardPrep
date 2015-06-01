app.controller('regionController', function ($scope, $timeout) {
    $scope.m = {};
    $scope.Corte = 0;

    $scope.lstResults = [];
    $scope.electionParams = {};
    $scope.catalogs = {};

    $scope.firstCatalog = function (catalog, id, param) {
        return window.firstCatalog(catalog, id, param);
    };

    $timeout(function () {

        $scope.electionParams.Corte = $scope.Corte;
        $scope.electionParams.District = $scope.idDistrict;
        var clientHub = $.connection.electionDayHub;

        $.connection.hub.logging = true;
        $.connection.hub.start().done(function () {
            $scope.catalogsDistrict();
        });

        clientHub.client.lastUpdateProp = function (model) {
            processUpdate(model);
        };

        $scope.catalogsDistrict = function () {
            clientHub.server.catalogsDistrict()
                .then(function (res) {
                    $scope.catalogs = res.Data;
                    $scope.lastUpdate($scope.electionParams);
                });
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

                for (var i = 0, len = $scope.lstResults.length; i < len; i++) {
                    var item = $scope.lstResults[i];
                    item.Coordinates = window.fullCatalog($scope.catalogs.CoordRegions, item.IdRegion);
                    item.Locations = window.fullCatalog($scope.catalogs.LocRegions, item.IdRegion);
                }

            });
        };
    }, 100);

});