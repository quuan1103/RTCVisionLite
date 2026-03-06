using CommonTools;
using RTC_Vision_Lite.Classes;
using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC_Vision_Lite.Forms
{
    public partial class frmSetupPassed : FrmBase
    {
        public frmSetupPassed()
        {
            InitializeComponent();
        }
        #region PROPERTIES
        private bool _RTCSetupPassed;
        public class SetupROI
        {
            public long ID { get; set; }
            public bool Active { get; set; }
            public string Name { get; set; }
            public double X { get; set; }
            public double Y { get; set; }
            public bool NeedPass { get; set; }
            public string Type { get; set; }
            public bool IsDisplayOutput { get; set; } 
        }
        public bool RTCSetupPassed
        {
            get => _RTCSetupPassed;
            set
            {
                _RTCSetupPassed = value;
                if (_RTCSetupPassed)
                {
                    Text = cStrings.SetupPassed;
                }
                else
                {
                    Text = cStrings.ApplyPropertiesToOTherROIs;
                    colActive.Text = cStrings.Choose;
                    colName.IsEditable = false;
                    colNeedPassed.IsVisible = false;
                    colIsDisplayOutput.IsVisible = false;
                    colNeedPassed.Width = 0;
                    colIsDisplayOutput.Width = 0;
                    chkNeedPass.Visible = false;
                    chkViewOutput.Visible = false;
                }
            }
        }

        private cAction _Action;

        public cAction Action
        {
            get => _Action;
            set
            {
                _Action = value;
                PreviewData();
            }
        }
        #endregion
        #region FUNCTIONS

        /// <summary>Preview data.</summary>
        /// <remarks>NTH, 09-08-2024.</remarks>

        private void PreviewData()
        {
            try
            {
                GlobVar.LockEvents = true;
                tlSetup.ClearObjects();
                if (Action == null)
                    return;
                foreach (cDrawingBaseType _ROI in Action.ROIs.Values)
                {
                    cROIProperty roiProperty = null;
                    if (Action.ROIProperties != null)
                        Action.ROIProperties.TryGetValue(_ROI.ID, out roiProperty);
                    if (roiProperty != null)
                    {
                        SetupROI newNode = new SetupROI();
                        newNode.ID = _ROI.ID; ;
                        newNode.Active = roiProperty.Active;
                        newNode.Name = _ROI.Name;
                        newNode.X = _ROI.Center.Col;
                        newNode.Y = _ROI.Center.Row;
                        newNode.NeedPass = roiProperty.RequiredPass.rtcValue;
                        newNode.Type = Enum.GetName(typeof(EDrawingtypes), _ROI.DrawingType);
                        newNode.IsDisplayOutput = _ROI.IsDisplayOutPut;
                        tlSetup.AddObject(newNode);
                    }    
                    else
                    {
                        SetupROI newNode = new SetupROI();
                        newNode.ID = _ROI.ID; ;
                        newNode.Active = true;
                        newNode.Name = _ROI.Name;
                        newNode.X = _ROI.Center.Col;
                        newNode.Y = _ROI.Center.Row;
                        newNode.NeedPass = true;
                        newNode.Type = Enum.GetName(typeof(EDrawingtypes), _ROI.DrawingType);
                        newNode.IsDisplayOutput = _ROI.IsDisplayOutPut;
                        tlSetup.AddObject(newNode);
                    }    
                      
                }
                tlSetup.ExpandAll();
            }
            finally
            {
                GlobVar.LockEvents = false;
                SetCheckActiveTrueFalse();
                SetCheckNeedPassedTrueFalse();
                SetCheckViewOutputTrueFalse();
            }
        }
        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            GlobVar.LockEvents = true;
            foreach (object node in tlSetup.Objects)
                if (colActive.GetValue(node) != null)
                    colActive.PutValue(node, chkActive.Checked);
            GlobVar.LockEvents = false;
        }

        private void chkNeedPass_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            foreach (object node in tlSetup.Objects)
                if (colNeedPassed.GetValue(node) != null)
                    colNeedPassed.PutValue(node, chkNeedPass.Checked);
        }

        private void chkViewOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            foreach (object node in tlSetup.Objects)
                if (colIsDisplayOutput.GetValue(node) != null)
                    colIsDisplayOutput.PutValue(node, chkViewOutput.Checked);
        }
        private void tlSetup_SubItemChecking(object sender, BrightIdeasSoftware.SubItemCheckingEventArgs e)
        {
            if (GlobVar.LockEvents)
                return;
            if (tlSetup.FocusedObject == null)
                return;
            if (e.Column == colActive)
                SetCheckActiveTrueFalse(true);
            else if (e.Column == colNeedPassed)
                SetCheckNeedPassedTrueFalse(true);
            else if (e.Column == colIsDisplayOutput)
                SetCheckViewOutputTrueFalse(true);
        }
        private void SetCheckActiveTrueFalse(bool setFocusedNodeValue = false)
        {
            GlobVar.LockEvents = true;
            if (setFocusedNodeValue && tlSetup.FocusedObject != null)
                colActive.PutValue(tlSetup.FocusedObject, !(bool)colActive.GetValue(tlSetup.FocusedObject));

            foreach (SetupROI node in tlSetup.Objects.Cast<SetupROI>().ToList())
                if (node.Active != null)
                    if (!node.Active)
                    {
                        chkActive.Checked = false;
                        GlobVar.LockEvents = false;
                        return;
                    }

            chkActive.Checked = true;
            GlobVar.LockEvents = false;
        }

        private void SetCheckNeedPassedTrueFalse(bool setFocusedNodeValue = false)
        {
            GlobVar.LockEvents = true;
            if (setFocusedNodeValue && tlSetup.FocusedObject != null)
                colNeedPassed.PutValue(tlSetup.FocusedObject, !(bool)colNeedPassed.GetValue(tlSetup.FocusedObject));

            foreach (SetupROI node in tlSetup.Objects.Cast<SetupROI>().ToList())
                if (node.NeedPass != null)
                    if (!node.NeedPass)
                    {
                        chkNeedPass.Checked = false;
                        GlobVar.LockEvents = false;
                        return;
                    }

            chkNeedPass.Checked = true;
            GlobVar.LockEvents = false;
        }

        private void SetCheckViewOutputTrueFalse(bool setFocusedNodeValue = false)
        {
            GlobVar.LockEvents = true;
            if (setFocusedNodeValue && tlSetup.FocusedObject != null)
                colIsDisplayOutput.PutValue(tlSetup.FocusedObject, !(bool)colIsDisplayOutput.GetValue(tlSetup.FocusedObject));

            foreach (SetupROI node in tlSetup.Objects.Cast<SetupROI>().ToList())
                if (node.IsDisplayOutput != null)
                    if (!node.IsDisplayOutput)
                    {
                        chkNeedPass.Checked = false;
                        GlobVar.LockEvents = false;
                        return;
                    }

            chkNeedPass.Checked = true;
            GlobVar.LockEvents = false;
        }

        private void Process_ApplyProperties()
        {
            List<SetupROI> AllNode = tlSetup.Objects.Cast<SetupROI>().ToList();
            if (AllNode != null && AllNode.Count > 0)
            {
                cROIProperty ROISelect = null;
                ROISelect = Action.ROIProperties.Values.FirstOrDefault(x => x.Selected);
                if (ROISelect == null) return;
                foreach (SetupROI _Node in AllNode)
                    if (_Node.Active != null)
                        if (_Node.Active)
                        {
                            long _ID = _Node.ID;
                            cROIProperty _ROIp = Action.ROIProperties[_ID];
                            Action.CopyROIProperties(ROISelect, _ROIp);
                        }
            }
        }
        private void Process_SetupPassed()
        {
            List<SetupROI> AllNode = tlSetup.Objects.Cast<SetupROI>().ToList();
            if (AllNode != null && AllNode.Count > 0)
                foreach (SetupROI _Node in AllNode)
                {
                    long _ID = _Node.ID;
                    Action.ROIProperties.TryGetValue(_ID, out cROIProperty _ROIp);
                    if (_ROIp != null)
                    {
                        _ROIp.RequiredPass.rtcValue = _Node.NeedPass;
                        _ROIp.Active = _Node.NeedPass;
                        Action.ROIProperties[_ID] = _ROIp;
                        if (_ROIp.Selected)
                            Action.SetROIPropertiesSelectedValueToAction(_ROIp.ID);
                    }
                    object roiObj = Action.ROIs.Values.FirstOrDefault(x => ((cDrawingBaseType)x).ID == _ID);
                    if (roiObj != null)
                    {
                        ((cDrawingBaseType)roiObj).IsDisplayOutPut = _Node.IsDisplayOutput;
                        ((cDrawingBaseType)roiObj).Name = _Node.Name;
                    }
                }
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_RTCSetupPassed)
                Process_SetupPassed();
            else
                Process_ApplyProperties();

            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tlSetup_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Column == colName && _RTCSetupPassed)
            {
                TextBox txtName = (TextBox)e.Control;
                e.NewValue= txtName.Text;
            }

        }

        private void tlSetup_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if(e.Column == colName && _RTCSetupPassed)
            {
                TextBox txtName= new TextBox();
                txtName.Text = e.Value.ToString();
                txtName.Bounds = e.CellBounds;
                e.Control = txtName;
            } 
            else
            {
                e.Cancel = true;
            }
                
        }
    }
}
