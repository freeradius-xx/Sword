﻿using Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    internal static class CommandParserUtils
    {
        public static int tag4ContentSize = sizeof(Int32);

        public static byte[] TruncateBuffer(byte[] cmdBytes)
        {
            var cmdSize = GetFirstCommandSize(cmdBytes);
            return cmdBytes.Skip(cmdSize + tag4ContentSize).ToArray();
        }

        public static CommandWrapper ParseCommand(byte[] cmdBytes)
        {
            var cmdSize = GetFirstCommandSize(cmdBytes);
            var bts = cmdBytes.Skip(tag4ContentSize).Take(cmdSize).ToArray();
            return SerializerUtility.BinDeserialize<CommandWrapper>(bts);
        }

        public static bool IsSizeOKForOneCommand(byte[] cmdBytes)
        {
            if (cmdBytes.Length < tag4ContentSize)
                return false;

            var cmdSize = GetFirstCommandSize(cmdBytes);

            if (cmdBytes.Length >= tag4ContentSize + cmdSize)
                return true;

            return false;
        }

        public static int GetFirstCommandSize(byte[] cmdBytes)
        {
            return BitConverter.ToInt32(cmdBytes.Take(tag4ContentSize).ToArray(), 0);
        }
    }
}
