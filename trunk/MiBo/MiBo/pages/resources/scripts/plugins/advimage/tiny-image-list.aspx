<%@ Page Language="C#" AutoEventWireup="true" Inherits="System.Web.UI.Page" %>

<% Response.ContentType = "text/javascript"; %>
<% string fn = Request["fn"]; %>
<% string path = string.Format("/pages/media/images/tinymce/", fn); %>
<% System.IO.DirectoryInfo folder = new System.IO.DirectoryInfo(Server.MapPath(path)); %>
<% System.IO.FileInfo[] files = folder.GetFiles(); %>

var tinyMCEImageList = new Array(
	// Name, URL
    <% int i = 0; %>
    <% foreach (var item in files) { %>
            <% if (i != 0) { %> , <% } %>
            ["<%= item.Name %>", "<%= path + item.Name%>"]
            <% i++; %>
    <% } %>
);
