<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="grademanagement.aspx.cs" Inherits="Web.View.admin.grademanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:auto">
        <h4>年级信息（<a href="Addgrade.aspx">添加年级信息</a>)</h4>
        <p>&nbsp;</p>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="grade_id" DataSourceID="grade" OnRowCreated="GridView1_RowCreated">
            <Columns>
                <asp:BoundField DataField="grade_id" HeaderText="年级编号" ReadOnly="True" SortExpression="grade_id" />
                <asp:BoundField DataField="grade_name" HeaderText="年级名称" SortExpression="grade_name" />
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:Button ID="btn_delete" runat="server" Text="删除" />
                            </ItemTemplate>
                        </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="grade" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" DeleteCommand="DELETE FROM [grade] WHERE [grade_id] = @grade_id" InsertCommand="INSERT INTO [grade] ([grade_id], [grade_name]) VALUES (@grade_id, @grade_name)" SelectCommand="SELECT * FROM [grade]" UpdateCommand="UPDATE [grade] SET [grade_name] = @grade_name WHERE [grade_id] = @grade_id">
            <DeleteParameters>
                <asp:Parameter Name="grade_id" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="grade_id" Type="String" />
                <asp:Parameter Name="grade_name" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="grade_name" Type="String" />
                <asp:Parameter Name="grade_id" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />

    </div>
</asp:Content>
