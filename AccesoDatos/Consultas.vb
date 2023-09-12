Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Security.Cryptography
Imports System.Text
Imports Funciones


Public Module Consultas
    Dim conn As New SqlConnection()




    'Funcion que ejecuta una instruccion SQL como un insert, un delete, un update...etc
    Public Function Executa_Query(ByVal strSQL As String, ByVal strCONN As String) As Boolean
        Dim comm As New SqlCommand

        Try
            conn.ConnectionString = strCONN
            comm.CommandText = strSQL
            comm.CommandType = CommandType.Text
            comm.Connection = conn
            comm.CommandTimeout = 600
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()
            Executa_Query = True
        Catch ex As Exception
            conn.Close()
            Throw New Exception("No se pudo ejecutar la instruccion: " + ex.Message)
            'MessageBox.Show(ex.Message & strSQL, "ERP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Executa_Query = False
        End Try
    End Function

    'Funcion que valida si un dato existe o no en la base de datos
    Public Function Existe_Dato(ByVal strSQL As String, ByVal strCONN As String) As Boolean
        Try
            Dim comm As New SqlCommand
            Dim dr As SqlDataReader

            conn.ConnectionString = strCONN
            comm.CommandText = strSQL
            comm.CommandType = CommandType.Text
            comm.Connection = conn
            conn.Open()
            dr = comm.ExecuteReader()
            If dr.HasRows() Then
                Existe_Dato = True
            Else
                Existe_Dato = False
            End If
            dr.Close()
            conn.Close()
        Catch ex As Exception
            conn.Close()
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function Consulta_Dato(ByVal strSQL As String, ByVal strCONN As String) As String
        Dim comm As New SqlCommand
        Dim dr As SqlDataReader

        Try
            conn.ConnectionString = strCONN
            comm.CommandText = strSQL
            comm.CommandType = CommandType.Text
            comm.Connection = conn
            conn.Open()
            dr = comm.ExecuteReader
            If dr.Read Then
                Consulta_Dato = dr(0).ToString.Trim
            Else
                Consulta_Dato = ""
            End If
            dr.Close()
            conn.Close()
        Catch ex As Exception
            conn.Close()
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function BloqueaImpresionKitting() As Boolean
        Try
            Return Existe_Dato("select * from ERP_ADM_CONFIGS where valor = 'S' AND parametro = 'KIT_BLOQUEO'", var_conexionsauerp)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    'Funcion que en base a una consulta te regresa un dataset con todos los datos obtenidos
    Public Function Consulta_Datos(ByVal strSQL As String, ByVal strCONN As String) As DataSet
        Try
            Dim adapter As New SqlDataAdapter
            Dim ds As New DataSet

            conn.ConnectionString = strCONN
            adapter.SelectCommand = New SqlCommand(strSQL, conn)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(ds)
            ds.Tables(0).TableName = "Consulta"
            Consulta_Datos = ds
            adapter.Dispose()
            conn.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function Escanea_Tadif(ByVal Tadif As String, ByRef Kanban As String, ByRef Cant As String, ByRef NoTadif As String) As Boolean
        If Tadif.Length = 14 Then ' es nuevo kanban
            Kanban = Tadif.Substring(0, 8)
            Cant = Tadif.Substring(11, 3)
            NoTadif = Tadif.Substring(8, 3)
            Return True
        Else
            If Tadif.Length > 11 Then
                Kanban = Tadif.Substring(0, 8)
                Cant = Tadif.Substring(8, 3)
                NoTadif = Tadif.Substring(11)
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Sub ValidateEmailAddress(ByVal txt As String)

        If txt.Length = 0 Then
            Throw New Exception("Email address is a required field")
        Else

            If txt.IndexOf(".") = -1 Or txt.IndexOf("@") = -1 Then
                Throw New Exception("E-mail address must be valid e-mail " & _
                    "address format." & ControlChars.Cr & "For example " & _
                    "'someone@microsoft.com'")
            End If
        End If
    End Sub
    Public Function Valida_Acceso_Usr(ByVal Group As String, ByVal Form As String, ByVal Tipo_Movimiento As String, ByVal strCONN As String) As Boolean
        If Group = "1" Then
            Valida_Acceso_Usr = True
            Exit Function
        Else
            Dim comm As New SqlCommand
            Dim dr As SqlDataReader
            Try

                conn.ConnectionString = strCONN
                comm.CommandText = String.Format("Select * From ERP_ADM_ACCESS WHERE GRP_ID = '{0}' AND FRM_ID = '{1}' AND FRM_AX = '{2}'", Group, Form, Tipo_Movimiento)
                comm.CommandType = CommandType.Text
                comm.Connection = conn
                conn.Open()
                dr = comm.ExecuteReader()
                If dr.HasRows() Then
                    Valida_Acceso_Usr = True
                Else
                    Valida_Acceso_Usr = False
                End If
                dr.Close()
                conn.Close()
            Catch ex As Exception
                conn.Close()
                Throw New Exception(ex.Message)
            End Try
        End If
    End Function

    Public Function ValidaAccesoTHS(ByVal acceso As String, ByVal strCONN As String) As Boolean
        Dim sql As String
        sql = "select * from ERP_MTTO_THS_USERS where user_id = '" & var_adm_Usr_NICK & "' and group_id <= '" & acceso & "'"
        If Existe_Dato(sql, strCONN) Then
            ValidaAccesoTHS = True
        Else
            sql = "select * from ERP_MTTO_THS_USERS where user_id = '" & var_adm_Usr_NICK & "' and group_id = '1'"
            If Existe_Dato(sql, strCONN) Then
                ValidaAccesoTHS = True
            Else
                ValidaAccesoTHS = False
            End If
        End If
    End Function

    Public Function ValidaAccesoTHSAseg(ByVal acceso As String, ByVal strCONN As String) As Boolean
        Dim sql As String
        sql = "select * from ERP_MTTO_THS_USERS where user_id = '" & var_adm_Usr_NICK & "' and group_id = '" & acceso & "'"
        If Existe_Dato(sql, strCONN) Then
            ValidaAccesoTHSAseg = True
        Else
            sql = "select * from ERP_MTTO_THS_USERS where user_id = '" & var_adm_Usr_NICK & "' and group_id = '0'"
            If Existe_Dato(sql, strCONN) Then
                ValidaAccesoTHSAseg = True
            Else
                ValidaAccesoTHSAseg = False
            End If
        End If
    End Function


    'Public Function Encrypt(ByVal Word As String, ByVal Key As String, Optional ByVal Mode As Boolean = False) As String
    '    Dim w As Long, k As Long, p As Long, j As Long, NuChr As Long
    '    Dim Cd As String
    '    Dim Kd As String
    '    Dim Rd As String

    '    w = Len(Word)
    '    k = Len(Key)
    '    ' Modalidad de Encripción...
    '    If Mode = False Then
    '        For j = 1 To w
    '            Cd = Mid(Word, j, 1)
    '            If p = k Then p = 0
    '            p = p + 1
    '            Kd = Mid(Key, p, 1)
    '            NuChr = Asc(Cd) + Asc(Kd)
    '            If NuChr > 255 Then
    '                NuChr = NuChr - 255
    '            End If
    '            Rd = Rd & Chr(NuChr)
    '        Next
    '        Encrypt = Rd
    '        Exit Function
    '    End If
    '    ' Modalidad de Dencripción...
    '    If Mode = True Then
    '        For j = 1 To w
    '            Cd = Mid(Word, j, 1)
    '            If p = k Then p = 0
    '            p = p + 1
    '            Kd = Mid(Key, p, 1)
    '            NuChr = Asc(Cd) - Asc(Kd)
    '            If NuChr < 0 Then
    '                NuChr = NuChr + 255
    '            End If
    '            Rd = Rd & Chr(NuChr)
    '        Next
    '        Encrypt = Rd
    '        Exit Function
    '    End If
    'End Function

    Public Function Desencriptar(ByVal Input As String, ByVal LlaveDes As String) As String

        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes(LlaveDes) 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Convert.FromBase64String(Input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV
        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))

    End Function

    Public Function DesencriptaCadenaConexion(ByVal CadenaOriginal As String) As String
        Dim CadenaNueva, Usuario, Passwrd, usrEncript, pwdEncript As String
        Try


            usrEncript = CadenaOriginal.Substring(CadenaOriginal.IndexOf("User ID") + 8)
            usrEncript = usrEncript.Split(";")(0)
            Usuario = Desencriptar(usrEncript, "usuario0")

            pwdEncript = CadenaOriginal.Substring(CadenaOriginal.IndexOf("Password") + 9)
            pwdEncript = pwdEncript.Split(";")(0)
            CadenaOriginal = CadenaOriginal.Replace(usrEncript, Usuario)

            If pwdEncript <> "" Then
                Passwrd = Desencriptar(pwdEncript, "contrase")
                CadenaNueva = CadenaOriginal.Replace(pwdEncript, Passwrd)
            Else
                CadenaNueva = CadenaOriginal
            End If
            Return CadenaNueva
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function DesencriptaCadenaConexionERPSAU(ByVal CadenaOriginal As String) As String
        Dim CadenaNueva, Usuario, Passwrd, usrEncript, pwdEncript As String
        Try


            usrEncript = CadenaOriginal.Substring(CadenaOriginal.IndexOf("User ID") + 8)
            usrEncript = usrEncript.Split(";")(0)
            Usuario = Desencriptar(usrEncript, "usuario0")

            pwdEncript = CadenaOriginal.Substring(CadenaOriginal.IndexOf("Password") + 9)
            pwdEncript = pwdEncript.Split(";")(0)
            CadenaOriginal = CadenaOriginal.Replace(usrEncript, Usuario)

            If pwdEncript <> "" Then
                Passwrd = Desencriptar(pwdEncript, "contrase")
                CadenaNueva = CadenaOriginal.Replace(pwdEncript, Passwrd)
            Else
                CadenaNueva = CadenaOriginal
            End If
            var_RptUsrSAU = Usuario
            var_RptPwdSAU = Passwrd
            Return CadenaNueva
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function DesencriptaCadenaConexionERP(ByVal CadenaOriginal As String) As String
        Dim CadenaNueva, Usuario, Passwrd, usrEncript, pwdEncript As String
        Try


            usrEncript = CadenaOriginal.Substring(CadenaOriginal.IndexOf("User ID") + 8)
            usrEncript = usrEncript.Split(";")(0)
            Usuario = Desencriptar(usrEncript, "usuario0")

            pwdEncript = CadenaOriginal.Substring(CadenaOriginal.IndexOf("Password") + 9)
            pwdEncript = pwdEncript.Split(";")(0)
            CadenaOriginal = CadenaOriginal.Replace(usrEncript, Usuario)

            If pwdEncript <> "" Then
                Passwrd = Desencriptar(pwdEncript, "contrase")
                CadenaNueva = CadenaOriginal.Replace(pwdEncript, Passwrd)
            Else
                CadenaNueva = CadenaOriginal
            End If
            var_RptUsr = Usuario
            var_RptPwd = Passwrd
            Return CadenaNueva
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function DesencriptaCadenaConexionCTRACE(ByVal CadenaOriginal As String) As String
        Dim CadenaNueva, Usuario, Passwrd, usrEncript, pwdEncript As String
        Try


            usrEncript = CadenaOriginal.Substring(CadenaOriginal.IndexOf("User ID") + 8)
            usrEncript = usrEncript.Split(";")(0)
            Usuario = Desencriptar(usrEncript, "usuario0")

            pwdEncript = CadenaOriginal.Substring(CadenaOriginal.IndexOf("Password") + 9)
            pwdEncript = pwdEncript.Split(";")(0)
            CadenaOriginal = CadenaOriginal.Replace(usrEncript, Usuario)

            If pwdEncript <> "" Then
                Passwrd = Desencriptar(pwdEncript, "contrase")
                CadenaNueva = CadenaOriginal.Replace(pwdEncript, Passwrd)
            Else
                Passwrd = ""
                CadenaNueva = CadenaOriginal
            End If
            var_RptKitPwd = Passwrd
            Return CadenaNueva
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Sub Carga_ComboDevXpress(ByRef combo As DevExpress.XtraEditors.LookUpEdit, ByVal strSQL As String, ByVal strCONN As String)

        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Try
            combo.Properties.DataSource = Nothing
            conn.ConnectionString = strCONN
            adapter.SelectCommand = New SqlCommand(strSQL, conn)
            adapter.Fill(ds)
            'ds.Tables(0).TableName = "CargaCombo"
            combo.Properties.DisplayMember = "Nombre_comun"
            combo.Properties.DataSource = ds.Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub Carga_CombooDevXpress(ByRef combo As DevExpress.XtraEditors.ComboBoxEdit, ByVal strSQL As String, ByVal strCONN As String)
        Dim adapter As New SqlDataAdapter
        Dim ds As New DataSet
        Try
            combo.Properties.Items.Clear()
            conn.ConnectionString = strCONN
            adapter.SelectCommand = New SqlCommand(strSQL, conn)
            adapter.Fill(ds)
            ds.Tables(0).TableName = "CargaCombo"
            For i = 0 To ds.Tables(0).Rows.Count - 1
                combo.Properties.Items.Add(ds.Tables(0).Rows(i)(0).ToString)
            Next i
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Module
