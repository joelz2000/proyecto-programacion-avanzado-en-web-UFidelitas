
/**
*
*  Agregar Rol
*
**/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_agregarRol 
	-- Add the parameters for the stored procedure here
	@pNombre varchar(25),
	@pDescripcion text
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Rol(NOMBRE, DESCRIPCION) VALUES(@pNombre, @pDescripcion);
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

CREATE PROCEDURE sp_actualizarRol
	@pId int,
	@pNombre varchar(25),
	@pDescripcion text
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.rol 
	set NOMBRE = @pNombre, DESCRIPCION = @pDescripcion 
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

CREATE PROCEDURE sp_agregarUsuario
	@pNombre varchar(25),
	@pApellidos varchar(125),
	@pContrasena varchar(125),
	@pCorreoElectronico varchar(125),
	@pFechaNacimiento date,
	@pGenero varchar(20),
	@pFotoPerfil varchar(150),
	@telefono int,
	@direccion text,
	@pPaisId int,
	@pDistritoId int,
	@pProvinciaId int,
	@pCantonId int


AS
BEGIN
	INSERT INTO dbo.usuarios 
	VALUES(@pNombre,@pApellidos,@pContrasena,@pCorreoElectronico,@pFechaNacimiento,@pGenero, @pFotoPerfil, @telefono,@direccion,@pPaisId,@pDistritoId,@pProvinciaId, @pCantonId);
END
GO