app.controller('detailController', function ($scope) {
    $scope.m = {};
    $scope.lstMonitoring = [{ id: 1, value: 'Asistencia' }, { id: 2, value: 'Instalación' }, { id: 1, value: 'Incidentes' }, { id: 1, value: 'Desayunos/Comidas' }];
    $scope.monitor = $scope.lstMonitoring[0];
    $scope.lstStatus = [{ id: 1, value: 'Todos' }, { id: 2, value: 'Incorrectos' }, { id: 3, value: 'Correctos' }];
    $scope.status = $scope.lstStatus[0];
});