<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="query_choose_course.aspx.cs" Inherits="Web.View.student.query_choose_course" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <h4>已选课程</h4>
        <p>&nbsp;</p>
        <p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="课程编号" ReadOnly="True" SortExpression="course_id" />
                    <asp:BoundField DataField="course_name" HeaderText="课程名称" SortExpression="course_name" />
                    <asp:BoundField DataField="course_time" HeaderText="上课时间" SortExpression="course_time" />
                     <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" Text="删除" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </p>
    </div>
</asp:Content>
