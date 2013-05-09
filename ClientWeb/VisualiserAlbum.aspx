<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualiserAlbum.aspx.cs"
    Inherits="ClientWeb.VisualiserImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form2" runat="server">
    <div class="page">
        <div class="header">
            <div class="title">
                <h1>
                    Octo-Photo
                </h1>
            </div>
        <div class="loginDisplay">
                <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
                    <AnonymousTemplate>
                        [ <a href="~/Account/Login.aspx" ID="HeadLoginStatus" runat="server">Se connecter</a> ]
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        Bienvenue <span class="bold"><asp:LoginName ID="HeadLoginName" runat="server" /></span>!
                        [ <asp:LoginStatus ID="HeadLoginStatus" runat="server" LogoutAction="Redirect" LogoutText="Se déconnecter" LogoutPageUrl="~/"/> ]
                    </LoggedInTemplate>
                </asp:LoginView>
            </div>
        </div>
    <div class="clear hideSkiplink">
        <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false"
            IncludeStyleBlock="false" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Accueil" />
                <asp:MenuItem NavigateUrl="~/VoirImage.aspx" Text="Voir vos images" />
                <asp:MenuItem NavigateUrl="~/DeposerImage.aspx" Text="Déposer vos images" />
                <asp:MenuItem NavigateUrl="~/VisualiserAlbum.aspx" Text="Visualiser un album" />
            </Items>
        </asp:Menu>
    </div>
    <div class="visualiserAlbum">
        <fieldset class="album">
            <p>
                <asp:Label ID="Label1" runat="server" Text="Label">Utilisateur :</asp:Label>
                <asp:DropDownList ID="DropDownList3" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="idUtilisateur" 
                    DataValueField="idUtilisateur">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DBMiniProjetConnectionString %>" 
                    SelectCommand="SELECT [idUtilisateur] FROM [Utilisateur]">
                </asp:SqlDataSource>
                <asp:Button ID="ChangeUser" runat="server" OnClick="Visualiser_Click" Text="Changer d'utilisateur" />
                <br />
                <asp:Label ID="NumeroAlbumLabel" runat="server" AssociatedControlID="DropDownList1">Numéro d'album :</asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" 
                    DataTextField="idAlbum" DataValueField="idAlbum">
            </asp:DropDownList>
            <asp:Button ID="VisButton" runat="server" OnClick="Visualiser_Click" Text="Visualiser" />
            </p>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DBMiniProjetConnectionString %>" 
                
                SelectCommand="SELECT [idAlbum] FROM [Album] WHERE ([idUtilisateur] = @idUtilisateur)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList3" Name="idUtilisateur" 
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </fieldset>
        <p class="submitButton">
            <asp:Label ID="Label2" runat="server" Text="Label">Nom de l'album à créer : </asp:Label>
            <asp:TextBox ID="NewAlbumName" runat="server"></asp:TextBox>
            <asp:Button ID="NewAlbum" runat="server" 
                Text="Nouvel album" onclick="NewAlbum_Click" />
        </p>
         <fieldset class="images">
        <asp:Label ID="LabelImage" runat="server" AssociatedControlID="DropDownList1">Images contenues dans l'album :</asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3" 
                    DataTextField="nomPhoto" DataValueField="nomPhoto">
                    </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DBMiniProjetConnectionString %>" 
                SelectCommand="SELECT [nomPhoto] FROM [Photo] WHERE ([idAlbum] = @idAlbum)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="idAlbum" 
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:Button ID="Button2" runat="server" Text="Voir l'image" 
                onclick="Button2_Click" />
        </fieldset>
        </p>
        <asp:Image ID="ImageView" runat="server" />

    </div>
    </form>
</body>
</html>
