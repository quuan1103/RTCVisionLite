using RTC_Vision_Lite.PublicFunctions;
using RTC_Vision_Lite.UserControls;
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
        public void Prepare_PassFail(cAction branchAction)
        {
            if (branchAction.Enable.rtcValue)
                return;
            // tìm các tool là tool con của tool này xem có tìm được không
            var listBranchItems = MyGroup.Actions.Values.Where(x =>
            x.ActionType == EActionTypes.BranchItem && x.IDBranch == branchAction.ID).ToList();
            if (!listBranchItems.Any())
                return;
            foreach (cAction branchItem in listBranchItems)
                ApplyIsCanRunToAllToolOfBranchItem(branchItem, false);
        }
        private bool GetPassedOfActionLinkPassFail(cAction action, string propName)
        {
            if (action != null)
            {
                var variableType = (RTCVariableType)action.GetType().GetProperty(propName)?.GetValue(action, null);
                if (variableType == null)
                    return false;
                var propertyInfoValue = variableType.GetType().GetProperty(cPropertyName.rtcValue);
                if (propertyInfoValue == null)
                    return false;
                var obj = propertyInfoValue.GetValue(variableType, null);

                return GlobFuncs.GetBoolValueFromObject(obj);
            }

            return false;
        }
        public void Run_PassFail()
        {
            try
            {
                Passed.rtcValue = false;
                bool _LanDau = true;
                foreach (cLinkPassFail linkPf in LinkPassFail)
                    if (linkPf.rtcActive)
                    {
                        MyGroup.Actions.TryGetValue(linkPf.rtcIDref, out cAction actionLink);
                        if (actionLink == null)
                            continue;
                        if (actionLink.STT >= this.STT || actionLink.Passed == null)
                            continue;

                        if (MyGroup.RunSimple && !IsActionCanRunLinkPassFail(actionLink))
                            continue;

                        // Lấy giá trị ok/ng của tool hiện tại
                        bool passed = GetPassedOfActionLinkPassFail(actionLink, linkPf.rtcPropNameRef);


                        if (PassCriteria.rtcValue == cPropertyValue.PassCriteria_All)
                        {
                            if (linkPf.rtcInvert)
                                Passed.rtcValue = _LanDau ? !passed : (Passed.rtcValue && !passed);
                            else
                                Passed.rtcValue = _LanDau ? passed : (Passed.rtcValue && passed);
                        }
                        else
                        {
                            if (linkPf.rtcInvert)
                                Passed.rtcValue = _LanDau ? !passed : (Passed.rtcValue || !passed);
                            else
                                Passed.rtcValue = _LanDau ? passed : (Passed.rtcValue || passed);
                        }
                        _LanDau = false;
                    }

                // Xử lý dữ liệu cho các tool lựa chọn GetResult
                foreach (cLinkPassFail linkPf in LinkPassFail)
                    if (linkPf.rtcGetResult)
                    {
                        MyGroup.Actions.TryGetValue(linkPf.rtcIDref, out cAction actionLink);
                        if (actionLink == null)
                            continue;
                        if (actionLink.STT >= this.STT || actionLink.Passed == null)
                            continue;

                        //DATRUONG: 08.11.2022: Chỉ có các tool được chạy mới được tham gia việc
                        // trào ngược giá trị
                        if (!actionLink.Enable.rtcValue)
                            continue;
                        if (MyGroup.RunSimple && !actionLink.IsRunned)
                            continue;
                        if (!MyGroup.RunSimple && actionLink.MyGroup.IsRun && !actionLink.IsRunned)
                            continue;

                        //if (MyGroup.RunSimple && !IsActionCanRunLinkPassFail(actionLink))
                        //    continue;

                        // Lấy tool nguồn
                        MyGroup.Actions.TryGetValue(linkPf.rtcIDGetResult, out cAction actionGetResult);
                        if (actionGetResult == null)
                            continue;

                        if (actionGetResult.ID == this.ID)
                            actionLink.Passed.rtcValue = this.Passed.rtcValue;
                        else
                        {
                            // Xác định tool nguồn này trong danh sách pass/fail hiện tại
                            cLinkPassFail linkPfSrc = LinkPassFail.FirstOrDefault(x => x.rtcIDref == actionGetResult.ID);
                            if (linkPfSrc == null)
                                return;
                            // Xác định giá trị ok/ng của tool nguồn
                            bool passed = GetPassedOfActionLinkPassFail(actionGetResult, linkPfSrc.rtcPropNameRef);
                            if (linkPfSrc.rtcInvert)
                                passed = !passed;
                            // Gán giá trị này cho tool hiện tại
                            actionLink.Passed.rtcValue = passed;
                        }
                        if (actionLink.ViewInfo != null)
                            ((ucBaseActionDetail)actionLink.ViewInfo).UpdatePropertyValueToAllControls(nameof(actionLink.Passed));
                    }

                // Tìm các tool là con của tool này xem có được chạy hay không
                var listBranchItems = MyGroup.Actions.Values.Where(x =>
                    x.ActionType == EActionTypes.BranchItem && x.IDBranch == ID).ToList();
                if (!listBranchItems.Any()) return;

                foreach (cAction branchItem in listBranchItems)
                {
                    branchItem.Passed.rtcValue = false;
                    //So sánh điều kiện của tool branch 
                    if (Passed.rtcValue &&
                        branchItem.Name.rtcValue == cStrings.Pass.ToUpper())
                        branchItem.Passed.rtcValue = true;
                    else if (!Passed.rtcValue &&
                             branchItem.Name.rtcValue == cStrings.Fail.ToUpper())
                        branchItem.Passed.rtcValue = true;

                    ApplyIsCanRunToAllToolOfBranchItem(branchItem, Enable.rtcValue && branchItem.Passed.rtcValue);
                }

                //Kiểm tra xem tool này có phải tool master hay ko
                if (Enable.rtcValue && IsMasterResult.rtcValue)
                {
                    MyGroup.Actions[MyGroup.IDMainAction].ResultOK.rtcValue = Passed.rtcValue;
                    MyGroup.SetValuetoVariableIsParentRef(MyGroup.Actions[MyGroup.IDMainAction]);
                }
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                Passed.rtcValue = false;
            }
        }

    }
}
