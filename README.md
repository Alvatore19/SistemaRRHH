# 🏢 Sistema de Información para la Gestión de Recursos Humanos (RRHH)

## 📋 Descripción del Proyecto
El presente proyecto tiene como finalidad el diseño y desarrollo de un Sistema de Información para la gestión de Recursos Humanos, orientado a automatizar y optimizar los procesos administrativos relacionados con el personal de una organización. 

El sistema delimita su alcance a los siguientes módulos funcionales:

* **👥 Gestión de Empleados:** Registro, actualización y consulta de información personal, laboral y contractual de los empleados, incluyendo historial laboral dentro de la organización.
* **⏱️ Gestión de Asistencia:** Control de entradas y salidas, registro de ausencias, permisos, incapacidades y vacaciones, con capacidad de generar históricos por empleado.
* **💰 Gestión de Nómina:** Cálculo automatizado de salarios basado en parámetros predefinidos, incluyendo deducciones (impuestos, seguridad social) y bonificaciones.
* **🏢 Estructura Organizacional:** Administración de puestos, cargos, departamentos y jerarquías organizacionales.
* **📈 Evaluación de Desempeño:** Registro y seguimiento de evaluaciones periódicas del personal mediante indicadores definidos.
* **📊 Generación de Reportes:** Elaboración de reportes estructurados relacionados con empleados, asistencia, nómina y desempeño, exportables a formatos estándar.

---

## 🧠 Arquitectura y Estructuras de Datos
Para dar soporte a los módulos mencionados, el núcleo de este sistema se basa en el uso estratégico de Estructuras de Datos Abstractas (TADs) operando en memoria principal (RAM), garantizando un rendimiento óptimo. La persistencia de datos se maneja a través de **SQL Server** y **Entity Framework 6 (ADO.NET)**.

* **🌳 Árbol N-ario (Módulo de Empleados y Estructura Organizacional):** Representa la jerarquía del organigrama empresarial, permitiendo inserciones, reasignaciones y búsquedas de dependencias directas.
* **🔗 Lista Enlazada Simple (Módulo de Nómina):** Modela el flujo de cálculo del salario neto y el historial de compensaciones. Cada nodo representa transacciones secuenciales.
* **⚡ Tabla Hash (Módulo de Asistencia):** Garantiza un acceso de tiempo constante $O(1)$ para el registro de entradas y salidas durante las horas pico, utilizando el documento legal y la fecha como llave.
* **🚥 Cola de Prioridad (Gestión de Permisos):** Gestiona las solicitudes de ausencia evaluando dinámicamente el nivel de urgencia, logrando que emergencias médicas se atiendan antes que las solicitudes de vacaciones.

---

## 🛠️ Requisitos Previos
Para ejecutar este proyecto de manera local, asegúrese de contar con el siguiente entorno:
* **IDE:** Visual Studio (2019 o 2022) con la carga de trabajo *"Desarrollo de escritorio de .NET"*.
* **Framework:** .NET Framework 4.7.2.
* **Base de Datos:** SQL Server Express LocalDB (Se incluye por defecto en la carga de trabajo *"Almacenamiento y procesamiento de datos"* de Visual Studio).

---

## 🚀 Guía de Instalación y Ejecución
Siga estos pasos al pie de la letra para configurar el entorno local y evitar excepciones de conexión a la base de datos:

### 1. Clonar el Repositorio
```bash
git clone [https://github.com/TU-USUARIO/SistemaRRHH.git](https://github.com/TU-USUARIO/SistemaRRHH.git)
```

### 2. Configuración de la Base de Datos
1. Abra **SQL Server Management Studio (SSMS)** o el **Explorador de objetos de SQL Server** en Visual Studio.
2. Ejecute el script SQL incluido en la carpeta DataBase(RRHH) en el proyecto para generar la estructura completa de la base de datos (tablas, restricciones y relaciones).
3. Abra el archivo `App.config` en Visual Studio y actualice la cadena de conexión (`connectionString`) dentro de la sección de Entity Framework para que apunte a su servidor local de SQL Server.
> **Nota técnica:** Si tras ejecutar el script SQL nota inconsistencias en el código, abra el archivo `.edmx` en Visual Studio y utilice la opción "Actualizar modelo desde base de datos" para sincronizar las entidades con su instancia local de SQL Server.

### 3. Apertura y Restauración de Dependencias
1. Navegue a la carpeta clonada y abra el archivo principal de la solución: `SistemaRRHH.sln`.
2. Para asegurar que Entity Framework y otras dependencias funcionen correctamente, haga clic derecho sobre la solución en el **Explorador de soluciones** y seleccione **Restaurar paquetes NuGet**.
3. Compile el proyecto presionando `Ctrl + Shift + B` (o en el menú **Compilar > Compilar solución**).

### 4. Ejecución del Programa
1. Verifique que el proyecto `SistemaRRHH` esté establecido como el proyecto de inicio.
2. Presione `F5` o haga clic en el botón **"Iniciar" (Start)** en la barra superior de Visual Studio.
3. En la pantalla de Login, ingrese utilizando las credenciales de prueba proporcionadas en la documentación interna (DUI y Contraseña).
