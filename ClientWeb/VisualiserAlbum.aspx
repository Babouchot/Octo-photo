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
    <asp:ValidationSummary ID="DeposValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="DeposValidationGroup"/>
    <div class="visualiserAlbum">
        <fieldset class="album">
            <p>
                <asp:Label ID="NumeroAlbumLabel" runat="server" AssociatedControlID="NumeroAlbum">Numéro d'album :</asp:Label>
                <asp:TextBox ID="NumeroAlbum" runat="server" CssClass="textEntry"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NumeroAlbumRequired" runat="server" ControlToValidate="NumeroAlbum"
                    CssClass="failureNotification" ErrorMessage="Un numéro d'album est requis." ToolTip="Un numéro d'album est requis."
                    ValidationGroup="DeposValidationGroup">*</asp:RequiredFieldValidator>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="VisButton" runat="server" OnClick="Visualiser_Click" Text="Visualiser"
                ValidationGroup="DeposValidationGroup" />
        </p>
    </div>
    </form>
</body>
</html>
