<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="FAQ.aspx.cs" Inherits="MiBo.pages.cln.FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript" src="../resources/scripts/utility.js"></script>
    <style type="text/css">
        .faqs
        {
            padding-top: 20px;
        }
        .faqs dt
        {
            font-weight: bold;
            background: url(../images/q.gif) 0 4px no-repeat;
            padding: 3px 0 15px 30px;
            position: relative;
        }
        .faqs dt:hover
        {
            cursor: pointer;
        }
        .faqs dd
        {
            background: url(../images/a.gif) 0 2px no-repeat;
            padding: 0 0 5px 30px;
            position: relative;
            color: #333;
        }
        .faqs .hover
        {
            color: #990000;
            text-decoration: underline;
        }
    </style>
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="page-title">
                    <h1>
                        FAQ</h1>
                </div>
                <br />
                <dl class="faqs">
                    <dt>Is this the first question?</dt>
                    <dd>
                        Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula
                        eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient
                        montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu,
                        pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla
                        vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a,
                        venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt.</dd>
                    <dt>If the previous was the first question this must be the second one. Isn't it?</dt>
                    <dd>
                        Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo,
                        rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis
                        pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean
                        vulputate eleifend tellus. Donec pede justo, fringilla vel, aliquet nec, vulputate
                        eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam
                        dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum
                        semper nisi. Aenean vulputate eleifend tellus.
                    </dd>
                    <dt>And what about the third question?</dt>
                    <dd>
                        Nam eget dui. Etiam rhoncus. Donec pede justo, fringilla vel, aliquet nec, vulputate
                        eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam
                        dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum
                        semper nisi. Aenean vulputate eleifend tellus. Maecenas tempus, tellus eget condimentum
                        rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Donec
                        pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus
                        ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium.
                        Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate
                        eleifend tellus. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu.
                        In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis
                        eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper
                        nisi. Aenean vulputate eleifend tellus.
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>
