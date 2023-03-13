<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="b_Urunler.aspx.cs" Inherits="CRM1.b_Urunler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        h3{
            color:red;
            text-align:center;
        }
     
    </style>
    <h3>Ürün Kayıt Sayfası</h3>
    <hr />
    <br />
    <div class="container">
         <div class="row">
           <div class="col-sm-3">
             <div class="form-group">
                <label>Ürün Adı</label>
                <asp:TextBox ID="txt_Uname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-sm-3">
            <div class="form-group">
                <label>Kodu</label>
                <asp:TextBox ID="txt_Code" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-sm-3">
            <div class="form-group">
                <label>Fiyatı</label>
                <asp:TextBox ID="txt_Fiyat" CssClass="form-control" runat="server"></asp:TextBox>
            </div>  
        </div>
        <div class="col-sm-3">
            <div class="form-group">
                  <label>Stok</label>
                 <asp:TextBox ID="txt_Brm_adi" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
             <div class="col-sm-3">
            <div class="form-group">
              <asp:FileUpload ID="FU_File" runat="server" />
            </div>
        </div>
             
             <br /> <br />
             <div class="col-sm-3" >  
               <div class="form-group">   <label>&nbsp</label> <br />
                    <asp:Button ID="btn_kaydet" CssClass="btn btn-primary" OnClientClick="return Kontrol(); " runat="server" Text="Kaydet" OnClick="btn_kaydet_Click" />
                    <label>&nbsp</label> 
                    <asp:Button ID="btn_bul" CssClass="btn btn-warning"  runat="server" Text="Listele" OnClick="btn_bul_Click" />
               </div>
        </div>
      </div>
        </div>
     <div class="container">

    <div class="table-responsive"> 
        <asp:Repeater ID="rpt_urunler" runat="server" OnItemCommand="rpt_urunler_ItemCommand">
            <HeaderTemplate>  
                <table class="table table-bordered">
            <thead>
                <tr>
                    <th> Ürün Adı</th>
                    <th> Kodu</th>
                    <th> Fiyatı</th>
                    <th> Stok</th>
                    <th>İşlemler</th>
                </tr>

            </thead>
                    
            <tbody>
           </HeaderTemplate>
            <ItemTemplate>
                  <tr>
                    <td> <%# Eval("UNAME") %></td>
                    <td> <%# Eval("CODE") %></td>
                    <td> <%# Eval("FIYAT") %></td>
                    <td> <%# Eval("BRM_ADI") %> </td>
                  <td> <asp:Button ID="rpt_urunler" runat="server" CssClass="btn btn-danger" OnClientClick='return confirm(" Bu kayıtı silmek istediğinizden emin misiniz?")' CommandArgument='<%# Eval("URN_ID") %>' Text="Sil" CommandName="Sil"  />
                       <asp:Button ID="rpt_urunler1" runat="server" CssClass="btn btn-success" CommandArgument='<%# Eval("URN_ID") %>' Text="Güncelle" CommandName="dzn" /></td>
                   
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                  </tbody>

        </table>
            </FooterTemplate>
            </asp:Repeater> 
          
    </div>

    </div>
    <script>
        function Kontrol() {
            
            if ($("#ContentPlaceHolder1_txt_Uname").val()=="") {
                alert('Boş geçilemez!');
                return false;
            }

            if ($("#ContentPlaceHolder1_txt_Code").val() == "") {
                alert('Boş geçilemez!');
                return false;
            }
        }
    </script>


       
</asp:Content>
