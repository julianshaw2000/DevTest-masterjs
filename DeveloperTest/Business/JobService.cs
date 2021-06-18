using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            var res = from j in context.Jobs.ToList()
                      join c in context.Customers.ToList() on j.CustomerId equals c.CustomerId into gj
                      from subList in gj.DefaultIfEmpty()
                      select new JobModel
                      {
                          JobId = j.JobId,
                          Engineer = j.Engineer,
                          When = j.When,
                          CustomerId = subList == null ? 0 : subList.CustomerId,
                       //   CustomerName = subList == null ? string.Empty : subList.CustomerName,
                          CustomerName = subList?.CustomerName ?? "No Customer"
                      };

            return res.ToArray();

            //return context.Jobs.Select(x => new JobModel
            //{
            //    JobId = x.JobId,
            //    Engineer = x.Engineer,
            //    When = x.When,
            //    CustomerId = x.CustomerId,
            // //   CustomerName = co
            //}).ToArray();


        }

        public JobModel GetJob(int jobId)
        {
            return context.Jobs.Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerId != 0 ? context.Customers.FirstOrDefault(x=>x.CustomerId == x.CustomerId).CustomerName : ""
            }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId=model.CustomerId = model.CustomerId
                
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                CustomerId = addedJob.Entity.CustomerId,
                //CustomerName = addedJob.Entity.CustomerName,
                When = addedJob.Entity.When
            };
        }
    }
}
