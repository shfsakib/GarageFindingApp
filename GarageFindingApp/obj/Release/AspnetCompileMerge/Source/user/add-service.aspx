<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="add-service.aspx.cs" Inherits="GarageFindingApp.user.add_service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Service</h1>
    </section>
    <div class="col-md-12">
        <div class="row">
            <div class="col-12 col-md-12">
                <div class="table-responsive" style="border: none;">
                    <asp:GridView ID="serviceGridView" class="table table-bordered table-striped " Style="border: 1px solid black; background: #ededfb;" runat="server" OnPageIndexChanging="serviceGridView_OnPageIndexChanging" OnRowCommand="serviceGridView_OnRowCommand" OnRowEditing="serviceGridView_OnRowEditing" OnRowUpdating="serviceGridView_OnRowUpdating" OnRowCancelingEdit="serviceGridView_OnRowCancelingEdit" OnRowDeleting="serviceGridView_OnRowDeleting" AutoGenerateColumns="False" ShowHeader="True" EmptyDataText="No service Found" ShowHeaderWhenEmpty="True" AllowPaging="True" PageSize="30">
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
                                    <table class="" width="100%">
                                        <tr>
                                            <th style="text-align: center">service_Name</th>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px 0;">
                                                <input type="text" runat="server" id="serviceFooterTextBox" style="font-weight: normal;" autocomplete="off" class="form-controls wd" placeholder="Add service" />
                                                <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Eval("Id") %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("serviceName") %>'></asp:Label>
                                    <asp:HiddenField ID="idHidden" runat="server" Value='<%#Eval("Id") %>' />

                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input type="text" runat="server" id="serviceTextBox" style="font-weight: normal;" autocomplete="off" class="form-controls wd" value='<%#Eval("serviceName") %>' placeholder="Add service" />
                                    <asp:HiddenField ID="idHiddenFieldEdit" runat="server" Value='<%#Eval("Id") %>' />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <HeaderTemplate>
                                    <table class="" width="100%">
                                        <tr>
                                            <th style="text-align: center">Price</th>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px 0;">
                                                <input type="text" runat="server" id="priceFooterTextBox" style="font-weight: normal;" autocomplete="off" class="form-controls wd" placeholder="XXX" />
                                            </td>
                                        </tr>
                                    </table>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("Price") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input type="text" runat="server" id="priceTextBox" style="font-weight: normal;" autocomplete="off" class="form-controls wd" value='<%#Eval("Price") %>' placeholder="XXX" />
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
                                    <asp:LinkButton ID="deleteButton" runat="server" class="" CommandName="Delete" ToolTip="Remove"><i class="fas fa-trash-alt fa-lg"></i></asp:LinkButton>
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
