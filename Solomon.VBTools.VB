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
Option Explicit On
Option Strict Off
#Const SHAREPOINT_UI = True

' A Dynamics SL SDK applciation requires referenecres to the following assemblies
'   Solomon.Kernel.dll
'   Interop.SAF.dll
'   Interop.SAFTypeLib.dll
'   Microsoft.VisualBasic.Compatibility.dll
'   
Imports Solomon.Kernel                      ' requires a reference to Solomon.Kernel
Imports Solomon.Kernel.Exports
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports VB = Microsoft.VisualBasic
Imports Microsoft.VisualBasic.Compatibility ' requires a reference to Microsoft.VisualBasic.Compatibility in the project
Imports System.ComponentModel

Module VBTools
    'Menu Buttons
    Friend Enum ToolBarButton As Integer
        GoToSite = 1024
        CreateSite = 512
    End Enum
    ' I needed to use a different name here because SendMessage was defined in other
    ' pieces of code and this line here was causing Ambigous defined issues in
    ' building other applications.
    Declare Function SendMessage_to_SWim Lib "user32.dll" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wmsg As Int32, ByVal wparam As Int32, ByVal lparam As Int32) As Int32

    ' Begin Applic.dh ************************************************************************************************
    ' MUST match corresponding define in define.h and swim.bas
    Public Const APPLIC_VER As String = "00.27"
    Public Const PARENT_VER As String = "00.25"
    Public Const PARENT_APP_NAME As String = "MSDynamicsSL.exe"

    Private InScreenExit As Boolean = False

    Structure SumInteger ' Declare of field to be passed to sum(integer_field) fetch statement
        Dim l As Integer
    End Structure

    'Structure Integer
    '	Dim l As Integer
    'End Structure

    'Structure Integer
    '	Dim l As Integer
    'End Structure

    Structure Sinteger
        Dim l As Short
    End Structure

    Structure Ssingle
        Dim l As Single
    End Structure

    Structure Sdouble
        Dim l As Double
    End Structure

    Structure Sstring
        Dim l As String
    End Structure

    Structure Slong
        Dim l As Integer
    End Structure

    '   Important dcls follow
    Public Const MinLVARLen As Short = 257 ' Min nbr of bytes for LVAR field
    Public NL As New VB6.FixedLengthString(2) ' Newline (carraige return, line feed)
    Public PRMSEP As String ' Application parameter seperator.
    Public Const NoAutoChk As Short = 0 ' Suppress any auto error checking SWIM would normally perform (e.g. pvchk()) after a CHK event is finished
    Public Const NoAction As Short = 0 ' Suppress any default action SWIM would normally perform when the event code has returned
    Public Const ErrNoMess As Short = 32000 ' Suppress error display SWIM would normally perform (e.g. pvchk()) if CHK returns error value
    Public Const Finished As Short = 32000 ' value of "level" in Update event, after other levels process sucessfully
    Public Const UpdateStart As Short = 32001 'UpdateStart pass of Update1
    Public Const IntMax As Short = 32767
    Public Const IntMin As Short = -32768
    Public Const MaxLineNbrInc As Short = 1 ' used for detail line numbering
    ' Note this DOES NOT correspond to the
    ' system's renumbering logic; this is
    ' for application use only
    Public Const FltMax As Double = 3.402823E+38
    Public Const OVERFLOW As Double = FltMax
    Public Const PREC_OVERFLOW As Short = 16
    Public Const EXCEPTION_ON As Short = -1 ' used in sqlerrexception
    Public Const EXCEPTION_OFF As Short = 0 ' used in sqlerrexception
    Public Const RETURN_ALL_ERRVALS As Short = -9999 ' used in sqlerrexception

    ' Used as 1st parm to Status() call
    Public Const EndProcess As Short = -2
    Public Const StartProcess As Short = -3
    Public Const SaveGoodArgVals As Short = -4
    Public Const SetEntityType As Short = -5
    Public Const StopProcess As Short = -6

    ' Used as 4th parm to Status() call
    Public Const LOG_ONLY As Short = 1
    Public Const DISP_ONLY As Short = 2
    Public Const LOG_AND_DISP As Short = 3

    ' property id to be passed to setprop
    Public Const PROP_VISIBLE As String = "Visible"
    Public Const PROP_DEFAULT As String = "Default"
    Public Const PROP_BLANKERR As String = "Blankerr"
    Public Const PROP_ENABLED As String = "Enabled"
    Public Const PROP_MASK As String = "Mask"
    Public Const PROP_CUSTLIST As String = "List"
    Public Const PROP_TABSTOP As String = "Tabstop"
    Public Const PROP_MIN As String = "Min"
    Public Const PROP_MAX As String = "Max"
    Public Const PROP_HEADING As String = "Heading"
    Public Const PROP_CAPTION As String = "Caption"

    Public Const COMMONFILES_REGISTRYENTRY As String = "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DynamicsSL"
    Public Const INSTALLATION_REGISTRYENTRY As String = "HKEY_LOCAL_MACHINE\Software\Solomon\Solomon IV Tools For Visual Basic"
    Public Const INSTALLATION_REGISTRYKEY As String = "ParentDirectory"
    Public Const COMMONFILES_REGISTRYKEY As String = "CommonFiles"
    Public Const HELP_PROVIDERNAME As String = "SAFHelpProvider"
    Public Const HELP_BRANDINGNAME As String = "SL_"
    Public Const HELP_FOLDERNAME As String = "Help"
    Public Const HELP_FILEEXT As String = ".chm"
    Public Const HELP_TOC As String = "toc"
    Public Const DEFAULT_HELPDIRECTORY As String = "SM"

    Public Const LTRUE As Short = 1 ' XQL logical TRUE
    Public Const LFALSE As Short = 0 ' XQL logical FALSE
    Public Const SQLWILDSTRING As String = "%" ' SQL wildcard for "like" restriction
    Public Const SQLWILDCHAR As String = "_" ' SQL wildcard for "like" restriction, 1 char

    '  sqlcursor() and sqlcursorex() parameter defines
    Public Const SqlList As Short = 32 ' Buffer rows (read ahead) defined by this cursor
    Public Const SqlUpdate As Short = 0 ' For upward compatability only
    Public Const SqlLock As Short = &H1000S ' Every row fetched with this type of cursor will be immediately locked.
    ' Rows fetched with this type of cursor should only be fetched
    ' within a transaction (to avoid db server dependant behavior).
    Public Const SqlFastReadOnly As Short = &H100S ' No updates,inserts, or deletes will be performed on the cursor.
    ' NOTE: Cursors with this flag cannot access tables which
    '       other cursors have updated in the same transaction.
    Public Const SqlNoSelect As Short = &H200S ' Indicates that the cursor will be used with any sql statement
    ' except Select.  Update and Delete statements will be the most
    ' common usage of this type of cursor.
    Public Const SqlNoList As Short = &H400S ' This flag instructs SWIM not to perform any buffering on this
    ' cursor during sfetch calls.
    Public Const SqlSingleRow As Short = &H2000S ' Indicates cursor will never read more then 1 row after each select
    ' statement (or stored procedure containing a select statement) has
    ' been compiled. sfetch calls with this type of cursor should not be
    ' separated from the associated sql call by any other db I/O.  The
    ' easiest way to accomplish this is via the sqlfetch functon.  Update,
    ' inserts, and deletes are allowed with this type of cursor.
    Public Const SqlSystemDb As Short = &H4000S ' Cursor is only to be used for system db tables
    Public Const SqlReadOnly As Short = &H8000S ' No updates,inserts, or deletes will be performed on the cursor.
    ' NOTE: This flag also implies a simple Fetch First,
    ' Fetch Next call sequence.  Once NOTFOUND is returned,
    ' no more Fetch calls can be sent.
    Public Const NOLEVEL As Short = 15
    Public Const LEVEL0 As Short = 0
    Public Const LEVEL1 As Short = 1
    Public Const LEVEL2 As Short = 2
    Public Const LEVEL3 As Short = 3
    Public Const LEVEL4 As Short = 4
    Public Const LEVEL5 As Short = 5
    Public Const LEVEL6 As Short = 6
    Public Const LEVEL7 As Short = 7
    Public Const LEVEL8 As Short = 8
    Public Const LEVEL9 As Short = 9

    ' memory array line status
    Public Const NEWROW As Short = 0
    Public Const INSERTED As Short = 1
    Public Const UPDATED As Short = 2
    Public Const DELETED As Short = 3
    Public Const NOTCHANGED As Short = 4
    Public Const ABANDONED As Short = 5


    ' The following error codes are guarenteed to be sql portable.  They should
    '   all be declared here as an aid to the person who has already searched
    '   unsuccesfully in the native SQL error code list.
    '   These error numbers contain message text in the Solomon message file.
    Public Const DUPLICATE As Short = 5
    Public Const NOTFOUND As Short = 9

    ' Setbutton values and subroutine dcl.  All the button ID values can be specified in 1 call (added togather)
    Public Const TbInsertButton As Short = 1
    Public Const TbSaveButton As Short = 2
    Public Const TbDeleteButton As Short = 4
    Public Const TbCancelButton As Short = 8
    Public Const TbNextButton As Short = 16
    Public Const TbPreviousButton As Short = 32
    Public Const TbFirstButton As Short = 64
    Public Const TbLastButton As Short = 128
    Public Const TbCurySelButton As Short = 256
    Public Const TbCuryTogButton As Short = 512
    Public Const AllLevels As Short = -1

    ' MsgBox parameters
    Public Const MB_OK As Short = 0 ' OK button only
    Public Const MB_OKCANCEL As Short = 1 ' OK and Cancel buttons
    Public Const MB_ABORTRETRYIGNORE As Short = 2 ' Abort, Retry, and Ignore buttons
    Public Const MB_YESNOCANCEL As Short = 3 ' Yes, No, and Cancel buttons
    Public Const MB_YESNO As Short = 4 ' Yes and No buttons
    Public Const MB_RETRYCANCEL As Short = 5 ' Retry and Cancel buttons

    Public Const MB_ICONSTOP As Short = 16 ' Critical message
    Public Const MB_ICONQUESTION As Short = 32 ' Warning query
    Public Const MB_ICONEXCLAMATION As Short = 48 ' Warning message
    Public Const MB_ICONINFORMATION As Short = 64 ' Information message

    Public Const MB_DEFBUTTON1 As Short = 0 ' First button is default
    Public Const MB_DEFBUTTON2 As Short = 256 ' Second button is default
    Public Const MB_DEFBUTTON3 As Short = 512 ' Third button is default

    ' MsgBox return values
    Public Const IDOK As Short = 1 ' OK button pressed
    Public Const IDCANCEL As Short = 2 ' Cancel button pressed
    Public Const IDABORT As Short = 3 ' Abort button pressed
    Public Const IDRETRY As Short = 4 ' Retry button pressed
    Public Const IDIGNORE As Short = 5 ' Ignore button pressed
    Public Const IDYES As Short = 6 ' Yes button pressed
    Public Const IDNO As Short = 7 ' No button pressed

    ' MousePointer (form, controls)
    Public DefaultMouseCursor As Cursor = System.Windows.Forms.Cursors.Default ' 0 - Default
    Public HourglassMouseCursor As Cursor = System.Windows.Forms.Cursors.WaitCursor  ' 11 - Hourglass

    ' Used by application for floating point calculations;
    ' These values will tell SWIM to use default rounding corresponding
    ' to each of these types
    Public Const TRANCURY As Short = &HA000S
    Public Const BASECURY As Short = &H9000S
    Public Const MONEY As Short = &H8000S
    Public Const INV_UNIT_QTY As Short = &H4000S
    Public Const Units As Short = &H3000S ' Used for both Payroll and JC currently
    Public Const INV_UNIT_PRICE As Short = &H2000S
    Public Const PERCENT As Short = &H1000S


    ' Use for account type fields.  Only valid if Solomon's default reporting
    ' order for chart of accounts is being used (e.g. GLSetup.COAOrder = "A")
    ' otherwise the first byte (e.g. the sequence byte) is not accurate)
    Public Const TYPEASSET As String = "1A"
    Public Const TYPELIABILITY As String = "2L"
    Public Const TYPEINCOME As String = "3I"
    Public Const TYPEEXPENSE As String = "4E"


    'Used to specify a particular datatype in API calls such as MKeyOffset
    Public Const DATA_TYPE_STRING As Short = 0
    Public Const DATA_TYPE_FLOAT As Short = 2
    Public Const DATA_TYPE_INTEGER As Short = 1
    Public Const DATA_TYPE_DATE As Short = 3
    Public Const DATA_TYPE_TIME As Short = 4
    Public Const DATA_TYPE_LOGICAL As Short = 7


    ' Application Parameter Passing Sections:
    Public Const PRMSECTION_VBRDT As String = "[VBRDT]"
    Public Const PRMSECTION_BSL As String = "[BSL]"
    Public Const PRMSECTION_TI As String = "[TI]"

    'Used for locating forms on screen
    Public Const PARENT_LEFT As Short = 0
    Public Const PARENT_TOP As Short = 0
    Public Const PARENT_WIDTH As Short = 6360
    Public Const PARENT_HEIGHT As Short = 1170
    Public Const PARENT_HEIGHT_NOTB As Short = 690 ' for use when the toolbar is floating

    Public Const ACCESSUPDATERIGHTS As Short = 2 ' Update/Save button allowed.
    Public Const ACCESSNORIGHTS As Short = &H7F00S ' No Screen access rights.

    Public c5, c3, c1, c2, c4, c6 As Short
    Public c11, c9, c7, c8, c10, c12 As Short
    Public serr3, serr1, serr, serr2, serr4 As Short
    Public serr8, serr6, serr5, serr7, serr9 As Short
    Public serr11, serr10, serr12 As Short

    Public NULLDATE As Integer
    Public DefaultCompanyColor As Integer = RGB(102, 125, 0)
    Public DefaultCompanyEdgeColor As Color = System.Drawing.ColorTranslator.FromWin32(RGB(&H43, &H43, &H43))

    <DesignerCategory("Code")> _
    Public Class PES
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0)> Public Property AccessNbr() As Short
            Get
                Return Me.GetPropertyValue("AccessNbr")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("AccessNbr", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=1)> Public Property Administrator() As Short
            Get
                Return Me.GetPropertyValue("Administrator")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("Administrator", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=2, StringSize:=4)> Public Property BaseCuryID() As String
            Get
                Return Me.GetPropertyValue("BaseCuryID")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("BaseCuryID", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=3)> Public Property BeforeReport() As Short
            Get
                Return Me.GetPropertyValue("BeforeReport")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("BeforeReport", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=4)> Public Property BegRI_ID() As Short
            Get
                Return Me.GetPropertyValue("BegRI_ID")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("BegRI_ID", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=5, StringSize:=21)> Public Property ComputerName() As String
            Get
                Return Me.GetPropertyValue("ComputerName")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("ComputerName", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=6, StringSize:=10)> Public Property CpnyID() As String
            Get
                Return Me.GetPropertyValue("CpnyID")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("CpnyID", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=7, StringSize:=30)> Public Property CpnyName() As String
            Get
                Return Me.GetPropertyValue("CpnyName")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("CpnyName", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=8, StringSize:=80)> Public Property CurrTitle() As String
            Get
                Return Me.GetPropertyValue("CurrTitle")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("CurrTitle", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=9, StringSize:=30)> Public Property CustomGroupId() As String
            Get
                Return Me.GetPropertyValue("CustomGroupId")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("CustomGroupId", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=10, StringSize:=1)> Public Property CustomLevel() As String
            Get
                Return Me.GetPropertyValue("CustomLevel")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("CustomLevel", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=11, StringSize:=47)> Public Property CustomUserId() As String
            Get
                Return Me.GetPropertyValue("CustomUserId")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("CustomUserId", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=12, StringSize:=21)> Public Property DBName() As String
            Get
                Return Me.GetPropertyValue("DBName")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("DBName", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=13, StringSize:=30)> Public Property DBNameSystem() As String
            Get
                Return Me.GetPropertyValue("DBNameSystem")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("DBNameSystem", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=14, StringSize:=30)> Public Property DBServer() As String
            Get
                Return Me.GetPropertyValue("DBServer")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("DBServer", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=15, StringSize:=30)> Public Property DBServerSystem() As String
            Get
                Return Me.GetPropertyValue("DBServerSystem")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("DBServerSystem", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=16)> Public Property EndRI_ID() As Short
            Get
                Return Me.GetPropertyValue("EndRI_ID")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("EndRI_ID", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=17)> Public Property EnterKeyAsTAB() As Short ' Should not be used in applications -- ignored by kernel
            Get
                Return Me.GetPropertyValue("EnterKeyAsTAB")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("EnterKeyAsTAB", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=18)> Public Property ExcludeMacros() As Short
            Get
                Return Me.GetPropertyValue("ExcludeMacros")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("ExcludeMacros", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=19)> Public Property InitMode() As Short
            Get
                Return Me.GetPropertyValue("InitMode")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("InitMode", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=20, StringSize:=6)> Public Property Language() As String
            Get
                Return Me.GetPropertyValue("Language")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("Language", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=21, StringSize:=12)> Public Property NextProg() As String
            Get
                Return Me.GetPropertyValue("NextProg")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("NextProg", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=22, StringSize:=255)> Public Property PrintDestinationName() As String
            Get
                Return Me.GetPropertyValue("PrintDestinationName")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("PrintDestinationName", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=23)> Public Property PrintIncludeCodes() As Short
            Get
                Return Me.GetPropertyValue("PrintIncludeCodes")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("PrintIncludeCodes", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=24)> Public Property PrintToFile() As Short
            Get
                Return Me.GetPropertyValue("PrintToFile")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("PrintToFile", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=25)> Public Property QMAction() As Short
            Get
                Return Me.GetPropertyValue("QMAction")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("QMAction", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=26)> Public Property QMMode() As Short
            Get
                Return Me.GetPropertyValue("QMMode")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("QMMode", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=27, StringSize:=5)> Public Property ScrnNbr() As String
            Get
                Return Me.GetPropertyValue("ScrnNbr")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("ScrnNbr", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=28)> Public Property Today() As Integer
            Get
                Return Me.GetPropertyValue("Today")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("Today", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=29, StringSize:=47)> Public Property UserId() As String
            Get
                Return Me.GetPropertyValue("UserId")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("UserId", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=30)> Public Property CpnyColor() As Integer
            Get
                Return Me.GetPropertyValue("CpnyColor")
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("CpnyColor", setval)
            End Set

        End Property

    End Class

    'DO NOT REASSIGN THESE VARIABLES, i.e. bSomeType = nSomeType.  Use API CopyClass(bSomeType,nSomeType)
    Public bpes As PES = New PES, NPES As PES = New PES

    Public Class CuryInfo
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0, StringSize:=4)> Public Property BaseCuryID() As String
            Get
                Return Me.GetPropertyValue("BaseCuryID")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("BaseCuryID", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=1)> Public Property BaseDecPl() As Short
            Get
                Return Me.GetPropertyValue("BaseDecPl")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("BaseDecPl", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=2)> Public Property CuryView() As Short
            Get
                Return Me.GetPropertyValue("CuryView")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("CuryView", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=3)> Public Property EffDate() As Integer
            Get
                Return Me.GetPropertyValue("EffDate")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("EffDate", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=4)> Public Property FieldsDisabled() As Short
            Get
                Return Me.GetPropertyValue("FieldsDisabled")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("FieldsDisabled", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=5, StringSize:=1)> Public Property MultDiv() As String
            Get
                Return Me.GetPropertyValue("MultDiv")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("MultDiv", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=6)> Public Property Rate() As Double
            Get
                Return Me.GetPropertyValue("Rate")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("Rate", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=7, StringSize:=6)> Public Property RateType() As String
            Get
                Return Me.GetPropertyValue("RateType")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("RateType", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=8, StringSize:=4)> Public Property TranCuryId() As String
            Get
                Return Me.GetPropertyValue("TranCuryId")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("TranCuryId", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=9)> Public Property TranDecPl() As Short
            Get
                Return Me.GetPropertyValue("TranDecPl")
            End Get

            Set(ByVal Value As Short)
                Me.SetPropertyValue("TranDecPl", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=10, StringSize:=30)> Public Property User1() As String
            Get
                Return Me.GetPropertyValue("User1")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("User1", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=11, StringSize:=30)> Public Property User2() As String
            Get
                Return Me.GetPropertyValue("User2")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("User2", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=12)> Public Property User3() As Double
            Get
                Return Me.GetPropertyValue("User3")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("User3", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=13)> Public Property User4() As Double
            Get
                Return Me.GetPropertyValue("User4")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("User4", Value)
            End Set

        End Property
    End Class

    'DO NOT REASSIGN THESE VARIABLES, i.e. bSomeType = nSomeType.  Use API CopyClass(bSomeType,nSomeType)
    Public bCuryInfo As CuryInfo = New CuryInfo, nCuryInfo As CuryInfo = New CuryInfo


    Public Class Favorites
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0, StringSize:=255)> Public Property AppExecute() As String
            Get
                Return Me.GetPropertyValue("AppExecute")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("AppExecute", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=1, StringSize:=7)> Public Property Number() As String
            Get
                Return Me.GetPropertyValue("Number")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("Number", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=2, StringSize:=40)> Public Property ApplicName() As String
            Get
                Return Me.GetPropertyValue("ApplicName")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("ApplicName", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=3, StringSize:=1)> Public Property AppType() As String
            Get
                Return Me.GetPropertyValue("AppType")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("AppType", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=4, StringSize:=30)> Public Property S4Future01() As String
            Get
                Return Me.GetPropertyValue("S4Future01")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("S4Future01", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=5, StringSize:=30)> Public Property S4Future02() As String
            Get
                Return Me.GetPropertyValue("S4Future02")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("S4Future02", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=6)> Public Property S4Future03() As Double
            Get
                Return Me.GetPropertyValue("S4Future03")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("S4Future03", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=7)> Public Property S4Future04() As Double
            Get
                Return Me.GetPropertyValue("S4Future04")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("S4Future04", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=8)> Public Property S4Future05() As Double
            Get
                Return Me.GetPropertyValue("S4Future05")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("S4Future05", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=9)> Public Property S4Future06() As Double
            Get
                Return Me.GetPropertyValue("S4Future06")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("S4Future06", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=10)> Public Property S4Future07() As Integer
            Get
                Return Me.GetPropertyValue("S4Future07")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("S4Future07", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=11)> Public Property S4Future08() As Integer
            Get
                Return Me.GetPropertyValue("S4Future08")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("S4Future08", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=12)> Public Property S4Future09() As Integer
            Get
                Return Me.GetPropertyValue("S4Future09")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("S4Future09", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=13)> Public Property S4Future10() As Integer
            Get
                Return Me.GetPropertyValue("S4Future10")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("S4Future10", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=14, StringSize:=10)> Public Property S4Future11() As String
            Get
                Return Me.GetPropertyValue("S4Future11")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("S4Future11", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=15, StringSize:=10)> Public Property S4Future12() As String
            Get
                Return Me.GetPropertyValue("S4Future12")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("S4Future12", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=16, StringSize:=30)> Public Property User1() As String
            Get
                Return Me.GetPropertyValue("User1")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("User1", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=17, StringSize:=30)> Public Property User2() As String
            Get
                Return Me.GetPropertyValue("User2")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("User2", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=18)> Public Property User3() As Double
            Get
                Return Me.GetPropertyValue("User3")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("User3", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=19)> Public Property User4() As Double
            Get
                Return Me.GetPropertyValue("User4")
            End Get

            Set(ByVal Value As Double)
                Me.SetPropertyValue("User4", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=20, StringSize:=10)> Public Property User5() As String
            Get
                Return Me.GetPropertyValue("User5")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("User5", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=21, StringSize:=10)> Public Property User6() As String
            Get
                Return Me.GetPropertyValue("User6")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("User6", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=22)> Public Property User7() As Integer
            Get
                Return Me.GetPropertyValue("User7")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("User7", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=23)> Public Property User8() As Integer
            Get
                Return Me.GetPropertyValue("User8")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("User8", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=24, StringSize:=47)> Public Property UserId() As String
            Get
                Return Me.GetPropertyValue("UserId")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("UserId", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=25, StringSize:=1)> Public Property UserType() As String
            Get
                Return Me.GetPropertyValue("UserType")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("UserType", Value)
            End Set

        End Property
    End Class

    'DO NOT REASSIGN THESE VARIABLES, i.e. bSomeType = nSomeType.  Use API CopyClass(bSomeType,nSomeType)
    Public bFavorites As Favorites = New Favorites, nFavorites As Favorites = New Favorites

    Public Class ScreenEntry
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0, StringSize:=2)> Public Property SolomonModule() As String
            Get
                Return Me.GetPropertyValue("SolomonModule")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("SolomonModule", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=1, StringSize:=40)> Public Property Name() As String
            Get
                Return Me.GetPropertyValue("Name")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("Name", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=2, StringSize:=7)> Public Property Number() As String
            Get
                Return Me.GetPropertyValue("Number")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("Number", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=3, StringSize:=1)> Public Property ScreenType() As String
            Get
                Return Me.GetPropertyValue("ScreenType")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("ScreenType", Value)
            End Set

        End Property
    End Class

    'DO NOT REASSIGN THESE VARIABLES, i.e. bSomeType = nSomeType.  Use API CopyClass(bSomeType,nSomeType)
    Public bScreenEntry As ScreenEntry = New ScreenEntry, nScreenEntry As ScreenEntry = New ScreenEntry

    'Currency Manager
    'Values for View - must correspond to #defines in define.h
    Public Const CURY_VIEW_TRAN As Short = 0
    Public Const CURY_VIEW_BASE As Short = 1

    'Currency Manager
    'Values to enable/disable fields in Currency Selection form
    Public Const CURYSEL_TRANCURYID As Short = 1
    Public Const CURYSEL_RATETYPE As Short = 2
    Public Const CURYSEL_ALL As Short = 16384

    'Currency Manager
    'Values for flag parameter in CurrencyField call
    Public Const CURY_BASE_CALC As Short = 0
    Public Const CURY_BASE_NOCALC As Short = 1

    'Currency Manager
    'Values for flag parameter in CuryInfoEnable call
    Public Const CURY_INFO_SETGET As Short = 0
    Public Const CURY_INFO_SETONLY As Short = 1
    Public Const CURY_INFO_GETONLY As Short = 2
    Public Const CURY_INFO_DISABLE As Short = -1

    Public FNULL As Object = Solomon.Kernel.NullObjectType.Instance
    Public PNULL As Object = Solomon.Kernel.NullObjectType.Instance
    Public CNULL As Object = Solomon.Kernel.NullObjectType.Instance
    Public INULL As Short

    Public Const APPLICRETURNPARMS As String = "ReturnParms" ' Application return in screenexit()

    ' SJL CR 208301  Added to identify number of buttons on app toolbar
    Public Const NUM_TLB_BUTTONS As Short = 13

    ' Save template LevelNbr parameter values
    Public Const CCPAllLevels As Short = -1
    Public Const CCPSelectedFields As Short = -2

    Public Const BTISqlType As Short = 0
    Public Const MSSqlType As Short = 1

    ' External functions for manipulating imagelists
    Declare Function ImageList_AddMasked Lib "Comctl32.dll" ( _
        ByVal himl As Integer, _
        ByVal hbmImage As Integer, _
        ByVal crMask As Integer) As Integer
    Declare Function ImageList_GetIcon Lib "comctl32" ( _
        ByVal HIMAGELIST As Integer, _
        ByVal ImgIndex As Integer, _
        ByVal fuFlags As Integer) As Integer
    Declare Function DestroyIcon Lib "user32" (ByVal hIcon As Integer) As Integer
    Declare Function ImageList_Create Lib "Comctl32.dll" ( _
        ByVal cx As Integer, _
        ByVal cy As Integer, _
        ByVal flags As Integer, _
        ByVal cInitial As Integer, _
        ByVal cGrow As Integer) As Integer
    Declare Function ImageList_Destroy Lib "Comctl32.dll" (ByVal himl As Integer) As Integer

    Public Const INTEGRATEDLOGONFAILED As Short = 10
    Public Const INTEGRATEDLOGONDENIED As Short = 11
    Public Const LOGONSUCCESS As Short = 0

    '[cmokma] CR205788 Constant to indicate an adhoc RAISERROR that was changed in SWIM from 50000
    Public Const SWIMRAISERROR As Short = 32767

    'CR206684 Add constants for return from pre-processes that indicate whether or not
    '         to continue or abort report generation.
    Public Const ROI_ABORT_REPORTS As String = "1"
    Public Const ROI_EXECUTE_REPORTS As String = "2"


    ' CR 208301  Added variable to indicate whether or not a toolbar should be
    '               created on the app.
    Public TbOnApp As Boolean = False


    ' End Applic.dh ************************************************************************************************





#Region "#IF SWIM.BAS code"


    'This region is the remnents on the original SWIM.BAS code. It is inteneded for inclusion with the Solomon Applications.
#If _REMOVE_SWIM_BAS = False Then
    ' Begin swim.bas ************************************************************************************************
    ' Used to insure application built correctly
    ' Should match APPLIC_VER in applic.dh and define.h
    Public Const SWIMBAS_VER As String = "00.27"

    ' Use the db type we have already loaded
    Public Const SqlTypeDefault As Short = 99

    ' used to collect db login info
    Public CalledByHwnd As Integer ' Handle of the program which called us (or we are otherwise linked to)

    ' Flag indicating whether cancel button pressed
    Dim flgCancelPressed As Short

    ' indicates whether db is opened
    Dim flgDBOpen As Short

    ' flag indicating where program was called from
    Public flgCalledFrom As Short

    Public maxpanel, max_button, maxlabel, maxframe, max_note_button As Short
    Public maxfloat, maxtext, maxint, maxdate As Short
    Public maxtabbox, maxoption, maxcheck, maxcombo, maxselbox As Short
#If FORM1NOTPRESENT Then
#Else

    Friend currentApplicationMenuStrip As ApplicationMenuStrip = Nothing
    Dim currentApplicationSAFDesigner As ApplicationSAFDesigner = Nothing
#End If

    'Following is for Note api's within this .bas file
    'Buffer used to fetch the snote record values
    Public Class sNoteBuffTag
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0)> Public Property nID() As Integer
            Get
                Return Me.GetPropertyValue("nID")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("nID", Value)
            End Set

        End Property
        <DataBinding(PropertyIndex:=1, StringSize:=20)> Public Property stablename() As String
            Get
                Return Me.GetPropertyValue("stablename")
            End Get

            Set(ByVal Value As String)
                Me.SetPropertyValue("stablename", Value)
            End Set

        End Property
    End Class

    'DO NOT REASSIGN THESE VARIABLES, i.e. bSomeType = nSomeType.  Use API CopyClass(bSomeType,nSomeType)
    Public bSnoteIdBuffer As sNoteBuffTag = New sNoteBuffTag

    'Buffer used to see if record exists with a certain noteid
    Public Class TableNoteTag
        Inherits SolomonDataObject
        <DataBinding(PropertyIndex:=0)> Public Property nID() As Integer
            Get
                Return Me.GetPropertyValue("nID")
            End Get

            Set(ByVal Value As Integer)
                Me.SetPropertyValue("nID", Value)
            End Set

        End Property
    End Class

    'DO NOT REASSIGN THESE VARIABLES, i.e. bSomeType = nSomeType.  Use API CopyClass(bSomeType,nSomeType)
    Public TableNoteID As TableNoteTag = New TableNoteTag


    Public Const AllNoteOrphans As Short = -1

    Public Const IDS_MENEW As Integer = 10180 '"&New       Ctrl+N"
    Public Const IDS_MESAVE As Integer = 10190 '"&Save      Ctrl+S"
    Public Const IDS_MEFINISH As Integer = 10200 '"&Finish     Ctrl+F"
    Public Const IDS_MECANCEL As Integer = 10210 '"C&ancel    Esc"
    Public Const IDS_MEDELETE As Integer = 10220 '"&Delete    Ctrl+D"
    Public Const IDS_MEFIRST As Integer = 10230 '"First       Ctrl+Home"
    Public Const IDS_MEPREV As Integer = 10240 '"Prev       PgUp"
    Public Const IDS_MENEXT As Integer = 10250 '"Next       PgDn"
    Public Const IDS_MELAST As Integer = 10260 '"Last       Ctrl+End"
    Public Const IDS_MECLOSEALT As Integer = 10270 '"Cl&ose      Alt+F4"
    Public Const IDS_MENAVIG As Integer = 10280 '"Na&vigation Level..."
    Public Const IDS_MENOTE As Integer = 10290 '"Not&e"
    Public Const IDS_MEATTACH As Integer = 10295 '"&Attachment"
    Public Const IDS_MECURR As Integer = 10300 '"Currency Select&ion..."
    Public Const IDS_MECHAN As Integer = 10310 '"Chan&ge Currency View"
    Public Const IDS_MEHELP As Integer = 10610 '"&Help"



    ' SJL, CR 207948 Changed the default id for the branding changes
    Public Const IDS_SOLOMON As String = "Solomon "
    Public Const IDS_MEEXIT As Integer = 10070 '"E&xit"
    Public Const IDS_MEEDIT As Integer = 10080 '"&Edit"
    Public Const IDS_MECUT As Integer = 10090 '"Cu&t"
    Public Const IDS_MECOPY As Integer = 10100 '"&Copy               Ctrl+C"
    Public Const IDS_MEPASTE As Integer = 10110 '"&Paste              Ctrl+V"
    Public Const IDS_MEUNDO As Integer = 10120 '"&Undo Paste     Ctrl+Z"
    Public Const IDS_MECLEAR As Integer = 10140 '"C&lear selection"
    Public Const IDS_MEINSERT As Integer = 10150 '"Insert &rows + Paste"
    Public Const IDS_METEMPLATE As Integer = 10160 '"Te&mplate"
    Public Const IDS_MESUBMIT As Integer = 10170 '"Su&bmit to Application Server"

    ' CR 207724
    ' New UI
    Public Const IDS_MEACTION As Integer = 11290

    Public Const IDS_ADDFAV As Integer = 11360
    Public Const IDS_REMFAV As Integer = 11370

    'The maximum length of a string literal allowed in Microsoft C is approximately 2,048 bytes.
    Private Const cnMaxStrSize As Short = 2048
    Private LLIHandle As Integer
    Public HIMAGELIST As Integer
    Public Const ILD_NORMAL As Integer = 0

    ' Height and width of the toolbar and menu being created
    Public Const APPTBHEIGHT As Short = 780
    Public Const APPTBWIDTH As Short = 8900


    '************************************************************************/
    'BEGIN RMV/MV

    ' Design time calls and constants follow (duplicated in parent.dh and swim.bas)
    Public Const CTL_LABEL As Short = 1
    Public Const CTL_BUTTON As Short = 4
    Public Const CTL_FORM As Short = 80
    Public Const CTL_FRAME As Short = 81 ' 3D frame
    Public Const CTL_PANEL As Short = 82 ' 3D panel
    Public Const CTL_SSCOMMAND As Short = 83 ' 3D SSCOMMAND (used for NOTE icons)    'deb
    Public Const CTL_SPREAD As Short = 84
    Public Const CTL_TLBLABEL As Short = 85
    Public Const CTL_VBTEXT As Short = 86
    Public Const CTL_TLB_FIRST As Short = 90
    Public Const CTL_TEXT As Short = 90
    Public Const CTL_INT As Short = 91
    Public Const CTL_FLOAT As Short = 92
    Public Const CTL_DATE As Short = 93
    Public Const CTL_CHECK As Short = 100
    Public Const CTL_OPTION As Short = 101
    Public Const CTL_COMBO As Short = 102
    Public Const CTL_TLB_LAST As Short = 102
    Public Const CTL_SELECTBOX As Integer = CTL_TLB_LAST + 1 ' not a true control type; used strictly
    ' internally by cut-copy-paste logic for
    ' creation of "selection" boxes (see ccpapi.c)





    ' use these in code in case message number changes later
    ' should match defines in define.h, as well as messages
    ' numbers stored in database
    Public Const MSG_SWIM_VERSION As Short = 5010


    ' Used to tell how one of our programs was called
    ' Corresponding #defines in DEFINE.H, PARENT.BAS
    Public Const FROM_OS As Short = 0
    Public Const PARENT_CALLED_APPL As Short = 1
    Public Const APPL_CALLED_PARENT As Short = 2
    Public Const APPL_CALLED_APPL As Short = 3
    Public Const APPLWAIT_CALLED_APPL As Short = 4
    Public Const APPL_CALLED_BY_QM As Short = 5



    Private Const VbVersion As Short = 2003

    '****************************************************************************
    ' Function:     CallApplic
    '
    ' Narrative:    Allow application program to start another application.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub CallApplic(ByRef exename As String, ByRef parms As String)

        Dim s As String

        s = exename & ".exe " & Str(APPL_CALLED_APPL) & PRMSEP & parms
        Call ExecProg(s)

    End Sub
#If FORM1NOTPRESENT Then
#Else

    '****************************************************************************
    ' Function:     CallApplicWait
    '
    ' Narrative:    Allow application program to start another application.  In
    '               addition, execution will not return until the called
    '               application has been closed.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub CallApplicWait(ByRef exename As String, ByRef parms As String)

        Dim s As String
        Dim serr As Short
        Dim hwnd As Integer

        hwnd = Form1.Handle.ToInt32
        s = exename & ".exe " & Str(APPLWAIT_CALLED_APPL) & PRMSEP & Trim(Str(hwnd)) & PRMSEP & parms
        serr = ExecProgWait(s)

    End Sub
    '****************************************************************************
    ' Function:     CallPrePostApplicWait
    '
    ' Narrative:    Allow application to start a pre/post-process.  In
    '               addition, execution will not return until the called
    '               application has been closed.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub CallPrePostApplicWait(ByRef exename As String, ByRef parms As String)

        Dim s As String
        Dim serr As Short
        Dim hwnd As Integer

        hwnd = Form1.Handle.ToInt32
        s = exename & ".exe " & Str(APPLWAIT_CALLED_APPL) & PRMSEP & Trim(Str(hwnd)) & PRMSEP & parms
        serr = ExecPrePostProgWait(s)

    End Sub
#End If
    '****************************************************************************
    ' Function:     ChkParentStart
    '
    ' Narrative:    Prompt application programmer for starting of parent
    '               application.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub ChkParentStart()

        Dim s As String

        If flgCalledFrom <> PARENT_CALLED_APPL And IsParentRunning() = False Then
            Call SetParentRootDir()
            s = PARENT_APP_NAME & " " & Str(APPL_CALLED_PARENT)
            ExecProg((s))

        End If

        Do While IsLoginReady() <> 1
            System.Windows.Forms.Application.DoEvents()
        Loop

    End Sub

    '****************************************************************************
    ' Function:     CloseDB
    '
    ' Narrative:    Close the database.
    '
    ' Arguements:
    '
    ' Alter(s):     flgDBOpen
    '
    '****************************************************************************
    Sub CloseDB()

        ' If flgDBOpen = False Then Exit Sub

        ' Logout of database
        Call SqlLogout()

        ' set flag indicating db is closed
        flgDBOpen = False

    End Sub

    '****************************************************************************'****************************************************************************
    ' Function:     DeleteNote
    '
    ' Narrative:    Used to delete a note or all notes for a particular
    '               record type, which do not have a corresponding
    '               record with same noteid.
    '
    ' Arguements:   TableName - Type of record to delete snotes for.
    '               noteid    - ID of note to delete or
    '                           AllNoteOrphans - to delete all
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub DeleteNote(ByRef tableName As String, ByRef NoteID As Integer)
        Dim sqlcmd As String
        Dim NOTE_CURSOR As Short
        Dim NOTE_BLANK_CURSOR As Short
        Dim TABLE_CURSOR As Short
        Dim ATTACH_CURSOR As Short
        Dim LoopCtr As Short
        Dim PrevNoteID As Integer
        Dim Done As Short
        Dim AttachResult As Short

        Call SqlCursorEx(NOTE_CURSOR, NOLEVEL, "Note_Cursor", "SNote", "SNote")
        Call SqlCursorEx(NOTE_CURSOR, NOLEVEL, "Note_Blank_Cursor", "SNote", "SNote")
        Call SqlCursorEx(TABLE_CURSOR, SqlReadOnly + NOLEVEL, "DeleteNoteTableCursor", Trim(tableName), "")
        Call SqlCursorEx(ATTACH_CURSOR, SqlReadOnly + NOLEVEL + SqlSystemDb, "Attach_Cursor", "Attachment", "")

        'Verify that a Note ID is not in use by Attachments before deleting it.
        sqlcmd = "exec Attachment_Exists @parm1"
        sql(ATTACH_CURSOR, sqlcmd)

        If (NoteID = AllNoteOrphans) Then

            ' Application will have already started process and be within a transaction
            Call Status(0, False, "Searching And Deleting Orphan Notes" & NL.Value, DISP_ONLY)
            System.Windows.Forms.Application.DoEvents()

            'This is used to count the number of note records we delete
            LoopCtr = 0

            'Get the first Record from TableName where noteid is not 0
            sqlcmd = "select noteid from " & Trim(tableName) & " where noteid > 0 order by noteid desc"
            serr = SqlFetch1(TABLE_CURSOR, sqlcmd, TableNoteID)

            'Setup the sql statement to obtain the snote tables > than the highest noteid we have in the TableName table
            'But less than the previous snote we were checking, which in the 1st case will be the highest possible value
            sqlcmd = "select nID, sTableName from snote where stablename like '" & Trim(tableName) & "%' and nID > @parm1 and nID < @parm2 order by nid"
            Call sql(NOTE_CURSOR, sqlcmd)

            'For 1st time set previouse noteid variable to highest value a long variable supports
            PrevNoteID = 2147483647

            'while there are TableName records to process then find the snote specific to the noteid's
            'specified above
            Done = False
            While Done = False
                'If there were no TableName records with a NoteID > 0 then the following loop will
                'delete all snote records for this TableName
                If serr = NOTFOUND Then
                    TableNoteID.nID = 0
                    Done = True
                End If

                'This makes sure we look at the right Attachments
                Call SqlSubst(ATTACH_CURSOR, "parm1", IParm(TableNoteID.nID))
                Call SqlExec(ATTACH_CURSOR)

                'This will restrict our result set to snotes with a noteid > the highest noteid in the TableName record
                Call SqlSubst(NOTE_CURSOR, "parm1", IParm(TableNoteID.nID))

                serr = SFetch1(ATTACH_CURSOR, AttachResult)
                If serr <> 0 Then AttachResult = 1 'err on the side of caution

                'This will restrict our result set to snotes with a noteid < the previous noteid we were checking
                'This will prevent us from deleting snotes that have been previously tested
                Call SqlSubst(NOTE_CURSOR, "parm2", IParm(PrevNoteID))
                Call SqlExec(NOTE_CURSOR)
                serr = SFetch1(NOTE_CURSOR, bSnoteIdBuffer)
                While serr = 0
                    If AttachResult = 1 Then
                        'There are Attachments using the Note ID, so blank out the text instead of deleting the SNote
                        sql(NOTE_BLANK_CURSOR, String.Concat("UPDATE [Snote] SET [sNoteText]='' WHERE [nID]=", IParm(TableNoteID.nID)))
                    Else
                        'Note ID is not in use by Attachments, so it is safe to delete
                        Call SDelete(NOTE_CURSOR, "SNote")
                    End If

                    If TranStatus() = 0 Then
                        LoopCtr = LoopCtr + 1

                        Call Status(0, False, "Table " & Trim(tableName) & Str(LoopCtr) & " Notes Deleted", DISP_ONLY)
                    End If
                    serr = SFetch1(NOTE_CURSOR, bSnoteIdBuffer)
                End While

                Call Status(0, False, "Table " & Trim(tableName) & Str(LoopCtr) & " Notes Deleted", DISP_ONLY)
                System.Windows.Forms.Application.DoEvents()

                'Set the PrevNoteID variable so we know not to delete this snote, next time through the loop
                PrevNoteID = TableNoteID.nID

                'Get the next noteid in the TableName table
                serr = SFetch1(TABLE_CURSOR, TableNoteID)
            End While
        Else
            sqlcmd = "select nID, sTableName from snote where nID = " & Trim(Str(NoteID)) & " AND stablename like '" & Trim(tableName) & "%'"
            serr = SqlFetch1(NOTE_CURSOR, sqlcmd, bSnoteIdBuffer)
            If serr = 0 Then
                'This makes sure we look at the right Attachments
                Call SqlSubst(ATTACH_CURSOR, "parm1", IParm(TableNoteID.nID))
                Call SqlExec(ATTACH_CURSOR)

                serr = SFetch1(ATTACH_CURSOR, AttachResult)
                If serr <> 0 Then AttachResult = 1 'err on the side of caution

                If AttachResult = 1 Then
                    'There are Attachments using the Note ID, so blank out the text instead of deleting the SNote
                    sql(NOTE_BLANK_CURSOR, String.Concat("UPDATE [Snote] SET [sNoteText]='' WHERE [nID]=", IParm(bSnoteIdBuffer.nID)))
                Else
                    Call SDelete(NOTE_CURSOR, "SNote")
                End If
            End If
        End If

        Call SqlFree(NOTE_CURSOR)
        Call SqlFree(NOTE_BLANK_CURSOR)
        Call SqlFree(TABLE_CURSOR)
        Call SqlFree(ATTACH_CURSOR)
    End Sub

    '****************************************************************************'****************************************************************************
    ' Function:     DispForm
    '
    ' Narrative:    Used to display application Sub Forms. Will deal with the
    '               MODEL and wait for form completion issues.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub DispForm(ByRef formx As System.Windows.Forms.Form, ByVal centered As Short)
        Call disp_form(formx, centered)
    End Sub

    '****************************************************************************
    ' Function:     LocateForm
    '
    ' Narrative:    Used as a standard method of locating application forms.
    '               Use pre-defined constants that indicate where the parent
    '               application is located, and locate the application form
    '               relative to it.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub LocateForm(ByRef X As System.Windows.Forms.Form)

        Dim ScreenXCenter As Short ' The horizontal center of the desktop
        Dim ScreenYCenter As Short ' The vertical center of the desktop
        Dim FormLeft As Short ' Leftmost coordinate of the loaded screen
        Dim FormTop As Short ' Topmost coordinate of the loaded screen


        ' Center form underneath parent
        'CR207901 - CAG - 8/22/02
        'Added " + GetWorkAreaTop()" to this calculation so that the form will be placed underneath Parent
        'A related change in CR207898 causes Parent to open at the top of the workarea rather than the screen
        'This ensures that Parent won't open behind the Windows taskbar if the taskbar is at the top of the screen.
        'Now when other forms open, we need to make sure that they open far enough down so as not to cover up Parent or the taskbar
        'Note that if Parent isn't at the top of the work area, other forms will still open at the same location as if Parent was at the top of the work area
        'This is the same effect as is in the current product, just now we are dealing with the work area rather than the screen


        '    X.Move (Screen.Width / 2 - X.Width / 2), GetWorkAreaTop()
        '   End CR207901

        ' Center the application in the middle of the screen.
        ScreenXCenter = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 2
        ScreenYCenter = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 2

        FormLeft = ScreenXCenter - (VB6.PixelsToTwipsX(X.Width) / 2)
        FormTop = ScreenYCenter - (VB6.PixelsToTwipsY(X.Height) / 2)

        X.SetBounds(VB6.TwipsToPixelsX(FormLeft), VB6.TwipsToPixelsY(FormTop), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)


    End Sub

    '****************************************************************************
    ' Function:     MousePointer
    '
    ' Narrative:    Allow setting of form mouse pointer.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub MousePointer(ByVal mp As System.Windows.Forms.Cursor)
        SetMousePointer(mp)
    End Sub

    '****************************************************************************
    ' Function:     SetMousePointer
    '
    ' Narrative:    Allow setting of form mouse pointer.  This one was added because
    '                   in VB 5.0, MousePointer is a property on a form.  So if the
    '                   MousePointer function was called in form code, it gave an error.
    '                   The MousePointer function above is kept for backwards compatibility.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub SetMousePointer(ByVal mp As System.Windows.Forms.Cursor)
        System.Windows.Forms.Cursor.Current = mp
    End Sub


    '
    '****************************************************************************
    ' Function:     OpenDB
    '
    ' Narrative:    Open the database.
    '
    ' Arguements:
    '
    ' Alter(s):     flgDBOpen
    '
    '****************************************************************************
    Sub OpenDB()

        Dim syserr, X, apperr As Short '02

        ' Signon has set the db type.  We don't know it yet, but this constant
        '   will tell swim that we want to set our environment to use the same type
        '   as signon specified.
        Call SetSqlType(SqlTypeDefault)

        ' Ready to roll
        X = SqlLogin("", syserr, "", apperr, "", 0)

        ' database not opened
        If X <> 0 Then
            ' leave
            Call ScreenExit("", "")

        Else ' everything OK

            flgDBOpen = True
        End If
    End Sub

    '****************************************************************************
    ' Function:     ScreenInit
    '
    ' Narrative:    Must be the first routine called by application, after all
    '               setaddr() calls have been made in Form.Load subroutine.
    '               This subroutine will call corresponding screeninit call
    '               in SWIM, as well as perform various miscellaneous tasks
    '               common to all application programs.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
#If FORM1NOTPRESENT Then
#Else
    Sub ScreenInit()

        Dim tmpstr As String

        If SystemErr() Then Exit Sub

        ' Call SWIM screeninit
        tmpstr = Form1.Text

        ' Set form location on screen (before screeninit call, which can change it's location)
        LocateForm(Form1)

        If TbOnApp = True Or Form1.Update1.Customizable = True Then
            ' Move all controls down on the screen in order to make room for the toolbar
            ' and the menu.
            '
            ' THIS MUST BE DONE PRIOR TO ScreenInit, in order to set the global variable in SWIM
            ' that indicates the Toolbar height.
            currentApplicationMenuStrip = New ApplicationMenuStrip
            Call currentApplicationMenuStrip.AddSAFMenuStrip()

            ' CUSTOMIZATION DESIGNER: Turned off until more changes.
            'Customization Desginer added to the application (if allowed)
            currentApplicationSAFDesigner = New ApplicationSAFDesigner
            Call currentApplicationSAFDesigner.AddSAFDesigner()

            If currentApplicationSAFDesigner.customizationAllowed = True Then
                'Activate right mouse click Menu Entry
                currentApplicationSAFDesigner.SetupCustomizationMenu(My.Forms.Form1)
            End If
        End If

        sw_screeninit(tmpstr)

        If SystemErr() Then Exit Sub

        ' Make sure mouse pointer is back to normal
        Call MousePointer(DefaultMouseCursor)

    End Sub

    '****************************************************************************
    ' Function:     SetReturnFromLogin
    '
    ' Narrative:    Called when command button is pressed in Database Login
    '               Form.  Set global flag indicating action.
    '
    ' Arguements:   Button == caption of button, "Cancel" or "Login"
    '
    ' Return(s):
    '
    ' Alter(s):     flgCancelPressed
    '
    '****************************************************************************
    Sub SetReturnFromLogin(ByRef Button As String)

        If Button = "Cancel" Then
            flgCancelPressed = True
        Else
            flgCancelPressed = False
        End If

    End Sub
#End If
    '****************************************************************************
    ' Function:     ApplInit
    '
    ' Narrative:    Should be called by application form.load before any other
    '               SWIM calls are made.  Perform any initialization the
    '               application may need here.
    '
    ' Arguements:
    '
    ' Alter(s):
    '
    '****************************************************************************
    Sub ApplInit()

        Dim ver As String
        Dim serr As Short
        Dim parm As String

        On Error Resume Next
#If FORM1NOTPRESENT
#else
        IconInit(My.Forms.Form1)

        ' Set mouse pointer to hourglass
        MousePointer(HourglassMouseCursor)

        ' This needs to be the first swim call in the app.
        ' We pass it a pointer to the ScreenExit2 function so
        ' that swim can shut down the VB properly whenever
        ' a fatal error occurs.  Since the apps can call LoadForm
        ' before applinit, this call needs to be there also.
        Solomon.Kernel.Exports.Instance.SetAddressofScreenExit2Callback(AddressOf ScreenExit2)

        ' Hook a FormClosing event handler within Solomon.Kernel to the FormClosing event
        AddHandler My.Forms.Form1.FormClosing, AddressOf Solomon.Kernel.Exports.Form1_FormClosing

        Call ChkParentStart()

        ' Call SWIM counterpart
        ExportsApplInit(Form1, VB.Command(), Form1.Text)
        If SystemErr() Then Exit Sub

        ' Add Form to the list of forms that need to processed for Extender providers
        ExtenderProviderProcessor.AddFormExtenderProviderList(My.Forms.Form1)

        ' Process IExtenderProviders we care about.
        ' This must be done AFTER ExportsApplInit, not before.
        ExtenderProviderProcessor.ExtenderProviderProcessAllForms()

        ' get first parm
        parm = ApplGetParms()

        ' Applic. called by parent
        flgCalledFrom = Val(parm)
        ' Check if parent application needs fired up

        If flgCalledFrom = APPLWAIT_CALLED_APPL Or flgCalledFrom = APPL_CALLED_BY_QM Then
            ' get next parm due to CallApplicWait()
            ' should indicate the Form1.hwnd of the calling program
            parm = ApplGetParms()
            CalledByHwnd = Val(parm)
            Call SetCalledByHwnd(CalledByHwnd)
        End If

#End If
        ' Time to open DB
        OpenDB()

        ' this must be first setaddr call of the application
        ' SWIM depends on location of pes for certain error checks
        ' NOTE: must be called after parent is started
        SetAddr(NOLEVEL, "bpes", bpes, PNULL)
        SetAddr(NOLEVEL, "bcuryinfo", bCuryInfo, PNULL)

        If SystemErr() Then Exit Sub

#If FORM1NOTPRESENT Then
        ' Get name of program
        bpes.CurrTitle = "CRUFLADG"
#Else
        ' Get name of program
        bpes.CurrTitle = Form1.Text
        Form1.Text += " - " + bpes.CpnyName.Trim ' UX 2009
#End If

        ' this must be called after first setaddr for bpes
        If flgCalledFrom = APPL_CALLED_BY_QM Then
            bpes.QMMode = True
        Else
            bpes.QMMode = False
        End If

        ' check version number of application for compatibility with SWIMAPI.DLL
        ver = ApplicVer()
        If ver <> APPLIC_VER Then
            Mess((MSG_SWIM_VERSION))
            Exit Sub
        End If

        ' Make sure SWIM.BAS and APPLIC.DH are compatible
        If APPLIC_VER <> SWIMBAS_VER Then
            Call sw_error("Version number in APPLIC.DH is not the same as the version number in SWIM.BAS", "", "", "")
            Exit Sub
        End If

        ' initialize SWIM overflow value
        Call floatinit(OVERFLOW)

        ' Initialize a NULL date for application
        Call dateinit(NULLDATE)

        If SystemErr() Then
            Exit Sub
            ' Make sure that update control is on form (after exit sub because only compile checking is needed)
#If FORM1NOTPRESENT Then
#Else
            Form1.Update1.Tag = ""
#End If
        End If

        ' Initialize misc applic globals
        NL.Value = Chr(13) & Chr(10)
        PRMSEP = Chr(9)

        '  Indicate that the toolbar should be created on the app - the
        '                   default behavior.  If this is not the case,
        '                   then the app will have to indicate this is false explicitly.
        TbOnApp = True
    End Sub

#If FORM1NOTPRESENT Then
#Else
    Public Sub LoadForm(ByRef Frm As System.Windows.Forms.Form)

        'Added for VB.Net.
        ' Under VB6, the first reference to the Hwnd property on a form caused the form to be loaded and
        ' its load event to be fired.  This formerly occurred in this call when .hWnd was passed to LoadForm.
        ' However, under VS2005, getting the hWnd (now handle) is not enough to cause a form to load.  The load
        ' event is now fired when the form is physically displayed, which is much later in the life of a typical
        ' application.  The typical VBTools pattern for subforms is to call LoadForm on every subform during 
        ' Form1() 's load event, prior to ApplInit.  Therefore in VB6 the form load event on all subforms 
        ' was called very early in the life of an application, prior to to ApplInit.
        '
        ' In order to preserve this behavior, we will have to call the code that was formerly in the 
        ' sub form's load event here.  We cannot simply call the subroutine representing the event handler,
        ' because that event handler will be called later when the form is actually loaded (probably 
        ' the first dispform call).  This means that subroutine will be called twice, when 
        ' under VB6 it was only called once.  This could cause undesired behavior in the application.
        '
        ' So we will call a special subroutine on the subform's class that was placed there by the
        ' code converter.  This subroutine will contain the code that was formerly in the form's load event.
        Dim methodName As String
        methodName = String.Format("{0}_LoadFormCalled", Frm.Name)
        Dim mi As System.Reflection.MethodInfo
        mi = Frm.GetType().GetMethod(methodName, Reflection.BindingFlags.Instance Or _
                                                 Reflection.BindingFlags.InvokeMethod Or _
                                                 Reflection.BindingFlags.NonPublic Or _
                                                 Reflection.BindingFlags.Public)
        If mi Is Nothing = False Then   ' If not there, we can't call it
            mi.Invoke(Frm, Nothing)
        End If

        ' This needs to be the first swim call in the app.
        ' We pass it a pointer to the ScreenExit2 function so
        ' that swim can shut down the VB properly whenever
        ' a fatal error occurs.  Since the apps can call LoadForm
        ' before applinit, this call needs to be here also.
        Solomon.Kernel.Exports.Instance.SetAddressofScreenExit2Callback(AddressOf ScreenExit2)

        ExportsLoadForm(Frm)

        ' Process IExtenderProviders we care about.
        ' This must be done AFTER ExportsLoadForm, not before.
        ExtenderProviderProcessor.AddFormExtenderProviderList(Frm)

        IconInit(Frm)

    End Sub
    Sub ScreenExit2()
        Form1.Close()
    End Sub

    Public Class ApplicationSAFDesigner
        Dim customizationControlClass As Control = Nothing
        Friend customizationAllowed As Boolean = False
        Dim currentUpdate1Control As Interop.SAF.SAFUpdate = Nothing

        Friend Sub AddSAFDesigner()

            customizationAllowed = False

            Try

                ' Customization not allowed under the following conditions:
                '   Update1.Customizable property is set false
                '   Customization level is either Standard or Supplemental
                If Form1.Update1.Customizable = False Or bpes.CustomLevel = "S" Or bpes.CustomLevel = "P" Then
                    Exit Sub
                End If

                Dim rghts As Short = getscreenaccessrights("9125000")
                If rghts <> ACCESSNORIGHTS And (rghts And ACCESSUPDATERIGHTS) Then

                    ' Must have access rights to have Customization enabled.
                    Dim Customization As [Assembly] = [Assembly].LoadFrom(My.Computer.FileSystem.CombinePath(Solomon.Kernel.Configuration.Instance.CommonFilesDirectory, "SAFDesigner.dll"))
                    customizationControlClass = Customization.CreateInstance("SAFDesigner.SAFDesigner", True)
                    customizationAllowed = True

                    ' Tell the kernel about the SAFDesigner instance
                    Solomon.Kernel.Exports.Instance.SetSAFDesignerInstance(customizationControlClass)
                Else
                    Exit Sub
                End If

            Catch ex As Exception
            End Try

        End Sub
        Friend Sub SetCurrentCustomizedForm(ByVal currentForm As Form)
            If customizationControlClass Is Nothing Then Exit Sub
            Dim CallSetCurrentCustomizedForm As MethodInfo = customizationControlClass.GetType.GetMethod("SetCurrentForm")
            CallSetCurrentCustomizedForm.Invoke(customizationControlClass, New Object() {currentForm})
        End Sub
        Friend Sub SetupCustomizationMenu(ByVal currentForm As Form)
            If customizationControlClass Is Nothing Then Exit Sub
            Dim AddCustomizationMenu As MethodInfo = customizationControlClass.GetType.GetMethod("AddCustomizationMenu")
            AddCustomizationMenu.Invoke(customizationControlClass, New Object() {currentForm})
        End Sub
    End Class

    Friend Sub AddCommonToolBarButton(ByVal name As String, ByVal tooltip As String, ByVal image As Image)

        Dim NewToolStripButton As System.Windows.Forms.ToolStripButton = New System.Windows.Forms.ToolStripButton
        Dim SAFMenu As System.Windows.Forms.ToolStrip = currentApplicationMenuStrip.menuStripControlClass.Controls.Item("SAFMenu")

        With NewToolStripButton
            .DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            .Enabled = False
            .Image = image
            .ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            .ImageTransparentColor = System.Drawing.Color.Magenta
            .Name = name
            .Size = New System.Drawing.Size(23, 22)
            .ToolTipText = tooltip
            .Enabled = True
        End With

        SAFMenu.Items.Add(NewToolStripButton)
    End Sub

    Friend Sub AddToolBarMenuSpacer()

        Dim NewToolStripSeparator As System.Windows.Forms.ToolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Dim SAFMenu As System.Windows.Forms.ToolStrip = currentApplicationMenuStrip.menuStripControlClass.Controls.Item("SAFMenu")

        With NewToolStripSeparator
            .DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            .Enabled = False
            .ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
            .Name = "paMenuSeparator"
            .Enabled = True
        End With

        SAFMenu.Items.Add(NewToolStripSeparator)

    End Sub

    Public Class ApplicationMenuStrip

        'TODO needs comments!!!
        Friend menuStripControlClass As Control
        Dim methodInfosetMenuButtonEnabled As MethodInfo
        Dim methodInfogetMenuButtonEnabled As MethodInfo
        Dim methodInfosetCurrencyImage As MethodInfo
        Dim methodInfosetNoteButtonAppearance As MethodInfo
        Dim methodInfoGrid2ExcelInfo As MethodInfo

        Friend Sub AddSAFMenuStrip()


            Dim SAFMenuStripAssembly As [Assembly] = [Assembly].LoadFrom(My.Computer.FileSystem.CombinePath(Solomon.Kernel.Configuration.Instance.CommonFilesDirectory, "SAFMenuStrip.dll"))
            menuStripControlClass = SAFMenuStripAssembly.CreateInstance("SAFMenuStrip.SAFMenuStrip", True)

            menuStripControlClass.Name = "ApplicationMenuStrip"
            menuStripControlClass.Top = 0
            menuStripControlClass.Left = 0
            menuStripControlClass.Dock = DockStyle.Top
            ' Next two commented out lines are useful to ISVs that may want to stack menus (multiple menus) and the Dock setting conflicts with them.
            'menuStripControlClass.Width = Form1.ClientSize.Width - 15 ' width setting varies based upon Fonts, Margin and AutoScaleMode settings.
            'menuStripControlClass.Anchor = AnchorStyles.Left + AnchorStyles.Top + AnchorStyles.Right
            If TbOnApp = False Then menuStripControlClass.Visible = False

            'Move the application controls down to make room for the menu strip.
            For Each c As Control In My.Forms.Form1.Controls
                c.Top += menuStripControlClass.Height
            Next

            My.Forms.Form1.Height += menuStripControlClass.Height
            AppToolbarInit(menuStripControlClass.Height)


            'Add and display the menu strip on the Main form.
            My.Forms.Form1.Controls.Add(menuStripControlClass)

            methodInfosetMenuButtonEnabled = menuStripControlClass.GetType.GetMethod("setButtonEnabled")
            methodInfogetMenuButtonEnabled = menuStripControlClass.GetType.GetMethod("getButtonEnabled")
            methodInfosetCurrencyImage = menuStripControlClass.GetType.GetMethod("setCurrencyImage")
            methodInfosetNoteButtonAppearance = menuStripControlClass.GetType.GetMethod("setNoteButtonAppearance")
            Dim methodInfoCompanyInfo As MethodInfo = menuStripControlClass.GetType.GetMethod("setCompanyInfo")

            If methodInfosetMenuButtonEnabled Is Nothing Or methodInfogetMenuButtonEnabled Is Nothing Then
                'ERROR
            Else
                Solomon.Kernel.Exports.Instance.SetAddressofApplicationMenuStripMethods(AddressOf setMenuButtonEnabled, _
                                                                                        AddressOf getMenuButtonEnabled, _
                                                                                        AddressOf setCurrencyImage, _
                                                                                        AddressOf setNoteButtonAppearance)
                If Not methodInfoCompanyInfo Is Nothing Then
                    methodInfoCompanyInfo.Invoke(menuStripControlClass, New Object() {bpes.CpnyID, bpes.CpnyName, bpes.CpnyColor})
                End If

                methodInfoGrid2ExcelInfo = menuStripControlClass.GetType.GetMethod("Grid2Excel")
                If Not methodInfoGrid2ExcelInfo Is Nothing Then
                    Solomon.Kernel.Exports.Instance.SetAddressofGrid2ExcelCallback(AddressOf setGrid2Excel)
                End If

            End If


        End Sub

        Public Sub setMenuButtonEnabled(ByVal buttonID As Integer, ByVal enableState As Boolean)
            methodInfosetMenuButtonEnabled.Invoke(menuStripControlClass, New Object() {buttonID, enableState})
        End Sub
        Public Function getMenuButtonEnabled(ByVal buttonID As Integer) As Boolean
            Return (methodInfogetMenuButtonEnabled.Invoke(menuStripControlClass, New Object() {buttonID}))
        End Function
        Public Sub setCurrencyImage(ByVal imageFile As String)
            methodInfosetCurrencyImage.Invoke(menuStripControlClass, New Object() {imageFile})
        End Sub
        Public Sub setNoteButtonAppearance(ByVal noteButton As Control, ByVal noteButtonPopulated As Boolean, ByVal attachmentButtonPopulated As Boolean)
            methodInfosetNoteButtonAppearance.Invoke(menuStripControlClass, New Object() {noteButton, noteButtonPopulated, attachmentButtonPopulated})
        End Sub
        Public Sub setGrid2Excel(ByVal formatString As String)
            methodInfoGrid2ExcelInfo.Invoke(menuStripControlClass, New Object() {formatString, Form1.Text, bpes.ScrnNbr})
        End Sub

    End Class
#End If


    Sub IconInit(ByVal currentForm As Form)

        ' Change runtime icon to Microsoft Dynamics logo icon at runtime.
        Dim iconDirectory As String = My.Computer.Registry.GetValue(INSTALLATION_REGISTRYENTRY, INSTALLATION_REGISTRYKEY, "")
        currentForm.Icon = Icon.ExtractAssociatedIcon(My.Computer.FileSystem.CombinePath(iconDirectory, PARENT_APP_NAME))

    End Sub

    ' End swim.bas ************************************************************************************************
#End If
#End Region


    ' Begin SolomonKernel.Exports ************************************************************************************************
    Private Interface ISolomonDataObjectItem
        ReadOnly Property Item() As Object
    End Interface

    Private Class SolomonDataObject_Double
        Inherits SolomonDataObject
        Implements ISolomonDataObjectItem

        <DataBinding(PropertyIndex:=0)> _
        Public Property Value() As Double

            Get
                Return CType(Me.GetPropertyValue("Value"), Double)
            End Get

            Set(ByVal setval As Double)
                Me.SetPropertyValue("Value", setval)
            End Set

        End Property

        Public ReadOnly Property Item() As Object Implements ISolomonDataObjectItem.Item
            Get
                Return Me.Value
            End Get
        End Property

    End Class

    Private Class SolomonDataObject_String
        Inherits SolomonDataObject
        Implements ISolomonDataObjectItem

        ' StringSize has to be big enough to handle the largest result from SQL 
        <DataBinding(PropertyIndex:=0, StringSize:=8192)> _
        Public Property Value() As String

            Get
                Return CType(Me.GetPropertyValue("Value"), String).Trim     ' trim the result so we are not returning a huge string back to the caller
            End Get

            Set(ByVal setval As String)
                Me.SetPropertyValue("Value", setval)
            End Set

        End Property

        Public ReadOnly Property Item() As Object Implements ISolomonDataObjectItem.Item
            Get
                Return Me.Value
            End Get
        End Property

    End Class

    Private Class SolomonDataObject_Short
        Inherits SolomonDataObject
        Implements ISolomonDataObjectItem

        <DataBinding(PropertyIndex:=0)> _
        Public Property Value() As Short

            Get
                Return CType(Me.GetPropertyValue("Value"), Short)
            End Get

            Set(ByVal setval As Short)
                Me.SetPropertyValue("Value", setval)
            End Set

        End Property

        Public ReadOnly Property Item() As Object Implements ISolomonDataObjectItem.Item
            Get
                Return Me.Value
            End Get
        End Property

    End Class

    Private Class SolomonDataObject_Integer
        Inherits SolomonDataObject
        Implements ISolomonDataObjectItem

        <DataBinding(PropertyIndex:=0)> _
        Public Property Value() As Integer

            Get
                Return CType(Me.GetPropertyValue("Value"), Integer)
            End Get

            Set(ByVal setval As Integer)
                Me.SetPropertyValue("Value", setval)
            End Set

        End Property

        Public ReadOnly Property Item() As Object Implements ISolomonDataObjectItem.Item
            Get
                Return Me.Value
            End Get
        End Property

    End Class

    Public SolomonKernelExports As Exports = Solomon.Kernel.Exports.Instance

    ' named so as not to conflict with SWIM.bas LoadForm
    Public Sub ExportsLoadForm(ByRef frm As Form)
        SolomonKernelExports.LoadForm(frm)
    End Sub

    Public Sub SetAddr(ByVal LevelNbr As Short, ByVal TableNameStr As String, ByRef bTableName As SolomonDataObject, ByRef nTableName As Object)
        SolomonKernelExports.SetAddr(LevelNbr, TableNameStr, bTableName, nTableName)
    End Sub

    Sub ExportsApplInit(ByRef form1 As Form, ByVal cmdLine As String, ByVal screenCaption As String)
        SolomonKernelExports.ApplInit(form1, cmdLine, screenCaption)
    End Sub

    Function PVChkFetch1(ByVal Ctrl As Object, ByRef Cursor As Short, ByVal SQLParmValue As String, ByRef bTable1 As SolomonDataObject) As Short
        PVChkFetch1 = SolomonKernelExports.PVChkFetch1(Ctrl, Cursor, SQLParmValue, bTable1)
    End Function

    Function PVChkFetch4(ByVal Ctrl As Object, ByRef Cursor As Short, ByVal SQLParmValue As String, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object) As Short
        PVChkFetch4 = SolomonKernelExports.PVChkFetch4(Ctrl, Cursor, SQLParmValue, bTable1, bTable2, bTable3, bTable4)
    End Function

    Function PVChkFetch8(ByVal Ctrl As Object, ByRef Cursor As Short, ByVal SQLParmValue As String, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object, ByRef bTable5 As Object, ByRef bTable6 As Object, ByRef bTable7 As Object, ByRef bTable8 As Object) As Short
        PVChkFetch8 = SolomonKernelExports.PVChkFetch8(Ctrl, Cursor, SQLParmValue, bTable1, bTable2, bTable3, bTable4, bTable5, bTable6, bTable7, bTable8)
    End Function

    Sub SInsert1(ByVal Cursor As Short, ByVal TablesInsertingInto As String, ByRef bTable1 As SolomonDataObject)
        SolomonKernelExports.SInsert1(Cursor, TablesInsertingInto, bTable1)
    End Sub
    Sub SInsert4(ByVal Cursor As Short, ByVal TablesInsertingInto As String, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object)
        SolomonKernelExports.SInsert4(Cursor, TablesInsertingInto, bTable1, bTable2, bTable3, bTable4)
    End Sub
    Sub SInsert8(ByVal Cursor As Short, ByVal TablesInsertingInto As String, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object, ByRef bTable5 As Object, ByRef bTable6 As Object, ByRef bTable7 As Object, ByRef bTable8 As Object)
        SolomonKernelExports.SInsert8(Cursor, TablesInsertingInto, bTable1, bTable2, bTable3, bTable4, bTable5, bTable6, bTable7, bTable8)
    End Sub
    Public Function SqlFetch1(ByRef cursor As Short, _
                              ByVal sqlStatement As String, _
                              ByRef bTable1 As Object _
                              ) As Short

        SqlFetch1 = SqlFetch8(cursor, sqlStatement, bTable1, PNULL, PNULL, PNULL, PNULL, PNULL, PNULL, PNULL)

    End Function

    Public Function SqlFetch4(ByRef Cursor As Short, _
                              ByVal sqlStatement As String, _
                              ByRef bTable1 As Object, _
                              ByRef bTable2 As Object, _
                              ByRef bTable3 As Object, _
                              ByRef bTable4 As Object _
                              ) As Short

        SqlFetch4 = SqlFetch8(Cursor, sqlStatement, bTable1, bTable2, bTable3, bTable4, PNULL, PNULL, PNULL, PNULL)

    End Function

    Public Function SqlFetch8(ByRef Cursor As Short, _
                              ByVal SqlStr As String, _
                              ByRef bTable1 As Object, _
                              ByRef bTable2 As Object, _
                              ByRef bTable3 As Object, _
                              ByRef bTable4 As Object, _
                              ByRef bTable5 As Object, _
                              ByRef bTable6 As Object, _
                              ByRef bTable7 As Object, _
                              ByRef bTable8 As Object _
                              ) As Short

        ' set parm1 to new SDO if necessary
        Dim parm1 As SolomonDataObject
        If TypeOf bTable1 Is SolomonDataObject Then
            parm1 = CType(bTable1, SolomonDataObject)
        ElseIf TypeOf bTable1 Is Double Then
            parm1 = New SolomonDataObject_Double
        ElseIf TypeOf bTable1 Is String Then
            parm1 = New SolomonDataObject_String
        ElseIf TypeOf bTable1 Is Short Then
            parm1 = New SolomonDataObject_Short
        ElseIf TypeOf bTable1 Is Integer Then
            parm1 = New SolomonDataObject_Integer
        ElseIf bTable1 Is Nothing Then
            Throw New System.ArgumentNullException("bTable1", String.Format("Argument '{0}' cannot be set to Nothing.", "bTable1"))
        Else ' we must have a first parm
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable1", bTable1.GetType.ToString()))
        End If

        ' set parm2 to new SDO if necessary
        Dim parm2 As Object
        If TypeOf bTable2 Is SolomonDataObject Then
            parm2 = CType(bTable2, SolomonDataObject)
        ElseIf TypeOf bTable2 Is Double Then
            parm2 = New SolomonDataObject_Double
        ElseIf TypeOf bTable2 Is String Then
            parm2 = New SolomonDataObject_String
        ElseIf TypeOf bTable2 Is Short Then
            parm2 = New SolomonDataObject_Short
        ElseIf TypeOf bTable2 Is Integer Then
            parm2 = New SolomonDataObject_Integer
        ElseIf bTable2 Is Nothing Or TypeOf bTable2 Is NullObjectType = True Then
            parm2 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable2", bTable2.GetType.ToString()))
        End If

        ' set parm3 to new SDO if necessary
        Dim parm3 As Object
        If TypeOf bTable3 Is SolomonDataObject Then
            parm3 = CType(bTable3, SolomonDataObject)
        ElseIf TypeOf bTable3 Is Double Then
            parm3 = New SolomonDataObject_Double
        ElseIf TypeOf bTable3 Is String Then
            parm3 = New SolomonDataObject_String
        ElseIf TypeOf bTable3 Is Short Then
            parm3 = New SolomonDataObject_Short
        ElseIf TypeOf bTable3 Is Integer Then
            parm3 = New SolomonDataObject_Integer
        ElseIf bTable3 Is Nothing Or TypeOf bTable3 Is NullObjectType = True Then
            parm3 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable3", bTable3.GetType.ToString()))
        End If

        ' set parm4 to new SDO if necessary
        Dim parm4 As Object
        If TypeOf bTable4 Is SolomonDataObject Then
            parm4 = CType(bTable4, SolomonDataObject)
        ElseIf TypeOf bTable4 Is Double Then
            parm4 = New SolomonDataObject_Double
        ElseIf TypeOf bTable4 Is String Then
            parm4 = New SolomonDataObject_String
        ElseIf TypeOf bTable4 Is Short Then
            parm4 = New SolomonDataObject_Short
        ElseIf TypeOf bTable4 Is Integer Then
            parm4 = New SolomonDataObject_Integer
        ElseIf bTable4 Is Nothing Or TypeOf bTable4 Is NullObjectType = True Then
            parm4 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable4", bTable4.GetType.ToString()))
        End If

        ' set parm5 to new SDO if necessary
        Dim parm5 As Object
        If TypeOf bTable5 Is SolomonDataObject Then
            parm5 = CType(bTable5, SolomonDataObject)
        ElseIf TypeOf bTable5 Is Double Then
            parm5 = New SolomonDataObject_Double
        ElseIf TypeOf bTable5 Is String Then
            parm5 = New SolomonDataObject_String
        ElseIf TypeOf bTable5 Is Short Then
            parm5 = New SolomonDataObject_Short
        ElseIf TypeOf bTable5 Is Integer Then
            parm5 = New SolomonDataObject_Integer
        ElseIf bTable5 Is Nothing Or TypeOf bTable5 Is NullObjectType = True Then
            parm5 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable5", bTable5.GetType.ToString()))
        End If

        ' set parm6 to new SDO if necessary
        Dim parm6 As Object
        If TypeOf bTable6 Is SolomonDataObject Then
            parm6 = CType(bTable6, SolomonDataObject)
        ElseIf TypeOf bTable6 Is Double Then
            parm6 = New SolomonDataObject_Double
        ElseIf TypeOf bTable6 Is String Then
            parm6 = New SolomonDataObject_String
        ElseIf TypeOf bTable6 Is Short Then
            parm6 = New SolomonDataObject_Short
        ElseIf TypeOf bTable6 Is Integer Then
            parm6 = New SolomonDataObject_Integer
        ElseIf bTable6 Is Nothing Or TypeOf bTable6 Is NullObjectType = True Then
            parm6 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable6", bTable6.GetType.ToString()))
        End If

        ' set parm7 to new SDO if necessary
        Dim parm7 As Object
        If TypeOf bTable7 Is SolomonDataObject Then
            parm7 = CType(bTable7, SolomonDataObject)
        ElseIf TypeOf bTable7 Is Double Then
            parm7 = New SolomonDataObject_Double
        ElseIf TypeOf bTable7 Is String Then
            parm7 = New SolomonDataObject_String
        ElseIf TypeOf bTable7 Is Short Then
            parm7 = New SolomonDataObject_Short
        ElseIf TypeOf bTable7 Is Integer Then
            parm7 = New SolomonDataObject_Integer
        ElseIf bTable7 Is Nothing Or TypeOf bTable7 Is NullObjectType = True Then
            parm7 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable7", bTable7.GetType.ToString()))
        End If

        ' set parm8 to new SDO if necessary
        Dim parm8 As Object
        If TypeOf bTable8 Is SolomonDataObject Then
            parm8 = CType(bTable8, SolomonDataObject)
        ElseIf TypeOf bTable8 Is Double Then
            parm8 = New SolomonDataObject_Double
        ElseIf TypeOf bTable8 Is String Then
            parm8 = New SolomonDataObject_String
        ElseIf TypeOf bTable8 Is Short Then
            parm8 = New SolomonDataObject_Short
        ElseIf TypeOf bTable8 Is Integer Then
            parm8 = New SolomonDataObject_Integer
        ElseIf bTable8 Is Nothing Or TypeOf bTable8 Is NullObjectType = True Then
            parm8 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable8", bTable8.GetType.ToString()))
        End If

        ' call the kernel
        SqlFetch8 = SolomonKernelExports.SqlFetch8(Cursor, SqlStr, parm1, parm2, parm3, parm4, parm5, parm6, parm7, parm8)

        If SqlFetch8 = 0 Then
            ' assign value from SDO to the argument reference return value
            If TypeOf parm1 Is ISolomonDataObjectItem Then bTable1 = CType(parm1, ISolomonDataObjectItem).Item
            If TypeOf parm2 Is ISolomonDataObjectItem Then bTable2 = CType(parm2, ISolomonDataObjectItem).Item
            If TypeOf parm3 Is ISolomonDataObjectItem Then bTable3 = CType(parm3, ISolomonDataObjectItem).Item
            If TypeOf parm4 Is ISolomonDataObjectItem Then bTable4 = CType(parm4, ISolomonDataObjectItem).Item
            If TypeOf parm5 Is ISolomonDataObjectItem Then bTable5 = CType(parm5, ISolomonDataObjectItem).Item
            If TypeOf parm6 Is ISolomonDataObjectItem Then bTable6 = CType(parm6, ISolomonDataObjectItem).Item
            If TypeOf parm7 Is ISolomonDataObjectItem Then bTable7 = CType(parm7, ISolomonDataObjectItem).Item
            If TypeOf parm8 Is ISolomonDataObjectItem Then bTable8 = CType(parm8, ISolomonDataObjectItem).Item
        End If

    End Function

    Public Function SFetch1(ByVal cursor As Short, _
                            ByRef bTable1 As Object) As Short

        SFetch1 = SFetch8(cursor, bTable1, PNULL, PNULL, PNULL, PNULL, PNULL, PNULL, PNULL)

    End Function

    Function SFetch4(ByVal Cursor As Short, _
                     ByRef bTable1 As Object, _
                     ByRef bTable2 As Object, _
                     ByRef bTable3 As Object, _
                     ByRef bTable4 As Object _
                     ) As Short

        SFetch4 = SFetch8(Cursor, bTable1, bTable2, bTable3, bTable4, PNULL, PNULL, PNULL, PNULL)

    End Function

    Function SFetch8(ByVal Cursor As Short, _
                     ByRef bTable1 As Object, _
                     ByRef bTable2 As Object, _
                     ByRef bTable3 As Object, _
                     ByRef bTable4 As Object, _
                     ByRef bTable5 As Object, _
                     ByRef bTable6 As Object, _
                     ByRef bTable7 As Object, _
                     ByRef bTable8 As Object _
                     ) As Short

        ' set parm1 to new SDO if necessary
        Dim parm1 As SolomonDataObject
        If TypeOf bTable1 Is SolomonDataObject Then
            parm1 = CType(bTable1, SolomonDataObject)
        ElseIf TypeOf bTable1 Is Double Then
            parm1 = New SolomonDataObject_Double
        ElseIf TypeOf bTable1 Is String Then
            parm1 = New SolomonDataObject_String
        ElseIf TypeOf bTable1 Is Short Then
            parm1 = New SolomonDataObject_Short
        ElseIf TypeOf bTable1 Is Integer Then
            parm1 = New SolomonDataObject_Integer
        ElseIf bTable1 Is Nothing Then
            Throw New System.ArgumentNullException("bTable1", String.Format("Argument '{0}' cannot be set to Nothing.", "bTable1"))
        Else ' we must have a first parm
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable1", bTable1.GetType.ToString()))
        End If

        ' set parm2 to new SDO if necessary
        Dim parm2 As Object
        If TypeOf bTable2 Is SolomonDataObject Then
            parm2 = CType(bTable2, SolomonDataObject)
        ElseIf TypeOf bTable2 Is Double Then
            parm2 = New SolomonDataObject_Double
        ElseIf TypeOf bTable2 Is String Then
            parm2 = New SolomonDataObject_String
        ElseIf TypeOf bTable2 Is Short Then
            parm2 = New SolomonDataObject_Short
        ElseIf TypeOf bTable2 Is Integer Then
            parm2 = New SolomonDataObject_Integer
        ElseIf bTable2 Is Nothing Or TypeOf bTable2 Is NullObjectType = True Then
            parm2 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable2", bTable2.GetType.ToString()))
        End If

        ' set parm3 to new SDO if necessary
        Dim parm3 As Object
        If TypeOf bTable3 Is SolomonDataObject Then
            parm3 = CType(bTable3, SolomonDataObject)
        ElseIf TypeOf bTable3 Is Double Then
            parm3 = New SolomonDataObject_Double
        ElseIf TypeOf bTable3 Is String Then
            parm3 = New SolomonDataObject_String
        ElseIf TypeOf bTable3 Is Short Then
            parm3 = New SolomonDataObject_Short
        ElseIf TypeOf bTable3 Is Integer Then
            parm3 = New SolomonDataObject_Integer
        ElseIf bTable3 Is Nothing Or TypeOf bTable3 Is NullObjectType = True Then
            parm3 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable3", bTable3.GetType.ToString()))
        End If

        ' set parm4 to new SDO if necessary
        Dim parm4 As Object
        If TypeOf bTable4 Is SolomonDataObject Then
            parm4 = CType(bTable4, SolomonDataObject)
        ElseIf TypeOf bTable4 Is Double Then
            parm4 = New SolomonDataObject_Double
        ElseIf TypeOf bTable4 Is String Then
            parm4 = New SolomonDataObject_String
        ElseIf TypeOf bTable4 Is Short Then
            parm4 = New SolomonDataObject_Short
        ElseIf TypeOf bTable4 Is Integer Then
            parm4 = New SolomonDataObject_Integer
        ElseIf bTable4 Is Nothing Or TypeOf bTable4 Is NullObjectType = True Then
            parm4 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable4", bTable4.GetType.ToString()))
        End If

        ' set parm5 to new SDO if necessary
        Dim parm5 As Object
        If TypeOf bTable5 Is SolomonDataObject Then
            parm5 = CType(bTable5, SolomonDataObject)
        ElseIf TypeOf bTable5 Is Double Then
            parm5 = New SolomonDataObject_Double
        ElseIf TypeOf bTable5 Is String Then
            parm5 = New SolomonDataObject_String
        ElseIf TypeOf bTable5 Is Short Then
            parm5 = New SolomonDataObject_Short
        ElseIf TypeOf bTable5 Is Integer Then
            parm5 = New SolomonDataObject_Integer
        ElseIf bTable5 Is Nothing Or TypeOf bTable5 Is NullObjectType = True Then
            parm5 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable5", bTable5.GetType.ToString()))
        End If

        ' set parm6 to new SDO if necessary
        Dim parm6 As Object
        If TypeOf bTable6 Is SolomonDataObject Then
            parm6 = CType(bTable6, SolomonDataObject)
        ElseIf TypeOf bTable6 Is Double Then
            parm6 = New SolomonDataObject_Double
        ElseIf TypeOf bTable6 Is String Then
            parm6 = New SolomonDataObject_String
        ElseIf TypeOf bTable6 Is Short Then
            parm6 = New SolomonDataObject_Short
        ElseIf TypeOf bTable6 Is Integer Then
            parm6 = New SolomonDataObject_Integer
        ElseIf bTable6 Is Nothing Or TypeOf bTable6 Is NullObjectType = True Then
            parm6 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable6", bTable6.GetType.ToString()))
        End If

        ' set parm7 to new SDO if necessary
        Dim parm7 As Object
        If TypeOf bTable7 Is SolomonDataObject Then
            parm7 = CType(bTable7, SolomonDataObject)
        ElseIf TypeOf bTable7 Is Double Then
            parm7 = New SolomonDataObject_Double
        ElseIf TypeOf bTable7 Is String Then
            parm7 = New SolomonDataObject_String
        ElseIf TypeOf bTable7 Is Short Then
            parm7 = New SolomonDataObject_Short
        ElseIf TypeOf bTable7 Is Integer Then
            parm7 = New SolomonDataObject_Integer
        ElseIf bTable7 Is Nothing Or TypeOf bTable7 Is NullObjectType = True Then
            parm7 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable7", bTable7.GetType.ToString()))
        End If

        ' set parm8 to new SDO if necessary
        Dim parm8 As Object
        If TypeOf bTable8 Is SolomonDataObject Then
            parm8 = CType(bTable8, SolomonDataObject)
        ElseIf TypeOf bTable8 Is Double Then
            parm8 = New SolomonDataObject_Double
        ElseIf TypeOf bTable8 Is String Then
            parm8 = New SolomonDataObject_String
        ElseIf TypeOf bTable8 Is Short Then
            parm8 = New SolomonDataObject_Short
        ElseIf TypeOf bTable8 Is Integer Then
            parm8 = New SolomonDataObject_Integer
        ElseIf bTable8 Is Nothing Or TypeOf bTable8 Is NullObjectType = True Then
            parm8 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable8", bTable8.GetType.ToString()))
        End If

        ' call the kernel
        SFetch8 = SolomonKernelExports.SFetch8(Cursor, parm1, parm2, parm3, parm4, parm5, parm6, parm7, parm8)

        If SFetch8 = 0 Then
            ' assign value from SDO to the argument reference return value
            If TypeOf parm1 Is ISolomonDataObjectItem Then bTable1 = CType(parm1, ISolomonDataObjectItem).Item
            If TypeOf parm2 Is ISolomonDataObjectItem Then bTable2 = CType(parm2, ISolomonDataObjectItem).Item
            If TypeOf parm3 Is ISolomonDataObjectItem Then bTable3 = CType(parm3, ISolomonDataObjectItem).Item
            If TypeOf parm4 Is ISolomonDataObjectItem Then bTable4 = CType(parm4, ISolomonDataObjectItem).Item
            If TypeOf parm5 Is ISolomonDataObjectItem Then bTable5 = CType(parm5, ISolomonDataObjectItem).Item
            If TypeOf parm6 Is ISolomonDataObjectItem Then bTable6 = CType(parm6, ISolomonDataObjectItem).Item
            If TypeOf parm7 Is ISolomonDataObjectItem Then bTable7 = CType(parm7, ISolomonDataObjectItem).Item
            If TypeOf parm8 Is ISolomonDataObjectItem Then bTable8 = CType(parm8, ISolomonDataObjectItem).Item

        End If

    End Function

    Sub SUpdate1(ByVal Cursor As Short, ByVal TablesUpdating As String, ByRef bTable1 As SolomonDataObject)
        SolomonKernelExports.SUpdate1(Cursor, TablesUpdating, bTable1)
    End Sub
    Sub SUpdate4(ByVal Cursor As Short, ByVal TablesUpdating As String, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object)
        SolomonKernelExports.SUpdate4(Cursor, TablesUpdating, bTable1, bTable2, bTable3, bTable4)
    End Sub
    Sub SUpdate8(ByVal Cursor As Short, ByVal TablesUpdating As String, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object, ByRef bTable5 As Object, ByRef bTable6 As Object, ByRef bTable7 As Object, ByRef bTable8 As Object)
        SolomonKernelExports.SUpdate8(Cursor, TablesUpdating, bTable1, bTable2, bTable3, bTable4, bTable5, bTable6, bTable7, bTable8)
    End Sub
    Function SGroupFetch1(ByVal Cursor As Short, ByRef bTable1 As SolomonDataObject) As Short
        SGroupFetch1 = SolomonKernelExports.SGroupFetch1(Cursor, bTable1)
    End Function

    Public Function SGroupFetch1(ByVal cursor As Short, _
                            ByRef bTable1 As Object) As Short

        SGroupFetch1 = SGroupFetch8(cursor, bTable1, PNULL, PNULL, PNULL, PNULL, PNULL, PNULL, PNULL)

    End Function

    Function SGroupFetch4(ByVal Cursor As Short, _
                          ByRef bTable1 As Object, _
                          ByRef bTable2 As Object, _
                          ByRef bTable3 As Object, _
                          ByRef bTable4 As Object _
                          ) As Short

        SGroupFetch4 = SGroupFetch8(Cursor, bTable1, bTable2, bTable3, bTable4, PNULL, PNULL, PNULL, PNULL)

    End Function

    Function SGroupFetch8(ByVal Cursor As Short, _
                          ByRef bTable1 As Object, _
                          ByRef bTable2 As Object, _
                          ByRef bTable3 As Object, _
                          ByRef bTable4 As Object, _
                          ByRef bTable5 As Object, _
                          ByRef bTable6 As Object, _
                          ByRef bTable7 As Object, _
                          ByRef bTable8 As Object _
                          ) As Short

        ' set parm1 to new SDO if necessary
        Dim parm1 As SolomonDataObject
        If TypeOf bTable1 Is SolomonDataObject Then
            parm1 = CType(bTable1, SolomonDataObject)
        ElseIf TypeOf bTable1 Is Double Then
            parm1 = New SolomonDataObject_Double
        ElseIf TypeOf bTable1 Is String Then
            parm1 = New SolomonDataObject_String
        ElseIf TypeOf bTable1 Is Short Then
            parm1 = New SolomonDataObject_Short
        ElseIf TypeOf bTable1 Is Integer Then
            parm1 = New SolomonDataObject_Integer
        ElseIf bTable1 Is Nothing Then
            Throw New System.ArgumentNullException("bTable1", String.Format("Argument '{0}' cannot be set to Nothing.", "bTable1"))
        Else ' we must have a first parm
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable1", bTable1.GetType.ToString()))
        End If

        ' set parm2 to new SDO if necessary
        Dim parm2 As Object
        If TypeOf bTable2 Is SolomonDataObject Then
            parm2 = CType(bTable2, SolomonDataObject)
        ElseIf TypeOf bTable2 Is Double Then
            parm2 = New SolomonDataObject_Double
        ElseIf TypeOf bTable2 Is String Then
            parm2 = New SolomonDataObject_String
        ElseIf TypeOf bTable2 Is Short Then
            parm2 = New SolomonDataObject_Short
        ElseIf TypeOf bTable2 Is Integer Then
            parm2 = New SolomonDataObject_Integer
        ElseIf bTable2 Is Nothing Or TypeOf bTable2 Is NullObjectType = True Then
            parm2 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable2", bTable2.GetType.ToString()))
        End If

        ' set parm3 to new SDO if necessary
        Dim parm3 As Object
        If TypeOf bTable3 Is SolomonDataObject Then
            parm3 = CType(bTable3, SolomonDataObject)
        ElseIf TypeOf bTable3 Is Double Then
            parm3 = New SolomonDataObject_Double
        ElseIf TypeOf bTable3 Is String Then
            parm3 = New SolomonDataObject_String
        ElseIf TypeOf bTable3 Is Short Then
            parm3 = New SolomonDataObject_Short
        ElseIf TypeOf bTable3 Is Integer Then
            parm3 = New SolomonDataObject_Integer
        ElseIf bTable3 Is Nothing Or TypeOf bTable3 Is NullObjectType = True Then
            parm3 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable3", bTable3.GetType.ToString()))
        End If

        ' set parm4 to new SDO if necessary
        Dim parm4 As Object
        If TypeOf bTable4 Is SolomonDataObject Then
            parm4 = CType(bTable4, SolomonDataObject)
        ElseIf TypeOf bTable4 Is Double Then
            parm4 = New SolomonDataObject_Double
        ElseIf TypeOf bTable4 Is String Then
            parm4 = New SolomonDataObject_String
        ElseIf TypeOf bTable4 Is Short Then
            parm4 = New SolomonDataObject_Short
        ElseIf TypeOf bTable4 Is Integer Then
            parm4 = New SolomonDataObject_Integer
        ElseIf bTable4 Is Nothing Or TypeOf bTable4 Is NullObjectType = True Then
            parm4 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable4", bTable4.GetType.ToString()))
        End If

        ' set parm5 to new SDO if necessary
        Dim parm5 As Object
        If TypeOf bTable5 Is SolomonDataObject Then
            parm5 = CType(bTable5, SolomonDataObject)
        ElseIf TypeOf bTable5 Is Double Then
            parm5 = New SolomonDataObject_Double
        ElseIf TypeOf bTable5 Is String Then
            parm5 = New SolomonDataObject_String
        ElseIf TypeOf bTable5 Is Short Then
            parm5 = New SolomonDataObject_Short
        ElseIf TypeOf bTable5 Is Integer Then
            parm5 = New SolomonDataObject_Integer
        ElseIf bTable5 Is Nothing Or TypeOf bTable5 Is NullObjectType = True Then
            parm5 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable5", bTable5.GetType.ToString()))
        End If

        ' set parm6 to new SDO if necessary
        Dim parm6 As Object
        If TypeOf bTable6 Is SolomonDataObject Then
            parm6 = CType(bTable6, SolomonDataObject)
        ElseIf TypeOf bTable6 Is Double Then
            parm6 = New SolomonDataObject_Double
        ElseIf TypeOf bTable6 Is String Then
            parm6 = New SolomonDataObject_String
        ElseIf TypeOf bTable6 Is Short Then
            parm6 = New SolomonDataObject_Short
        ElseIf TypeOf bTable6 Is Integer Then
            parm6 = New SolomonDataObject_Integer
        ElseIf bTable6 Is Nothing Or TypeOf bTable6 Is NullObjectType = True Then
            parm6 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable6", bTable6.GetType.ToString()))
        End If

        ' set parm7 to new SDO if necessary
        Dim parm7 As Object
        If TypeOf bTable7 Is SolomonDataObject Then
            parm7 = CType(bTable7, SolomonDataObject)
        ElseIf TypeOf bTable7 Is Double Then
            parm7 = New SolomonDataObject_Double
        ElseIf TypeOf bTable7 Is String Then
            parm7 = New SolomonDataObject_String
        ElseIf TypeOf bTable7 Is Short Then
            parm7 = New SolomonDataObject_Short
        ElseIf TypeOf bTable7 Is Integer Then
            parm7 = New SolomonDataObject_Integer
        ElseIf bTable7 Is Nothing Or TypeOf bTable7 Is NullObjectType = True Then
            parm7 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable7", bTable7.GetType.ToString()))
        End If

        ' set parm8 to new SDO if necessary
        Dim parm8 As Object
        If TypeOf bTable8 Is SolomonDataObject Then
            parm8 = CType(bTable8, SolomonDataObject)
        ElseIf TypeOf bTable8 Is Double Then
            parm8 = New SolomonDataObject_Double
        ElseIf TypeOf bTable8 Is String Then
            parm8 = New SolomonDataObject_String
        ElseIf TypeOf bTable8 Is Short Then
            parm8 = New SolomonDataObject_Short
        ElseIf TypeOf bTable8 Is Integer Then
            parm8 = New SolomonDataObject_Integer
        ElseIf bTable8 Is Nothing Or TypeOf bTable8 Is NullObjectType = True Then
            parm8 = PNULL
        Else
            Throw New System.ArgumentException(String.Format("Argument '{0}' cannot be of type {1}.", "bTable8", bTable8.GetType.ToString()))
        End If

        ' call the kernel
        SGroupFetch8 = SolomonKernelExports.SGroupFetch8(Cursor, parm1, parm2, parm3, parm4, parm5, parm6, parm7, parm8)

        If SGroupFetch8 = 0 Then
            ' assign value from SDO to the argument reference return value
            If TypeOf parm1 Is ISolomonDataObjectItem Then bTable1 = CType(parm1, ISolomonDataObjectItem).Item
            If TypeOf parm2 Is ISolomonDataObjectItem Then bTable2 = CType(parm2, ISolomonDataObjectItem).Item
            If TypeOf parm3 Is ISolomonDataObjectItem Then bTable3 = CType(parm3, ISolomonDataObjectItem).Item
            If TypeOf parm4 Is ISolomonDataObjectItem Then bTable4 = CType(parm4, ISolomonDataObjectItem).Item
            If TypeOf parm5 Is ISolomonDataObjectItem Then bTable5 = CType(parm5, ISolomonDataObjectItem).Item
            If TypeOf parm6 Is ISolomonDataObjectItem Then bTable6 = CType(parm6, ISolomonDataObjectItem).Item
            If TypeOf parm7 Is ISolomonDataObjectItem Then bTable7 = CType(parm7, ISolomonDataObjectItem).Item
            If TypeOf parm8 Is ISolomonDataObjectItem Then bTable8 = CType(parm8, ISolomonDataObjectItem).Item

        End If

    End Function
    Sub CurrencyInfo(ByVal Level As Short, ByRef RecAddr As SolomonDataObject, ByVal RecName As String, ByVal IDFldName As String, ByVal MDFldName As String, ByVal RateTypeFldName As String, ByVal EffDate As Object, ByVal Rate As Object)
        SolomonKernelExports.CurrencyInfo(Level, RecAddr, RecName, IDFldName, MDFldName, RateTypeFldName, EffDate, Rate)
    End Sub
    Sub CurrencyInfo2(ByVal Level As Short, ByRef RecAddr As SolomonDataObject, ByVal RecName As String, ByVal IDFldName As String, ByVal MDFldName As String, ByVal RateTypeFldName As String, ByVal EffDate As Object, ByVal Rate As Object, ByVal BaseCuryIDFld As String)
        SolomonKernelExports.CurrencyInfo2(Level, RecAddr, RecName, IDFldName, MDFldName, RateTypeFldName, EffDate, Rate, BaseCuryIDFld)
    End Sub
    Sub CurrencyField(ByRef TranCuryControl As Control, ByVal bBaseCuryFld As IntPtr, ByVal Flags As Short)
        SolomonKernelExports.CurrencyField(TranCuryControl, bBaseCuryFld, Flags)
    End Sub
#If FORM1NOTPRESENT Then
#Else
    Function DetailSetup(ByVal Cursor As Short, ByVal SAFGridCtrl As Interop.SAF.SAFGrid, ByVal AutoLineNbfFld As Object, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object) As Short
        DetailSetup = SolomonKernelExports.DetailSetup(Cursor, SAFGridCtrl, AutoLineNbfFld, bTable1, bTable2, bTable3, bTable4)
    End Function

    Function DetailSetup8(ByVal Cursor As Short, ByVal SAFGridCtrl As Interop.SAF.SAFGrid, ByVal AutoLineNbfFld As Object, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object, ByRef bTable5 As Object, ByRef bTable6 As Object, ByRef bTable7 As Object, ByRef bTable8 As Object) As Short
        DetailSetup8 = SolomonKernelExports.DetailSetup8(Cursor, SAFGridCtrl, AutoLineNbfFld, bTable1, bTable2, bTable3, bTable4, bTable5, bTable6, bTable7, bTable8)
    End Function
#End If

    Function MOpen(ByVal DelRetToSystem As Short, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object) As Short
        MOpen = SolomonKernelExports.MOpen(DelRetToSystem, bTable1, bTable2, bTable3, bTable4)
    End Function

    Function MOpen8(ByVal DelRetToSystem As Short, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object, ByRef bTable5 As Object, ByRef bTable6 As Object, ByRef bTable7 As Object, ByRef bTable8 As Object) As Short
        MOpen8 = SolomonKernelExports.MOpen8(DelRetToSystem, bTable1, bTable2, bTable3, bTable4, bTable5, bTable6, bTable7, bTable8)
    End Function

    ''' <summary>
    ''' Define a key field for a previously opened memory array.
    ''' </summary>
    ''' <param name="MemHandle">Unique handle to a previously opened memory array.</param>
    ''' <param name="KeySegmentNbr">Memory array key segment whose key field is being defined. The first key segment number is always zero. Multi-segment keys must have contiguous key segment values such as 0 and 1 as opposed to 0 and 3. The maximum allowable number of key segments is five.</param>
    ''' <param name="bTable">SolomonDataObject containing the designated key field. This object must also have been previously passed to the MOpen call.</param>
    ''' <param name="KeyFldByteOffset">This argument is designed to help the system locate the first byte of the designated key field. The system will already know the memory location of the first byte of the entire user-defined datatype via the bTable argument. The byte offset tells the system how far the first byte of the designated key field is offset from the first byte of the entire user-defined datatype. If the designated key field is the first field in the user-defined datatype then a value of zero should be passed.</param>
    ''' <param name="KeyFldDataType">Specifies the datatype of the designated key field. The following datatype constants are declared in Applic.DH: DATA_TYPE_STRING DATA_TYPE_FLOAT DATA_TYPE_INTEGER DATA_TYPE_DATE DATA_TYPE_TIME DATA_TYPE_LOGICAL</param>
    ''' <param name="KeyFldDataLength">bTable.GetPropertyLength("KeyFld"). Note: It is critical to use GetPropertyLength for string properties.</param>
    ''' <param name="Ascending">True if the key segment should be sorted ascending. False to implement a descending sort sequence for the key segment currently being defined.</param>
    ''' <example> This sample shows how to call the CopyClass method.
    ''' <code>
    ''' Call MKeyOffset(MemHandle, KeySegmentNbr, bTable, KeyFldByteOffset, KeyFldDataType, KeyFldDataLength, Ascending)
    ''' </code>
    ''' </example>
    ''' <remarks>
    ''' Occasionally a program will need the ability to easily locate a particular record within a memory array
    ''' based on one or more key field values. The MKeyFind function can be used to accomplish this goal assuming
    ''' the sort order for the memory array has been previously defined. Memory arrays associated with an SAFGrid
    ''' control automatically have their sort order initialized by the DetailSetup function based on the key
    ''' field control(s) contained within the grid (e.g., notated by a �,k� in the levels property of the controls).
    ''' All other memory arrays must have their sort order explicitly defined via one of several different methods.
    ''' Each of the methods to define a key field, such as MKey, MKeyFld, MKeyHctl and MKeyOffset, vary primarily
    ''' in the way they acquire detailed information on a key field such as datatype, size and byte offset within
    ''' a user-defined datatype. The MKeyOffset method is the most flexible method of defining memory array key
    ''' fields but it is also the most detailed to code. It is designed to facilitate the definition of a key field
    ''' that does not exist in the database and therefore has no correlated data dictionary information in the
    ''' database. This situation can occur if one of the user-defined datatypes in a memory array is only declared
    ''' within VB and does not exist within the database. In such a case, the system has no way of determining the
    ''' byte offset from the beginning of the structure for any particular field, the field datatype nor the length
    ''' of the field. The MKeyOffset statement allows the developer to explicitly pass all of this detailed information
    ''' relating to the designated key field since it does not exist in the SQL data dictionary. Multi-segment keys
    ''' can be defined by successive calls to MKeyOffset with different KeySegmentNbr argument values.
    ''' </remarks>
    Sub MKeyOffset(ByVal MemHandle As Short, _
                   ByVal KeySegmentNbr As Short, _
                   ByRef bTable As SolomonDataObject, _
                   ByVal KeyFldByteOffset As Short, _
                   ByVal KeyFldDataType As Short, _
                   ByVal KeyFldDataLength As Short, _
                   ByVal Ascending As Short)

        SolomonKernelExports.MKeyOffset(MemHandle, KeySegmentNbr, bTable, KeyFldByteOffset, KeyFldDataType, KeyFldDataLength, Ascending)

    End Sub

    Function MKeyFind(ByVal MemHandle As Short, ByRef KeySeg1Val As Object, ByRef KeySeg2Val As Object, ByRef KeySeg3Val As Object, ByRef KeySeg4Val As Object, ByRef KeySeg5Val As Object) As Short
        MKeyFind = SolomonKernelExports.MKeyFind(MemHandle, KeySeg1Val, KeySeg2Val, KeySeg3Val, KeySeg4Val, KeySeg5Val)
    End Function

    Sub MKeyFld(ByVal MemHandle As Short, ByVal KeySegmentNbr As Short, ByVal TableDotFieldName As String, ByRef bTable As SolomonDataObject, ByVal Ascending As Short)
        SolomonKernelExports.MKeyFld(MemHandle, KeySegmentNbr, TableDotFieldName, bTable, Ascending)
    End Sub

    Function MExtend(ByVal MemHandle As Short, ByRef bTable As SolomonDataObject) As Short
        MExtend = SolomonKernelExports.MExtend(MemHandle, bTable)
    End Function

    Sub SetPesInfo(ByRef bpes As SolomonDataObject)
        ' Not exposed through SolomonKernel.Exports, but wrapped in order to 
        ' keep programming interface compatibility.  bpes no longer needs to be passed
        ' to SWIM.
        Call Ex_SetPesInfo()
    End Sub
#If FORM1NOTPRESENT Then
#Else
    Function DetailSetupExtend(ByVal SAFGridCtrl As Interop.SAF.SAFGrid, ByRef bTable1 As SolomonDataObject) As Short
        DetailSetupExtend = SolomonKernelExports.DetailSetupExtend(SAFGridCtrl, bTable1)
    End Function
#End If

    Sub DecimalPlaces(ByVal Ctrl As Control, ByVal DecPl As IntPtr)
        SolomonKernelExports.DecimalPlaces(Ctrl, DecPl)
    End Sub

    Function DBNavFetch1(ByVal Ctrl As Object, ByRef Cursor As Short, ByVal SQLParmValue As String, ByRef bTable1 As SolomonDataObject) As Short
        DBNavFetch1 = SolomonKernelExports.DBNavFetch1(Ctrl, Cursor, SQLParmValue, bTable1)
    End Function

    Function DBNavFetch4(ByVal Ctrl As Object, ByRef Cursor As Short, ByVal SQLParmValue As String, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object) As Short
        DBNavFetch4 = SolomonKernelExports.DBNavFetch4(Ctrl, Cursor, SQLParmValue, bTable1, bTable2, bTable3, bTable4)
    End Function

    Function DBNavFetch8(ByVal Ctrl As Object, ByRef Cursor As Short, ByVal SQLParmValue As String, ByRef bTable1 As SolomonDataObject, ByRef bTable2 As Object, ByRef bTable3 As Object, ByRef bTable4 As Object, ByRef bTable5 As Object, ByRef bTable6 As Object, ByRef bTable7 As Object, ByRef bTable8 As Object) As Short
        DBNavFetch8 = SolomonKernelExports.DBNavFetch8(Ctrl, Cursor, SQLParmValue, bTable1, bTable2, bTable3, bTable4, bTable5, bTable6, bTable7, bTable8)
    End Function

    Function StartAppAndAutomate(ByVal exename As String, ByRef SolomonErr As Short, ByRef OSErr As Integer) As Object
        StartAppAndAutomate = SolomonKernelExports.StartApplication(exename, SolomonErr, OSErr)
    End Function

    ''' <summary>
    ''' Terminate the dynamic link with the Solomon Parent, log out of the database and terminate the application.
    ''' </summary>
    ''' <param name="OpCode">
    ''' Operation Code. If another application should be executed after the current application terminates then
    ''' the name of the next application can be specified using this argument. Parameters can be sent to the
    ''' next application using the ParmStr argument. If the current application was originally called by
    ''' another application then return values can be passed back to the originating application by passing
    ''' the APPLICRETURNPARMS symbolic constant defined in Solomon.VBTools.vb. The actual return value(s) are
    ''' passed via the ParmStrargument. Normally this argument will be blank - in which case the value of
    ''' ParmStr is ignored, the application is terminated and no further action is taken.
    ''' </param>
    ''' <param name="ParmStr">
    ''' Parameter value(s) to be sent to the next application or returned to the calling application.
    ''' Multiple parameters can be passed by separating each individual parameter with the PRMSEP symbolic
    ''' constant defined in Solomon.VBTools.vb.
    '''</param>
    ''' <remarks>
    ''' The ScreenExit call is required in the FormClosed event handler of Form1 for all applications developed 
    ''' with Tools for Visual Basic.
    ''' </remarks>
    Sub ScreenExit(ByVal OpCode As String, ByVal ParmStr As String)

        ' ScreenExit can be called recursively in the case where the application makes a call from 
        ' somewhere other than Form1_Closed.
        If InScreenExit = True Then Exit Sub
        InScreenExit = True

        ' Call corresponding Kernel method. Note this will cause a Form_Closed event handler to be called,
        ' unless this ScreenExit call is being made from Form_Closed.
        SolomonKernelExports.ScreenExit(OpCode, ParmStr)

        ' Causes immediate termination of application code.  Any code following a ScreenExit call
        ' from within the application will not be executed.
        '
        ' SolomonKernelExports.ScreenExit() calls the Winforms Application.Exit call, which 
        ' causes a clean shutdown of all application resources, including the Solomon Kernel.
        '
        ' This call to End, even though documented in VB as causing immediate termination
        ' without cleanup of application resources, should not be a cause of concern here
        ' since the Solomon Kernel has already handled the cleanup.
        ' Make the call to End conditional, depending on whether the call is being made from 
        ' Form1 FormClosed event handler or from application code.  If from the event handler,
        ' we know the application will terminate anyway so there is no need to call End.
        If SolomonKernelExports.InForm1Close() = False Then
            'This End is causing a lockup after clicking OK in signon when Rational Robot is on the scene.
            'The Form close is not completed prior to this End occuring.
            'According to v-davebu rational requires the form close events to complete prior to ending the app.
            'Make sure events have been processed
            System.Windows.Forms.Application.DoEvents()
#If FORM1NOTPRESENT Then
#Else
            End
#End If
        End If

    End Sub
    Sub ApplSetfocus(ByVal hctl As Object)
        SolomonKernelExports.ApplSetfocus(hctl)
    End Sub
    Function AutoNbrDefault(ByVal ctrl As Object, ByVal sqlcmd As String, ByVal ctrl1 As Object, ByVal ctrl2 As Object) As Short
        AutoNbrDefault = SolomonKernelExports.AutoNbrDefault(ctrl, sqlcmd, ctrl1, ctrl2)
    End Function
    Sub SetAutoNbrFlag(ByVal ctrl As Object, ByVal ActiveFlg As Short)
        SolomonKernelExports.SetAutoNbrFlag(ctrl, ActiveFlg)
    End Sub
    Sub SetDefaults(ByVal formx As Object, ByVal ctrlbeg As Object, ByVal ctrlend As Object)
        SolomonKernelExports.SetDefaults(formx, ctrlbeg, ctrlend)
    End Sub
    Sub Level_SetDefaults(ByVal formx As Object, ByVal ctrlbeg As Object, ByVal ctrlend As Object, ByVal lvl As Short)
        SolomonKernelExports.Level_SetDefaults(formx, ctrlbeg, ctrlend, lvl)
    End Sub
    Sub SetKeysEnabledOnly(ByVal formx As Object, ByVal ctrlbeg As Object, ByVal ctrlend As Object, ByVal action_flag As Short)
        SolomonKernelExports.SetKeysEnabledOnly(formx, ctrlbeg, ctrlend, action_flag)
    End Sub
    Sub MSet(ByVal ctrl As Object, ByVal valstr As String)
        SolomonKernelExports.MSet(ctrl, valstr)
    End Sub
    Sub DetailLoad(ByVal ctrl As Object)
        SolomonKernelExports.DetailLoad(ctrl)
    End Sub
    Sub DetailSave(ByVal cursor As Short, ByVal ctrl As Object, ByVal recname As String)
        SolomonKernelExports.DetailSave(cursor, ctrl, recname)
    End Sub
    Function MGetDelHandle(ByVal hgrid As Object) As Short
        MGetDelHandle = SolomonKernelExports.MGetDelHandle(hgrid)
    End Function
    Sub Grid_Sortable(ByVal Level As Short, ByVal s As Object)
        SolomonKernelExports.Grid_Sortable(Level, s)
    End Sub
    Sub DispField(ByVal ctrl As Object)
        SolomonKernelExports.DispField(ctrl)
    End Sub
    Sub DispFields(ByVal formx As Object, ByVal ctrlbeg As Object, ByVal ctrlend As Object)
        SolomonKernelExports.DispFields(formx, ctrlbeg, ctrlend)
    End Sub
    Function CallChks(ByVal formx As Object, ByVal ctrlbeg As Object, ByVal ctrlend As Object, ByVal call_applic As Short, ByVal chk_detail_flds As Short) As Short
        CallChks = SolomonKernelExports.CallChks(formx, ctrlbeg, ctrlend, call_applic, chk_detail_flds)
    End Function
    Sub HideForm(ByVal formx As Object)
        SolomonKernelExports.HideForm(formx)
    End Sub
    Sub MKeyHctl(ByVal handle As Short, ByVal segnum As Short, ByVal hctl As Object, ByVal ascending As Short)
        SolomonKernelExports.MKeyHctl(handle, segnum, hctl, ascending)
    End Sub
    Function MCallChks(ByVal handle As Short, ByVal ctrlbeg As Object, ByVal ctrlend As Object) As Short
        MCallChks = SolomonKernelExports.MCallChks(handle, ctrlbeg, ctrlend)
    End Function
    Function PVChk(ByVal ctrl As Object, ByRef cursor As Short, ByVal keyval As String) As Short
        PVChk = SolomonKernelExports.PVChk(ctrl, cursor, keyval)
    End Function
    Sub CuryFieldCalcSet(ByVal ctrl As Object, ByVal flags As Short)
        SolomonKernelExports.CuryFieldCalcSet(ctrl, flags)
    End Sub
    Sub SetTI_Alias_Level(ByVal ctrl As Object, ByVal Level As Short)
        SolomonKernelExports.SetTI_Alias_Level(ctrl, Level)
    End Sub
    Function IsParentOf(ByVal TestParent As Object, ByVal TestChild As Object) As Short
        IsParentOf = SolomonKernelExports.IsParentOf(TestParent, TestChild)
    End Function
    Sub disp_form(ByVal formx As Object, ByVal centered As Short)
        SolomonKernelExports.disp_form(formx, centered)
    End Sub
    Function formwait(ByVal formx As Object) As Short
        formwait = SolomonKernelExports.formwait(formx)
    End Function
    Sub DisplayModeSetprops(ByVal formx As Object, ByVal ctrlbeg As Object, ByVal ctrlend As Object, ByVal propname As String, ByVal prop_data As Object)
        SolomonKernelExports.DisplayModeSetprops(formx, ctrlbeg, ctrlend, propname, prop_data)
    End Sub
    Sub MSetProp(ByVal ctrl As Object, ByVal propname As String, ByVal prop_data As Object)
        SolomonKernelExports.MSetProp(ctrl, propname, prop_data)
    End Sub
    Sub SetProps(ByVal formx As Object, ByVal ctrlbeg As Object, ByVal ctrlend As Object, ByVal propname As String, ByVal prop_data As Object)
        SolomonKernelExports.SetProps(formx, ctrlbeg, ctrlend, propname, prop_data)
    End Sub
    Function SetObjectValue(ByVal ctrl As Object, ByVal CtrlValue As Object) As Short
        SetObjectValue = SolomonKernelExports.SetObjectValue(ctrl, CtrlValue)
    End Function

    ''' <summary>
    ''' Increment a string representation of a whole number value.
    ''' </summary>
    ''' <param name="StringNbr">
    ''' String whose current whole number is be incremented.
    ''' </param>
    ''' <param name="Length">
    ''' Size of StringNbr. It is not required that this value equal the full size of StringNbr.  For example, if the string can actually hold 10 bytes but currently the developer only desires to use 6 bytes values then a value 6 can be passed.
    ''' </param>
    ''' <param name="Increment">
    ''' Amount by which StringNbr is to be incremented.
    '''</param>
    ''' <remarks>
    ''' The ScreenExit call is required in the FormClosed event handler of Form1 for all applications developed 
    ''' with Tools for Visual Basic.
    ''' </remarks>
    Sub IncrStrg(ByRef StringNbr As String, ByVal Length As Short, ByVal Increment As Short)
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder(StringNbr)
        Call IncrStrg(sb, Length, Increment)
        StringNbr = sb.ToString()
    End Sub

    ' Exported API list
    Declare Sub SetButton Lib "swimapi.dll" ( _
        ByVal ButtonIds As Short, _
        ByVal Level As Short, _
        ByVal OnFlag As Short)
    Declare Function ApplGetParms Lib "swimapi.dll" Alias "ManagedApplGetParms" () As String
    Declare Function ApplGetReturnParms Lib "swimapi.dll" Alias "ManagedApplGetReturnParms" () As String
    Declare Function ApplGetParmValue Lib "swimapi.dll" Alias "ManagedApplGetParmValue" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal pSection As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal pEntry As String) As String
    Declare Sub ApplSetParmValue Lib "swimapi.dll" Alias "#112" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal pSection As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal pEntry As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal pValue As String)
    Declare Sub HideNoteButtons Lib "swimapi.dll" ( _
        ByVal Level As Short, _
        ByVal flag As Short)
    Declare Function ExportCustom Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal screennbr As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal EntityId As String, _
        ByVal BegSeqVal As Short, _
        ByVal EndSeqVal As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal FileName As String, _
        ByVal FileAppend As Short, _
        ByVal Vba As Short) As Short
    Declare Function ImportCustom Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal FileName As String, _
        ByVal Conflicts As Short, _
        ByVal Errors As Short) As Short
    Declare Function GetModulePeriod Lib "swimapi.dll" Alias "#116" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal modnbr As String) As String
    Declare Function DateCheck Lib "swimapi.dll" Alias "#117" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal DateStr As String) As Short
    Declare Function PeriodCheck Lib "swimapi.dll" Alias "#118" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal Period As String) As Short
    Declare Sub StrToDate Lib "swimapi.dll" Alias "#310" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal DateStr As String, _
        ByRef dateval As Integer)
    Declare Function DateToStr Lib "swimapi.dll" Alias "ManagedDateToStr" (ByVal dateval As Integer) As String
    Declare Function DateToStrSep Lib "swimapi.dll" Alias "ManagedDateToStrSep" (ByVal dateval As Integer) As String
    Declare Sub StrToTime Lib "swimapi.dll" Alias "#121" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal timestr As String, _
        ByRef timeval As Integer)
    Declare Function TimeToStr Lib "swimapi.dll" Alias "ManagedTimeToStr" (ByVal timeval As Integer) As String
    Declare Function DateMinusDate Lib "swimapi.dll" Alias "Ex_dateminusdateByRef" ( _
        ByVal date1 As Integer, _
        ByVal date2 As Integer) As Integer
    Declare Sub DatePlusDays Lib "swimapi.dll" Alias "Ex_dateplusdaysByRef" ( _
        ByVal date1 As Integer, _
        ByVal addindays As Short, _
        ByRef enddate As Integer)
    Declare Function DateCmp Lib "swimapi.dll" Alias "Ex_datecmpByRef" ( _
        ByVal date1 As Integer, _
        ByVal date2 As Integer) As Short
    Declare Function PeriodPlusPerNum Lib "swimapi.dll" Alias "ManagedPeriodPlusPerNum" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal ppyyyy As String, _
        ByVal Number As Short) As String
    Declare Function PeriodMinusPeriod Lib "swimapi.dll" Alias "#127" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal period1 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal period2 As String) As Short
    Declare Sub DatePlusMonthSetDay Lib "swimapi.dll" Alias "Ex_dateplusmonthsetdayByRef" ( _
        ByVal date1 As Integer, _
        ByVal monthval As Short, _
        ByVal dayval As Short, _
        ByRef date2 As Integer)
    Declare Sub GetSysDate Lib "swimapi.dll" Alias "#129" (ByRef currdate As Integer)
    Declare Sub GetSysTime Lib "swimapi.dll" Alias "#130" (ByRef currtime As Integer)
    Declare Function DateToIntlStr Lib "swimapi.dll" (ByVal dval As Integer) As String
    Declare Sub IntlStrToDate Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal DateStr As String, _
        ByRef dateval As Integer)
    Declare Sub DisplayMode Lib "swimapi.dll" Alias "#136" (ByVal OnFlag As Short)
    Declare Function FPRnd Lib "swimapi.dll" Alias "#99" ( _
        ByVal dbl As Double, _
        ByVal precision As Short) As Double
    Declare Function FPAdd Lib "swimapi.dll" ( _
        ByVal dbl1 As Double, _
        ByVal dbl2 As Double, _
        ByVal precision As Short) As Double
    Declare Function FPSub Lib "swimapi.dll" ( _
        ByVal dbl1 As Double, _
        ByVal dbl2 As Double, _
        ByVal precision As Short) As Double
    Declare Function FPMult Lib "swimapi.dll" ( _
        ByVal dbl1 As Double, _
        ByVal dbl2 As Double, _
        ByVal precision As Short) As Double
    Declare Function FPDiv Lib "swimapi.dll" ( _
        ByVal dbl1 As Double, _
        ByVal dbl2 As Double, _
        ByVal precision As Short) As Double
    Declare Function FToA Lib "swimapi.dll" ( _
        ByVal dbl As Double, _
        ByVal precision As Short) As String
    Declare Function GetPrecision Lib "swimapi.dll" ( _
        ByVal precision As Short) As Short
    Declare Sub SetLevelChg Lib "swimapi.dll" Alias "#138" ( _
        ByVal Level As Short, _
        ByVal chgflg As Short)
    Declare Function TestLevelChg Lib "swimapi.dll" Alias "#139" ( _
        ByVal Level As Short) As Short
    Declare Sub MClose Lib "swimapi.dll" Alias "#263" (ByVal handle As Short)
    Declare Sub MLoad Lib "swimapi.dll" Alias "#265" ( _
        ByVal handle As Short, _
        ByVal cursor As Short)
    Declare Sub MClear Lib "swimapi.dll" Alias "#266" (ByVal handle As Short)
    Declare Function MFirst Lib "swimapi.dll" Alias "#267" ( _
        ByVal handle As Short, _
        ByRef maintflg As Short) As Short
    Declare Function MNext Lib "swimapi.dll" Alias "#268" ( _
        ByVal handle As Short, _
        ByRef maintflg As Short) As Short
    Declare Function MLast Lib "swimapi.dll" Alias "#269" ( _
        ByVal handle As Short, _
        ByRef maintflg As Short) As Short
    Declare Function MPrev Lib "swimapi.dll" Alias "#270" ( _
        ByVal handle As Short, _
        ByRef maintflg As Short) As Short
    Declare Function MDelete Lib "swimapi.dll" Alias "#271" ( _
        ByVal handle As Short, _
        ByRef maintflg As Short) As Short
    Declare Sub MInsert Lib "swimapi.dll" Alias "#272" (ByVal handle As Short)
    Declare Sub MDisplay Lib "swimapi.dll" Alias "#273" (ByVal handle As Short)
    Declare Sub MUpdate Lib "swimapi.dll" Alias "#274" (ByVal handle As Short)
    Declare Function MArrayCnt Lib "swimapi.dll" Alias "#275" (ByVal handle As Short) As Short
    Declare Function MSetLineStatus Lib "swimapi.dll" Alias "#276" ( _
        ByVal handle As Short, _
        ByVal Status As Short) As Short
    Declare Function MGetLineStatus Lib "swimapi.dll" Alias "#277" (ByVal handle As Short) As Short
    Declare Sub MKey Lib "swimapi.dll" Alias "#279" ( _
        ByVal handle As Short, _
        ByVal segnum As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal fieldName As String, _
        ByVal ascending As Short)
    Declare Sub MSetRow Lib "swimapi.dll" Alias "#283" ( _
        ByVal handle As Short, _
        ByVal row As Short)
    Declare Function MGetRowNum Lib "swimapi.dll" Alias "#284" (ByVal handle As Short) As Short
    Declare Sub MSort Lib "swimapi.dll" Alias "#286" (ByVal handle As Short)
    Declare Sub Mess Lib "swimapi.dll" (ByVal messno As Short)
    Declare Sub Messf Lib "swimapi.dll" ( _
        ByVal messno As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal arg0 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal arg1 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal arg2 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal arg3 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal arg4 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal arg5 As String)
    Declare Sub MessBox Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal msg As String, _
        ByVal msgtype As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal Title As String)
    Declare Function MessResponse Lib "swimapi.dll" () As Short
    Declare Function MessGetText Lib "swimapi.dll" (ByVal messno As Short) As String
    Private Declare Sub IncrStrg Lib "swimapi.dll" Alias "#140" ( _
        ByVal lpBuffer As System.Text.StringBuilder, _
        ByVal length As Short, _
        ByVal delta As Short)
    Declare Function NoteCopy Lib "swimapi.dll" Alias "#304" ( _
        ByVal SourceNoteId As Integer, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal DestRecordType As String) As Integer
    Declare Sub Status Lib "swimapi.dll" ( _
        ByVal msgno As Short, _
        ByVal fatalflg As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal idstrng As String, _
        ByVal log_disp_flg As Short)
    Declare Sub SetRestart Lib "swimapi.dll" (ByRef cursor As Short)
    Declare Function SwimGetProfile Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal Section As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal entry As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal Default_Renamed As String, _
        ByVal size As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal Profilename As String) As String
    Declare Function SwimWriteProfile Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal Section As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal entry As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal EString As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal Profilename As String) As Short
    Declare Function SParm Lib "swimapi.dll" Alias "ManagedSParm" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal sval As String) As String
    Declare Function DParm Lib "swimapi.dll" Alias "ManagedDParm" (ByVal dval As Integer) As String
    Declare Function FParm Lib "swimapi.dll" Alias "ManagedFParm" (ByVal fval As Double) As String
    Declare Function IParm Lib "swimapi.dll" Alias "ManagedIParm" (ByVal ival As Integer) As String
    Declare Sub SDelete Lib "swimapi.dll" ( _
        ByVal cursor As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal recordname As String)
    Declare Function SDeleteAll Lib "swimapi.dll" ( _
        ByVal cursor As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal recordname As String) As Short
    Declare Sub sql Lib "swimapi.dll" Alias "Sql" ( _
        ByRef cursor As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal psql As String)
    Declare Sub sqlNoWait Lib "swimapi.dll" ( _
        ByRef cursor As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal psql As String)
    Declare Sub SqlExec Lib "swimapi.dll" (ByVal cursor As Short)
    Declare Function Edit_First Lib "swimapi.dll" (ByVal Level As Short) As Short
    Declare Function Edit_Next Lib "swimapi.dll" (ByVal Level As Short) As Short
    Declare Function Edit_Prev Lib "swimapi.dll" (ByVal Level As Short) As Short
    Declare Function Edit_Last Lib "swimapi.dll" (ByVal Level As Short) As Short
    Declare Function Edit_Delete Lib "swimapi.dll" (ByVal Level As Short) As Short
    Declare Function Edit_New Lib "swimapi.dll" (ByVal Level As Short) As Short
    Declare Sub Edit_Save Lib "swimapi.dll" ()
    Declare Sub Edit_Cancel Lib "swimapi.dll" ()
    Declare Sub Edit_Finish Lib "swimapi.dll" ()
    Declare Sub Edit_Close Lib "swimapi.dll" ()
    Declare Sub TranBeg Lib "swimapi.dll" (ByVal abortable As Short)
    Declare Sub TranEnd Lib "swimapi.dll" ()
    Declare Sub TranAbort Lib "swimapi.dll" ()
    Declare Function TranStatus Lib "swimapi.dll" () As Short
    Declare Sub SqlCursor Lib "swimapi.dll" ( _
        ByRef cursor As Short, _
        ByVal flags As Short)
    Declare Sub SqlCursorEx Lib "swimapi.dll" ( _
        ByRef cursor As Short, _
        ByVal flags As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal CursorName As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal TabNames As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal UpdateTabNames As String)
    Declare Sub SqlFree Lib "swimapi.dll" (ByRef cursor As Short)
    Declare Sub SqlSubst Lib "swimapi.dll" ( _
        ByVal cursor As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal parmname As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal parmval As String)
    Declare Function SqlErr Lib "swimapi.dll" () As Short
    Declare Sub SqlErrException Lib "swimapi.dll" ( _
        ByVal flag As Short, _
        ByVal errval As Short)
    Declare Sub SqlRowCntrs Lib "swimapi.dll" ( _
        ByVal handle As Short, _
        ByVal cursor As Short)
    Declare Sub GetCuryRate Lib "swimapi.dll" Alias "#300" ()
    Declare Sub CurySelFieldEnable Lib "swimapi.dll" Alias "#299" ( _
        ByVal FieldIds As Short, _
        ByVal EnabledFlag As Short)
    Declare Function ChkCuryRateType Lib "swimapi.dll" Alias "#288" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal RateType As String) As Short
    Declare Sub CuryInfoGet Lib "swimapi.dll" Alias "#294" (ByVal lvl As Short)
    Declare Sub CuryInfoSet Lib "swimapi.dll" Alias "#295" (ByVal lvl As Short)
    Declare Sub CuryInfoInit Lib "swimapi.dll" Alias "#296" ()
    Declare Sub CuryRateTypeSet Lib "swimapi.dll" Alias "#297" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal RateType As String)
    Declare Sub CuryEffDateSet Lib "swimapi.dll" Alias "#290" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal EffDate As String)
    Declare Sub CuryInfoEnable Lib "swimapi.dll" Alias "#293" ( _
        ByVal lvl As Short, _
        ByVal flag As Short)
    Declare Sub CuryIdSet Lib "swimapi.dll" Alias "#292" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal CuryID As String)
    Declare Sub CuryResetBase Lib "swimapi.dll" Alias "#298" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal BaseCuryID As String)
    Declare Function GetPrecCury Lib "swimapi.dll" Alias "#322" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal CuryID As String) As Short
    Declare Sub SetStatusBarText Lib "swimapi.dll" Alias "#597" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal StatusBarText As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal ToolTip As String)
    Declare Function NewRecord Lib "swimapi.dll" ( _
        ByVal Level As Short, _
        ByVal InsertAtNextLocation As Boolean) As Boolean
    Declare Sub DisableObjectModel Lib "swimapi.dll" ()
    Declare Sub SetUnattendedMode Lib "swimapi.dll" Alias "#602" (ByVal ModeFlag As Short)
    Declare Function IsUnattendedMode Lib "swimapi.dll" Alias "#603" () As Short
    Declare Sub AppControlSetup Lib "swimapi.dll" ( _
        ByVal btype As Short, _
        ByVal Enable As Short)
    Declare Sub AppToolbar Lib "swimapi.dll" (ByVal Buttonid As Integer)
    Declare Sub ParentEditRowInsertAndPaste Lib "swimapi.dll" ()
    Declare Function checkappload Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal progname As String) As Short
    Declare Sub AppSetNavLevel Lib "swimapi.dll" ()
    Declare Sub AppTemplateFormSetup Lib "swimapi.dll" ()
    Declare Sub AppInvokeNoteDialog Lib "swimapi.dll" ()
    Declare Sub AppInvokeAttachmentDialog Lib "swimapi.dll" ()
    Declare Function AreAppsRunning Lib "swimapi.dll" () As Short
    Declare Function AreAppsReady Lib "swimapi.dll" () As Short
    Declare Function AppGetAppNavLevels Lib "swimapi.dll" () As Short
    Declare Function AppIsCurrentAppTemplateable Lib "swimapi.dll" () As Short
    Declare Function AppCheckClipboardData Lib "swimapi.dll" () As Boolean
    Declare Sub AppGetLastControlWithFocus Lib "swimapi.dll" ( _
        ByRef ctltype As Integer, _
        ByRef sortedDetailInput As Boolean)
    Declare Function AppControlsSelected Lib "swimapi.dll" () As Boolean
    Declare Function AppUndoPasteAvailable Lib "swimapi.dll" () As Boolean
    Declare Function AppNoteCheckLevelNotable Lib "swimapi.dll" () As Boolean
    Declare Function IsCustMode Lib "swimapi.dll" Alias "#165" () As Short
    Declare Sub SaveTemplate Lib "swimapi.dll" Alias "#423" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal TemplateId As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal templatedesc As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal UserId As String, _
        ByVal LowerLevelData As Short, _
        ByVal levelnbr As Short)
    Declare Function PasteTemplate Lib "swimapi.dll" Alias "#424" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal TemplateId As String) As Short
    Declare Function GetSqlType Lib "swimapi.dll" () As Short
    Declare Function IS_TI Lib "swimapi.dll" Alias "#301" () As Short
    Declare Function IsMultiCompany Lib "swimapi.dll" Alias "#571" () As Short
    Declare Function IS_AppServer Lib "swimapi.dll" Alias "#596" () As Short
    Declare Sub Assign_VBversion Lib "swimapi.dll" Alias "#598" (ByVal VersionNbr As Short)
    Declare Sub Ex_SetPesInfo Lib "swimapi.dll" ()
    Declare Sub floatinit Lib "swimapi.dll" Alias "#100" (ByVal dbl As Double)
    Declare Sub dateinit Lib "swimapi.dll" Alias "#101" (ByRef NULLDATE As Integer)
    Declare Function SystemErr Lib "swimapi.dll" () As Short
    Declare Sub sw_error Lib "swimapi.dll" Alias "#253" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal s1 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal s2 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal s3 As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal s4 As String)
    Declare Sub ExecProg Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal cmdline As String)
    Declare Function ExecProgWait Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal cmdline As String) As Short
    Declare Function ExecPrePostProgWait Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal cmdline As String) As Short
    Declare Function ExecProgWithStatus Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal cmdline As String) As Short
    Declare Sub SetParentRootDir Lib "swimapi.dll" Alias "#316" ()
    Declare Function IsParentRunning Lib "swimapi.dll" Alias "#302" () As Short
    Declare Function GetParentHeight Lib "swimapi.dll" Alias "#569" () As Integer
    Declare Function GetWorkAreaTop Lib "swimapi.dll" Alias "#608" () As Integer 'CR207901 - CAG - 8/22/02
    Declare Sub ProcStatButton Lib "swimapi.dll" Alias "#257" ()
    Declare Function IsLoginReady Lib "swimapi.dll" () As Short
    Declare Function SqlLogin Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal SysDbPassword As String, _
        ByRef SysDbErr As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal AppDbPassword As String, _
        ByRef AppDbErr As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal SqlSrvrAppDbPass As String, _
        ByVal Passflg As Short) As Short
    Declare Sub SqlLogout Lib "swimapi.dll" ()
    Declare Sub button_change_level Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal bnName As String, _
        ByVal fromLevel As Short, _
        ByVal toLevel As Short)
    Declare Sub button_change_form Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal bnName As String, _
        ByVal Level As Short, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal fromForm As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal toForm As String)
    Declare Sub sw_screeninit Lib "swimapi.dll" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal pscreenid As String)
    Declare Function ApplicVer Lib "swimapi.dll" () As String
    Declare Sub SetCalledByHwnd Lib "swimapi.dll" Alias "#249" (ByVal CalledByHwnd As Integer)
    Declare Function GetCalledByHwnd Lib "swimapi.dll" Alias "#250" () As Short
    Declare Sub SetSqlType Lib "swimapi.dll" (ByVal SqlType As Short)
    Declare Sub ExposeCustomObject Lib "swimapi.dll" (ByVal custObj As Object)
    Declare Function IsAppAutomating Lib "swimapi.dll" () As Boolean

    'Changed to pass only the menutoolbar height for customization adjustments. See ApplicationMenuStrip class
    Declare Sub AppToolbarInit Lib "swimapi.dll" (ByVal MenutoolstripHeight As Integer)

    Declare Function GetModuleDirectory Lib "swimapi.dll" (<MarshalAs(UnmanagedType.LPStr)> ByVal ModuleID As String) As String

    Declare Function GetAccessRightsForCompany Lib "Swimapi.dll" Alias "#587" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal ScrnNbr As String, _
        <MarshalAs(UnmanagedType.LPStr)> ByVal CpnyID As String) As Short

    Declare Function InitLocalization Lib "lli.dll" _
        (<MarshalAs(UnmanagedType.LPStr)> ByVal theLocalString As String) As Integer
    Declare Function DoneLocalization Lib "lli.dll" (ByVal ptr As Integer) As Boolean
    <DllImport("lli.dll", CharSet:=CharSet.Auto)> _
    Public Function LoadLocalString(ByVal ptr As Integer, ByVal uID As Integer, <MarshalAs(UnmanagedType.LPStr)> ByVal theLocalString As System.Text.StringBuilder, ByVal StringSize As Integer) As Integer
    End Function
    Declare Function IsUSEnglishLocale Lib "lli.dll" () As Boolean

    Declare Function getscreenaccessrights Lib "swimapi.dll" Alias "#241" ( _
        <MarshalAs(UnmanagedType.LPStr)> ByVal ScrnNbr As String) As Short

    Declare Sub TurnOffLegacyResizing Lib "swimapi.dll" ()
    Declare Sub ResetCurrencyCache Lib "swimapi.dll" Alias "EX_ResetCurrencyCache" ()
    ' End SolomonKernel.Exports ************************************************************************************************

    '''
    ''' ExtenderProviderProcessor
    '''
    Public Class ExtenderProviderProcessor

        Private Shared ExtenderProviderList As ArrayList

        Public Shared Sub AddFormExtenderProviderList(ByRef frm As Form)
            If ExtenderProviderList Is Nothing = True Then
                ExtenderProviderList = New ArrayList()
            End If
            ExtenderProviderList.Add(frm)
        End Sub

        ''' HelpInit
        '''
        ''' Use reflection to iterate the specified form.  Find Help and Tooltip IExtender providers
        ''' and process them accordingly.
        '''
        Public Shared Sub ExtenderProviderProcessAllForms()

            ' process all IExtenderProvider lists
            For Each frm As Form In ExtenderProviderList
                ExtenderProviderProcessForm(frm, False)
            Next

            ' we're done with the list
            ExtenderProviderList.Clear()
            ExtenderProviderList = Nothing

        End Sub

        Public Shared Sub ExtenderProviderProcessFormForHelp(ByVal currentForm As Form)
            ExtenderProviderProcessForm(currentForm, True)
        End Sub


        Private Shared Sub ExtenderProviderProcessForm(ByVal currentForm As Form, ByVal bHelpOnly As Boolean)

            ' If HelpButton property exist on the form then a HelpProvider has been added to the form.
            Dim myMembers As MemberInfo() = currentForm.GetType().GetMember("HelpButton")

            ' If a Help provider must already exists on this form, Use that instead. 
            Dim HelpButtonIsPresent As Boolean = myMembers.Length > 0

            ' Must loop through member info since the help provider cannot be found through property info.
            For Each t As MemberInfo In currentForm.GetType().GetMembers(MemberTypes.All)

                ' Note that if the Tooltip class variable is declared WithEvents, reflection will show it as a property.
                ' Without the WithEvents, it is a field.

                If t.MemberType = MemberTypes.Field Then

                    Dim f As FieldInfo = t

                    If bHelpOnly = False And f.FieldType.ToString = "System.Windows.Forms.ToolTip" Then
                        Dim toolTipInstance As System.Windows.Forms.ToolTip = f.GetValue(currentForm)
                        SolomonKernelExports.AddTooltip(currentForm, toolTipInstance)
                    End If

                ElseIf t.MemberType = MemberTypes.Property Then

                    ' extender providers are a property type only in reflections eye.
                    Dim p As PropertyInfo = t

                    If bHelpOnly = False And p.PropertyType.ToString = "System.Windows.Forms.ToolTip" Then

                        Dim toolTipInstance As System.Windows.Forms.ToolTip = p.GetValue(currentForm, Nothing)
                        SolomonKernelExports.AddTooltip(currentForm, toolTipInstance)

                    ElseIf HelpButtonIsPresent = True And p.PropertyType.ToString = "System.Windows.Forms.HelpProvider" Then

                        ' Found a predefined HelpProvider, make sure it's ours.
                        If p.Name = HELP_PROVIDERNAME Then
                            Dim MSDynamicsSLHelpProvider As System.Windows.Forms.HelpProvider = p.GetValue(currentForm, Nothing)
                            Dim helpModule As String

                            ' Get the help module ID from the assemblies' 1st two digits.
                            helpModule = GetModuleDirectory(My.Application.Info.AssemblyName.Substring(0, 2))

                            If MSDynamicsSLHelpProvider.HelpNamespace = String.Empty Then
                                ' If the help namespace is empty then default it.
                                Dim helpDirectory As String = My.Computer.Registry.GetValue(COMMONFILES_REGISTRYENTRY, COMMONFILES_REGISTRYKEY, "") 'bug 14745
                                helpDirectory = My.Computer.FileSystem.CombinePath(helpDirectory, HELP_FOLDERNAME)
                                If helpModule = "" Then helpModule = DEFAULT_HELPDIRECTORY
                                MSDynamicsSLHelpProvider.HelpNamespace = My.Computer.FileSystem.CombinePath(helpDirectory, HELP_BRANDINGNAME + helpModule + HELP_FILEEXT)
                            End If

                            If MSDynamicsSLHelpProvider.GetHelpNavigator(currentForm) = HelpNavigator.AssociateIndex And _
                               MSDynamicsSLHelpProvider.GetHelpKeyword(currentForm) = String.Empty Then
                                ' Help topic not specified, try the default one.

                                ' Format for robo help tool used.
                                ' for example: "User_Maintenance_95_260_00.htm"
                                'Help format changed by Documentation team. 4/25/2006
                                Dim helpTopic As String = currentForm.Text
                                helpTopic = helpTopic.Replace(".", "_")
                                helpTopic = helpTopic.Replace("(", "")
                                helpTopic = helpTopic.Replace(")", "")
                                helpTopic = helpTopic.Replace(" ", "_")
                                helpTopic = helpTopic.Replace("/", "_")
                                helpTopic = helpTopic.Replace("'", "_")
                                helpTopic = helpTopic.Replace("-", "_")
                                helpTopic += ".htm"

                                MSDynamicsSLHelpProvider.SetHelpKeyword(currentForm, helpTopic)
                                MSDynamicsSLHelpProvider.SetHelpNavigator(currentForm, HelpNavigator.Topic)
                            End If

                            MSDynamicsSLHelpProvider.SetShowHelp(currentForm, True)

                        End If
                    End If
                End If
            Next

        End Sub

    End Class

#Region "Print info"
    Structure Pinfo
        Dim DeviceName As String
        Dim DriverName As String
        Dim PrintPort As String
        Dim PrintDestinationName As String
        Dim PrintFileType As String
        Dim PrintToFile As Short
        Dim PrintIncludeCodes As Short
        '  DevMode                 As sol4_devmode 'fields specified in pinfo to avoid alignment problem
        Dim dmDeviceName As String
        Dim dmSpecVersion As Short
        Dim dmDriverVersion As Short
        Dim dmSize As Short
        Dim dmDriverExtra As Short
        Dim dmFields As Integer
        Dim dmOrientation As Short
        Dim dmPaperSize As Short
        Dim dmPaperLength As Short
        Dim dmPaperWidth As Short
        Dim dmScale As Short
        Dim dmCopies As Short
        Dim dmDefaultSource As Short
        Dim dmPrintQuality As Short
        Dim dmColor As Short
        Dim dmDuplex As Short
        Dim dmYResolution As Short
        Dim dmTTOption As Short
        Dim dmCollate As Short
        Dim dmFormName As String
        Dim dmLogPixels As Short
        Dim dmBitsPerPel As Integer
        Dim dmPelsWidth As Integer
        Dim dmPelsHeight As Integer
        Dim dmDisplayFlags As Integer
        Dim dmDisplayFrequency As Integer
        Dim dmICMMethod As Integer
        Dim dmICMIntent As Integer
        Dim dmMediaType As Integer
        Dim dmDitherType As Integer
        Dim dmICCManufacturer As Integer
        Dim dmICCModel As Integer
        Dim dmPanningWidth As Integer
        Dim dmPanningHeight As Integer
        '  FontInfo                As FontStruct   'fields specified in pinfo to avoid alignment problem
        Dim fiFontName As String
        Dim fiFontSize As Short
        Dim fiBold As Short
        Dim fiItalic As Short
        Dim WindowsDefault As Short
        Dim PrinterOrientation As Short
    End Structure

    Function GetSWIMDefaultPrintInfo(ByRef Pnfo As Pinfo) As Short
        GetSWIMDefaultPrintInfo = GetPrinterInformation(0, Pnfo)
    End Function

    Function GetSWIMPrintInfo(ByRef Pnfo As Pinfo) As Short
        GetSWIMPrintInfo = GetPrinterInformation(1, Pnfo)
    End Function

    Sub SetSWIMPrintInfo(ByRef Pnfo As Pinfo)
        Call SetPrinterInformation(1, Pnfo)
    End Sub

    Declare Sub GetSwimPrinterInformation Lib "swimapi.dll" Alias "#611" (ByVal Infotype As Short, ByVal AllInfo As System.Text.StringBuilder)
    Declare Sub SetSwimPrinterInformation Lib "swimapi.dll" Alias "#610" (ByVal Infotype As Short, <MarshalAs(UnmanagedType.LPStr)> ByVal Allinfo As String)
    Declare Function SWIMPrintFromDialog Lib "swimapi.dll" Alias "#612" (ByVal Handle As Integer, ByVal Flags As Short, ByVal LastHdc As IntPtr, ByVal AllInfo As System.Text.StringBuilder) As IntPtr

    Function GetPrinterInformation(ByVal Infotype As Short, ByRef Pnfo As Pinfo) As Short
        Dim AllInfo As String = ""
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder(2048)

        Call GetSwimPrinterInformation(Infotype, sb)

        AllInfo = sb.ToString

        Call Convert_String_to_Pinfo(AllInfo, Pnfo)

        GetPrinterInformation = 1

    End Function
    Sub Convert_String_to_Pinfo(ByVal Allinfo As String, ByRef Pnfo As Pinfo)

        ' in case AllInfo is junk, or does not contain any ~
        ' this will hop us OUT of the function
        On Error GoTo Func_end

        Dim Split As String() = Allinfo.Split("~"c)

        With Pnfo
            .DeviceName = Trim(Split(0))                  ' String
            .DriverName = Trim(Split(1))               ' String
            .PrintPort = Trim(Split(2))                  ' String
            .PrintDestinationName = Trim(Split(3))      ' String
            .PrintFileType = Trim(Split(4))            ' String
            .PrintToFile = CShort(Split(5))         ' Short
            .PrintIncludeCodes = CShort(Split(6))   ' Short
            '  DevMode                  = ""    ' sol4_devmode 'fields specified in pinfo to avoid alignment problem
            .dmDeviceName = Split(7)                ' String
            .dmSpecVersion = CShort(Split(8))       ' Short
            .dmDriverVersion = CShort(Split(9))    ' Short
            .dmSize = CShort(Split(10))             ' Short
            .dmDriverExtra = CShort(Split(11))      ' Short
            .dmFields = CInt(Split(12))           ' Short
            '            .dmMyFiller = CShort(Split(14))         ' Short          'used to avoid alignment problems
            .dmOrientation = CShort(Split(13))      ' Short
            .dmPaperSize = CShort(Split(14))        ' Short
            .dmPaperLength = CShort(Split(15))      ' Short
            .dmPaperWidth = CShort(Split(16))       ' Short
            .dmScale = CShort(Split(17))            ' Short
            .dmCopies = CShort(Split(18))           ' Short
            .dmDefaultSource = CShort(Split(19))    ' Short
            .dmPrintQuality = CShort(Split(20))     ' Short
            .dmColor = CShort(Split(21))            ' Short
            .dmDuplex = CShort(Split(22))           ' Short
            .dmYResolution = CShort(Split(23))      ' Short
            .dmTTOption = CShort(Split(24))         ' Short
            .dmCollate = CShort(Split(25))          ' Short
            .dmFormName = Split(26)                 ' String
            .dmLogPixels = CShort(Split(27))        ' Short
            .dmBitsPerPel = CInt(Split(28))         ' Integer
            .dmPelsWidth = CInt(Split(29))          ' Integer
            .dmPelsHeight = CInt(Split(30))         ' Integer
            .dmDisplayFlags = CInt(Split(31))       ' Integer
            .dmDisplayFrequency = CInt(Split(32))   ' Integer
            .dmICMMethod = CInt(Split(33))          ' Integer
            .dmICMIntent = CInt(Split(34))          ' Integer
            .dmMediaType = CInt(Split(35))          ' Integer
            .dmDitherType = CInt(Split(36))         ' Integer
            .dmICCManufacturer = CInt(Split(37))    ' Integer
            .dmICCModel = CInt(Split(38))           ' Integer
            .dmPanningWidth = CInt(Split(39))       ' Integer
            .dmPanningHeight = CInt(Split(40))      ' Integer
            '  FontInfo                 = ""    ' FontStruct   'fields specified in pinfo to avoid alignment problem
            .fiFontName = Split(41)                 ' String
            .fiFontSize = CShort(Split(42))         ' Short
            .fiBold = CShort(Split(43))             ' Short
            .fiItalic = CShort(Split(44))           ' Short
            .WindowsDefault = CShort(Split(45))     ' Short
            .PrinterOrientation = CShort(Split(46)) ' Short
        End With
Func_end:
    End Sub

    Function Convert_Pinfo_To_String(ByVal Pnfo As Pinfo) As String
        Dim AllInfo As String = ""

        With Pnfo
            AllInfo = AllInfo + Trim(CStr(.DeviceName)) + " ~"                  ' String
            AllInfo = AllInfo + Trim(CStr(.DriverName)) + " ~"                  ' String
            AllInfo = AllInfo + Trim(CStr(.PrintPort)) + " ~"                   ' String
            AllInfo = AllInfo + Trim(CStr(.PrintDestinationName)) + " ~"        ' String
            AllInfo = AllInfo + CStr(.PrintFileType) + " ~"               ' String
            AllInfo = AllInfo + CStr(.PrintToFile) + "~"        ' Short
            AllInfo = AllInfo + CStr(.PrintIncludeCodes) + "~"   ' Short
            '  DevMode                  = ""    ' sol4_devmode 'fields specified in pinfo to avoid alignment problem
            AllInfo = AllInfo + CStr(.dmDeviceName) + " ~"                ' String
            AllInfo = AllInfo + CStr(.dmSpecVersion) + "~"       ' Short
            AllInfo = AllInfo + CStr(.dmDriverVersion) + "~"    ' Short
            AllInfo = AllInfo + CStr(.dmSize) + "~"    ' = CShort(Split(11))             ' Short
            AllInfo = AllInfo + CStr(.dmDriverExtra) + "~"    '= CShort(Split(12))      ' Short
            AllInfo = AllInfo + CStr(.dmFields) + "~"    '= CShort(Split(13))           ' Short
            '            AllInfo = AllInfo + CStr(.dmMyFiller) + "~"    ' = CShort(Split(14))         ' Short          'used to avoid alignment problems
            AllInfo = AllInfo + CStr(.dmOrientation) + "~"    ' = CShort(Split(15))      ' Short
            AllInfo = AllInfo + CStr(.dmPaperSize) + "~"    '= CShort(Split(16))        ' Short
            AllInfo = AllInfo + CStr(.dmPaperLength) + "~"    ' = CShort(Split(17))      ' Short
            AllInfo = AllInfo + CStr(.dmPaperWidth) + "~"    ' = CShort(Split(18))       ' Short
            AllInfo = AllInfo + CStr(.dmScale) + "~"    ' = CShort(Split(19))            ' Short
            AllInfo = AllInfo + CStr(.dmCopies) + "~"    ' = CShort(Split(20))           ' Short
            AllInfo = AllInfo + CStr(.dmDefaultSource) + "~"    ' = CShort(Split(21))    ' Short
            AllInfo = AllInfo + CStr(.dmPrintQuality) + "~"    '= CShort(Split(22))     ' Short
            AllInfo = AllInfo + CStr(.dmColor) + "~"    ' = CShort(Split(23))            ' Short
            AllInfo = AllInfo + CStr(.dmDuplex) + "~"    '= CShort(Split(24))           ' Short
            AllInfo = AllInfo + CStr(.dmYResolution) + "~"    ' = CShort(Split(25))      ' Short
            AllInfo = AllInfo + CStr(.dmTTOption) + "~"    ' = CShort(Split(26))         ' Short
            AllInfo = AllInfo + CStr(.dmCollate) + "~"    ' = CShort(Split(27))          ' Short
            AllInfo = AllInfo + CStr(.dmFormName) + " ~"    ' = Split(28)                 ' String
            AllInfo = AllInfo + CStr(.dmLogPixels) + "~"    ' = CShort(Split(29))        ' Short
            AllInfo = AllInfo + CStr(.dmBitsPerPel) + "~"    ' = CInt(Split(30))         ' Integer
            AllInfo = AllInfo + CStr(.dmPelsWidth) + "~"    '= CInt(Split(31))          ' Integer
            AllInfo = AllInfo + CStr(.dmPelsHeight) + "~"    ' = CInt(Split(32))         ' Integer
            AllInfo = AllInfo + CStr(.dmDisplayFlags) + "~"    ' = CInt(Split(33))       ' Integer
            AllInfo = AllInfo + CStr(.dmDisplayFrequency) + "~"    ' = CInt(Split(34))   ' Integer
            AllInfo = AllInfo + CStr(.dmICMMethod) + "~"    ' = CInt(Split(35))          ' Integer
            AllInfo = AllInfo + CStr(.dmICMIntent) + "~"    ' = CInt(Split(36))          ' Integer
            AllInfo = AllInfo + CStr(.dmMediaType) + "~"    ' = CInt(Split(37))          ' Integer
            AllInfo = AllInfo + CStr(.dmDitherType) + "~"    ' = CInt(Split(38))         ' Integer
            AllInfo = AllInfo + CStr(.dmICCManufacturer) + "~"    '= CInt(Split(39))    ' Integer
            AllInfo = AllInfo + CStr(.dmICCModel) + "~"    ' = CInt(Split(40))           ' Integer
            AllInfo = AllInfo + CStr(.dmPanningWidth) + "~"    ' = CInt(Split(41))       ' Integer
            AllInfo = AllInfo + CStr(.dmPanningHeight) + "~"    ' = CInt(Split(42))      ' Integer
            '  FontInfo                 = ""    ' FontStruct   'fields specified in pinfo to avoid alignment problem
            AllInfo = AllInfo + CStr(.fiFontName) + " ~"    ' = Split(43)                 ' String
            AllInfo = AllInfo + CStr(.fiFontSize) + "~"    ' = CShort(Split(44))         ' Short
            AllInfo = AllInfo + CStr(.fiBold) + "~"    '= CShort(Split(45))             ' Short
            AllInfo = AllInfo + CStr(.fiItalic) + "~"    '= CShort(Split(46))           ' Short
            AllInfo = AllInfo + CStr(.WindowsDefault) + "~"    ' = CShort(Split(47))     ' Short
            AllInfo = AllInfo + CStr(.PrinterOrientation) + "~"    ' = CShort(Split(49)) ' Short
        End With

        Convert_Pinfo_To_String = AllInfo
    End Function

    Sub SetPrinterInformation(ByVal Infotype As Short, ByRef Pnfo As Pinfo)
        Dim AllInfo As String = ""

        AllInfo = Convert_Pinfo_To_string(Pnfo)
        Call SetSwimPrinterInformation(Infotype, AllInfo)

    End Sub
#End Region
End Module
' Bug 11405
' Issue the needed TLB_PAINT event here instead of in SWIM.
' This Shown event occurs at the right time for this to occur.
'
#If FORM1NOTPRESENT Then
#Else
Partial Class Form1
    ' Do NOT include this code when Compiling the Parent Application.

#If _REMOVE_SWIM_BAS = False Then
    Private Sub Form1_Shown2(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If (IS_AppServer()) Then
            Dim TLB_PAINT As Int32 = &H8000 + &H1200 + &H14
            SendMessage_to_SWim(Me.Handle, TLB_PAINT, 0, 0)
        End If
    End Sub

    Public Event QuickPrint(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)

#End If
End Class

Namespace My

    Partial Friend Class MyApplication

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            ' This event handler will display a custom error message for the Debug
            ' version of Dynamics SL, that should provide enough information for the 
            ' developer to report the problem, or self-diagnose.  
            '
            ' For the Retail version, the standard behavior for unhandled exceptions
            ' will be used.  If Watson 2.0 is installed, then it will be used to
            ' display error information to the user.
            '
            Solomon.Kernel.UnhandledExceptionHandler.OnUnhandledException(sender, e.Exception)

        End Sub

    End Class

End Namespace
#End If