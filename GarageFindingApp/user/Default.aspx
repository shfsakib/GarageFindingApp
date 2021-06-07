<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GarageFindingApp.user.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Dashboard</h1>
    </section>
    <div class="row pad-all">
        <div class="col-12 col-md-12 align-items-center">
            <div class="col-xs-6 col-md-3" style="margin: 0; padding: 0 0 0 15px;">
                <asp:DropDownList ID="ddlThana" class="form-controls select2" AutoPostBack="True" OnSelectedIndexChanged="ddlThana_OnSelectedIndexChanged" runat="server">
                    <asp:ListItem>--THANA--</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-6 col-md-3" style="margin: 0; padding: 0 15px 0 15px;">
                <asp:DropDownList ID="ddlLocation" class="form-controls select2" runat="server">
                    <asp:ListItem>--LOCATION--</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-12 col-md-4" style="margin: 0; padding: 5px 15px 0 15px;">
                <asp:TextBox ID="txtSearch" runat="server" autocomplete="off" class="form-controls" placeholder="Search by garage name or email"></asp:TextBox>
            </div>
            <div class="col-xs-12 col-md-2" style="margin: 0; padding: 5px 15px 0 15px;">
                <asp:Button ID="btnSearch" OnClick="btnSearch_OnClick" runat="server" Width="100%" class="btn btn-warning" Text="Search" />
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-12 col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gridGarage" class="table table-bordered" Style="background: #f3f3f3;" OnRowDataBound="gridGarage_OnRowDataBound" OnPageIndexChanging="gridGarage_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Garage Found" AllowPaging="True" PageSize="20" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="col-12 p-3 pl-2" style="padding: 10px;">
                                        <div class="row p-0">
                                            <div class="col-4 col-lg-2 mp tc text-center">
                                                <asp:Image runat="server" class="mt-1" Width="150px" Height="150px" ImageUrl='<%#Eval("Picture") %>' Style="border: 2px solid #696969"></asp:Image>
                                            </div>
                                            <div class="col-8 col-lg-6 pl-2">
                                                <asp:HiddenField ID="userId" runat="server" Value='<%#Eval("UserId") %>' />

                                                <asp:Label runat="server" ID="lblName" Text='<%#Eval("Name")%>'></asp:Label>
                                                <h3 class=""><a id="anchorName" style="text-decoration: none;" runat="server" href='<%#"/user/profile.aspx?id="+Eval("UserId")%>'></a><span style="color: olive; font-size: 20px; font-weight: bold;"><%#" "+" "+Star(Eval("Rate").ToString())%></span></h3>
                                                <p class="mp"><i class="fa fa-map-marker text-success" title="Location"></i><%#" "+Eval("Address")+","+Eval("LocationName")+","+Eval("Thana")+","+Eval("DistrictName") %></p>
                                                <p class="mp"><i class="fas fa-star-of-david text-primary" title="Experience"></i><%#" "+Exp(Eval("Experience").ToString())%></p>                                                
                                                <p class="mp"><i class="far fa-envelope text-primary" title="Location"></i><%#" "+Eval("Email")%></p>
                                                <p class="mp"><i class="fas fa-phone-alt text-primary" title="Location"></i><%#" "+Eval("MobileNo")%></p>
                                                <p class="mp font-20 text-success">
                                                    <asp:LinkButton ID="lnkBook" OnClick="lnkBook_OnClick" class="btn btn-success"  runat="server" ToolTip="Click for booking">Book Service</asp:LinkButton>
                                                    <%--<asp:LinkButton ID="lnkViewMap" OnClick="lnkViewMap_OnClick" class="btn btn-primary" runat="server" ToolTip="View Map">View Map Location</asp:LinkButton>--%>
                                                </p>
                                            </div>
                                            <div class="col-12 col-lg-4 mp pl-2 text-center text-lg-left">
                                                <%--<asp:Image runat="server" class="mt-1" Width="75px" Height="75px" ImageUrl='<%#ShowImage(Eval("HallPic1").ToString())%>' Style="border: 1px solid #696969"></asp:Image>
                                                <asp:Image runat="server" class="mt-1" Width="75px" Height="75px" ImageUrl='<%#ShowImage(Eval("HallPic2").ToString())%>' Style="border: 1px solid #696969"></asp:Image>
                                                <asp:Image runat="server" class="mt-1" Width="75px" Height="75px" ImageUrl='<%#ShowImage(Eval("HallPic3").ToString())%>' Style="border: 1px solid #696969"></asp:Image>
                                                <asp:Image runat="server" class="mt-1" Width="75px" Height="75px" ImageUrl='<%#ShowImage(Eval("HallPic4").ToString())%>' Style="border: 1px solid #696969"></asp:Image>
                                                <asp:Image runat="server" class="mt-1" Width="75px" Height="75px" ImageUrl='<%#ShowImage(Eval("HallPic5").ToString())%>' Style="border: 1px solid #696969"></asp:Image>
                                                --%>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-autocomplete/1.0.7/jquery.auto-complete.min.js" integrity="sha512-TToQDr91fBeG4RE5RjMl/tqNAo35hSRR4cbIFasiV2AAMQ6yKXXYhdSdEpUcRE6bqsTiB+FPLPls4ZAFMoK5WA==" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-autocomplete/1.0.7/jquery.auto-complete.min.css" integrity="sha512-TfnGOYsHIBHwx3Yg6u6jCWhqz79osu5accjEmw8KYID9zfWChaGyjDCmJIdy9fJjpvl9zXxZamkLam0kc5p/YQ==" crossorigin="anonymous" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <%--Auto complete--%>

    <script>
        $(document).ready(function () {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete.asmx/GetGarage",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtSearch.ClientID %>").val() + "'}",
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
                minLength: 1
            });
        });
        function pageLoad() {
            $("#<%=txtSearch.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete.asmx/GetGarage",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json; charset=utf-8",
                        data: "{ 'txt' : '" + $("#<%=txtSearch.ClientID %>").val() + "'}",
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
                minLength: 1
            });
        };

    </script>


</asp:Content>
