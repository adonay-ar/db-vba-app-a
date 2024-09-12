Imports System
Imports mysql.Data.MySqlClient

Module Program

    Dim connection 

    Sub Main(args As String())
        Dim op As Integer

        Connect()

        Do
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
                    Console.WriteLine("Mostrar")
                Case 2
                    Console.WriteLine("Registrar")
                Case 3
                    Console.WriteLine("Actualizar")
                Case 4
                    Console.WriteLine("Eliminar")
                Case 5
                    Console.WriteLine("Salir")
                Case Else
                    Console.WriteLine("Opción no válida")
            End Select
        Loop While op <> 5
  
    End Sub

    Sub Connect()
        connection = New MySqlConnection(
            "server=localhost;user=root;password=;database=db_escuela"
        )

        connection.Open()
    End Sub
End Module
