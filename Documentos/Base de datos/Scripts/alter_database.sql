INSERT INTO Rol (NOMBRE, DESCRIPCION) VALUES ('Admin', 'Admin')
INSERT INTO Rol (NOMBRE, DESCRIPCION) VALUES ('Usuario', 'Usuario')
INSERT INTO Usuarios (nombre, apellidos, contrasena, correoElectronico)
VALUES ('Admin', 'Admin','Admin', 'Admin@correo.com')
INSERT INTO Usuarios (nombre, apellidos, contrasena, correoElectronico)
VALUES ('Usuario', 'Usuario','Usuario', 'Usuario@correo.com')

INSERT INTO rol_user (rolId, userId) VALUES (1, 1)
INSERT INTO rol_user (rolId, userId) VALUES (2, 2)

ALTER TABLE dbo.Usuarios ADD Usuario_ID NVARCHAR (128);

select * from productos;

INSERT INTO marcas (nombre, descripcion) VALUES ('Nike', 'Nike')

INSERT INTO productos (nombre, precio, descripcion, modelo, cantidad, id_marca)
VALUES ('Nike Mercurial', 1000, 'Nike Mercurial Vapor X', 'Mercurial', 10, 1)

select * from usuarios;