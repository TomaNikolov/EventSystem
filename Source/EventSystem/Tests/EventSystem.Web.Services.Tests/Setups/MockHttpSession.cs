﻿namespace EventSystem.Web.Services.Tests.Setups
{
    using System.Collections.Generic;
    using System.Web;

    public class MockHttpSession : HttpSessionStateBase
    {
        private Dictionary<string, object> sessionStorage;

        public MockHttpSession()
        {
            this.sessionStorage = new Dictionary<string, object>();
        }

        public override object this[string name]
        {
            get
            {
                if (!this.sessionStorage.ContainsKey(name))
                {
                    this.sessionStorage[name] = null;
                }

                return sessionStorage[name];
            }
            set { sessionStorage[name] = value; }
        }
    }
}
