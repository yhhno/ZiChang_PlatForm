<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="CollieryEdit.aspx.cs"
    Inherits="Colliery_CollieryEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css">
        .newPreview
        {
            filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);
            filters: ..item("DXImageTransform.Microsoft.AlphaImageLoader").src= "..//Images//NoPhoto.jpg";
            width: 400px;
            height: 200px;
        }
    </style>

    <script src="../../Js/js_webFormForModel.js" type="text/javascript"></script>

    <script src="../../Js/winModel.js" type="text/javascript"></script>

    <script src="../../Js/createHTML.js" type="text/javascript"></script>

    <script language="javascript" src="../../Js/drag.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        //预览图片
        // function PreviewImg(imgFile,divObj,imgName) {


        // var Preview = document.getElementById(divObj);
        // var img = document.getElementById(imgName);
        // try {
        //     img.style.display = "none";
        // }
        // catch (e) { }
        // Preview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile.value;
        // Preview.style.display = "block";

        // }

        //预览图片
        function PreviewImg(imgFile, divObj, imgName) {
            var photoStr = imgFile.value;
            var photoEx = photoStr.substring(photoStr.lastIndexOf(".")).toUpperCase();
            var str = ".JPG.BMP.GIF.PSD.PCX.PNG";
            var i = str.indexOf(photoEx);
            if (i == -1) {
                alert('您选择的不是图片文件，请重新选择!');
                return;
            }

            var Preview = document.getElementById(divObj);
            var img = document.getElementById(imgName);
            try {
                img.style.display = "none";
            }
            catch (e) { }
            Preview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile.value;
            Preview.style.display = "block";

        }

        //初始化预览图片
        function initPic() {
            try {
                var Preview1 = document.getElementById("Preview1");
                var Preview2 = document.getElementById("Preview2");
                var Preview3 = document.getElementById("Preview3");
                if (document.getElementById("hf_action").value == "edit") {
                    Preview1.style.display = "none";
                    Preview2.style.display = "none";
                    Preview3.style.display = "none";
                    return;
                }

                Preview1.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = "../../Images/NoPhoto.jpg";
                Preview2.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = "../../Images/NoPhoto.jpg";
                Preview3.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = "../../Images/NoPhoto.jpg";

            } catch (e) { }
        }
        
       
    </script>

</head>
<body style="background-color: #C7D6E9;" onload="initPic();">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="upDepartAdd" runat="server">
            <ContentTemplate>
                <div style="width: 100%; overflow: auto;">
                    <table style="width: 95%;">
                        <tr>
                            <td height="25" width="15%" align="right">
                                煤矿名称：
                            </td>
                            <td height="25" width="30%" align="left">
                                <%--  <asp:TextBox ID="txtCollCode" runat="server" Width="180px" MaxLength="20"></asp:TextBox><asp:Label
                                ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
                          <asp:RequiredFieldValidator ControlToValidate="txtCollCode" ID="RequiredFieldValidator2"
                                runat="server" ErrorMessage="煤矿编号不能为空" Display="None"></asp:RequiredFieldValidator>--%>
                                <asp:TextBox ID="txtCollName" runat="server" Width="180px" MaxLength="50"></asp:TextBox>
                                <span class="required">*</span>
                                <asp:RequiredFieldValidator ControlToValidate="txtCollName" ID="RequiredFieldValidator1"
                                    runat="server" ErrorMessage="煤矿名称不能为空" Display="None"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCollName"
                                    ErrorMessage="您输入的煤矿名称不能包含特殊字符" Display="None" ValidationExpression="^[^<>&/'\|\\]+$"></asp:RegularExpressionValidator>
                            </td>
                            <td height="25" width="15%" align="right">
                                煤矿状态：
                            </td>
                            <td height="25" width="30%" align="left">
                                <asp:DropDownList ID="ddlCollState" runat="server" Width="187px">
                                </asp:DropDownList>
                                <span class="required">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="15%" align="right">
                                所属乡镇：
                            </td>
                            <td height="25" width="30%" align="left">
                                <asp:DropDownList ID="ddlVillageCode" runat="server" Width="187px">
                                </asp:DropDownList>
                            </td>
                            <td height="25" width="15%" align="right">
                                所属煤管站：
                            </td>
                            <td height="25" width="30%" align="left">
                                <asp:DropDownList ID="ddlOrgID" runat="server" Width="187px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="15%" align="right">
                                煤矿法人：
                            </td>
                            <td height="25" width="30%" align="left">
                                <asp:TextBox ID="txtMineOwner" runat="server" MaxLength="20" Width="180px"></asp:TextBox>
                            </td>
                            <td height="25" width="15%" align="right">
                                煤矿电话：
                            </td>
                            <td height="25" width="30%" align="left">
                                <asp:TextBox ID="txtMinePhone" runat="server" MaxLength="20" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="15%" align="right">
                                煤矿年产量：
                            </td>
                            <td height="25" width="35%" align="left">
                                <asp:TextBox ID="txtYearOutput" runat="server" Width="180px" Text="0" MaxLength="10"></asp:TextBox>万吨<asp:RegularExpressionValidator
                                    ID="rgvNumber" runat="server" ControlToValidate="txtYearOutput" ErrorMessage="煤矿年产量输入格式不正确，只能为正的数值型"
                                    ValidationExpression="^[0-9]{0,}\.{0,1}[0-9]{0,}$" Display="None"></asp:RegularExpressionValidator>
                            </td>
                            <td height="25" width="15%" align="right">
                                煤矿属性：</td>
                            <td height="25" width="35%" align="left">
                                <asp:DropDownList ID="ddlCollProperty" runat="server" Width="187px">
                                </asp:DropDownList>
                                <span class="required">*</span>
                            </td>
                        </tr>
                        <tr runat="server" id="trParcel" visible="false">
                            <td align="right" height="25" width="15%">
                                所属片区：</td>
                            <td align="left" height="25" width="35%">
                                <asp:DropDownList ID="ddlParcel" runat="server" Width="187px">
                                </asp:DropDownList>
                                <span class="required">*</span>
                            </td>
                            <td align="right" height="25" width="15%">
                                &nbsp;</td>
                            <td align="left" height="25" width="35%">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td height="25" width="15%" align="right">
                                备注：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="3" Width="393"
                                    Height="60px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td height="25" width="15%" align="right">
                                是否禁用：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:DropDownList ID="ddlIsForbid" runat="server">
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="15%" align="right">
                                工商营业执照：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <img id="imgImageLicence" name="imgImageLicence" src="~/Images/NoPhoto.jpg" height="200"
                                    width="400" runat="server" />
                                <div id="Preview1" class="newPreview">
                                </div>
                                <input id="hidImageLicence" type="hidden" runat="server" />
                                <asp:FileUpload ID="fupImageLicence" Width="400px" runat="server" onkeydown="return false;"
                                    onchange="javascript:PreviewImg(this,'Preview1','imgImageLicence');" />
                        </tr>
                        <tr style="display: none;">
                            <td height="25" width="15%" align="right">
                                工商执照图片格式：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:TextBox ID="txtLicenceImageType" runat="server" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="15%" align="right">
                                税务登记证：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <img id="imgImageRevenue" name="imgImageLicence" src="~/Images/NoPhoto.jpg" height="200"
                                    width="400" runat="server">
                                <div id="Preview2" class="newPreview">
                                </div>
                                <input id="hidImageRevenue" type="hidden" runat="server" />
                                <asp:FileUpload ID="fupImageRevenue" runat="server" Width="400px" onkeydown="return false;"
                                    onchange="javascript:PreviewImg(this,'Preview2','imgImageRevenue');" />
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td height="25" width="15%" align="right">
                                税务登记证图片格式：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:TextBox ID="txtRevenueImageType" runat="server" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="15%" align="right">
                                煤炭经营资格：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <img id="imgImageCompetency" name="imgImageLicence" src="~/Images/NoPhoto.jpg" height="200"
                                    width="400" runat="server" />
                                <div id="Preview3" class="newPreview">
                                </div>
                                <input id="hidImageCompetency" type="hidden" runat="server" />
                                <asp:FileUpload ID="fupImageCompetency" runat="server" Width="400px" onkeydown="return false;"
                                    onchange="javascript:PreviewImg(this,'Preview3','imgImageCompetency');" />
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td height="25" width="15%" align="right">
                                煤炭经营资格图片格式：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:TextBox ID="txtCompetencyImageType" runat="server" Width="180px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4" style="height: 40px; width: 100%">
                                <asp:ImageButton ID="btn_Save" runat="server" ImageUrl="../Images/baocun.gif" OnClick="btn_Save_Click" />
                                &nbsp;&nbsp;<asp:ImageButton ID="btn_chongzhi" runat="server" ImageUrl="../Images/chongzhi.gif"
                                    OnClick="btn_chongzhi_Click" CausesValidation="false" />
                                &nbsp;&nbsp;<asp:ImageButton ID="btnCancel" runat="server" ImageUrl="../Images/close.gif"
                                    ValidationGroup="gr" OnClientClick="top.currForm.close();" />
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="hf_action" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" />
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_Save" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
