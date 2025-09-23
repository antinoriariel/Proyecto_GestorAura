-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'proyecto_gestorAura')
BEGIN
    CREATE DATABASE proyecto_gestorAura;
END
GO

USE proyecto_gestorAura;
GO

-- Tabla users
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='users' AND xtype='U')
BEGIN
    CREATE TABLE users (
        id_usuario INT NOT NULL IDENTITY(1,1),
        username VARCHAR(30) NOT NULL,
        password_hash VARBINARY(256) NOT NULL,
        password_salt VARBINARY(128) NOT NULL,
        email VARCHAR(50) NOT NULL,
        nombre VARCHAR(50) NOT NULL,
        apellido VARCHAR(50) NOT NULL,
        dni NUMERIC(8,0) NOT NULL,
        f_nacimiento DATE NOT NULL
            CONSTRAINT CHK_Users_FechaNacimiento CHECK (f_nacimiento <= GETDATE()),
        telefono VARCHAR(20)
            CONSTRAINT CHK_Users_Telefono CHECK (telefono NOT LIKE '%[^0-9+() -]%' AND LEN(telefono) BETWEEN 7 AND 20),
        created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
        modified_at DATETIME2 NULL,
        deleted_at DATETIME2 NULL,
        activo BIT NOT NULL DEFAULT 1,
        rol VARCHAR(20) NOT NULL
            CONSTRAINT CHK_Rol_Valido CHECK (rol IN ('medico', 'secretaria', 'administrador')),

        CONSTRAINT PK_ID_USUARIO PRIMARY KEY (id_usuario),
        CONSTRAINT UQ_email UNIQUE (email),
        CONSTRAINT UQ_username UNIQUE (username),
        CONSTRAINT UQ_dni UNIQUE (dni)
    );
END
GO

-- Tabla medicos
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='medicos' AND xtype='U')
BEGIN
    CREATE TABLE medicos (
        id_medico INT PRIMARY KEY IDENTITY(1,1),

        -- Relación 1:1 con users
        id_usuario INT NOT NULL UNIQUE,
        
        -- Datos profesionales
        especialidad VARCHAR(100) NOT NULL,
        matricula_provincial VARCHAR(50) NOT NULL,
        matricula_nacional VARCHAR(50) NULL,

        -- Auditoría
        created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
        modified_at DATETIME2 NULL,

        -- Relaciones
        CONSTRAINT FK_Medico_Usuario FOREIGN KEY (id_usuario)
            REFERENCES users(id_usuario)
            ON DELETE CASCADE
    );
END
GO

-- Tabla provincias
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='provincias' AND xtype='U')
BEGIN
    CREATE TABLE provincias (
        id_provincia INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL UNIQUE,
        codigo_iso VARCHAR(10) NULL
    );
END
GO

-- Tabla localidades
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='localidades' AND xtype='U')
BEGIN
    CREATE TABLE localidades (
        id_localidad INT PRIMARY KEY IDENTITY(1,1),
        nombre VARCHAR(100) NOT NULL,
        id_provincia INT NOT NULL,
        nombre_departamento VARCHAR(100) NULL,
        codigo_postal VARCHAR(20) NULL,

        CONSTRAINT FK_Localidad_Provincia FOREIGN KEY (id_provincia)
            REFERENCES provincias(id_provincia)
    );
END
GO

-- Tabla pacientes
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='pacientes' AND xtype='U')
BEGIN
    CREATE TABLE pacientes (
        id_paciente INT PRIMARY KEY IDENTITY(1,1),

        -- Datos personales
        nombre VARCHAR(50) NOT NULL,
        apellido VARCHAR(50) NOT NULL,
        dni NUMERIC(8,0) NOT NULL UNIQUE,
        sexo CHAR(1) NOT NULL CHECK (sexo IN ('H', 'M')),
        f_nacimiento DATE NOT NULL
            CONSTRAINT CHK_Pacientes_FechaNacimiento CHECK (f_nacimiento <= GETDATE()),

        -- Contacto
        telefono VARCHAR(20)
            CONSTRAINT CHK_Pacientes_Telefono CHECK (telefono NOT LIKE '%[^0-9+() -]%' AND LEN(telefono) BETWEEN 7 AND 20),
        email VARCHAR(100),
        direccion VARCHAR(100),
        id_localidad INT NULL,

        -- Información médica
        grupo_sanguineo VARCHAR(3) NULL CHECK (
            grupo_sanguineo IN ('A+','A-','B+','B-','AB+','AB-','O+','O-')
        ),
        alergias VARCHAR(MAX),

        -- Auditoría
        created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
        modified_at DATETIME2 NULL,
        deleted_at DATETIME2 NULL,

        -- Relaciones
        CONSTRAINT FK_Paciente_Localidad FOREIGN KEY (id_localidad)
            REFERENCES localidades(id_localidad)
            ON DELETE SET NULL
    );
END
GO

-- Tabla turnos
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='turnos' AND xtype='U')
BEGIN
    CREATE TABLE turnos (
        id_turno INT PRIMARY KEY IDENTITY(1,1),

        -- Datos del turno
        fecha_turno DATE NOT NULL,
        hora_turno TIME NOT NULL,

        -- Relaciones
        id_paciente INT NOT NULL,
        id_medico INT NOT NULL,
        id_usuario_creador INT NULL, -- ✅ ahora NULL para que funcione ON DELETE SET NULL

        -- Información adicional
        motivo VARCHAR(255) NULL,
        observaciones VARCHAR(MAX) NULL,
        estado VARCHAR(20) NOT NULL DEFAULT 'programado'
            CHECK (estado IN ('programado','confirmado','atendido','cancelado')),

        -- Auditoría
        created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
        modified_at DATETIME2 NULL,
        deleted_at DATETIME2 NULL,

        -- Relaciones
        CONSTRAINT FK_Turno_Paciente FOREIGN KEY (id_paciente)
            REFERENCES pacientes(id_paciente)
            ON DELETE CASCADE,
        CONSTRAINT FK_Turno_Medico FOREIGN KEY (id_medico)
            REFERENCES medicos(id_medico)
            ON DELETE CASCADE,
        CONSTRAINT FK_Turno_Usuario FOREIGN KEY (id_usuario_creador)
            REFERENCES users(id_usuario)
            ON DELETE NO ACTION
    );
END
GO


-- Tabla de historia clínica
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='historias_clinicas' AND xtype='U')
BEGIN
    CREATE TABLE historias_clinicas (
        id_hc INT PRIMARY KEY IDENTITY(1,1),

        -- Relaciones
        id_paciente INT NOT NULL,
        id_usuario INT NULL,  -- médico/usuario que generó la HC (NULL porque ON DELETE SET NULL)

        -- Contenido clínico
        mdc VARCHAR(MAX) NOT NULL,  
        antecedentes_patologicos VARCHAR(MAX) NULL,
        diagnostico VARCHAR(MAX) NULL,
        impresion_diagnostica VARCHAR(MAX) NOT NULL,
        evolucion VARCHAR(MAX) NULL,
        indicaciones VARCHAR(MAX) NULL,
        impresion_general VARCHAR(MAX) NULL,
        examenes_complementarios VARCHAR(255) NULL,
        tipo_consulta VARCHAR(30) NULL 
            CHECK (tipo_consulta IN ('guardia','consulta','control','internacion')),
        estado VARCHAR(20) NOT NULL DEFAULT 'abierta'
            CHECK (estado IN ('abierta','cerrada','archivada')),

        -- Auditoría
        fecha_hora DATETIME2 NOT NULL DEFAULT GETDATE(),
        created_at DATETIME2 NOT NULL DEFAULT GETDATE(),
        modified_at DATETIME2 NULL,
        deleted_at DATETIME2 NULL,

        -- Relaciones
        CONSTRAINT FK_HC_Paciente FOREIGN KEY (id_paciente)
            REFERENCES pacientes(id_paciente)
            ON DELETE CASCADE,
        CONSTRAINT FK_HC_Usuario FOREIGN KEY (id_usuario)
            REFERENCES users(id_usuario)
            ON DELETE SET NULL
    );
END
GO

-- Tabla de signos vitales
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='signos_vitales' AND xtype='U')
BEGIN
    CREATE TABLE signos_vitales (
        id_sv INT PRIMARY KEY IDENTITY(1,1),

        -- Relación con historia clínica
        id_hc INT NOT NULL,

        -- Datos de signos vitales
        fecha_hora DATETIME2 NOT NULL DEFAULT GETDATE(),
        temperatura DECIMAL(4,1) NOT NULL,   -- °C
        frecuencia_cardiaca INT NOT NULL,    -- lpm
        frecuencia_respiratoria INT NOT NULL,
        presion_arterial_sistolica INT NOT NULL,
        presion_arterial_diastolica INT NOT NULL,
        saturacion_oxigeno DECIMAL(5,2) NOT NULL, -- %SpO2
        escala_glasgow INT NULL,         -- escala neurológica
        peso DECIMAL(5,2) NULL,          -- kg
        talla DECIMAL(5,2) NULL,         -- m
        glucemia DECIMAL(6,2) NULL,      -- mg/dL

        -- Observaciones
        observaciones VARCHAR(MAX) NULL,

        -- Restricciones y relaciones
        CONSTRAINT FK_SV_HC FOREIGN KEY (id_hc)
            REFERENCES historias_clinicas(id_hc)
            ON DELETE CASCADE,
        CONSTRAINT CHK_SV_Temperatura CHECK (temperatura BETWEEN 25.0 AND 45.0),
        CONSTRAINT CHK_SV_FrecuenciaCardiaca CHECK (frecuencia_cardiaca BETWEEN 20 AND 250),
        CONSTRAINT CHK_SV_FrecuenciaRespiratoria CHECK (frecuencia_respiratoria BETWEEN 5 AND 80),
        CONSTRAINT CHK_SV_PresionSistolica CHECK (presion_arterial_sistolica BETWEEN 50 AND 300),
        CONSTRAINT CHK_SV_PresionDiastolica CHECK (presion_arterial_diastolica BETWEEN 30 AND 200),
        CONSTRAINT CHK_SV_Saturacion CHECK (saturacion_oxigeno BETWEEN 0 AND 99.99),
        CONSTRAINT CHK_SV_Glasgow CHECK (escala_glasgow BETWEEN 3 AND 15),
        CONSTRAINT CHK_SV_Peso CHECK (peso BETWEEN 0 AND 500),
        CONSTRAINT CHK_SV_Talla CHECK (talla BETWEEN 0.30 AND 2.50),
        CONSTRAINT CHK_SV_Glucemia CHECK (glucemia BETWEEN 10 AND 2000)
    );
END
GO

------------------------------------------------------------------------------------------------------------------
-- Usuarios basicos insert
INSERT INTO users (username,password_hash,password_salt,email,nombre,apellido,dni,f_nacimiento,telefono,created_at,activo,rol) VALUES (
    'admin',0xC2804C7D19E7D63F72DCD5FA53B56DE0EDD5CE12164AD813C1E4FD52F6010A07,0x650ED8353D8DF63924D2F4DB294FB26B,'admin@mail.com','Leonel','Alegre',11222333,'2000-01-01','3794001122','2025-09-22T16:07:34.050',1,'administrador');

INSERT INTO users (username,password_hash,password_salt,email,nombre,apellido,dni,f_nacimiento,telefono,created_at,activo,rol) VALUES (
    'antinori',0xC2804C7D19E7D63F72DCD5FA53B56DE0EDD5CE12164AD813C1E4FD52F6010A07,0x650ED8353D8DF63924D2F4DB294FB26B,'antinori@mail.com','Ariel','Antinori',11222334,'2000-01-01','3794001122','2025-09-22T16:07:34.050',1,'medico');

-- Provincias Insert
INSERT INTO provincias (nombre, codigo_iso) VALUES 
('Buenos Aires', 'AR-B'),
('Ciudad Autónoma de Buenos Aires', 'AR-C'),
('Catamarca', 'AR-K'),
('Chaco', 'AR-H'),
('Chubut', 'AR-U'),
('Córdoba', 'AR-X'),
('Corrientes', 'AR-W'),
('Entre Ríos', 'AR-E'),
('Formosa', 'AR-P'),
('Jujuy', 'AR-Y'),
('La Pampa', 'AR-L'),
('La Rioja', 'AR-F'),
('Mendoza', 'AR-M'),
('Misiones', 'AR-N'),
('Neuquén', 'AR-Q'),
('Río Negro', 'AR-R'),
('Salta', 'AR-A'),
('San Juan', 'AR-J'),
('San Luis', 'AR-D'),
('Santa Cruz', 'AR-Z'),
('Santa Fe', 'AR-S'),
('Santiago del Estero', 'AR-G'),
('Tierra del Fuego, Antártida e Islas del Atlántico Sur', 'AR-V'),
('Tucumán', 'AR-T');

-- Localidades de Corrientes (ejemplo)
-- Supongamos que “Corrientes” tiene id_provincia = X (de acuerdo al orden insertado; sería el 7º)
DECLARE @IdProvinciaCorrientes INT;
SELECT @IdProvinciaCorrientes = id_provincia FROM provincias WHERE nombre = 'Corrientes';

-- Localidades / Municipios de Corrientes
INSERT INTO localidades (nombre, id_provincia, nombre_departamento, codigo_postal) VALUES
('9 de Julio', @IdProvinciaCorrientes, 'San Roque', NULL),
('Alvear', @IdProvinciaCorrientes, 'General Alvear', NULL),
('Bella Vista', @IdProvinciaCorrientes, 'Bella Vista', NULL),
('Berón de Astrada', @IdProvinciaCorrientes, NULL, NULL),
('Bonpland', @IdProvinciaCorrientes, 'Paso de los Libres', NULL),
('Caá Catí', @IdProvinciaCorrientes, 'General Paz', NULL),
('Cazadores Correntinos', @IdProvinciaCorrientes, NULL, NULL),
('Cecilio Echeverría', @IdProvinciaCorrientes, NULL, NULL),
('Chavarría', @IdProvinciaCorrientes, NULL, NULL),
('Colonia Carolina', @IdProvinciaCorrientes, NULL, NULL),
('Colonia Carlos Pellegrini', @IdProvinciaCorrientes, NULL, NULL),
('Colonia Libertad', @IdProvinciaCorrientes, NULL, NULL),
('Colonia Liebig', @IdProvinciaCorrientes, NULL, NULL),
('Colonia Pando', @IdProvinciaCorrientes, NULL, NULL),
('Concepción del Yaguareté Corá', @IdProvinciaCorrientes, NULL, NULL),
('Corrientes', @IdProvinciaCorrientes, 'Capital', NULL),
('Cruz de los Milagros', @IdProvinciaCorrientes, NULL, NULL),
('Curuzú Cuatiá', @IdProvinciaCorrientes, 'Curuzú Cuatiá', NULL),
('El Sombrero', @IdProvinciaCorrientes, NULL, NULL),
('Empedrado', @IdProvinciaCorrientes, 'Empedrado', NULL),
('Esquina', @IdProvinciaCorrientes, 'Esquina', NULL),
('Felipe Yofre', @IdProvinciaCorrientes, NULL, NULL),
('Garabí', @IdProvinciaCorrientes, NULL, NULL),
('Garruchos', @IdProvinciaCorrientes, NULL, NULL),
('Gobernador Martínez', @IdProvinciaCorrientes, NULL, NULL),
('Gobernador Virasoro', @IdProvinciaCorrientes, NULL, NULL),
('Goya', @IdProvinciaCorrientes, 'Goya', NULL),
('Guaviraví', @IdProvinciaCorrientes, NULL, NULL),
('Herlitzka', @IdProvinciaCorrientes, NULL, NULL),
('Itá Ibaté', @IdProvinciaCorrientes, 'General Paz', NULL),
('Itatí', @IdProvinciaCorrientes, NULL, NULL),
('Ituzaingó', @IdProvinciaCorrientes, NULL, NULL),
('Juan Pujol', @IdProvinciaCorrientes, NULL, NULL),
('La Cruz', @IdProvinciaCorrientes, 'San Martín', NULL),
('Lavalle', @IdProvinciaCorrientes, 'Lavalle', NULL),
('Lomas de Vallejos', @IdProvinciaCorrientes, NULL, NULL),
('Loreto', @IdProvinciaCorrientes, 'San Miguel', NULL),
('Manuel Derqui', @IdProvinciaCorrientes, NULL, NULL),
('Mercedes', @IdProvinciaCorrientes, 'Mercedes', NULL),
('Mocoretá', @IdProvinciaCorrientes, 'Monte Caseros', NULL),
('Monte Caseros', @IdProvinciaCorrientes, 'Monte Caseros', NULL),
('Pago de los Deseos', @IdProvinciaCorrientes, NULL, NULL),
('Palmar Grande', @IdProvinciaCorrientes, NULL, NULL),
('Parada Pucheta', @IdProvinciaCorrientes, NULL, NULL),
('Paso de la Patria', @IdProvinciaCorrientes, 'Ituzaingó', NULL),
('Paso de los Libres', @IdProvinciaCorrientes, 'Paso de los Libres', NULL),
('Pedro R. Fernández', @IdProvinciaCorrientes, NULL, NULL),
('Perugorría', @IdProvinciaCorrientes, NULL, NULL),
('Pueblo Libertador', @IdProvinciaCorrientes, NULL, NULL),
('Ramada Paso', @IdProvinciaCorrientes, NULL, NULL),
('Riachuelo', @IdProvinciaCorrientes, NULL, NULL),
('Saladas', @IdProvinciaCorrientes, 'Saladas', NULL),
('San Antonio de Apipé', @IdProvinciaCorrientes, NULL, NULL),
('San Carlos', @IdProvinciaCorrientes, NULL, NULL),
('San Cosme', @IdProvinciaCorrientes, NULL, NULL),
('San Isidro', @IdProvinciaCorrientes, NULL, NULL),
('San Lorenzo', @IdProvinciaCorrientes, NULL, NULL),
('San Luis del Palmar', @IdProvinciaCorrientes, NULL, NULL),
('San Miguel', @IdProvinciaCorrientes, NULL, NULL),
('San Roque', @IdProvinciaCorrientes, NULL, NULL),
('Santa Ana de los Guácaras', @IdProvinciaCorrientes, NULL, NULL),
('Santa Lucía', @IdProvinciaCorrientes, NULL, NULL),
('Santa Rosa', @IdProvinciaCorrientes, NULL, NULL),
('Santo Tomé', @IdProvinciaCorrientes, 'Santo Tomé', NULL),
('Sauce', @IdProvinciaCorrientes, NULL, NULL),
('Tabay', @IdProvinciaCorrientes, NULL, NULL),
('Tapebicuá', @IdProvinciaCorrientes, NULL, NULL),
('Tatacuá', @IdProvinciaCorrientes, NULL, NULL),
('Torrent', @IdProvinciaCorrientes, NULL, NULL),
('Tres de Abril', @IdProvinciaCorrientes, NULL, NULL),
('Villa Olivari', @IdProvinciaCorrientes, NULL, NULL),
('Yapeyú', @IdProvinciaCorrientes, 'San Martín', NULL),
('Yataytí Calle', @IdProvinciaCorrientes, NULL, NULL);
GO
