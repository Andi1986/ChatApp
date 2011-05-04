<%@ Page Title="Startseite" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
    <asp:Label ID="WelcomeLabel" runat="server" Text="Chat Test" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />
    <br />
    <h2>
        Enter Login Data</h2>
    <p>
        &nbsp;<asp:UpdatePanel ID="ErrorLabelUpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="ErrorLabel" runat="server" Font-Size="Larger" ForeColor="Red" Text="Label"
                    Visible="False"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    Username<br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;<br />
    Password<br />
    <asp:TextBox ID="TextBox2" runat="server" TextMode="password" ></asp:TextBox>&nbsp;<asp:Button ID="EnterButton" runat="server" Text="Enter" OnClick="EnterButton_Click" />
</asp:Content>
