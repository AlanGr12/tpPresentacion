public class DatoInteres{
public int Id{ get; private set; }
public int IdUsuario{ get; private set; }
public int TipoInteres{ get; private set; }
public string Interes { get; private set; }


public DatoInteres(int Id, int IdUsuario, int TipoInteres, string Interes){

this.Id = Id;
this.IdUsuario = IdUsuario;
this.TipoInteres = TipoInteres;
this.Interes = Interes;

}
}