<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="choose_course.aspx.cs" Inherits="Web.View.student.choose_course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <h3>选课</h3>
        <p>&nbsp;&nbsp;</p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="查询条件"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="专业"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="年级"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="课程类型"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="drp_tiaojian" runat="server" Height="16px" Width="146px">
                <asp:ListItem>全部</asp:ListItem>
                <asp:ListItem>符合右边条件</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="drp_major" runat="server" Height="16px" Width="146px" DataSourceID="choosecourse_major" DataTextField="major_name" DataValueField="major_id">
                <asp:ListItem Value="null"></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="choosecourse_major" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [major]"></asp:SqlDataSource>
            <asp:DropDownList ID="drp_grade" runat="server" Height="16px" Width="146px" DataSourceID="choosecourse_grade" DataTextField="grade_name" DataValueField="grade_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="choosecourse_grade" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [grade]"></asp:SqlDataSource>
            <asp:DropDownList ID="drp_type" runat="server" Height="16px" Width="146px" DataSourceID="choosecourse_type" DataTextField="course_type_name" DataValueField="course_type_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="choosecourse_type" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT * FROM [course_type]"></asp:SqlDataSource>
&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" style="height: 21px" />
        </p>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="课程编号" ReadOnly="True" SortExpression="course_id" />
                    <asp:BoundField DataField="course_name" HeaderText="课程名称" SortExpression="course_name" />
                    <asp:BoundField DataField="course_time" HeaderText="上课时间" SortExpression="course_time" />
                    <asp:TemplateField HeaderText="选课">
                            <ItemTemplate>
                                <asp:Button ID="Button2" runat="server" Text="选择" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="choosecourse" runat="server" ConnectionString="<%$ ConnectionStrings:OnlineAcademicConnectionString %>" SelectCommand="SELECT [course_id], [course_name], [course_time] FROM [course]"></asp:SqlDataSource>
        </p>
    </div>
</asp:Content>
