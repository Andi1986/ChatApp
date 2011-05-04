<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="WebApplication1._Register" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
    <asp:Label ID="WelcomeLabel" runat="server" Text="Register User" Font-Bold="True"
        Font-Size="X-Large"></asp:Label>
    <br />
    <br />
    <h2>
        Please enter your user data</h2>
    <p>
        &nbsp;<asp:UpdatePanel ID="ErrorLabelUpdatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="ErrorLabel" runat="server" Font-Size="Larger" ForeColor="Red" Text="Label"
                    Visible="False"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    Username<br />
    <asp:TextBox ID="UsernameBox" runat="server" Width="212px"></asp:TextBox>
    &nbsp;<br />
    EMail<br />
    <asp:TextBox ID="EmailBox" runat="server" Width="212px"></asp:TextBox>
    &nbsp;<br />
    Password<br />
    <asp:TextBox ID="PasswordBox1" runat="server" Width="212px" TextMode="password" ></asp:TextBox>
    &nbsp;<br />
    Repeat Password<br />
    <asp:TextBox ID="PasswordBox2" runat="server" Width="212px" TextMode="password" ></asp:TextBox>
    &nbsp;<br />
    <asp:Button ID="EnterButton" runat="server" Text="Register" OnClick="EnterButton_Click" />
</asp:Content>
