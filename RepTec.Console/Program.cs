using RepTec.Core.Entity;
using RepTec.DataAccess;

namespace RepTec.Console
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var db = new RepTecUnitOfWork();
            db.RepairersRepository.Insert(new Repairer { Name = "Test!" });
            db.Commit();

            var repairers = db.RepairersRepository.GetAll();
            foreach (var repairer in repairers)
            {
                Console.WriteLine(repairer.Name);
            }

            Console.ReadLine();
        }
    }
}