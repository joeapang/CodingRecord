﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="check_student_score.aspx.cs" Inherits="Web.View.admin.check_student_score" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h3>成绩录入</h3>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="学号："></asp:Label>
            <asp:TextBox ID="txt_student_id" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />
         &nbsp;<asp:Button ID="Button2" runat="server" Text="查看全部" OnClick="Button2_Click" />
         </p>
         <p>
             &nbsp;</p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="entryscore" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" DataKeyNames="student_id,course_id" OnRowDataBound="gridView_RowDataBound">
            <Columns>
                <asp:BoundField DataField="student_id" HeaderText="学号" SortExpression="student_id" ReadOnly="True" />
                <asp:BoundField DataField="course_id" HeaderText="课程编号" SortExpression="course_id" ReadOnly="True" />
                <asp:BoundField DataField="student_name" HeaderText="姓名" SortExpression="student_name" ReadOnly="True" />
                <asp:BoundField DataField="student_sex" HeaderText="性别" ReadOnly="True" SortExpression="student_sex" />
                <asp:BoundField DataField="course_name" HeaderText="课程名称" SortExpression="course_name" ReadOnly="True" />
                <asp:BoundField DataField="course_type_name" HeaderText="课程类型" SortExpression="course_type_name" ReadOnly="True" />
                <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" ReadOnly="True" />
                <asp:BoundField DataField="grade_name" HeaderText="年级" SortExpression="grade_name" ReadOnly="True" />
                <asp:BoundField DataField="class_name" HeaderText="班级" SortExpression="class_name" ReadOnly="True" />
                <asp:BoundField DataField="course_score" HeaderText="成绩" SortExpression="course_score" />
                <asp:CommandField HeaderText="成绩管理" ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="entryscore" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT choose_course.student_id, choose_course.course_id, student.student_name, student.student_sex, course.course_name, course_type.course_type_name, major.major_name, grade.grade_name, classes.class_name, choose_course.course_score FROM major INNER JOIN student INNER JOIN grade ON student.grade_id = grade.grade_id INNER JOIN classes ON student.class_id = classes.class_id ON major.major_id = student.major_id INNER JOIN choose_course INNER JOIN course ON choose_course.course_id = course.course_id INNER JOIN course_type ON course.course_type_id = course_type.course_type_id ON student.student_id = choose_course.student_id INNER JOIN teacher_course ON course.course_id = teacher_course.course_id" UpdateCommand="UPDATE choose_course SET course_score = @course_score WHERE (student_id = @student_id) AND (course_id = @course_id)">
        </asp:SqlDataSource>
         <br />
        <asp:SqlDataSource ID="entryscore1" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT choose_course.student_id, choose_course.course_id, student.student_name, student.student_sex, course.course_name, course_type.course_type_name, major.major_name, grade.grade_name, classes.class_name, choose_course.course_score FROM major INNER JOIN student INNER JOIN grade ON student.grade_id = grade.grade_id INNER JOIN classes ON student.class_id = classes.class_id ON major.major_id = student.major_id INNER JOIN choose_course INNER JOIN course ON choose_course.course_id = course.course_id INNER JOIN course_type ON course.course_type_id = course_type.course_type_id ON student.student_id = choose_course.student_id INNER JOIN teacher_course ON course.course_id = teacher_course.course_id WHERE (choose_course.student_id = @student_id)" UpdateCommand="UPDATE choose_course SET course_score = @course_score WHERE (student_id = @student_id) AND (course_id = @course_id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="txt_student_id" Name="student_id" PropertyName="Text" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="course_score" />
                <asp:Parameter Name="student_id" />
                <asp:Parameter Name="course_id" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>