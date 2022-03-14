Imports time_recorder_service

Public Class sfrmUserProfiles
    Public Employees As New List(Of Model.Employee)
    Private Employee As New Model.Employee
    Public FaceManager As VerilookLib2.Manager.Verilook

    Private Function checkFaceAvailable(_user As Model.Employee) As Boolean
        Dim value As Boolean = Not (_user.FaceImage_1 Is Nothing Or _user.FaceImage_2 Is Nothing Or _user.FaceImage_3 Is Nothing)
        If value Then
            lbMessage2.ForeColor = Color.MidnightBlue
            lbMessage2.Text = "Your Face has been registered."
        Else
            lbMessage2.ForeColor = Color.Maroon
            lbMessage2.Text = "Your Face is not yet registered."
        End If
        Return value
    End Function

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub sfrmUserProfiles_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadEmployeesToDGV()
        cbSearchOption.SelectedIndex = 0
    End Sub

    Public Sub LoadEmployeesToDGV()
        dgv.Rows.Clear()
        DatabaseManager.Connection.Open()
        Employees = Controller.Employee.CollectEmployees(DatabaseManager)
        For Each employee As Model.Employee In Employees
            With employee
                dgv.Rows.Add(employee, .first_name, .last_name, .MI, .Active, .admin)
            End With
        Next
        DatabaseManager.Connection.Close()
    End Sub

    Private Sub dgv_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv.CurrentCellChanged
        If Not dgv.Rows.Count = 0 And dgv.CurrentRow IsNot Nothing Then
            employee = dgv.CurrentRow.Cells(0).Value
            With Employee
                tbEmployeeNumber.Text = .Employee_Id
                tbFirstName.Text = .first_name
                tbLastName.Text = .last_name
                tbMiddleName.Text = .middle_name
                cbAdmin.Checked = .admin
                cbActive.Checked = .Active

                cbActive.Enabled = (.NoFaceImage = False)
            End With
            checkFaceAvailable(employee)
        End If
    End Sub


    Private Sub btnRegFace_Click(sender As Object, e As EventArgs) Handles btnRegFace.Click
        If checkFaceAvailable(employee) Then
            If MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Else : Exit Sub
            End If
        End If

        VerilookLib2.Controller.Verilook.EditFaceTemplate(FaceManager, Employee)
        checkFaceAvailable(employee)
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim changes As New List(Of String)
        With Employee

            .Employee_Id = tbEmployeeNumber.Text
            .admin = cbAdmin.Checked
            .Active = cbActive.Checked

            .owner = Environment.GetEnvironmentVariable("USERDOMAIN")

            Controller.Employee.SaveEmployee(DatabaseManager, employee)
        End With


        With dgv.CurrentRow
            .Cells(0).Value = Employee.Employee_Id
            .Cells(1).Value = Employee.first_name
            .Cells(2).Value = Employee.last_name
            .Cells(3).Value = Employee.middle_name
            .Cells(8).Value = Employee.Active
            .Cells(9).Value = Employee.admin
        End With

        MsgBox("All Changes Has been Saved.")
    End Sub

    'Private Sub tbSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSearch.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        btnSearch.PerformClick()
    '    End If
    'End Sub

    Private Sub cbSearchAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles cbSearchAdmin.CheckedChanged, cbSearchActive.CheckedChanged
        'NOTE: Create Controller.Employee.FilterEmployees
        'readUserDB(Employees)
    End Sub


    'Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    '    filteredUserDB = New EmployeeRecordCollection
    '    Select Case cbSearchOption.Text.ToUpper
    '        Case "EMPLOYEE NUMBER"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.Employee_Id.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "COMPANY"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.company.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "DEPARTMENT"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.department.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "FIRSTNAME"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.first_name.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "LASTNAME"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.last_name.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case "MIDDLE INITIAL"
    '            filteredUserDB.AddRange(
    '                (From res In employees Where res.MI.ToUpper = tbSearch.Text And res.admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
    '        Case Else
    '            Exit Sub
    '    End Select
    '    readUserDB(filteredUserDB)
    'End Sub
End Class