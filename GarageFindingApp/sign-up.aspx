<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign-up.aspx.cs" Inherits="GarageFindingApp.sign_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Page</title>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="icon" href="/Link/garage.png" type="image/gif" sizes="16x16" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&amp;display=fallback" />
    <!-- Font Awesome -->
    <script src="Link/font-awesome.js"></script>
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="/Link/log-in/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="/Link/log-in/dist/css/adminlte.min.css" />
</head>
<body class="hold-transition register-page">
    <div class="register-box">
        <div class="register-logo">
            <a href="#"><b>Garage</b>Finder</a>
        </div>

        <div class="card">
            <div class="card-body register-card-body">
                <p class="login-box-msg">Register</p>

                <form runat="server">
                    <div class="input-group mb-3">
                        <input type="text" class="form-control" id="txtName" autocomplete="off" runat="server" placeholder="Full Name" />
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-user"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <input type="email" runat="server" id="txtEmail" autocomplete="off" class="form-control" placeholder="Email" />
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-envelope"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <input type="text" runat="server" id="txtMobile" autocomplete="off" class="form-control" placeholder="Contact Number" maxlength="11" />
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-phone fa-rotate-90"></span>
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <asp:DropDownList ID="ddltype" AutoPostBack="True" OnSelectedIndexChanged="ddltype_OnSelectedIndexChanged" class="form-controls" Style="border-right: 1px solid gainsboro" runat="server">
                            <asp:ListItem>--User Type--</asp:ListItem>
                            <asp:ListItem>Customer</asp:ListItem>
                            <asp:ListItem>Garage</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:Panel ID="garage" runat="server" Visible="False">
                        <div class="input-group mb-3">
                            <input type="text" class="form-control" id="txtGarageName" autocomplete="off" runat="server" placeholder="Garage Name" />
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-building"></span>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Customer" runat="server" Visible="False">
                        <div class="input-group mb-3">
                            <asp:DropDownList ID="ddlGender" class="form-controls" Style="border-right: 1px solid gainsboro" runat="server">
                                <asp:ListItem>--Select--</asp:ListItem>
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="input-group mb-3">
                            <span style="width: 100%;">Date of Birth</span><br />
                            <input type="text" class="form-control" id="txtDob" autocomplete="off" runat="server" placeholder="dd/mm/yyyy" />
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-birthday-cake"></span>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="input-group mb-3">
                        <asp:DropDownList ID="ddlDistrict" class="form-control select2" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_OnSelectedIndexChanged" Style="border-right: 1px solid gainsboro" runat="server">
                            <asp:ListItem>--DISTRICT--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-group mb-3">
                        <asp:DropDownList ID="ddlThana" AutoPostBack="True" OnSelectedIndexChanged="ddlThana_OnSelectedIndexChanged" class="form-control select2" Style="border-right: 1px solid gainsboro" runat="server">
                            <asp:ListItem>--THANA--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-group mb-3">
                        <asp:DropDownList ID="ddlLocation" class="form-control select2" Style="border-right: 1px solid gainsboro" runat="server">
                            <asp:ListItem>--LOCATION--</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtAddress" CssClass="form-control" Height="80px" TextMode="MultiLine" runat="server" Style="border-right: 1px solid gainsboro" placeholder="Address"></asp:TextBox>
                        <div class="input-group-append">
                            <div class="input-group-text p-0">
                            </div>
                        </div>
                    </div>
                    <div class="input-group mb-3">
                        <input type="password" runat="server" id="txtNewPass" autocomplete="off" class="form-control" placeholder="Password" />
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>
                    <asp:TextBox ID="lat" runat="server" Style="display: none;"></asp:TextBox>
                    <asp:TextBox ID="longL" runat="server" Style="display: none;"></asp:TextBox>
                    <div class="input-group mb-3">
                        <input type="password" runat="server" autocomplete="off" id="txtConfirmPass" class="form-control" placeholder="Retype password" />
                        <div class="input-group-append">
                            <div class="input-group-text">
                                <span class="fas fa-lock"></span>
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    <div class="input-group mb-3">
                        Profile Picture
                         <asp:FileUpload ID="fileImage" CssClass="col-12" onchange="ImagePreview(this)" accept=".png,.jpg,.jpeg" runat="server" />
                    </div>
                    <div class="input-group mb-3">
                        <asp:Image ID="imgUser" Width="125px" Height="125px" Style="border: 2px solid black; border-radius: 10px;" ImageUrl="Link/user.png" runat="server" />
                    </div>
                    <div class="row">

                        <div class="col-12">
                            <button type="submit" runat="server" onserverclick="OnServerClick" class="btn btn-primary btn-block">Register</button>
                        </div>
                        <!-- /.col -->
                    </div>
                </form>
                <a href="log-in.aspx" class="text-center">I already have an account</a>
            </div>
            <!-- /.form-box -->
        </div>
        <!-- /.card -->
    </div>
    <!-- /.register-box -->

    <!-- jQuery -->
    <script src="/Link/log-in/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="/Link/log-in/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="/Link/log-in/dist/js/adminlte.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css" rel="stylesheet" />
    <link href="/Link/select2.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $('.select2').select2({
                closeOnSelect: false
            });
        });
    </script>

    <link href="Link/Date-Picker.css" rel="stylesheet" />
    <script>
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgUser.ClientID%>').prop('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
                }
            }
            $(document).ready(function () {
                $("#txtDob").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'dd/mm/yy',
                    yearRange: '1901:2099'
                });
            });
            function pageLoad() {
                $("#txtDob").datepicker({
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'dd/mm/yy',
                    yearRange: '1901:2099'
                });
            };
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtConfirmPass').keyup(function () {
                var pass = $('#txtNewPass').val();
                var cPass = $('#txtConfirmPass').val();
                $('#lblMsg').fadeIn();

                if (pass !== cPass) {
                    $('#lblMsg').text('Password missmatch ✖');
                    $('#lblMsg').css('color', 'red');
                    setTimeout(function () {
                        $('#lblMsg').fadeOut(600);
                    }, 2000);
                } else {
                    $('#lblMsg').text('Password missmatch ✔');
                    $('#lblMsg').css('color', 'green');
                    setTimeout(function () {
                        $('#lblMsg').fadeOut(600);
                    }, 2000);
                }
            });
        });

    </script>

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
</body>
</html>
