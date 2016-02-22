<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="coursemanagement.aspx.cs" Inherits="Web.View.admin.coursemanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div1" runat="server">
        <h3>课程信息(<a href="Addcourse.aspx">添加课程信息</a>)</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="course_id" DataSourceID="course" Width="615px" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="课程编号" ReadOnly="True" SortExpression="course_id" />
                    <asp:BoundField DataField="classroom_name" HeaderText="教室" SortExpression="classroom_name" />
                    <asp:BoundField DataField="course_type_name" HeaderText="课程类型" SortExpression="course_type_name" />
                    <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" />
                    <asp:BoundField DataField="course_name" HeaderText="课程名称" SortExpression="course_name" />
                    <asp:BoundField DataField="course_time" HeaderText="上课时间" SortExpression="course_time" />
                    <asp:BoundField DataField="grade_name" HeaderText="年级" SortExpression="grade_name" />
                    <asp:BoundField DataField="teacher_name" HeaderText="上课教师" SortExpression="teacher_name" />
                    <asp:TemplateField HeaderText="编辑">
                            <ItemTemplate>
                                <asp:Button ID="btn_edit" runat="server" Text="编辑" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="course" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT course.course_id, classroom.classroom_name, course_type.course_type_name, major.major_name, course.course_name, course.course_time, grade.grade_name, teacher.teacher_name FROM course INNER JOIN course_type ON course.course_type_id = course_type.course_type_id INNER JOIN classroom ON course.classroom_id = classroom.classroom_id INNER JOIN grade ON course.grade_id = grade.grade_id INNER JOIN major ON course.major_id = major.major_id INNER JOIN teacher_course ON course.course_id = teacher_course.course_id INNER JOIN teacher ON teacher_course.teacher_id = teacher.teacher_id"></asp:SqlDataSource>
        </p>
    </div>
    <div id="div2" runat="server">
        <h4>修改课程信息<asp:Label ID="lab_course_id" runat="server" Text="Label" Visible="False"></asp:Label>
        </h4>

        <br />
        <asp:Label ID="Label4" runat="server" Text="课程类型："></asp:Label>
        <asp:DropDownList ID="drp_course_type" runat="server" DataSourceID="course_type" DataTextField="course_type_name" DataValueField="course_type_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="course_type" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [course_type]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="所属专业："></asp:Label>
        <asp:DropDownList ID="drp_course_major" runat="server" DataSourceID="course_major" DataTextField="major_name" DataValueField="major_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="course_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="所属年级："></asp:Label>
        <asp:DropDownList ID="drp_course_grade" runat="server" DataSourceID="course_grade" DataTextField="grade_name" DataValueField="grade_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="course_grade" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [grade]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="上课教室："></asp:Label>
        <asp:DropDownList ID="drp_course_classroom" runat="server" DataSourceID="course_classroom" DataTextField="classroom_name" DataValueField="classroom_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="course_classroom" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [classroom]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="上课老师："></asp:Label>
        <asp:DropDownList ID="drp_course_teacher" runat="server" DataSourceID="course_teacher" DataTextField="teacher_name" DataValueField="teacher_id">
        </asp:DropDownList>
        <asp:SqlDataSource ID="course_teacher" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT [teacher_id], [teacher_name] FROM [teacher]">
        </asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="课程名称："></asp:Label>
        <asp:TextBox ID="txt_course_name" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="上课时间："></asp:Label>
        <asp:TextBox ID="txt_course_time" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Height="24px" Text="修改" Width="43px" OnClick="Button1_Click" />
&nbsp;<asp:Button ID="Button2" runat="server" Height="24px" Text="取消" Width="42px" OnClick="Button2_Click" />

    </div>
</asp:Content>
