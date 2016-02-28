namespace RepTec.Console
{
    using App.EntitiesServices;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var repairersService = new RepairersService();
            var repairers = repairersService.GetAll();
            foreach (var repairer in repairers)
            {
                Console.WriteLine(repairer.Name);
            }

            Console.ReadLine();
        }
    }
}