using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace Kursach
{
    public static class ExplicitLoaders
    {
        public static void LoadAllUserData(User user)
        {
            //Repository<User>.context.Entry(user.UserAccountInfo).State = EntityState.Detached;
            //Repository<User>.context.Entry(user.UserPublicInfo).State = EntityState.Detached;
            foreach (ReferenceEntry item in Repository<User>.context.Entry(user).References)
            {
                Console.Write(item.IsLoaded + " - ");
                Console.WriteLine(item.CurrentValue);
                Console.WriteLine("---");
            }

            Repository<User>.context.Entry(user).Reference(u => u.UserAccountInfo).Load();
            Repository<User>.context.Entry(user).Reference(u => u.UserPublicInfo).Load();

            //Repository<User>.context.Entry(user.UserAccountInfo).State = EntityState.Detached;
            //Repository<User>.context.Entry(user.UserPublicInfo).State = EntityState.Detached;

            foreach (ReferenceEntry item in Repository<User>.context.Entry(user).References)
            {
                Console.Write(item.IsLoaded + " - ");
                Console.WriteLine(item.CurrentValue);
                Console.WriteLine("---");
            }
        }
    }
}
