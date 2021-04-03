<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="book-service.aspx.cs" Inherits="GarageFindingApp.user.book_service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <h3>Book Service</h3>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <p>
                    Please pay BDT 100 to 01XXXXXXXXX as your booking fee. Please use <b>
                        <asp:Label ID="lblToken" runat="server" Text=""></asp:Label></b> as your reference id during payment. This fee will be reduct from your service charge. If you don't come on booking date you won't get back your advance fees.
                </p>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-2">Garage Name : </div>
            <div class="col-md-6">
                <input type="text" runat="server" readonly="readonly" class="form-control wd" autocomplete="off" placeholder="Garage Name" id="txtGarageName" />
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-2">Booking Date : </div>
            <div class="col-md-6">
                <input type="text" runat="server" class="form-control wd dateJ" autocomplete="off" placeholder="dd/mm/yyyy" id="txtDate" />
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-2">Booking Time : </div>
            <div class="col-md-6">
                <input type="time" runat="server" class="form-control wd" autocomplete="off" placeholder="HH:MM tt" id="txtTime" />
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-2">Bkash No. (Last 6 digits only) : </div>
            <div class="col-md-6">
                <input type="text" runat="server" class="form-control wd" maxlength="6" autocomplete="off" placeholder="XXXXXX" id="txtBkashNo" />
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-2">Transaction No. : </div>
            <div class="col-md-6">
                <input type="text" runat="server" class="form-control wd" autocomplete="off" placeholder="XXXXXXXXXX" id="txtTransNo" />
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-2">Amount :</div>
            <div class="col-md-6">
                <input type="text" runat="server" class="form-control wd" autocomplete="off" placeholder="XXXX" id="txtAmount" />
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Label ID="lblwarning" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-2"></div>
            <div class="col-md-6">
                <asp:Button ID="btnBook" class="btn btn-success wd" OnClick="btnBook_OnClick" Width="100%" runat="server" Text="Book Now" />
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
</asp:Content>
