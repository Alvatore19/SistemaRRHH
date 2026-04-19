

SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS SolicitudPermiso;
DROP TABLE IF EXISTS Asistencia;
DROP TABLE IF EXISTS HistorialSalarial;
DROP TABLE IF EXISTS Empleado;
DROP TABLE IF EXISTS Cargo;

SET FOREIGN_KEY_CHECKS = 1;


CREATE TABLE Cargo(
    IdCargo INT AUTO_INCREMENT,
    NombreRol VARCHAR(100) NOT NULL,
    NivelJerarquico INT NOT NULL,
    SalarioBase DECIMAL(10,2) NOT NULL,
    PRIMARY KEY(IdCargo)
);


CREATE TABLE Empleado(
    IdEmpleado VARCHAR(20) NOT NULL,
    IdCargo INT NOT NULL,
    IdJefe VARCHAR(20),
    NombreCompleto VARCHAR(150) NOT NULL,
    DocumentoLegal VARCHAR(15) NOT NULL,
    Correo VARCHAR(150) NOT NULL,
    EstadoActivo BOOLEAN NOT NULL DEFAULT TRUE,
    Contrasena VARCHAR(100) NOT NULL,
    PRIMARY KEY(IdEmpleado),
    UNIQUE (DocumentoLegal),
    FOREIGN KEY(IdCargo) REFERENCES Cargo(IdCargo) ON DELETE CASCADE,
    FOREIGN KEY(IdJefe) REFERENCES Empleado(IdEmpleado)
);

CREATE TABLE HistorialSalarial(
    IdHistorial INT AUTO_INCREMENT,
    IdEmpleado VARCHAR(20) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    TipoModificacion VARCHAR(50) NOT NULL,
    FechaAplicacion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(IdHistorial),
    FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado) ON DELETE CASCADE
);

CREATE TABLE Asistencia(
    LlaveHash VARCHAR(50) NOT NULL,
    IdEmpleado VARCHAR(20) NOT NULL,
    Fecha DATE NOT NULL,
    HoraEntrada DATETIME,
    HoraSalida DATETIME,
    HorasTrabajadas DECIMAL(5,2),
    EstadoJornada VARCHAR(50) NOT NULL DEFAULT 'Incompleta',
    PRIMARY KEY(LlaveHash),
    FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado) ON DELETE CASCADE
);

CREATE TABLE SolicitudPermiso(
    IdSolicitud INT AUTO_INCREMENT,
    IdEmpleado VARCHAR(20) NOT NULL,
    TipoPermiso VARCHAR(50) NOT NULL,
    NivelPrioridad INT NOT NULL,
    FechaSolicitud DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    EstadoAprobacion VARCHAR(20) NOT NULL DEFAULT 'Pendiente',
    CantidadTiempo INT NOT NULL DEFAULT 1,
    UnidadTiempo VARCHAR(10) NOT NULL DEFAULT 'Dias',
    MotivoDetallado VARCHAR(500) NOT NULL,
    RutaComprobante VARCHAR(500),
    PRIMARY KEY(IdSolicitud),
    FOREIGN KEY(IdEmpleado) REFERENCES Empleado(IdEmpleado) ON DELETE CASCADE
);

-- ==============================================
-- 2. DATOS (CORREGIDOS CON INGRESO INICIAL)
-- ==============================================

-- Cargos
INSERT INTO Cargo (NombreRol, NivelJerarquico, SalarioBase) VALUES 
('Director General', 1, 3500.00),
('Gerente de TI', 2, 2000.00),
('Gerente de RRHH', 2, 1800.00),
('Desarrollador Backend', 3, 1200.00),
('Analista de RRHH', 3, 900.00);

-- Empleados
INSERT INTO Empleado VALUES 
('EMP-1', 1, NULL, 'Alejandro Alvarenga', '12345678-9', 'director@empresa.com', TRUE, 'director123'),
('EMP-2', 2, 'EMP-1', 'Roberto Sanchez', '23456789-0', 'roberto@empresa.com', TRUE, 'gerente123'),
('EMP-3', 3, 'EMP-1', 'Maria Fernanda Lopez', '34567890-1', 'maria@empresa.com', TRUE, 'analista123'),
('EMP-4', 4, 'EMP-2', 'Carlos Martinez', '45678901-2', 'carlos@empresa.com', TRUE, 'empleado123'),
('EMP-5', 5, 'EMP-3', 'Lucia Gomez', '56789012-3', 'lucia@empresa.com', TRUE, 'empleado123');

-- Historial Salarial (Todos con su registro obligatorio de 'Ingreso Inicial')
INSERT INTO HistorialSalarial (IdEmpleado, Monto, TipoModificacion, FechaAplicacion) VALUES 
('EMP-1', 3500.00, 'Ingreso Inicial', '2026-01-01'),
('EMP-2', 2000.00, 'Ingreso Inicial', '2026-01-01'),
('EMP-3', 1800.00, 'Ingreso Inicial', '2026-01-01'),
('EMP-4', 1200.00, 'Ingreso Inicial', '2026-01-01'),
('EMP-5', 900.00, 'Ingreso Inicial', '2026-01-01');

-- Asistencia
INSERT INTO Asistencia VALUES ('45678901-2_20260331', 'EMP-4', '2026-03-31', '2026-03-31 08:00:00', '2026-03-31 17:00:00', 8.0, 'A Tiempo');

-- Solicitudes
INSERT INTO SolicitudPermiso (IdEmpleado, TipoPermiso, NivelPrioridad, EstadoAprobacion, CantidadTiempo, UnidadTiempo, MotivoDetallado, RutaComprobante) VALUES 
('EMP-5', 'Vacaciones Anuales', 3, 'Pendiente', 5, 'Dias', 'Vacaciones familiares', NULL),
('EMP-4', 'Incapacidad Medica', 1, 'Pendiente', 48, 'Horas', 'Infección estomacal', 'C:/Documentos/Incapacidad.pdf');