<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="delete_student.aspx.cs" Inherits="Web.View.admin.delete_student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>删除学生</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" DataSourceID="student" OnRowDataBound="gridView_RowDataBound" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="学号" ReadOnly="True" SortExpression="student_id" />
                    <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" />
                    <asp:BoundField DataField="grade_name" HeaderText="年级" SortExpression="grade_name" />
                    <asp:BoundField DataField="class_name" HeaderText="班级" SortExpression="class_name" />
                    <asp:BoundField DataField="student_name" HeaderText="姓名" SortExpression="student_name" />
                    <asp:BoundField DataField="student_sex" HeaderText="性别" SortExpression="student_sex" />
                    <asp:BoundField DataField="student_tel" HeaderText="联系方式" SortExpression="student_tel" />
                    <asp:BoundField DataField="student_places" HeaderText="生源地" SortExpression="student_places" />
                    <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" Text="删除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="student" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT student.student_id, major.major_name, grade.grade_name, classes.class_name, student.student_name, student.student_sex, student.student_tel, student.student_places, student.student_password FROM student INNER JOIN major ON student.major_id = major.major_id INNER JOIN grade ON student.grade_id = grade.grade_id INNER JOIN classes ON student.class_id = classes.class_id"></asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
