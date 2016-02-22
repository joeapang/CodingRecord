<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="classroommanagement.aspx.cs" Inherits="Web.View.admin.classroommanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>教室信息（<a href="Addclassroom.aspx">添加教室信息</a>)</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="classroom_id" DataSourceID="classroom" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="classroom_id" HeaderText="教室ID" ReadOnly="True" SortExpression="classroom_id" />
                    <asp:BoundField DataField="classroom_name" HeaderText="教室名称" SortExpression="classroom_name" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" Text="删除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="classroom" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" DeleteCommand="DELETE FROM [classroom] WHERE [classroom_id] = @classroom_id" InsertCommand="INSERT INTO [classroom] ([classroom_id], [classroom_name]) VALUES (@classroom_id, @classroom_name)" SelectCommand="SELECT * FROM [classroom]" UpdateCommand="UPDATE [classroom] SET [classroom_name] = @classroom_name WHERE [classroom_id] = @classroom_id">
                <DeleteParameters>
                    <asp:Parameter Name="classroom_id" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="classroom_id" Type="String" />
                    <asp:Parameter Name="classroom_name" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="classroom_name" Type="String" />
                    <asp:Parameter Name="classroom_id" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
