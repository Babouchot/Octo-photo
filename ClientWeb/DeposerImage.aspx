<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeposerImage.aspx.cs" Inherits="ClientWeb.DeposerImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Accueil"/>
                        <asp:MenuItem NavigateUrl="~/VoirImage.aspx" Text="Voir vos images"/>
                        <asp:MenuItem NavigateUrl="~/DeposerImage.aspx" Text="Déposer vos images"/>
                    </Items>
                </asp:Menu>
            </div>
            <asp:ValidationSummary ID="DeposValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="DeposValidationGroup"/>
  <div class="deposImage">
                <fieldset class="depos">
                    <p>
                        <asp:Label ID="NomImageLabel" runat="server" AssociatedControlID="NomImage">Nom d'image :</asp:Label>
                        <asp:TextBox ID="NomImage" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NomImageRequired" runat="server" ControlToValidate="NomImage" 
                             CssClass="failureNotification" ErrorMessage="Un nom d'image est requis." ToolTip="Un nom d'image est requis." 
                             ValidationGroup="DeposValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="NumeroAlbumLabel" runat="server" AssociatedControlID="NumeroAlbum">Numéros d'album :</asp:Label>
                        <asp:TextBox ID="NumeroAlbum" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NumeroAlbumRequired" runat="server" ControlToValidate="NumeroAlbum" 
                             CssClass="failureNotification" ErrorMessage="Un numéro d'album est requis." ToolTip="Un numéro d'album est requis." 
                             ValidationGroup="DeposValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PathLabel" runat="server" AssociatedControlID="Path">Path :</asp:Label>
                        <asp:TextBox ID="Path" runat="server" CssClass="Entry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PathRequired" runat="server" ControlToValidate="Path" 
                             CssClass="failureNotification" ErrorMessage="Un path est requis." ToolTip="Un path passe est requis." 
                             ValidationGroup="DeposValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="DeposButton" runat="server" OnClick="Deposer_Click" Text="Deposer" ValidationGroup="DeposValidationGroup"/>
                </p>
            </div>
        <div>
        <p>
        <%
           if (Session["transfert"] != null)
                {
                    Response.Write(Session["transfert"]);
                }
                %>
          </p>
        </div>

        <div class="clear">
        </div>
    </div>
    <div class="footer">
        
    </div>
    </form>
</body>
</html>


