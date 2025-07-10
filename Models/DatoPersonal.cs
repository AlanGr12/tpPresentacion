public class DatoPersonal 
{
public int Id {get; private set;}
public string Nombre { get; private set; }
public string Apellido{ get; private set; }

public string Email {get; private set;}
public string Contraseña {get; private set;}
public DateTime FechaNacimiento { get; private set; }
public string Foto {get; private set;}


public DatoPersonal(int Id, string Nombre, string Apellido, string Email, string Contraseña, DateTime FechaNacimiento, string foto){
this.Id = Id;
this.Nombre = Nombre;
this.Apellido = Apellido;
this.Email = Email;
this.Contraseña = Contraseña;
this.FechaNacimiento = FechaNacimiento;
}

public int ObtenerEdad(){     
    
        var hoy = DateTime.Today;
        int edad = hoy.Year - FechaNacimiento.Year;
        if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
        return edad;
}

}