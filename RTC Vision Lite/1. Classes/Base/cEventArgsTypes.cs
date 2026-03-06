using BrightIdeasSoftware;
//using CommonTools;
using RTC_Vision_Lite.UserControls;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public class RTCE_ActionDetailProperties_RowCellClickEventArgs : EventArgs
    {
        public MyPropertiesItem Node;
        public ucBaseActionDetail Base;
        public cAction action;
        public Guid IDRef;
        public ENodeTypes ActionType;
        public bool Enable;
        public string ActionName;
        public string Type;
        public string Value;
        public bool IsSytem;
        public EHTupleStyle ValueStyle;
        public OLVColumn CIDRef;
        public OLVColumn CActionType;
        public OLVColumn CEnable;
        public OLVColumn CActionName;
        public OLVColumn CType;
        public OLVColumn CValue;
        public OLVColumn CIsSystem;
        public TreeListView TreeList;
        public bool Success;
        public RTCE_ActionDetailProperties_RowCellClickEventArgs()
        {
            Base = null;
            Node = null;
            IDRef = Guid.Empty;
            ActionType = ENodeTypes.None;
            Enable = false;
            ActionName = string.Empty;
            Type = string.Empty;
            Value = string.Empty;
            ValueStyle = EHTupleStyle.None;
            CIDRef = null;
            CActionType = null;
            CEnable = null;
            CActionName = null;
            CType = null;
            CValue = null;
            Success = false;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
   

    public class RTCE_AddActionEventArgs : EventArgs
    {
        public EActionTypes ActionTypes;
        public RTCE_AddActionEventArgs()
        {
            ActionTypes = EActionTypes.None;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
       
       
    public class RTCE_CheckboxValueChangeEventArgs : EventArgs
    {
        public string PropertyName;
        public bool Value;
        public RTCE_CheckboxValueChangeEventArgs()
        {
            PropertyName = String.Empty;
            Value = false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    public class RTCE_SValueChangeEventArgs : EventArgs
    {
        public string PropertyName;
        public SListDouble Value;
        public SListObject ObjectValue;
        //public SListString ListStringValue;
        
        public RTCE_SValueChangeEventArgs()
        {
            PropertyName = String.Empty;
            Value = new SListDouble();
            ObjectValue = new SListObject();
           // ListStringValue = new SListString();
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class RTCE_ActionList_FocusedNodeChangedEventArgs : EventArgs
    {
        public ActionTools node;
        public ActionTools Oldnode;
        public cAction Action;
        public string PropertyLinkName;

        public RTCE_ActionList_FocusedNodeChangedEventArgs()
        {
            node = null;
            Action = null;
            PropertyLinkName = string.Empty;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class RTCE_ButtonLinkClickEventArgs : EventArgs
    {
        public string PropertyName;

        public RTCE_ButtonLinkClickEventArgs()
        {
            PropertyName = string.Empty;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class RTCE_ButtonRemoveLinkClickEventArgs : EventArgs
    {
        public string PropertyName;
        public bool Success;

        public RTCE_ButtonRemoveLinkClickEventArgs()
        {
            PropertyName = string.Empty;
            Success = false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
    public class RTCE_StringBuilderItem_RowCellClickEventArgs : EventArgs
    {
        public ucBaseActionDetail Base;
        public ucStringBuilderDetail View;
        public MyPropertiesItem Node;
        public cAction Action;
        public PropertyInfo PropertyInfo;
        public SStringBuilderItem SBItem;

        public OLVColumn cActionName;
        public OLVColumn CEnable;
        public OLVColumn CValue;
        public OLVColumn CIDRef;
        public TreeListView treeList;
        public int DataItemParentIndex;
        public int DataItemIndex;
        public RTCE_StringBuilderItem_RowCellClickEventArgs()
        {
            View = null;
            PropertyInfo = null;
            Node = null;
            SBItem = null;
            Action = null;
            CEnable = null;
            CValue = null;
            CIDRef = null;
            treeList = null;
            DataItemIndex = -1;
            DataItemParentIndex = -1;

        }    
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
    public class RTCE_CsvWrite_RowCellClickEventArgs : EventArgs
    {
        public ucCsvWriteActionDetail View;
        public TreeListView TreeList;
        public cAction Action;
        public cColumnProperty ColumnProperty;
        public CSVWrite ColumnPropertyNode;
        public OLVColumn IdColumn;
        public OLVColumn ValueColumn;
        public OLVColumn EnableColumn;
    }
    public class RTCE_ExcelWrite_RowCellClickEventArgs : EventArgs
    {
        public ucExcelWriteActionDetail View;
        public TreeListView TreeList;
        public cAction Action;
        public cColumnProperty ColumnProperty;
        public CSVWrite ColumnPropertyNode;
        public OLVColumn IdColumn;
        public OLVColumn ValueColumn;
        public OLVColumn EnableColumn;
    }
    public class RTCE_PictureSelectedEventArgs : EventArgs
    {
        public cImage RTCImage;
        //public RTCE_AddActionEventArgs()
        //{
        //    ActionType = EActionTypes.None;
        //}
        //public void Dispose()
        //{
        //    GC.SuppressFinalize(this);
        //}
    }
}
