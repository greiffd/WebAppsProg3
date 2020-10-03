<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventDisplayPage.aspx.cs" Inherits="Prog3.EventDisplayPage" %>

<%@ MasterType VirtualPath="MasterPage.Master" %>
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
        <asp:BoundField DataField="Event_Name" HeaderText="Event" />  
        <asp:BoundField DataField="Date" HeaderText="Date" /> 
    </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="btnUpdate" runat="server" PostBackUrl="EventUpdatePage.aspx" Text="Update Event" OnClick="btnUpdate_Click" />
</asp:Content>


<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder5">
    <asp:Calendar ID="Calendar2" runat="server" Width="370px" Height="231px" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
</asp:Content>



