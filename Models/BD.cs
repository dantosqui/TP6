using System.Data.SqlClient;
using Dapper;
public class BD{

    private static string _connectionString=@"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";  
    public static void AgregarCandidato(Candidato can){
        string SQL="INSERT INTO Candidato(IdPartido, Nombre, Apellido, Foto, FechaNacimiento, Postulacion) VALUES (@pIdPartido, @pNombre, @pApellido, @pFoto, @pFechaNacimiento, @pPostulacion)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(SQL, new {pNombre=can.Nombre, pApellido=can.Apellido, pFoto=can.Foto, pFechaNacimiento=can.FechaNacimiento, pPostulacion=can.Postulacion, pIdPartido=can.IdPartido});
        }
    }

    public static int EliminarCandidato(int idCandidato){
        int registrosEliminados=0;
        string sql ="DELETE FROM Candidato WHERE IdCandidato = @pIdCandidato;";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            registrosEliminados=db.Execute(sql, new {pIdCandidato=idCandidato});
        }
        return registrosEliminados;
    }


    public static Partido VerInfoPartido(int idPartido){
        Partido MiPartido=null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Partido WHERE IdPartido = @pIdPartido";
            MiPartido = db.QueryFirstOrDefault<Partido>(sql, new {pIdPartido = idPartido});
        }
        return MiPartido;
    }

    public static Candidato VerInfoCandidato(int idCandidato){
        Candidato MiCandidato=null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Candidato WHERE IdCandidato = @pIdCandidato";
            MiCandidato = db.QueryFirstOrDefault<Candidato>(sql, new {pIdCandidato = idCandidato});
        }
        return MiCandidato;
    }

  public static List<Partido> ListarPartidos(){
        List<Partido> listaPartidos = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Partido";
            listaPartidos = db.Query<Partido>(sql).ToList();
        }
        return listaPartidos;
    }
 
    public static List<Candidato> ListarCandidatos(int idPartido){
        List<Candidato> listaCandis = null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Candidato WHERE IdPartido=@pIdPartido";
            listaCandis = db.Query<Candidato>(sql, new {pIdPartido=idPartido}).ToList();
        }
        return listaCandis;
    }
}



