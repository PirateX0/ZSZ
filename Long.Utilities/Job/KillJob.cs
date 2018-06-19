using Quartz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Long.Utilities.Job
{
    public class KillJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(context.Trigger.StartTimeUtc + " : check kill progress status... ");

            if (!IsRun())
            {
                return;
            }

            Console.WriteLine(context.Trigger.StartTimeUtc + " : start kill progress... ");

            Kill();
            Stop();

            Console.WriteLine(context.Trigger.StartTimeUtc + " : finish kill progress... ");
        }

        private bool IsRun()
        {
            string sql = "select * from T_Tasks where Name = 'KillJob'";
            DataTable dataTable = sqlHelper.executeDataTable(sql);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow["Status"].ToString() == "1")
                {
                    return true;
                }
            }
            return false;
        }

        private void Kill()
        {
            string sql = "update  T_Tasks set status='0'  where Name = 'BuildJob'";
             sqlHelper.executeNonQuery(sql);
          
        }

        private void Stop()
        {
            string sql = "update  T_Tasks set status='0'  where Name = 'KillJob'";
            sqlHelper.executeNonQuery(sql);

        }
    }
}
