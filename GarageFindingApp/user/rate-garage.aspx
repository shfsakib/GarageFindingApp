<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="rate-garage.aspx.cs" Inherits="GarageFindingApp.user.rate_garage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Rate Garage</h1>
    </section>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-md-12" style="padding: 35px!important;">
        <div class="row">
            <div class="col-12 col-md-12">
                <div class="row">
                    <div class="col-12">
                        <asp:Rating ID="Rating1" Style="left: 34%; position: relative;" StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                            FilledStarCssClass="FilledStar" runat="server">
                        </asp:Rating>
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <span>Garage Name</span>
                        <asp:TextBox ID="txtGarage" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                    </div> 
                </div>
                <div class="row">
                    <div class="col-12">
                        <span>Write Review</span>
                        <asp:TextBox ID="txtReview" class="form-control wd-100" Style="height: 80px; border: 1px solid #696969; padding: 10px;" TextMode="MultiLine" placeholder="Write your review" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12" style="margin-top: 10px;">
                        <asp:HiddenField ID="rateValue" runat="server" />
                        <asp:LinkButton ID="btnRating" OnClick="btnRating_OnClick" class="btn btn-primary" runat="server">Submit</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style type="text/css">
        .Star {
            background-image: url(/Rating/Star.png);
            background-repeat: no-repeat;
            background-size: cover;
            height: 45px;
            width: 45px;
        }

        .WaitingStar {
            background-image: url(/Rating/WaitingStar.png);
            background-repeat: no-repeat;
            background-size: cover;
            height: 45px;
            width: 45px;
        }

        .FilledStar {
            background-image: url(/Rating/FilledStar.png);
            background-repeat: no-repeat;
            background-size: cover;
            height: 45px;
            width: 45px;
        }
    </style>
</asp:Content>
