using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SistemaRRHH
{
    public class AN_Jerarquia
    {
        public Nodo_Empleado Raiz { get; set; }

        public AN_Jerarquia()
        {
            Raiz = null;
        }

        // Método recursivo para buscar un nodo por su ID
        public Nodo_Empleado Buscar(string idBuscado, Nodo_Empleado nodoActual)
        {
            if (nodoActual == null) return null;

            if (nodoActual.Id == idBuscado) return nodoActual;

            foreach (Nodo_Empleado subalterno in nodoActual.Subalternos)
            {
                Nodo_Empleado encontrado = Buscar(idBuscado, subalterno);
                if (encontrado != null)
                {
                    return encontrado;
                }
            }

            return null;
        }

        // Método para insertar al empleado en su lugar correcto
        public bool Insertar(Nodo_Empleado nuevoEmpleado, string idJefe)
        {
            if (Raiz == null)
            {
                Raiz = nuevoEmpleado; // Es el jefe máximo

                // Enviar correo para el Jefe Máximo
               EnviarConfirmacion(nuevoEmpleado, "N/A (Jefe Máximo)");
                return true;
            }

            Nodo_Empleado jefe = Buscar(idJefe, Raiz);

            if (jefe != null)
            {
                nuevoEmpleado.Jefe = jefe;
                jefe.Subalternos.Add(nuevoEmpleado);

                // Enviar correo con la info del nuevo empleado y su jefe encontrado
                EnviarConfirmacion(nuevoEmpleado, jefe.Nombre);
                return true;
            }

            return false;
        }

        public bool EliminarConReasignacion(string idEliminar, string idNuevoJefe)
        {
            Nodo_Empleado nodoAEliminar = Buscar(idEliminar, Raiz);
            if (nodoAEliminar == null) return false;

            // CASO 1: Es la Raíz
            if (nodoAEliminar == Raiz)
            {
                if (nodoAEliminar.Subalternos.Count > 0) return false; // Protegemos que no borren al dueño si hay empleados
                Raiz = null;
                return true;
            }

            Nodo_Empleado jefeActual = nodoAEliminar.Jefe;

            // CASO 2: Reasignar subalternos (si los tiene)
            if (nodoAEliminar.Subalternos.Count > 0)
            {
                Nodo_Empleado nuevoJefe = Buscar(idNuevoJefe, Raiz);
                if (nuevoJefe != null)
                {
                    foreach (Nodo_Empleado hijo in nodoAEliminar.Subalternos)
                    {
                        hijo.Jefe = nuevoJefe;
                        nuevoJefe.Subalternos.Add(hijo);
                    }
                }
            }

            // Desconectar al despedido de su jefe actual
            jefeActual.Subalternos.Remove(nodoAEliminar);
            nodoAEliminar.Subalternos.Clear();
            nodoAEliminar.Jefe = null;

            return true;
        }


        public bool ActualizarEmpleado(string idEmpleado, string nuevoNombre, string nuevoPuesto, double nuevoSueldo, string idNuevoJefe)
        {
            // 1. Buscar al empleado que vamos a editar
            Nodo_Empleado empAEditar = Buscar(idEmpleado, Raiz);
            if (empAEditar == null) return false;

            // 2. Actualizar sus datos básicos
            empAEditar.Nombre = nuevoNombre;
            empAEditar.Puesto = nuevoPuesto;
            empAEditar.Sueldo = nuevoSueldo;

            // 3. Lógica para cambiar de Jefe (Mover la rama)
            // Validamos que no sea la raíz (la raíz no tiene jefe) y que nos hayan pasado un ID de jefe
            if (empAEditar.Jefe != null && !string.IsNullOrEmpty(idNuevoJefe))
            {
                // Solo hacemos el movimiento si realmente eligieron un jefe distinto al actual
                if (empAEditar.Jefe.Id != idNuevoJefe)
                {
                    Nodo_Empleado nuevoJefe = Buscar(idNuevoJefe, Raiz);

                    if (nuevoJefe != null)
                    {
                        // --- Validaciones de Seguridad Estrictas ---
                        // A. No puede ser jefe de sí mismo
                        if (nuevoJefe.Id == empAEditar.Id) return false;

                        // B. Evitar ciclos infinitos (El nuevo jefe no puede ser su subordinado)
                        if (Buscar(nuevoJefe.Id, empAEditar) != null) return false;

                        // --- Hacemos el cambio en el Árbol ---
                        empAEditar.Jefe.Subalternos.Remove(empAEditar); // Desconectar del viejo
                        empAEditar.Jefe = nuevoJefe;                    // Asignar al nuevo
                        nuevoJefe.Subalternos.Add(empAEditar);          // Conectar al nuevo
                    }
                }
            }

            return true; // Todo salió bien
        }

        public bool FusionarDepartamentos(string idGanador, string idPerdedor, string nuevoCargoGanador)
        {
            Nodo_Empleado ganador = Buscar(idGanador, Raiz);
            Nodo_Empleado perdedor = Buscar(idPerdedor, Raiz);

            // Validamos que ambos existan
            if (ganador == null || perdedor == null) return false;

            // 1. Actualizamos el cargo del ganador
            ganador.Puesto = nuevoCargoGanador;

            // 2. Traspasamos a todos los empleados del perdedor al equipo del ganador
            // OJO: Usamos ToList() para crear una copia temporal de la lista. 
            // Si modificamos una lista mientras la recorremos en un foreach, C# lanza error.
            foreach (Nodo_Empleado empleadoTransferido in perdedor.Subalternos.ToList())
            {
                empleadoTransferido.Jefe = ganador;       // Le asignamos el nuevo jefe
                ganador.Subalternos.Add(empleadoTransferido); // Lo agregamos a la lista del ganador
            }

            // El perdedor se queda sin subordinados
            perdedor.Subalternos.Clear();

            // 3. Desconectamos al perdedor de su jefe actual (el Dueño/Raíz)
            if (perdedor.Jefe != null)
            {
                perdedor.Jefe.Subalternos.Remove(perdedor);
            }

            // 4. El perdedor pasa a ser un empleado más bajo el mando del ganador
            perdedor.Jefe = ganador;
            ganador.Subalternos.Add(perdedor);

            return true;
        }

        // Método recursivo para contar los empleados de un subárbol
        public int ContarEmpleadosSubarbol(Nodo_Empleado nodoActual)
        {
            if (nodoActual == null) return 0;

            int contador = 1; // Nos contamos a nosotros mismos (al jefe)

            // Sumamos a todos los subalternos de forma recursiva
            foreach (Nodo_Empleado subalterno in nodoActual.Subalternos)
            {
                contador += ContarEmpleadosSubarbol(subalterno);
            }

            return contador;
        }

        public static void EnviarConfirmacion(Nodo_Empleado empleado, string nombreJefe)
        {
            try
            {
                // 1. Configuración de la cuenta emisora (Sistema)
                var senderEmail = "sistemarh10@gmail.com";
                var appPassword = "myzupkxuajtvuhom"; // La que ya te funcionó

                // 2. Configuración del mensaje
                var mensaje = new MailMessage
                {
                    From = new MailAddress(senderEmail, "Sistema RRHH - UDB"),
                    Subject = $"Bienvenido al Sistema - {empleado.Nombre}",
                    IsBodyHtml = true
                };

                // El 'Username' ahora es el correo del empleado, así que lo usamos como destino
                mensaje.To.Add(empleado.Username);

                // 3. Cuerpo del mensaje con la contraseña incluida
                mensaje.Body = $@"
            <div style='font-family: Arial, sans-serif; color: #333; max-width: 600px; border: 1px solid #eee; padding: 20px;'>
                <h2 style='color: #2e6c80;'>¡Hola, {empleado.Nombre}!</h2>
                <p>Tu registro en el sistema de Recursos Humanos ha sido completado exitosamente.</p>
                <hr style='border: 0; border-top: 1px solid #eee;' />
                
                <p><strong>Tus credenciales de acceso son:</strong></p>
                <div style='background-color: #f9f9f9; padding: 15px; border-radius: 5px;'>
                    <p style='margin: 5px 0;'><b>Usuario:</b> {empleado.Username}</p>
                    <p style='margin: 5px 0;'><b>Contraseña:</b> <span style='color: #d9534f; font-family: monospace;'>{empleado.Password}</span></p>
                </div>

                <p style='margin-top: 20px;'><b>Detalles del puesto:</b></p>
                <ul>
                    <li><b>Cargo:</b> {empleado.Puesto}</li>
                    <li><b>Jefe Inmediato:</b> {nombreJefe}</li>
                </ul>
                
                <hr style='border: 0; border-top: 1px solid #eee;' />
                <p style='font-size: 0.8em; color: #999;'>Generado el: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
            </div>";

                // 4. Configuración del cliente SMTP
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, appPassword);

                    client.Send(mensaje);
                }

                Console.WriteLine($"Correo enviado con éxito a: {empleado.Username}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }

    }
}