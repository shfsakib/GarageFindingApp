<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="all-user-charge-list.aspx.cs" Inherits="GarageFindingApp.user.all_user_charge_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Monthly Charge List</h1>
    </section>
    <div class="row pad-all">
        <div class="col-12 col-md-12 align-items-center">
            <div class="col-xs-5 col-md-3" style="margin: 0; padding: 0 0 0 15px;">
                <asp:DropDownList ID="ddlStatus" class="form-controls" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_OnSelectedIndexChanged" runat="server">
                    <asp:ListItem Value="I">Inactive</asp:ListItem>
                    <asp:ListItem Value="A">Active</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-7 col-md-5" style="margin: 0; padding: 0 15px 0 5px;">
                <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" autocomplete="off" OnTextChanged="txtSearch_OnTextChanged" class="form-controls monY" placeholder="mmm-yy"></asp:TextBox>
            </div>
            <div class="col-xs-12 col-md-4" style="margin: 0; padding: 5px 15px 0 15px;">
                <asp:LinkButton ID="lnkSearch" class="btn btn-warning wd" runat="server">Search</asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-12 col-md-12">
                <div class="table-responsive" style="border: none;">
                    <asp:GridView ID="gridCharge" Width="100%" class="table table-hover table-bordered table-striped" Style="background: #ededfb;" OnRowDataBound="gridCharge_OnRowDataBound" OnPageIndexChanging="gridCharge_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Payment Found" AllowPaging="True" PageSize="20" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="Garage_Name">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("ChargeId")%>' />
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("GarageName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Month">
                                <ItemTemplate>
                                    <asp:Label ID="Label31" runat="server" Text='<%#Eval("Month")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bkash_No">
                                <ItemTemplate>
                                    <asp:Label ID="Label41" runat="server" Text='<%#Eval("BkashNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction_No">
                                <ItemTemplate>
                                    <asp:Label ID="Label51" runat="server" Text='<%#Eval("TransactionNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="Label81" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payment_Time">
                                <ItemTemplate>
                                    <asp:Label ID="Label91" runat="server" Text='<%#Eval("PaymentTime")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbkActive" class="btn btn-success" OnClick="lbkActive_OnClick" runat="server" ToolTip="Accept"><i class="fas fa-check fa-lg"></i>&nbsp;Accept</asp:LinkButton>
                                    <asp:LinkButton ID="lnkRemove" class="btn btn-danger mt2" OnClick="lnkRemove_OnClick" runat="server" ToolTip="Remove"><i class="fas fa-trash-alt fa-lg"></i>&nbsp;Remove</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(document).ready(function () {
            $(".monY").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1901:2099',
                dateFormat: 'M-y',
                showButtonPanel: true,
                onClose: function (dateText, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).val($.datepicker.formatDate('M-y', new Date(year, month, 1)));
                }
            });
            $(".monY").focus(function () {
                $(".ui-datepicker-calendar").hide();
                $("#ui-datepicker-div").position({
                    my: "center top",
                    at: "center bottom",
                    of: $(this)
                });
            });
        });
        function pageLoad() {
            $(".monY").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1901:2099',
                showButtonPanel: true,
                dateFormat: 'M-y',
                onClose: function (dateText, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).val($.datepicker.formatDate('M-y', new Date(year, month, 1)));
                }
            });
            $(".monY").focus(function () {
                $(".ui-datepicker-calendar").hide();
                $("#ui-datepicker-div").position({
                    my: "center top",
                    at: "center bottom",
                    of: $(this)
                });
            });
        };
    </script>
</asp:Content>
