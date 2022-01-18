# PIP 
import pyodbc

class Connection(object):

    def __init__(self, server, db_name, db_user, password):
        self.server = server
        self.db_name = db_name
        self.db_user = db_user
        self.password = password

    def Connect(self):
        try:
            connection = pyodbc.connect('Driver={ODBC Driver 17 for SQL Server}' +
                                        ';Server=' + self.server + 
                                        ';DATABASE=' + self.db_name + 
                                        ';UID=' + self.db_user +
                                        ';PWD=' + self.password)
            return connection
        except Exception as e:
            print('Ocurrio un error al conectar SQL Server: ', e)