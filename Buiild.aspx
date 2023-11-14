<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNull.master" AutoEventWireup="true" CodeFile="Buiild.aspx.cs" Inherits="Buiild" %>

<%@ Register Src="~/PopUpMessage.ascx" TagName="Pop" TagPrefix="Elpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

   
<Elpt:Pop ID="pop" runat="server" />
   <div class="container">
        <div class="boxNew1D">
            <div class="boxNew1-header bold">فرم</div>
            <div class="boxNew1-body">
             
                <div class="row">

                    <div class="col-sm-6">
                         <div class="ColorBBB">انتخاب مرحله</div>
                         <asp:DropDownList ID="level_Id" runat="server" CssClass="drp"></asp:DropDownList>
                    </div>

                    <div class="col-sm-6">
                         <div class="ColorBBB">تاریخ</div>
                         <asp:TextBox ID="txt_date" runat="server" CssClass="txt" autocomplete="off"></asp:TextBox>
                    </div>

                </div>

                <div style="text-align: center; padding-top: 20px; padding-bottom: 20px;">
                    <asp:Button ID="btn" runat="server" CssClass="btn btn-success"  BackColor="#449d44" OnClick="btn_Click" Text="ذخیره سازی" />
                </div>

                <div style="text-align: center;">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered" GridLines="None" AutoGenerateColumns="false" OnRowCommand="GridView1_OnRowCommand">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="550px" DataField="date" HeaderText="تاریخ" />
                            <asp:BoundField ItemStyle-Width="550px" DataField="des" HeaderText=" مرحله " />
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" HeaderText="تاریخ" CausesValidation="false" CommandName="del"
                                        Text="حذف" CssClass="btn btn btn-danger" CommandArgument='<%# Eval("id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>
   </div>
</asp:Content>
