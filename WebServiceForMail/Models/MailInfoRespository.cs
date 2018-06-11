using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;


namespace WebServiceForMail.Models
{
    public class MailInfoRespository
    {
        private static MailInfoRespository mlpo=new MailInfoRespository();
        //

        DbEntities be = new DbEntities();
        //System.Data.Objects.ObjectStateManager objectStateManager = be.ObjectStateManager();

        public static MailInfoRespository Current
        { get { return mlpo; } }

        private List<MailInfo> data
        { get { return be.MailInfos.ToList(); }
        }


        //    {
        //        new MailInfo {
        //          MailID=1,  UserID = "A3104505", UserName = "Jack", MailAddress = "Jack.Bond@163.com",Goup="SNA",PhoneNum="18721207543"},
        //        new MailInfo {
        //         MailID=2,    UserID = "A3104506", UserName = "Mike", MailAddress = "Mike.Bond@163.com",Goup="SNA",PhoneNum="18721207573"},
        //        new MailInfo {
        //          MailID=3,   UserID = "A3104507", UserName = "Robert", MailAddress = "Robert.Bond@163.com",Goup="SF",PhoneNum="18721207583"},
        //};



        public IEnumerable<MailInfo> GetAll()
        {
            return data;
        }

        public MailInfo Get(int id)
        {
            return data.Where(r => r.MailID == id).FirstOrDefault();
        }

        //更改的方法
        public MailInfo Add(MailInfo item)
        {
            item.MailID = data.Max(e=>e.MailID) + 1;
            data.Add(item);
            be.MailInfos.Add(item);
            //be.ObjectStateManager.ChangeObjectState(student, EntityState.Modified);
            be.SaveChanges();
            return item;
        }

        public void Remove(int id)
        {
            MailInfo item = Get(id);
            if (item != null)
            {
                data.Remove(item);
                be.MailInfos.Remove(item);
                be.SaveChanges();
            }
        }

        public bool Update(MailInfo item)
        {
            MailInfo storedItem = Get(item.MailID);
            if (storedItem != null)
            {
                storedItem.UserID = item.UserID;
                storedItem.UserName = item.UserName;
                storedItem.MailAddress = item.MailAddress;
                storedItem.Goup = item.Goup;
                storedItem.PhoneNum = item.PhoneNum;

                be.MailInfos.Attach(storedItem);
                be.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}