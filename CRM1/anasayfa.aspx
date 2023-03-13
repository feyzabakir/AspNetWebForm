<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="CRM1.anasayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        h3{
            color:red;
            text-align:center;
        }
     
    </style>
    <h3>Hoşgeldiniz</h3>
    <br />

    <div style="text-align:center">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

       <ContentTemplate>
           <asp:Timer ID="Timer1" runat="server" Interval="2000"></asp:Timer>
           <asp:Label ID="Label1" runat="server"></asp:Label> <br />
       </ContentTemplate>


        </asp:UpdatePanel> 
        <br />
         <asp:Button ID="Button2" runat="server" CssClass="btn btn-outline-danger" Text="Geri" OnClick="Button2_Click" /> 
        <asp:Button ID="Button1" runat="server" CssClass="btn btn-outline-danger" Text="İleri" OnClick="Button1_Click" />
         

    </div>
  
       
</asp:Content>

