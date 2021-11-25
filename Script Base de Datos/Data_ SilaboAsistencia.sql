USE BDSistemaGestion
GO

-- Escuela Profesional:
insert into TEscuelaProfesional VALUES('IN','INGENIERÍA INFORMÁTICA Y DE SISTEMAS');
insert into TEscuelaProfesional VALUES('LI','INGENIERÍA ELECTRÓNICA');
insert into TEscuelaProfesional VALUES('CI','INGENIERÍA CIVIL');
insert into TEscuelaProfesional VALUES('CO','CONTABILIDAD');
insert into TEscuelaProfesional VALUES('PS','PSICOLOGÍA');
insert into TEscuelaProfesional VALUES('QI','INGENIERÍA QUÍMICA');
GO

-- Departamento Académico:
insert into TDepartamentoAcademico VALUES('IF','INGENIERÍA INFORMÁTICA');
insert into TDepartamentoAcademico VALUES('EL','INGENIERÍA ELECTRÓNICA');
insert into TDepartamentoAcademico VALUES('IC','INGENIERÍA CIVIL');
insert into TDepartamentoAcademico VALUES('CO','CONTABILIDAD');
insert into TDepartamentoAcademico VALUES('FP','FILOSOFIA Y PSICOLOGÍA');
insert into TDepartamentoAcademico VALUES('IQ','INGENIERÍA QUÍMICA');
GO

-- Estudiantes:
EXEC DBO.spuInsertarEstudiante NULL,'170115','PAZ','GUERRA','ANA','170115@unsaac.edu.pe','AV. TUPAC AMARU 23','954345698','IN'
EXEC DBO.spuInsertarEstudiante NULL,'170225','ARCE','ANDIA','ANGEL','170225@unsaac.edu.pe','CALLE URCOS 32','934675322','IN'
EXEC DBO.spuInsertarEstudiante NULL,'171347','BUENO','BUENDIA','BENITO','171347@unsaac.edu.pe','JR. LINERTAD 4','956784320','IN'
EXEC DBO.spuInsertarEstudiante NULL,'170231','CUSI','COSIO','CARLOTA','170231@unsaac.edu.pe','AV COSTANERA 34','945389056','IN'
EXEC DBO.spuInsertarEstudiante NULL,'171121','DUEÑAS','DAVILA','DAVID','171121@unsaac.edu.pe','JR. CALCA 57','945389056','IN'
EXEC DBO.spuInsertarEstudiante NULL,'170335','ESCOBAR','ESTRADA','ERNESTO','170335@unsaac.edu.pe','AV. SOL 73','945389056','IN'
EXEC DBO.spuInsertarEstudiante NULL,'170255','FARFAN','FLORES','FABIOLA','170255@unsaac.edu.pe','AV INDUSTRIAL 423','990987896','IN'
EXEC DBO.spuInsertarEstudiante NULL,'181371','GARCIA','GUDIEL','GABRIELA','181371@unsaac.edu.pe','CALLE COMERCIO 76','954325644','IN'
EXEC DBO.spuInsertarEstudiante NULL,'180219','HURTADO','HUILLCA','HUMBERTO','180219@unsaac.edu.pe','JR. TARAPACA 88','989097786','IN'
EXEC DBO.spuInsertarEstudiante NULL,'181227','IBARRA','IBAÑEZ','INES','181227@unsaac.edu.pe','CALLE LIMA 21','923432232','IN'
EXEC DBO.spuInsertarEstudiante NULL,'180116','JIMENEZ','JARAMILLO','JULIO','180116@unsaac.edu.pe','AV. SUIZA 42','951234323','IN'
EXEC DBO.spuInsertarEstudiante NULL,'180277','KAWAMURA','KAWAMURA','KEVIN','180277@unsaac.edu.pe','AV. SANTIAGO 67','955454533','IN'
EXEC DBO.spuInsertarEstudiante NULL,'181197','LOZA','LUZA','LILIANA','181197@unsaac.edu.pe','AV. LOSSAUCES 78','965678212','IN'
EXEC DBO.spuInsertarEstudiante NULL,'180919','MEZA','MAR','MARISOL','190919@unsaac.edu.pe','AV. SOL 67','954343698','IN'
EXEC DBO.spuInsertarEstudiante NULL,'191447','NUÑEZ','NAVIA','NOHEMI','191447@unsaac.edu.pe','CALLE QUISPICANCHIS 32','956432122','IN'
EXEC DBO.spuInsertarEstudiante NULL,'190366','ORTEGA','OCAMPO','OMAR','190366@unsaac.edu.pe','CALLE ESPAÑA 143','987653320','IN'
EXEC DBO.spuInsertarEstudiante NULL,'190788','PRADO','PERALTA','PABLO','190788@unsaac.edu.pe','CALLE SUAREZ 63','999875511','IN'
EXEC DBO.spuInsertarEstudiante NULL,'191779','RAMOS','ROBLES','ROSA','191779@unsaac.edu.pe','AV. UNION 55','984323456','IN'
EXEC DBO.spuInsertarEstudiante NULL,'190998','SALAZAR','SALAS','SOFIA','190998@unsaac.edu.pe','AV. ALMAGRO 341','921234556','IN'
EXEC DBO.spuInsertarEstudiante NULL,'191876','TORRES','TARRAGA','TOMAS','191876@unsaac.edu.pe','AV SOL 24','967890345','IN'
EXEC DBO.spuInsertarEstudiante NULL,'193402','GARCIA','OLIVERA','ALEJANDRO','193402@unsaac.edu.pe','CALLE HOSPITAL 19','954345665','IN'
EXEC DBO.spuInsertarEstudiante NULL,'203413','MENDOZA','QUISPE','MARIA','203413@unsaac.edu.pe','AV. ALMUDENA 67','965432245','IN'
EXEC DBO.spuInsertarEstudiante NULL,'202700','PEÑA','AYALA','JOSE LUIS','202700@unsaac.edu.pe','AV. LOS CEDROS 98','989712313','IN'
EXEC DBO.spuInsertarEstudiante NULL,'208025','ATAYUPANQUI','SALAS','CARLOS','208025@unsaac.edu.pe','CALLE EDEN 32','956432310','IN'
EXEC DBO.spuInsertarEstudiante NULL,'203456','CANAL','TORRES','JUAN','203456@unsaac.edu.pe','CALLE KISWAR 17','955677987','IN'
EXEC DBO.spuInsertarEstudiante NULL,'206543','ACUÑA','UMERES','ZOILA','206543@unsaac.edu.pe','JR. ESMERALDA 231','984509802','IN'
EXEC DBO.spuInsertarEstudiante NULL,'203022','PAREDES','OLIVERA','ESTHER','203022@unsaac.edu.pe','JR. EL SOL 54','974213455','IN'
EXEC DBO.spuInsertarEstudiante NULL,'202453','CARPIO','PUELLES','ERNESTO','202453@unsaac.edu.pe','AV. FEREDAL 254','987664664','IN'
EXEC DBO.spuInsertarEstudiante NULL,'213404','TARRAGA','PEZO','GIOVANNA','213404@unsaac.edu.pe','CALLE LOS OLIVOS 42','953234700','IN'
EXEC DBO.spuInsertarEstudiante NULL,'219025','ARCE','CRESPO','EVA','219025@unsaac.edu.pe','JR.CANARIOS 123','935212435','IN'
GO

-- Docentes:
EXEC DBO.spuInsertarDocente NULL,'00000','----','----','DOCENTE POR DEFECTO','----','----','----','NOMBRADO','PRINCIPAL','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'15313','SEGUNDO','CARPIO','LISETH URPY','15313@unsaac.edu.pe','AV. PERU 132','943565434','NOMBRADO','ASOCIADO','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'16200','SONCCO','ALVAREZ','JOSE LUIS','16200@unsaac.edu.pe','AV. CUSCO 234','986473485','CONTRATADO','A1','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'23635','VILLAFUERTE','SERNA','RONY','23635@unsaac.edu.pe','AV. SAN JOSE 51','997640345','NOMBRADO','ASOCIADO','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'34024','CHULLO','LLAVE','BORIS','34024@unsaac.edu.pe','CALLE HUAYRA 18','905439234','CONTRATADO','B1','TIEMPO PARCIAL','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'54235','QUISPE','ONOFRE','CARLOS RAMON','54235@unsaac.edu.pe','CALLE PUQUIN 10','984325712','CONTRATADO','A1','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'74224','CANDIA','OVIEDO','DENNIS IVAN','74224@unsaac.edu.pe','AV. SUCRE 34','985493452','NOMBRADO','ASOCIADO','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'12341','GAMARRA','SALDIVAR','ENRIQUE','12341@unsaac.edu.pe','AV. VALDEZ 87','994543245','NOMBRADO','PRINCIPAL','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'32403','FLORES','PACHECO','LINO PRISCILIANO','32403@unsaac.edu.pe','CALLE PERA 46','932432187','NOMBRADO','PRINCIPAL','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'51410','MEDRANO','VALENCIA','IVAN CESAR','51410@unsaac.edu.pe','CALLE QUERA 39','990768321','NOMBRADO','ASOCIADO','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'95234','ROZAS','HUACHO','JAVIER ARTURO','95234@unsaac.edu.pe','AV. TACNA 17','944356782','NOMBRADO','PRINCIPAL','DEDICACIÓN EXCLUSIVA','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'13432','CHAVEZ','CENTENO','JAVIER DAVID','13432@unsaac.edu.pe','AV. MANCO CAPAC 210','974358922','NOMBRADO','AUXILIAR','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'10134','MEDINA','MIRANDA','KARELIA','10134@unsaac.edu.pe','AV. ANTA 12','955784357','NOMBRADO','ASOCIADO','TIEMPO PARCIAL','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'14233','ENCISO','RODAS','LAURO','14233@unsaac.edu.pe','JR. ESPINAR 134','937892354','NOMBRADO','PRINCIPAL','DEDICACIÓN EXCLUSIVA','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'14235','PALMA','TTITO','LUIS BELTRAN','14235@unsaac.edu.pe','CALLE ARICA 43','975382948','NOMBRADO','ASOCIADO','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'53466','VENEGAS','VERGARA','MARIA DEL PILAR','53466@unsaac.edu.pe','AV. ARGUEDAS 88','910234294','CONTRATADO','A1','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'17453','ACURIO','USCA','NILA ZONIA','17453@unsaac.edu.pe','AV. COLINA 40','951235879','NOMBRADO','PRINCIPAL','DEDICACIÓN EXCLUSIVA','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'65475','ALZAMORA','PAREDES','ROBERT','65475@unsaac.edu.pe','JR. SAUCES 21','935789040','NOMBRADO','ASOCIADO','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'76745','QUINTANILLA','PORTUGAL','ROXANA LISETTE','76745@unsaac.edu.pe','AV. AMERICAS 318','945678912','CONTRATADO','A1','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'54543','UGARTE','ROJAS','HECTOR EDUARDO','54543@unsaac.edu.pe','AV. CHIMU 27','912323453','CONTRATADO','A1','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'18439','ORMEÑO','AYALA','YESHICA ISELA','18435@unsaac.edu.pe','JR. GARCILASO 65','972138900','NOMBRADO','ASOCIADO','DEDICACIÓN EXCLUSIVA','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'63321','TICONA','PARI','GUZMAN','63321@unsaac.edu.pe','AV. BOLIVAR 211','984589033','NOMBRADO','ASOCIADO','DEDICACIÓN EXCLUSIVA','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'43242','PALOMINO','OLIVERA','EMILIO','43242@unsaac.edu.pe','AV. SUCRE 45','984590098','NOMBRADO','PRINCIPAL','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'18435','ZAMALLOA','PARO','WILLIAN','18435@unsaac.edu.pe','JR. GAMARRA 24','953224639','CONTRATADO','B1','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'13144','CARRASCO','POBLETE','EDWIN','13144@unsaac.edu.pe','CALLE ARICA 38','989032429','NOMBRADO','PRINCIPAL','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'54323','IBARRA','ZAMBRANO','WALDO ELLIO','54323@unsaac.edu.pe','CALLE PALMERAS 27','975849302','NOMBRADO','AUXILIAR','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'62322','PILLCO','QUISPE','JOSE MAURO','62322@unsaac.edu.pe','AV. SAN LUIS 11','993203245','NOMBRADO','AUXILIAR','TIEMPO COMPLETO','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'12345','CARBAJAL','LUNA','JULIO CESAR','12345@unsaac.edu.pe','JR. GRAU 43','951234566','NOMBRADO','PRINCIPAL','DEDICACIÓN EXCLUSIVA','IF','IN'
EXEC DBO.spuInsertarDocente NULL,'16341','PEÑALOZA','FIGUEROA','MANUEL AURELIO','16341@unsaac.edu.pe','AV. 2 DE MAYO 123','995049596','NOMBRADO','ASOCIADO','TIEMPO PARCIAL','IF','IN'
GO

-- Asignaturas:
EXEC DBO.spuInsertarAsignatura 'IF662','DEEP LEARNING',4,'EEEP',3,2,'IF652','0' 
EXEC DBO.spuInsertarAsignatura 'IF468','FUNDAMENTOS DE PROGRAMACIÓN',4,'OEES',3,2,NULL,'0'
EXEC DBO.spuInsertarAsignatura 'IF902','TECNOLOGIAS DE LA INFORMACIÓN Y LA COMUNICACIÓN',3,'EG',2,2,'15 CREDITOS','0'
EXEC DBO.spuInsertarAsignatura 'IF450','ABSTRACCIÓN DE DATOS Y OBJETOS',4,'OEES',3,2,'IF468','0'
EXEC DBO.spuInsertarAsignatura 'IF451','PROGRAMACION I',2,'OEES',0,4,'IF468','0'
EXEC DBO.spuInsertarAsignatura 'IF452','ALGORITMOS Y ESTRUCTURAS DE DATOS',4,'OEES',3,2,'IF450','0'
EXEC DBO.spuInsertarAsignatura 'IF650','MODELOS PROBABILISTICOS',4,'OEES',3,2,'ME532','0'
EXEC DBO.spuInsertarAsignatura 'IF454','TEORIA DE LA COMPUTACION',3,'OEES',2,2,'IF452,ME355','0'
EXEC DBO.spuInsertarAsignatura 'IF458','COMPUTACIÓN GRÁFICA I',4,'EEEP',3,2,'IF452,ME351','0'
EXEC DBO.spuInsertarAsignatura 'IF612','FUNDAMENTOS Y DISEÑO DE BASES DE DATOS',4,'OEES',3,2,'IF610','0'
EXEC DBO.spuInsertarAsignatura 'IF611','METODOLOGÍA DE DESARROLLO DE SOFTWARE',3,'OEES',2,2,'IF610','0'
EXEC DBO.spuInsertarAsignatura 'IF456','ALGORITMOS AVANZADOS',4,'OEES',3,2,'IF454','0'
EXEC DBO.spuInsertarAsignatura 'IF467','ANÁLISIS Y DISEÑO DE ALGORITMOS',3,'EEEP',2,2,'IF452,IF453','0'
EXEC DBO.spuInsertarAsignatura 'IF613','DESARROLLO DE SOFTWARE I',2,'OEES',2,2,'IF612','0'
EXEC DBO.spuInsertarAsignatura 'IF651','INTELIGENCIA ARTIFICIAL',4,'OEES',3,2,'IF650,IF612','0'
EXEC DBO.spuInsertarAsignatura 'IF652','APRENDIZAJE AUTOMATICO',4,'OEES',3,2,'IF651','0'
EXEC DBO.spuInsertarAsignatura 'IF614','INGENIERIA DE SOFTWARE I',4,'OEES',3,2,'IF611,IF613','0'
EXEC DBO.spuInsertarAsignatura 'IF617','INGENIERIA DE SOFTWARE II',4,'EEEP',3,2,'IF614','0'
EXEC DBO.spuInsertarAsignatura 'LI617','INGENIERIA DE SOFTWARE II',4,'EEEP',3,2,'IF614','0'
GO

-- Catalogo:
-- DEEP LEARNING
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF662','IN','A','51410',NULL,NULL
-- FUNDAMENTOS DE PROGRAMACIÓN
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF468','IN','A','17453',NULL,NULL
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF468','IN','A','10134',NULL,NULL
-- PROGRAMACION I
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF451','IN','A','10134',NULL,NULL
-- TECNOLOGIAS DE LA INFORMACIÓN Y LA COMUNICACIÓN
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF902','IN','A','95234',NULL,NULL
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF902','LI','A','10134',NULL,NULL
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF902','CI','A','34024',NULL,NULL
-- ALGORITMOS Y ESTRUCTURAS DE DATOS
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF452','IN','A','95234',NULL,NULL
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF452','IN','A','10134',NULL,NULL
-- TEORIA DE LA COMPUTACION
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF454','IN','A','54543',NULL,NULL
-- FUNDAMENTOS Y DISEÑO DE BASES DE DATOS
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF612','IN','A','65475',NULL,NULL
-- ANÁLISIS Y DISEÑO DE ALGORITMOS A
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF467','IN','A','34024',NULL,NULL
-- ANÁLISIS Y DISEÑO DE ALGORITMOS B
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF467','IN','B','34024',NULL,NULL
-- INGENIERIA DE SOFTWARE I
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF614','IN','A','65475',NULL,NULL
-- INGENIERIA DE SOFTWARE II
--EXEC DBO.spuInsertarAsignaturaCatalogo '2021-II','IF617','IN','A','65475',NULL,NULL
--GO

-- Horario-Asignatura:
-- DEEP LEARNING
--EXEC spuInsertarHorarioAsignatura '2021-II','IF662','IN','A','51410','LU',2,0,'09','11','T',50,'VIRT 11 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF662','IN','A','51410','MI',0,2,'09','11','P',50,'VIRT 11 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF662','IN','A','51410','VI',1,0,'09','10','T',50,'VIRT 11 IN','VIRTUAL'
-- FUNDAMENTOS DE PROGRAMACIÓN
--EXEC spuInsertarHorarioAsignatura '2021-II','IF468','IN','A','17453','LU',2,0,'09','11','T',40,'VIRT 1 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF468','IN','A','17453','MI',0,2,'09','11','P',40,'VIRT 1 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF468','IN','A','17453','VI',1,0,'09','10','T',40,'VIRT 1 IN','VIRTUAL'
-- PROGRAMACION I
--EXEC spuInsertarHorarioAsignatura '2021-II','IF451','IN','A','10134','LU',0,2,'09','11','P',45,'VIRT 2 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF451','IN','A','10134','MI',0,2,'09','11','P',45,'VIRT 2 IN','VIRTUAL'
-- TECNOLOGIAS DE LA INFORMACIÓN Y LA COMUNICACIÓN
--EXEC spuInsertarHorarioAsignatura '2021-II','IF902','IN','A','95234','MA',2,0,'14','16','T',50,'V. EG IN 1','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF902','IN','A','95234','JU',0,2,'14','16','P',50,'V. EG IN 1','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF902','LI','A','10134','MA',2,0,'14','16','T',50,'V. EG IN 1','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF902','LI','A','10134','JU',0,2,'14','16','P',50,'V. EG IN 1','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF902','CI','A','34024','MA',2,0,'14','16','T',50,'V. EG IN 1','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF902','CI','A','34024','JU',0,2,'14','16','P',50,'V. EG IN 1','VIRTUAL'
-- ALGORITMOS Y ESTRUCTURAS DE DATOS
--EXEC spuInsertarHorarioAsignatura '2021-II','IF452','IN','A','95234','LU',2,0,'09','11','T',45,'VIRT 3 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF452','IN','A','10134','MI',0,2,'09','11','P',45,'VIRT 3 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF452','IN','A','95234','VI',1,0,'10','11','T',45,'VIRT 3 IN','VIRTUAL'
-- TEORIA DE LA COMPUTACION
--EXEC spuInsertarHorarioAsignatura '2021-II','IF454','IN','A','54543','LU',2,0,'07','09','T',35,'VIRT 4 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF454','IN','A','54543','MI',0,2,'07','09','P',35,'VIRT 4 IN','VIRTUAL'
-- FUNDAMENTOS Y DISEÑO DE BASES DE DATOS
--EXEC spuInsertarHorarioAsignatura '2021-II','IF612','IN','A','65475','MA',2,0,'09','11','T',40,'VIRT 5 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF612','IN','A','65475','JU',0,2,'09','11','P',40,'VIRT 5 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF612','IN','A','65475','VI',1,0,'09','10','T',40,'VIRT 5 IN','VIRTUAL'
-- ANÁLISIS Y DISEÑO DE ALGORITMOS A
--EXEC spuInsertarHorarioAsignatura '2021-II','IF467','IN','A','34024','MA',2,0,'07','09','T',50,'VIRT 6 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF467','IN','A','34024','JU',0,2,'07','09','P',50,'VIRT 6 IN','VIRTUAL'
-- ANÁLISIS Y DISEÑO DE ALGORITMOS B
--EXEC spuInsertarHorarioAsignatura '2021-II','IF467','IN','B','34024','MA',2,0,'15','17','T',50,'VIRT 6 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF467','IN','B','34024','JU',0,2,'15','17','P',50,'VIRT 6 IN','VIRTUAL'
-- INGENIERIA DE SOFTWARE I
--EXEC spuInsertarHorarioAsignatura '2021-II','IF614','IN','A','65475','MA',2,0,'07','09','T',40,'VIRT 7 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF614','IN','A','65475','JU',0,2,'07','09','P',40,'VIRT 7 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF614','IN','A','65475','VI',1,0,'08','09','T',40,'VIRT 7 IN','VIRTUAL'
-- INGENIERIA DE SOFTWARE II
--EXEC spuInsertarHorarioAsignatura '2021-II','IF617','IN','A','65475','LU',2,0,'09','11','T',35,'VIRT 9 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF617','IN','A','65475','MI',0,2,'09','11','P',35,'VIRT 9 IN','VIRTUAL'
--EXEC spuInsertarHorarioAsignatura '2021-II','IF617','IN','A','65475','VI',1,0,'09','10','T',35,'VIRT 9 IN','VIRTUAL'

-- Matricula:
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','170115'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','170225'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','181227'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','171121'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','170335'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','180219'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','191447'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','191779'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','208025'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','202453'
EXEC spuInsertarMatricula '2021-II','IN','IF662AIN','213404'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','170115'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','170225'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','171121'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','181371'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','181227'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','191447'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','191779'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','208025'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','202453'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','213404'
EXEC spuInsertarMatricula '2021-II','IN','IF468AIN','219025'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','170115'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','171121'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','180219'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','181227'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','180116'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','191447'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','190788'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','191779'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','202700'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','208025'
EXEC spuInsertarMatricula '2021-II','IN','IF451AIN','202453'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','170225'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','170231'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','170335'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','181371'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','180116'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','181197'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','190788'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','191876'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','202700'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','206543'
EXEC spuInsertarMatricula '2021-II','IN','IF452AIN','203022'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','170115'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','170231'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','170255'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','180219'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','181227'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','180919'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','191779'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','170225'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','203413'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','202700'
EXEC spuInsertarMatricula '2021-II','IN','IF454AIN','203456'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','171347'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','171121'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','170335'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','170255'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','180116'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','181197'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','190788'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','191876'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','193402'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','203413'
EXEC spuInsertarMatricula '2021-II','IN','IF612AIN','206543'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','170115'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','171347'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','170231'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','170335'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','180116'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','180277'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','180919'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','191876'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','203456'
EXEC spuInsertarMatricula '2021-II','IN','IF467AIN','203022'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','170225'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','171347'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','171121'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','170255'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','181371'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','180219'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','190366'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','190998'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','193402'
EXEC spuInsertarMatricula '2021-II','IN','IF467BIN','203413'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','170115'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','171347'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','170231'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','181371'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','180277'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','180919'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','190366'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','190998'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','206543'
EXEC spuInsertarMatricula '2021-II','IN','IF614AIN','203022'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','171347'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','170231'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','171121'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','170255'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','180277'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','181197'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','190366'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','190998'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','193402'
EXEC spuInsertarMatricula '2021-II','IN','IF617AIN','203456'


SELECT * FROM TEscuelaProfesional

SELECT * FROM TDepartamentoAcademico

SELECT * FROM TEstudiante

SELECT * FROM TDocente

SELECT * FROM TAsignatura

SELECT * FROM TCatalogo

SELECT * FROM THorarioAsignatura

SELECT * FROM TMatricula

--Select DISTINCT CodAsignatura,CodSemestre,CodEscuelaP,Grupo
	--from TCatalogo
	--WHERE CodSemestre = '2023-I'