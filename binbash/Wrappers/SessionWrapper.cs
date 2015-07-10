using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace binbash.Wrappers {
    /// <summary>
    /// Wraps the MVC Session service for access outside of controllers
    /// </summary>
    public class SessionWrapper {

        /// <summary>
        /// get or set a value in the session
        /// </summary>
        /// <param name="name">the name of the value</param>
        /// <returns>the stored value</returns>
        public object this[string name] {
            get {
                return HttpContext.Current.Session[name];
            }

            set {
                HttpContext.Current.Session[name] = value;
            }
        }

        /// <summary>
        /// get or set a value in the session
        /// </summary>
        /// <param name="index">the index of the value</param>
        /// <returns>the stored value</returns>
        public object this[int index] {
            get {
                return HttpContext.Current.Session[index];
            }

            set {
                HttpContext.Current.Session[index] = value;
            }
        }
    }
}