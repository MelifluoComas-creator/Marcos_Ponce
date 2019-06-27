using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Marcos_Ponce.App_Code
{
    public class MCC_Conexion
    {
        public SqlConnection sqlcad = new SqlConnection("Data source=.; initial catalog =marcos_ponce; Integrated security = True");
        public void conectar() { sqlcad.Open(); }
        public void desconectar() { sqlcad.Close(); }
    }
}