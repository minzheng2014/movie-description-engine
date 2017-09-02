<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search_Movies.aspx.cs" Inherits="Project_5.Search_Movies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Movies</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"  rel="stylesheet">
    <style type="text/css">
        form {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="form-group row">
        <div class="col-sm-1">
            <asp:Label ID="lblSearch" class="control-label" runat="server" Text="SEARCH"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox ID="tbxSearch" class="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-4">
            <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click" />
            <br />
        </div>
    </div>
    <div id="display" class="container-fluid row" runat="server"></div>
    </form>
</body>
</html>
