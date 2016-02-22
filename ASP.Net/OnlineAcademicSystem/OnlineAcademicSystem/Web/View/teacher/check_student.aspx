<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="check_student.aspx.cs" Inherits="Web.View.teacher.check_student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div style="width:900px;height:auto;margin:0 auto">
        <h3>查看学生信息</h3>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="查询条件："></asp:Label>
            <asp:DropDownList ID="drp_tiaojian" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>查询全部</asp:ListItem>
                <asp:ListItem>粗略查询</asp:ListItem>
                <asp:ListItem>按学号查询</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lab_stu_id" runat="server" Text="学号：" Visible="False"></asp:Label>
            <asp:TextBox ID="txt_stu_id" runat="server" Visible="False"></asp:TextBox>
            &nbsp;<asp:DropDownList ID="drp_major" runat="server" DataSourceID="checkstudent_major" DataTextField="major_name" DataValueField="major_id" Visible="False" AutoPostBack="True">
            </asp:DropDownList>
            <asp:DropDownList ID="drp_classes" runat="server" DataSourceID="checkstudent_classes" DataTextField="class_name" DataValueField="class_id" Visible="False">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:SqlDataSource ID="checkstudent_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
&nbsp;<asp:SqlDataSource ID="checkstudent_classes" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT [class_id], [class_name] FROM [classes] WHERE ([major_id] = @major_id)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="drp_major" Name="major_id" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" OnRowDataBound="gridView_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="学号" ReadOnly="True" SortExpression="student_id" />
                    <asp:BoundField DataField="grade_name" HeaderText="年级" SortExpression="grade_name" />
                    <asp:BoundField DataField="class_name" HeaderText="班级" SortExpression="class_name" />
                    <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" />
                    <asp:BoundField DataField="student_name" HeaderText="姓名" SortExpression="student_name" />
                    <asp:BoundField DataField="student_sex" HeaderText="性别" SortExpression="student_sex" />
                    <asp:BoundField DataField="student_tel" HeaderText="联系方式" SortExpression="student_tel" />
                    <asp:BoundField DataField="student_places" HeaderText="生源地" SortExpression="student_places" />
                </Columns>
            </asp:GridView>
            &nbsp;<asp:SqlDataSource ID="checkstudent" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT student.student_id, grade.grade_name, classes.class_name, major.major_name, student.student_name, student.student_sex, student.student_tel, student.student_places FROM student INNER JOIN major ON student.major_id = major.major_id INNER JOIN grade ON student.grade_id = grade.grade_id INNER JOIN classes ON student.class_id = classes.class_id "></asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
