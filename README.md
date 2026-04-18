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
