using MuwebNET.Models.GameContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuwebNET.Bll.GameContext
{
    public static class Account
    {
        public static void Create(Models.GameContext.Account user)
        {
            using (var c = new GameDbContext())
            {
                c.Accounts.Add(user);
                c.SaveChanges();
            }
        }

        public static void Update(Models.GameContext.Account user)
        {
            using (var c = new GameDbContext())
            {
                c.Entry(user).State = System.Data.Entity.EntityState.Modified;
                c.SaveChanges();
            }
        }

        public static Models.GameContext.Account VerifyLogin(string user, string pass)
        {
            using (var db = new GameDbContext())
            {
                var u = db.Accounts.Where(x => x.memb___id == user && x.memb__pwd == pass).FirstOrDefault();
                return u;
            }
        }

        public static Models.GameContext.Warehouse GetVaultByUser(string account)
        {
            using (var c = new GameDbContext())
            {
                return c.Vaults.Find(account);
            }
        }

        public static List<Models.GameContext.Item> GetVaultItemsToList(string account)
        {
            List<Models.GameContext.Item> list = new List<Models.GameContext.Item>();

            using (var c = new GameDbContext())
            {
                var bau = c.Vaults.Find(account);
                if (bau != null)
                {
                    int len = bau.Items.Length;
                    int lts = 16;
                    for (int i = 0; i < len; i = i + lts)
                    {
                        byte[] temp = new byte[lts];
                        if (len < i + lts)
                        {
                            lts = len - i;
                        }

                        Array.Copy(bau.Items, i, temp, 0, lts);
                        string hex_tmp = Models.GameContext.Item.ByteArrayToString(temp);
                        list.Add(Item.CreateFromHex(Models.GameContext.Item.ByteArrayToString(temp)));
                    }
                }
            }
            return list;
        }
    }
}
