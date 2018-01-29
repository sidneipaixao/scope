﻿Public Class frmPedidos

    Private Sub frmPedidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'DESENHA BORDA DO FORMULARIO
        'NAO PODE MAXIMIZAR, SENAO COBRE BARRA DE TAREFAS DO WINDOWS, POR ISSO NAO USA WINDOWSTATE
        Top = 0
        Left = 0
        Width = Screen.GetWorkingArea(Me).Width
        Height = Screen.GetWorkingArea(Me).Height

        BackgroundImage = New Bitmap(Width - 1, Height - 1)
        Graphics.FromImage(BackgroundImage).DrawRectangle(New Pen(Color.FromArgb(55, 65, 80)), New Rectangle(New Point(0, 0), Size))

        objBuscaPedido_Tick(objBuscaPedido, Nothing)

    End Sub

    Private Sub cmdFechar_Click(sender As System.Object, e As System.EventArgs)
        Close()
    End Sub

  Private Sub lstPedidos_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lstPedidos.MouseClick

        If lstPedidos.SelectedItems.Count > 0 Then
            frmEncerrarPedido.fnCarregaDados(lstPedidos.SelectedItems(0).Name.ToString.Remove(0, 3))
            frmEncerrarPedido.txtEmail.Text = lstPedidos.SelectedItems(0).SubItems(2).Text
            frmEncerrarPedido.Show()
        End If

  End Sub

    Private Sub cmdFechar_Click_1(sender As System.Object, e As System.EventArgs) Handles cmdFechar.Click

        Close()

    End Sub

    Private Sub objBuscaPedido_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objBuscaPedido.Tick

        'Dim oCon As New MySql.Data.MySqlClient.MySqlConnection
        'oCon.ConnectionString = "Persist Security Info=False;datasource=admlojas.dyndns.org;port=3307;username=vb;password=vb;database=Lpc_production"
        'oCon.Open()

        'Dim oMySQLCmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT id CODPEDIDO, identificacao NOME, '' CONTRATO, fidelidade EMAIL FROM vendas WHERE impresso = 'n'", oCon)
        'Dim oPedidos As MySql.Data.MySqlClient.MySqlDataReader = oMySQLCmd.ExecuteReader

        ''Dim oSenha As New BCrypt.Net.BCrypt

        ''If oPedidos.Read Then

        'lstPedidos.Items.Clear()

        ''MessageBox.Show(oPedidos("CONTADOR"))

        'While oPedidos.Read
        '    With lstPedidos.Items.Add("PDD" & oPedidos("CODPEDIDO"), oPedidos("NOME") & "", 0)
        '        .UseItemStyleForSubItems = False
        '        .SubItems.Add(oPedidos("CONTRATO") & " ", Color.IndianRed, lstPedidos.BackColor, New Font(lstPedidos.Font.Name, 12, FontStyle.Bold))
        '        .SubItems.Add(oPedidos("EMAIL") & " ", Color.IndianRed, lstPedidos.BackColor, New Font(lstPedidos.Font.Name, 12, FontStyle.Bold))
        '    End With
        'End While

        'oPedidos.Close()

        ''End If













        ''EXECUTA A CHAMADA DA ROTINA NA BASE DE DADOS
        'oComando.CommandText = "SP_BUSCAPEDIDO"
        'oComando.CommandTimeout = 600
        'oComando.ExecuteNonQuery()

        Dim oPedidos As SqlClient.SqlDataReader = fnRetornaDados("SELECT VNDCODIGO CODPEDIDO, VNDCLIENTENOME NOME, '' CONTRATO, VNDCLIENTEEMAIL EMAIL FROM vendas WHERE VNDCOMANDA IS NULL")

        lstPedidos.Items.Clear()

        'CARREGA PEDIDOS DA BASE DE DADOS
        While oPedidos.Read
            With lstPedidos.Items.Add("PDD" & oPedidos("CODPEDIDO"), oPedidos("NOME") & "", 0)
                .UseItemStyleForSubItems = False
                .SubItems.Add(oPedidos("CONTRATO") & " ", Color.IndianRed, lstPedidos.BackColor, New Font(lstPedidos.Font.Name, 12, FontStyle.Bold))
                .SubItems.Add(oPedidos("EMAIL") & " ", Color.IndianRed, lstPedidos.BackColor, New Font(lstPedidos.Font.Name, 12, FontStyle.Bold))
            End With
        End While

        oPedidos.Close()

        oPedidos = fnRetornaDados("SELECT TOP 20 VNDCODIGO CODPEDIDO, VNDCLIENTENOME NOME, '' CONTRATO, VNDCLIENTEEMAIL EMAIL FROM vendas WHERE VNDCOMANDA IS NOT NULL ORDER BY VNDCODIGO DESC")

        lstRecentes.Items.Clear()

        'CARREGA PEDIDOS DA BASE DE DADOS
        While oPedidos.Read
            With lstRecentes.Items.Add("PDD" & oPedidos("CODPEDIDO"), oPedidos("NOME") & "", 0)
                .UseItemStyleForSubItems = False
                .SubItems.Add(oPedidos("CONTRATO") & " ", Color.IndianRed, lstPedidos.BackColor, New Font(lstPedidos.Font.Name, 12, FontStyle.Bold))
                .SubItems.Add(oPedidos("EMAIL") & " ", Color.IndianRed, lstPedidos.BackColor, New Font(lstPedidos.Font.Name, 12, FontStyle.Bold))
            End With
        End While

        oPedidos.Close()

    End Sub

End Class