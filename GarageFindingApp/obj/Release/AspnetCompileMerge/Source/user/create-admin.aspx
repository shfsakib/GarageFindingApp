<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="create-admin.aspx.cs" Inherits="GarageFindingApp.user.create_admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <h3>Create Admin</h3>
    </div>
    <div class="col-md-12">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Name : </div>
                <div class="col-md-6">
                    <input type="text" runat="server" class="form-control wd" autocomplete="off" placeholder="Full Name" id="txtName" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Email : </div>
                <div class="col-md-6">
                    <input class="form-control wd" id="txtEmail" autocomplete="off" runat="server" type="email" placeholder="example@example.com" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Mobile No. : </div>
                <div class="col-md-6">
                    <input type="text" runat="server" autocomplete="off" class="form-control wd" placeholder="01XXXXXXXXX" id="txtMobileNo" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Date of Birth : </div>
                <div class="col-md-6">
                    <asp:TextBox ID="txtDob" autocomplete="off" class="form-control wd" runat="server" required="required" placeholder="dd/mm/yyyy"></asp:TextBox>
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Gender : </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlGender" runat="server" class="form-control wd">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Profile Picture : </div>
                <div class="col-md-6">
                    <asp:FileUpload ID="fileImage" onchange="ImagePreview(this)" class="form-control" accept=".png,.jpg,.jpeg" runat="server" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <img id="profilePicImage" runat="server" class="form-control wd" src="../Link/dummy.png" alt="ProfilePic" style="height: 150px; width: 150px" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Type : </div>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlType" class="form-control wd" required="required" runat="server">
                        <asp:ListItem Text="Select"></asp:ListItem>
                        <asp:ListItem Text="Super Admin"></asp:ListItem>
                        <asp:ListItem Text="Admin"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Password : </div>
                <div class="col-md-6">
                    <input type="password" runat="server" autocomplete="off" class="form-control wd" placeholder="enter password" id="txtNewPass" />
                </div>
                <div class="col-md-2"></div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2">Confirm Password : </div>
                <div class="col-md-6">
                    <asp:TextBox runat="server" autocomplete="off" TextMode="Password" class="form-control wd" placeholder="confirm password" ID="txtConfirmPass"></asp:TextBox>
                </div>
                <div class="col-md-2"></div>
            </div>
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-2"></div>
                <div class="col-md-6">
                    <asp:LinkButton ID="createButton" OnClick="createButton_OnClick" Style="width: 100%; margin-top: 2px" runat="server" class="btn btn-primary wd"> <i class="icon-add_to_queue"></i>&nbsp;Create Admin</asp:LinkButton>
                </div>
                <div class="col-md-2"></div>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <style>
        .wd {
            margin-top: 2px;
        }
    </style>
    <!-- /.container-fluid -->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        function ImagePreview(input) { 
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $("#ContentPlaceHolder1_profilePicImage").prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
