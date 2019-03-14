USE BDprogramacionV
GO

delete from Pais;
delete from Provincia;
delete from Canton;
delete from Distrito;

DBCC CHECKIDENT ('[Pais]', RESEED, 0);
DBCC CHECKIDENT ('[Provincia]', RESEED, 0);
DBCC CHECKIDENT ('[Canton]', RESEED, 0);
DBCC CHECKIDENT ('[Distrito]', RESEED, 0);

insert into Pais values ('Costa Rica');
Insert into Provincia values('SAN JOSE', 1);
Insert into Canton values (1, 'SAN JOSE');
Insert into Distrito values (1, 1,'Carmen')
Insert into Distrito values (1, 1,'Merced')
Insert into Distrito values (1, 1,'Hospital')
Insert into Distrito values (1, 1,'Catedral')
Insert into Distrito values (1, 1,'Zapote')
Insert into Distrito values (1, 1,'San Francisco de Dos Ríos')
Insert into Distrito values (1, 1,'Uruca')
Insert into Distrito values (1, 1,'Mata Redonda')
Insert into Distrito values (1, 1,'Pavas')
Insert into Distrito values (1, 1,'Hatillo')
Insert into Distrito values (1, 1,'San Sebastián')
Insert into Canton values (1,'ESCAZU');
Insert into Distrito values (1,2,'Escazú')
Insert into Distrito values (1,2,'San Antonio')
Insert into Distrito values (1,2,'San Rafael')
Insert into Canton values (1,'DESAMPARADOS');
Insert into Distrito values (1,3,'Desamparados')
Insert into Distrito values (1,3,'San Miguel')
Insert into Distrito values (1,3,'San Juan de Dios')
Insert into Distrito values (1,3,'San Rafael Arriba')
Insert into Distrito values (1,3,'San Antonio')
Insert into Distrito values (1,3,'Frailes')
Insert into Distrito values (1,3,'Patarrá')
Insert into Distrito values (1,3,'San Cristóbal')
Insert into Distrito values (1,3,'Rosario')
Insert into Distrito values (1,3,'Damas')
Insert into Distrito values (1,3,'San Rafael Abajo')
Insert into Distrito values (1,3,'Gravilias')
Insert into Distrito values (1,3,'Los Guido')


Insert into Provincia values('HEREDIA', 1);
Insert into Canton values (2,' HEREDIA')
Insert into Distrito values (2, 4,'Heredia')
Insert into Distrito values (2, 4,'Mercedes')
Insert into Distrito values (2, 4,'San Francisco')
Insert into Distrito values (2, 4,'Ulloa')
Insert into Distrito values (2, 4,'Vara Blanca')
Insert into Canton values (2,' SANTO DOMINGO')
Insert into Distrito values (2, 5,'Santo Domingo')
Insert into Distrito values (2, 5,'San Vicente')
Insert into Distrito values (2, 5,'San Miguel')
Insert into Distrito values (2, 5,'Paracito')
Insert into Distrito values (2, 5,'Santo Tomás')
Insert into Distrito values (2, 5,'Santa Rosa')
Insert into Distrito values (2, 5,'Tures')
Insert into Distrito values (2, 5,'Pará')
Insert into Canton values (2,' SAN RAFAEL')
Insert into Distrito values (2, 6, 'San Rafael')
Insert into Distrito values (2, 6, 'San Josecito')
Insert into Distrito values (2, 6, 'Santiago')
Insert into Distrito values (2, 6, 'Angeles')
Insert into Distrito values (2, 6, 'Concepción')

Insert into Provincia values('CARTAGO', 1);
Insert into Canton values (3,' CARTAGO')
Insert into Distrito values (3, 7,'Oriental')
Insert into Distrito values (3, 7,'Occidental')
Insert into Distrito values (3, 7,'Carmen')
Insert into Distrito values (3, 7,'San Nicolás')
Insert into Distrito values (3, 7,'Aguacaliente  (San Francisco)')
Insert into Distrito values (3, 7,'Guadalupe  (Arenilla)')
Insert into Distrito values (3, 7,'Corralillo')
Insert into Distrito values (3, 7,'Tierra Blanca')
Insert into Distrito values (3, 7,'Dulce Nombre')
Insert into Distrito values (3, 7,'Llano Grande')
Insert into Distrito values (3, 7,'Quebradilla')
Insert into Canton values (3,' PARAISO')
Insert into Distrito values (3, 8, 'Paraíso')
Insert into Distrito values (3, 8, 'Santiago')
Insert into Distrito values (3, 8, 'Orosi')
Insert into Distrito values (3, 8, 'Cachí')
Insert into Distrito values (3, 8, 'Llanos de Sta Lucia')
Insert into Canton values (3, ' LA UNION')
Insert into Distrito values (3, 9, 'Tres Ríos')
Insert into Distrito values (3, 9, 'San Diego')
Insert into Distrito values (3, 9, 'San Juan')
Insert into Distrito values (3, 9, 'San Rafael')
Insert into Distrito values (3, 9, 'Concepción')
Insert into Distrito values (3, 9, 'Dulce Nombre')
Insert into Distrito values (3, 9, 'San Ramón')
Insert into Distrito values (3, 9, 'Río Azul')


Insert into Provincia values('ALAJUELA', 1);
Insert into Canton values (4,' ALAJUELA')
Insert into Distrito values (4, 10,'Alajuela')
Insert into Distrito values (4, 10,'San José')
Insert into Distrito values (4, 10,'Carrizal')
Insert into Distrito values (4, 10,'San Antonio')
Insert into Distrito values (4, 10,'Guácima')
Insert into Distrito values (4, 10,'San Isidro')
Insert into Distrito values (4, 10,'Sabanilla')
Insert into Distrito values (4, 10,'San Rafael')
Insert into Distrito values (4, 10,'Río Segundo')
Insert into Distrito values (4, 10,'Desamparados')
Insert into Distrito values (4, 10,'Turrucares')
Insert into Distrito values (4, 10,'Tambor')
Insert into Distrito values (4, 10,'La Garita')
Insert into Distrito values (4, 10,'Sarapiquí')
Insert into Canton values (4,' SAN RAMON')
Insert into Distrito values (4, 11,'San Ramón')
Insert into Distrito values (4, 11,'Santiago')
Insert into Distrito values (4, 11,'San Juan')
Insert into Distrito values (4, 11,'Piedades Norte')
Insert into Distrito values (4, 11,'Piedades Sur')
Insert into Distrito values (4, 11,'San Rafael')
Insert into Distrito values (4, 11,'San Isidro')
Insert into Distrito values (4, 11,'Angeles')
Insert into Distrito values (4, 11,'Alfaro')
Insert into Distrito values (4, 11,'Volio')
Insert into Distrito values (4, 11,'Concepción')
Insert into Distrito values (4, 11,'Zapotal')
Insert into Distrito values (4, 11,'San Isidro de Peñas Blancas')
Insert into Distrito values (4, 11,'San Lorenzo')
Insert into Canton values (4, '  GRECIA')
Insert into Distrito values (4, 12,'Grecia')
Insert into Distrito values (4, 12,'San Isidro')
Insert into Distrito values (4, 12,'San José')
Insert into Distrito values (4, 12,'San Roque')
Insert into Distrito values (4, 12,'Tacares')
Insert into Distrito values (4, 12,'Puente Piedra')
Insert into Distrito values (4, 12,'Bolívar')



Insert into Provincia values('LIMON', 1);
Insert into Canton values (5,' LIMON')
Insert into Distrito values (5, 13, 'Limón')
Insert into Distrito values (5, 13, 'Valle  La Estrella')
Insert into Distrito values (5, 13, 'Río Blanco')
Insert into Distrito values (5, 13, 'Matama')
Insert into Canton values (5, ' POCOCI')
Insert into Distrito values (5, 14, 'Guápiles')
Insert into Distrito values (5, 14,'Jiménez')
Insert into Distrito values (5, 14,'Rita')
Insert into Distrito values (5, 14,'Roxana')
Insert into Distrito values (5, 14,'Cariari')
Insert into Distrito values (5, 14,'Colorado')
Insert into Distrito values (5, 14,'La Colonia')
Insert into Canton values (5,' SIQUIRRES')
Insert into Distrito values (5, 15,'Siquirres')
Insert into Distrito values (5, 15,'Pacuarito')
Insert into Distrito values (5, 15,'Florida')
Insert into Distrito values (5, 15,'Germania')
Insert into Distrito values (5, 15,'Cairo')
Insert into Distrito values (5, 15,'Alegría')


Insert into Provincia values('GUANACASTE', 1);
Insert into Canton values (6, ' LIBERIA')
Insert into Distrito values (6, 16,'Liberia')
Insert into Distrito values (6, 16,'Cañas Dulces')
Insert into Distrito values (6, 16,'Mayorga')
Insert into Distrito values (6, 16,'Nacascolo')
Insert into Distrito values (6, 16,'Curubande')
Insert into Canton values (6, ' NICOYA')
Insert into Distrito values (6, 17,'Nicoya')
Insert into Distrito values (6, 17,'Mansión')
Insert into Distrito values (6, 17,'San Antonio')
Insert into Distrito values (6, 17,'Quebrada Honda')
Insert into Distrito values (6, 17,'Sámara')
Insert into Distrito values (6, 17,'Nosara')
Insert into Distrito values (6, 17,'Belén de Nosarita')
Insert into Canton values (6,' SANTA CRUZ')
Insert into Distrito values (6, 18,'Santa Cruz')
Insert into Distrito values (6, 18,'Bolsón')
Insert into Distrito values (6, 18,'Veintisiete de Abril')
Insert into Distrito values (6, 18,'Tempate')
Insert into Distrito values (6, 18,'Cartagena')
Insert into Distrito values (6, 18,'Cuajiniquil')
Insert into Distrito values (6, 18,'Diriá')
Insert into Distrito values (6, 18,'Cabo Velas')
Insert into Distrito values (6, 18,'Tamarindo')


Insert into Provincia values('PUNTARENAS', 1);
Insert into Canton values (7, ' PUNTARENAS')
Insert into Distrito values (7, 19,'Puntarenas')
Insert into Distrito values (7, 19,'Pitahaya')
Insert into Distrito values (7, 19,'Chomes')
Insert into Distrito values (7, 19,'Lepanto')
Insert into Distrito values (7, 19,'Paquera')
Insert into Distrito values (7, 19,'Manzanillo')
Insert into Distrito values (7, 19,'Guacimal')
Insert into Distrito values (7, 19,'Barranca')
Insert into Distrito values (7, 19,'Monte Verde')
Insert into Distrito values (7, 19,'Isla del Coco')
Insert into Distrito values (7, 19,'Cóbano')
Insert into Distrito values (7, 19,'Chacarita')
Insert into Distrito values (7, 19,'Chira (Isla)')
Insert into Distrito values (7, 19,'Acapulco')
Insert into Distrito values (7, 19,'El Roble')
Insert into Distrito values (7, 19,'Arancibia')
Insert into Canton values (7,' ESPARZA')
Insert into Distrito values (7, 20,'Espíritu Santo')
Insert into Distrito values (7, 20,'San Juan Grande')
Insert into Distrito values (7, 20,'Macacona')
Insert into Distrito values (7, 20,'San Rafael')
Insert into Distrito values (7, 20,'San Jerónimo')
Insert into Distrito values (7, 20,'Caldera')
Insert into Canton values (7,' BUENOS AIRES')
Insert into Distrito values (7, 21,'Buenos Aires')
Insert into Distrito values (7, 21,'Volcán')
Insert into Distrito values (7, 21,'Potrero Grande')
Insert into Distrito values (7, 21,'Boruca')
Insert into Distrito values (7, 21,'Pilas')
Insert into Distrito values (7, 21,'Colinas o Bajo de Maíz')
Insert into Distrito values (7, 21,'Chánguena')
Insert into Distrito values (7, 21,'Biolley')
Insert into Distrito values (7, 21,'Brunka')