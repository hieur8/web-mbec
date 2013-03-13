<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload-image.aspx.cs" Inherits="MiBo.pages.administer.upload_image" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" class="no-js">
<head runat="server">
    <meta charset="utf-8">
    <title>Tải lên hình ảnh</title>
    <!--[if lt IE 9]>
        <script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/themes/base/jquery-ui.css" id="theme" />
    <link rel="stylesheet" href="/pages/resources/styles/jquery.fileupload-ui.css" />
    <style type="text/css">
        body
        {
            font-family: Verdana, Arial, sans-serif;
            font-size: 13px;
            margin: 0;
            padding: 20px;
        }
        a
        {
            color: #222;
        }
    </style>
</head>
<body>
    <div id="fileupload">
        <form action='/pages/handler/UploadImageHandler.ashx<%= "?g=" + Request["g"] + "&p=" + Request["p"] %>' method="post" enctype="multipart/form-data">
        <div class="fileupload-buttonbar">
            <label class="fileinput-button">
                <span>Add files...</span>
                <input type="file" name="files[]" multiple="multiple" />
            </label>
            <button type="button" class="delete button">
                Delete all files</button>
            <div class="fileupload-progressbar">
            </div>
        </div>
        </form>
        <div class="fileupload-content">
            <table class="files">
            </table>
        </div>
    </div>
    <script id="template-upload" type="text/x-jquery-tmpl">
    <tr class="template-upload{{if error}} ui-state-error{{/if}}">
        <td class="preview"></td>
        <td class="name">${Name}</td>
        <td class="size">${Sizef}</td>
        {{if error}}
            <td class="error" colspan="2">Error:
                {{if error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="progress"><div></div></td>
            <td class="start"><button>Start</button></td>
        {{/if}}
        <td class="cancel"><button>Cancel</button></td>
    </tr>
    </script>
    <script id="template-download" type="text/x-jquery-tmpl">
    <tr class="template-download{{if error}} ui-state-error{{/if}}">
        {{if error}}
            <td></td>
            <td class="name">${Name}</td>
            <td class="size">${Sizef}</td>
            <td class="error" colspan="2">Error:
                {{if error === 1}}File exceeds upload_max_filesize (php.ini directive)
                {{else error === 2}}File exceeds MAX_FILE_SIZE (HTML form directive)
                {{else error === 3}}File was only partially uploaded
                {{else error === 4}}No File was uploaded
                {{else error === 5}}Missing a temporary folder
                {{else error === 6}}Failed to write file to disk
                {{else error === 7}}File upload stopped by extension
                {{else error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else error === 'uploadedBytes'}}Uploaded bytes exceed file size
                {{else error === 'emptyResult'}}Empty file upload result
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="preview">
                {{if ThumbnailUrl}}
                    <a href="${Url}" target="_blank"><img widht="64" height="64" src="${ThumbnailUrl}"></a>
                {{/if}}
            </td>
            <td class="name">
                <a href="${Url}"{{if ThumbnailUrl}} target="_blank"{{/if}}>${Name}</a>
            </td>
            <td class="size">${Sizef}</td>
            <td colspan="2"></td>
        {{/if}}
        <td class="delete">
            <button data-type="${DeleteType}" data-url="${DeleteUrl}">Delete</button>
        </td>
    </tr>
    </script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.13/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../resources/scripts/jquery.tmpl.min.js" type="text/javascript"></script>
    <script src="/pages/resources/scripts/jquery.iframe-transport.js" type="text/javascript"></script>
    <script src="/pages/resources/scripts/jquery.fileupload.js" type="text/javascript"></script>
    <script src="/pages/resources/scripts/jquery.fileupload-ui.js" type="text/javascript"></script>
    <script src="/pages/resources/scripts/jquery.fileupload.app.js" type="text/javascript"></script>
</body>
</html>
