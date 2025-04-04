using Lektion_med_Petter_REPETION.Services;

namespace Lektion_med_Petter_REPETION
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //EFService.ShowMembers();
            //Console.WriteLine();
            //ADOService.ShowMembers();
            //Console.WriteLine();
            //ADOService.ShowActivities();
            //Console.WriteLine();
            //ADOService.ShowMembersAndActivities();
            //Console.WriteLine();
            EFService.QueryTests();
            Console.ReadKey();
        }
    }
}
