using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RTC_Vision_Lite.Classes
{
    #region
    public delegate void PropertyValueChanged(string name);
    #endregion
    #region "cGroupActions"
    public delegate void ImageSourceTypeChanged(object sender, EventArgs e);
    public delegate void CameraLiveAndConnectChanged(object sender, EventArgs e);
    #endregion

    #region "BaseActionDetail"
    public delegate void PropertiesRowCellClick(object sender, RTCE_ActionDetailProperties_RowCellClickEventArgs e);
    public delegate void ImageLink_ButtonLinkClickEvent(object sender, RTCE_ButtonLinkClickEventArgs e);
    public delegate void SetActionEvent(object sender, EventArgs e);
    public delegate void ButtonClickEvents(object sender, EventArgs e);
    public delegate void SetOutPutProppertyActionChangeEvent(object sender, EventArgs e);
    public delegate void StringBuilderDetail_BtnLinkClickEvent(object sender, RTCE_StringBuilderItem_RowCellClickEventArgs eRTC);
    public delegate void StringBuilderDetail_BtnRemoveLinkClickEvent(object sender, RTCE_StringBuilderItem_RowCellClickEventArgs eRTC);
    public delegate void CsvWriteDetail_BtnLinkValueClickEvent(object sender, RTCE_CsvWrite_RowCellClickEventArgs e);
    public delegate void ExcelWriteDetail_BtnLinkValueClickEvent(object sender, RTCE_ExcelWrite_RowCellClickEventArgs e);
    #endregion

    #region "ucTemplateTools"
    public delegate void AddAction(object sender, RTCE_AddActionEventArgs e);
    #endregion

    #region UCLINK
    public delegate void ButtonLinkClickEvent(object sender, RTCE_ButtonLinkClickEventArgs e);
    public delegate void ButtonRemoveLinkClickEvent(object sender, RTCE_ButtonRemoveLinkClickEventArgs e);
    public delegate void TextBoxValueChanged(TextBox txtEdit);
    #endregion

    public delegate void ComboSelectedIndexChanged(int selectedIndex = -1);
    public delegate void TextBoxValueChanged1(string propName, string value);
    public delegate void ProgramNameValueChanged(string propName, string value, bool isMultiChoose = true);
    public delegate void ToolNameComboboxValueChanged(string propName, string toolName, Guid toolID);
    public delegate void FontInfoValueChanged(string fontInfo, string infoName = "");
    public delegate void ReceiveDataEvents(string _Data);
    public delegate void ColorComboboxValueChanged(string propName, string value);

    #region ORIGIN
    public delegate void ButtonLinkEndSelectedPropertyLinkEvent(Guid groupID, Guid actionID, string propertyname);
    #endregion
    class cDelegateEvents
    {
    }
}
