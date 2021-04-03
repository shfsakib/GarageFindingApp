<%@ Page Title="" Language="C#" MasterPageFile="~/user/root.Master" AutoEventWireup="true" CodeBehind="service-request.aspx.cs" Inherits="GarageFindingApp.user.service_request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1>Customer List</h1>
    </section>
    <div class="row pad-all">
        <div class="col-12 col-md-12 align-items-center">
            <div class="col-xs-5 col-md-3" style="margin: 0; padding: 0 0 0 15px;">
                <asp:textbox runat="server" id="txtDate" class="dateJ form-control" placeholder="seach by booking date" AutoPostBack="True" OnTextChanged="txtDate_OnTextChanged" autocomplete="off"></asp:textbox>
            </div>
            <div class="col-xs-7 col-md-5" style="margin: 0; padding: 0 15px 0 5px;">
                <asp:checkbox id="chkPending" runat="server" OnCheckedChanged="chkPending_OnCheckedChanged" AutoPostBack="True"  style="font-size: 18px;" Text="&nbsp; Show pending request"></asp:checkbox>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="row">
            <div class="col-12 col-md-12">
                <div class="table-responsive" style="border: none;">
                    <asp:gridview id="gridbook" width="100%" class="table table-hover table-bordered table-striped" style="background: #ededfb;" OnRowDataBound="gridbook_OnRowDataBound" onpageindexchanging="gridbook_OnPageIndexChanging" autogeneratecolumns="False" showheader="False" showheaderwhenempty="True" emptydatatext="No Booking Found" allowpaging="True" pagesize="20" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="" >
                                <ItemTemplate>
                                   <div class="col-12 p-3 pl-2" style="padding: 10px;">
                                        <div class="row p-0">
                                            <div class="col-4 col-lg-2 mp tc text-center">
                                                <asp:Image runat="server" class="mt-1" Width="150px" Height="150px" ImageUrl='<%#Eval("GaragePic") %>' Style="border: 2px solid #696969"></asp:Image>
                                            </div>
                                            <div class="col-8 col-lg-6 pl-2">
                                                <asp:HiddenField ID="BookId" runat="server" Value='<%#Eval("BookId") %>' />
                                                <asp:HiddenField ID="GarageId" runat="server" Value='<%#Eval("GarageId") %>' />
                                                <asp:HiddenField ID="CustId" runat="server" Value='<%#Eval("CustId") %>' />
                                                <asp:HiddenField ID="status" runat="server" Value='<%#Eval("Status") %>' />

                                               <h3><asp:Label runat="server" ID="lblName" Text='<%#"You have sent booking request to "+Eval("GarageName")%>'></asp:Label></h3> 
                                                <p class="mp"><i class="fas fa-calendar text-success" ></i><%#" "+Eval("BookingDate")+"_"+Eval("BookingTime")%></p>
                                                <p class="mp"><i class="fas fa-sort-numeric-down  text-primary" ></i><%#" "+Eval("BkashNo")%></p>
                                                <p class="mp"><i class="fas fa-dove text-primary"></i><%#" "+Eval("TransactionNo")%></p>
                                                <p class="mp"><i class="fas fa-lira-sign text-primary"></i><%#" "+Eval("Amount")%></p>
                                                <p class="mp"><i class="fas fa-cash-register text-primary"></i><%#" "+Eval("TokenId")%></p>
                                                <p class="mp"><%#"Request Time: "+Eval("Intime")%></p>
                                                <p class="mp"><asp:Label runat="server" id="lblStatus" style="font-size: 24px; font-weight: bold; font-family: comic sans ms;" Text=""></asp:Label></p>
                                                <p class="mp font-20 text-success">
                                                    <asp:LinkButton ID="lnkRemove" OnClick="lnkRemove_OnClick" class="btn btn-danger"  runat="server" ToolTip="Remove"><i class="fas fa-trash-alt"></i>&nbsp;Remove</asp:LinkButton>
                                                    <asp:LinkButton ID="lnkRating" OnClick="lnkRating_OnClick" class="btn btn-warning" runat="server" ToolTip="Rate">Rate Garage</asp:LinkButton>
                                                    
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
                    </asp:gridview>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
