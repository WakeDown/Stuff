using System;
using System.Configuration;
using System.Linq;
using CoordinationDB;
using DAL.Entities.Models;
using NUnit.Framework;

namespace NUnitTestProject1
{
    [TestFixture]
    public class CoordinationTest
    {
        [Test]
        public void TestCoordinationScheme()
        {
            var originalConnectionString = ConfigurationManager.ConnectionStrings["CoordinationDbContext"].ConnectionString;


            using (CoordinationContext db = new CoordinationContext(originalConnectionString + ";Password=sa"))
            {
                var documentTypes = db.DocumentTypes;
                var employees = db.employees;
                var employeesAlternats = db.EmployeeAlternates;



                int initDocTypeCnt = documentTypes.Count();
                int initEmployeeCnt = employees.Count();
                int initEmployeeAlternatsCnt = employeesAlternats.Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();
                //int initCnt = .Count();




                var docType1 = new DocumentType
                {
                    Description = "Только в сартир.",
                    Name = "Писулька",
                };
                documentTypes.Add(docType1);
                db.SaveChanges();
                var empl1 = new employee {Name = "Super boxs"};
                var empl2 = new employee { Name = "Boxs" };
                var empl3 = new employee { Name = "MaxCool" };
                employees.Add(empl3);
                employees.Add(empl2);
                employees.Add(empl1);
                db.SaveChanges();


                #region Связи замещения

                var empAlter = new EmployeeAlternate
                {
                    AlternateEmployeeId = empl2.Id,
                    EmployeeId = empl3.Id,
                };
                employeesAlternats.Add(empAlter);
                bool checkConstraintWork = false;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    checkConstraintWork = true;
                }
                Assert.True(checkConstraintWork);
                empAlter.StartDate = DateTime.Now;
                empAlter.EndDate = DateTime.Now.AddDays(31);
                empAlter.Unlimited = true;
                checkConstraintWork = false;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    checkConstraintWork = true;
                }
                Assert.True(checkConstraintWork);
                empAlter.StartDate = DateTime.Now;
                empAlter.EndDate = DateTime.Now.AddDays(31);
                empAlter.Unlimited = null;
                checkConstraintWork = false;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    checkConstraintWork = true;
                }
                Assert.False(checkConstraintWork);
                var empAlter2 = new EmployeeAlternate
                {
                    AlternateEmployeeId = empl1.Id,
                    EmployeeId = empl3.Id,
                    Unlimited = true
                };
                var empAlter3 = new EmployeeAlternate
                {
                    AlternateEmployeeId = empl1.Id,
                    EmployeeId = empl2.Id,
                    Unlimited = true
                };
                employeesAlternats.Add(empAlter2);
                employeesAlternats.Add(empAlter3);
                db.SaveChanges();
                //Max 2 зама и никого не замещает его
                Assert.AreEqual(empl3.EmployeeReplaceds.Count, 0);
                Assert.AreEqual(empl3.EmployeeAlternates.Count, 2);
                //Boxs замещает Maxа и его замещает SuperBoxs
                Assert.AreEqual(empl2.EmployeeReplaceds.Count, 1);
                Assert.AreEqual(empl2.EmployeeAlternates.Count, 1);
                //SuperBoxs замещает 2 а его никто
                Assert.AreEqual(empl1.EmployeeReplaceds.Count, 2);
                Assert.AreEqual(empl1.EmployeeAlternates.Count, 0);

                #endregion



                //проверка на NavigationProperty
                //Assert.AreEqual(empl3.EmployeesReplaced.Count(), 0);
                //Assert.AreEqual(empl3.EmployeeReplaceds.Count(), 2);
                //Assert.AreEqual(empl2.EmployeesReplaced.Count(), 0);
                //Assert.AreEqual(empl2.EmployeeReplaceds.Count(), 2);
                //Assert.AreEqual(empl3.EmployeesReplaced.Count(), 0);
                //Assert.AreEqual(empl3.EmployeeReplaceds.Count(), 2);
                int newDocTypeCnt = documentTypes.Count();
                int newEmployeeCnt = employees.Count();
                int newEmployeeAlternatsCnt = employeesAlternats.Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();
                //int newCnt = .Count();

                Assert.AreEqual(newDocTypeCnt, initDocTypeCnt + 1);
                Assert.AreEqual(newEmployeeCnt, initEmployeeCnt + 3);
                Assert.AreEqual(newEmployeeAlternatsCnt, initEmployeeAlternatsCnt + 3);
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );

                documentTypes.Remove(docType1);
                employees.Remove(empl3);
                employees.Remove(empl2);
                employees.Remove(empl1);
                employeesAlternats.Remove(empAlter);
                employeesAlternats.Remove(empAlter2);
                employeesAlternats.Remove(empAlter3);
                db.SaveChanges();







                int actualDocTypeCnt = documentTypes.Count();
                int actualEmploueeCnt = employees.Count();
                int actualEmployeeAlternatsCnt = employeesAlternats.Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();
                //int actualCnt = .Count();

                Assert.AreEqual(actualDocTypeCnt, initDocTypeCnt);
                Assert.AreEqual(actualEmploueeCnt, initEmployeeCnt);
                Assert.AreEqual(actualEmployeeAlternatsCnt, initEmployeeAlternatsCnt);
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );
                //Assert.AreEqual(, );







            }
        }
    }
}