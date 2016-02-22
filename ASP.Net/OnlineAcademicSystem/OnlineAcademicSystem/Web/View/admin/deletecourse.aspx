<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="deletecourse.aspx.cs" Inherits="Web.View.admin.deletecourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>删除课程</h3>
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
                    <asp:TemplateField HeaderText="删除">
                        <ItemTemplate>
                            <asp:Button ID="btn_delete" runat="server" Text="删除" />
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

</asp:Content>
