<%@ Page Async="true" Title="Create A New Customer" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateCustomerForm.aspx.cs" Inherits="RetailerAndTransaction.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/CreateCustomerForm.css" rel="stylesheet" />
    <link href="css/Dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dashboard">
        <div class="dashboard-left">
            <ul>
                <a href="/UserDashBoard.aspx"><li>Dashboard</li></a>
                <a href="/Transections.aspx"><li>Transections</li></a>
                <li class="selected">Create Customer</li>
                <a href="/AccountCreateForm.aspx"><li>Create Account</li></a>
                <li><asp:Button ID="logout" runat="server" Text="Logout" OnClick="OnClickLogOut"/></li>
            </ul>
        </div>
        <div class="dashboard-right">
        <div class="create_customer_form">
            <div class="create_customer_form_fields">
                <table>
                    <tr>
                        <td width="100%" align="center" colspan="5">
                            <div class="create_customer_form_label">
                                Create A New Customer
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Name</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" OnTextChanged="nameChangehandler"></asp:TextBox>
                            <asp:Label ID="txtNameError" runat="server" class="error_message"></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Gender</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpgender" runat="server" AutoPostBack="True" OnSelectedIndexChanged="genderChangehandler">
                                <asp:ListItem Value="0">Choose</asp:ListItem>
                                <asp:ListItem Value="M">Male</asp:ListItem>
                                <asp:ListItem Value="F">Female</asp:ListItem>
                                <asp:ListItem Value="O">Other</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpgenderError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Father's Name</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtFathersName" runat="server" AutoPostBack="True" OnTextChanged="txtFathersNameChangehandler"></asp:TextBox>
                            <asp:Label ID="txtFathersNameError" runat="server" class="error_message"></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td  width="15%">
                            <label>Mother's Name</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtMothersName" runat="server"  AutoPostBack="True" OnTextChanged="txtMothersNameChangehandler"></asp:TextBox>
                            <asp:Label ID="txtMothersNameError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>NID</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtNid" runat="server" AutoPostBack="True" OnTextChanged="txtNidChangehandler"></asp:TextBox>
                            <asp:Label ID="txtNidError" runat="server" class="error_message"></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Date Of Birth</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtDob" runat="server" TextMode="Date" Width="168px" AutoPostBack="True" OnTextChanged="txtDobChangehandler"></asp:TextBox> 
                             <asp:Label ID="txtDobError" runat="server" class="error_message"></asp:Label>
                        </td>
 
                    </tr>


                     <tr>
                        <td width="15%">
                            <label>Religion</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpReligion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="religionChangehandler">
                                <asp:ListItem Value="0">Choose</asp:ListItem>
                                <asp:ListItem Value="101">Islam</asp:ListItem>
                                <asp:ListItem Value="102">Hinduism</asp:ListItem>
                                <asp:ListItem Value="103">Chrishtian</asp:ListItem>
                                <asp:ListItem Value="104">Buddhism</asp:ListItem>
                            </asp:DropDownList>
                             <asp:Label ID="drpReligionError" runat="server" class="error_message"></asp:Label>
                        </td>

                         <td width="20%"></td>

                         <td width="15%">
                            <label>Occupation</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpOccupation" runat="server" AutoPostBack="True" OnSelectedIndexChanged="occupationChangehandler">
                                <asp:ListItem Value="0">Choose</asp:ListItem>
                                <asp:ListItem Value="201">Service Holder</asp:ListItem>
                                <asp:ListItem Value="202">Business</asp:ListItem>
                                <asp:ListItem Value="203">House Maker</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpOccupationError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Monthly Income</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtMonthlyIncome" runat="server" AutoPostBack="True" OnTextChanged="txtMonthlyIncomeChangehandler"></asp:TextBox>
                            <asp:Label ID="txtMonthlyIncomeError" runat="server" class="error_message"></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Phone No</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtPhoneNo" runat="server" AutoPostBack="True" OnTextChanged="txtPhoneNoChangehandler"></asp:TextBox>
                            <asp:Label ID="txtPhoneNoError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Permanent Address</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtPerAdd" runat="server" AutoPostBack="True" OnTextChanged="txtPerAddChangehandler"></asp:TextBox>
                             <asp:Label ID="txtPerAddError" runat="server" class="error_message"></asp:Label>
                        </td>

                         <td width="20%"></td>

                        <td width="15%">
                            <label>Permanent Division</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpPerDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPerDivisionChangehandler">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                
                            </asp:DropDownList>
                             <asp:Label ID="drpPerDivisionError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Permanent District</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpPerDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPerDistrictChangehandler">
                                <asp:ListItem Value="0">Select Permanent Division</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpPerDistrictError" runat="server" class="error_message"></asp:Label>
                        </td>
                        <td width="20%"></td>
                        <td width="15%">
                            <label>Permanent Thana</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpPerThana" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPerThanaChangehandler">
                                <asp:ListItem Value="0">Select Permanent District</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpPerThanaError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Permanent PostalCode</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtPerPostCode" runat="server" AutoPostBack="True" OnTextChanged="txtPerPostCodeChangehandler"></asp:TextBox>
                            <asp:Label ID="txtPerPostCodeError" runat="server" class="error_message"></asp:Label>
                        </td>
                         <td width="20%"></td>
                         <td width="15%">
                            <label>Present Address</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtPreAdd" runat="server" AutoPostBack="True" OnTextChanged="txtPreAddChangehandler"></asp:TextBox>
                            <asp:Label ID="txtPreAddError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Present Divison</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpPreDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPreDivisionChangehandler">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpPreDivisionError" runat="server" class="error_message"></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Present District</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpPreDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPreDistrictChangehandler">
                                <asp:ListItem Value="0">Select Present Division</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpPreDistrictError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Present Thana</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpPreThana" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpPreThanaChangehandler">
                                <asp:ListItem Value="0">Select Permanent District</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpPreThanaError" runat="server" class="error_message"></asp:Label>

                        </td>

                          <td width="20%"></td>

                         <td width="15%">
                            <label>Present PostalCode</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtPrePostalCode" runat="server" AutoPostBack="True" OnTextChanged="txtPrePostalCodeChangehandler"></asp:TextBox>
                             <asp:Label ID="txtPrePostalCodeError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Communication Address</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtComAdd" runat="server" AutoPostBack="True" OnTextChanged="txtComAddChangehandler"></asp:TextBox>
                             <asp:Label ID="txtComAddError" runat="server" class="error_message"></asp:Label>
                        </td>

                          <td width="20%"></td>

                         <td width="15%">
                            <label>Communication Division</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpComDivision" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpComDivisionChangehandler">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpComDivisionError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td width="15%">
                            <label>Communication District</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpComDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpComDistrictChangehandler">
                                <asp:ListItem Value="0">Select Communication Division</asp:ListItem>
                            </asp:DropDownList>
                             <asp:Label ID="drpComDistrictError" runat="server" class="error_message"></asp:Label>
                        </td>
                          <td width="20%"></td>
                         <td width="15%">
                            <label>Communication Thana</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpComThana" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpComThanaChangehandler">
                                <asp:ListItem Value="0">Select Permanent District</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpComThanaError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">
                            <label>Communication PostalCode</label>
                        </td>
                        <td width="25%">
                            <asp:TextBox ID="txtComPostalCode" runat="server" AutoPostBack="True" OnTextChanged="txtComPostalCodeChangehandler"></asp:TextBox>
                            <asp:Label ID="txtComPostalCodeError" runat="server" class="error_message"></asp:Label>
                        </td>

                         <td width="20%"></td>

                        <td width="15%">
                            <label>RM Name</label>
                        </td>
                        <td width="25%">
                            <asp:DropDownList ID="drpCusOpenBy" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpCusOpenByChangehandler"  >
                                <asp:ListItem  Value="0">Choose</asp:ListItem>
                            </asp:DropDownList>
                            <asp:Label ID="drpCusOpenByError" runat="server" class="error_message"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" align="center" colspan="5">
                            <asp:Button ID="btnSave" runat="server" Text="Save" Type="Button" OnClick="SaveButtonClickHandler"/>
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        </div>
     </div>

</asp:Content>
