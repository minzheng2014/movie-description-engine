<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailsPage.aspx.cs" Inherits="Project_5.DetailsPage" %>

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
    <div>
        <asp:Button ID="btnReturn" class="btn btn-primary" runat="server" Text="Return" PostBackUrl="~/Search_Movies.aspx" />
        <br />
    </div>
    <div id="display" runat="server">
    </div>
    </form>
</body>
</html>
