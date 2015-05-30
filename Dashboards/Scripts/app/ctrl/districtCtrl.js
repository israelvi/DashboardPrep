app.controller('districtController', function ($scope) {
    $scope.m = {};
    $scope.lstDistricts = [{ id: 1, value: 'Local' }, { id: 2, value: 'Federal' }];
    $scope.district = $scope.lstDistricts[0];
});