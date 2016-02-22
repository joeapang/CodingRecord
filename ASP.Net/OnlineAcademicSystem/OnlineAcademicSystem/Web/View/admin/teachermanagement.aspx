<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="teachermanagement.aspx.cs" Inherits="Web.View.admin.teachermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div1" runat="server">
        <h3>教师信息（<a href="Addteacher.aspx">添加教师信息</a>)</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="teacher_id" DataSourceID="teacher" OnRowDataBound="gridView_RowDataBound" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="teacher_id" HeaderText="教师编号" ReadOnly="True" SortExpression="teacher_id" />
                    <asp:BoundField DataField="teacher_position_name" HeaderText="职称" SortExpression="teacher_position_name" />
                    <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" />
                    <asp:BoundField DataField="teacher_name" HeaderText="姓名" SortExpression="teacher_name" />
<asp:BoundField DataField="teacher_sex" HeaderText="性别" SortExpression="teacher_sex"></asp:BoundField>
                    <asp:BoundField DataField="teacher_tel" HeaderText="联系方式" SortExpression="teacher_tel" />
                     <asp:BoundField DataField="teacher_password" HeaderText="密码" SortExpression="teacher_password" />
                    <asp:TemplateField HeaderText="编辑">
                            <ItemTemplate>
                                <asp:Button ID="btn_edit" runat="server" Text="编辑" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="teacher" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT teacher.teacher_id, teacher_position.teacher_position_name, major.major_name, teacher.teacher_name, teacher.teacher_sex, teacher.teacher_tel, teacher.teacher_password FROM teacher INNER JOIN teacher_position ON teacher.teacher_position_id = teacher_position.teacher_position_id INNER JOIN major ON teacher.major_id = major.major_id"></asp:SqlDataSource>
        </p>
    </div>

    <div id="div2" runat="server">
        <h3>修改老师信息</h3>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="老师编号："></asp:Label>
            &nbsp;<asp:TextBox ID="txt_teacher_id" runat="server" ReadOnly="True"></asp:TextBox>
&nbsp;<asp:Label ID="Label4" runat="server" Text="职称："></asp:Label>
            <asp:DropDownList ID="drp_teacher_position" runat="server" DataSourceID="teacher_position" DataTextField="teacher_position_name" DataValueField="teacher_position_id" Height="17px" Width="144px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="teacher_position" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [teacher_position]"></asp:SqlDataSource>
&nbsp;<asp:Label ID="Label5" runat="server" Text="所属专业："></asp:Label>
            <asp:DropDownList ID="drp_teacher_major" runat="server" DataSourceID="teacher_major" DataTextField="major_name" DataValueField="major_id" Height="17px" Width="144px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="teacher_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="姓名："></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txt_teacher_name" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label7" runat="server" Text="性别："></asp:Label>
            <asp:DropDownList ID="drp_teacher_sex" runat="server" Height="17px" Width="144px">
                <asp:ListItem>男</asp:ListItem>
                <asp:ListItem>女</asp:ListItem>
            </asp:DropDownList>
&nbsp;联系方式：<asp:TextBox ID="txt_teacher_tel" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="密码："></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txt_teacher_password" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_edit" runat="server" Height="30px" Text="修改" Width="50px" OnClick="btn_edit_Click1" />
&nbsp;
            <asp:Button ID="btn_close" runat="server" Height="30px" Text="取消" Width="50px" OnClick="btn_close_Click" />
        </p>
    </div>
</asp:Content>
