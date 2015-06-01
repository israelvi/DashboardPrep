namespace Dashboards.Models.Dto
{
    public class ElectionResGeneral
    {
        public int AsistenciaCasillas { get; set; }
        public int AsistenciaConteo { get; set; }
        public int DttoElec { get; set; }
        public string TipoEleccion { get; set; }
        public int DesayunoCasillas { get; set; }
        public int DesayunoConteo { get; set; }
        public int IncidentesCasillas { get; set; }
        public int IncidentesConteo { get; set; }
        public int InstalacionConteo { get; set; }
        public int InstalacionCasillas { get; set; }
        public int TotalCasillas { get; set; }
        public int IdRegion { get; set; }
        public int ComidaCasillas { get; set; }
        public int ComidaConteo { get; set; }
        public string NotaAsistencia { get; set; }
        public string NotaDesayuno { get; set; }
        public string NotaComida { get; set; }
        public string NotaIncidente { get; set; }
        public string NotaInstalacion { get; set; }
        public int Seccion { get; set; }
        public string Casilla { get; set; }
        public int CodigoIncidente { get; set; }
    }
}