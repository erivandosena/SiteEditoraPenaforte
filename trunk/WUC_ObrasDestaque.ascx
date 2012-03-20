<script src="Scripts/Plugins/jscroller/jscroller-0.4.js" type="text/javascript"></script>
<script src="Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function() {
        // Add Scroller Object
        $jScroller.add("#scroller_container", "#scroller", "up", 1);
        // Start Autoscroller
        $jScroller.start();
    });
</script>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WUC_ObrasDestaque.ascx.cs" Inherits="WUC_ObrasDestaque" %>

<ul>
    <li>
        <h2>
            Obras</h2>
    </li>
</ul>
<div id="scroller_container" style="position:relative;overflow:hidden;width:250px;height:640px">
<div id="scroller">
<ul>
    <asp:DataList ID="DataListInfo" runat="server" DataSourceID="DsObra" EnableViewState="False"
        ShowFooter="False" ShowHeader="False">
        <ItemTemplate>
            <li>
                <div id="calendar">
                
                    <a href="<%# Eval("obr_cod", "Escritor.aspx?o={0}") %>">
                    <div style="text-align:center;text-decoration:none;padding:5px 0">
                    <p style="text-align:center"><%# Eval("obr_titulo")%></p>
                    <br />
                    <img alt="IEP - Obra do Escritor" border="0" src='../HandlerImgs.ashx?imgobr=<%# Eval("obr_cod") %>&amp;tamanhocapa=M' />
                    </div>
                    </a>
                </a>
                </div>  
            </li>
        </ItemTemplate>
    </asp:DataList>
</ul>
</div>
</div>
     <div>
        [+]<a href="/ObrasAutor.aspx" title="Clique aqui">Todas as obras do escritor</a>
    </div>

<p>
</p>
<asp:ObjectDataSource ID="DsObra" runat="server" SelectMethod="SelecionaObrasDs"
    TypeName="Rwd.BLL.BusinessLogic" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter DefaultValue="" Name="obr_cod" Type="Int32" />
        <asp:Parameter DefaultValue="%" Name="obr_titulo" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>