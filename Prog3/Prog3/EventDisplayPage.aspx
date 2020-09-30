<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventDisplayPage.aspx.cs" Inherits="Prog3.EventDisplayPage" %>


<%--<script runat="server">
    protected void Page_Load(Object s, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblEventName.Text = "Event Here";
        }
        else
        {
            Page previousPage = Page.PreviousPage;
            if (previousPage != null)
            {
                lblEventName = (Label)Page.PreviousPage.FindControl("lblEventName");
            }
        }
        
        Calendar  calendar = (Calendar)Master.FindControl("Calendar1");
        lblEventName.Text = calendar.SelectedDate.ToShortDateString();
        

    }
</script>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblEventName" runat="server" Text="No Event"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Date], [Event_Description], [Event_Name] FROM [Table]"></asp:SqlDataSource>
    <asp:Button ID="btnUpdate" runat="server" PostBackUrl="EventUpdatePage.aspx" Text="Update Event" />
</asp:Content>


