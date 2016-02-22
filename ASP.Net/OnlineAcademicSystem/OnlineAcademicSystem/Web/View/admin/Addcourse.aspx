<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Addcourse.aspx.cs" Inherits="Web.View.admin.Addcourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h4>添加课程信息</h4>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="课程编号："></asp:Label>
            <asp:TextBox ID="txt_course_id" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="课程类型："></asp:Label>
            <asp:DropDownList ID="drp_course_type_id" runat="server" Height="17px" Width="144px" DataSourceID="couese_coursetype" DataTextField="course_type_name" DataValueField="course_type_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="couese_coursetype" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [course_type]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="所属专业："></asp:Label>
            <asp:DropDownList ID="drp_major_id" runat="server" Height="17px" Width="144px" DataSourceID="course_major" DataTextField="major_name" DataValueField="major_id" AutoPostBack="True">
            </asp:DropDownList>
            <asp:SqlDataSource ID="course_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="所属年级："></asp:Label>
            <asp:DropDownList ID="drp_grade_id" runat="server" Height="17px" Width="144px" DataSourceID="course_grade" DataTextField="grade_name" DataValueField="grade_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="course_grade" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [grade]"></asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="上课教室："></asp:Label>
            <asp:DropDownList ID="drp_classroom_id" runat="server" Height="17px" Width="144px" DataSourceID="course_classroom" DataTextField="classroom_name" DataValueField="classroom_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="course_classroom" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [classroom]"></asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="上课老师："></asp:Label>
            <asp:DropDownList ID="drp_teacher_id" runat="server" Height="17px" Width="144px" DataSourceID="course_teacher" DataTextField="teacher_name" DataValueField="teacher_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="course_teacher" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT [teacher_id], [teacher_name] FROM [teacher] WHERE ([major_id] = @major_id)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="drp_major_id" DefaultValue="" Name="major_id" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="课程名称："></asp:Label>
            <asp:TextBox ID="txt_course_name" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="上课时间："></asp:Label>
            <asp:DropDownList ID="drp_course_time1" runat="server" Height="17px" Width="72px">
                <asp:ListItem>周一</asp:ListItem>
                <asp:ListItem>周二</asp:ListItem>
                <asp:ListItem>周三</asp:ListItem>
                <asp:ListItem>周四</asp:ListItem>
                <asp:ListItem>周五</asp:ListItem>
                <asp:ListItem>周六</asp:ListItem>
                <asp:ListItem>周日</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="drp_course_time2" runat="server" Height="17px" Width="72px">
                <asp:ListItem>（1、2）节</asp:ListItem>
                <asp:ListItem>（3、4）节</asp:ListItem>
                <asp:ListItem>（5、6）节</asp:ListItem>
                <asp:ListItem>（7、8）节</asp:ListItem>
                <asp:ListItem>（9、10）节</asp:ListItem>
                <asp:ListItem>（11、12）节</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>&nbsp;</p>
        <p>&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
        </p>
    </div>
</asp:Content>
