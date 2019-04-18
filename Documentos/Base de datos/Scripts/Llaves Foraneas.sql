USE [BDprogramacionV]
GO
ALTER TABLE [dbo].[Canton]  WITH CHECK ADD  CONSTRAINT [FK_Canton_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[Canton] CHECK CONSTRAINT [FK_Canton_estados]
GO
ALTER TABLE [dbo].[Canton]  WITH CHECK ADD  CONSTRAINT [FK_Canton_Provincia] FOREIGN KEY([provinciaId])
REFERENCES [dbo].[Provincia] ([provinciaId])
GO
ALTER TABLE [dbo].[Canton] CHECK CONSTRAINT [FK_Canton_Provincia]
GO
ALTER TABLE [dbo].[categorias]  WITH CHECK ADD  CONSTRAINT [FK_categorias_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[categorias] CHECK CONSTRAINT [FK_categorias_estados]
GO
ALTER TABLE [dbo].[colecciones]  WITH CHECK ADD  CONSTRAINT [FK_colecciones_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[colecciones] CHECK CONSTRAINT [FK_colecciones_estados]
GO
ALTER TABLE [dbo].[distribuidor]  WITH CHECK ADD  CONSTRAINT [FK_distribuidor_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[distribuidor] CHECK CONSTRAINT [FK_distribuidor_estados]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Distrito_Canton] FOREIGN KEY([cantonId])
REFERENCES [dbo].[Canton] ([cantonId])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Distrito_Canton]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Distrito_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Distrito_estados]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [FK_Distrito_Provincia] FOREIGN KEY([provinciaId])
REFERENCES [dbo].[Provincia] ([provinciaId])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [FK_Distrito_Provincia]
GO
ALTER TABLE [dbo].[facturacion_producto]  WITH CHECK ADD  CONSTRAINT [FK_facturacion_facturacion_producto] FOREIGN KEY([facturacionId])
REFERENCES [dbo].[facturaciones] ([facturacionId])
GO
ALTER TABLE [dbo].[facturacion_producto] CHECK CONSTRAINT [FK_facturacion_facturacion_producto]
GO
ALTER TABLE [dbo].[facturacion_producto]  WITH CHECK ADD  CONSTRAINT [FK_facturacion_producto_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[facturacion_producto] CHECK CONSTRAINT [FK_facturacion_producto_estados]
GO
ALTER TABLE [dbo].[facturacion_producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_facturacion_producto] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO
ALTER TABLE [dbo].[facturacion_producto] CHECK CONSTRAINT [FK_producto_facturacion_producto]
GO
ALTER TABLE [dbo].[facturaciones]  WITH CHECK ADD  CONSTRAINT [FK_facturaciones_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[facturaciones] CHECK CONSTRAINT [FK_facturaciones_estados]
GO
ALTER TABLE [dbo].[formas_pago_facturacion]  WITH CHECK ADD  CONSTRAINT [FK_facturacion_formas_pago_facturacion] FOREIGN KEY([facturacionId])
REFERENCES [dbo].[facturaciones] ([facturacionId])
GO
ALTER TABLE [dbo].[formas_pago_facturacion] CHECK CONSTRAINT [FK_facturacion_formas_pago_facturacion]
GO
ALTER TABLE [dbo].[formas_pago_facturacion]  WITH CHECK ADD  CONSTRAINT [FK_formas_pago_facturacion_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[formas_pago_facturacion] CHECK CONSTRAINT [FK_formas_pago_facturacion_estados]
GO
ALTER TABLE [dbo].[genero_producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_genero_producto] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO
ALTER TABLE [dbo].[genero_producto] CHECK CONSTRAINT [FK_producto_genero_producto]
GO
ALTER TABLE [dbo].[imagen_producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_imagen_producto] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO
ALTER TABLE [dbo].[imagen_producto] CHECK CONSTRAINT [FK_producto_imagen_producto]
GO
ALTER TABLE [dbo].[marcas]  WITH CHECK ADD  CONSTRAINT [FK_marcas_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[marcas] CHECK CONSTRAINT [FK_marcas_estados]
GO
ALTER TABLE [dbo].[medida_producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_medida_producto] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO
ALTER TABLE [dbo].[medida_producto] CHECK CONSTRAINT [FK_producto_medida_producto]
GO
ALTER TABLE [dbo].[Pais]  WITH CHECK ADD  CONSTRAINT [FK_Pais_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[Pais] CHECK CONSTRAINT [FK_Pais_estados]
GO
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
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_estados]
GO
ALTER TABLE [dbo].[promociones]  WITH CHECK ADD  CONSTRAINT [FK_promociones_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[promociones] CHECK CONSTRAINT [FK_promociones_estados]
GO
ALTER TABLE [dbo].[promociones_productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_promociones_productos] FOREIGN KEY([productoId])
REFERENCES [dbo].[productos] ([productoId])
GO
ALTER TABLE [dbo].[promociones_productos] CHECK CONSTRAINT [FK_productos_promociones_productos]
GO
ALTER TABLE [dbo].[promociones_productos]  WITH CHECK ADD  CONSTRAINT [FK_promociones_productos_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[promociones_productos] CHECK CONSTRAINT [FK_promociones_productos_estados]
GO
ALTER TABLE [dbo].[promociones_productos]  WITH CHECK ADD  CONSTRAINT [FK_promociones_promociones_productos] FOREIGN KEY([promocionId])
REFERENCES [dbo].[promociones] ([promocionId])
GO
ALTER TABLE [dbo].[promociones_productos] CHECK CONSTRAINT [FK_promociones_promociones_productos]
GO
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Pais_Provincia] FOREIGN KEY([paisId])
REFERENCES [dbo].[Pais] ([paisId])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_Pais_Provincia]
GO
ALTER TABLE [dbo].[Provincia]  WITH CHECK ADD  CONSTRAINT [FK_Provincia_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[Provincia] CHECK CONSTRAINT [FK_Provincia_estados]
GO
ALTER TABLE [dbo].[rol]  WITH CHECK ADD  CONSTRAINT [FK_rol_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[rol] CHECK CONSTRAINT [FK_rol_estados]
GO
ALTER TABLE [dbo].[rol_user]  WITH CHECK ADD  CONSTRAINT [FK_ROL_ROLUSER] FOREIGN KEY([rolId])
REFERENCES [dbo].[rol] ([ROLID])
GO
ALTER TABLE [dbo].[rol_user] CHECK CONSTRAINT [FK_ROL_ROLUSER]
GO
ALTER TABLE [dbo].[rol_user]  WITH CHECK ADD  CONSTRAINT [FK_rol_user_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[rol_user] CHECK CONSTRAINT [FK_rol_user_estados]
GO
ALTER TABLE [dbo].[rol_user]  WITH CHECK ADD  CONSTRAINT [FK_rol_user_usuarios] FOREIGN KEY([userId])
REFERENCES [dbo].[usuarios] ([userId])
GO
ALTER TABLE [dbo].[rol_user] CHECK CONSTRAINT [FK_rol_user_usuarios]
GO
ALTER TABLE [dbo].[usuario_facturaciones]  WITH CHECK ADD  CONSTRAINT [FK_facturaciones_usuario_facturaciones] FOREIGN KEY([facturacionId])
REFERENCES [dbo].[facturaciones] ([facturacionId])
GO
ALTER TABLE [dbo].[usuario_facturaciones] CHECK CONSTRAINT [FK_facturaciones_usuario_facturaciones]
GO
ALTER TABLE [dbo].[usuario_facturaciones]  WITH CHECK ADD  CONSTRAINT [FK_usuario_facturaciones_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[usuario_facturaciones] CHECK CONSTRAINT [FK_usuario_facturaciones_estados]
GO
ALTER TABLE [dbo].[usuario_facturaciones]  WITH CHECK ADD  CONSTRAINT [FK_usuario_facturaciones_usuarios] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[usuarios] ([userId])
GO
ALTER TABLE [dbo].[usuario_facturaciones] CHECK CONSTRAINT [FK_usuario_facturaciones_usuarios]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_Canton] FOREIGN KEY([cantonId])
REFERENCES [dbo].[Canton] ([cantonId])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_Canton]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_Distrito] FOREIGN KEY([distritoId])
REFERENCES [dbo].[Distrito] ([distritoId])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_Distrito]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_estados]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_Pais] FOREIGN KEY([paisId])
REFERENCES [dbo].[Pais] ([paisId])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_Pais]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_Provincia] FOREIGN KEY([provinciaId])
REFERENCES [dbo].[Provincia] ([provinciaId])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_Provincia]
GO
ALTER TABLE [dbo].[usuarios_promocion]  WITH CHECK ADD  CONSTRAINT [FK_user_usuarios_promocion] FOREIGN KEY([promocionId])
REFERENCES [dbo].[promociones] ([promocionId])
GO
ALTER TABLE [dbo].[usuarios_promocion] CHECK CONSTRAINT [FK_user_usuarios_promocion]
GO
ALTER TABLE [dbo].[usuarios_promocion]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_promocion_estados] FOREIGN KEY([id_estado])
REFERENCES [dbo].[estados] ([id_estado])
GO
ALTER TABLE [dbo].[usuarios_promocion] CHECK CONSTRAINT [FK_usuarios_promocion_estados]
GO
ALTER TABLE [dbo].[usuarios_promocion]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_promocion_usuarios] FOREIGN KEY([usuarioId])
REFERENCES [dbo].[usuarios] ([userId])
GO
ALTER TABLE [dbo].[usuarios_promocion] CHECK CONSTRAINT [FK_usuarios_promocion_usuarios]
GO

