<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="monthly-charge.aspx.cs" Inherits="GarageFindingApp.user.monthly_charge" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <h3>Monthly Charge</h3>
    </div>
    <div class="col-md-12">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8"><p runat="server" id="paymentMsg">Please pay your monthly charge to 01XXXXXXXXX. Please use <b><asp:label id="lblToken" runat="server" text=""></asp:label></b> as reference during payment.
                </p></div>
               <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Email : </div>
                <div class="col-md-6">
                    <asp:textbox runat="server"  class="form-control wd" autocomplete="off" placeholder="name@example.com" id="txtEmail"></asp:textbox> 
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Choose Month : </div>
                <div class="col-md-6">
                    <input type="text" runat="server" autocomplete="off" class="form-control wd monY" placeholder="MMMMyyyy" id="txtMonth" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Bkash No. (Last 6 digit only) : </div>
                <div class="col-md-6">
                    <input class="form-control wd" id="txtBkashNo" autocomplete="off" runat="server" type="text" placeholder="XXXXXX" maxlength="6" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Transaction No. : </div>
                <div class="col-md-6">
                    <input type="text" runat="server" autocomplete="off" class="form-control wd" placeholder="XXXXXXXXX" id="txtTrans" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Amount : </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtAmount" autocomplete="off" class="form-control wd" runat="server" required="required" placeholder="XXXXXX"></asp:TextBox>
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
                dateFormat: 'M-Y',
                showButtonPanel: true,
                onClose: function (dateText, inst) {
                    var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                    var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                    $(this).val($.datepicker.formatDate('MM yy', new Date(year, month, 1)));
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
                dateFormat: 'MMM-yy',
                onClose: function (dateText, inst) {
                    $(this).datepicker('setDate', new Date(inst.selectedYear, inst.selectedMonth, 1));
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
