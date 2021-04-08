<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="own-profile.aspx.cs" Inherits="GarageFindingApp.user.own_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h3>Profile</h3>
    </section>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center">
                <asp:Image ID="profileImage" runat="server" ImageUrl="/Link/dummy.png" class="rounded-circle" Width="250px" Height="250px" alt="profile_image" Style="border: 1px solid black; border-radius: 50%;" />
                <br />
                <asp:FileUpload ID="fileProfile" onchange="ImagePreview(this)" Visible="False" accept=".png,.jpg,.jpeg" runat="server" />
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center">
                <br />
                <asp:Label ID="nameLabel" runat="server" Style="font-family: comic sans ms; font-size: 20px;" Text="Label"></asp:Label>
                <asp:TextBox ID="txtName" CssClass="form-control wd"  Visible="False" placeholder="Full Name" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center">
                <br />
                <a id="btnEdit" runat="server" class="btn btn-primary" style="color: white;" title="Edit" OnServerClick="btnEdit_OnServerClick"><i class="fas fa-edit"></i>&nbsp;&nbsp;Edit Profile</a>
                <asp:LinkButton ID="lnkUpdate" Visible="False" CssClass="btn btn-success" OnClick="lnkUpdate_OnClick" runat="server"><i class="fas fa-check"></i>&nbsp;&nbsp;Update</asp:LinkButton>
                <br/>
                 </div>
            <div class="col-md-4"></div>
        </div>
        <hr/>
        <div class="row">
            <div class="col-xs-4">Email :</div>
            <div class="col-xs-8" >
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-xs-4">
                Mobile No. :
            </div>
            <div class="col-xs-8" >
                <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtMobile" CssClass="form-control wd"  Visible="False" autocomplete="off" placeholder="01XXXXXXXXX" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" id="userDiv" runat="server">
            <div class="col-xs-4">Gender :</div>
            <div class="col-xs-8" >
                <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="ddlGender" class="form-control wds" Visible="False" Style="border-right: 1px solid gainsboro" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-4">
                Date of Birth :
            </div>
            <div class="col-xs-8" >
                <asp:Label ID="lblDob" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtDob" CssClass="form-control wd dateJ" Visible="False" autocomplete="off" placeholder="dd/mm/yyyy" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row" id="garageDiv" runat="server">
            <div class="col-xs-4">Garage Name :</div>
            <div class="col-xs-8" >
                <asp:Label ID="lblGarageName" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtGarageName" CssClass="form-control wd" Visible="False" autocomplete="off" placeholder="Garage name" runat="server"></asp:TextBox>

            </div>
            <div class="col-xs-4">
                District :
            </div>
            <div class="col-xs-8" >
                <asp:Label ID="lbldistrict" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="ddlDistrict" class="form-control wd select2" Visible="False" Style="border-right: 1px solid gainsboro;margin: 2px 0 0 0;" runat="server">
                    <asp:ListItem>--DISTRICT--</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-4">
                Thana :
            </div>
            <div class="col-xs-8" >
                <asp:Label ID="lblThana" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="ddlThana" class="form-control wd select2" Visible="False" Style="border-right: 1px solid gainsboro;margin: 2px 0 0 0;" runat="server">
                    <asp:ListItem>--THANA--</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-4">
                Location :
            </div>
            <div class="col-xs-8" >
                <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="ddlLocation" class="form-control wd select2" Visible="False" Style="border-right: 1px solid gainsboro;margin: 2px 0 0 0;" runat="server">
                    <asp:ListItem>--LOCATION--</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-4">
                Address :
            </div>
            <div class="col-xs-8" >
                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtAddress" CssClass="form-control wd" Height="80px" Visible="False" autocomplete="off" TextMode="MultiLine" runat="server" Style="border-right: 1px solid gainsboro" placeholder="Address"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-4">Password :</div>
            <div class="col-xs-8" >
                <asp:Label ID="lblPass" runat="server" Text="********"></asp:Label>
                <asp:TextBox ID="txtPass" CssClass="form-control wd" Visible="False" placeholder="Enter Password" autocomplete="off" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:TextBox ID="lat" runat="server" Style="display: none;"></asp:TextBox>
        <asp:TextBox ID="longL" runat="server" Style="display: none;"></asp:TextBox>
        <div class="row">
            <div class="col-md-12">
                <h4 runat="server" id="lblService">Service List:</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gridService" Width="100%" class="table table-hover table-bordered table-striped" Style="background: #ededfb;" AutoGenerateColumns="False" ShowHeader="True" ShowHeaderWhenEmpty="True" EmptyDataText="No Service Found" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="Service_Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Id")%>' />
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ServiceName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="Label21" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(document).ready(function () {
            // get users lat/long
            var getPosition = {
                enableHighAccuracy: false,
                timeout: 9000,
                maximumAge: 0
            };
            function success(gotPosition) {
                var uLat = gotPosition.coords.latitude;
                var uLon = gotPosition.coords.longitude;
                //$('#lat').text(uLat);
                //$('#longL').text(uLon);
                $('#lat').val(uLat);
                $('#longL').val(uLon);
                ////$('#NavBar_MapTypeText').innerHTML = "Aerial";
            };
            function error(err) {
                console.warn(`ERROR(${err.code}): ${err.message}`);
            };
            navigator.geolocation.getCurrentPosition(success, error, getPosition);
        });
    </script>
</asp:Content>
