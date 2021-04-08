<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="monthly-charge.aspx.cs" Inherits="GarageFindingApp.user.monthly_charge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <h3>Monthly Charge</h3>
    </div>
    <div class="col-md-12">
        <asp:Label ID="lblId" runat="server" Text="" style="display: none"></asp:Label>
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8"><p runat="server" id="paymentMsg">Please pay BDT 2000 as your monthly charge to 01XXXXXXXXX. Please use <b><asp:label id="lblToken" runat="server" text=""></asp:label></b> as reference during payment.
                </p></div>
               <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Email : </div>
                <div class="col-md-6">
                    <asp:textbox runat="server"  class="form-control mt2" autocomplete="off" placeholder="name@example.com" id="txtEmail"></asp:textbox> 
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Choose Month : </div>
                <div class="col-md-6">
                    <input type="text" runat="server" autocomplete="off" class="form-control mt2 monY" placeholder="mmm-yy" id="txtMonth" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Bkash No. (Last 6 digit only) : </div>
                <div class="col-md-6">
                    <input class="form-control  mt2" id="txtBkashNo" autocomplete="off" runat="server" type="text" placeholder="XXXXXX" maxlength="6" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Transaction No. : </div>
                <div class="col-md-6">
                    <input type="text" runat="server" autocomplete="off" class="form-control  mt2" placeholder="XXXXXXXXX" id="txtTrans" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Amount : </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtAmount" autocomplete="off" class="form-control  mt2" runat="server" required="required" placeholder="XXXXXX"></asp:TextBox>
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:LinkButton ID="btnPay" OnClick="btnPay_OnClick" Style="width: 100%; margin-top: 2px" runat="server" class="btn btn-primary wd">Make Payment</asp:LinkButton>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>
    </div>
     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(document).ready(function() {
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
    <%-- Auto complete --%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-autocomplete/1.0.7/jquery.auto-complete.min.js" integrity="sha512-TToQDr91fBeG4RE5RjMl/tqNAo35hSRR4cbIFasiV2AAMQ6yKXXYhdSdEpUcRE6bqsTiB+FPLPls4ZAFMoK5WA==" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-autocomplete/1.0.7/jquery.auto-complete.min.css" integrity="sha512-TfnGOYsHIBHwx3Yg6u6jCWhqz79osu5accjEmw8KYID9zfWChaGyjDCmJIdy9fJjpvl9zXxZamkLam0kc5p/YQ==" crossorigin="anonymous" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    
    <script>
        $(document).ready(function() {
            $("#<%=txtEmail.ClientID %>").autocomplete({
                source: function(request, response) {
                    $.ajax({
                        url: "../AutoComplete.asmx/GetGarageEmail",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtEmail.ClientID %>").val() + "'}",
                        dataFilter: function(data) { return data; },
                        success: function(data) {
                            response($.map(data.d, function(item) {
                                return {
                                    label: item,
                                    value: item
                                };
                            }));
                        },
                        error: function(result) {
                            alert('User not found');
                        }
                    });
                },
                minLength: 1,
            });
        });
        function pageLoad() {
            $("#<%=txtEmail.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete.asmx/GetGarageEmail",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtEmail.ClientID %>").val() + "'}",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item,
                                    value: item
                                };
                            }));
                        },
                        error: function (result) {
                            alert('User not found');
                        }
                    });
                },
                minLength: 1,
            });
        };

    </script>
</asp:Content>
