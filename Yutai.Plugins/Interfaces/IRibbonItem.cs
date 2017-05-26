﻿using System.Drawing;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;

namespace Yutai.Plugins.Interfaces
{
    public interface IRibbonItem
    {
        string Name { get;  }
        string Key { get;  }
        string Caption { get;  }
        Bitmap Image { get;  }
        string Tooltip { get; }
        string Category { get; }
        RibbonItemType ItemType { get;  }
        bool Checked { get; }
        bool Enabled { get; }
        PluginIdentity PluginIdentity { get; }
    }
}