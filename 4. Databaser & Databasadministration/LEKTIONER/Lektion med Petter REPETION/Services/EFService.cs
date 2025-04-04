using Lektion_med_Petter_REPETION.Models;
using Microsoft.EntityFrameworkCore;

namespace Lektion_med_Petter_REPETION.Services
{
    public static class EFService
    {
        public static void ShowMembers()
        {
            using(MemberRegistryContext context = new MemberRegistryContext())
            {
                var result = context.Members;

                foreach (var member in result) 
                {
                    Console.WriteLine($"{member.MemberId}. {member.FirstName} {member.LastName}");
                }
            }
        }

        public static void QueryTests()
        {
            using (var context = new MemberRegistryContext())
            {
                var olderMembers = context.Members.Where(m => m.Age > 25).ToList();

                var memberByLastName = context.Members
                    .Where(m => m.LastName.Contains("a"))
                    .OrderBy(m => m.LastName)
                    .ToList();

                //foreach (var member in memberByLastName) 
                //{
                //    Console.WriteLine(member.LastName);
                //}

                var member = context.Members.FirstOrDefault(m => m.FirstName == "Charles");

                //Console.WriteLine(member.FirstName + ' ' + member.LastName);

                var membersWithActivities = context.Members
                    .Where(m => m.ActivityParticipations.Any())
                    .Select(m => new
                    {
                        FullName = m.FirstName + ' ' + m.LastName,
                        Activities = m.ActivityParticipations.Select(ap => ap.Activity.Name)
                    })
                    .ToList();

                foreach (var item in membersWithActivities)
                {
                    Console.WriteLine(item.FullName);
                    foreach(var activity in item.Activities)
                    {
                        Console.WriteLine(activity);
                    }
                    Console.WriteLine();
                }
            }
        }

        public static bool MembersOver25(Member m)
        {
            return m.Age > 25;
        }
    }
}
