<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="check_score.aspx.cs" Inherits="Web.View.student.check_score" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <h3>成绩单</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id" DataSourceID="checkscore">
                <Columns>
                    <asp:BoundField DataField="course_name" HeaderText="课程名称" SortExpression="course_name" />
                    <asp:BoundField DataField="course_score" HeaderText="成绩" SortExpression="course_score" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="checkscore" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT course.course_id, course.course_name, choose_course.course_score FROM choose_course INNER JOIN course ON choose_course.course_id = course.course_id WHERE (choose_course.student_id = @student_id)">
                <SelectParameters>
                    <asp:SessionParameter Name="student_id" SessionField="name" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
