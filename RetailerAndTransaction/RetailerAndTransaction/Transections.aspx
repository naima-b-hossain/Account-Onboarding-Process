<%@ Page  Async="true" Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Transections.aspx.cs" Inherits="RetailerAndTransaction.AllTransections" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dashboard">
        <div class="dashboard-left">
            <ul>
                <a href="/UserDashBoard.aspx"><li>Dashboard</li></a>
                <li class="selected">Transections</li>
                <a href="/CreateCustomerForm.aspx"><li>Create Customer</li></a>
                <a href="/AccountCreateForm.aspx"><li>Create Account</li></a>
                <li><asp:Button ID="logout" runat="server" Text="Logout" OnClick="OnClickLogOut"/></li>
            </ul>
        </div>
        <div class="dashboard-right">
            <div class="create-transection">
                <div class="create-form">
                    <table>
                        <tr>
                            <td width="100%" align="center" colspan="5">
                                <h2>
                                     Sender Account Information
                                </h2>
                            </td>
                        </tr>
                        <tr>
                            <td width="50%">
                                <label>Customer Name : </label>
                                <asp:Label ID="txtSenderCustomerName" runat="server"></asp:Label>
                            </td>
                            <td width="50%">
                                <label>Account Balance : </label>
                                <asp:Label ID="txtSenderAccountBalance" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="create-transection">
                <div class="create-form">
                    <table>
                        <tr>
                            <td width="100%" align="center" colspan="5">
                                <h2>
                                    Money Transfer
                                </h2>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                                <label>Sender's Account</label>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="txtSenderAccount" runat="server" AutoPostBack="true" OnTextChanged="txtSenderAccountChangeHandler"></asp:TextBox>
                                <asp:Label ID="txtSenderAccountError" runat="server" class="error_message"></asp:Label>
                            </td>
                            <td width="20%"></td>
                            <td width="15%">
                                <label>Receiver's Account</label>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="txtReceiverAccount" runat="server" AutoPostBack="true" OnTextChanged="txtReceiverAccountChangeHandler" ></asp:TextBox>
                                <asp:Label ID="txtReceiverAccountError" runat="server" class="error_message"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="15%">
                                <label>Transfer Ammount</label>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="txtTransferAmount" runat="server" TextMode="Number" AutoPostBack="true" OnTextChanged="txtTransferAmountChangeHandler"></asp:TextBox>
                                <asp:Label ID="txtTransferAmountError" runat="server" class="error_message"></asp:Label>
                            </td>
                            <td width="20%"></td>
                            <td width="15%">
                                <label>Reference</label>
                            </td>
                            <td width="25%">
                                <asp:TextBox ID="txtReference" runat="server" AutoPostBack="true" OnTextChanged="txtReferenceChangeHandler"></asp:TextBox>
                                <asp:Label ID="txtReferenceError" runat="server" class="error_message"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center" colspan="5">
                                <asp:Button ID="btnSend" runat="server" Text="Send" Type="Button" OnClick="SendButtonClickHandler"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="create-transection">
                <div class="create-form">
                    <table>
                        <tr>
                            <td width="100%" align="center" colspan="5">
                                <h2>
                                     Account Deposit / Wintdraw Information
                                </h2>
                            </td>
                        </tr>
                        <tr>
                            <td width="50%">
                                <label>Customer Name : </label>
                                <asp:Label ID="txtCutomerName" runat="server"></asp:Label>
                            </td>
                            <td width="50%">
                                <label>Account Balance : </label>
                                <asp:Label ID="txtAccountBalance" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="create-transection">
                <div class="create-form">
                    <table>
                        <tr>
                            <td width="100%" align="center" colspan="5">
                                <h2>
                                     Deposite / Withdraw Money
                                </h2>
                            </td>
                        </tr>
                        <tr>
                            <td width="30%">
                                <label>Account No</label>
                                <asp:TextBox ID="txtAccNo" runat="server" AutoPostBack="true" OnTextChanged="txtAccountChangeHandler"></asp:TextBox>
                                <asp:Label ID="txtAccNoError" runat="server" class="error_message"></asp:Label>
                            </td>
                            <td width="30%">
                                <label>Amount</label>
                                <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="true" OnTextChanged="txtAmountChangeHandler"></asp:TextBox>
                                <asp:Label ID="txtAmountError" runat="server" class="error_message"></asp:Label>
                            </td>
                            <td width="25%">
                                <label>Type</label>
                                 <asp:DropDownList ID="drpType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpTypeChangehandler">
                                    <asp:ListItem Value="0">Choose</asp:ListItem>
                                    <asp:ListItem Value="1">Debit</asp:ListItem>
                                    <asp:ListItem Value="2">Credit</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="drpTypeError" runat="server" class="error_message"></asp:Label>
                            </td>
                            <td width="15%">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Type="Button" OnClick="SubmitButtonClickHandler"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="all-transections">
                <h2>All Transaction Records</h2>
                <div width="100%">
                    <label>Account No</label>
                    <asp:TextBox ID="txtAllTranAccNo" runat="server" AutoPostBack="true" OnTextChanged="txtAllTranAccNoChangeHandler"></asp:TextBox>
                    <asp:Label ID="txtAllTranAccNoError" runat="server" class="error_message"></asp:Label>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Type="Button" onClick="SearchButtonClickHandler"/>
                </div><br />
                <asp:GridView ID="gridTransaction" runat="server" Width="100%" AutoGenerateColumns="False" AutoPostBack="True">
                      <Columns>
                          <asp:BoundField DataField="Id" HeaderText="ID" />
                          <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
                          <asp:BoundField DataField="AccountNo" HeaderText="Account NO" />
                          <asp:BoundField DataField="TransactionType" HeaderText="Transaction Type" />
                          <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" />
                          <asp:BoundField DataField="TranAmmount" HeaderText="Transaction Ammount" />
                          <asp:BoundField DataField="Narration" HeaderText="Referencec" />
                          <asp:BoundField DataField="TransactionTo" HeaderText="Transaction With" />
                      </Columns>
                  </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
