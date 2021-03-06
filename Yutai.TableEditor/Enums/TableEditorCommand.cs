﻿// 项目名称 :  Yutai
// 项目描述 :  
// 类 名 称 :  TableEditorCommand.cs
// 版 本 号 :  
// 说    明 :  
// 作    者 :  
// 创建时间 :  2017/06/06  15:25
// 更新时间 :  2017/06/06  15:25

using System.ComponentModel;

namespace Yutai.Plugins.TableEditor.Enums
{
    public enum TableEditorCommand
    {
        Clear = 0,
        Close = 1,
    }

    public enum ItemDisplayStyle
    {
        None,
        Text,
        Image,
        ImageAndText,
    }

    public enum TableType
    {
        All,
        Selected
    }

    public enum FieldType
    {
        String = 0,
        Integer = 1,
        Double = 2
    }

    public enum MatchType
    {
        Contains = 0,
        Match = 1,
        Start = 2,
    }
}