<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainFrame.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="FoodShop.Member.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/demo.css" rel="stylesheet" />
    <style type="text/css">
        .reg {
            width: 200px; /**宽度**/
            height: 100px; /**高度**/
            position: absolute; /**绝对定位**/
            left: 50%; /**左边50%**/
            top: 50%; /**顶部50%**/
            margin-top: -50px; /**上移-50%**/
            margin-left: -100px; /**左移-50%**/
            border-radius: 10px;
            border: 3px solid Blue;
        }
    </style>
    <script src="../js/jquery-1.7.2.min.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
</asp:Content>
