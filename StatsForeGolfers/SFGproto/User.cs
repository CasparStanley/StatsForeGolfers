using System;
using System.Collections.Generic;
using System.Text;

namespace SFGproto
{
    class User
    {
        /// <summary>
        /// This is the golf player.
        /// Connected to this class are only the properties explicitly for the person
        /// Their name or their experience as a golfer, etc.
        /// 
        /// Their handicap, for example, will be part of the statistics, 
        /// so that is in a class for itself.
        /// </summary>
        
        // The name of the user
        public string Name { get; set; }
        // The "status" of the user - Pro, Amateur, N00b, Senior, etc.
        public string Status { get; set; }
        // The user's membership number in their main club. Only needs to be filled if they want to.
        public string MemberNo { get; set; }
    }
}
