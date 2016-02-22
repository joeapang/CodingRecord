<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.View.teacher.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div id="div1" runat="server">
    <h3>公告</h3>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="announcement_id" DataSourceID="announcement" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="announcement_id" HeaderText="编号" InsertVisible="False" ReadOnly="True" SortExpression="announcement_id" />
                    <asp:BoundField DataField="announcement_title" HeaderText="标题" SortExpression="announcement_title" />
                    <asp:BoundField DataField="announcement_time" HeaderText="发布时间" SortExpression="announcement_time" />
                    <asp:TemplateField HeaderText="查看">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" Text="查看" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="announcement" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT [announcement_id], [announcement_title], [announcement_time] FROM [announcement]"></asp:SqlDataSource>
        </p>
    </div>
    <div id="div2" runat="server">
        <h4 style="text-align:center">公告<asp:Label ID="announcement_id" runat="server" Text="Label"></asp:Label></h4>
        <asp:Label ID="Label1" runat="server" Text="标题："></asp:Label>
        <asp:Label ID="txt_announcement_title" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="内容："></asp:Label>
        <asp:Label ID="txt_announcement_coent" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="附件："></asp:Label>

        <asp:Label ID="txt_announcement_attachment" runat="server" Text="Label" Visible="False"></asp:Label>

        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="下载附件" />
&nbsp;</div>
</asp:Content>
