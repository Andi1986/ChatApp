<%@ Page Title="Startseite" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Chat.aspx.cs" Inherits="WebApplication1._Chat" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
    <asp:Label ID="WelcomeLabel" runat="server" Font-Bold="True" Font-Size="X-Large"
        Text="Chat Test"></asp:Label>
    <br />
    <br />
    <asp:UpdatePanel ID="ChatUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            Buddys<br />
            <asp:BulletedList ID="ChattersBulletedList" runat="server" />
            Chat Text<br />
            <div id="ChatText" style="width: 640px; height: 240px; overflow: auto;">
                <asp:BulletedList runat="server" ID="ChatMessageList" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    Send Message<asp:Panel ID="Panel1" runat="server" DefaultButton="SendButton">
        <asp:UpdatePanel ID="TextBoxUpdatePanel" runat="server" 
        UpdateMode="Conditional">
            <ContentTemplate>
                <asp:TextBox ID="NewMessageTextBox" Columns="50" runat="server" />
                <asp:Button ID="SendButton" runat="server" EnableViewState="false" 
                OnClick="SendButton_Click" Text="Send" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <br />
    &nbsp;<asp:Button ID="LeaveButton" runat="server" onclick="LeaveButton_Click" 
        Text="Leave" />
&nbsp;<script type="text/javascript">
        function _SetChatTextScrollPosition() {
            var chatText = document.getElementById("ChatText");
            chatText.scrollTop = chatText.scrollHeight;
            window.setTimeout("_SetChatTextScrollPosition()", 1);
        }

        window.onload = function () {
            _SetChatTextScrollPosition();
        }
    </script><asp:Button ID="ChangeButton" runat="server" 
        onclick="ChangeButton_Click" Text="Change Room" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="ChatTextTimer" runat="server" Interval="1000" 
                ontick="ChatTextTimer_Tick" />
        </ContentTemplate>
    </asp:UpdatePanel>
&nbsp;
</asp:Content>
