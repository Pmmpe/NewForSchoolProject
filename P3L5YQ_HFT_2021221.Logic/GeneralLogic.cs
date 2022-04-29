namespace P3L5YQ_HFT_2021221.Logic
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class GeneralLogic <T>
    {
        public GeneralLogic(DbContext context)
        {
            this.context = context;
        }

        protected DbContext context;
    }
}
