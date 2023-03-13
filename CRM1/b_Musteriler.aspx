<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="b_Musteriler.aspx.cs" Inherits="CRM1.b_Musteriler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        h3{
            color:red;
            text-align:center;
        }
 
    </style>
     <h3>Müşteri Kayıt Sayfası</h3>
        <hr />
        <br /> 
    <div class="container">
         <div class="row">
          <div class="col-sm-3">
            <div class="form-group">
                <label>Unvan </label>
                <asp:TextBox ID="txt_Unvan" CssClass="form-control" runat="server"></asp:TextBox>
            </div>  
        </div>
        <div class="col-sm-3">
            <div class="form-group">
                <label>Email </label>
                <asp:TextBox ID="txt_Email" CssClass="form-control" runat="server"></asp:TextBox>
            </div>   
        </div>
        <div class="col-sm-3">
            <div class="form-group">
                <label>Telefon </label>
                <asp:TextBox ID="txt_Sabittel" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
             <br /> 
        <div class="col-sm-3">
            <div class="form-group">
                <label>Adres </label>
                <asp:TextBox ID="txt_Adres" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
              <div class="col-sm-3">
                  <div class="form-group" >
                      <label>&nbsp</label> <br />
                      <asp:Button ID="btn_kaydet" CssClass="btn btn-primary"  OnClientClick="return Kontrol(); " runat="server" Text="Kaydet" OnClick="btn_kaydet_Click" />
                        <label>&nbsp</label>
                        <asp:Button ID="btn_bul" CssClass="btn btn-warning" runat="server" Text="Listele" OnClick="btn_bul_Click" />
                  </div>  
        </div>
    </div>
    </div>
   
     <div class="container">
        

    <div class="table-responsive"> 
        <asp:Repeater ID="rpt_musteri" runat="server" OnItemCommand="rpt_musteriler_ItemCommand">
            <HeaderTemplate>  
                <table class="table table-bordered">
            <thead>
                <tr>
                    <th> Unvan</th>
                    <th> Email</th>
                    <th> Telefon</th>
                    <th> Adres</th>
                    <th>İşlemler</th>
                </tr>

            </thead>
                    
            <tbody>
           </HeaderTemplate>
            <ItemTemplate>
                  <tr>
                    <td> <%# Eval("Unvan") %></td>
                    <td> <%# Eval("Email") %></td>
                    <td> <%# Eval("SabitTel") %></td>
                    <td> <%# Eval("Adres") %> </td>
                    <td> <asp:Button ID="rpt_musteriler" runat="server" CssClass="btn btn-danger" OnClientClick='return confirm(" Bu kayıtı silmek istediğinizden emin misiniz?")' CommandArgument='<%# Eval("CUS_ID") %>' Text="Sil" CommandName="Sil"  />
                         <asp:Button ID="rpt_kull1" runat="server" CssClass="btn btn-success" CommandArgument='<%# Eval("CUS_ID") %>' Text="Güncelle" CommandName="dzn" /> </td>
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
            debugger
            if ($("#ContentPlaceHolder1_txt_Unvan").val()=="") {
                alert('Boş geçilemez!');
                return false;
            }
        
        }
       </script>

    
</asp:Content>
