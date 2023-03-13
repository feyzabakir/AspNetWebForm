<%@ Page Language="C#" MasterPageFile="~/etiaret.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="CRM1._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>


    <div>
        <h2 class="w3-center">
            <center>Anasayfa</center>
        </h2>


        <div id="demo" class="carousel slide" data-ride="carousel">

            <!-- Indicators -->
            <ul class="carousel-indicators">
                <li data-target="#demo" data-slide-to="0" class="active"></li>
                <li data-target="#demo" data-slide-to="1"></li>
                <li data-target="#demo" data-slide-to="2"></li>
                <li data-target="#demo" data-slide-to="3"></li>
               <li data-target="#demo" data-slide-to="4"></li>
                <li data-target="#demo" data-slide-to="5"></li>
            </ul>

            <!-- The slideshow -->
            <div class="carousel-inner">
               <div class="carousel-item active">
                  <a href="Urun_Detay.aspx?URN_ID=31">  <img src="resimler/s1.jpg" width="1100" height="500"> </a>
                </div>
                <div class="carousel-item">
                    <img src="resimler/s2.jpg" width="1100" height="500">
                </div>
                <div class="carousel-item">
                    <img src="resimler/s3.jpg" width="1100" height="500">
                </div>
                <div class="carousel-item">
                    <img src="resimler/t1.jpg" width="1100" height="500">
                </div>
                <div class="carousel-item">
                  <a href="Urun_Detay.aspx?URN_ID=30">   <img src="resimler/t2.jpg" width="1100" height="500"> </a>
                </div> 
                <div class="carousel-item">
                    <img src="resimler/t3.jpg" width="1100" height="500">
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="carousel-control-prev" href="#demo" data-slide="prev">
                <span class="carousel-control-prev-icon"></span>
            </a>
            <a class="carousel-control-next" href="#demo" data-slide="next">
                <span class="carousel-control-next-icon"></span>
            </a>
        </div>
    </div>


    <div class="container d-flex justify-content-center mt-50 mb-50">
        <div class="row">
            <asp:Repeater ID="rpt_Urunler" runat="server" OnItemCommand="rpt_Urunler_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-4 mt-2">
                        <div class="card">
                            <div class="card-body">
                                <div class="card-img-actions">
                                    <center>
                                        <a href="Urun_Detay.aspx?URN_ID=<%#Eval("URN_ID") %>" class="text-muted" data-abc="True">
                                            <img class="" style="height: 120px;" src='./resimler/<%#Eval("FPath") %>' /></a>
                                    </center>
                                </div>
                            </div>

                            <div class="card-body bg-light text-center">
                                <div class="mb-2">
                                    <h6 class="font-weight-semibold mb-2">

                                        <a href="Urun_Detay.aspx?URN_ID=<%#Eval("URN_ID") %>" class="text-muted" data-abc="True"><%#Eval("UNAME") %></a>
                                        <br />
                                        <br />

                                        <a href="#" class="text-default mb-2" data-abc="true"><%# Eval("CODE") %></a>
                                    </h6>
                                </div>
                                <h3 class="mb-0  mb-2"><%#Eval("FIYAT") %> TL</h3>
                                <asp:LinkButton ID="btn_ekle" class="btn bg-cart" runat="server" CommandArgument='<%#Eval("URN_ID") %>' CommandName="ekle" CssClass="btn-group-toggle">
                                 <i class="fa fa-plus"></i>
                                        Ekle
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>


</asp:Content>

