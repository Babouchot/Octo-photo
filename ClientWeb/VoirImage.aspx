<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VoirImage.aspx.cs" Inherits="ClientWeb.VoirImage" %>

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
        <div>
        <p>
            Salut
            <%
                // Si la variable de session user est non nulle,
                // on "écrit" sa valeur dans la page HTML que l'on génère
                if (Session["user"] != null)
                {
                    Response.Write(Session["user"]);
                }
                else
                {
                    Response.Write("inconnu");
                } %>
                . Quel image voulez-vous visualiser ?
        </p>
        <p>
            Votre nom :
            <asp:TextBox ID="UserTextBox" runat="server" />
            <asp:Button ID="UserBouton" runat="server" OnClick="Authentifier_Click" Text="Ok" />
        </p>
        <p>
            <asp:Image ID="ImageCourante" runat="server" />
        </p>
        <p>
            Image&nbsp;ID&nbsp;:&nbsp;
            <asp:TextBox ID="ImageIDBox" runat="server" />
            <asp:Button ID="Visualiser" runat="server" OnClick="Visualiser_Click" Text="Visualiser" />
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