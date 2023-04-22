﻿using GameBuilder.Psp;
using Org.BouncyCastle.Asn1.Pkcs;
using PspCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBuilder.VersionKey
{
    public class ActRifMethod
    {
        public static NpDrmInfo GetVersionKey(byte[] actDat, byte[] licenseDat, byte[] consoleId, int keyIndex)
        {
            byte[] versionKey = new byte[0x10];
            SceNpDrm.SetPSID(consoleId);
            SceNpDrm.sceNpDrmGetVersionKey(versionKey, actDat, licenseDat, keyIndex);
            SceNpDrm.Aid = BitConverter.ToUInt64(licenseDat, 0x8);

            string contentId = Encoding.UTF8.GetString(licenseDat, 0x10, 0x24);
            
            return new NpDrmInfo(versionKey, contentId, keyIndex);
        }
    }
}
