<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventUpdatePage.aspx.cs" Inherits="Prog3.EventUpdatePage" %>

<%@ PreviousPageType VirtualPath="~/EventDisplayPage.aspx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblDateSelected" runat="server" Text="No Event" Enabled="False"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
<br />
    <asp:Calendar ID="Calendar1" runat="server" Visible="False"></asp:Calendar>
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
<asp:Button ID="btnCreate" runat="server" Text="Create Event" OnClick="btnCreate_Click" />
        <asp:Button ID="btnUpdate" runat="server" Enabled="False" OnClick="btnUpdate_Click" Text="Update" />
        <asp:Button ID="btnDelete" runat="server" Enabled="False" OnClick="btnDelete_Click" Text="Delete" />
</p>
</asp:Content>

<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHolder5">
    <asp:GridView ID="GridView1" runat="server" Height="176px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="278px" AutoGenerateSelectButton="True">
    </asp:GridView>
</asp:Content>


