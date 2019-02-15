/*Canton*/
ALTER TABLE [dbo].[Canton]  WITH CHECK ADD  CONSTRAINT [FK_Canton_Provincia] FOREIGN KEY([provinciaId])
REFERENCES [dbo].[Provincia] ([provinciaId])
GO

ALTER TABLE [dbo].[Canton] CHECK CONSTRAINT [FK_Canton_Provincia]
GO


/*Distrito*/

ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Distrito_Canton] FOREIGN KEY([cantonId])
REFERENCES [dbo].[Canton] ([cantonId])
GO

ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Distrito_Canton]
GO

ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Distrito_Provincia] FOREIGN KEY([provinciaId])
REFERENCES [dbo].[Provincia] ([provinciaId])
GO

ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Distrito_Provincia]
GO


/** Facturacion producto **/


ALTER TABLE [dbo].[facturacion_producto]  WITH CHECK ADD  CONSTRAINT [FK_facturacion_facturacion_producto] FOREIGN KEY([facturacionId])
REFERENCES [dbo].[facturaciones] ([facturacionId])
GO

ALTER TABLE [dbo].[facturacion_producto] CHECK CONSTRAINT [FK_facturacion_facturacion_producto]
GO

ALTER TABLE [dbo].[facturacion_producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_facturacion_producto] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO

ALTER TABLE [dbo].[facturacion_producto] CHECK CONSTRAINT [FK_producto_facturacion_producto]
GO

/** Formas de pago facturacion **/


ALTER TABLE [dbo].[formas_pago_facturacion]  WITH CHECK ADD  CONSTRAINT [FK_facturacion_formas_pago_facturacion] FOREIGN KEY([facturacionId])
REFERENCES [dbo].[facturaciones] ([facturacionId])
GO

ALTER TABLE [dbo].[formas_pago_facturacion] CHECK CONSTRAINT [FK_facturacion_formas_pago_facturacion]
GO


/*Genero Producto*/

ALTER TABLE [dbo].[genero_producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_genero_producto] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO

ALTER TABLE [dbo].[genero_producto] CHECK CONSTRAINT [FK_producto_genero_producto]
GO

/** Imagen Productos **/

ALTER TABLE [dbo].[imagen_producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_imagen_producto] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO

ALTER TABLE [dbo].[imagen_producto] CHECK CONSTRAINT [FK_producto_imagen_producto]
GO

/** Medida Producto **/

ALTER TABLE [dbo].[medida_producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_medida_producto] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO

ALTER TABLE [dbo].[medida_producto] CHECK CONSTRAINT [FK_producto_medida_producto]
GO


/** Productos **/


ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_categorias_productos] FOREIGN KEY([id_categoria])
REFERENCES [dbo].[categorias] ([id_categoria])
GO

ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_categorias_productos]
GO

ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_colecciones_productos] FOREIGN KEY([id_coleccion])
REFERENCES [dbo].[colecciones] ([id_coleccion])
GO

ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_colecciones_productos]
GO

ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_distribuidor_productos] FOREIGN KEY([id_distribuidor])
REFERENCES [dbo].[distribuidor] ([id_distribuidor])
GO

ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_distribuidor_productos]
GO

ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_marca_productos] FOREIGN KEY([id_marca])
REFERENCES [dbo].[marcas] ([id_marca])
GO

ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_marca_productos]
GO

/** Promociones Producto **/


ALTER TABLE [dbo].[promociones_productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_promociones_productos] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO

ALTER TABLE [dbo].[promociones_productos] CHECK CONSTRAINT [FK_productos_promociones_productos]
GO

ALTER TABLE [dbo].[promociones_productos]  WITH CHECK ADD  CONSTRAINT [FK_promociones_promociones_productos] FOREIGN KEY([promocionId])
REFERENCES [dbo].[promociones] ([promocionId])
GO

ALTER TABLE [dbo].[promociones_productos] CHECK CONSTRAINT [FK_promociones_promociones_productos]
GO

/** Provincia **/

ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Pais_Provincia] FOREIGN KEY([paisId])
REFERENCES [dbo].[Pais] ([paisId])
GO

ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_Pais_Provincia]
GO


/** Rol User**/


ALTER TABLE [dbo].[rol_user]  WITH CHECK ADD  CONSTRAINT [FK_ROL_ROLUSER] FOREIGN KEY([rolId])
REFERENCES [dbo].[rol] ([ROLID])
GO

ALTER TABLE [dbo].[rol_user] CHECK CONSTRAINT [FK_ROL_ROLUSER]
GO

ALTER TABLE [dbo].[rol_user]  WITH CHECK ADD  CONSTRAINT [FK_USER_ROLUSER] FOREIGN KEY([userId])
REFERENCES [dbo].[user] ([userId])
GO

ALTER TABLE [dbo].[rol_user] CHECK CONSTRAINT [FK_USER_ROLUSER]
GO

/** User **/


ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_Canton] FOREIGN KEY([cantonId])
REFERENCES [dbo].[Canton] ([cantonId])
GO

ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_Canton]
GO

ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_Distrito] FOREIGN KEY([distritoId])
REFERENCES [dbo].[Distrito] ([distritoId])
GO

ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_Distrito]
GO

ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_pais] FOREIGN KEY([paisId])
REFERENCES [dbo].[Pais] ([paisId])
GO

ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_pais]
GO

ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_Provincia] FOREIGN KEY([provinciaId])
REFERENCES [dbo].[Provincia] ([provinciaId])
GO

ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_Provincia]
GO

/** Usuario Facturacion**/


ALTER TABLE [dbo].[usuario_facturaciones]  WITH CHECK ADD  CONSTRAINT [FK_facturaciones_usuario_facturaciones] FOREIGN KEY([facturacionId])
REFERENCES [dbo].[facturaciones] ([facturacionId])
GO

ALTER TABLE [dbo].[usuario_facturaciones] CHECK CONSTRAINT [FK_facturaciones_usuario_facturaciones]
GO

ALTER TABLE [dbo].[usuario_facturaciones]  WITH CHECK ADD  CONSTRAINT [FK_user_usuario_facturaciones] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[user] ([userId])
GO

ALTER TABLE [dbo].[usuario_facturaciones] CHECK CONSTRAINT [FK_user_usuario_facturaciones]
GO


/** Usuario promocion**/


ALTER TABLE [dbo].[usuarios_promocion]  WITH CHECK ADD  CONSTRAINT [FK_promocion_usuarios_promocion] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[user] ([userId])
GO

ALTER TABLE [dbo].[usuarios_promocion] CHECK CONSTRAINT [FK_promocion_usuarios_promocion]
GO

ALTER TABLE [dbo].[usuarios_promocion]  WITH CHECK ADD  CONSTRAINT [FK_user_usuarios_promocion] FOREIGN KEY([promocionId])
REFERENCES [dbo].[promociones] ([promocionId])
GO

ALTER TABLE [dbo].[usuarios_promocion] CHECK CONSTRAINT [FK_user_usuarios_promocion]
GO