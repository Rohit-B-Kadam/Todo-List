<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="/Content/bootstrap.css" rel="stylesheet" />
    <link href="/Content/Site.css" rel="stylesheet" />
    <style type="text/css">
        body {
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #eee;
        }

        .form-signin {
            max-width: 330px;
            padding: 15px;
            margin: 0 auto;
        }

            .form-signin .form-control {
                position: relative;
                height: auto;
                -webkit-box-sizing: border-box;
                -moz-box-sizing: border-box;
                box-sizing: border-box;
                padding: 10px;
                font-size: 16px;
            }

                .form-signin .form-control:focus {
                    z-index: 2;
                }
    </style>
</head>
<body>

    <div class="container">

        <form class="form-signin" id="form1" runat="server">
            <h2 class="form-signin-heading">Login ToDo App</h2>
            <br />
            <div class="form-group">
                <label for="TxtEmail">Email address:</label>
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Please Enter Username" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Email Invalid" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group">
                <label for="TxtPassword">Password:</label>
                <asp:TextBox ID="TxtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPassword" ErrorMessage="Please Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>

            </div>
            <div class="form-group">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"
                    CssClass="btn btn-lg btn-primary btn-block" Text="Login" />
            </div>
            <div style="text-align: right">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/View/Authentication/Registration.aspx">Create new Account</asp:HyperLink>
            </div>

            <asp:Label ID="LblShowErrorMessage" runat="server" Text="" CssClass="alert-danger"></asp:Label>

        </form>
    </div>
    <!-- /container -->


</body>
</html>
