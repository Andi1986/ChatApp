<%@ Page Title="Startseite" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Chat.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="WelcomeLabel" runat="server" Text="Chat Test" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />
    <br />
    <h2>
        Enter Username</h2>
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;
    <asp:Button ID="EnterButton" runat="server" Text="Enter" 
        onclick="EnterButton_Click" />
</asp:Content>
