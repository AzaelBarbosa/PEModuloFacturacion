Imports System.Data.SqlClient
Imports Microsoft.Win32

Public Class SQLServer

    Private Shared mstrConnection As String

    Private mstrConnection_2 As String

    'Private members
    Private Shared mobjConnection As SqlConnection
    Private mobjConnection_2 As SqlConnection
    Private Shared mobjTransaction As SqlTransaction
    Private mobjTransaction_2 As SqlTransaction
    Private Shared mstrModuleName As String
    Private mstrModuleName_2 As String
    Private Shared mblnDisposed As Boolean = False
    Private mblnDisposed_2 As Boolean = False
    Private Shared mintTimeOut As Integer = 300
    Private mintTimeOut_2 As Integer = 300

    Private Const EXCEPTION_MSG As String = "There was an error in the method. " & _
                                            "Please see the Application Log for details."

    Public Structure SQLTableCommand
        Public SQLTable As String
        Public SQLCommand As String
    End Structure

#Region "Public Instance Constructors"

    Public Sub New()

        'Call the base class constructor
        MyBase.New()

        Init()

        mstrModuleName = Me.GetType.ToString

    End Sub

    Public Sub New(ByVal mstrConn As String)

        'Call the base class constructor
        MyBase.New()

        'Initialize private members
        mstrConnection = mstrConn
        mobjConnection = New SqlConnection(mstrConnection)
        mstrModuleName = Me.GetType.ToString

    End Sub

    Public Sub New(ByVal intTimeOut As Integer, _
                           ByVal strCatalog As String, _
                           ByVal strDataSrc As String, _
                           ByVal strUserID As String, _
                           ByVal strPW As String)

        'Call the base class constructor
        MyBase.New()

        Inicia(intTimeOut, strCatalog, strDataSrc, strUserID, strPW)

        mstrModuleName = Me.GetType.ToString

    End Sub

    Public Sub Inicia(Optional ByVal intTimeOut As Integer = 300, _
                           Optional ByVal strCatalog As String = "", _
                           Optional ByVal strDataSrc As String = "", _
                           Optional ByVal strUserID As String = "", _
                           Optional ByVal strPW As String = "")
        Dim REGPATH As String = "SOFTWARE\Image Technology\VisualMatrix\Data"

        If strCatalog = "" Then
            'strCatalog = GetReg(REGPATH, "DBCatalog", "VisualMatrix")
            strCatalog = "bd_valessa02"
        End If
        If strDataSrc = "" Then
            'strDataSrc = GetReg(REGPATH, "DBDataSource", "(LOCAL)\VISUALMATRIX")
            strDataSrc = "MATAPORTATIL\SQLEXPRESS2008"
            'Else
            '    strDataSrc = strDataSrc & "\SQLEXPRESS2008"
        End If
        If strUserID = "" Then
            'strUserID = GetReg(REGPATH, "DBUserID", "VisualMatrix")
            strUserID = "sa"
        End If
        If strPW = "" Then
            strPW = "12345678"
            'strPW = GetVMPassword()
            'If strPW = "" Then
            '    strPW = GetReg(REGPATH, "DBPassword", "VisualMatrix")
            'End If
        End If

        'mstrConnection = "Initial Catalog=" + strCatalog + ";Data Source=" + strDataSrc + ";User ID=" + strUserID + ";Password=" + strPW + ";"
        'mstrConnection = "Data Source=" + strDataSrc + ";Initial Catalog=" + strCatalog + ";User Id=" + strUserID + ";Password=" + strPW + ";Trusted_Connection=yes;"
        mstrConnection_2 = "Data Source=" + strDataSrc + ";Initial Catalog=" + strCatalog + ";User Id=" + strUserID + ";Password=" + strPW + ";"
        'Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;

        mintTimeOut_2 = intTimeOut

        Try
            'Initialize private members
            mobjConnection_2 = New SqlConnection(mstrConnection_2)
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub Init(Optional ByVal intTimeOut As Integer = 300, _
                           Optional ByVal strCatalog As String = "", _
                           Optional ByVal strDataSrc As String = "", _
                           Optional ByVal strUserID As String = "", _
                           Optional ByVal strPW As String = "")

        Dim REGPATH As String = "SOFTWARE\Image Technology\VisualMatrix\Data"

        If strCatalog = "" Then
            'strCatalog = GetReg(REGPATH, "DBCatalog", "VisualMatrix")
            strCatalog = "bd_valessa02"
        End If
        If strDataSrc = "" Then
            'strDataSrc = GetReg(REGPATH, "DBDataSource", "(LOCAL)\VISUALMATRIX")
            strDataSrc = "MATAPORTATIL\SQLEXPRESS2008"
            'Else
            '    strDataSrc = strDataSrc & "\SQLEXPRESS2008"
        End If
        If strUserID = "" Then
            'strUserID = GetReg(REGPATH, "DBUserID", "VisualMatrix")
            strUserID = "sa"
        End If
        If strPW = "" Then
            strPW = "12345678"
            'strPW = GetVMPassword()
            'If strPW = "" Then
            '    strPW = GetReg(REGPATH, "DBPassword", "VisualMatrix")
            'End If
        End If

        'mstrConnection = "Initial Catalog=" + strCatalog + ";Data Source=" + strDataSrc + ";User ID=" + strUserID + ";Password=" + strPW + ";"
        'mstrConnection = "Data Source=" + strDataSrc + ";Initial Catalog=" + strCatalog + ";User Id=" + strUserID + ";Password=" + strPW + ";Trusted_Connection=yes;"
        mstrConnection = "Data Source=" + strDataSrc + ";Initial Catalog=" + strCatalog + ";User Id=" + strUserID + ";Password=" + strPW + ";"
        'Data Source=myServerAddress;Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;

        mintTimeOut = intTimeOut

        Try
            'Initialize private members
            mobjConnection = New SqlConnection(mstrConnection)
        Catch ex As Exception

        End Try

    End Sub

#End Region

#Region "Public Instance Methods"

#Region "ExecSP"

    Public Shared Sub ExecSP(ByVal SPName As String, Optional ByVal ParamValues() As SqlParameter = Nothing)

        Dim objCommand As SqlCommand

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Instantiate a new SQLCommand object.
            objCommand = New SqlCommand(SPName, mobjConnection)

            'We are using a stored procedure for the CommandType.
            objCommand.CommandType = CommandType.StoredProcedure

            'Build the parameters for the SqlCommand object.
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            'Execute the stored procedure, and do not return any rows
            objCommand.CommandTimeout = mintTimeOut
            objCommand.ExecuteNonQuery()

        Catch objException As Exception

            'Log the error to the Application Log.
            'LogError(objException)

            'Throw a new exception, with the original exception nested.
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the SqlConnection.
            '    mobjConnection.Close()

        End Try

    End Sub

#End Region

#Region "ExecSPNoQuery"

    Public Shared Function ExecSPNoQuery(ByVal strSPName As String, Optional ByVal ParamValues() As SqlParameter = Nothing) As ArrayList

        Dim objCommand As New SqlCommand(strSPName, mobjConnection)
        Dim objParameter As SqlParameter
        Dim arrReturn As New ArrayList

        Try

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            objCommand.CommandType = CommandType.StoredProcedure
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            objCommand.CommandTimeout = mintTimeOut
            objCommand.ExecuteNonQuery()

            'Build the ArrayList of output values
            For Each objParameter In objCommand.Parameters
                If objParameter.Direction = ParameterDirection.Output Then
                    arrReturn.Add(objParameter.Value)
                End If
            Next

            Return arrReturn

        Catch objException As Exception

            'Log the error to the Application Log.
            'LogError(objException)

            'Throw a new exception, with the original exception nested.
            'Throw New Exception(EXCEPTION_MSG, objException)

            Throw objException

            'Finally

            '    'Close the SQLConnection.
            '    mobjConnection.Close()

        End Try

    End Function

#End Region

#Region "ExecSPOutputValues"

    Public Shared Function ExecSPOutputValues(ByVal SPName As String, Optional ByVal ParamValues() As SqlParameter = Nothing) As ArrayList

        Dim objCommand As SqlCommand
        Dim arlParameters As New ArrayList
        Dim objParameter As SqlParameter

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Instantiate a new SQLCommand object.
            objCommand = New SqlCommand(SPName, mobjConnection)

            'We are using a stored procedure for the CommandType.
            objCommand.CommandType = CommandType.StoredProcedure

            'Build the parameters for the SQLCommand object.
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            'Execute the stored procedure, and do not return any rows
            objCommand.CommandTimeout = mintTimeOut
            objCommand.ExecuteNonQuery()

            'Build the ArrayList of output values
            For Each objParameter In objCommand.Parameters
                If objParameter.Direction = ParameterDirection.Output Or _
                   objParameter.Direction = ParameterDirection.InputOutput Then
                    arlParameters.Add(objParameter.Value)
                End If
            Next

            'Return the output values
            Return arlParameters

        Catch objException As Exception

            'Log the error to the Application Log.
            'LogError(objException)

            'Throw a new exception, with the original exception nested.
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the SQLConnection.
            '    mobjConnection.Close()

        End Try

    End Function

#End Region

#Region "ExecSPReturnValue"

    Public Shared Function ExecSPReturnValue(ByVal SPName As String, Optional ByVal ParamValues() As SqlParameter = Nothing) As ArrayList

        Dim objCommand As SqlCommand
        Dim arlParameters As New ArrayList
        Dim objParameter As SqlParameter

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Instantiate a new SQLCommand object.
            objCommand = New SqlCommand(SPName, mobjConnection)

            'We are using a stored procedure for the CommandType.
            objCommand.CommandType = CommandType.StoredProcedure

            'Build the parameters for the SQLCommand object.
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            'Execute the stored procedure, and do not return any rows
            objCommand.CommandTimeout = mintTimeOut
            objCommand.ExecuteNonQuery()

            'Build the ArrayList of output values
            For Each objParameter In objCommand.Parameters
                If objParameter.Direction = ParameterDirection.ReturnValue Then
                    arlParameters.Add(objParameter.Value)
                End If
            Next

            'Return the output values
            Return arlParameters

        Catch objException As Exception

            'Log the error to the Application Log.
            'LogError(objException)

            'Throw a new exception, with the original exception nested.
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the SQLConnection.
            '    mobjConnection.Close()

        End Try

    End Function

#End Region

#Region "ExecSPReturnDS"

    Public Function ExecSPReturnDS_2(ByVal SPName As String, _
                                   Optional ByVal ParamValues() As SqlParameter = Nothing, _
                                   Optional ByVal strTableName As String = "Table") As DataSet
        Dim objCommand As SqlCommand
        Dim objDA As SqlDataAdapter
        Dim objDS As New DataSet

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed_2 = True Then
                Throw New ObjectDisposedException(mstrModuleName_2, _
                "This object has already been disposed.")
            End If

            If mobjConnection_2 Is Nothing Then Init()

            If mobjConnection_2.State <> ConnectionState.Open Then
                mobjConnection_2.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(SPName, mobjConnection_2)
            objCommand.CommandTimeout = mintTimeOut_2
            objCommand.CommandType = CommandType.StoredProcedure

            'Build the parameters, if any
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            'Initialize the SQLDataAdapter with the 
            If Not mobjTransaction_2 Is Nothing Then
                objCommand.Transaction = mobjTransaction_2
            End If

            'SQLCommand object
            objDA = New SqlDataAdapter(objCommand)

            'Fill the DataSet
            'objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey
            objDA.Fill(objDS, strTableName)

            'Return the value
            Return objDS

        Catch objException As Exception

            'LogError(objException)
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the connection and return the value
            '    objCommand.Connection.Close()

        End Try
    End Function

    Public Shared Function ExecSPReturnDS(ByVal SPName As String, _
                                   Optional ByVal ParamValues() As SqlParameter = Nothing, _
                                   Optional ByVal strTableName As String = "Table") As DataSet

        Dim objCommand As SqlCommand
        Dim objDA As SqlDataAdapter
        Dim objDS As New DataSet

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection Is Nothing Then Init()

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(SPName, mobjConnection)
            objCommand.CommandTimeout = mintTimeOut
            objCommand.CommandType = CommandType.StoredProcedure

            'Build the parameters, if any
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            'Initialize the SQLDataAdapter with the 
            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            'SQLCommand object
            objDA = New SqlDataAdapter(objCommand)

            'Fill the DataSet
            'objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey
            objDA.Fill(objDS, strTableName)

            'Return the value
            Return objDS

        Catch objException As Exception

            'LogError(objException)
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the connection and return the value
            '    objCommand.Connection.Close()

        End Try

    End Function

#End Region

#Region "ExecSPReturnDR"

    Public Shared Function ExecSPReturnDR(ByVal SPName As String, Optional ByVal ParamValues() As SqlParameter = Nothing) As SqlDataReader

        Dim objCommand As SqlCommand
        Dim objReader As SqlDataReader

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(SPName, mobjConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            'Build the parameters, if any
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            'Open the connection (required for the ExecuteReader method).
            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            'Execute the sp and get the SqlDataReader.
            objCommand.CommandTimeout = mintTimeOut
            objReader = objCommand.ExecuteReader

            'Return the value
            Return objReader

        Catch objException As Exception

            'Log the error
            'LogError(objException)

            ''Close the connection
            'mobjConnection.Close()

            'Throw a new exception
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

        End Try

    End Function

#End Region

#Region "GetMultiTableDataSet"

    Public Shared Function GetMultiDataSet(ByVal strSQLCommands() As SQLTableCommand) As DataSet
        'create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim da As SqlDataAdapter
        'Dim sParameter As String
        Dim strSQL As String
        Dim intIndex As Integer

        'Try

        'Make sure that the object has not been disposed yet
        If mblnDisposed = True Then
            Throw New ObjectDisposedException(mstrModuleName, _
            "This object has already been disposed.")
        End If

        If mobjConnection.State <> ConnectionState.Open Then
            mobjConnection.Open()
        End If

        For intIndex = 0 To strSQLCommands.GetUpperBound(0)
            strSQL = strSQLCommands(intIndex).SQLCommand

            PrepareCommand(cmd, mobjConnection, CType(Nothing, SqlTransaction), CommandType.Text, strSQL, CType(Nothing, SqlParameter()))

            'create the DataAdapter & DataSet
            da = New SqlDataAdapter(cmd)

            Try
                'fill the DataSet using default values for DataTable names, etc.
                da.Fill(ds, strSQLCommands(intIndex).SQLTable)

            Catch objException As System.Exception

                'Log the error to the Application Log.
                'LogError(objException)

                'Throw a new exception, with the original exception nested.
                'Throw New Exception(EXCEPTION_MSG, objException)
                Throw objException

            End Try
        Next

        'Finally

        '    'Close the SqlConnection.
        '    mobjConnection.Close()

        'End Try

        'return the dataset
        Return ds
    End Function 'MultiTableDataSet

#End Region

#Region "ExecSQLReturnDS"

    Public Shared Function ExecSQLReturnDS(ByVal strSQL As String, _
                                    Optional ByVal strTableName As String = "Table") As DataSet

        Dim objCommand As SqlCommand
        Dim objDA As SqlDataAdapter
        Dim objDS As New DataSet

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(strSQL, mobjConnection)
            objCommand.CommandTimeout = mintTimeOut
            objCommand.CommandType = CommandType.Text

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            'Initialize the SQLDataAdapter with the 
            'SQLCommand object
            objDA = New SqlDataAdapter(objCommand)

            'Fill the DataSet
            objDA.Fill(objDS, strTableName)

            'Return the value
            Return objDS

        Catch objException As Exception

            'LogError(objException)
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the connection and return the value
            '    objCommand.Connection.Close()

        End Try

    End Function

#End Region

#Region "ExecSPReturnDT"

    Public Function ExecSPReturnDT_2(ByVal SPName As String, _
                                  Optional ByVal ParamValues() As SqlParameter = Nothing, _
                                   Optional ByVal TableName As String = "Table") As DataTable
        Dim objCommand As SqlCommand
        Dim objDA As SqlDataAdapter
        Dim objDT As New DataTable

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed_2 = True Then
                Throw New ObjectDisposedException(mstrModuleName_2, _
                "This object has already been disposed.")
            End If

            If mobjConnection_2.State <> ConnectionState.Open Then
                mobjConnection_2.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(SPName, mobjConnection_2)
            objCommand.CommandTimeout = mintTimeOut_2
            objCommand.CommandType = CommandType.StoredProcedure

            'Build the parameters, if any
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            If Not mobjTransaction_2 Is Nothing Then
                objCommand.Transaction = mobjTransaction_2
            End If

            'Initialize the SQLDataAdapter with the 
            'SQLCommand object
            objDA = New SqlDataAdapter(objCommand)

            'Fill the DataSet
            'objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey
            objDA.Fill(objDT)
            objDT.TableName = TableName

            'Return the value
            Return objDT

        Catch objException As Exception

            'LogError(objException)
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the connection and return the value
            '    objCommand.Connection.Close()

        End Try
    End Function

    Public Shared Function ExecSPReturnDT(ByVal SPName As String, _
                                   Optional ByVal ParamValues() As SqlParameter = Nothing, _
                                    Optional ByVal TableName As String = "Table") As DataTable

        Dim objCommand As SqlCommand
        Dim objDA As SqlDataAdapter
        Dim objDT As New DataTable

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(SPName, mobjConnection)
            objCommand.CommandTimeout = mintTimeOut
            objCommand.CommandType = CommandType.StoredProcedure

            'Build the parameters, if any
            If Not ParamValues Is Nothing Then
                AttachParameters(objCommand, ParamValues)
            End If

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            'Initialize the SQLDataAdapter with the 
            'SQLCommand object
            objDA = New SqlDataAdapter(objCommand)

            'Fill the DataSet
            'objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey
            objDA.Fill(objDT)
            objDT.TableName = TableName

            'Return the value
            Return objDT

        Catch objException As Exception

            'LogError(objException)
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the connection and return the value
            '    objCommand.Connection.Close()

        End Try

    End Function

#End Region

#Region "ExecSQLReturnDT"

    Public Function ExecSQLReturnDT_2(strSQL As String, Optional TableName As String = "") As DataTable
        Dim objCommand As SqlCommand
        Dim objDA As SqlDataAdapter
        Dim objDT As New DataTable

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName_2, _
                "This object has already been disposed.")
            End If

            If mobjConnection_2.State <> ConnectionState.Open Then
                mobjConnection_2.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(strSQL, mobjConnection_2)
            objCommand.CommandTimeout = 300
            objCommand.CommandType = CommandType.Text

            If Not mobjTransaction_2 Is Nothing Then
                objCommand.Transaction = mobjTransaction_2
            End If

            'Initialize the SQLDataAdapter with the 
            'SQLCommand object
            objDA = New SqlDataAdapter(objCommand)
            'objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey

            'Fill the DataSet
            objDA.Fill(objDT)
            objDT.TableName = TableName

            'Return the value
            Return objDT

        Catch objException As Exception

            'LogError(objException)
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the connection and return the value
            '    objCommand.Connection.Close()

        End Try
    End Function

    Public Shared Function ExecSQLReturnDT(ByVal strSQL As String, Optional ByVal TableName As String = "NewTable") As DataTable

        Dim objCommand As SqlCommand
        Dim objDA As SqlDataAdapter
        Dim objDT As New DataTable

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(strSQL, mobjConnection)
            objCommand.CommandTimeout = 300
            objCommand.CommandType = CommandType.Text

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            'Initialize the SQLDataAdapter with the 
            'SQLCommand object
            objDA = New SqlDataAdapter(objCommand)
            'objDA.MissingSchemaAction = MissingSchemaAction.AddWithKey

            'Fill the DataSet
            objDA.Fill(objDT)
            objDT.TableName = TableName

            'Return the value
            Return objDT

        Catch objException As Exception

            'LogError(objException)
            'Throw New Exception(EXCEPTION_MSG, objException)
            Throw objException

            'Finally

            '    'Close the connection and return the value
            '    objCommand.Connection.Close()

        End Try

    End Function

    Public Sub ExecSQL_2(ByVal strSQL As String)
        Dim objCommand As SqlCommand

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed_2 = True Then
                Throw New ObjectDisposedException(mstrModuleName_2, _
                "This object has already been disposed.")
            End If

            If mobjConnection_2.State <> ConnectionState.Open Then
                mobjConnection_2.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(strSQL, mobjConnection_2)
            objCommand.CommandTimeout = mintTimeOut
            objCommand.CommandType = CommandType.Text

            If Not mobjTransaction_2 Is Nothing Then
                objCommand.Transaction = mobjTransaction_2
            End If

            objCommand.ExecuteNonQuery()

        Catch objException As Exception

            Throw objException

        End Try
    End Sub

    Public Shared Sub ExecSQL(ByVal strSQL As String)
        Dim objCommand As SqlCommand

        Try

            'Make sure that the object has not been disposed yet
            If mblnDisposed = True Then
                Throw New ObjectDisposedException(mstrModuleName, _
                "This object has already been disposed.")
            End If

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            'Initialize the SQLCommand object
            objCommand = New SqlCommand(strSQL, mobjConnection)
            objCommand.CommandTimeout = mintTimeOut
            objCommand.CommandType = CommandType.Text

            If Not mobjTransaction Is Nothing Then
                objCommand.Transaction = mobjTransaction
            End If

            objCommand.ExecuteNonQuery()

        Catch objException As Exception

            Throw objException

        End Try

    End Sub

#End Region

    Public Shared Sub BeginTrans()
        If Not mobjConnection Is Nothing Then
            mobjTransaction = mobjConnection.BeginTransaction
        End If
    End Sub

    Public Shared Sub CommitTrans()
        If Not mobjTransaction Is Nothing Then
            mobjTransaction.Commit()
            mobjTransaction.Dispose()
        End If
    End Sub

    Public Shared Sub RollBackTrans()
        If Not mobjTransaction Is Nothing Then
            mobjTransaction.Rollback()
            mobjTransaction.Dispose()
        End If
    End Sub

    '#Region "Delete Commands"

    '    Public Shared Function Delete(ByVal ds As DataSet, ByVal strTable As String) As Boolean

    '        Return False

    '    End Function


    '#End Region

#Region "Update Command"

    Public Shared Sub UpdateDataset(ByRef ds As DataSet, ByVal strTable As String)

        Dim da As SqlDataAdapter
        Dim cb As SqlCommandBuilder
        Dim tr As SqlTransaction

        Try

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            da = New SqlDataAdapter("SELECT * FROM " & strTable & " WHERE 1=0", mobjConnection)
            cb = New SqlCommandBuilder(da)

            ' Start a local transaction
            tr = mobjConnection.BeginTransaction()

            da.SelectCommand.Transaction = tr
            cb.RefreshSchema()

            ' Must assign both transaction object and connection
            ' to Command object for a pending local transaction
            'da.UpdateCommand.Transaction = tr
            'da.InsertCommand.Transaction = tr
            'da.DeleteCommand.Transaction = tr

            ' Include an event to fill in the Autonumber value.
            AddHandler da.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

            ' Without the SqlCommandBuilder, this line would fail.
            da.Update(ds, strTable)

            RemoveHandler da.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

            tr.Commit()

        Catch ex As Exception
            Try
                'tr.Rollback()
            Catch
            End Try
            Throw ex
        End Try

    End Sub


    Private Shared Sub OnRowUpdated(ByVal sender As Object, ByVal args As SqlRowUpdatedEventArgs)
        Dim newID As Integer = 0
        Dim newObj As Object
        Dim idCMD As SqlCommand = New SqlCommand("SELECT IDENT_CURRENT('" & args.TableMapping.DataSetTable.ToString & "')", mobjConnection)
        If args.StatementType = StatementType.Insert Then
            If Not CType(sender, SqlDataAdapter).SelectCommand.Transaction Is Nothing Then
                ' Enlist in the transaction is one is present
                idCMD.Transaction = CType(sender, SqlDataAdapter).SelectCommand.Transaction
            End If
            ' Retrieve the identity value and store it in the first column.
            newObj = idCMD.ExecuteScalar()
            If Not newObj Is System.DBNull.Value Then
                newID = CInt(newObj)
                If newID > 0 Then
                    args.Row(0) = newID
                End If
            End If
        End If
    End Sub


    Public Shared Sub UpdateByDataTable(ByRef dt As DataTable)

        If dt Is Nothing Then Return

        Dim da As SqlDataAdapter
        Dim cb As SqlCommandBuilder
        Dim tr As SqlTransaction

        Try

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            da = New SqlDataAdapter("SELECT * FROM " & dt.TableName & " Where 1=0", mobjConnection)
            cb = New SqlCommandBuilder(da)

            ' Start a local transaction
            tr = mobjConnection.BeginTransaction()
            da.SelectCommand.Transaction = tr
            cb.RefreshSchema()

            ' Must assign both transaction object and connection
            ' to Command object for a pending local transaction

            'da.UpdateCommand.Transaction = tr
            'da.InsertCommand.Transaction = tr
            'da.DeleteCommand.Transaction = tr

            ' Include an event to fill in the Autonumber value.
            AddHandler da.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

            ' Without the SqlCommandBuilder, this line would fail.
            da.Update(dt)

            RemoveHandler da.RowUpdated, New SqlRowUpdatedEventHandler(AddressOf OnRowUpdated)

            tr.Commit()

        Catch ex As Exception
            Try
                'tr.Rollback()
            Catch
            End Try
            Throw ex
        End Try

    End Sub

#End Region

    'Currently we will be using the Automatically Generated Commands   -8/13/02 - ks

#Region "Insert Command"
    Public Shared Function InsertByDataset(ByVal ds As DataSet, ByVal strTable As String) As DataSet

        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM " & strTable & " Where 1=0", mobjConnection)
        Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)

        Try

            If mobjConnection.State <> ConnectionState.Open Then
                mobjConnection.Open()
            End If

            cb.RefreshSchema()
            da.Fill(ds, strTable)

            ' Without the SqlCommandBuilder, this line would fail.
            da.Update(ds, strTable)

        Catch
            'DBConcurrencyException:
            '**  Optimistic Concurrency Issue
            '**  In cases where an automatically generated update attempts to update a row that has been deleted or that does not contain the original values found in the DataSet, the command will not affect any records and a DBConcurrencyException will be thrown.

            'InvalidOperation exception :
            '**  The SelectCommand must also return at least one primary key or unique column. 
            '**  If none are present, commands are not generated.


            'Finally
            '    mobjConnection.Close()

        End Try

        Return ds


    End Function


#End Region

#End Region

#Region "Dispose"

    Public Shared Sub Dispose()

        If mblnDisposed = False Then

            Try

                'Free up the database connection resource by 
                'calling its Dispose method
                mobjConnection.Dispose()

            Finally

                'Because this Dispose method has done the necessary cleanup,
                'prevent the Finalize method from being called.
                'GC.SuppressFinalize(Me)

                'Let our class know that Dispose() has been called
                mblnDisposed = True

            End Try

        End If

    End Sub

#End Region

#Region "Private/Protected Methods"

#Region "AssignParameterValues"

    Private Shared Sub AssignParameterValues(ByVal commandParameters() As SqlParameter, ByVal parameterValues() As Object)

        Dim i As Integer
        Dim j As Integer

        If (commandParameters Is Nothing) And (parameterValues Is Nothing) Then
            'do nothing if we get no data
            Return
        End If

        ' we must have the same number of values as we pave parameters to put them in
        If commandParameters.Length <> parameterValues.Length Then
            Throw New ArgumentException("Parameter count does not match Parameter Value count.")
        End If

        'value array
        j = commandParameters.Length - 1
        For i = 0 To j
            commandParameters(i).Value = parameterValues(i)
        Next

    End Sub 'AssignParameterValues

#End Region

#Region "PrepareCommand"

    Private Shared Sub PrepareCommand(ByVal command As SqlCommand, _
                                      ByVal connection As SqlConnection, _
                                      ByVal transaction As SqlTransaction, _
                                      ByVal commandType As CommandType, _
                                      ByVal commandText As String, _
                                      ByVal commandParameters() As SqlParameter)

        'if the provided connection is not open, we will open it
        If connection.State <> ConnectionState.Open Then
            connection.Open()
        End If

        'associate the connection with the command
        command.Connection = connection

        'set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText

        'if we were provided a transaction, assign it.
        If Not (transaction Is Nothing) Then
            command.Transaction = transaction
        End If

        'set the command type
        command.CommandType = commandType

        'attach the command parameters if they are provided
        If Not (commandParameters Is Nothing) Then
            AttachParameters(command, commandParameters)
        End If

        Return

    End Sub 'PrepareCommand

#End Region

#Region "AttachParameters"

    Private Shared Sub AttachParameters(ByVal command As SqlCommand, ByVal commandParameters() As SqlParameter)
        Dim p As SqlParameter
        For Each p In commandParameters
            'check for derived output value with no value assigned
            If p.Direction = ParameterDirection.InputOutput And p.Value Is Nothing Then
                p.Value = Nothing
            End If
            command.Parameters.Add(p)
        Next p
    End Sub 'AttachParameters

    Private Shared Function GetVMPassword() As String
        GetVMPassword = Mid(mstrAlpha, 4, 1) & _
                        Mid(mstrAlpha, 2, 1) & _
                        Mid(mstrAlpha, 15, 1) & _
                        CStr(10 - 9) & Chr(47 + 54) & CStr(Asc("x") - Asc("r"))
    End Function

#End Region

#End Region

#Region "Log Errors"


    Public Shared Sub LogError(ByRef objException As Exception, Optional ByVal strModule As String = "", Optional ByVal strScreen As String = "")

        'Log the error information to the Application Log

        Dim strLogMsg As String

        Try

            With objException

                strLogMsg = "ModuleName: " & strModule & vbCrLf _
                & "ScreenName: " & strScreen & vbCrLf _
                & vbCrLf & "Source: " & .Source & vbCrLf _
                & "Message: " & .Message & vbCrLf _
                & "Stack Trace:  " & .StackTrace & vbCrLf _
                & "Target Site:  " & .TargetSite.ToString

            End With

            'Write error to event log
            System.Diagnostics.EventLog.WriteEntry(objException.Source, strLogMsg, Diagnostics.EventLogEntryType.Error)

        Catch
        End Try

    End Sub


    Public Shared Sub LogSQLError(ByRef objException As SqlException, Optional ByVal strModule As String = "", Optional ByVal strScreen As String = "")

        'Log the error information to the Application Log

        Dim strLogMsg As String

        Try

            With objException

                strLogMsg = "ModuleName: " & strModule & vbCrLf _
                & "ScreenName: " & strScreen & vbCrLf _
                & vbCrLf & "Source: " & .Source & vbCrLf _
                & "Message: " & .Message & vbCrLf _
                & "Stack Trace:  " & .StackTrace & vbCrLf _
                & "Target Site:  " & .TargetSite.ToString

            End With

            'Write error to event log
            System.Diagnostics.EventLog.WriteEntry(objException.Source, strLogMsg, Diagnostics.EventLogEntryType.Error)

        Catch
        End Try

    End Sub


#End Region

#Region "Finalize"

    'Provides a safeguard in case Dispose does not get called.
    Protected Overrides Sub Finalize()
        Try
            'This obj may have already been collected.
            'If Not mobjConnection Is Nothing Then
            '    mobjConnection.Dispose()
            'End If
        Catch

        Finally
            MyBase.Finalize()
        End Try
    End Sub

#End Region

#Region "Registry Routines"
    '
    ' get a registry value from a key
    '
    Private Shared Function GetReg(ByVal sPath As String, ByVal sKey As String, ByVal sDefault As String) As String

        Dim reg As RegistryKey

        '
        ' open the path to the key
        '
        Try
            reg = Registry.LocalMachine.OpenSubKey(sPath, False)

        Catch ex As Exception

        End Try

        '
        ' if the key does not exist, then return the default
        '
        If IsNothing(reg) Then
            GetReg = sDefault
        Else
            Try
                '
                ' return the value of the key
                '
                GetReg = reg.GetValue(sKey).ToString

                If IsNothing(GetReg) Then GetReg = sDefault

                reg.Close()
            Catch
                GetReg = sDefault
            End Try
        End If

    End Function

    '
    ' set a registry value to a key
    '
    Private Shared Sub SetReg(ByVal sPath As String, ByVal sKey As String, ByVal sVal As String)

        Dim reg As RegistryKey

        '
        ' open the path to the key
        '
        reg = Registry.LocalMachine.OpenSubKey(sPath, True)

        '
        ' if the key does not exist, then create it.
        '
        If IsNothing(reg) Then reg = Registry.LocalMachine.CreateSubKey(sPath)

        '
        ' set the key with the value
        '
        reg.SetValue(sKey, sVal)

        reg.Close()

    End Sub

    Private Const mstrAlpha As String = "ZyXwVuTsRqPoNmLkJiHgFeDcBa"

#End Region

End Class
