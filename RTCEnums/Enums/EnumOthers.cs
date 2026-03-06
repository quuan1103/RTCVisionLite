using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTCEnums
{
    public enum ELanguage
    {
        Eng = 0,
        VN = 1
    }

    public enum EFunctionReturn
    {
        Success = 0,
        Error = 1,
        Cancel = 2
    }
    public enum EUserActionData
    {
        Add = 0,
        Edit = 1,
        Delete = 2,
        None = 999
    }

    public enum ETrayResult_SetupProgramToProductMode
    {
        EvenOdd = 0,
        Custom = 99
    }
    public enum EColor
    {
        Black,
        White,
        Cyan,
        Blue,
        Pink,
        Gray,
        Green,
        Maroon,
        Navy,
        Violet,
        Red,
        Teal,
        Yellow
    }

    public enum ENodeTypes
    {
        Group = 0,
        Action = 1,
        Property = 2,
        PropertyDetail = 3,
        Template = 4,
        DataItemParent = 5,
        DataItem = 6,
        DataItemParentView = 7,
        DataItemView = 8,
        Operand = 9,
        None = 9999
    }
    public enum ESuffixMode
    {
        DateTime = 0,
        Numbered = 1,
        None = 9999
    }
    public enum EModeViewGrid
    {
        MainView = 0,
        DetailView = 1
    }
    #region ENUM CHO TOOL STRINGBUILDER 
    public enum EDateFormat
    {
        yymmdd = 0,
        yyyymmdd = 1,
        ddmmyy = 2,
        ddmmyyyy =3,
        mmddyy = 4,
        mmddyyyy = 5,
        none = 6

    }
    public enum EDelimiterDate
    {
        /// <summary>
        /// Gạch chéo
        /// </summary>
        Slash =0,
        /// <summary>
        /// Gạch ngang
        /// </summary>
        Dash =1,
        /// <summary>
        /// Dấu chấm
        /// </summary>
        Dot = 2,
        /// <summary>
        /// Space
        /// </summary>
        Space = 3,
        /// <summary>
        /// Không có gì
        /// </summary>
        None = 4
    }
    public enum EDelimiterTime
    {
        /// <summary>
        /// Dấu 2 chấm
        /// </summary>
        Colon = 0,
        /// <summary>
        /// Dấu chấm
        /// </summary>
        Dot = 1,
        /// <summary>
        /// Space
        /// </summary>
        Space = 2,
        /// <summary>
        /// Không có gì
        /// </summary>
        None = 3
    }
    public enum ETimeFormat
    {
        hhmmss24,
        hhmmss12,
        None
    }
    public enum EXYDelimiter
    {
        None = 0,
        Comma = 1,
        Space = 2,
        Colon = 3,
        Semicolon = 4,
        Underscore = 5

    }
    public enum EPadWiths
    {
        LeadingZeros = 0,
        LeadSpaces = 1,
        TrallingZeros = 2,
        TrallingSpaces = 3,
        AutoAddDecimal = 4

    }
    public enum EPadOutPut
    {
        LeadingZeros = 0,
        LeadingSpaces = 1,
        TrallingZeros = 2,
        TrallingSpaces = 3,
        AutoAddDecimal = 4

    }
    public enum EGroupingBracket
    {
        None = 0,
        Parenttheses = 1,
        Braces = 2,
        SquareBracket = 3,
        SmallBig = 4
    }
    public enum EDelimiter
    {
        None = 0,
        Comma = 1,
        Space = 2,
        Tab = 3,
        Semicolon = 4,
        Underscore = 5

    }
    public enum EDelimiterTypes
    {
        Standard = 0,
        Custom = 1
    }
    public enum EStringBuilderItemTypes
    {
        Boolean,
        BooleanList,
        DateAndTime,
        Integer,
        IntegerList,
        Origin,
        OriginList,
        Point,
        PointList,
        Real,
        RealList,
        Rectangle,
        RectangleList,
        String,
        StringList
    }
    #endregion
    class EnumOthers
    {
    }
}
