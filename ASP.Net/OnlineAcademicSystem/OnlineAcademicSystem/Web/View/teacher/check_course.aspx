<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="check_course.aspx.cs" Inherits="Web.View.teacher.check_course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div>
        <h3 style="text-align:center">查看授课</h3>
        <p style="text-align:center">&nbsp;</p>
        <p style="text-align:center">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="课程编号" ReadOnly="True" SortExpression="course_id" />
                    <asp:BoundField DataField="classroom_name" HeaderText="上课教室" SortExpression="classroom_name" />
                    <asp:BoundField DataField="course_type_name" HeaderText="课程类型" SortExpression="course_type_name" />
                    <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" />
                    <asp:BoundField DataField="course_name" HeaderText="课程名" SortExpression="course_name" />
                    <asp:BoundField DataField="course_time" HeaderText="上课时间" SortExpression="course_time" />
                </Columns>
            </asp:GridView>
        </p>
    </div>
</asp:Content>
