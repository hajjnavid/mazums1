<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageNull.master" AutoEventWireup="true" CodeFile="Sarp.aspx.cs" Inherits="Sarp" %>
<%@ Register  Src="~/PopUpMessage.ascx" TagName="Pop" TagPrefix="Elpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <Elpt:Pop ID="pop" runat="server" />


    <div class="container">
        <div class="boxNew1">
            <div class="boxNew1-header bold">فرم تعریف</div>
            <div class="boxNew1-body">
                <div class="row">
                    
                     

                <div class="col-sm-3">
                   <div class="ColorBBB">بسته</div>
                    <asp:DropDownList ID="ddl_req" runat="server" CssClass="dropdown"></asp:DropDownList>
                  </div>



                 <div class="col-sm-3">
                   <div class="ColorBBB">بسته</div>
                   <asp:CheckBoxList  ID="chk_req" runat="server"  CssClass="checkbox-inline "></asp:CheckBoxList>

                  </div>


                </div>
                </div>

                <div style="text-align: center; padding-top: 40px">
                    <asp:Button ID="btn" runat="server" BackColor="#00ff00" CssClass="btn btn-success"  OnClick="btn_Click" Text="ذخیره سازی" />
                </div>

                <div id="div_error" runat="server"></div>

            </div>
        </div>

    

</asp:Content>



