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
        public NodoEmpleado Raiz { get; set; }

        public AN_Jerarquia()
        {
            Raiz = null;
        }


        // Dentro de AN_Jerarquia
        public List<NodoEmpleado> ObtenerTodosLosNodos()
        {
            List<NodoEmpleado> lista = new List<NodoEmpleado>();
            Recorrer(Raiz, lista);
            return lista;
        }



        private void Recorrer(NodoEmpleado nodo, List<NodoEmpleado> lista)
        {
            if (nodo == null) return;
            lista.Add(nodo);
            foreach (NodoEmpleado hijo in nodo.Subalternos)
                Recorrer(hijo, lista);
        }

        // Método recursivo para buscar un nodo por su ID
        public NodoEmpleado Buscar(string idBuscado, NodoEmpleado nodoActual)
        {
            if (nodoActual == null) return null;

            if (nodoActual.Id == idBuscado) return nodoActual;

            foreach (NodoEmpleado subalterno in nodoActual.Subalternos)
            {
                NodoEmpleado encontrado = Buscar(idBuscado, subalterno);
                if (encontrado != null)
                {
                    return encontrado;
                }
            }

            return null;
        }

        // Método para insertar al empleado en su lugar correcto
        public bool Insertar(NodoEmpleado nuevoEmpleado, string idJefe)
        {
            if (Raiz == null)
            {
                Raiz = nuevoEmpleado; 

               EnviarConfirmacion(nuevoEmpleado, "N/A (Jefe Máximo)");
                return true;
            }

            NodoEmpleado jefe = Buscar(idJefe, Raiz);

            if (jefe != null)
            {
                nuevoEmpleado.Jefe = jefe;
                jefe.Subalternos.Add(nuevoEmpleado);

                EnviarConfirmacion(nuevoEmpleado, jefe.Nombre);
                return true;
            }

            return false;
        }

        public bool EliminarConReasignacion(string idEliminar, string idNuevoJefe)
        {
            NodoEmpleado nodoAEliminar = Buscar(idEliminar, Raiz);
            if (nodoAEliminar == null) return false;

            // CASO 1: Es la Raíz
            if (nodoAEliminar == Raiz)
            {
                if (nodoAEliminar.Subalternos.Count > 0) return false; 
                Raiz = null;
                return true;
            }

            NodoEmpleado jefeActual = nodoAEliminar.Jefe;

            // CASO 2: Reasignar subalternos (si los tiene)
            if (nodoAEliminar.Subalternos.Count > 0)
            {
                NodoEmpleado nuevoJefe = Buscar(idNuevoJefe, Raiz);
                if (nuevoJefe != null)
                {
                    foreach (NodoEmpleado hijo in nodoAEliminar.Subalternos)
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
            NodoEmpleado empAEditar = Buscar(idEmpleado, Raiz);
            if (empAEditar == null) return false;

            // 2. Actualizar sus datos básicos
            empAEditar.Nombre = nuevoNombre;
            empAEditar.Puesto = nuevoPuesto;
            empAEditar.Sueldo = nuevoSueldo;

            // 3. Lógica para cambiar de Jefe (Mover la rama)
            if (empAEditar.Jefe != null && !string.IsNullOrEmpty(idNuevoJefe))
            {
                if (empAEditar.Jefe.Id != idNuevoJefe)
                {
                    NodoEmpleado nuevoJefe = Buscar(idNuevoJefe, Raiz);

                    if (nuevoJefe != null)
                    {
                        // --- Validaciones ---

                        // A. No puede ser jefe de sí mismo
                        if (nuevoJefe.Id == empAEditar.Id) return false;

                        // B. Evitar ciclos infinitos
                        if (Buscar(nuevoJefe.Id, empAEditar) != null) return false;

                        empAEditar.Jefe.Subalternos.Remove(empAEditar); 
                        empAEditar.Jefe = nuevoJefe;                    
                        nuevoJefe.Subalternos.Add(empAEditar);         
                    }
                }
            }

            return true; 
        }

        public bool FusionarDepartamentos(string idGanador, string idPerdedor, string nuevoCargoGanador)
        {
            NodoEmpleado ganador = Buscar(idGanador, Raiz);
            NodoEmpleado perdedor = Buscar(idPerdedor, Raiz);

            if (ganador == null || perdedor == null) return false;

            // 1. Actualizamos el cargo del ganador
            ganador.Puesto = nuevoCargoGanador;

            // 2. Traspasamos a todos los empleados del perdedor al equipo del ganador
            foreach (NodoEmpleado empleadoTransferido in perdedor.Subalternos.ToList())
            {
                empleadoTransferido.Jefe = ganador;      
                ganador.Subalternos.Add(empleadoTransferido); 
            }

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
        public int ContarEmpleadosSubarbol(NodoEmpleado nodoActual)
        {
            if (nodoActual == null) return 0;

            int contador = 1; 

            foreach (NodoEmpleado subalterno in nodoActual.Subalternos)
            {
                contador += ContarEmpleadosSubarbol(subalterno);
            }

            return contador;
        }

        public static void EnviarConfirmacion(NodoEmpleado empleado, string nombreJefe)
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