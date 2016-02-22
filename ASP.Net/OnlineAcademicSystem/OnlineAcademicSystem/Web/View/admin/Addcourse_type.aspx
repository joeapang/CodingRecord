<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addcourse_type.aspx.cs" Inherits="Web.View.admin.Addcourse_type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4>添加课程类型</h4>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="课程类型编号："></asp:Label>
            <asp:TextBox ID="txt_course_type_id" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="课程类型名称："></asp:Label>
            <asp:TextBox ID="txt_course_type_name" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
        </p>
    </div>
</asp:Content>
