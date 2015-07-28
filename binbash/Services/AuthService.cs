using binbash.Models;
using System;

namespace binbash.Services {

    public class AuthService {
        private static BinBashModels db = new BinBashModels();

        public static Boolean UserIsAdmin(AspNetUser user) {
            return user.IsAdmin;
        }

        public static Boolean UserIsAdmin(string userId) {
            AspNetUser user = db.AspNetUsers.Find(userId);
            if(user != null) {
                return UserIsAdmin(user);
            } else {
                return false;
            }
        }
    }
}