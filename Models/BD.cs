using System.Data.SqlClient;
using Dapper;

public class BD{
    
    public static void AgregarCandidato(Candidato can){
        string SQL="INSERT INTO Candidato(Nombre, Apellido, Foto, FechaNacimiento, Postulacion, IdPartido) VALUES (@pNombre, @pApellido, @pFoto, @pFechaNacimiento, @pPostulacion, @pIdPartido)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(SQL, new {pNombre=can.Nombre, pApellido=can.Apellido, pFoto=can.Foto, pFechaNacimiento=can.FechaNacimiento, pPostulacion=can.Postulacion, pIdPartido=can.IdPartido});
        }
    }

    public static int EliminarCandidato(int IdCandidato){
        int registrosEliminados=0;
        string sql ="DELETE FROM Candidato WHERE IdCandidato=@Candidato";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            registrosEliminados=db.Execute(sql, new {Candiato=IdCandidato});
        }
        return registrosEliminados;
    }

}