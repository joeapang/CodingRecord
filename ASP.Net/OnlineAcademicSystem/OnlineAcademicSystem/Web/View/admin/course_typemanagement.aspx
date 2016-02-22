<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="course_typemanagement.aspx.cs" Inherits="Web.View.admin.course_typemanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>课程类型(<a href="Addcourse_type.aspx">添加课程类型</a>)</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="course_type_id" DataSourceID="course_type" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="course_type_id" HeaderText="课程类型编号" ReadOnly="True" SortExpression="course_type_id" />
                    <asp:BoundField DataField="course_type_name" HeaderText="课程类型名称" SortExpression="course_type_name" />
                    <asp:CommandField ShowEditButton="True" HeaderText="编辑" />
                    <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" Text="删除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="course_type" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" DeleteCommand="DELETE FROM [course_type] WHERE [course_type_id] = @course_type_id" InsertCommand="INSERT INTO [course_type] ([course_type_id], [course_type_name]) VALUES (@course_type_id, @course_type_name)" SelectCommand="SELECT * FROM [course_type]" UpdateCommand="UPDATE [course_type] SET [course_type_name] = @course_type_name WHERE [course_type_id] = @course_type_id">
                <DeleteParameters>
                    <asp:Parameter Name="course_type_id" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="course_type_id" Type="String" />
                    <asp:Parameter Name="course_type_name" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="course_type_name" Type="String" />
                    <asp:Parameter Name="course_type_id" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
