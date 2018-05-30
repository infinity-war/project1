<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="FirstProject.Display" %>

<% if (Session["username"] == null)
    {
        Response.Redirect("/Home/Login");
    }
%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>MDP Application</title>
    <link href="https://code.jquery.com/ui/1.10.3/themes/redmond/jquery-ui.css" rel="stylesheet" media="screen" />
    <!-- Bootstrap -->
    <link href="/Content/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- styles -->
    <link href="/Content/css/styles.css" rel="stylesheet" />
    <link href="/Content/customStyle.css" rel="stylesheet" />
</head>
<body>


    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="<%$RouteUrl:routename=default,controller=Home,action=Index%>" CssClass="navbar-brand">Application name</asp:HyperLink>

            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>
                        <asp:HyperLink ID="hypHome" runat="server" NavigateUrl="<%$RouteUrl:routename=default,controller=Home,action=Index%>">Home</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="<%$RouteUrl:routename=default,controller=Home,action=About%>">About</asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="<%$RouteUrl:routename=default,controller=Home,action=Contact%>">Contact</asp:HyperLink>
                    </li>

                    <%if (Session["username"] == null)
                        { %>
                    <li>
                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="<%$RouteUrl:routename=default,controller=Home,action=Login%>">Login</asp:HyperLink>
                    </li>
                    <% }
                        else
                        {%>
                    <li>
                        <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="<%$RouteUrl:routename=default,controller=Home,action=Logout%>">Logout  (  <%= Session["username"] %> )</asp:HyperLink>
                    </li>
                    <%  }%>
                </ul>
            </div>
        </div>
    </div>

    <div class="page-content" style="margin-top: 70px;">

        <div class="row">
            <div class="col-md-12">
                <div class="content-box-large" style="width: fit-content;">
                    <div class="panel-heading">
                        <div class="panel-title">Bootstrap dataTables</div>
                    </div>
                    <div class="panel-body">
                        <form id="form1" runat="server">
                            <div>

                                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                </asp:GridView>
                                <asp:Label ID="Label1" runat="server" CssClass="badge" Text="Sort by Lead Name"></asp:Label>
                                <asp:DropDownList ID="DropDownList1" CssClass="btn btn-default dropdown-toggle" runat="server" DataTextField="Fname" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="Label2" runat="server" CssClass="badge" Text="Sort By Lead Location"></asp:Label>
                                <asp:DropDownList ID="DropDownList2" CssClass="btn btn-default dropdown-toggle" runat="server" DataTextField="MobileNo" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView2"  CssClass="table table-striped table-bordered" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                                </asp:GridView>
                                <asp:Button ID="Button1" CssClass="btn" runat="server" OnClick="GetRecord_Click" Text="Get Records" />

                            </div>
                        </form>
                    </div>
                </div>

            </div>
        </div>


    </div>
    <link href="/Content/vendors/datatables/dataTables.bootstrap.css" rel="stylesheet" media="screen" />
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://code.jquery.com/jquery.js"></script>
    <!-- jQuery UI -->
    <script src="https://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="/Content/bootstrap/js/bootstrap.min.js"></script>
    <script src="/Content/vendors/datatables/js/jquery.dataTables.min.js"></script>
    <script src="/Content/vendors/datatables/dataTables.bootstrap.js"></script>
    <script src="/Content/js/custom.js"></script>
    <script src="/Content/js/tables.js"></script>


    <asp:PlaceHolder runat="server">
        <%: System.Web.Optimization.Scripts.Render("~/bundles/bootstrap") %>
        
      
    </asp:PlaceHolder>


    <footer class="footer">
        <div class="container">

            <div class="copy text-center">
                Copyright 2014 <a href='#'>Website</a>
            </div>

        </div>
    </footer>
</body>
</html>
