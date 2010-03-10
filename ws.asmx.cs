using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Web.Services;
using dm = srp4net.DataModel;
using srp4net.Helpers;

namespace srp4net
{
    /// <summary>
    /// Sample webservice for demonstrating the SRP authentication mechanism
    /// </summary>
    [WebService(Namespace = "http://srp4net/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ws : System.Web.Services.WebService
    {
        public class SRPReturn_AddAccount
        {
            public class Data
            {
            }

            public int error;
            public Data data;
        }

        [WebMethod(MessageName = "SRP/AddAccount")]
        public SRPReturn_AddAccount SRP_AddAccount(string user, string s, string v)
        {
            int error = dm.Users.Add(user, s, v);

            if (0 != error)
            {
                return new SRPReturn_AddAccount { error = error };
            }

            return new SRPReturn_AddAccount
            {
                error = 0,
                data = new SRPReturn_AddAccount.Data
                {
                }
            };
        }

        public class SRPReturn_AuthStep1
        {
            public class Data
            {
                public string uniq1;
                public string s;
                public string B;
                public string u;
            }

            public int error;
            public Data data;

        }

        // [TODO] perhaps this should stay in the DataModel
        static List<AuthData> auth = new List<AuthData>();

        public class AuthData
        {
            public string user;
            public string uniq;
            public string s;
            public string v;
            public string A;
            public string b;
            public string B;
            public string u;
        }

        [WebMethod(MessageName = "SRP/AuthStep1")]
        public SRPReturn_AuthStep1 AuthStep1(string user, string A)
        {
            string sHex;
            string vHex;
            int error = dm.Users.AuthStep1(user, out sHex, out vHex);

            if (0 != error)
            {
                return new SRPReturn_AuthStep1() { error = 1 };
            }


            string bHex;
            string BHex;
            string uHex;
            Crypto.SRP.AuthStep1(
                vHex,
                A,
                out bHex,
                out BHex,
                out uHex);


            string uniq1 = DateTime.Now.Ticks.ToString();

            auth.Add(new AuthData()
            {
                user = user,
                uniq = uniq1,
                s = sHex,
                v = vHex,
                A = A,
                b = bHex,
                B = BHex,
                u = uHex
            });

            return new SRPReturn_AuthStep1()
            {
                error = 0,
                data = new SRPReturn_AuthStep1.Data
                {
                    uniq1 = uniq1,
                    s = sHex,
                    B = BHex,
                    u = uHex
                }
            };
        }

        public class SRPReturn_AuthStep2
        {
            public class Data
            {
                public string uniq2;
                public string m2;
            }

            public int error;
            public Data data;
        }

        [WebMethod(MessageName = "SRP/AuthStep2")]
        public SRPReturn_AuthStep2 AuthStep2(string user, string uniq1, string m1)
        {

            var q =
                (from x in auth
                 where (x.user == user) && (x.uniq == uniq1)
                 select x).First();

            // [TODO] in the real life here will check if the user exists...

            Trace.TraceInformation("We've got from auth: v={0} u={1} A={2} b={3} B={4}", q.v, q.u, q.A, q.b, q.B);

            string m1serverHex;
            string m2Hex;
            Crypto.SRP.AuthStep2(
                q.v,
                q.u,
                q.A,
                q.b,
                q.B,
                out m1serverHex,
                out m2Hex);

            if (m1serverHex == m1)
            {
                // so far, from server's point of view, everything is ok
                // we've just authenticated the client
                // [TODO] now we should do something smart here, like going into the private section
                Trace.TraceInformation("Server says: we do trust the client; it's authenticated");
            }
            else
            {
                // [TODO] panic :) the authentication failed
                Trace.TraceInformation("Server says: we do NOT trust the client");
                throw new Exception("Server says: we do NOT trust the client; now do something cool here");
            }

            // remove it from the queue
            auth.Remove(q);

            string uniq2 = DateTime.Now.Ticks.ToString();

            return new SRPReturn_AuthStep2()
            {
                error = 0,
                data = new SRPReturn_AuthStep2.Data
                {
                    uniq2 = uniq2,
                    m2 = m2Hex
                }
            };
        }
    }
}
