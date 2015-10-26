<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainFrame.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FoodShop.Member.Register" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script>
        $(function () {
            $("#btnLogin").click(function () {
                location.href = "Login.aspx";
            });
            $("#vCodeImg").click(function () {
                var oldSrc = $(this).attr("src");
                oldSrc += new Date().toString();
                $(this).attr("src", oldSrc);
            });

            //验证用户名

            $("#txtName").blur(function () {
                if ($(this).val().lenth > 12 || $(this).val().length < 6) {
                    $(this).siblings("span").css("color", "red");
                } else {
                    $(this).siblings("span").css("color", "black");
                }
            });


            //验证邮箱
            $("#txtEmail").blur(function () {
                var checkEmail = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;
                if (!checkEmail.test($(this).val())) {
                    $(this).siblings("span").html("请输入正确的邮箱").css("color", "red");
                } else {
                    $(this).siblings("span").html("");
                }
            });

            //验证电话号码
            $("#txtTel").blur(function () {
                var checkTel = /^1[3|4|5|7|8][0-9]\d{4,8}$/;
                if (!checkTel.test($(this).val())) {
                    $(this).siblings("span").html("请输入正确的手机号码").css("color", "red");
                } else {
                    $(this).siblings("span").html("");
                }
            });

            //验证密码
            $("#txtPwd").blur(function () {
                if ($(this).val().lenth > 12 || $(this).val().length < 6) {
                    $(this).siblings("span").css("color", "red");
                } else {
                    $(this).siblings("span").css("color", "black");
                }
            })

            //验证确认密码
            $("#chkPwd").blur(function () {
                if ($(this).val() != $("#txtPwd").val()) {
                    $(this).siblings("span").html("两次密码输入不同,请重新输入").css("color", "red");
                } else {
                    $(this).siblings("span").html("");
                }
            })

            //验证验证码           
            $("#txtCode").blur(function () {
                var vCode = $(this).val();
                $.post("../ashx/CheckVCode.ashx", { vCode: vCode }, function (data) {
                    if (data == "Error") {
                        $("#txtCode").siblings("span").html("验证码输入错误").css("color", "red");
                    } else {
                        $("#txtCode").siblings("span").html("");
                    }
                })
                return false;
            })

            $("#btnReg").click(function () {
                //用户名
                if ($("#txtName").siblings("span").css("color") == "rgb(255, 0, 0)") {
                    return false;
                }
                //邮箱
                if ($("#txtEmail").siblings("span").html() != "") {
                    return false;
                }
                //电话
                if ($("#txtTel").siblings("span").html() != "") {
                    return false;
                }
                //密码
                if($("#txtPwd").siblings("span").css("color") == "rgb(255, 0, 0)") {
                    return false;
                }
                //确认密码
                if ($("#chkPwd").siblings("span").html() != "") {
                    return false;
                }
                //验证码
                if ($("#txtCode").siblings("span").html() != "") {
                    return false;
                }               
            })            
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container_12">
        <div id="content">
            <div class="grid_12">
                <h1 class="page_title">新用户注册</h1>
            </div>
            <!-- .grid_12 -->

            <div class="grid_6 new_customers">
                <h2>尊敬的用户:</h2>
                <p>欢迎注册美食网站, 如果你已经拥有一个账户, 可以直接登陆哦.</p>
                <div class="clear"></div>
                <button class="account" id="btnLogin">登陆现有账户</button>
            </div>
            <!-- .grid_6 -->

            <div class="grid_6">
                <form class="registed" runat="server">
                    <h2>请输入注册信息</h2>
                    <div class="name">
                        <strong>用户名:</strong><sup class="surely">*</sup><span>请输入6~12位字符</span><br />
                        <input type="text" name="txtName" id="txtName" />
                    </div>

                    <div class="email">
                        <strong>邮  箱:</strong><sup class="surely">*</sup><span></span><br />
                        <input type="email" name="txtEmail" id="txtEmail" class="" value="" />
                    </div>
                    <!-- .email -->

                    <div class="telephone">
                        <strong>手  机:</strong><sup class="surely">*</sup><span></span><br />
                        <input type="text" name="txtTel" id="txtTel" class="" value="" />
                    </div>
                    <!-- .telephone -->

                    <div class="password">
                        <strong>密  码:</strong><sup class="surely">*</sup><span>请输入6~12位字符</span><br />
                        <input type="password" name="txtPwd" id="txtPwd" class="" value="" />
                    </div>
                    <!-- .password -->

                    <div class="Checkpassword">
                        <strong>确认密码:</strong><sup class="surely">*</sup><span></span><br />
                        <input type="password" name="chkPwd" id="chkPwd" class="" value="" />
                    </div>
                    <!-- .Chkpassword -->

                    <div class="ValidateCode">
                        <strong>验证码:</strong><sup class="surely">*</sup><span></span><br />
                        <input type="text" name="txtCode" id="txtCode" class="" value="" />
                        <img id="vCodeImg" style="padding-left: 20px" src="../ashx/ValidateCode.ashx?id=3" />
                    </div>

                    <div class="submit">
                        <input type="submit" value="注册" id="btnReg" />
                        <sup class="surely">*</sup><span>必填</span>
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
</asp:Content>
