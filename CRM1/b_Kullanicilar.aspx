<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="b_Kullanicilar.aspx.cs" Inherits="CRM1.b_Kullanicilar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        h3{
            color:red;
            text-align:center;
        }
    
    </style>
    
     <h3>Kullanıcı Kayıt Sayfası</h3>
    
    <hr />
    <br />
    <div class="container">
       <div class="row">
         <div class="col-sm-3">
            <div class="form-group">
                <label>Ad </label>
                   <asp:TextBox ID="txt_name" CssClass="form-control" runat="server"></asp:TextBox>
            </div>  
        </div>
       <div class="col-sm-3">
          <div class="form-group">
             <label>Kullanıcı Adı </label>
               <asp:TextBox ID="txt_Usern" CssClass="form-control" runat="server"></asp:TextBox>
           </div>
          
       </div>
        <div class="col-sm-3">
            <div class="form-group">
                  <label>Parola</label>
                  <asp:TextBox ID="txt_Passw" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-sm-3">
            <div class="form-group">
                 <label>Email</label>
                <asp:TextBox ID="txt_Email" CssClass="form-control" runat="server"></asp:TextBox>
            </div> 
        </div>
            <br /> <br />
        <div class="col-sm-3">
            <div class="form-group">
                <label>Cep Telefon</label>
                <asp:TextBox ID="txt_GSM" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        
        </div>
           <div class="col-sm-3" >  
               <div class="form-group">   <label>&nbsp</label> <br />
                    <asp:Button ID="btn_kaydet" CssClass="btn btn-primary" OnClientClick="return Kontrol()" runat="server" Text="Kaydet" OnClick="btn_kaydet_Click" />
                    <label>&nbsp</label>
                     <asp:Button ID="btn_bul" CssClass="btn btn-warning" runat="server"  Text="Listele" OnClick="btn_bul_Click" />
               </div>
 
        </div>
    </div>
    </div>

    <div class="container">
        

    <div class="table-responsive"> 
        <asp:Repeater ID="rpt_kull" runat="server" OnItemCommand="rpt_kull_ItemCommand">
            <HeaderTemplate>  
                <table class="table table-bordered">
            <thead>
                <tr>
                    <th> İsim</th>
                    <th> Kullanıcı Adı</th>
                    <th> Şifresi</th>
                    <th> Email</th>
                    <th> GSM</th>
                    <th>İşlemler</th>
                </tr>

            </thead>
                    
            <tbody>
           </HeaderTemplate>
            <ItemTemplate>
                  <tr>
                    <td> <%# Eval("NAME")  %></td>
                    <td> <%# Eval("USERN") %></td>
                    <td> <%# Eval("PASSW") %></td>
                    <td> <%# Eval("EMAIL") %> </td>
                    <td> <%# Eval("CSM")   %> </td>
                    <td> <asp:Button ID="rpt_kull" runat="server"  CssClass="btn btn-danger" OnClientClick='return confirm(" Bu kayıtı silmek istediğinizden emin misiniz?")' CommandArgument='<%# Eval("KUL_ID") %>' Text="Sil" CommandName="Sil" /> 
                     <asp:Button ID="rpt_kull1" runat="server" CssClass="btn btn-success" CommandArgument='<%# Eval("KUL_ID") %>' Text="Güncelle" CommandName="dzn" /> </td>    
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
            if ($("#ContentPlaceHolder1_txt_name").val()=="") {
                alert('Boş geçilemez!');
                return false;
            }
        
        }
    </script>

</asp:Content>
