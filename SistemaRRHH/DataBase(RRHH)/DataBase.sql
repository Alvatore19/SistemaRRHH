-- =============================================================
-- Script de Base de Datos: SistemaRRHH (Para Entity Framework)
-- =============================================================
DROP DATABASE IF EXISTS SistemaRRHH;
CREATE DATABASE SistemaRRHH;
GO

USE SistemaRRHH;
GO

-- =====================================================
-- 1. Creación de Tablas con Restricciones (Constraints)
-- =====================================================

CREATE TABLE Cargo(
    IdCargo INT IDENTITY(1,1) NOT NULL,
    NombreRol VARCHAR(100) NOT NULL,
    NivelJerarquico INT NOT NULL,
    SalarioBase DECIMAL(10,2) NOT NULL CHECK (SalarioBase > 0),
    BonoEscala1 DECIMAL(10,2) NOT NULL DEFAULT 0.00 CHECK (BonoEscala1 > 0),
    BonoEscala2 DECIMAL(10,2) NOT NULL DEFAULT 0.00 CHECK (BonoEscala2 > 0),
    BonoEscala3 DECIMAL(10,2) NOT NULL DEFAULT 0.00 CHECK (BonoEscala3 > 0),
    CONSTRAINT PK_IdCargo PRIMARY KEY(IdCargo)
);

CREATE TABLE Empleado(
    IdEmpleado VARCHAR(20) NOT NULL,
    IdCargo INT NOT NULL,
    IdJefe VARCHAR(20) NULL, 
    NombreCompleto VARCHAR(150) NOT NULL,
    DocumentoLegal VARCHAR(15) NOT NULL, 
    EstadoActivo BIT NOT NULL DEFAULT 1,
    Contrasena VARCHAR(100) NOT NULL,
    CorreoElectronico VARCHAR(100) NULL,
    CONSTRAINT PK_IdEmpleado PRIMARY KEY(IdEmpleado),
    CONSTRAINT UQ_DocumentoLegal UNIQUE (DocumentoLegal), 
    CONSTRAINT FK_Empleado_Cargo FOREIGN KEY(IdCargo) REFERENCES Cargo(IdCargo) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Empleado_Jefe FOREIGN KEY(IdJefe) REFERENCES Empleado(IdEmpleado) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE SolicitudDespido (
    IdSolicitud INT IDENTITY(1,1) NOT NULL,
    IdSolicitante VARCHAR(20) NOT NULL, -- El Analista que pide el despido
    IdEmpleadoADespedir VARCHAR(20) NOT NULL,
    IdNuevoJefeAsignado VARCHAR(20) NULL, -- A quién se le pasa el equipo
    MotivoDespido VARCHAR(500) NOT NULL,
    EstadoAprobacion VARCHAR(20) NOT NULL DEFAULT 'Pendiente', -- Pendiente, Aprobado, Denegado
    MotivoRechazo VARCHAR(500) NULL,
    FechaSolicitud DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_SolicitudDespido PRIMARY KEY (IdSolicitud),
    CONSTRAINT FK_Despido_Solicitante FOREIGN KEY (IdSolicitante) REFERENCES Empleado(IdEmpleado) ON DELETE NO ACTION,
    CONSTRAINT FK_Despido_Empleado FOREIGN KEY (IdEmpleadoADespedir) REFERENCES Empleado(IdEmpleado) ON DELETE NO ACTION
);
GO

CREATE TABLE HistorialSalarial(
    IdHistorial INT IDENTITY(1,1) NOT NULL,
    IdEmpleado VARCHAR(20) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    TipoModificacion VARCHAR(50) NOT NULL,
    FechaAplicacion DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_IdHistorial PRIMARY KEY(IdHistorial),
    CONSTRAINT FK_Historial_Empleado FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE BoletaPago(
    IdBoleta INT IDENTITY(1,1) NOT NULL,
    IdEmpleado VARCHAR(20) NOT NULL,
    MesCorrespondiente VARCHAR(30) NOT NULL,
    Salario DECIMAL(10,2) NOT NULL,
    Bonos DECIMAL(10,2) NOT NULL DEFAULT 0,
    Descuentos DECIMAL(10,2) NOT NULL DEFAULT 0,
    FechaEmision DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT PK_IdBoleta PRIMARY KEY(IdBoleta),
    CONSTRAINT FK_Boleta_Empleado FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Asistencia(
    LlaveHash VARCHAR(50) NOT NULL, 
    IdEmpleado VARCHAR(20) NOT NULL,
    Fecha DATE NOT NULL,
    HoraEntrada DATETIME NULL,
    HoraSalida DATETIME NULL,
    HorasTrabajadas DECIMAL(5,2) NULL,
    EstadoJornada VARCHAR(50) NOT NULL DEFAULT 'Incompleta', 
    CONSTRAINT PK_LlaveHash PRIMARY KEY(LlaveHash),
    CONSTRAINT FK_Asistencia_Empleado FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE SolicitudPermiso(
    IdSolicitud INT IDENTITY(1,1) NOT NULL,
    IdEmpleado VARCHAR(20) NOT NULL,
    TipoPermiso VARCHAR(50) NOT NULL,
    NivelPrioridad INT NOT NULL CHECK (NivelPrioridad BETWEEN 1 AND 5), 
    FechaSolicitud DATETIME NOT NULL DEFAULT GETDATE(),
    EstadoAprobacion VARCHAR(20) NOT NULL DEFAULT 'Pendiente', 
    CantidadTiempo INT NOT NULL DEFAULT 1,
    UnidadTiempo VARCHAR(10) NOT NULL DEFAULT 'Dias',
    MotivoDetallado VARCHAR(500) NOT NULL DEFAULT 'Sin especificar',
    RutaComprobante VARCHAR(500) NULL,     
    CONSTRAINT PK_IdSolicitud PRIMARY KEY(IdSolicitud),
    CONSTRAINT FK_Permiso_Empleado FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado) ON DELETE CASCADE ON UPDATE CASCADE
);
GO

-- ==============================================
-- 2. Inserción de Datos de Prueba (Mock Data)
-- ==============================================

INSERT INTO Cargo (NombreRol, NivelJerarquico, SalarioBase, BonoEscala1, BonoEscala2, BonoEscala3) 
VALUES 
('Director General', 1, 3500.00, 150.00, 300.00, 500.00),
('Analista de RRHH', 2, 900.00, 40.00, 80.00, 150.00),
('Empleado', 3, 600.00, 25.00, 50.00, 100.00);

-- Inserción del Director General (Raíz del Árbol)
INSERT INTO Empleado (IdEmpleado, IdCargo, IdJefe, NombreCompleto, DocumentoLegal, EstadoActivo, Contrasena, CorreoElectronico) 
VALUES 
('EMP-1', 1, NULL, 'Alejandro Alvarenga', '12345678-9', 1, 'director123', 'aalvarenga@empresa.com');

-- Inserción de Empleados
INSERT INTO Empleado (IdEmpleado, IdCargo, IdJefe, NombreCompleto, DocumentoLegal, EstadoActivo, Contrasena, CorreoElectronico) 
VALUES 
('EMP-2', 2, 'EMP-1', 'Roberto Sanchez', '23456789-0', 1, 'analista123', 'rsanchez@empresa.com'),
('EMP-3', 2, 'EMP-1', 'Maria Fernanda Lopez', '34567890-1', 1, 'analista123', 'mlopez@empresa.com'),
('EMP-4', 3, 'EMP-2', 'Carlos Martinez', '45678901-2', 1, 'empleado123', 'cmartinez@empresa.com'),
('EMP-5', 3, 'EMP-3', 'Lucia Gomez', '56789012-3', 1, 'empleado123', 'lgomez@empresa.com');

-- Historial Salarial
INSERT INTO HistorialSalarial (IdEmpleado, Monto, TipoModificacion, FechaAplicacion) 
VALUES 
('EMP-4', 1200.00, 'Ingreso Inicial', '2026-01-01'),
('EMP-4', 100.00, 'Bono Rendimiento', '2026-03-15');

-- Boletas de Pago
INSERT INTO BoletaPago (IdEmpleado, MesCorrespondiente, Salario, Bonos, Descuentos, FechaEmision)
VALUES 
('EMP-4', 'Marzo 2026', 1200.00, 100.00, 120.00, '2026-03-31'),
('EMP-5', 'Marzo 2026', 900.00, 0.00, 90.00, '2026-03-31');

-- Control de Asistencia
INSERT INTO Asistencia (LlaveHash, IdEmpleado, Fecha, HoraEntrada, HoraSalida, HorasTrabajadas, EstadoJornada) 
VALUES 
('45678901-2_20260331', 'EMP-4', '2026-03-31', '2026-03-31 08:00:00', '2026-03-31 17:00:00', 8.0, 'A Tiempo');

-- Solicitudes de Permisos
INSERT INTO SolicitudPermiso (IdEmpleado, TipoPermiso, NivelPrioridad, EstadoAprobacion, CantidadTiempo, UnidadTiempo, MotivoDetallado, RutaComprobante) 
VALUES 
('EMP-5', 'Vacaciones Anuales', 3, 'Pendiente', 5, 'Dias', 'Solicitud de vacaciones anuales correspondientes a ley para viaje familiar.', NULL),
('EMP-4', 'Incapacidad Medica', 1, 'Aprobado', 48, 'Horas', 'Incapacidad extendida por el ISSS debido a infección estomacal severa.', 'C:\Documentos\Incapacidad_ISSS_EMP4.pdf');
GO

-- ========================================================================================
-- 3. Cambios que se puedan llegar a realizar en la Base de Datos a futuro (Alter Table)
--    Una vez que realicen sus cambios, borren el alter table y corrijan la tabla original
-- ========================================================================================