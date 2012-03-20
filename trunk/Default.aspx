<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Src="WUC_InforDestaque.ascx" TagName="WUC_InforDestaque" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>

    <script src="Scripts/Plugins/jcarousel/lib/jquery.jcarousel.js" type="text/javascript"></script>

    <script src="Scripts/Plugins/jcarousel/lib/jquery.jcarousel.pack.js" type="text/javascript"></script>

    <script src="Scripts/Plugins/Lightbox/js/jquery.lightbox-0.5.js" type="text/javascript"></script>

    <link href="Scripts/Plugins/jcarousel/lib/jquery.jcarousel.css" rel="stylesheet"
        type="text/css" />
    <link href="Scripts/Plugins/jcarousel/skins/tango/skin.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/Plugins/Lightbox/css/jquery.lightbox-0.5.css" rel="stylesheet"
        type="text/css" />

    <script type="text/javascript">

    function mycarousel_initCallback(carousel)
    {
        // Disable autoscrolling if the user clicks the prev or next button.
        carousel.buttonNext.bind('click', function() {
            carousel.startAuto(0);
        });

        carousel.buttonPrev.bind('click', function() {
            carousel.startAuto(0);
        });

        // Pause autoscrolling if the user moves with the cursor over the clip.
        carousel.clip.hover(function() {
            carousel.stopAuto();
        }, function() {
            carousel.startAuto();
        });
    };

    jQuery(document).ready(function() {
        jQuery('#mycarousel').jcarousel({
            auto: 2,
            wrap: 'last',
            initCallback: mycarousel_initCallback
        });
        jQuery("#mycarousel a").lightBox();
    });

    </script>
    
    <meta name="google-site-verification" content="a634R-Md2MA98bbd4MIf1sf6eqvUsN62B4325tmmml0" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="title">
        <asp:Label ID="LabelBanner" runat="server"></asp:Label>
        <p class="slogan">
            <asp:Label ID="LabelSlogan" runat="server" Text="Label"></asp:Label></p>
    </div>
    <h2 class="barraconteudo">
        Professores</h2>
    <div class="entry">
        <div id="wrap">
            <ul id="mycarousel" class="jcarousel-skin-tango">
                <asp:Repeater DataSourceID="DsPro" ID="Repeater1" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <li><a href='../HandlerImgs.ashx?imgpro=<%# Eval("pro_cod") %>&Tamanho=N' title='<%# Eval("pro_nome") %><br /><%# Eval("pro_sobre") %>'
                            style='text-decoration: none'>
                            <img alt='Clique aqui!' title='Professor(a) <%# Eval("pro_nome") %>' src='../HandlerImgs.ashx?imgpro=<%# Eval("pro_cod") %>&Tamanho=M'
                                border='0'></img></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <asp:ObjectDataSource ID="DsPro" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="SelecionaProfessoresDs" TypeName="Rwd.BLL.BusinessLogic">
                <SelectParameters>
                    <asp:Parameter DefaultValue="" Name="pro_cod" Type="Int32" />
                    <asp:Parameter DefaultValue="%" Name="pro_nome" Type="String" />
                    <asp:Parameter DefaultValue="" Name="pro_email" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>
    <p class="meta">
    </p>
    <div class="Section">
        <asp:Label ID="LabelPublicidade" runat="server"></asp:Label>
    </div>
    <p>
        &nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <uc1:WUC_InforDestaque ID="WUC_InforDestaque1" runat="server" />
</asp:Content>
