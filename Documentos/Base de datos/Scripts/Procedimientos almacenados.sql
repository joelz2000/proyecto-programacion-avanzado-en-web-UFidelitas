
/**
*
*  Agregar Rol
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE or alter PROCEDURE sp_agregarRol 
	-- Add the parameters for the stored procedure here
	@pNombre varchar(25),
	@pDescripcion text,
	@pEstadoId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Rol(NOMBRE, DESCRIPCION, id_estado) VALUES(@pNombre, @pDescripcion, @pEstadoId);
END
GO



/**
*
*  obtener Roles 
*
**/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerRoles
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.rol;
END
GO


/**
*
*  obtener Rol Id 
*
**/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerRolId
	@pId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.rol where ROLID = @pId;
END
GO


/**
*
*  actualizar Rol 
*
**/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE or alter PROCEDURE sp_actualizarRol
	@pId int,
	@pNombre varchar(25),
	@pDescripcion text,
	@pEstadoId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.rol 
	set NOMBRE = @pNombre, DESCRIPCION = @pDescripcion, id_estado = @pEstadoId
	WHERE ROLID = @pId;
END
GO

/**
*
*  Eliminar Rol 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_deleteRol 
	@pRolId int
AS
BEGIN
	UPDATE rol_user SET rolId = 1 where rolId = @pRolId;
	DELETE FROM ROL WHERE ROLID = @pRolId; 
END
GO

/**
*
*  Agregar Usuario 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE or alter PROCEDURE sp_agregarUsuario
	@pNombre varchar(25),
	@pApellidos varchar(125),
	@pContrasena varchar(125),
	@pCorreoElectronico varchar(125),
	@pFechaNacimiento date,
	@pGenero varchar(20),
	@pFotoPerfil varchar(150),
	@pTelefono int,
	@pDireccion text,
	@pPaisId int,
	@pDistritoId int,
	@pProvinciaId int,
	@pCantonId int,
	@pUsuario_ID nvarchar(128),
	@pEstadoId int


AS
BEGIN
	INSERT INTO dbo.usuarios 
	VALUES(@pNombre,@pApellidos,@pContrasena,@pCorreoElectronico,@pFechaNacimiento,@pGenero, @pFotoPerfil, @pTelefono,@pDireccion,@pPaisId,@pDistritoId,@pProvinciaId, @pCantonId, @pUsuario_ID, @pEstadoId);
END
GO

/**
*
*  Obtener Usuarios 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerUsuarios
AS
BEGIN
	SELECT * FROM dbo.usuarios;
END
GO

/**
*
*  Obtener Usuarios con Id
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerUsuariosId
	@pUsuarioId int
AS
BEGIN
	SELECT * FROM dbo.usuarios where userId = @pUsuarioId;
END
GO

/**
*
*  Actualizar Usuario
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE or alter PROCEDURE sp_actualizarUsuario
	@pUsuarioId int,
	@pNombre varchar(25),
	@pApellidos varchar(125),
	@pContrasena varchar(125),
	@pCorreoElectronico varchar(125),
	@pFechaNacimiento date,
	@pGenero varchar(20),
	@pFotoPerfil varchar(150),
	@pTelefono int,
	@pDireccion text,
	@pPaisId int,
	@pDistritoId int,
	@pProvinciaId int,
	@pCantonId int,
	@pUsuario_ID nvarchar(128),
	@pIdEstado int
AS
BEGIN


	UPDATE dbo.usuarios 
	set nombre = @pNombre, apellidos = @pApellidos, contrasena = @pContrasena, correoElectronico = @pCorreoElectronico, fechaNacimiento = @pFechaNacimiento, genero = @pGenero, fotoPerfil = @pFotoPerfil, telefono = @pTelefono, direccion = @pDireccion, paisId = @pPaisId, distritoId = @pDistritoId, provinciaId = @pProvinciaId, cantonId = @pCantonId, Usuario_ID = @pUsuario_ID, id_estado = @pIdEstado
	WHERE userId = @pUsuarioId;

END
GO


/**
*
*  Eliminar Usuario
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_eliminarUsuario 
	@pUserId int
AS
BEGIN
	
	DELETE FROM usuarios WHERE userId = @pUserId; 

	DELETE FROM rol_user WHERE userId = @pUserId;

	DELETE FROM usuario_facturaciones WHERE usuarioId = @pUserId;

	DELETE FROM usuarios_promocion WHERE usuarioId = @pUserId;



END
GO



/**
*
*  Agregar ROL USER
*
**/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE or alter PROCEDURE sp_agregarRolUser
	@pRolId int,
	@pUserId int,
	@pEstadoId int
	
AS
BEGIN
	
	INSERT INTO dbo.rol_user(rolId, userId, id_estado) VALUES (@pRolId, @pUserId, @pEstadoId);

END
GO


/**
*
*  Obtener ROL USER
*
**/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_ObtenerRolesUser
	
AS
BEGIN
	
	SELECT ru.rolId, ru.userId, r.NOMBRE as Rol, u.nombre AS Usuario from dbo.rol_user ru 
	inner join dbo.rol r on r.ROLID = ru.rolId
	inner join dbo.usuarios u on ru.userId = u.userId ;

END
GO

/**
*
*  Obtener ROL USER by id
*
**/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerRolUserId

	@idUser int
AS
BEGIN
	SELECT ru.rolId, r.NOMBRE as Rol,ru.userId, u.nombre AS Usuario from dbo.rol_user ru 
	inner join dbo.rol r on r.ROLID = ru.rolId
	inner join dbo.usuarios u on ru.userId = u.userId 
	where ru.userId = @idUser;

END
GO


/**
*
*  Actualizar ROL USER
*
**/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE or alter  PROCEDURE sp_actualizarRolesUser
	@idRolOriginal int,
	@idUser int,
	@idRolNueva int,
	@pEstadoId int
AS
BEGIN
	
	UPDATE dbo.rol_user SET rolId = @idRolNueva, id_estado = @pEstadoId 
	WHERE rolId = @idRolOriginal and userId = @idUser;

END
GO



/**
*
*  Agregar FACTURACION
*
**/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE or alter PROCEDURE [dbo].[sp_agregarFacturacion]
	@pNombre varchar(250),
	@pfecha date,
	@pDescripcion text,
	@pImpuesto int,
	@pTipo varchar(25),
	@pEstadoId int
	/*@pCantidad int,
	@pProductId int,
	@pUsuario int*/
AS

 /*DECLARE @ultimaFacturacion int;
 DECLARE @pSubtotal float;
 DECLARE @pTotal float;
 DECLARE @impuestoConvertido float;*/
BEGIN
	 
	/* SET @pTotal = (SELECT (precio * @pCantidad) FROM productos WHERE productoId = @pProductId);
	 set @impuestoConvertido = CAST(@pImpuesto AS FLOAT) /   CAST(100 AS FLOAT)
	 SET @pSubtotal = ((@pTotal * @impuestoConvertido) + @pTotal );*/
	 
	INSERT INTO dbo.facturaciones(nombre,fecha, descripcion, impuesto, subtotal, total, tipo, id_estado)
	VALUES(@pNombre, @pfecha, @pDescripcion, @pImpuesto, null, null, @pTipo, @pEstadoId);

	/*
	SET @ultimaFacturacion = (select max(facturacionId) from dbo.facturaciones);

	INSERT INTO dbo.facturacion_producto(facturacionId,productoId,cantidad)
	VALUES(@ultimaFacturacion, @pProductId, @pCantidad);

	INSERT INTO dbo.usuario_facturaciones(usuarioId, facturacionId)
	VALUES(@pUsuario, @ultimaFacturacion);

	update dbo.productos set cantidad = (cantidad - @pCantidad ) where productoId = @pProductId;*/
END

/**
*
*  actualizar FACTURACION
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create or alter PROCEDURE [dbo].[sp_actualizarFacturacion]
	@pIdFacturacion int,
	@pNombre varchar(250),
	@pfecha date,
	@pDescripcion text,
	@pImpuesto int,
	@pTipo varchar(25),
	@pEstadoId int
AS


 DECLARE @pSubtotal float;
 DECLARE @pTotal float;
 DECLARE @impuestoConvertido float;
 DECLARE @precio float;
BEGIN
	
	
		
	 SET @pTotal = (SELECT sum(p.precio * fp.cantidad) FROM dbo.productos p
					inner join dbo.facturacion_producto fp on p.productoId=fp.productoId
					where facturacionId = @pIdFacturacion);

	 SET @impuestoConvertido = CAST(@pImpuesto AS FLOAT) /   CAST(100 AS FLOAT)
	 
	 SET @pSubtotal = ((@pTotal * @impuestoConvertido) + @pTotal );
	 
	
	UPDATE dbo.facturaciones 
	SET  
	nombre = @pNombre, 
	fecha= @pfecha, 
	descripcion = @pDescripcion,
	impuesto = @pImpuesto,
	subtotal = @pSubtotal,
	total = @pTotal,
	tipo = @pTipo,
	id_estado = @pEstadoId
	WHERE facturacionId = @pIdFacturacion;

END



/**
*
*  Obtener FACTURACIONES
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerFacturaciones
AS
BEGIN
	SELECT * FROM dbo.facturaciones;
END
GO

/**
*
*  Obtener FACTURACION por id
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerFacturacionId
	@pId int
AS
BEGIN
	SELECT * FROM dbo.facturaciones where facturacionId = @pId;
END
GO


/**
*
*  eliminar FACTURACION 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_eliminarFacturaciones
	@pIdFacturacion int
AS
BEGIN
	delete from dbo.facturaciones where facturacionId = @pIdFacturacion;
END
GO

/**
*
*  agregar facturacionProductos
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create or alter PROCEDURE [dbo].[sp_agregarFacturacionProducto]
	
	@pFacturacionId int,
	@pProductoId int,
	@pCantidad int,
	@pEstadoId int
	
AS
DECLARE @pSubtotal float;
 DECLARE @pTotal float;
 DECLARE @impuestoConvertido float;
 DECLARE @precio float;
 DECLARE @pImpuesto int;
BEGIN

	INSERT INTO dbo.facturacion_producto(productoId,facturacionId, cantidad, id_estado)
	VALUES(@pProductoId, @pFacturacionId, @pCantidad, @pEstadoId);

	update dbo.productos set cantidad = (cantidad - @pCantidad) 
	where productoId =  @pProductoId;

	SET @pTotal = (SELECT sum(p.precio * fp.cantidad) FROM dbo.productos p
					inner join dbo.facturacion_producto fp on p.productoId=fp.productoId
					where facturacionId = @pFacturacionId);

	 set @pImpuesto = (select  impuesto from dbo.facturaciones where facturacionId = @pFacturacionId);

	 SET @impuestoConvertido = CAST(@pImpuesto AS FLOAT) /   CAST(100 AS FLOAT)
	 
	 SET @pSubtotal = ((@pTotal * @impuestoConvertido) + @pTotal );
	 
	
	UPDATE dbo.facturaciones 
	SET  
	impuesto = @pImpuesto,
	subtotal = @pSubtotal,
	total = @pTotal
	WHERE facturacionId = @pFacturacionId;

END

/**
*
*  actualizar FACTURACION por PRODUCTO 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE or alter PROCEDURE sp_actualizarFacturacionesProducto
	@pIdProducto int,
	@pIdFacturacion int,
	@cantidad int,
	@pEstadoId int
AS
BEGIN
	update dbo.facturacion_producto
	set 
	productoId = @pIdProducto,
	cantidad = @cantidad,
	id_estado = @pEstadoId
	where 
	facturacionId = @pIdFacturacion and productoId = @pIdProducto;
END
GO
/**
*
*  Obtener FACTURACION por PRODUCTO 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerFacturacionesProducto
	
AS
BEGIN
	SELECT f.facturacionId, f.nombre, p.productoId, p.nombre FROM dbo.facturacion_producto fp 
	inner join dbo.productos p on fp.productoId = p.productoId
	inner join dbo.facturaciones f on f.facturacionId = fp.facturacionId;
END
GO


/**
*
*  Obtener FACTURACION por Usuario 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerFacturacionesUsuario
AS
BEGIN
	select f.facturacionId, f.nombre, u.userId, u.nombre from dbo.usuario_facturaciones uf
	inner join dbo.usuarios u on u.userId = uf.usuarioId
	inner join dbo.facturaciones f on f.facturacionId = uf.facturacionId
END
GO



/**
*
*  Obtener una imagen de Productos 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerImagenProducto
	@pIdProducto int,
	@pImagen varchar(150)
AS
BEGIN
	select * from dbo.imagen_producto 
	where productoId = @pIdProducto and IMAGEN = @pImagen; 
END
GO

/**
*
*  Obtener una imagenes de Productos con id 
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_obtenerImagenesProductoId
	@pIdProducto int
AS
BEGIN
	select * from dbo.imagen_producto 
	where productoId = @pIdProducto; 
END
GO

/**
*
*  Eliminar un PromocionProducto
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create or ALTER PROCEDURE [dbo].[sp_eliminarPromocionProducto]
	@pPromocionId int,
	@pProductoId int
AS
BEGIN
	
	delete from promociones_productos 
	where	productoId = @pProductoId AND
			promocionId = @pPromocionId;



END


/**
*
*  Eliminar una Promocion Usuario
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create or ALTER PROCEDURE [dbo].[sp_eliminarUsuarioPromocion]
	@pUsuarioId int,
	@pPromocionId int
AS
BEGIN
	
	delete from usuarios_promocion 
	where	usuarioId = @pUsuarioId AND
			promocionId = @pPromocionId;



END

/**
*
*  Obtener Facturaciones productos by idFacturacion
**/


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create or ALTER PROCEDURE [dbo].[sp_obtenerFacturacionProductoByIdFacturacion]
	@pFacturacionId int
AS
BEGIN
	
	select f.facturacionId, f.nombre, p.productoId, p.nombre, fp.cantidad, p.precio
	 from dbo.facturacion_producto fp
	inner join dbo.productos p on fp.productoId = p.productoId
	inner join dbo.facturaciones f on f.facturacionId = fp.facturacionId
	where fp.facturacionId = @pFacturacionId;



END