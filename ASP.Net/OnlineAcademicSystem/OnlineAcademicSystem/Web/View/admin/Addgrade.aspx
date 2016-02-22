<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addgrade.aspx.cs" Inherits="Web.View.admin.Addgrade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:auto">
        <asp:Label ID="Label1" runat="server" Text="年级编号："></asp:Label>
        <asp:TextBox ID="txt_grade_id" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="年级名称："></asp:Label>
        <asp:TextBox ID="txt_grade_name" runat="server"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
        &nbsp;<asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
    </div>
</asp:Content>
