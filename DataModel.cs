// srp4net 1.0
// SRP for .NET - A Javascript/C# .NET library for implementing the SRP authentication protocol
// by Sorin Ostafiev (http://code.google.com/p/srp4net/)
// License: LGPL v3 (http://www.gnu.org/licenses/lgpl-3.0.txt)

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace srp4net.DataModel
{
    // some dummy "in memory" model for an users list

    public abstract class Users
    {
        private static Hashtable h = new Hashtable();
        public static int Add(string user, string sHex, string vHex)
        {
            if (h.ContainsKey(user))
            {
                return 1; // the account already exists
            }

            h.Add(user, new sv() { sHex = sHex, vHex = vHex });
            return 0;
        }

        internal class sv
        {
            public string sHex;
            public string vHex;
        }
        public static int AuthStep1(string user, out string sHex, out string vHex)
        {
            if (!h.ContainsKey(user))
            {
                sHex = null;
                vHex = null;
                return 1;
            }

            var gg = h[user] as sv;
            sHex = gg.sHex;
            vHex = gg.vHex;
            return 0;
        }
    }
}
