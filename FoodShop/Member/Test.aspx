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
    <div id="ts" style="width:800px; height:600px;background-color:blue">
        <h1>111111111111111111111111111111</h1>
    </div>
    <%--<div class="reg">
        <button id="notification-trigger" class="progress-button">
        </button>
        
    </div>--%>
    <input type="button" value="tijiao111" id="bt1" runat="server" onclick="bt1Click()" />
    <script type="text/javascript">
        function bt1Click() {
            $("body").css("background-color","red")
            //alert('123213123');
        }
    </script>
    
</asp:Content>
