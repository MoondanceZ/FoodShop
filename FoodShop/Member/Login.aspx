<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainFrame.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodShop.Member.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>用户登陆</title>
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnReg").click(function () {
                location.href = "Register.aspx";
            })
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main" class="entire_width">
        <div class="container_12">
            <div id="content">
                <div class="grid_12">
                    <h1 class="page_title">登陆账户</h1>
                </div>
                <!-- .grid_12 -->

                <div class="grid_6 new_customers">
                    <h2>新用户</h2>
                    <p>如果您还尚未拥有本站账户, 您可以点击注册按钮进行注册, 以便更好的使用本网站, 谢谢您的使用</p>
                    <div class="clear"></div>
                    <button id="btnReg" class="account">注册新账户</button>
                </div>
                <!-- .grid_6 -->

                <div class="grid_6">
                    <form class="registed" runat="server" method="post">
                        <input type="hidden" name="isPostBack" value="1" />
                        <h2>已注册用户</h2>

                        <p>如果您已经拥有一个账户, 请登录</p>

                        <div class="email">
                            <strong>帐号/邮箱:</strong><sup class="surely">*</sup><br />
                            <input type="text" name="txtLoginId" class="" value="" />
                        </div>
                        <!-- .email -->

                        <div class="password">
                            <strong>密码:</strong><sup class="surely">*</sup><br />
                            <input type="password" name="txtPwd" class="" value="" />
                            <a class="forgot" href="#">忘记密码?</a>
                        </div>
                        <!-- .password -->

                        <div class="remember">
                            <input class="niceCheck" type="checkbox" name="Remember_password" />
                            <span class="rem">记住我</span>
                        </div>
                        <!-- .remember -->

                        <div class="submit">
                            <input type="submit" value="登陆" />
                            <span><%= this.msg %></span>
                            <%--<sup class="surely">*</sup><span>Required Field</span>--%>
                        </div>
                        <!-- .submit -->
                    </form>
                    <!-- .registed -->
                </div>
                <!-- .grid_6 -->
            </div>
            <!-- #content -->

            <div class="clear"></div>
        </div>
        <!-- .container_12 -->
    </section>
    <!-- #main -->
</asp:Content>
