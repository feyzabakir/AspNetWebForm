<%@ Page Title="" Language="C#" MasterPageFile="~/etiaret.Master" AutoEventWireup="true" CodeBehind="Urun_Detay.aspx.cs" Inherits="CRM1.Urun_Detay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center mt-50 mb-50">
        <div class="row">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>

                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>Ürün Adı: </th>
                                <th>Fiyatı: </th>
                                <th>Kodu:</th>
                                <th>Stok:</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <div>
                        <br />
                       <%-- <a href="Urun_Detay.aspx?URN_ID=<%#Eval("URN_ID") %>" class="text-muted" data-abc="True">--%>
                            <img style="height: 200px; text-align: center;" src='./resimler/<%# Eval("Fpath") %>' />
                       <%-- </a>--%>
                        <br /> <br />
                    </div>
                    <tr>
                        <td><%# Eval("UNAME") %></td>
                        <td><%# Eval("FIYAT") %></td>
                        <td><%# Eval("CODE") %></td>
                        <td><%# Eval("BRM_ADI") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                  </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
