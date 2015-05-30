app.controller('electionGlobalCtrl', function ($scope) {
    $scope.m = {};
    $scope.lstTypes = [{ id: 1, value: 'Todas' }, { id: 2, value: 'Casillas no capturadas' }, { id: 3, value: 'Casillas capturadas' }];
    $scope.type = $scope.lstTypes[0];
});