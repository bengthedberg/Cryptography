﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HybridWithSignature
{
    /// <summary>
    /// class to hold data in transfer
    /// </summary>
    public class EncryptedPacket
    {
        public byte[] EncryptedSessionKey;
        public byte[] EncryptedData;
        public byte[] Iv;
        public byte[] Hmac;
        public byte[] Signature;
    }
}
