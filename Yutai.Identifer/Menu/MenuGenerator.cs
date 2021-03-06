﻿using System;
using System.Collections.Generic;
using System.Xml;
using DevExpress.XtraBars.Ribbon;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Interfaces;
using Yutai.UI.Menu.Ribbon;

namespace Yutai.Plugins.Identifer.Menu
{
    internal class MenuGenerator
    {
        private readonly IAppContext _context;
        private readonly YutaiCommands _commands;
        private readonly object _menuManager;
        private readonly IdentifierPlugin _plugin;


        public MenuGenerator(IAppContext context, IdentifierPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            // if (pluginManager == null) throw new ArgumentNullException("pluginManager");

            _plugin = plugin;
            _context = context;

            _menuManager = _context.MainView.RibbonManager;
            _commands = new YutaiCommands(_context, plugin.Identity);
            _commands.Plugin = plugin;
            InitMenus();
        }

        public List<string> GetMenuKeys()
        {
            return _commands.GetKeys();
        }

        private void InitMenus()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(base.GetType().Assembly.GetManifestResourceStream("Yutai.Plugins.Identifer.Menu.MenuLayout.xml"));
            RibbonFactory.CreateMenus(_commands.GetCommands(), (RibbonControl) _menuManager,
                _context.MainView.RibbonStatusBar as RibbonStatusBar, doc);
        }
    }
}