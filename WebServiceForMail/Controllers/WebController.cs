using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Entity;
using WebServiceForMail.Models;


namespace WebServiceForMail.Controllers
{
    public class WebController : ApiController
    {
        private MailInfoRespository repo = MailInfoRespository.Current;

        public IEnumerable<MailInfo> GetAllMailInfos()
        {
            return repo.GetAll();
        }

        public MailInfo GetMailInfo(int id)
        {
            return repo.Get(id);
        }

        [HttpPost]
        public MailInfo CreateMailInfo(MailInfo item)
        {
            return repo.Add(item);
        }

        [HttpPut]
        public bool UpdateMailInfo(MailInfo item)
        {
            return repo.Update(item);
        }

        public void DeleteMailInfo(int id)
        {
            repo.Remove(id);
        }

        //private IMailInfoRepository repository;


        //public WebController(IMailInfoRepository mailinfoRepository)
        //{
        //    this.repository = mailinfoRepository;
        //}



        ////private EFDbContext context = new EFDbContext();

        ////public IEnumerable<MailInfo> MailInfos
        ////{
        ////    get { return context.MailInfos; }
        ////}

        //public IEnumerable<MailInfo> GetAllMailInfos()
        //{
        //    return repository.MailInfos;
        //}

        //[HttpPost]
        //public MailInfo CreateMailInfo(MailInfo mailInfo)
        //{
        //    if (mailInfo.MailID == 0)
        //    {
        //        repository.Add(mailInfo);
        //    }
        //    else
        //    {
        //        mailInfo.MailID = context.MailInfos.Max(e => e.MailID) + 1;
        //        context.MailInfos.Add(mailInfo);
        //    }
        //    context.SaveChanges();
        //    return mailInfo;
        //}

        //[HttpPut]
        //public bool UpdateMailInfo(MailInfo mailInfo)
        //{

        //    if (mailInfo.MailID == 0)
        //    {
        //        context.MailInfos.Add(mailInfo);
        //    }
        //    else
        //    {
        //        MailInfo dbEntry = context.MailInfos.Find(mailInfo.MailID);
        //        if (dbEntry != null)
        //        {
        //            dbEntry.UserID = mailInfo.UserID;
        //            dbEntry.UserName = mailInfo.UserName;
        //            dbEntry.MailAddress = mailInfo.MailAddress;
        //            dbEntry.Goup = mailInfo.Goup;
        //            dbEntry.PhoneNum = mailInfo.PhoneNum;

        //        }
        //    }
        //    context.SaveChanges();
        //    return true;

        //}

        //public void DeleteMailInfo(int mailID)
        //{
        //    MailInfo dbEntry = context.MailInfos.Find(mailID);
        //    if (dbEntry != null)
        //    {
        //        context.MailInfos.Remove(dbEntry);
        //        context.SaveChanges();
        //    }
        //}


        //public MailInfo GetMailInfo(int id)
        //{
        //    return MailInfos.Where(r => r.MailID == id).FirstOrDefault();
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    context.Dispose();
        //    base.Dispose(disposing);
        //}


    }
}
