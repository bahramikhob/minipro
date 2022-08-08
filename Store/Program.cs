using Store.Repository;
using System;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Querys.AddDefaultData();
            //  Querys.ClientVsServerAfter03();
            // Querys.EagerLoadingSample01();
            //Querys.EagerLoadingSample02();
            //Querys.SelectLoading();
            //Querys.ClientVsServerBefore3();
            //Querys.CheckEntityState();

            //CommandRepository.EditCourseGet(1);

            // TipRepository.GetByDbSET();

            //TipRepository.RelationShipSimple();
            //TipRepository.RelationShipNormal();

           // RelationManyToManyBySelf.AddEmployees();
           RelationManyToManyBySelf.ReadEmployees();


            // RelationManyToManyBySelf.AddParent();
            // RelationManyToManyBySelf.GetParentIncludeChild();


            //RelationManyToManyBySelf.AddChildToParent();
            // RelationManyToManyBySelf.GetParentIncludeChild();
            // RelationManyToManyBySelf.GetParentIncludeChildSplitedQuery();

            MutedFail.Get();

            Console.ReadLine();
        }
    }
}
