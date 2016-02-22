<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="query_course_list.aspx.cs" Inherits="Web.View.student.query_course_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <h3>课程表</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="课程编号" ReadOnly="True" SortExpression="course_id" />
                    <asp:BoundField DataField="course_name" HeaderText="课程名称" SortExpression="course_name" />
                    <asp:BoundField DataField="course_time" HeaderText="上课时间" SortExpression="course_time" />
                    <asp:BoundField DataField="classroom_name" HeaderText="上课教室" SortExpression="classroom_name" />
                    <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" />
                    <asp:BoundField DataField="teacher_name" HeaderText="任课老师" SortExpression="teacher_name" />
                </Columns>
            </asp:GridView>
        </p>
    </div>
</asp:Content>
