<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="studentmanagement.aspx.cs" Inherits="Web.View.admin.studentmanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div1" runat="server">
        <h3>学生信息(<a href="Addstudent.aspx">添加学生信息</a>)</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="student_id" DataSourceID="student" AllowPaging="True" OnRowDataBound="gridView_RowDataBound" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="学号" ReadOnly="True" SortExpression="student_id" />
                    <asp:BoundField DataField="grade_name" HeaderText="年级" SortExpression="grade_name" />
                    <asp:BoundField DataField="class_name" HeaderText="班级" SortExpression="class_name" />
                    <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" />
                    <asp:BoundField DataField="student_name" HeaderText="姓名" SortExpression="student_name" />
<asp:BoundField DataField="student_sex" HeaderText="性别" SortExpression="student_sex"></asp:BoundField>
                    <asp:BoundField DataField="student_tel" HeaderText="联系方式" SortExpression="student_tel" />
                    <asp:BoundField DataField="student_places" HeaderText="生源地" SortExpression="student_places" />
                    <asp:BoundField DataField="student_password" HeaderText="密码" SortExpression="student_password" />
                    <asp:TemplateField HeaderText="编辑">
                            <ItemTemplate>
                                <asp:Button ID="btn_edit" runat="server" Text="编辑" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="student" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT student.student_id, grade.grade_name, classes.class_name, major.major_name, student.student_name, student.student_sex, student.student_tel, student.student_places, student.student_password FROM major INNER JOIN student ON major.major_id = student.major_id INNER JOIN grade ON student.grade_id = grade.grade_id INNER JOIN classes ON student.class_id = classes.class_id"></asp:SqlDataSource>
        </p>
    </div>
     <div id="div2" runat="server">
        <h3>修改学生信息</h3>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="学  号："></asp:Label>
            &nbsp;&nbsp; <asp:TextBox ID="txt_student_id" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;</p>
         <p>
             <asp:Label ID="Label4" runat="server" Text="年  级："></asp:Label>
            &nbsp;<asp:DropDownList ID="drp_student_grade" runat="server" DataSourceID="student_grade" DataTextField="grade_name" DataValueField="grade_id" Height="17px" Width="144px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="student_grade" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [grade]"></asp:SqlDataSource>
&nbsp;<asp:Label ID="Label5" runat="server" Text="班级："></asp:Label>
            &nbsp;<asp:DropDownList ID="drp_student_classes" runat="server" DataSourceID="student_classes" DataTextField="class_name" DataValueField="class_id" Height="17px" Width="144px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="student_classes" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT [class_id], [class_name] FROM [classes]"></asp:SqlDataSource>
        </p>
         <p>
             &nbsp;</p>
         <p>
             <asp:Label ID="Label9" runat="server" Text="专  业："></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="drp_student_major" runat="server" DataSourceID="student_major" DataTextField="major_name" DataValueField="major_id" Height="17px" Width="144px">
            </asp:DropDownList>
             <asp:SqlDataSource ID="student_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
            &nbsp;
            <asp:Label ID="Label6" runat="server" Text="姓  名："></asp:Label>
&nbsp;<asp:TextBox ID="txt_student_name" runat="server"></asp:TextBox>
&nbsp;</p>
         <p>
             <asp:Label ID="Label7" runat="server" Text="性别："></asp:Label>
            &nbsp;<asp:DropDownList ID="drp_student_sex" runat="server" Height="17px" Width="144px">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
&nbsp;</p>
         <p>
             &nbsp;</p>
         <p>
             联系方式：&nbsp; <asp:TextBox ID="txt_student_tel" runat="server"></asp:TextBox>
        &nbsp;</p>
         <p>
             &nbsp;<asp:Label ID="Label10" runat="server" Text="生源地："></asp:Label>
            <asp:TextBox ID="txt_student_place" runat="server"></asp:TextBox>
&nbsp;</p>
         <p>
             &nbsp;<asp:Label ID="Label8" runat="server" Text="密码："></asp:Label>
            <asp:TextBox ID="txt_student_password" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_edit" runat="server" Height="30px" Text="修改" Width="50px" OnClick="btn_edit_Click1" />
&nbsp;
            <asp:Button ID="btn_close" runat="server" Height="30px" Text="取消" Width="50px" OnClick="btn_close_Click" />
        </p>
    </div>
</asp:Content>
