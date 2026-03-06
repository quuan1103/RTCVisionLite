using RTCConst;
using RTCEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        private bool isPrepare = false;
        //private bool isPrepare = false;
        public void Prepare_Branch (cAction branchAction)
        {
            try
            {
                isPrepare = true;
                if (branchAction.Enable.rtcValue)
                    return;
                // Tìm các tool là con của tool này xem có được chạy hay không
                var listBranchItems = MyGroup.Actions.Values.Where(x => 
                x.ActionType == EActionTypes.BranchItem && x.IDBranch == branchAction.ID).ToList();
                if (!listBranchItems.Any())
                    return;
                foreach (cAction branchItem in listBranchItems)
                    ApplyIsCanRunToAllToolOfBranchItem(branchItem, false, false);

            }
            finally
            {
                isPrepare = false;
            }
        }
        public void ApplyIsCanRunToAllToolOfBranchItem(cAction branchItemAction, bool isCanRun, bool isSetBreak = true, bool isSetAbortCause = false)
        {
            if (isSetAbortCause)
                isSetAbortCauseValue(branchItemAction.MyNode, isCanRun ? cStrings.True.ToString() : cStrings.False.ToString());
            branchItemAction.IsCanRun = isCanRun;
            if (branchItemAction.IsCanRun && isSetBreak)
                this.MyGroup.IndexBreak = branchItemAction.STT - 1;
            var listActionInBranchItem = MyGroup.Actions.Values.Where(x => x.IDBranchItem == branchItemAction.ID).OrderBy(x => x.STT);
            foreach (cAction action in listActionInBranchItem)
            {
                switch (action.ActionType)
                {
                    case EActionTypes.Branch:
                        {
                            action.IsCanRun = isCanRun && action.Enable.rtcValue;
                            ApplyIsCanRunToAllToolOfBranch(action, action.IsCanRun, false);
                            break;
                        }
                    case EActionTypes.Switch:
                        {
                            action.IsCanRun = isCanRun && action.Enable.rtcValue;
                            ApplyIsCanRunToAllToolOfBranch(action, action.IsCanRun, false);
                            break;
                        }
                    case EActionTypes.CounterLoop:
                        {
                            action.IsCanRun = isCanRun && action.Enable.rtcValue;
                            ApplyIsCanRunToAllToolOfBranch(action, action.IsCanRun, false);
                            break;
                        }
                    case EActionTypes.PassFail:
                        {
                            action.IsCanRun = isCanRun && action.Enable.rtcValue;
                            ApplyIsCanRunToAllToolOfBranch(action, action.IsCanRun, false);
                            break;
                        }
                    case EActionTypes.BranchItem:
                        break;
                    default:
                        action.IsCanRun = isCanRun && action.Enable.rtcValue;
                        break;
                }
            }
        }

        private void isSetAbortCauseValue(ActionTools Node, string value)
        {
            //if (MyGroup.RunSimple || Node == null)
            //    return;
            //GlobVar.AbortCause.PutValue(Node, value);
        }

        private void ApplyIsCanRunToAllToolOfBranch(cAction branchAction, bool isCanRun, bool isSetBreak = true)
        {
            var listBranchItems = MyGroup.Actions.Values.Where(x => x.ActionType == EActionTypes.BranchItem && IDBranch == branchAction.ID).ToList();
            if (!listBranchItems.Any()) return;
            foreach (cAction branchItem in listBranchItems)
            {
                branchItem.IsCanRun = isCanRun;
                ApplyIsCanRunToAllToolOfBranchItem(branchItem, isCanRun, isSetBreak);
            }
        }
        
        public void Prepare_Switch(cAction switchAction)
        {
            try
            {
                isPrepare = true;
                if (switchAction.Enable.rtcValue)
                    return;
                // Tìm các tool là con của tool này xem có được chạy hay không
                var listBranchItems = MyGroup.Actions.Values.Where(x =>
                x.ActionType == EActionTypes.BranchItem && x.IDBranch == switchAction.ID).ToList();
                if (!listBranchItems.Any())
                    return;
                foreach (cAction branchItem in listBranchItems)
                    ApplyIsCanRunToAllToolOfBranchItem(branchItem, false, false);

            }
            finally
            {
                isPrepare = false;
            }
        }
        
    }
}
