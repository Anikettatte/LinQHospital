using LinQHospital.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;

namespace LinQHospital.Models
{
    public class DoctorModel
    {
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string DocMobile { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientMobile { get; set; }
        public string SaveDoctor(DoctorModel model)
        {
            string msg = "Save";
            LinQEntities Db= new LinQEntities();
            {
                var DoctorData = new tbldoctor()
                {
                    DocName = model.DocName,
                    DocMobile = model.DocMobile,
                    Email = model.Email,
                    State = model.State,
                    City = model.City,
             

                };
                Db.tbldoctors.Add(DoctorData);
                Db.SaveChanges();
                return msg;
            }

        }
        public List<DoctorModel> GetDoctorList(String Search)
        {
            LinQEntities db = new LinQEntities();
            List<DoctorModel> lstDoctor = new List<DoctorModel>();
          
            var DoctorData = from t1 in db.tbldoctors
                             join t2 in db.tblpatients
                             on t1.DocId equals t2.DocId where t1.DocName.Contains(Search)
                             select new { t1.DocName, t1.DocMobile, t1.Email, t1.State, t1.City, t2.PatientName, t2.PatientMobile };


            if (DoctorData != null)
            {
                foreach (var Doctor in DoctorData)
                {
                    lstDoctor.Add(new DoctorModel()
                    {
                        //DocId = Doctor.DocId,
                        DocName = Doctor.DocName,
                        DocMobile = Doctor.DocMobile,
                        Email = Doctor.Email,
                        State = Doctor.State,
                        City = Doctor.City,
                        PatientName = Doctor.PatientName,
                        PatientMobile =  Doctor.PatientMobile,

                        
                    });
                }
            }
            return lstDoctor;
        }


    }
}