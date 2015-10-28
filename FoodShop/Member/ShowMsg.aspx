<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainFrame.Master" AutoEventWireup="true" CodeBehind="ShowMsg.aspx.cs" Inherits="FoodShop.Member.ShowMsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>信息显示</title>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //setInterval(function () {
            //    var timeStr = $("#time").html();
            //    if (timeStr > 1) {
            //        $("#time").html(--timeStr);
            //    }
            //}, 1000);            
            setTimeout(timeChange, 1000);
            function timeChange() {
                var timeStr = $("#time").html();
                var time = parseInt(timeStr);
                time--;
                if (time < 1) {
                    location.href = "<%= this.url%>";
                } else {
                    $("#time").html(time);
                    setTimeout(timeChange, 1000);
                }
            }
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_12">

        <h4>尊敬的<span style="font-size: 25px; font-weight:bolder"><%= this.userName %></span>用户,恭喜您<%= this.info %>,您将在
            <span id="time" style="font-size: 20px; color: red">5</span>秒后跳转到<a style="text-decoration: none" href="<%= this.url%>"><%= this.urlName %></a></h4>

    </div>
</asp:Content>
