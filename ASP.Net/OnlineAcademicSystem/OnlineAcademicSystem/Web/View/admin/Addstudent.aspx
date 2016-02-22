<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addstudent.aspx.cs" Inherits="Web.View.admin.Addstudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4>添加学生信息</h4>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="学生学号："></asp:Label>
            <asp:TextBox ID="txt_student_id" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="所属年级："></asp:Label>
            <asp:DropDownList ID="drp_grade_id" runat="server" Height="17px" Width="144px" DataSourceID="student_grade" DataTextField="grade_name" DataValueField="grade_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="student_grade" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [grade]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="所属班级："></asp:Label>
            <asp:DropDownList ID="drp_classes_id" runat="server" Height="17px" Width="144px" DataSourceID="student_classes" DataTextField="class_name" DataValueField="class_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="student_classes" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT [class_id], [class_name] FROM [classes]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="所属专业："></asp:Label>
            <asp:DropDownList ID="drp_major_id" runat="server" Height="17px" Width="144px" DataSourceID="student_major" DataTextField="major_name" DataValueField="major_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="student_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="学生姓名："></asp:Label>
            <asp:TextBox ID="txt_student_name" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="学生性别："></asp:Label>
            <asp:DropDownList ID="drp_student_sex" runat="server" Height="17px" Width="144px">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="联系方式："></asp:Label>
            <asp:TextBox ID="txt_student_tel" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="生 源 地："></asp:Label>
            <asp:TextBox ID="txt_student_palaces" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label9" runat="server" Text="学生密码："></asp:Label>
            <asp:TextBox ID="txt_student_password" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
        </p>
    </div>
</asp:Content>
