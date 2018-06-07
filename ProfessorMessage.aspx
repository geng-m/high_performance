<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfessorMessage.aspx.cs"
    Inherits="DeviceMessage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>工程院院士信息查询</title>
    <link href="resource/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="resource/css/gridview.css" rel="stylesheet" type="text/css" />
    <link href="resource/css/style.css" rel="stylesheet" type="text/css" />
    <link href="resource/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="resource/themes/gray/easyui.css" rel="stylesheet" type="text/css" />
    <script src="resource/js/jquery.min.js" type="text/javascript"></script>
    <script src="resource/js/jquery.easyui.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="resource/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="resource/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="resource/css/demo.css" />
    <link rel="stylesheet" type="text/css" href="resource/css/style.css">
    <script type="text/javascript" src="resource/js/jquery.min.js"></script>
    <script type="text/javascript" src="resource/js/jquery.easyui.min.js"></script>
</head>
<body class="easyui-layout">
    <div style="background-color:#5588AA; float: left; width: 13%; height: 100%">
        <ul>
            <li style="width: 193px; height: 20px"></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorMessage.aspx"
                target="right" title="院士综合信息查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士综合信息查询</h1>
            </a></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorStatic.aspx"
                target="right" title="院士统计信息查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士统计信息查询</h1>
            </a></li>
             <li style="width: 193px; height: 100px"><a href="ProfessorStaticDetails.aspx" target="right"
                title="院士统计detail查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士统计信息查询_1</h1>
            </a></li>
            <li style="width: 193px; height: 100px"><a href="ProfessorStaticDetails_1.aspx" target="right"
                title="院士统计detail查询">
                <h1 style="font-family: 微软雅黑; font-size: 20px">
                    院士统计信息查询_2</h1>
            </a></li>
        </ul>
    </div>
    <div id="p" title="院士信息查询" style="overflow: hidden; padding: 0px; float: right; width: 85%;
        position: relative; top: 20px; right: 5px">
        <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="line-height: 25px; margin-top: -4px; border-top-width: 1px; border-right: gainsboro 1px solid;
                    border-left: gainsboro 1px solid; border-top-color: gainsboro; border-bottom: gainsboro 1px solid;"
                    dir="ltr">
                    <asp:GridView ID="Gvlist" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        DataKeyNames="Id" CssClass="Check" BackColor="White" BorderColor="#999999" GridLines="None"
                        Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="院士ID" SortExpression="Id">
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="姓名"></asp:BoundField>
                            <asp:BoundField DataField="Birthday" HeaderText="出生日期"></asp:BoundField>
                            <asp:BoundField DataField="Gender" HeaderText="性别"></asp:BoundField>
                            <asp:BoundField DataField="Jiguan" HeaderText="籍贯"></asp:BoundField>
                            <asp:BoundField DataField="Unit" HeaderText="单位"></asp:BoundField>
                            <asp:BoundField DataField="Major" HeaderText="专业" />
                            <asp:BoundField DataField="HightestE" HeaderText="学位" />
                            <asp:BoundField DataField="AwardTime" HeaderText="获称时间" />
                            <asp:BoundField DataField="Abord" HeaderText="是否出国" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                    <font>
                        </font>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: right; height: 40px; margin-right: 0px; border: gainsboro 1px solid">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageIndexBoxType="TextBox"
                SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" FirstPageText="首页"
                LastPageText="末页" NextPageText="下一页&gt;" PageSize="10" PrevPageText="&lt;上一页"
                AlwaysShow="True" CssClass="anpager" CurrentPageButtonClass="cpb" SubmitButtonClass="goo"
                ShowBoxThreshold="1" NumericButtonCount="2" EnableViewState="False" OnPageChanging="AspNetPager1_PageChanging">
            </webdiyer:AspNetPager>
        </div>
        </form>
    </div>
</body>
</html>
