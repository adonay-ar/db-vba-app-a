Imports System
Imports mysql.Data.MySqlClient

Module Program

    Dim connection 

    Sub Main(args As String())
        Dim op As Integer
        Dim nie As Integer
        Dim nombre As String

        'Connect()

        Do
            Console.Clear() '<--- Limpiar la pantalla
            Console.WriteLine("-- MENU --")
            Console.WriteLine("1. Mostrar")
            Console.WriteLine("2. Registrar")
            Console.WriteLine("3. Actualizar")
            Console.WriteLine("4. Eliminar")
            Console.WriteLine("5. Salir")
            Console.Write("Seleccione: ")
            op = Console.ReadLine()

            Select Case op
                Case 1
                    Console.Clear() '<--- Limpiar la pantalla
                    Console.WriteLine("-- MOSTRAR --")
                    Console.WriteLine(Show())
                Case 2
                    Console.WriteLine("-- REGISTRAR --")
                    Console.Write("NIE: ")
                    nie = Console.ReadLine()

                    Console.Write("Nombre: ")
                    nombre = Console.ReadLine()

                    Console.WriteLine(Insert(nie, nombre))
                Case 3
                    Console.WriteLine("Actualizar")
                Case 4
                    Console.WriteLine("Eliminar")
                Case 5
                    Console.WriteLine("Salir")
                Case Else
                    Console.WriteLine("Opción no válida")
            End Select

            Console.ReadKey()

        Loop While op <> 5
  
    End Sub

    Sub Connect()
        connection = New MySqlConnection(
            "server=localhost;user=root;password=;database=db_escuela"
        )

        connection.Open()
    End Sub

    Function Show() As String
        Connect() 'Abrimos la conexión
        Dim sql = "SELECT * FROM alumno"

        Dim cmd = New MySqlCommand(sql, connection)
        Dim reader = cmd.ExecuteReader()

        Dim result As String = ""
        While reader.Read()
            result &= reader("id_alumno")
            result &= " - "
            result &= reader("nie_alumno")
            result &= " - "
            result &= reader("nombre_alumno")
            result &= VbCrLf
        End While

        connection.Close() 'Cerramos conexión
        return result
    End Function

    Function Insert(nie As Integer, nombre As String) As String
        Connect() 'Abrimos la conexión
        Dim sql = "INSERT INTO alumno(nie_alumno, nombre_alumno) VALUES(@nie, @nombre)"
        Dim cmd = New MySqlCommand(sql, connection)

        cmd.Parameters.AddWithValue("@nie", nie) 'Asignamos el valor a la variable
        cmd.Parameters.AddWithValue("@nombre", nombre)
        cmd.ExecuteNonQuery() 'Ejecutamos la consulta

        connection.Close() 'Cerramos conexión

        Return "Registro guardado"
    End Function
End Module
