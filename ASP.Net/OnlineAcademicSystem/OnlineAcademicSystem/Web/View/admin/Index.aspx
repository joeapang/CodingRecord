<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.View.admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>公告</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataKeyNames="announcement_id" DataSourceID="announcement" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="announcement_id" HeaderText="编号" InsertVisible="False" ReadOnly="True" SortExpression="announcement_id" />
                    <asp:BoundField DataField="announcement_content" HeaderText="内容" SortExpression="announcement_content" />
                    <asp:BoundField DataField="announcement_title" HeaderText="标题" SortExpression="announcement_title" />
                    <asp:BoundField DataField="announcement_attachment" HeaderText="附件" SortExpression="announcement_attachment" />
                    <asp:BoundField DataField="announcement_time" HeaderText="发布时间" SortExpression="announcement_time" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
            <asp:SqlDataSource ID="announcement" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" DeleteCommand="DELETE FROM [announcement] WHERE [announcement_id] = @announcement_id" InsertCommand="INSERT INTO [announcement] ([announcement_content], [announcement_title], [announcement_attachment], [announcement_time]) VALUES (@announcement_content, @announcement_title, @announcement_attachment, @announcement_time)" SelectCommand="SELECT * FROM [announcement]" UpdateCommand="UPDATE [announcement] SET [announcement_content] = @announcement_content, [announcement_title] = @announcement_title, [announcement_attachment] = @announcement_attachment, [announcement_time] = @announcement_time WHERE [announcement_id] = @announcement_id">
                <DeleteParameters>
                    <asp:Parameter Name="announcement_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="announcement_content" Type="String" />
                    <asp:Parameter Name="announcement_title" Type="String" />
                    <asp:Parameter Name="announcement_attachment" Type="String" />
                    <asp:Parameter Name="announcement_time" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="announcement_content" Type="String" />
                    <asp:Parameter Name="announcement_title" Type="String" />
                    <asp:Parameter Name="announcement_attachment" Type="String" />
                    <asp:Parameter Name="announcement_time" Type="String" />
                    <asp:Parameter Name="announcement_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </p>
       
    </div>
</asp:Content>
