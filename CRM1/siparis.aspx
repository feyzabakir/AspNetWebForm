<%@ Page Language="C#" MasterPageFile="~/etiaret.Master" AutoEventWireup="true" CodeBehind="siparis.aspx.cs" Inherits="CRM1.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #customers {
            font-family: Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            #customers td, #customers th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #customers tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #customers tr:hover {
                background-color: #ddd;
            }

            #customers th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #04AA6D;
                color: white;
            }

        ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            background-color: #34495e;
        }

        li {
            display: inline-block;
        }

            li a {
                display: block;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

                li a:hover {
                    background-color: #f39c12;
                }

        ul li ul {
            background-color: #2c3e50;
            display: none;
            position: absolute;
            width: 100px
        }

        ul li:hover ul {
            display: block;
        }

        li ul li {
            display: block;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float: right">
        <asp:Button ID="Button1" runat="server" Text="Anasayfaya Dön" CssClass="btn btn-outline-info" OnClick="Button1_Click" />
    </div>
    <div>
        <table id="customers" class="table table-bordered">
            <thead>
                <tr>
                    <th>Ürün</th>
                    <th>Sipariş No</th>
                    <th>Fiyat</th>
                    <th>Miktar</th>
                    <th>Toplam Tutar</th>

                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rpt_sipler" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("UName")  %></td>
                            <td><%# Eval("SIP_NO")  %></td>
                            <td><%# Eval("FIYAT")  %></td>
                            <td><%# Eval("MIKTAR")  %></td>
                            <td><%# Eval("TOPLAM")  %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td style="float: right"><strong>Toplam:</strong></td>
                    <td>
                        <asp:Label ID="lbl_toplam" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>

