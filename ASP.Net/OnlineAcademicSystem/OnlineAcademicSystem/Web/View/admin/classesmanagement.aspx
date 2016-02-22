<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="classesmanagement.aspx.cs" Inherits="Web.View.admin.classesmanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div1" runat="server">
        <h3>班级信息（<a href="Addclasses.aspx">添加班级信息</a>)</h3>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="class_id" DataSourceID="classes" Width="363px" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="class_id" HeaderText="班级编号" ReadOnly="True" SortExpression="class_id" />
                    <asp:BoundField DataField="major_name" HeaderText="专业" SortExpression="major_name" />
                    <asp:BoundField DataField="grade_name" HeaderText="年级" SortExpression="grade_name" />
                    <asp:BoundField DataField="class_name" HeaderText="班级名称" SortExpression="class_name" />
                    <asp:TemplateField HeaderText="编辑">
                            <ItemTemplate>
                                <asp:Button ID="btn_edit" runat="server" Text="编辑" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
            <asp:SqlDataSource ID="classes" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT classes.class_id, major.major_name, grade.grade_name, classes.class_name FROM classes INNER JOIN grade ON classes.grade_id = grade.grade_id INNER JOIN major ON classes.major_id = major.major_id"></asp:SqlDataSource>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;
            </p>
    </div>
    <div id="div2" runat="server">
        <h4>修改班级</h4>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="班级编号："></asp:Label>
            <asp:TextBox ID="txt_class_id" runat="server" ReadOnly="True"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="所属专业："></asp:Label>
            <asp:DropDownList ID="drp_class_major" runat="server" DataSourceID="classes_major" DataTextField="major_name" DataValueField="major_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="classes_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="所属年级："></asp:Label>
            <asp:DropDownList ID="drp_class_grade" runat="server" DataSourceID="classes_grade" DataTextField="grade_name" DataValueField="grade_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="classes_grade" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [grade]"></asp:SqlDataSource>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="班级名称："></asp:Label>
            <asp:TextBox ID="txt_class_name" runat="server"></asp:TextBox>
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:Button ID="Button1" runat="server" Height="30px" OnClick="Button1_Click" Text="修改" Width="47px" />
&nbsp;<asp:Button ID="Button2" runat="server" Height="30px" OnClick="Button2_Click" Text="取消" Width="46px" />
        </p>
    </div>
</asp:Content>
