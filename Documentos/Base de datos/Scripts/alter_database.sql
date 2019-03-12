INSERT INTO Rol (NOMBRE, DESCRIPCION) VALUES ('Admin', 'Admin')
INSERT INTO Rol (NOMBRE, DESCRIPCION) VALUES ('Usuario', 'Usuario')
INSERT INTO Usuarios (nombre, apellidos, contrasena, correoElectronico)
VALUES ('Admin', 'Admin','Admin', 'Admin')
INSERT INTO Usuarios (nombre, apellidos, contrasena, correoElectronico)
VALUES ('Usuario', 'Usuario','Usuario', 'Usuario')

INSERT INTO rol_user (rolId, userId) VALUES (1, 1)
INSERT INTO rol_user (rolId, userId) VALUES (2, 2)

ALTER TABLE dbo.Usuarios ADD Usuario_ID NVARCHAR (128);

