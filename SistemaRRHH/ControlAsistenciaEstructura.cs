using System;
using System.Collections.Generic;

public class ControlAsistenciaEstructura
{
    private Dictionary<string, AsistenciaRegistro> tabla = new Dictionary<string, AsistenciaRegistro>();

    private string Clave(string dui, DateTime fecha)
    {
        return dui + "_" + fecha.ToString("yyyyMMdd");
    }
    // VALIDACIONES GENERALES
    private void ValidarDatos(string id, string dui)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new Exception("El ID del empleado es obligatorio");

        if (string.IsNullOrWhiteSpace(dui))
            throw new Exception("El DUI es obligatorio");

        if (dui.Length < 9)
            throw new Exception("DUI inválido");
    }

    // ENTRADA
    public void RegistrarEntrada(string id, string dui, DateTime hora)
    {
        ValidarDatos(id, dui);

        string clave = Clave(dui, hora.Date);

        if (tabla.ContainsKey(clave))
            throw new Exception("Ya registró entrada hoy");

        if (hora.Hour < 6 || hora.Hour > 12)
            throw new Exception("Hora de entrada fuera del rango permitido (6AM - 12PM)");

        tabla[clave] = new AsistenciaRegistro
        {
            IdEmpleado = id,
            DUI = dui,
            Fecha = hora.Date,
            HoraEntrada = hora,
            Estado = "Incompleta"
        };
    }
    // SALIDA
    public void RegistrarSalida(string dui, DateTime hora)
    {
        if (string.IsNullOrWhiteSpace(dui))
            throw new Exception("El DUI es obligatorio");

        string clave = Clave(dui, hora.Date);

        if (!tabla.ContainsKey(clave))
            throw new Exception("Debe marcar entrada primero");

        var reg = tabla[clave];

        if (reg.HoraEntrada == null)
            throw new Exception("Entrada no válida");

        if (reg.HoraSalida != null)
            throw new Exception("Ya registró salida");

        // Salida antes de entrada
        if (hora <= reg.HoraEntrada)
            throw new Exception("La salida no puede ser antes de la entrada");

        // Salida fuera de rango laboral
        if (hora.Hour < 12 || hora.Hour > 23)
            throw new Exception("Hora de salida fuera del rango permitido");

        reg.HoraSalida = hora;

        // CALCULO HORAS
        reg.HorasTrabajadas = Math.Round(
            (reg.HoraSalida.Value - reg.HoraEntrada.Value).TotalHours, 2);

        // ESTADO
        if (reg.HorasTrabajadas >= 8)
            reg.Estado = "A Tiempo";
        else if (reg.HorasTrabajadas >= 4)
            reg.Estado = "Media Jornada";
        else
            reg.Estado = "Incompleto";
    }

    // CONSULTAS
    public AsistenciaRegistro Buscar(string dui, DateTime fecha)
    {
        string clave = Clave(dui, fecha);

        return tabla.ContainsKey(clave) ? tabla[clave] : null;
    }

    public List<AsistenciaRegistro> ObtenerTodos()
    {
        return new List<AsistenciaRegistro>(tabla.Values);
    }
}