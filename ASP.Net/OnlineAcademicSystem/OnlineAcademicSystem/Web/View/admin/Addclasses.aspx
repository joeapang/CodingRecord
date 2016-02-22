<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addclasses.aspx.cs" Inherits="Web.View.admin.Addclasses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4>添加班级信息</h4>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="班级编号："></asp:Label>
            <asp:TextBox ID="txt_class_id" runat="server" TextMode="Number"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="年级名称："></asp:Label>
            <asp:DropDownList ID="drp_grade_id" runat="server" Height="16px" Width="144px" DataSourceID="SqlDataSource1" DataTextField="grade_name" DataValueField="grade_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [grade]"></asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="所属专业："></asp:Label>
            <asp:DropDownList ID="drp_major_id" runat="server" Height="16px" Width="144px" DataSourceID="classes_major" DataTextField="major_name" DataValueField="major_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="classes_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="班级名称："></asp:Label>
            <asp:TextBox ID="txt_class_name" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" style="height: 21px" />
            &nbsp;
            <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
        </p>
    </div>
</asp:Content>
