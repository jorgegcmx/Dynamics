'*********************************************************
'
'    Copyright (c) Microsoft. All rights reserved.
'    This code is licensed under the Microsoft Public License.
'    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
'    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
'    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
'    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
'
'*********************************************************
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Update1 = New Interop.SAF.SAFUpdate
        Me.SAFHelpProvider = New System.Windows.Forms.HelpProvider
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dblTotalGeneralMXN = New Interop.SAF.SAFFloat
        Me.Label42 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.dblOrdProve = New Interop.SAF.SAFFloat
        Me.dblProve = New Interop.SAF.SAFFloat
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.dblOrdReorden = New Interop.SAF.SAFFloat
        Me.dblReorden = New Interop.SAF.SAFFloat
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.dblOrdExtra = New Interop.SAF.SAFFloat
        Me.dblExtra = New Interop.SAF.SAFFloat
        Me.lblmensage = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.dbltotalcompra = New Interop.SAF.SAFFloat
        Me.dbltotalAuto = New Interop.SAF.SAFFloat
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SafCombo2 = New Interop.SAF.SAFCombo
        Me.SafCombo1 = New Interop.SAF.SAFCombo
        Me.btnCargarInformacion = New System.Windows.Forms.Button
        Me.txtNoLote = New Interop.SAF.SAFMaskedText
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.SafMaskedText5 = New Interop.SAF.SAFMaskedText
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtObservaciones = New Interop.SAF.SAFMaskedText
        Me.txttipo = New Interop.SAF.SAFMaskedText
        Me.Label24 = New System.Windows.Forms.Label
        Me.floRedondeo = New Interop.SAF.SAFFloat
        Me.Label23 = New System.Windows.Forms.Label
        Me.floAmacen = New Interop.SAF.SAFFloat
        Me.Label22 = New System.Windows.Forms.Label
        Me.SafFloat9 = New Interop.SAF.SAFFloat
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtobservacionescost = New Interop.SAF.SAFMaskedText
        Me.dblPesos = New Interop.SAF.SAFFloat
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.floDiferencia = New Interop.SAF.SAFFloat
        Me.SafFloat3 = New Interop.SAF.SAFFloat
        Me.SafInteger1 = New Interop.SAF.SAFInteger
        Me.SafFloat6 = New Interop.SAF.SAFFloat
        Me.SafFloat5 = New Interop.SAF.SAFFloat
        Me.SafFloat4 = New Interop.SAF.SAFFloat
        Me.SafFloat2 = New Interop.SAF.SAFFloat
        Me.SafFloat1 = New Interop.SAF.SAFFloat
        Me.gridreport = New Interop.SAF.SAFGrid
        Me.txtDescripcion = New Interop.SAF.SAFMaskedText
        Me.txtArticulo = New Interop.SAF.SAFMaskedText
        Me.txtNombreProveedor = New Interop.SAF.SAFMaskedText
        Me.txtProveedor = New Interop.SAF.SAFMaskedText
        Me.txtSemana = New Interop.SAF.SAFMaskedText
        Me.Label20 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.SafMaskedText1 = New Interop.SAF.SAFMaskedText
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.cboStatus0 = New Interop.SAF.SAFCombo
        Me.DvgGrid3 = New Interop.SAF.SAFGrid
        Me.txtPersonaSol3 = New Interop.SAF.SAFMaskedText
        Me.txtAreaSoli3 = New Interop.SAF.SAFMaskedText
        Me.txtNoLote3 = New Interop.SAF.SAFMaskedText
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cboTipoRequi = New Interop.SAF.SAFCombo
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.SafMaskedText4 = New Interop.SAF.SAFMaskedText
        Me.SafMaskedText3 = New Interop.SAF.SAFMaskedText
        Me.SafMaskedText2 = New Interop.SAF.SAFMaskedText
        Me.gridOrdenes = New Interop.SAF.SAFGrid
        CType(Me.Update1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dblTotalGeneralMXN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dblOrdProve, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dblProve, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dblOrdReorden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dblReorden, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dblOrdExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dblExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbltotalcompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbltotalAuto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafCombo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafCombo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoLote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.SafMaskedText5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.floRedondeo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.floAmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafFloat9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtobservacionescost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dblPesos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.floDiferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafFloat3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafInteger1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafFloat6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafFloat5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafFloat4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafFloat2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafFloat1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridreport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.SafMaskedText1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStatus0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DvgGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPersonaSol3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAreaSoli3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoLote3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.cboTipoRequi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafMaskedText4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafMaskedText3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SafMaskedText2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Update1
        '
        Me.Update1.Enabled = True
        Me.Update1.Location = New System.Drawing.Point(225, 160)
        Me.Update1.Name = "Update1"
        Me.Update1.OcxState = CType(resources.GetObject("Update1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Update1.Size = New System.Drawing.Size(26, 26)
        Me.Update1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dblTotalGeneralMXN)
        Me.GroupBox2.Controls.Add(Me.Label42)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.dblOrdProve)
        Me.GroupBox2.Controls.Add(Me.dblProve)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.dblOrdReorden)
        Me.GroupBox2.Controls.Add(Me.dblReorden)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.dblOrdExtra)
        Me.GroupBox2.Controls.Add(Me.dblExtra)
        Me.GroupBox2.Controls.Add(Me.lblmensage)
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.dbltotalcompra)
        Me.GroupBox2.Controls.Add(Me.dbltotalAuto)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.SafCombo2)
        Me.GroupBox2.Controls.Add(Me.SafCombo1)
        Me.GroupBox2.Controls.Add(Me.btnCargarInformacion)
        Me.GroupBox2.Controls.Add(Me.txtNoLote)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1101, 114)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'dblTotalGeneralMXN
        '
        Me.dblTotalGeneralMXN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dblTotalGeneralMXN.Location = New System.Drawing.Point(799, 30)
        Me.dblTotalGeneralMXN.Name = "dblTotalGeneralMXN"
        Me.dblTotalGeneralMXN.OcxState = CType(resources.GetObject("dblTotalGeneralMXN.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dblTotalGeneralMXN.Size = New System.Drawing.Size(157, 23)
        Me.dblTotalGeneralMXN.TabIndex = 134
        '
        'Label42
        '
        Me.Label42.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(813, 13)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(98, 13)
        Me.Label42.TabIndex = 133
        Me.Label42.Text = "Total General MXN"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(964, 70)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(134, 23)
        Me.Button3.TabIndex = 132
        Me.Button3.Text = "Validar Observaciones"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(612, 81)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(52, 13)
        Me.Label34.TabIndex = 129
        Me.Label34.Text = "En Orden"
        '
        'Label35
        '
        Me.Label35.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(344, 83)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(123, 13)
        Me.Label35.TabIndex = 128
        Me.Label35.Text = "Importe Total Boehringer"
        '
        'dblOrdProve
        '
        Me.dblOrdProve.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dblOrdProve.Location = New System.Drawing.Point(668, 75)
        Me.dblOrdProve.Name = "dblOrdProve"
        Me.dblOrdProve.OcxState = CType(resources.GetObject("dblOrdProve.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dblOrdProve.Size = New System.Drawing.Size(111, 19)
        Me.dblOrdProve.TabIndex = 127
        '
        'dblProve
        '
        Me.dblProve.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dblProve.Location = New System.Drawing.Point(486, 75)
        Me.dblProve.Name = "dblProve"
        Me.dblProve.OcxState = CType(resources.GetObject("dblProve.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dblProve.Size = New System.Drawing.Size(118, 19)
        Me.dblProve.TabIndex = 126
        '
        'Label32
        '
        Me.Label32.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(612, 59)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(52, 13)
        Me.Label32.TabIndex = 125
        Me.Label32.Text = "En Orden"
        '
        'Label33
        '
        Me.Label33.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(344, 61)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(113, 13)
        Me.Label33.TabIndex = 124
        Me.Label33.Text = "Importe Total Reorden"
        '
        'dblOrdReorden
        '
        Me.dblOrdReorden.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dblOrdReorden.Location = New System.Drawing.Point(668, 53)
        Me.dblOrdReorden.Name = "dblOrdReorden"
        Me.dblOrdReorden.OcxState = CType(resources.GetObject("dblOrdReorden.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dblOrdReorden.Size = New System.Drawing.Size(111, 19)
        Me.dblOrdReorden.TabIndex = 123
        '
        'dblReorden
        '
        Me.dblReorden.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dblReorden.Location = New System.Drawing.Point(486, 53)
        Me.dblReorden.Name = "dblReorden"
        Me.dblReorden.OcxState = CType(resources.GetObject("dblReorden.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dblReorden.Size = New System.Drawing.Size(118, 19)
        Me.dblReorden.TabIndex = 122
        '
        'Label30
        '
        Me.Label30.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(612, 37)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(52, 13)
        Me.Label30.TabIndex = 121
        Me.Label30.Text = "En Orden"
        '
        'Label31
        '
        Me.Label31.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(344, 39)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(136, 13)
        Me.Label31.TabIndex = 120
        Me.Label31.Text = "Importe Total Extraordinario"
        '
        'dblOrdExtra
        '
        Me.dblOrdExtra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dblOrdExtra.Location = New System.Drawing.Point(668, 31)
        Me.dblOrdExtra.Name = "dblOrdExtra"
        Me.dblOrdExtra.OcxState = CType(resources.GetObject("dblOrdExtra.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dblOrdExtra.Size = New System.Drawing.Size(111, 19)
        Me.dblOrdExtra.TabIndex = 119
        '
        'dblExtra
        '
        Me.dblExtra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dblExtra.Location = New System.Drawing.Point(486, 31)
        Me.dblExtra.Name = "dblExtra"
        Me.dblExtra.OcxState = CType(resources.GetObject("dblExtra.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dblExtra.Size = New System.Drawing.Size(118, 19)
        Me.dblExtra.TabIndex = 118
        '
        'lblmensage
        '
        Me.lblmensage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblmensage.AutoSize = True
        Me.lblmensage.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmensage.Location = New System.Drawing.Point(6, 9)
        Me.lblmensage.Name = "lblmensage"
        Me.lblmensage.Size = New System.Drawing.Size(296, 20)
        Me.lblmensage.TabIndex = 117
        Me.lblmensage.Text = "Información Guardada Previamente"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 98)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1101, 10)
        Me.ProgressBar1.TabIndex = 116
        '
        'Label19
        '
        Me.Label19.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(612, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "En Orden"
        '
        'Label18
        '
        Me.Label18.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(344, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(122, 13)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Importe Total Autorizado"
        '
        'dbltotalcompra
        '
        Me.dbltotalcompra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dbltotalcompra.Location = New System.Drawing.Point(667, 9)
        Me.dbltotalcompra.Name = "dbltotalcompra"
        Me.dbltotalcompra.OcxState = CType(resources.GetObject("dbltotalcompra.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dbltotalcompra.Size = New System.Drawing.Size(112, 19)
        Me.dbltotalcompra.TabIndex = 22
        '
        'dbltotalAuto
        '
        Me.dbltotalAuto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dbltotalAuto.Location = New System.Drawing.Point(486, 9)
        Me.dbltotalAuto.Name = "dbltotalAuto"
        Me.dbltotalAuto.OcxState = CType(resources.GetObject("dbltotalAuto.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dbltotalAuto.Size = New System.Drawing.Size(118, 19)
        Me.dbltotalAuto.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(962, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Manejo"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(961, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Status"
        '
        'SafCombo2
        '
        Me.SafCombo2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SafCombo2.Location = New System.Drawing.Point(1005, 36)
        Me.SafCombo2.Name = "SafCombo2"
        Me.SafCombo2.OcxState = CType(resources.GetObject("SafCombo2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafCombo2.Size = New System.Drawing.Size(94, 21)
        Me.SafCombo2.TabIndex = 116
        '
        'SafCombo1
        '
        Me.SafCombo1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SafCombo1.Location = New System.Drawing.Point(1004, 10)
        Me.SafCombo1.Name = "SafCombo1"
        Me.SafCombo1.OcxState = CType(resources.GetObject("SafCombo1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafCombo1.Size = New System.Drawing.Size(94, 21)
        Me.SafCombo1.TabIndex = 17
        '
        'btnCargarInformacion
        '
        Me.btnCargarInformacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCargarInformacion.Location = New System.Drawing.Point(151, 33)
        Me.btnCargarInformacion.Name = "btnCargarInformacion"
        Me.btnCargarInformacion.Size = New System.Drawing.Size(118, 24)
        Me.btnCargarInformacion.TabIndex = 16
        Me.btnCargarInformacion.Text = "Mostrar Información"
        Me.btnCargarInformacion.UseVisualStyleBackColor = True
        Me.btnCargarInformacion.Visible = False
        '
        'txtNoLote
        '
        Me.txtNoLote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNoLote.Location = New System.Drawing.Point(62, 33)
        Me.txtNoLote.Name = "txtNoLote"
        Me.txtNoLote.OcxState = CType(resources.GetObject("txtNoLote.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtNoLote.Size = New System.Drawing.Size(80, 24)
        Me.txtNoLote.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Semana"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(889, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 24)
        Me.Button2.TabIndex = 131
        Me.Button2.Text = "Reclasificar Requisiciones Origen"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(662, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(221, 24)
        Me.Button1.TabIndex = 130
        Me.Button1.Text = "Cargar Requisiciones/Ordenes Boehringer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 570)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1101, 38)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TabControl1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 114)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1101, 456)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1095, 437)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1087, 411)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Informe"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label41)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.SafMaskedText5)
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.txtObservaciones)
        Me.GroupBox5.Controls.Add(Me.txttipo)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Controls.Add(Me.floRedondeo)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.floAmacen)
        Me.GroupBox5.Controls.Add(Me.Label22)
        Me.GroupBox5.Controls.Add(Me.SafFloat9)
        Me.GroupBox5.Controls.Add(Me.Label21)
        Me.GroupBox5.Controls.Add(Me.txtobservacionescost)
        Me.GroupBox5.Controls.Add(Me.dblPesos)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.floDiferencia)
        Me.GroupBox5.Controls.Add(Me.SafFloat3)
        Me.GroupBox5.Controls.Add(Me.SafInteger1)
        Me.GroupBox5.Controls.Add(Me.SafFloat6)
        Me.GroupBox5.Controls.Add(Me.SafFloat5)
        Me.GroupBox5.Controls.Add(Me.SafFloat4)
        Me.GroupBox5.Controls.Add(Me.SafFloat2)
        Me.GroupBox5.Controls.Add(Me.SafFloat1)
        Me.GroupBox5.Controls.Add(Me.gridreport)
        Me.GroupBox5.Controls.Add(Me.txtDescripcion)
        Me.GroupBox5.Controls.Add(Me.txtArticulo)
        Me.GroupBox5.Controls.Add(Me.txtNombreProveedor)
        Me.GroupBox5.Controls.Add(Me.txtProveedor)
        Me.GroupBox5.Controls.Add(Me.txtSemana)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1081, 405)
        Me.GroupBox5.TabIndex = 73
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "F4 para Forma/Tabla"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(407, 187)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(65, 13)
        Me.Label41.TabIndex = 118
        Me.Label41.Text = "Importe  MN"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(647, 66)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(62, 13)
        Me.Label40.TabIndex = 117
        Me.Label40.Text = "Requisicion"
        '
        'SafMaskedText5
        '
        Me.SafMaskedText5.Location = New System.Drawing.Point(715, 60)
        Me.SafMaskedText5.Name = "SafMaskedText5"
        Me.SafMaskedText5.OcxState = CType(resources.GetObject("SafMaskedText5.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafMaskedText5.Size = New System.Drawing.Size(85, 19)
        Me.SafMaskedText5.TabIndex = 1
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(681, 40)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(28, 13)
        Me.Label39.TabIndex = 116
        Me.Label39.Text = "Tipo"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(491, 281)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.OcxState = CType(resources.GetObject("txtObservaciones.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtObservaciones.Size = New System.Drawing.Size(272, 23)
        Me.txtObservaciones.TabIndex = 94
        '
        'txttipo
        '
        Me.txttipo.Location = New System.Drawing.Point(715, 32)
        Me.txttipo.Name = "txttipo"
        Me.txttipo.OcxState = CType(resources.GetObject("txttipo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txttipo.Size = New System.Drawing.Size(85, 23)
        Me.txttipo.TabIndex = 77
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(415, 230)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 13)
        Me.Label24.TabIndex = 114
        Me.Label24.Text = "Redondeo"
        '
        'floRedondeo
        '
        Me.floRedondeo.Location = New System.Drawing.Point(491, 232)
        Me.floRedondeo.Name = "floRedondeo"
        Me.floRedondeo.OcxState = CType(resources.GetObject("floRedondeo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.floRedondeo.Size = New System.Drawing.Size(84, 23)
        Me.floRedondeo.TabIndex = 92
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(425, 205)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(48, 13)
        Me.Label23.TabIndex = 113
        Me.Label23.Text = "Almacen"
        '
        'floAmacen
        '
        Me.floAmacen.Location = New System.Drawing.Point(491, 208)
        Me.floAmacen.Name = "floAmacen"
        Me.floAmacen.OcxState = CType(resources.GetObject("floAmacen.OcxState"), System.Windows.Forms.AxHost.State)
        Me.floAmacen.Size = New System.Drawing.Size(84, 23)
        Me.floAmacen.TabIndex = 91
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(388, 313)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(84, 13)
        Me.Label22.TabIndex = 112
        Me.Label22.Text = "Diferencias Cost"
        '
        'SafFloat9
        '
        Me.SafFloat9.Location = New System.Drawing.Point(491, 307)
        Me.SafFloat9.Name = "SafFloat9"
        Me.SafFloat9.OcxState = CType(resources.GetObject("SafFloat9.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafFloat9.Size = New System.Drawing.Size(84, 23)
        Me.SafFloat9.TabIndex = 96
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(361, 334)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(113, 13)
        Me.Label21.TabIndex = 111
        Me.Label21.Text = "Observaciones Costos"
        '
        'txtobservacionescost
        '
        Me.txtobservacionescost.Location = New System.Drawing.Point(491, 336)
        Me.txtobservacionescost.Name = "txtobservacionescost"
        Me.txtobservacionescost.OcxState = CType(resources.GetObject("txtobservacionescost.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtobservacionescost.Size = New System.Drawing.Size(272, 23)
        Me.txtobservacionescost.TabIndex = 98
        '
        'dblPesos
        '
        Me.dblPesos.Location = New System.Drawing.Point(491, 182)
        Me.dblPesos.Name = "dblPesos"
        Me.dblPesos.OcxState = CType(resources.GetObject("dblPesos.OcxState"), System.Windows.Forms.AxHost.State)
        Me.dblPesos.Size = New System.Drawing.Size(84, 23)
        Me.dblPesos.TabIndex = 90
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(326, 286)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(149, 13)
        Me.Label17.TabIndex = 110
        Me.Label17.Text = "Observaciones Cant, Articulos"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(416, 257)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 109
        Me.Label16.Text = "No.Partida"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(387, 160)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "Importe en Orden"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(397, 137)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 13)
        Me.Label14.TabIndex = 107
        Me.Label14.Text = "Cost. en Orden"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(394, 112)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 106
        Me.Label13.Text = "Cant. Ordenada"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(388, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 105
        Me.Label12.Text = "Importe Autorizado"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(372, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 13)
        Me.Label11.TabIndex = 104
        Me.Label11.Text = "Cost.Unit. Autorizado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(392, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 103
        Me.Label10.Text = "Cant. Autorizada"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(2, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "Descripción"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(2, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "Articulo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(2, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 99
        Me.Label6.Text = "Nombre"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Cod.Proveedor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "Semana"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "IDAuto"
        '
        'floDiferencia
        '
        Me.floDiferencia.Location = New System.Drawing.Point(491, 257)
        Me.floDiferencia.Name = "floDiferencia"
        Me.floDiferencia.OcxState = CType(resources.GetObject("floDiferencia.OcxState"), System.Windows.Forms.AxHost.State)
        Me.floDiferencia.Size = New System.Drawing.Size(84, 23)
        Me.floDiferencia.TabIndex = 93
        '
        'SafFloat3
        '
        Me.SafFloat3.Location = New System.Drawing.Point(491, 79)
        Me.SafFloat3.Name = "SafFloat3"
        Me.SafFloat3.OcxState = CType(resources.GetObject("SafFloat3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafFloat3.Size = New System.Drawing.Size(84, 23)
        Me.SafFloat3.TabIndex = 86
        '
        'SafInteger1
        '
        Me.SafInteger1.Location = New System.Drawing.Point(84, 25)
        Me.SafInteger1.Name = "SafInteger1"
        Me.SafInteger1.OcxState = CType(resources.GetObject("SafInteger1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafInteger1.Size = New System.Drawing.Size(63, 23)
        Me.SafInteger1.TabIndex = 115
        '
        'SafFloat6
        '
        Me.SafFloat6.Location = New System.Drawing.Point(491, 156)
        Me.SafFloat6.Name = "SafFloat6"
        Me.SafFloat6.OcxState = CType(resources.GetObject("SafFloat6.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafFloat6.Size = New System.Drawing.Size(84, 23)
        Me.SafFloat6.TabIndex = 89
        '
        'SafFloat5
        '
        Me.SafFloat5.Location = New System.Drawing.Point(491, 131)
        Me.SafFloat5.Name = "SafFloat5"
        Me.SafFloat5.OcxState = CType(resources.GetObject("SafFloat5.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafFloat5.Size = New System.Drawing.Size(84, 23)
        Me.SafFloat5.TabIndex = 88
        '
        'SafFloat4
        '
        Me.SafFloat4.Location = New System.Drawing.Point(491, 105)
        Me.SafFloat4.Name = "SafFloat4"
        Me.SafFloat4.OcxState = CType(resources.GetObject("SafFloat4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafFloat4.Size = New System.Drawing.Size(84, 23)
        Me.SafFloat4.TabIndex = 87
        '
        'SafFloat2
        '
        Me.SafFloat2.Location = New System.Drawing.Point(491, 55)
        Me.SafFloat2.Name = "SafFloat2"
        Me.SafFloat2.OcxState = CType(resources.GetObject("SafFloat2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafFloat2.Size = New System.Drawing.Size(84, 23)
        Me.SafFloat2.TabIndex = 85
        '
        'SafFloat1
        '
        Me.SafFloat1.Location = New System.Drawing.Point(491, 30)
        Me.SafFloat1.Name = "SafFloat1"
        Me.SafFloat1.OcxState = CType(resources.GetObject("SafFloat1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafFloat1.Size = New System.Drawing.Size(84, 23)
        Me.SafFloat1.TabIndex = 84
        '
        'gridreport
        '
        Me.gridreport.Location = New System.Drawing.Point(931, 263)
        Me.gridreport.Name = "gridreport"
        Me.gridreport.OcxState = CType(resources.GetObject("gridreport.OcxState"), System.Windows.Forms.AxHost.State)
        Me.gridreport.Size = New System.Drawing.Size(147, 84)
        Me.gridreport.TabIndex = 83
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(84, 154)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.OcxState = CType(resources.GetObject("txtDescripcion.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtDescripcion.Size = New System.Drawing.Size(205, 23)
        Me.txtDescripcion.TabIndex = 82
        '
        'txtArticulo
        '
        Me.txtArticulo.Location = New System.Drawing.Point(84, 129)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.OcxState = CType(resources.GetObject("txtArticulo.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtArticulo.Size = New System.Drawing.Size(63, 23)
        Me.txtArticulo.TabIndex = 81
        '
        'txtNombreProveedor
        '
        Me.txtNombreProveedor.Location = New System.Drawing.Point(84, 104)
        Me.txtNombreProveedor.Name = "txtNombreProveedor"
        Me.txtNombreProveedor.OcxState = CType(resources.GetObject("txtNombreProveedor.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtNombreProveedor.Size = New System.Drawing.Size(298, 23)
        Me.txtNombreProveedor.TabIndex = 80
        '
        'txtProveedor
        '
        Me.txtProveedor.Location = New System.Drawing.Point(84, 79)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.OcxState = CType(resources.GetObject("txtProveedor.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtProveedor.Size = New System.Drawing.Size(63, 23)
        Me.txtProveedor.TabIndex = 79
        '
        'txtSemana
        '
        Me.txtSemana.Location = New System.Drawing.Point(84, 54)
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.OcxState = CType(resources.GetObject("txtSemana.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtSemana.Size = New System.Drawing.Size(63, 23)
        Me.txtSemana.TabIndex = 78
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(429, 308)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(49, 13)
        Me.Label20.TabIndex = 72
        Me.Label20.Text = "Recibido"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1087, 411)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Requisiciones"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label25)
        Me.GroupBox6.Controls.Add(Me.SafMaskedText1)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.Label27)
        Me.GroupBox6.Controls.Add(Me.Label28)
        Me.GroupBox6.Controls.Add(Me.Label29)
        Me.GroupBox6.Controls.Add(Me.cboStatus0)
        Me.GroupBox6.Controls.Add(Me.DvgGrid3)
        Me.GroupBox6.Controls.Add(Me.txtPersonaSol3)
        Me.GroupBox6.Controls.Add(Me.txtAreaSoli3)
        Me.GroupBox6.Controls.Add(Me.txtNoLote3)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox6.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1081, 405)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "F4 para Forma/Tabla"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(12, 148)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(28, 13)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "Tipo"
        '
        'SafMaskedText1
        '
        Me.SafMaskedText1.Location = New System.Drawing.Point(88, 139)
        Me.SafMaskedText1.Name = "SafMaskedText1"
        Me.SafMaskedText1.OcxState = CType(resources.GetObject("SafMaskedText1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafMaskedText1.Size = New System.Drawing.Size(123, 22)
        Me.SafMaskedText1.TabIndex = 0
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(12, 120)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 13)
        Me.Label26.TabIndex = 28
        Me.Label26.Text = "Persona Solic"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(14, 98)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(55, 13)
        Me.Label27.TabIndex = 27
        Me.Label27.Text = "Area Solic"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(14, 73)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(37, 13)
        Me.Label28.TabIndex = 26
        Me.Label28.Text = "Status"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(14, 42)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(28, 13)
        Me.Label29.TabIndex = 25
        Me.Label29.Text = "Lote"
        '
        'cboStatus0
        '
        Me.cboStatus0.Location = New System.Drawing.Point(88, 65)
        Me.cboStatus0.Name = "cboStatus0"
        Me.cboStatus0.OcxState = CType(resources.GetObject("cboStatus0.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cboStatus0.Size = New System.Drawing.Size(123, 21)
        Me.cboStatus0.TabIndex = 23
        '
        'DvgGrid3
        '
        Me.DvgGrid3.Location = New System.Drawing.Point(909, 308)
        Me.DvgGrid3.Name = "DvgGrid3"
        Me.DvgGrid3.OcxState = CType(resources.GetObject("DvgGrid3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DvgGrid3.Size = New System.Drawing.Size(166, 74)
        Me.DvgGrid3.TabIndex = 5
        '
        'txtPersonaSol3
        '
        Me.txtPersonaSol3.Location = New System.Drawing.Point(88, 114)
        Me.txtPersonaSol3.Name = "txtPersonaSol3"
        Me.txtPersonaSol3.OcxState = CType(resources.GetObject("txtPersonaSol3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtPersonaSol3.Size = New System.Drawing.Size(123, 19)
        Me.txtPersonaSol3.TabIndex = 4
        '
        'txtAreaSoli3
        '
        Me.txtAreaSoli3.Location = New System.Drawing.Point(88, 91)
        Me.txtAreaSoli3.Name = "txtAreaSoli3"
        Me.txtAreaSoli3.OcxState = CType(resources.GetObject("txtAreaSoli3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtAreaSoli3.Size = New System.Drawing.Size(123, 19)
        Me.txtAreaSoli3.TabIndex = 3
        '
        'txtNoLote3
        '
        Me.txtNoLote3.Location = New System.Drawing.Point(88, 42)
        Me.txtNoLote3.Name = "txtNoLote3"
        Me.txtNoLote3.OcxState = CType(resources.GetObject("txtNoLote3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.txtNoLote3.Size = New System.Drawing.Size(123, 19)
        Me.txtNoLote3.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox7)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1087, 411)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Ordenes y sus Requis Origen"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cboTipoRequi)
        Me.GroupBox7.Controls.Add(Me.Label43)
        Me.GroupBox7.Controls.Add(Me.Label38)
        Me.GroupBox7.Controls.Add(Me.Label37)
        Me.GroupBox7.Controls.Add(Me.Label36)
        Me.GroupBox7.Controls.Add(Me.SafMaskedText4)
        Me.GroupBox7.Controls.Add(Me.SafMaskedText3)
        Me.GroupBox7.Controls.Add(Me.SafMaskedText2)
        Me.GroupBox7.Controls.Add(Me.gridOrdenes)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(1087, 411)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "F4 para Forma/Tabla"
        '
        'cboTipoRequi
        '
        Me.cboTipoRequi.Location = New System.Drawing.Point(110, 147)
        Me.cboTipoRequi.Name = "cboTipoRequi"
        Me.cboTipoRequi.OcxState = CType(resources.GetObject("cboTipoRequi.OcxState"), System.Windows.Forms.AxHost.State)
        Me.cboTipoRequi.Size = New System.Drawing.Size(113, 21)
        Me.cboTipoRequi.TabIndex = 41
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(5, 155)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(28, 13)
        Me.Label43.TabIndex = 12
        Me.Label43.Text = "Tipo"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(5, 124)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(46, 13)
        Me.Label38.TabIndex = 10
        Me.Label38.Text = "Semana"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(5, 96)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(96, 13)
        Me.Label37.TabIndex = 9
        Me.Label37.Text = "Requisicion Origen"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(6, 71)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(75, 13)
        Me.Label36.TabIndex = 8
        Me.Label36.Text = "Orden Compra"
        '
        'SafMaskedText4
        '
        Me.SafMaskedText4.Location = New System.Drawing.Point(112, 59)
        Me.SafMaskedText4.Name = "SafMaskedText4"
        Me.SafMaskedText4.OcxState = CType(resources.GetObject("SafMaskedText4.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafMaskedText4.Size = New System.Drawing.Size(112, 25)
        Me.SafMaskedText4.TabIndex = 5
        '
        'SafMaskedText3
        '
        Me.SafMaskedText3.Location = New System.Drawing.Point(111, 112)
        Me.SafMaskedText3.Name = "SafMaskedText3"
        Me.SafMaskedText3.OcxState = CType(resources.GetObject("SafMaskedText3.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafMaskedText3.Size = New System.Drawing.Size(112, 25)
        Me.SafMaskedText3.TabIndex = 7
        '
        'SafMaskedText2
        '
        Me.SafMaskedText2.Location = New System.Drawing.Point(112, 87)
        Me.SafMaskedText2.Name = "SafMaskedText2"
        Me.SafMaskedText2.OcxState = CType(resources.GetObject("SafMaskedText2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SafMaskedText2.Size = New System.Drawing.Size(112, 22)
        Me.SafMaskedText2.TabIndex = 6
        '
        'gridOrdenes
        '
        Me.gridOrdenes.Location = New System.Drawing.Point(881, 302)
        Me.gridOrdenes.Name = "gridOrdenes"
        Me.gridOrdenes.OcxState = CType(resources.GetObject("gridOrdenes.OcxState"), System.Windows.Forms.AxHost.State)
        Me.gridOrdenes.Size = New System.Drawing.Size(201, 86)
        Me.gridOrdenes.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 608)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Update1)
        Me.Name = "Form1"
        Me.Text = "Captura de Observaciones Presupuesto Medicamentos y Vacunas(NU.206.RQ)"
        CType(Me.Update1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dblTotalGeneralMXN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dblOrdProve, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dblProve, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dblOrdReorden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dblReorden, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dblOrdExtra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dblExtra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbltotalcompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbltotalAuto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafCombo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafCombo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoLote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.SafMaskedText5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.floRedondeo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.floAmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafFloat9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtobservacionescost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dblPesos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.floDiferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafFloat3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafInteger1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafFloat6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafFloat5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafFloat4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafFloat2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafFloat1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridreport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.SafMaskedText1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStatus0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DvgGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPersonaSol3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAreaSoli3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoLote3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.cboTipoRequi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafMaskedText4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafMaskedText3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SafMaskedText2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Update1 As Interop.SAF.SAFUpdate
    Friend WithEvents SAFHelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dbltotalcompra As Interop.SAF.SAFFloat
    Friend WithEvents dbltotalAuto As Interop.SAF.SAFFloat
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SafCombo2 As Interop.SAF.SAFCombo
    Friend WithEvents SafCombo1 As Interop.SAF.SAFCombo
    Friend WithEvents btnCargarInformacion As System.Windows.Forms.Button
    Friend WithEvents txtNoLote As Interop.SAF.SAFMaskedText
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblmensage As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents dblOrdExtra As Interop.SAF.SAFFloat
    Friend WithEvents dblExtra As Interop.SAF.SAFFloat
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents dblOrdReorden As Interop.SAF.SAFFloat
    Friend WithEvents dblReorden As Interop.SAF.SAFFloat
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents dblOrdProve As Interop.SAF.SAFFloat
    Friend WithEvents dblProve As Interop.SAF.SAFFloat
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents SafMaskedText5 As Interop.SAF.SAFMaskedText
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As Interop.SAF.SAFMaskedText
    Friend WithEvents txttipo As Interop.SAF.SAFMaskedText
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents floRedondeo As Interop.SAF.SAFFloat
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents floAmacen As Interop.SAF.SAFFloat
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents SafFloat9 As Interop.SAF.SAFFloat
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtobservacionescost As Interop.SAF.SAFMaskedText
    Friend WithEvents dblPesos As Interop.SAF.SAFFloat
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents floDiferencia As Interop.SAF.SAFFloat
    Friend WithEvents SafFloat3 As Interop.SAF.SAFFloat
    Friend WithEvents SafInteger1 As Interop.SAF.SAFInteger
    Friend WithEvents SafFloat6 As Interop.SAF.SAFFloat
    Friend WithEvents SafFloat5 As Interop.SAF.SAFFloat
    Friend WithEvents SafFloat4 As Interop.SAF.SAFFloat
    Friend WithEvents SafFloat2 As Interop.SAF.SAFFloat
    Friend WithEvents SafFloat1 As Interop.SAF.SAFFloat
    Friend WithEvents gridreport As Interop.SAF.SAFGrid
    Friend WithEvents txtDescripcion As Interop.SAF.SAFMaskedText
    Friend WithEvents txtArticulo As Interop.SAF.SAFMaskedText
    Friend WithEvents txtNombreProveedor As Interop.SAF.SAFMaskedText
    Friend WithEvents txtProveedor As Interop.SAF.SAFMaskedText
    Friend WithEvents txtSemana As Interop.SAF.SAFMaskedText
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents SafMaskedText1 As Interop.SAF.SAFMaskedText
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboStatus0 As Interop.SAF.SAFCombo
    Friend WithEvents DvgGrid3 As Interop.SAF.SAFGrid
    Friend WithEvents txtPersonaSol3 As Interop.SAF.SAFMaskedText
    Friend WithEvents txtAreaSoli3 As Interop.SAF.SAFMaskedText
    Friend WithEvents txtNoLote3 As Interop.SAF.SAFMaskedText
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents SafMaskedText4 As Interop.SAF.SAFMaskedText
    Friend WithEvents SafMaskedText3 As Interop.SAF.SAFMaskedText
    Friend WithEvents SafMaskedText2 As Interop.SAF.SAFMaskedText
    Friend WithEvents gridOrdenes As Interop.SAF.SAFGrid
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents dblTotalGeneralMXN As Interop.SAF.SAFFloat
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cboTipoRequi As Interop.SAF.SAFCombo

End Class
