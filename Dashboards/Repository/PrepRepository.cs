using System;
using System.Collections.Generic;
using System.Linq;
using Dashboards.Models;

namespace Dashboards.Repository
{
    public class PrepRepository : BaseOneRepository, IPrepRepository
    {
        public IList<EleccionesDto> LastResult(int candidateType)
        {
            throw new NotImplementedException();
            //return Db.Elecciones.Where(e => e.IdTipoEleccion == candidateType).Select(e => new EleccionesDto
            //{
            //    Pan = e.Pan,
            //    Pri = e.Pri,
            //    Prd = e.Prd,
            //    Pna = e.Pna,
            //    Pvem = e.Pvem,
            //    Pt = e.Pt,
            //    Morena = e.Morena,
            //    Otros = e.Otros,
            //}).ToList();
        }

        public EleccionesDto LastResultFirst(int candidateType)
        {
            throw new NotImplementedException();
            //return Db.Elecciones.Where(e => e.IdTipoEleccion == candidateType).Select(e => new EleccionesDto
            //{
            //    Pan = e.Pan,
            //    Pri = e.Pri,
            //    Prd = e.Prd,
            //    Pna = e.Pna,
            //    Pvem = e.Pvem,
            //    Pt = e.Pt,
            //    Morena = e.Morena,
            //    Otros = e.Otros,
            //}).FirstOrDefault();
        }
    }
}