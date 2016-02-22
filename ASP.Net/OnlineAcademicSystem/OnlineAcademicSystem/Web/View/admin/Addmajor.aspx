<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addmajor.aspx.cs" Inherits="Web.View.admin.Addmajor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:auto;">
        <h4>添加学院信息</h4>
        <br />
        <asp:Label ID="Label1" runat="server" Text="学院编号："></asp:Label>
        <asp:TextBox ID="txt_major_id" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="学院名称："></asp:Label>
        <asp:TextBox ID="txt_major_name" runat="server"></asp:TextBox>
        <br />
        <br />
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
        <br />
    </div>
</asp:Content>
