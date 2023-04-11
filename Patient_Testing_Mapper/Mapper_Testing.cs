using Patient_Bussiness_Logic;
using Models;
using PE = EF_Layer.Entities;
using EF_Layer.Entities;

namespace Patient_Testing_Mapper
{
    [TestFixture]
    public class Tests
    {
        Mapper map = new Mapper();


        // entity to model 
        [Test]
        public void Test1()
        {
            PE.Patient patient = new PE.Patient();
            var model = map.MapPatient(patient);
            Assert.AreEqual(model.GetType(), typeof(Patient_M));
        }

        [Test]
        public void Test2()
        {
            PE.VisitDetail patient = new PE.VisitDetail();
            var model = map.mapVisitDetailEM(patient);
            Assert.AreEqual(model.GetType(), typeof(Visit_Details_M));
        }

        [Test]
        public void Test3()
        {
            PE.Prescription patient = new PE.Prescription();
            var model = map.mapPrescriptionEM(patient);
            Assert.AreEqual(model.GetType(), typeof(Prescription_M));
        }

        [Test]
        public void Test4()
        {
            PE.Test patient = new PE.Test();
            var model = map.mapTestEM(patient);
            Assert.AreEqual(model.GetType(), typeof(Test_M));
        }

        // model to entity

        [Test]
        public void Test5()
        {
            Patient_M patient = new Patient_M();
            var model = map.mapPatient(patient);
            Assert.AreEqual(model.GetType(), typeof(PE.Patient));
        }

        [Test]
        public void Test6()
        {
            Visit_Details_M patient = new Visit_Details_M();
            var model = map.mapVisitDetailME(patient);
            Assert.AreEqual(model.GetType(), typeof(PE.VisitDetail));
        }

        [Test]
        public void Test7()
        {
            Prescription_M patient = new Prescription_M();
            var model = map.mapPrescriptionME(patient);
            Assert.AreEqual(model.GetType(), typeof(PE.Prescription));
        }

        [Test]
        public void Test8()
        {
            Test_M patient = new Test_M();
            var model = map.mapTestME(patient);
            Assert.AreEqual(model.GetType(), typeof(PE.Test));
        }
    }
}