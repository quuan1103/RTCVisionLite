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
        public void Prepare_CounterLoop(cAction counterLoopAction)
        {
            var listBranchItems = MyGroup.Actions.Values.Where(x =>
               x.ActionType == EActionTypes.BranchItem && x.IDBranch == counterLoopAction.ID).ToList();
            if (!listBranchItems.Any()) return;
            foreach (cAction branchItem in listBranchItems)
                ApplyIsCanRunToAllToolOfBranchItem(branchItem, false);

        }
        public void Run_CounterLoop()
        {
            try
            {
                Passed.rtcValue = false;
                // Tìm các tool là con của tool này xem có được chạy hay không
                cAction brandItemLoop = MyGroup.Actions.Values.FirstOrDefault(x =>
                    x.ActionType == EActionTypes.BranchItem && x.IDBranch == ID);
                if (brandItemLoop == null)
                {
                    Passed.rtcValue = true;
                    return;
                }

                int startOrder = brandItemLoop.STT + 1;
                int endOrder = brandItemLoop.STT;

                cAction actionOuterLoop = MyGroup.Actions.Values.OrderBy(x => x.STT).FirstOrDefault(x =>
                    x.IDBranch != this.ID && x.IDBranchItem != brandItemLoop.ID && x.STT > this.STT);
                cAction endAction = MyGroup.Actions.Values.OrderByDescending(x => x.STT).FirstOrDefault();
                if (actionOuterLoop != null)
                    endOrder = actionOuterLoop.STT;
                else if (endAction != null)
                    endOrder = endAction.STT;
                else
                {
                    Passed.rtcValue = true;
                    return;
                }

                var orderActions = MyGroup.Actions.Values.OrderBy(x => x.STT).Where(x => x.STT >= startOrder && x.STT <= endOrder).ToList();


                for (CurrentCount.rtcValue = StartNumber.rtcValue; CurrentCount.rtcValue <= Count.rtcValue; CurrentCount.rtcValue += Step.rtcValue)
                {
                    this.MyGroup.SetValuetoVariableIsParentRef(this);

                    foreach (cAction orderAction in orderActions)
                    {
                        if (orderAction.IDBranchItem == brandItemLoop.ID)
                            orderAction.IsCanRun = orderAction.Enable.rtcValue;
                        else
                            orderAction.IsCanRun = false;

                        orderAction.IsRunned = false;
                    }

                    for (int i = 0; i < orderActions.Count; i++)
                    {
                        cAction action = orderActions[i];
                        //if (action.IDBranchItem == brandItemLoop.ID)
                        //{
                        //    action.IsCanRun = action.Enable.rtcValue;
                        //    MyGroup.Run1Action(ref action);
                        //    //action.IsCanRun = false;
                        //}
                        //else if (action.IsCanRun)
                        //{
                        //    MyGroup.Run1Action(ref action);
                        //    //action.IsCanRun = false;
                        //}


                        if (action.IsCanRun)
                        {
                            MyGroup.Run1Action(ref action);
                            //action.IsCanRun = false;
                        }

                        if (MyGroup.IsReturn)
                        {
                            switch (MyGroup.ReturnMode)
                            {
                                case cReturnMode.Break:
                                    {
                                        MyGroup.IsReturn = false;
                                        Passed.rtcValue = true;
                                        return;
                                    }
                                case cReturnMode.BreakCurrentLoop:
                                    {
                                        MyGroup.IsReturn = false;
                                        Passed.rtcValue = true;
                                        return;
                                    }
                                case cReturnMode.BackToTheTop:
                                    {
                                        Passed.rtcValue = true;
                                        return;
                                    }
                                case cReturnMode.Tool:
                                    {
                                        Passed.rtcValue = true;
                                        return;
                                    }
                            }
                        }

                        MyGroup.IndexBreak = action.STT;
                    }
                }
                if (!this.MyGroup.RunSimple && this.ViewInfo != null)
                    ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();
                Passed.rtcValue = true;
            }
            catch (Exception ex)
            {
                GlobFuncs.SaveErr(ex);
                Passed.rtcValue = false;
            }

            //try
            //{
            //    Passed.rtcValue = false;
            //    // Tìm các tool là con của tool này xem có được chạy hay không
            //    cAction brandItemLoop = MyGroup.Actions.Values.FirstOrDefault(x =>
            //        x.ActionType == EActionTypes.BranchItem && x.IDBranch == ID);

            //    var listBranchItems = MyGroup.Actions.Values.Where(x =>
            //        x.ActionType == EActionTypes.BranchItem && x.IDBranch == ID).ToList();
            //    if (brandItemLoop == null)
            //    {
            //        Passed.rtcValue = true;
            //        return;
            //    }

            //    for (CurrentCount.rtcValue = StartNumber.rtcValue; CurrentCount.rtcValue <= Count.rtcValue; CurrentCount.rtcValue += Step.rtcValue)
            //    {
            //        this.MyGroup.SetValueToVariableIsParentRef(this);
            //        if (!this.MyGroup.RunSimple && this.ViewInfo != null)
            //            ((ucBaseActionDetail)this.ViewInfo).ReviewAllPropertyValueToViewInfo();

            //        int startOrder = brandItemLoop.STT + 1;
            //        int endOrder = brandItemLoop.STT;

            //        var orderActions = MyGroup.Actions.Values.OrderBy(x => x.STT).ToList();
            //        for (int i = 0; i < orderActions.Count; i++)
            //        {
            //            if (orderActions[i].STT >= endOrder &&
            //                orderActions[i].IDBranch == Guid.Empty &&
            //                orderActions[i].IDBranchItem == brandItemLoop.ID)
            //            {
            //                endOrder = orderActions[i].STT;

            //                if (orderActions[i].ActionType == EActionTypes.Branch ||
            //                    orderActions[i].ActionType == EActionTypes.Switch ||
            //                    orderActions[i].ActionType == EActionTypes.CounterLoop)
            //                {
            //                    // Lấy toàn bộ các nhánh của tool này
            //                    var orderBranchItems = orderActions.Where(x => x.IDBranch == orderActions[i].ID).ToList();
            //                    if (orderBranchItems.Count > 0) //Lấy các phần tử thuộc nhánh cuối cùng
            //                    {
            //                        var actionOfBranchItems = orderActions.Where(x => x.IDBranchItem == orderBranchItems[orderBranchItems.Count - 1].ID).ToList();
            //                        if (actionOfBranchItems.Count > 0)
            //                        {
            //                            i = actionOfBranchItems[actionOfBranchItems.Count - 1].STT;
            //                            endOrder = i;
            //                        }
            //                        else
            //                            endOrder = orderBranchItems[orderBranchItems.Count - 1].STT;
            //                    }
            //                }
            //            }
            //        }

            //        orderActions = MyGroup.Actions.Values.OrderBy(x => x.STT).Where(x => x.STT >= startOrder && x.STT <= endOrder).ToList();

            //        for (int i = 0; i < orderActions.Count; i++)
            //        {
            //            cAction action = orderActions[i];
            //            if (action.IDBranchItem == brandItemLoop.ID)
            //            {
            //                action.IsCanRun = action.Enable.rtcValue;
            //                MyGroup.Run1Action(ref action);
            //                //action.IsCanRun = false;
            //            }
            //            else if (action.Enable.rtcValue)
            //            {
            //                MyGroup.Run1Action(ref action);
            //                //action.IsCanRun = false;
            //            }

            //            if (MyGroup.IsReturn)
            //            {
            //                switch (MyGroup.ReturnMode)
            //                {
            //                    case cReturnMode.Break:
            //                        {
            //                            MyGroup.IsReturn = false;
            //                            Passed.rtcValue = true;
            //                            return;
            //                        }
            //                    case cReturnMode.BreakCurrentLoop:
            //                        {
            //                            MyGroup.IsReturn = false;
            //                            Passed.rtcValue = true;
            //                            return;
            //                        }
            //                    case cReturnMode.BackToTheTop:
            //                        {
            //                            Passed.rtcValue = true;
            //                            return;
            //                        }
            //                    case cReturnMode.Tool:
            //                        {
            //                            Passed.rtcValue = true;
            //                            return;
            //                        }
            //                }
            //            }

            //            MyGroup.IndexBreak = action.STT;
            //        }
            //    }

            //    Passed.rtcValue = true;
            //}
            //catch (Exception ex)
            //{
            //    GlobFuncs.SaveErr(ex);
            //    Passed.rtcValue = false;
            //}
        }

    }
}
