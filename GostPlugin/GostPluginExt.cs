﻿using KeePass.Plugins;
using System;

namespace GostPlugin
{
    public class GostPluginExt : Plugin
    {
        public override string UpdateUrl { get { return "https://gostplugin.ru/VersionInformation.txt"; } }

        public override bool Initialize (IPluginHost host) {
            if (host == null || host.CipherPool == null) return false;

            try {
                host.CipherPool.AddCipher(new CipherEngine(new Kuznyechik()));
                host.CipherPool.AddCipher(new CipherEngine(new Magma()));
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}