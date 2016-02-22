<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="majormanagement.aspx.cs" Inherits="Web.View.admin.majormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:auto;">
        <h3>学院信息(<a href="Addmajor.aspx">添加学院信息</a>)</h3>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="major_id" DataSourceID="major" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="major_id" HeaderText="学院编号" ReadOnly="True" SortExpression="major_id" />
                    <asp:BoundField DataField="major_name" HeaderText="学院名称" SortExpression="major_name" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" Text="删除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" DeleteCommand="DELETE FROM [major] WHERE [major_id] = @major_id" InsertCommand="INSERT INTO [major] ([major_id], [major_name]) VALUES (@major_id, @major_name)" SelectCommand="SELECT * FROM [major]" UpdateCommand="UPDATE [major] SET [major_name] = @major_name WHERE [major_id] = @major_id">
                <DeleteParameters>
                    <asp:Parameter Name="major_id" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="major_id" Type="String" />
                    <asp:Parameter Name="major_name" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="major_name" Type="String" />
                    <asp:Parameter Name="major_id" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
