using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Maintenance
{
    static class MembershipData
    {
        private static string path =  
            System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MembershipList.txt";

        /// <summary>
        /// Read File and add elements to Membershiplist
        /// </summary>
        /// <param name="memList">The membership list we are writing to</param>
        public static void GetMembership(MembershipList memList)
        {
            // if the directory doesn't exist, create it
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch { }


            using (StreamReader reader = new StreamReader(path))
            {
                string current;
                while ((current = reader.ReadLine()) != null)
                {
                    string row = current;
                    string[] columns = row.Split('|');
                    memList.Add(new Member(columns[0], columns[1], columns[2]));
                }
            }
        }

        /// <summary>
        /// Write elements of MembershipList to a file
        /// </summary>
        /// <param name="memList">The membership list we are reading from</param>
        public static void SaveMembership(MembershipList memList)
        {

            // if the directory doesn't exist, create it
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch { }

            try
            {
                using (StreamWriter deleter = new StreamWriter(path, false)) { }
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    foreach (Member mem in memList)
                    {
                        writer.Write(mem.FirstName + "|");
                        writer.Write(mem.LastName + "|");
                        writer.WriteLine(mem.Email);
                    }
                }
            }
            catch { }

        }
    }
}
