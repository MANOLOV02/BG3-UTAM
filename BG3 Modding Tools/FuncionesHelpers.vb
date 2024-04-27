Imports System.ComponentModel
Imports System.DirectoryServices
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Net.WebRequestMethods
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Text.Json
Imports BG3_Modding_Tools
Imports BG3_Modding_Tools.FuncionesHelpers
Imports LSLib.LS
Imports LSLib.LS.Enums
Imports Pfim


Class FuncionesHelpers
    'Public Shared Lista_Enum_GameObjectType As List(Of String) = [Enum].GetNames(GetType(BG3_Enum_GameObject_Type)).ToList
    Public Shared GameEngine As New Main_GameEngine_Class
    Public Shared Progreso As New BG3_Custom_Progreso_Class
    Public Shared Jsonoptions As New JsonSerializerOptions With {.IgnoreReadOnlyProperties = True, .IgnoreReadOnlyFields = True, .WriteIndented = True, .DefaultIgnoreCondition = Serialization.JsonIgnoreCondition.WhenWritingDefault}
    Public Shared Small_No_Ok As New Bitmap(My.Resources.No_Ok.ToBitmap, 16, 16)
    Public Shared Small_Ok As New Bitmap(My.Resources.Ok.ToBitmap, 16, 16)
    Public Shared ItemRarity As New List(Of String) From {"Common", "Uncommon", "Rare", "VeryRare", "Legendary"}
    Public Shared UTAM_Groups As New List(Of String) From {"(Default)"}
    Public Shared ColorMaterialsNames As New List(Of String) From {"Color_01", "Color_02", "Color_03", "Cloth_Primary", "Cloth_Secondary", "Cloth_Tertiary", "Leather_Primary", "Leather_Secondary", "Leather_Tertiary", "Metal_Primary", "Metal_Secondary", "Metal_Tertiary", "Custom_1", "Custom_2", "Accent_Color"}
End Class
