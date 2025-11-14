USE proyecto_gestorAura;
GO

SELECT * FROM users;

SELECT * FROM pacientes;

-- Lote de datos correspondiente a la tabla de Pacientes para probar como se ven los datos de los pacientes
-- en el formulario de formInternados.

INSERT INTO pacientes
    (nombre, apellido, dni, sexo, f_nacimiento, telefono, email, direccion,
     id_localidad, grupo_sanguineo, alergias, created_at)
VALUES
-- 1
('Juan', 'Pérez', '30123456', 'H', '1990-05-12', '3794550011',
 'juan.perez@gmail.com', 'Calle Belgrano 245', 1, 'A+', NULL, GETDATE()),

-- 2
('María', 'Gómez', '28987654', 'M', '1988-11-03', '3794123345',
 'maria.gomez@hotmail.com', 'San Martín 820', 2, 'B+', 'Penicilina', GETDATE()),

-- 3
('Pedro', 'Ruiz', '33222111', 'H', '1995-02-17', '3794332987',
 'pedro.ruiz@gmail.com', 'Av. Libertad 1500', 1, 'O-', NULL, GETDATE()),

-- 4
('Ana', 'Torres', '27888999', 'M', '1987-07-29', '3794557721',
 'ana.torres@yahoo.com', 'Lavalle 560', 3, 'AB+', 'Polen', GETDATE()),

-- 5
('Carlos', 'Díaz', '30111222', 'H', '1992-09-14', '3794678890',
 'carlos.diaz@gmail.com', 'Chile 415', 1, 'A-', NULL, GETDATE()),

-- 6
('Laura', 'Rivas', '35666111', 'M', '1999-03-21', '3794872901',
 'laura.rivas@gmail.com', 'Fray Rossi 230', 2, 'O+', 'Nueces', GETDATE()),

-- 7
('Sofía', 'Mendoza', '31233455', 'M', '1994-12-01', '3794231987',
 'sofia.mendoza@gmail.com', 'Güemes 980', 4, 'B-', NULL, GETDATE()),

-- 8
('Martín', 'López', '29877123', 'H', '1991-06-10', '3794115566',
 'martin.lopez@gmail.com', 'Catamarca 700', 3, 'A+', 'Ibuprofeno', GETDATE()),

-- 9
('Florencia', 'Cano', '32789012', 'M', '1996-10-25', '3794661209',
 'florencia.cano@gmail.com', 'Córdoba 312', 1, 'AB-', NULL, GETDATE()),

-- 10
('Joaquín', 'Ferreyra', '30199887', 'H', '1993-08-07', '3794550088',
 'joaquin.ferreyra@gmail.com', 'Entre Ríos 1021', 2, 'O+', NULL, GETDATE());
