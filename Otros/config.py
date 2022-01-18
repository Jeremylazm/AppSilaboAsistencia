import odbc

direccion_servidor = 'localhost' # 127.0.0.1
nombre_bd = 'BDSistemaGestion'
nombre_usuario = ''
password = ''

conn = odbc.Connection(direccion_servidor, nombre_bd, nombre_usuario, password)
conexion = conn.Connect()
