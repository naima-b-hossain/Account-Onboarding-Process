<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserDashBoard.aspx.cs" Inherits="RetailerAndTransaction.UserDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dashboard">
        <div class="dashboard-left">
            <ul>
                <li class="selected">Dashboard</li>
                <a href="/Transections.aspx"><li>Transections</li></a>
                <a href="/CreateCustomerForm.aspx"><li>Create Customer</li></a>
                <a href="/AccountCreateForm.aspx"><li>Create Account</li></a>
                <li><asp:Button ID="logout" runat="server" Text="Logout" OnClick="OnClickLogOut"/></li>
            </ul>
        </div>
        <div class="dashboard-right">
            <div class="all-accounts">
                <h2>Search By NID / Phone</h2>
                <div>
                     <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" OnTextChanged="SearchTextChangeHandler"></asp:TextBox>
                     <asp:Label ID="txtSearchError" runat="server" class="error_message"></asp:Label>
                     <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="SearchButtonClickHandler"/>
                </div>
            </div>
            <div class="all-accounts">
                <h2>All Accounts Info</h2>
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" AutoPostBack="True">
                      <Columns>
                          <asp:BoundField DataField="Id" HeaderText="ID" />
                          <asp:BoundField DataField="AccountNo" HeaderText="Account No" />
                          <asp:BoundField DataField="CustomerId" HeaderText="Customer ID" />
                          <asp:BoundField DataField="ProductType" HeaderText="Product Name" />
                          <asp:BoundField DataField="SubProductType" HeaderText="Sub-Product Name" />
                          <asp:BoundField DataField="Balance" HeaderText="Account Balance" />
                          <asp:BoundField DataField="AccCreatedDate" HeaderText="Account Created Date" />
                          <asp:BoundField DataField="AccStatus" HeaderText="Account Status" />
                      </Columns>
                  </asp:GridView>
            </div><br /><br />
            <div class="all-accounts">
                <table>
                    <tr>
                        <td width="100%" align="center" colspan="5">
                            <h3 class="create_customer_form_label">
                                Customer Information
                            </h3>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <label>Name</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtName" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="10%"></td>
                        <td width="20%">
                            <label>Gender</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpgender" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Father's Name</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtFathersName" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td  width="15%">
                            <label>Mother's Name</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtMothersName" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>NID</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtNid" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Date Of Birth</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtDob" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
 
                    </tr>


                     <tr>
                        <td width="15%">
                            <label>Religion</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpReligion" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>

                         <td width="20%"></td>

                         <td width="15%">
                            <label>Occupation</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpOccupation" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Monthly Income</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtMonthlyIncome" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Phone No</label>
                        </td>
                        <td width="25%">
                           : <asp:Label ID="txtPhoneNo" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Permanent Address</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtPerAdd" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>

                         <td width="20%"></td>

                        <td width="15%">
                            <label>Permanent Division</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpPerDivision" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Permanent District</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpPerDistrict" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Permanent Thana</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtPerThana" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Permanent PostalCode</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtPerPostCode" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                         <td width="20%"></td>
                         <td width="15%">
                            <label>Present Address</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtPreAdd" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Present Divison</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpPreDivision" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Present District</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpPreDistrict" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Present Thana</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtPreThana" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Present PostalCode</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtPrePostalCode" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Communication Address</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtComAdd" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>

                          <td width="20%"></td>

                         <td width="15%">
                            <label>Communication Division</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpComDivision" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Communication District</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpComDistrict" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Communication Thana</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtComThana" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Communication PostalCode</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="txtComPostalCode" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>

                         <td width="20%"></td>

                        <td width="15%">
                            <label>RM Name</label>
                        </td>
                        <td width="25%">
                            : <asp:Label ID="drpCusOpenBy" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
