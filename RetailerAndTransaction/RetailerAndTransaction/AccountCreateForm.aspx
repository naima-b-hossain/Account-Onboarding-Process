<%@ Page Async="true"  Title="Create A New Account" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AccountCreateForm.aspx.cs" Inherits="RetailerAndTransaction.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/AccountCreateForm.css" rel="stylesheet" />
    <link href="css/Dashboard.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="dashboard">
        <div class="dashboard-left">
            <ul>
                <a href="/UserDashBoard.aspx"><li>Dashboard</li></a>
                <a href="/Transections.aspx"><li>Transections</li></a>
                <a href="/CreateCustomerForm.aspx"><li>Create Customer</li></a>
                <li class="selected">Create Account</li>
                <li><asp:Button ID="logout" runat="server" Text="Logout" OnClick="OnClickLogOut"/></li>
                
            </ul>
        </div>
        <div class="dashboard-right">
        <div class="account_create_form">
            <div class="account_create_form_fields">
                <table>
                    <tr>
                        <td width="100%" align="center" colspan="5">
                            <div class="account_create_form_label">
                                Create A New Account
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Customer ID</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtCustomerId"  runat="server" AutoPostBack="True" OnTextChanged="txtIdChangehandler"></asp:TextBox>
                             <asp:Label ID="txtCustomerIdError" runat="server" class="error_message"></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Product Name</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpProductType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="productTypeChangehandler">
                                <asp:ListItem  Value="0">Choose</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpProductTypeError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            
                        </td>
                        <td width="25%">

                            
                        </td>


                        <td width="20%"></td>
                        <td width="15%">
                            <label>Branch Code</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpBranchCode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="branchCodeChangehandler">
                                <asp:ListItem Value="0">Choose</asp:ListItem>
                                <asp:ListItem Value="300">MTB Centre - 300</asp:ListItem>
                                <asp:ListItem Value="301">MTB Tower - 301</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpBranchCodeError" runat="server" class="error_message"></asp:Label>
                        </td>
                        
                    </tr>

                     <tr>
                        <td width="15%">
                          <label>Sub-Product Name</label>  
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpSubProduct" runat="server" AutoPostBack="True" OnSelectedIndexChanged="subProductChangehandler" >
                                <asp:ListItem  Value="0">Choose</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpSubProductError" runat="server" class="error_message"></asp:Label>
                        </td>


                        <td width="20%"></td>
                        <td width="15%">
                            <label>RM Name</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpAccOpenBy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="accOpenByChangehandler" >
                                <asp:ListItem Value="0">Choose</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpAccOpenByError" runat="server" class="error_message"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td width="100%" align="center" colspan="5">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="SaveButton_ClickHandler"/>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td width="100%" align="center" colspan="5">
                            <div class="create_customer_form_label">
                                Selected Customer Information
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Name</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtName" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Gender</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpgender" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Father's Name</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtFathersName" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td  width="15%">
                            <label>Mother's Name</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtMothersName" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>NID</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtNid" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Date Of Birth</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtDob" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
 
                    </tr>


                     <tr>
                        <td width="15%">
                            <label>Religion</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpReligion" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>

                         <td width="20%"></td>

                         <td width="15%">
                            <label>Occupation</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpOccupation" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Monthly Income</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtMonthlyIncome" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Phone No</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtPhoneNo" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Permanent Address</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtPerAdd" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>

                         <td width="20%"></td>

                        <td width="15%">
                            <label>Permanent Division</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpPerDivision" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Permanent District</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpPerDistrict" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Permanent Thana</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtPerThana" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Permanent PostalCode</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtPerPostCode" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                         <td width="20%"></td>
                         <td width="15%">
                            <label>Present Address</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtPreAdd" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Present Divison</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpPreDivision" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Present District</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpPreDistrict" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Present Thana</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtPreThana" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Present PostalCode</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtPrePostalCode" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Communication Address</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtComAdd" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>

                          <td width="20%"></td>

                         <td width="15%">
                            <label>Communication Division</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpComDivision" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Communication District</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpComDistrict" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Communication Thana</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtComThana" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Communication PostalCode</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtComPostalCode" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>

                         <td width="20%"></td>

                        <td width="15%">
                            <label>RM Name</label>
                        </td>
                        <td width="25%">
                            <asp:Label ID="drpCusOpenBy" runat="server" AutoPostBack="True" ></asp:Label>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
        </div>
    </div>





</asp:Content>
