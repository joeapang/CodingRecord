<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="delete_teacher.aspx.cs" Inherits="Web.View.admin.delete_teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>删除教师</h3>
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
                    <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" Text="删除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="teacher" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT teacher.teacher_id, teacher_position.teacher_position_name, major.major_name, teacher.teacher_name, teacher.teacher_sex, teacher.teacher_tel, teacher.teacher_password FROM teacher INNER JOIN teacher_position ON teacher.teacher_position_id = teacher_position.teacher_position_id INNER JOIN major ON teacher.major_id = major.major_id"></asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
