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
                <asp:Label ID="NumeroAlbumLabel" runat="server" AssociatedControlID="DropDownList1">Numéro d'album :</asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" 
                    DataTextField="idAlbum" DataValueField="idAlbum">
            </asp:DropDownList>
            <asp:Button ID="VisButton" runat="server" OnClick="Visualiser_Click" Text="Visualiser"
                ValidationGroup="DeposValidationGroup" />
            </p>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DBMiniProjetConnectionString %>" 
                SelectCommand="SELECT [idAlbum] FROM [Album]"></asp:SqlDataSource>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="NewAlbum" runat="server" 
                Text="Nouvel album" onclick="NewAlbum_Click" />
        </p>
        <p>
                <asp:ListView ID="albumImagesView" runat="server" 
                onselectedindexchanged="albumImages_SelectedIndexChanged" 
                DataSourceID="SqlDataSource1">
                    <AlternatingItemTemplate>
                        <span style="">blob:
                        <asp:Label ID="blobLabel" runat="server" Text='<%# Eval("blob") %>' />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Voir l'image" />
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# byteArrayToImage((byte[])Eval("blob")) %>' />
                        <br />
                        nom de la photo:
                        <asp:Label ID="nomPhotoLabel" runat="server" Text='<%# Eval("nomPhoto") %>' />
                        <br />
                        <br />
                        <br />
                        </span>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <span style="">blob:
                        <asp:TextBox ID="blobTextBox" runat="server" Text='<%# Bind("blob") %>' />
                        <br />
                        nomPhoto:
                        <asp:TextBox ID="nomPhotoTextBox" runat="server" 
                            Text='<%# Bind("nomPhoto") %>' />
                        <br />
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                            Text="Mettre à jour" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Annuler" />
                        <br />
                        <br />
                        </span>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        <span>Aucune donnée n&#39;a été retournée.</span>
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <span style="">blob:
                        <asp:TextBox ID="blobTextBox" runat="server" Text='<%# Bind("blob") %>' />
                        <br />
                        nomPhoto:
                        <asp:TextBox ID="nomPhotoTextBox" runat="server" 
                            Text='<%# Bind("nomPhoto") %>' />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                            Text="Insérer" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Désactiver" />
                        <br />
                        <br />
                        </span>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <span style="">blob:
                        <asp:Label ID="blobLabel" runat="server" Text='<%# Eval("blob") %>' />
                        <br />
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# byteArrayToImage((byte[])Eval("blob")) %>' />
                        <br />
                        nom de la photo:
                        <asp:Label ID="nomPhotoLabel" runat="server" Text='<%# Eval("nomPhoto") %>' />
                        <br />
                        <br />
                        <br />
                        </span>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <div ID="itemPlaceholderContainer" runat="server" style="">
                            <span runat="server" id="itemPlaceholder" />
                        </div>
                        <div style="">
                        </div>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <span style="">blob:
                        <asp:Label ID="blobLabel" runat="server" Text='<%# Eval("blob") %>' />
                        <br />
                        nomPhoto:
                        <asp:Label ID="nomPhotoLabel" runat="server" Text='<%# Eval("nomPhoto") %>' />
                        <br />
                        <br />
                        </span>
                    </SelectedItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:DBMiniProjetConnectionString %>" 
                
                
                    SelectCommand="SELECT [blob], [nomPhoto] FROM [Photo] WHERE ([idAlbum] = @idAlbum2)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="idAlbum2" 
                        PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
    </div>
    </form>
</body>
</html>
