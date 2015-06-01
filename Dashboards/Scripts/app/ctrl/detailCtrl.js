app.controller('detailController', function ($scope, $timeout) {
    $scope.m = {};
    $scope.lstMonitoring = [{ id: -1, value: 'Todos' }, { id: 1, value: 'Asistencia' }, { id: 2, value: 'Instalación' }, { id: 3, value: 'Incidentes' }, { id: 4, value: 'Desayunos' }, { id: 5, value: 'Comidas' }];
    $scope.monitor = $scope.lstMonitoring[0];

    $scope.lstStatus = [{ id: -1, grId: -1, value: 'Todos' }, { id: 1, grId: -1, value: 'Exitoso' }, { id: 2, grId: -1, value: 'Fallido' }, { id: 3, grId: -1, value: 'Sin reporte' },
        { id: -1, grId: 1, value: 'Todos' }, { id: 1, grId: 1, value: 'Con asistencia' }, { id: 2, grId: 1, value: 'Sin asistencia' }, { id: 3, grId: 1, value: 'Sin reporte' },
        { id: -1, grId: 2, value: 'Todos' }, { id: 1, grId: 2, value: 'Instaladas' }, { id: 2, grId: 2, value: 'No instaladas' }, { id: 3, grId: 2, value: 'Sin reporte' },
        { id: -1, grId: 3, value: 'Todos' }, { id: 1, grId: 3, value: 'Sin incidentes' }, { id: 2, grId: 3, value: 'Con incidentes' }, { id: 3, grId: 3, value: 'Sin reporte' },
        { id: -1, grId: 4, value: 'Todos' }, { id: 1, grId: 4, value: 'Con desayuno' }, { id: 2, grId: 4, value: 'Sin desayuno' }, { id: 3, grId: 4, value: 'Sin reporte' },
        { id: -1, grId: 5, value: 'Todos' }, { id: 1, grId: 5, value: 'Con comida' }, { id: 2, grId: 5, value: 'Sin comida' }, { id: 3, grId: 5, value: 'Sin reporte' }
    ];

    $scope.init = function () {
        var monitorId = $scope.monitor.id;
        $scope.selectCurrenStatus(monitorId);
    };

    $scope.onMonitorChange = function () {
        $scope.selectCurrenStatus($scope.monitor.id);
    };

    $scope.selectCurrenStatus = function (monitorId) {
        $scope.lstCurrentStatus = jQuery.map($scope.lstStatus, function (item) {
            if (item.grId === monitorId)
                return item;
            return null;
        });
        $scope.status = $scope.lstCurrentStatus[0];
    };

    $scope.init();

    $timeout(function () {

        $scope.electionParams = {
            Corte: $scope.Corte,
            District: $scope.idDistrict,
            Region: $scope.idRegion,
            MonitorId: $scope.monitor.id,
            StatusId: $scope.status.id
        };

        var clientHub = $.connection.electionDayHub;

        $.connection.hub.logging = true;
        $.connection.hub.start().done(function () {
            $scope.catalogsDistrictByRegionId($scope.idRegion);
        });

        clientHub.client.lastUpdateProp = function (model) {
            processUpdate(model);
        };

        $scope.catalogsDistrictByRegionId = function (idRegion) {
            clientHub.server.catalogsDistrictByRegionId(idRegion)
                .then(function (res) {
                    $scope.$apply(function () {
                        $scope.catalogs = res.Data;
                    });
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
                var resIn = model;
                var lstResults = [];
                var lstRegions = $scope.getRegions(resIn);

                for (var r, i = 0; r = lstRegions[i++];) {

                    var lstAsistencia = [], lstIncidencia = [], lstInstalacion = [], lstDesayuno = [], lstComida = [];

                    for (var m, j = 0; m = resIn[j++];) {
                        if (m.IdRegion === r) {
                            lstAsistencia.push({ status: m.AsistenciaConteo, section: m.Seccion, box: m.Casilla, comment: m.NotaAsistencia });
                            lstInstalacion.push({ status: m.InstalacionConteo, section: m.Seccion, box: m.Casilla, comment: m.NotaInstalacion });
                            lstIncidencia.push({
                                status: m.IncidentesConteo, section: m.Seccion, box: m.Casilla,
                                comment: window.firstCatalog($scope.catalogs.Incidents, m.CodigoIncidente)
                            });
                            lstDesayuno.push({ status: m.DesayunoConteo, section: m.Seccion, box: m.Casilla, comment: m.NotaDesayuno });
                            lstComida.push({ status: m.ComidaConteo, section: m.Seccion, box: m.Casilla, comment: m.NotaComida });
                        }
                    }

                    lstResults.push({
                        RegionId: r, RegionName: window.firstCatalog($scope.catalogs.Regions, r), Casillas: lstAsistencia.length,
                        Asistencia: {name: "Asistencia", id: 1, data: lstAsistencia}, 
                        Instalacion: { name: "Instalación", id: 2, data: lstInstalacion},
                        Incidencia: { name: "Incidencia", id: 3, data: lstIncidencia },
                        Desayuno: { name: "Desayuno", id: 4, data: lstDesayuno },
                        Comida: { name: "Comida", id: 5, data: lstComida}
                    });
                }

                $scope.lstResults = lstResults;
                $scope.refreshChevrons();
            });
        };
    }, 100);

    $scope.getRegions = function (items) {
        var lookup = {};
        var result = [];

        for (var item, i = 0; item = items[i++];) {
            var name = item.IdRegion;

            if (!(name in lookup)) {
                lookup[name] = 1;
                result.push(name);
            }
        }
        return result;
    };

    $scope.refreshChevrons = function() {
        $timeout(function () {
            $('.collapse-link').click(function () {
                var ibox = $(this).closest('div.ibox');
                var button = $(this).find('i');
                var content = ibox.find('div.ibox-content');
                content.slideToggle(200);
                button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
                ibox.toggleClass('').toggleClass('border-bottom');
                setTimeout(function () {
                    ibox.resize();
                    ibox.find('[id^=map-]').resize();
                }, 50);
            });
        }, 1000);
    };

    $scope.filterStatus = function(item) {
        if ($scope.status.id === -1)
            return true;
        return item.status === $scope.status.id;
    };

});

//var lstCasillas = jQuery.map($scope.lstStatus, function (item) {
//    if (item.IdRegion === r)
//        return item;
//    return null;
//});
