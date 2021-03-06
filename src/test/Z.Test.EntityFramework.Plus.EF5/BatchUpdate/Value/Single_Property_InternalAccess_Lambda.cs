﻿// Description: Entity Framework Bulk Operations & Utilities (EF Bulk SaveChanges, Insert, Update, Delete, Merge | LINQ Query Cache, Deferred, Filter, IncludeFilter, IncludeOptimize | Audit)
// Website & Documentation: https://github.com/zzzprojects/Entity-Framework-Plus
// Forum & Issues: https://github.com/zzzprojects/EntityFramework-Plus/issues
// License: https://github.com/zzzprojects/EntityFramework-Plus/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.
#if EF5 || EF6
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.EntityFramework.Plus;

namespace Z.Test.EntityFramework.Plus
{
    public partial class BatchUpdate_Value
    {
        [TestMethod]
        public void Single_Property_InternalAccess_Lambda()
        {
            TestContext.DeleteAll(x => x.Internal_Entity_Basics);
            TestContext.Insert(x => x.Internal_Entity_Basics, 50);

            using (var ctx = new TestContext())
            {
                // BEFORE
                Assert.AreEqual(1225, ctx.Internal_Entity_Basics.Sum(x => x.ColumnInt));

                // ACTION
                var rowsAffected = ctx.Internal_Entity_Basics.Where(x => x.ColumnInt > 10 && x.ColumnInt <= 40).Update(x => new Internal_Entity_Basic { ColumnInt = x.ColumnInt + 99 });

                // AFTER
                Assert.AreEqual(4195, ctx.Internal_Entity_Basics.Sum(x => x.ColumnInt));
                Assert.AreEqual(30, rowsAffected);
            }
        }
    }
}
#endif