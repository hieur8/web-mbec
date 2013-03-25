<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true" CodeBehind="active.aspx.cs" Inherits="MiBo.pages.cln.active" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">

    <p>
        <span id="yui_3_7_2_1_1364189277257_1951" 
            style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; float: none; color: rgb(77, 77, 77); display: inline !important;">
        Bạn đã đăng ký thành viên trên&nbsp;<a href="http://mibo.vn/" rel="nofollow" 
            style="text-decoration: underline; color: rgb(40, 98, 197); outline: 0px;" 
            target="_blank"><span id="lw_1364189276_0" class="yshortcuts">mibo.vn</span></a><span 
            class="Apple-converted-space">&nbsp;</span>thành công!</span><br 
            style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; color: rgb(77, 77, 77);" />
        <br style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; color: rgb(77, 77, 77);" />
        <span id="yui_3_7_2_1_1364189277257_1950" 
            style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; float: none; color: rgb(77, 77, 77); display: inline !important;">
        Bạn hãy kiểm tra email bạn vừa đăng ký để kích hoạt tài khoản và sử dụng các 
        dịch vụ của chúng tôi.</span><br 
            style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; color: rgb(77, 77, 77);" />
        <br style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; color: rgb(77, 77, 77);" />
        <span id="yui_3_7_2_1_1364189277257_1949" 
            style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; float: none; color: rgb(77, 77, 77); display: inline !important;">
        Lưu ý: Email kích hoạt có thể rơi vào bulk hoặc spam mail.</span><br 
            style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; color: rgb(77, 77, 77);" />
        <br style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; color: rgb(77, 77, 77);" />
        <span id="yui_3_7_2_1_1364189277257_1948" 
            style="font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); line-height: 18px; font-family: Arial, Tahoma; float: none; color: rgb(77, 77, 77); display: inline !important;">
        Nếu bạn có gì vướng mắc hãy liên lạc với chúng tôi qua mail: support@mibo.vn để được trợ 
        giúp. Xin cảm ơn.</span></p>

</asp:Content>
