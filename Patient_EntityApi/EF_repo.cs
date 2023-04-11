using System.IO;
using EF_Layer.Entities;
using Models;

namespace EF_Layer
{
    public class EF_repo : IRepo
    {
        PatientInfoDbContext context = new PatientInfoDbContext();

        public Patient AddPatient(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();

            return patient;
        }

        public List<Patient> GetAllPatient()
        {
            return context.Patients.ToList();
        }

        public Patient GetByID(int id)
        {
            var patients = context.Patients;
            var query = from p in patients
                        where p.Id == id
                        select p;
            Patient patient = new Patient();
            foreach (var pat in query)
            {
                patient = new Patient()
                {
                    Id = pat.Id,
                    Email = pat.Email,
                    Title = pat.Title,
                    FirstName = pat.FirstName,
                    LastName = pat.LastName,
                    Dob = pat.Dob,
                    ContactNumber = pat.ContactNumber,
                    Password = pat.Password,
                    Gender = pat.Gender,
                    Address = pat.Address,
                };
            }
            return patient;
        }

        public Patient UpdatePatient(Patient patient)
        {
            context.Patients.Update(patient);
            context.SaveChanges();

            return patient;
        }

        public int login(string email, string password)
        {
            var query_1 = context.Patients.FirstOrDefault(v => v.Email == email);

            if (query_1 != null)
            {
                if (query_1.Password == password)
                {
                    var result = context.Patients;
                    var patient_id = context.Patients.FirstOrDefault(v => v.Email == email);

                    return patient_id.Id;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        //Visit Details
        public VisitDetail AddVisitDetails(VisitDetail visitDetail)
        {
            context.VisitDetails.Add(visitDetail);
            context.SaveChanges();

            return visitDetail;
        }

        public List<VisitDetail> GetVisitById(int id)
        {


            var visitDetails = context.VisitDetails;
            var query = from v in visitDetails
                        where v.PatientId == id
                        select v;
            List<VisitDetail> visitDetail = new List<VisitDetail>();

            foreach (var vi in query)
            {
                VisitDetail visit_Details_M = new VisitDetail()
                {

                    Id = vi.Id,
                    PatientId = vi.PatientId,
                    Height = vi.Height,
                    Weight = vi.Weight,
                    BloodPressureSystolic = vi.BloodPressureSystolic,
                    BloodPressureDiastolic = vi.BloodPressureDiastolic,
                    BodyTemperature = vi.BodyTemperature,
                    RespirationRate = vi.RespirationRate,
                    BloodGroup = vi.BloodGroup,
                    NurseEmail = vi.NurseEmail,
                    PhysicianEmail = vi.PhysicianEmail,
                    AppointmentId = vi.AppointmentId,
                    KeyNotes = vi.KeyNotes


                };
                visitDetail.Add(visit_Details_M);

            };
            return visitDetail;

        }

        public VisitDetail GetPaticularVisitById(int id)
        {

            var visitDetails = context.VisitDetails.FirstOrDefault(x => x.Id == id);

            return visitDetails;

        }

        public VisitDetail GetbyAcceptanceId(int id)
        {
            var visit = context.VisitDetails.FirstOrDefault(x => x.AppointmentId == id);

            return visit;
        }


        //Prescription
        public Prescription AddPrescription(Prescription prescription)
        {
            context.Prescriptions.Add(prescription);
            context.SaveChanges();
            return prescription;
        }


        public List<Prescription> GetPrescriptionById(int id)
        {
            var pres = context.Prescriptions;
            var query = from p in pres
                        where p.VisitDetailsId == id
                        select p;

            List<Prescription> prescription = new List<Prescription>();
            foreach (var pi in query)
            {
                Prescription prescription1 = new Prescription()
                {
                    Id = pi.Id,
                    VisitDetailsId = pi.VisitDetailsId,
                    PrescriptionName = pi.PrescriptionName,
                    Dosage = pi.Dosage,
                    Notes = pi.Notes
                };
                prescription.Add(prescription1);
                //Prescription prescription = new Prescription()
                //    {
                //        Id = pi.Id,
                //        VisitDetailsId = pi.VisitDetailsId,
                //        PrescriptionName = pi.PrescriptionName,
                //        Dosage = pi.Dosage,
                //        Notes = pi.Notes
                //    };
            }
            return prescription;
        }

        public bool ExistingPatient(string email)
        {
            var pat = context.Patients;


            var query = (from p in pat
                         where p.Email == email
                         select p).FirstOrDefault();
            try
            {
                if (email == query.Email)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }

        }

        public bool isExistPhone(string phone)
        {
            var pat = context.Patients;


            var query = (from p in pat
                         where p.ContactNumber == phone
                         select p).FirstOrDefault();
            try
            {
                if (phone == query.ContactNumber)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }

        }

        //test methods
        public Test AddTest(Test test)
        {
            context.Tests.Add(test);
            context.SaveChanges();
            return test;
        }

        public List<Test> GetTestList(int visitId)
        {
            List<Test> TList = new List<Test>();
            foreach (var e in context.Tests.ToList())
            {
                if (e.VisitDetailsId == visitId)
                {
                    TList.Add(e);
                }
            }
            return TList;
        }


        public Test UpdateTest(Test test)
        {
            context.Tests.Update(test);
            context.SaveChanges();
            return test;
        }


        public int GetTestIdByName(string name)
        {
            var Test = context.Tests.FirstOrDefault(x => x.TestName == name);
            if (Test != null) { return Test.Id; }
            else
            {
                return 0;
            }
        }

        public Test DeleteTest(int TestID)
        {
            var test = context.Tests;

            var query = (from p in test
                         where p.Id == TestID
                         select p).FirstOrDefault();
            context.Tests.Remove(query);
            context.SaveChanges();
            return query;
        }



    }
}
