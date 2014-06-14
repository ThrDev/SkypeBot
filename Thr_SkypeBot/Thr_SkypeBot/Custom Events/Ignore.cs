using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thr_SkypeBot
{
    /// <summary>
    /// Stores all ignored users.
    /// </summary>
    public class Ignore
    {
        static List<string> ignorelist = new List<string>();
        /// <summary>
        /// Add a Skype Name to the Ignore list.
        /// </summary>
        /// <param name="SkypeName">The Skype Name of the User.</param>
        public static void Add(string SkypeName)
        {
            if(!ignorelist.Contains(SkypeName))
                ignorelist.Add(SkypeName);
        }
        /// <summary>
        /// Check to see if the list of ignored users contains the specified Skype name.
        /// </summary>
        /// <param name="SkypeName">The Skype name of the user.</param>
        /// <returns>True if the username is contained in the ignore list.</returns>
        public static bool Contains(string SkypeName)
        {
            if (ignorelist.Contains(SkypeName))
                return true;
            return false;
        }
        /// <summary>
        /// Removes the specified Skype name from the ignore list.
        /// </summary>
        /// <param name="SkypeName">The Skype name of the user.</param>
        public static void Remove(string SkypeName)
        {
            if(ignorelist.Contains(SkypeName))
                ignorelist.Remove(SkypeName);
        }
        /// <summary>
        /// Output all of the entries of the Ignore list.
        /// </summary>
        /// <returns>A list containing all ignored Skype names.</returns>
        public static List<string> List()
        {
            return ignorelist;
        }
    }
}
