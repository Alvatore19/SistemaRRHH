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
    CONSTRAINT PK_IdEmpleado PRIMARY KEY(IdEmpleado),
    CONSTRAINT UQ_DocumentoLegal UNIQUE (DocumentoLegal), 
    CONSTRAINT FK_Empleado_Cargo FOREIGN KEY(IdCargo) REFERENCES Cargo(IdCargo) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT FK_Empleado_Jefe FOREIGN KEY(IdJefe) REFERENCES Empleado(IdEmpleado) ON DELETE NO ACTION ON UPDATE NO ACTION
);

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

INSERT INTO Cargo (NombreRol, NivelJerarquico, SalarioBase) VALUES 
('Director General', 1, 3500.00),
('Gerente de TI', 2, 2000.00),
('Gerente de RRHH', 2, 1800.00),
('Desarrollador Backend', 3, 1200.00),
('Analista de RRHH', 3, 900.00);

INSERT INTO Empleado (IdEmpleado, IdCargo, IdJefe, NombreCompleto, DocumentoLegal, EstadoActivo, Contrasena) VALUES 
('EMP-1', 1, NULL, 'Alejandro Alvarenga', '12345678-9', 1, 'director123');

INSERT INTO Empleado (IdEmpleado, IdCargo, IdJefe, NombreCompleto, DocumentoLegal, EstadoActivo, Contrasena) VALUES 
('EMP-2', 2, 'EMP-1', 'Roberto Sanchez', '23456789-0', 1, 'gerente123'),
('EMP-3', 3, 'EMP-1', 'Maria Fernanda Lopez', '34567890-1', 1, 'analista123');

INSERT INTO Empleado (IdEmpleado, IdCargo, IdJefe, NombreCompleto, DocumentoLegal, EstadoActivo, Contrasena) VALUES 
('EMP-4', 4, 'EMP-2', 'Carlos Martinez', '45678901-2', 1, 'empleado123'),
('EMP-5', 5, 'EMP-3', 'Lucia Gomez', '56789012-3', 1, 'empleado123');

INSERT INTO HistorialSalarial (IdEmpleado, Monto, TipoModificacion, FechaAplicacion) VALUES 
('EMP-4', 1200.00, 'Ingreso Inicial', '2026-01-01'),
('EMP-4', 100.00, 'Bono Proyecto', '2026-03-15');

INSERT INTO Asistencia (LlaveHash, IdEmpleado, Fecha, HoraEntrada, HoraSalida, HorasTrabajadas, EstadoJornada) VALUES 
('45678901-2_20260331', 'EMP-4', '2026-03-31', '2026-03-31 08:00:00', '2026-03-31 17:00:00', 8.0, 'A Tiempo');

INSERT INTO SolicitudPermiso 
(IdEmpleado, TipoPermiso, NivelPrioridad, EstadoAprobacion, CantidadTiempo, UnidadTiempo, MotivoDetallado, RutaComprobante) 
VALUES 
('EMP-5', 'Vacaciones Anuales', 3, 'Pendiente', 5, 'Dias', 'Solicitud de vacaciones anuales correspondientes a ley para viaje familiar.', NULL),
('EMP-4', 'Incapacidad Medica', 1, 'Pendiente', 48, 'Horas', 'Incapacidad extendida por el ISSS debido a infección estomacal severa.', 'C:\Documentos\Incapacidad_ISSS_EMP4.pdf');
GO

-- ========================================================================================
-- 3. Cambios que se puedan llegar a realizar en la Base de Datos a futuro (Alter Table)
--    Una vez que realicen sus cambios, borren el alter table y corrijan la tabla original
-- ========================================================================================