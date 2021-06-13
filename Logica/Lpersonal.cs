using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORUSCURSO.Logica
{
    public class Lpersonal
    {

//		[Id_personal] [int] IDENTITY(1,1) NOT NULL,
//[Nombres] [varchar]
//		(max) NULL,
//[Identificacion] [varchar]
//		(max) NULL,
//[Pais] [varchar]
//		(max) NULL,
//[Id_cargo] [int] NULL,
//	[SueldoPorHora] [numeric] (18, 2) NULL,
//	[Estado]
//		[varchar]
//		(max) NULL,
//	[Codigo] [varchar]
//		(max) NULL,

public int Id_personal { get; set; }
public string Nombres { get; set; }
public string Identificacion { get; set; }
public string Pais { get; set; }
public int Id_cargo { get; set; }
public double SueldoPorHora { get; set; }
public string Estado { get; set; }
public string Codigo { get; set; }


    }
}
