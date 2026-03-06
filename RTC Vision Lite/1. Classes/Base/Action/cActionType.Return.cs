using RTCConst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTC_Vision_Lite.Classes
{
    public partial class cAction
    {
        public void Run_Return()
        {
            Passed.rtcValue = false;
            MyGroup.IsReturn = false;
            MyGroup.ReturnMode = cReturnMode.Break;
            MyGroup.ReturnToolID = Guid.Empty;

            if (NumberOfRun.rtcValue <= 0)
            {
                Passed.rtcValue = true;
                return;
            }

            if (IsUseNumberOfRun.rtcValue)
            {
                CurrentCount.rtcValue += 1;
                if (CurrentCount.rtcValue > NumberOfRun.rtcValue)
                {
                    Passed.rtcValue = true;
                    return;
                }
            }

            MyGroup.IsReturn = true;

            switch (ReturnMode.rtcValue)
            {
                case cReturnMode.Break:
                    {
                        break;
                    }
                case cReturnMode.BackToTheTop:
                    {
                        //Tool return hiện tại chọn quay về đầu ==> Chuyển hướng về main action
                        MyGroup.ReturnToolID = MyGroup.IDMainAction;
                        break;
                    }
                case cReturnMode.BreakCurrentLoop:
                    {
                        //Kiểm tra xem tool này đang nằm trong tool rẽ nhánh nào, sau đó lấy tool tiếp sau tool rẽ nhánh đó
                        if (IDBranchItem != Guid.Empty)
                        {
                            //Lấy tool cuối cùng trong danh sách các tool của tool rẽ nhánh này
                            Guid idBranch = MyGroup.Actions[IDBranchItem].IDBranch;
                            var listToolOfBranch = MyGroup.Actions.Values.Where(x => x.IDBranch == idBranch ||
                            (x.IDBranchItem != Guid.Empty && MyGroup.Actions[x.IDBranchItem].IDBranch == idBranch)).OrderBy(x => x.STT).ToList();
                            cAction nextAction = MyGroup.Actions.Values.FirstOrDefault(x => x.STT == listToolOfBranch[listToolOfBranch.Count - 1].STT + 1);
                            if (nextAction != null)
                                MyGroup.ReturnToolID = nextAction.ID;
                        }
                        else
                        {
                            //Tool return hiện tại không thuộc bất cứ 1 nhánh nào, lại chọn chế độ break loop ==> Chuyển hướng về mainaction
                            MyGroup.ReturnToolID = MyGroup.IDMainAction;
                        }
                        break;
                    }
                case cReturnMode.CurrentLoop:
                    {
                        //Quay trở lại chính tool rẽ nhánh cha của tool này
                        if (IDBranchItem != Guid.Empty)
                            MyGroup.ReturnToolID = MyGroup.Actions[IDBranchItem].IDBranch;
                        else //Tool return hiện tại không thuộc bất cứ 1 nhánh nào, lại chọn chế độ break loop ==> Chuyển hướng về mainaction
                            MyGroup.ReturnToolID = MyGroup.IDMainAction;
                        break;
                    }
                case cReturnMode.Tool:
                    {
                        Guid.TryParse(ToolID.rtcValue, out MyGroup.ReturnToolID);
                        break;
                    }
            }
            Passed.rtcValue = true;
        }

    }
}
