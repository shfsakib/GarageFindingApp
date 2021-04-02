<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="GarageFindingApp.user.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h3>View Profile</h3>
    </section>
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center">
                <asp:Image ID="profileImage" runat="server" ImageUrl="/Link/dummy.png" class="rounded-circle" Width="250px" Height="250px" alt="profile_image" Style="border: 1px solid black; border-radius: 50%;" />
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center">
                <br />
                <asp:Label ID="nameLabel" runat="server" Style="font-family: comic sans ms; font-size: 20px;" Text="Label"></asp:Label>
            </div>
            <div class="col-md-4"></div>
        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center">
                <br />
                <a id="callButton" runat="server" class="btn btn-success" style="color: white;" title="Call"><i class="fas fa-phone fa-rotate-90"></i>&nbsp;&nbsp;Call</a>
                <a id="mailButton" runat="server" class="btn btn-warning" style="color: white;" title="Mail"><i class="fas fa-mail-bulk"></i>&nbsp;&nbsp;Send mail</a>
            </div>
            <div class="col-md-4"></div>
        </div><div class="row">
            <div class="col-md-12">
                <h4>Service List:</h4>
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
    <!-- /.row -->
</asp:Content>
