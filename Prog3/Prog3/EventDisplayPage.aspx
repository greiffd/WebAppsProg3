<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventDisplayPage.aspx.cs" Inherits="Prog3.EventDisplayPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .CustomCellCss
        {
            background-color: orange;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblDate" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="366px">
        <Columns>
        <asp:BoundField DataField="Event_Name" HeaderText="Event" />  
        <%--<asp:BoundField DataField="Date" HeaderText="Date" />--%> 
    </Columns>
    </asp:GridView>
    <asp:Button ID="btnUpdate" runat="server" PostBackUrl="~/EventUpdatePage.aspx" Text="Update Event" />
</asp:Content>


<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder5">
    <asp:Calendar ID="Calendar2" runat="server" Width="370px" Height="231px" OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender1">
        
            
        </asp:Calendar>
</asp:Content>



