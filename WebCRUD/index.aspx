<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebCRUD.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="indexstyle.css" rel="stylesheet" />
</head>
<body>
    <form  runat="server">
        <div class="data">
            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtCustomerName" runat="server" CssClass="input" placeholder="Name"></asp:TextBox>
            <asp:Label ID="lblAge" runat="server" Text="Age" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtAge" runat="server" CssClass="input" placeholder="Age"></asp:TextBox>
            <asp:Label ID="lblAdress" runat="server" Text="Adress" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtAdress" runat="server" CssClass="input" placeholder="Adress"></asp:TextBox>
            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input" placeholder="Email"></asp:TextBox>
            <asp:Button ID="btnInsert" runat="server" CssClass="buttonins" Text="Insert" OnClick="btnInsert_Click"/>
            <asp:Button ID="btnReset" runat="server" CssClass="buttonres" Text="Reset" Onclick="btnReset_Click"/>
        </div>
            <asp:Label ID="lblShow" runat="server" Text="" CssClass="lblShow"></asp:Label>
        <asp:GridView ID="grdCustomer" CssClass="grdCustomer" runat="server" AutoGenerateColumns="False"  DataKeyNames="ID" GridLines="None" OnRowCancelingEdit="grdCustomer_RowCancelingEdit" OnRowDeleting="grdCustomer_RowDeleting" OnRowEditing="grdCustomer_RowEditing" OnRowUpdating="grdCustomer_RowUpdating">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Customer_ID" ReadOnly="True" />
                <asp:BoundField DataField="CustomerName" HeaderText="Cust_Name" />
                <asp:BoundField DataField="Age" HeaderText="Cust_Age" />
                <asp:BoundField DataField="Adress" HeaderText="Cust_Adress" />
                <asp:BoundField DataField="Email" HeaderText="Cust_Email" />
                <asp:CommandField ButtonType="Button" ShowEditButton="True">
                <ControlStyle BackColor="#00CC00" ForeColor="White" />
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True">
                    <ControlStyle BackColor="#CC0000" ForeColor="White" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
