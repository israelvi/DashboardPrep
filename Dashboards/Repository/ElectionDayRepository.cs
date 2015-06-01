using System.Collections.Generic;
using System.Linq;
using Dashboards.Models;
using Dashboards.Models.Constants;
using Dashboards.Models.Dto;

namespace Dashboards.Repository
{
    public class ElectionDayRepository : BaseOneRepository, IElectionDayRepository
    {
        public IList<EleccionesDto> LastUpdate(ElectionDayParams electionDayParams)
        {
            throw new System.NotImplementedException();
        }

        public IList<ElectionResGeneral> LastUpdateGlobal(ElectionDayParams electionDayParams)
        {
            return DbEntities.V_GeneralNivelGlobal
                .Where(e => e.D_TipoEleccion == electionDayParams.Global)
                .Select(e => new ElectionResGeneral
                {
                    AsistenciaCasillas = e.AsistenciaCasillas??0,
                    AsistenciaConteo = e.AsistenciaConteo ?? 0,
                    DttoElec = (int)e.D_DttoElec,
                    TipoEleccion = e.D_TipoEleccion,
                    DesayunoCasillas = e.DesayunoCasillas ?? 0,
                    DesayunoConteo = e.DesayunoConteo ?? 0,
                    ComidaCasillas = e.ComidaCasillas ?? 0,
                    ComidaConteo = e.ComidaConteo ?? 0,
                    IncidentesCasillas = e.IncidentesCasillas ?? 0,
                    IncidentesConteo = e.IncidentesConteo ?? 0,
                    InstalacionCasillas = e.InstalacionCasillas ?? 0,
                    InstalacionConteo = e.InstalacionConteo ?? 0,
                    TotalCasillas = e.TotalCasillas ?? 0,
                }).ToList();
        }

        public IList<ItemModel> GetRegions()
        {
            return DbEntities.Region.Select(e => new ItemModel
            {
                Id = e.IdRegion,
                ValOne = e.Nombre,
                ValTwo = e.Descripcion
            }).ToList();
        }

        public IList<ItemModel> GetCoordRegions()
        {
            return DbEntities.RegionCoordinador.Select(e => new ItemModel
            {
                Id = e.IdRegion,
                ValOne = e.Coordinador,
                ValTwo = e.Telefonos
            }).ToList();
        }

        public IList<ItemModel> GetLocRegions()
        {
            return DbEntities.RegionUbicacion.Select(e => new ItemModel
            {
                Id = e.IdRegion,
                ValOne = e.Ubicacion
            }).ToList();
        }

        public IList<ElectionResGeneral> LastUpdateDistrict(ElectionDayParams electionDayParams)
        {
            return DbEntities.V_GeneralNivelDistrito
                .Where(e => (int)e.D_DttoElec == electionDayParams.District)
                .Select(e => new ElectionResGeneral
                {
                    IdRegion = e.IdRegion,
                    AsistenciaCasillas = e.AsistenciaCasillas ?? 0,
                    AsistenciaConteo = e.AsistenciaConteo ?? 0,
                    DttoElec = (int)e.D_DttoElec,
                    TipoEleccion = e.D_TipoEleccion,
                    DesayunoCasillas = e.DesayunoCasillas ?? 0,
                    DesayunoConteo = e.DesayunoConteo ?? 0,
                    ComidaCasillas = e.ComidaCasillas ?? 0,
                    ComidaConteo = e.ComidaConteo ?? 0,
                    IncidentesCasillas = e.IncidentesCasillas ?? 0,
                    IncidentesConteo = e.IncidentesConteo ?? 0,
                    InstalacionCasillas = e.InstalacionCasillas ?? 0,
                    InstalacionConteo = e.InstalacionConteo ?? 0,
                    TotalCasillas = e.TotalCasillas ?? 0,
                }).ToList();
        }

        public IList<ItemModel> GetRegionsByRegionId(int regionId)
        {
            return DbEntities.Region.Where(e => e.IdRegion == regionId || regionId == SharedConstants.ENTITY_NULL).Select(e => new ItemModel
            {
                Id = e.IdRegion,
                ValOne = e.Nombre,
                ValTwo = e.Descripcion
            }).ToList();
        }

        public IList<ItemModel> GetCoordRegionsByRegionId(int regionId)
        {
            return DbEntities.RegionCoordinador.Where(e => e.IdRegion == regionId || regionId == SharedConstants.ENTITY_NULL).Select(e => new ItemModel
            {
                Id = e.IdRegion,
                ValOne = e.Coordinador,
                ValTwo = e.Telefonos
            }).ToList();
        }

        public IList<ItemModel> GetLocRegionsByRegionId(int regionId)
        {
            return DbEntities.RegionUbicacion.Where(e => e.IdRegion == regionId || regionId == SharedConstants.ENTITY_NULL).Select(e => new ItemModel
            {
                Id = e.IdRegion,
                ValOne = e.Ubicacion
            }).ToList();
        }

        public IList<ItemModel> GetIncidents()
        {
            return DbEntities.Tc_Incidentes.Select(e => new ItemModel
            {
                Id = e.Inc_Ref ?? 0,
                ValOne = e.Inc_Concepto
            }).ToList();
            
        }

        public IList<ElectionResGeneral> LastUpdateRegion(ElectionDayParams electionDayParams)
        {
            return DbEntities.V_GeneralNivelRegion
                .Where(e => (int)e.D_DttoElec == electionDayParams.District && (e.IdRegion == electionDayParams.Region || electionDayParams.Region == SharedConstants.ENTITY_NULL))
                .Select(e => new ElectionResGeneral
                {
                    IdRegion = e.IdRegion,
                    NotaAsistencia = e.NotaAsistencia,
                    AsistenciaConteo = e.AsistenciaEstatus,
                    DttoElec = (int)e.D_DttoElec,
                    NotaDesayuno = e.NotaDesayuno,
                    DesayunoConteo = e.DesayunoEstatus,
                    NotaComida = e.NotaComida,
                    ComidaConteo = e.ComidaEstatus,
                    NotaIncidente = e.NotaIncidente,
                    IncidentesConteo = e.IncidentesEstatus,
                    NotaInstalacion = e.NotaInstalacion,
                    InstalacionConteo = e.InstalacionEstatus,
                    CodigoIncidente = e.CodigoIncidente,
                    Seccion = (int)e.S_IdSeccion,
                    Casilla = e.TC_Descripcion,
                }).ToList();
        }
    }
}