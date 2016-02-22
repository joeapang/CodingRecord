<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="teacher_positionmanagement.aspx.cs" Inherits="Web.View.admin.teacher_positionmanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>教师职称（<a href="Addteacher_position.aspx">添加教师职称</a>)</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="teacher_position_id" DataSourceID="teacher_position" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="teacher_position_id" HeaderText="教师职称编号" ReadOnly="True" SortExpression="teacher_position_id" />
                    <asp:BoundField DataField="teacher_position_name" HeaderText="教师职称名称" SortExpression="teacher_position_name" />
                    <asp:CommandField ShowEditButton="True" HeaderText="编辑" />
                    <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" Text="删除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="teacher_position" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" DeleteCommand="DELETE FROM [teacher_position] WHERE [teacher_position_id] = @teacher_position_id" InsertCommand="INSERT INTO [teacher_position] ([teacher_position_id], [teacher_position_name]) VALUES (@teacher_position_id, @teacher_position_name)" SelectCommand="SELECT * FROM [teacher_position]" UpdateCommand="UPDATE [teacher_position] SET [teacher_position_name] = @teacher_position_name WHERE [teacher_position_id] = @teacher_position_id">
                <DeleteParameters>
                    <asp:Parameter Name="teacher_position_id" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="teacher_position_id" Type="String" />
                    <asp:Parameter Name="teacher_position_name" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="teacher_position_name" Type="String" />
                    <asp:Parameter Name="teacher_position_id" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
