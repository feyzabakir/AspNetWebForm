<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sepetim.aspx.cs" Inherits="CRM1.sepetim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css">
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="float: right">
            <div class="row">
                <div class="col-xs-8">
                    <div class="panel panel-info ">
                        <div class="panel-heading">
                            <div class="panel-title">
                                <div class="row">
                                    <div class="col-xs-6">
                                        <h5><span class="glyphicon glyphicon-shopping-cart"></span>Alışveriş Sepeti</h5>
                                    </div>
                                    <div class="col-xs-4" style="float: right">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton_alisveris">
									<span class="glyphicon glyphicon-share-alt" ></span> Alışverişe devam et</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

   <asp:Repeater ID="rpt_sepetim" runat="server" OnItemCommand="rpt_Urunler_ItemCommand">
      <ItemTemplate>
         <div class="col-xs-8">
           <div class="panel-body">
             <div class="row">
               <div class="col-xs-2">
                   <img class="img-responsive" src='./resimler/<%#Eval("FPath") %>'>
               </div>
               <div class="col-xs-4">
                   <h4 class="product-name"><strong><%#Eval("UNAME") %></strong></h4>
                </div>
          <div class="col-xs-6">
             <div class="col-xs-6 text-right">
                <h6><strong><%#Eval("FIYAT") %> TL <span class="text-muted">x</span></strong></h6>
              </div>
          <div class="col-xs-4">
            <asp:TextBox ID="TextBox1" runat="server" type="text" class="form-control input-sm" value='<%#Eval("MIKTAR") %>'></asp:TextBox>
           </div>
    <div class="col-xs-2">
         <asp:LinkButton ID="lnk_sil" runat="server" CommandName="sil" CommandArgument='<%#Eval("SPT_ID") %>' class="btn btn-link btn-xs">
			<span class="glyphicon glyphicon-trash"> </span>
         </asp:LinkButton>
    </div>
         </div>
                    </div> <hr>
             </div>
             </div>
       </ItemTemplate>
   </asp:Repeater>

         <div class="container">
          </div>
             <div class="row">
               <div class="panel-footer">
                 <div class="row text-center">
                   <div class="col-xs-5">
                      <h4 class="text-left"><strong>Toplam:</strong><asp:Label ID="lbl_toplam" runat="server"></asp:Label></h4>
                    </div>

            <div class="col-xs-3">
							<asp:LinkButton ID="btn_siparis" class="btn btn-success btn-block" runat="server" OnClick="siparisver">
                                 <i class="fa fa-plus"></i>
                                        Sipariş Ver
                                    </asp:LinkButton>
						</div>
                 </div>
               </div>
             </div>
            </div>
        </div>
    </form>
</body>
</html>
