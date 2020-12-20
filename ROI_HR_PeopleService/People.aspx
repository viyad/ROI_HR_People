<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="People.aspx.cs" Inherits="ROI_HR_PeopleService.People" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Xml ID="Xml1" runat="server"></asp:Xml>

    <table class="small-table">
        <tr>
            <th>Id</th>
            <td><asp:TextBox ID="txtId" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Name</th>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Phone</th>
            <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Department</th>
            <td><asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Street</th>
            <td><asp:TextBox ID="txtStreet" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>City</th>
            <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>State</th>
            <td><asp:TextBox ID="txtState" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Zip</th>
            <td><asp:TextBox ID="txtZip" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>country</th>
            <td><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnFind_Click" />
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
