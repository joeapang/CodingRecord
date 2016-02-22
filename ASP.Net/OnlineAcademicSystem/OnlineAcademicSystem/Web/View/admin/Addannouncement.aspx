<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addannouncement.aspx.cs" Inherits="Web.View.admin.Addannouncement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    #textarea1 {
        width: 603px;
        height: 165px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:720px;height:auto;margin:auto">
      <center><h3>发布公告</h3>
          <p>&nbsp;</p>
        </center>
        <asp:Label ID="Label4" runat="server" Text="公告编号："></asp:Label>
        <asp:TextBox ID="txt_announcement_id" runat="server" Width="603px" Height="25px" TextMode="Number"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="公告标题："></asp:Label>
        <asp:TextBox ID="txt_announcement_title" runat="server" Width="603px" Height="25px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="公告正文："></asp:Label>
        <asp:TextBox ID="txt_announcement_content" runat="server" Height="209px" Width="603px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="公告附件："></asp:Label>
        <asp:FileUpload ID="txt_announcement_attachment" runat="server" />
        <br />
&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="37px" Text="发布" Width="79px" OnClick="Button1_Click" />
    </div>
</asp:Content>
