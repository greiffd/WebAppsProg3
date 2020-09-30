﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventUpdatePage.aspx.cs" Inherits="Prog3.EventUpdatePage" %>

<%@ PreviousPageType VirtualPath="~/EventDisplayPage.aspx" %>

<%--<script runat="server">
    protected void Page_Load(Object s, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.IsCrossPagePostBack/*!IsPostBack*/)
        {
            lblEventName = (Label)Page.PreviousPage.FindControl("lblEventName");
        }
        else
        {
            lblEventName.Text = "Not postback";
        }

    }
</script>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblUpdatedName" runat="server" Text="No Event" Enabled="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
<br />
</asp:Content>
<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <p>
        <asp:Label ID="lblName" runat="server" Text="Event Name:"></asp:Label>
<asp:TextBox ID="txtEventName" runat="server" Height="25px" ToolTip="Event Name" Width="173px"></asp:TextBox>
    </p>
    <p>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEventName" ErrorMessage="Please enter an event name"></asp:RequiredFieldValidator>
    </p>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="ContentPlaceHolder4">
    <p>
<asp:Button ID="btnUpdate" runat="server" Text="Update Event" OnClick="btnUpdate_Click" PostBackUrl="EventDisplayPage.aspx" />
</p>
</asp:Content>
