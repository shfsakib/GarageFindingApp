<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="add-location.aspx.cs" Inherits="GarageFindingApp.user.AddLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Location</h1>
    </section>
    <div class="col-md-12">
        <div class="row">
            <div class="col-12 col-md-12">
                <div class="table-responsive" style="border: none;">
                    <asp:GridView ID="locationGridView" class="table table-bordered table-striped " OnRowDataBound="locationGridView_OnRowDataBound" Style="border: 1px solid black; background: #ededfb;" runat="server" OnPageIndexChanging="locationGridView_OnPageIndexChanging" OnRowCommand="locationGridView_OnRowCommand" OnRowEditing="locationGridView_OnRowEditing" OnRowUpdating="locationGridView_OnRowUpdating" OnRowCancelingEdit="locationGridView_OnRowCancelingEdit" AutoGenerateColumns="False" ShowHeader="True" EmptyDataText="No Location Found" ShowHeaderWhenEmpty="True" AllowPaging="True" PageSize="30">
                        <Columns>
                            <asp:TemplateField HeaderText="Serial">
                                <HeaderTemplate>
                                    <table class="" width="100%">
                                        <tr>
                                            <th style="text-align: center">Serial</th>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <label>#</label>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="slLabel" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderTemplate>
                                    <table class="" width="100%" style="min-width: 100px!important">
                                        <tr>
                                            <th style="text-align: center">Thana</th>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px 0;">
                                                <asp:DropDownList ID="ddlThanaFooter" class="form-controls select2" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("Thana") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlThana" class="form-controls select2" runat="server"></asp:DropDownList>
                                    <asp:HiddenField ID="thanaId" runat="server" Value='<%#Eval("Thana") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderTemplate>
                                    <table class="" width="100%">
                                        <tr>
                                            <th style="text-align: center">Location_Name</th>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px 0;">
                                                <input type="text" runat="server" id="locationFooterTextBox" style="font-weight: normal;" autocomplete="off" class="form-controls wd" placeholder="Add location" />
                                                <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Eval("Id") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("LocationName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input type="text" runat="server" id="locationTextBox" style="font-weight: normal;" autocomplete="off" class="form-controls wd" value='<%#Eval("LocationName") %>' placeholder="Add location" />
                                    <asp:HiddenField ID="idHiddenFieldEdit" runat="server" Value='<%#Eval("Id") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Intime" Visible="False">
                                <HeaderTemplate>
                                    <table class="" width="100%">
                                        <tr>
                                            <th>
                                                <label>Intime</label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>#</td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("Intime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemStyle Width="20%"></ItemStyle>
                                <HeaderTemplate>
                                    <table class="" width="100%">
                                        <tr>
                                            <th>
                                                <label></label>
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="addNewButton" runat="server" class="btn btn-primary" CommandName="AddNew" ToolTip="Add New"><i class="fas fa-plus fa-lg"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="editButton" runat="server" class="" CommandName="Edit" ToolTip="Edit"><i class="fas fa-edit fa-lg"></i></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="updateButton" runat="server" class="" CommandName="Update" ToolTip="Update"><i class="fas fa-save fa-2x"></i></asp:LinkButton>
                                    <asp:LinkButton ID="cancelButton" runat="server" class="" CommandName="Cancel" ToolTip="Cancel"><i class="fas fa-times fa-2x"></i></asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <style>
        td {
            padding: 10px;
        }
    </style>

</asp:Content>
