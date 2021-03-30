<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GarageFindingApp.user.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Dashboard</h1>
    </section>
    <div class="row pad-all">
        <div class="col-12 col-md-12 align-items-center">
            <div class="col-xs-5 col-md-3" style="margin: 0; padding: 0 0 0 15px;">
                <asp:DropDownList ID="ddlStatus" class="form-controls" runat="server">
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="A">Active</asp:ListItem>
                    <asp:ListItem Value="I">Inactive</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-xs-7 col-md-5" style="margin: 0; padding: 0 15px 0 5px;">
                <asp:TextBox ID="txtSearch" runat="server" autocomplete="off" class="form-controls" placeholder="Search by name or email"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-12 col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="gridGarage" class="table table-bordered" Style="background: #f3f3f3;" OnPageIndexChanging="gridGarage_OnPageIndexChanging" AutoGenerateColumns="False" ShowHeader="False" ShowHeaderWhenEmpty="True" EmptyDataText="No Garage Found" AllowPaging="True" PageSize="20" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="col-12 p-3 pl-2" style="padding: 10px;">
                                        <div class="row p-0">
                                            <div class="col-4 col-lg-2 mp tc text-center">
                                                <asp:Image runat="server" class="mt-1" Width="150px" Height="150px" ImageUrl='<%#Eval("Picture") %>' Style="border: 2px solid #696969"></asp:Image>
                                            </div>
                                            <div class="col-8 col-lg-6 mp pl-2 cenModel">
                                                <asp:HiddenField ID="userId" runat="server" Value='<%#Eval("UserId") %>' />
                                                <h3 class="mp">
                                                    <asp:Label runat="server" Text='<%#Eval("Name")%>'></asp:Label><span style="color: olive; font-size: 20px; font-weight: bold;"><%#" "+" "+Star(Eval("Rate").ToString())%></span></h3>
                                                <p class="mp"><i class="fa fa-map-marker text-success" title="Location"></i><%#" "+Eval("Address")+","+Eval("LocationName")+","+Eval("Thana")+","+Eval("DistrictName") %></p>
                                                <p class="mp"><i class="far fa-envelope text-primary" title="Location"></i><%#" "+Eval("Email")%></p>
                                                <p class="mp"><i class="fas fa-phone-alt text-primary" title="Location"></i><%#" "+Eval("MobileNo")%></p>
                                                <p class="mp font-20 text-success">
                                                    <asp:LinkButton ID="lnkBook" OnClick="lnkBook_OnClick" class="btn btn-success" runat="server" ToolTip="Click for booking">Book</asp:LinkButton>
                                                    <asp:LinkButton ID="lnkRating" OnClick="lnkRating_OnClick" class="btn btn-warning" runat="server" ToolTip="Rate">Rate</asp:LinkButton>
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
</asp:Content>
