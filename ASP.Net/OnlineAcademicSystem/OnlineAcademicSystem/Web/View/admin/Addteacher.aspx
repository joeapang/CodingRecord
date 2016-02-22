<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addteacher.aspx.cs" Inherits="Web.View.admin.Addteacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4>添加教师信息</h4>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="教师编号："></asp:Label>
            <asp:TextBox ID="txt_teacher_id" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="教师职称："></asp:Label>
            <asp:DropDownList ID="drp_teacher_position_id" runat="server" Height="17px" Width="144px" DataSourceID="teaxher_teacherposition" DataTextField="teacher_position_name" DataValueField="teacher_position_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="teaxher_teacherposition" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [teacher_position]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="所属学院："></asp:Label>
            <asp:DropDownList ID="drp_major_id" runat="server" Height="17px" Width="144px" DataSourceID="teacher_major" DataTextField="major_name" DataValueField="major_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="teacher_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="教师姓名："></asp:Label>
            <asp:TextBox ID="txt_teacher_name" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="教师性别："></asp:Label>
            <asp:DropDownList ID="drp_teacher_sex" runat="server" Height="17px" Width="144px">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="联系方式："></asp:Label>
            <asp:TextBox ID="txt_teacher_tel" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="教师密码："></asp:Label>
            <asp:TextBox ID="txt_teacher_password" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
        </p>
    </div>
</asp:Content>
