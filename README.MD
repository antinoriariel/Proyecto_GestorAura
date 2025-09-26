# 🏥 Gestor Aura

Gestor Aura es un **sistema de gestión clínica** desarrollado en **C# (.NET / Windows Forms)** con base de datos en **SQL Server 2022**.  
Permite administrar usuarios, médicos, pacientes, turnos, historias clínicas y auditoría del sistema, con roles diferenciados:  
- 👨‍⚕️ **Médico**  
- 👩‍💼 **Secretaria**  
- 🛠️ **Administrador**

---

## 📂 Arquitectura del Proyecto

El sistema está organizado en **capas**:

- **CapaPresentacion** → Formularios de Windows Forms (UI).
- **CapaNegocio** → Lógica de negocio y validaciones.
- **CapaDatos** → Acceso a SQL Server mediante ADO.NET.

---

## 🗄️ Base de Datos: `proyecto_gestorAura`

Se utiliza **SQL Server 2022**. Las principales tablas son:

- **users** → credenciales y datos personales.
- **medicos** → datos adicionales de médicos (especialidad, matrículas).
- **pacientes** → información personal y médica.
- **turnos** → agenda de turnos médicos.
- **historias_clinicas** → evolución médica de pacientes.
- **signos_vitales** → registros clínicos vinculados a historias.

🔒 **Seguridad**:
- Contraseñas con **hash + salt (PBKDF2)**.
- Login **case-sensitive** (`Latin1_General_CS_AS`).
- Validaciones de unicidad (`username`, `email`, `dni`).
- Constraints en **fechas, teléfonos y roles válidos**.

---

## 🎨 Interfaz de Usuario

El sistema se organiza en torno a un **MDI Dashboard** que carga un **sidebar dinámico** según el rol del usuario:

### 🔹 Sidebars
- **AdminSidebar** → Inicio, Usuarios, Médicos, Pacientes, Turnos, Reportes, Auditoría, Backup, Configuración.
- **MedicoSidebar** → Inicio, Pacientes, Turnos, Historias Clínicas.
- **SecretariaSidebar** → Inicio, Pacientes, Turnos.

👉 Todos los sidebars heredan de **`SidebarBase`**, que define:
- Header con **usuario + rol + avatar**.
- Botones estilizados (colores hex, bordes redondeados, hover).
- Botón de **Cerrar Sesión** fijo al pie.

---

## 📑 Formularios Principales

- **Login** → autenticación con validación frontend + backend.
- **Dashboard** → contenedor MDI que carga formularios según los botones del sidebar.
- **FormCargaUsuarios** → alta de usuarios con validaciones (frontend + constraints SQL).
- **FormTurnos** → agenda de turnos con paciente, médico, fecha/hora, motivo y observaciones.
- **FormHC (Historias Clínicas)** → registro médico de pacientes.
- **FormPacientes** → gestión de pacientes.
- **FormInternados** → visualización de pacientes internados en cuadrícula.

---

## ✅ Validaciones (Frontend + Backend)

Ejemplo en **FormCargaUsuarios**:
- Username obligatorio, máx. 30 caracteres.
- Password obligatorio, mín. 6 caracteres.
- Email válido, máx. 50 caracteres.
- DNI con 8 dígitos.
- Teléfono opcional (7 a 20 caracteres, regex).
- Rol válido (`medico`, `secretaria`, `administrador`).
- Fecha de nacimiento no futura.

---

## 🚀 Ejecución

### Requisitos
- Visual Studio 2022
- .NET Framework 4.8 / .NET 6 (según configuración)
- SQL Server 2022

### Pasos
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/tuusuario/gestor-aura.git
   ```
2. Configurar la conexión a la base de datos en la capa de datos.
3. Ejecutar el script `db_proyecto_gestorAura.sql` para crear la base y tablas.
4. Compilar y ejecutar el proyecto en Visual Studio.

---

## 📊 Colores de Interfaz

Se usan tonos **teal/petróleo** y grises:

- Fondo sidebar: `#00565E`
- Botones base: `#27D9CF`
- Hover: `#1FA29C`
- Botón salir: `#F0331F`
- Header: `#293947`

---

## 📌 Estado Actual

- [x] Login con seguridad
- [x] Dashboard con MDI
- [x] Sidebars por rol
- [x] FormCargaUsuarios con validaciones
- [x] FormTurnos con agenda
- [x] Integración de pacientes / médicos
- [ ] Reportes avanzados
- [ ] Módulo de auditoría
- [ ] Backup automático

---

## 👨‍💻 Autores

Proyecto académico / profesional: **Gestor Aura**  
Desarrollado en **C# WinForms + SQL Server 2022**  
Con arquitectura en capas, validaciones y diseño moderno.

---

## 📜 Licencia

Este proyecto está bajo la licencia MIT.  
Puedes usarlo, modificarlo y distribuirlo con fines académicos o profesionales.
