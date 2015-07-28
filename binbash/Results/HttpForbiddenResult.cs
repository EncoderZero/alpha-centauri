using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace binbash.Results {
    public class HttpForbiddenResult : HttpStatusCodeResult {
        public HttpForbiddenResult()
            : this(null) {
        }

        public HttpForbiddenResult(string statusDescription)
            : base(HttpStatusCode.Forbidden, statusDescription) {
        }
    }
}