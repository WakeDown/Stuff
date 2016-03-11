using System;
using System.Configuration;
using System.Linq;
using DALCoordination;
using DALCoordination.Entities;
using DALStuff.Models;
using NUnit.Framework;
using employee = DALStuff.Models.employee;
using EmployeeAlternate = DALStuff.Models.EmployeeAlternate;

//using Employee = DAL.Entities.Models.Creator;

namespace CoordinationTests
{
    [TestFixture]
    public class CoordinationTest
    {
        [Test]
        public void TestEmployeesAndRequests()
        {
            var originalConnectionString = ConfigurationManager.ConnectionStrings["CoordinationDbContext"].ConnectionString;
            var stuffConnectionString = ConfigurationManager.ConnectionStrings["StuffConnectionString"].ConnectionString;
            using (StuffContext stuffDb = new StuffContext(stuffConnectionString + ";Password=sa"))
            {
                using (CoordinationContext db = new CoordinationContext(originalConnectionString + ";Password=sa"))
                {
                    var employees = stuffDb.employees;
                    var employeesAlternats = stuffDb.employeeAlternates;
                    var employeesView = db.Employees;
                    var employeesAlternatsView = db.EmployeeAlternates;
                    var requests = stuffDb.requests;
                    var requestReasons = stuffDb.request_reasons;
                    var requestStatuses = stuffDb.request_statuses;
                    var requestHistoryes = stuffDb.request_historyes;

                    int initEmployeeCnt = employees.Count();
                    int initEmployeeAlternatsCnt = employeesAlternats.Count();
                    int initCntrequests = requests.Count();
                    int initCntrequestReasons = requestReasons.Count();
                    int initCntrequestStatuses = requestStatuses.Count();
                    int initCntrequestHistoryes = requestHistoryes.Count();
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

                    var requestReason = new RequestReason
                    {
                        Name = "Нет нормальных сотрудников",
                        Description = "Поувольнять всех и набрать четких работников",
                    };
                    requestReasons.Add(requestReason);
                    stuffDb.SaveIfNoError();

                    #region new employees

                    var empl1 = new employee
                    {
                        ad_login = "Super boxs",
                        ad_sid = "Super boxs",
                        birth_date = DateTime.Now,
                        creator_sid = "Super boxs",
                        date_came = DateTime.Now,
                        date_fired = DateTime.Now,
                        dattim1 = DateTime.Now,
                        dattim2 = DateTime.Now,
                        display_name = "Super boxs",
                        email = "Super boxs",
                        enabled = true,
                        full_name = "Super boxs",
                        full_name_dat = "Super boxs",
                        full_name_rod = "Super boxs",
                        has_ad_account = true,
                        id_city = 26, // Екб
                        id_department = 17, // ИТ отдел
                        id_emp_state = 3, // Декрет
                        id_manager = 126, // Начальник - Степанов
                        id_organization = 45, // УК Юнит
                        id_position = 25, // Инженер
                        id_position_org = 25,
                        male = true,
                        mobil_num = "Super boxs",
                        name = "Super boxs",
                        newvbie_delivery = true,
                        patronymic = "Super boxs",
                        surname = "Super boxs",
                        work_num = "Super boxs",
                    };
                    var empl2 = new employee
                    {
                        ad_login = "Boxs",
                        ad_sid = "Boxs",
                        birth_date = DateTime.Now,
                        creator_sid = "Boxs",
                        date_came = DateTime.Now,
                        date_fired = DateTime.Now,
                        dattim1 = DateTime.Now,
                        dattim2 = DateTime.Now,
                        display_name = "Boxs",
                        email = "Boxs",
                        enabled = true,
                        full_name = "Boxs",
                        full_name_dat = "Boxs",
                        full_name_rod = "Boxs",
                        has_ad_account = true,
                        id_city = 26, // Екб
                        id_department = 17, // ИТ отдел
                        id_emp_state = 3, // Декрет
                        id_manager = 126, // Начальник - Степанов
                        id_organization = 45, // УК Юнит
                        id_position = 25, // Инженер
                        id_position_org = 25,
                        male = true,
                        mobil_num = "Boxs",
                        name = "Boxs",
                        newvbie_delivery = true,
                        patronymic = "Boxs",
                        surname = "Boxs",
                        work_num = "Boxs",
                    };
                    var empl3 = new employee
                    {
                        ad_login = "Max cool",
                        ad_sid = "Max cool",
                        birth_date = DateTime.Now,
                        creator_sid = "Max cool",
                        date_came = DateTime.Now,
                        date_fired = DateTime.Now,
                        dattim1 = DateTime.Now,
                        dattim2 = DateTime.Now,
                        display_name = "Max cool",
                        email = "Max cool",
                        enabled = true,
                        full_name = "Max cool",
                        full_name_dat = "Max cool",
                        full_name_rod = "Max cool",
                        has_ad_account = true,
                        id_city = 26, // Екб
                        id_department = 17, // ИТ отдел
                        id_emp_state = 3, // Декрет
                        id_manager = 126, // Начальник - Степанов
                        id_organization = 45, // УК Юнит
                        id_position = 25, // Инженер
                        id_position_org = 25,
                        male = true,
                        mobil_num = "Max cool",
                        name = "Max cool",
                        newvbie_delivery = true,
                        patronymic = "Max cool",
                        surname = "Max cool",
                        work_num = "Max cool",
                    };

                    #endregion

                    employees.Add(empl3);
                    employees.Add(empl2);
                    employees.Add(empl1);
                    stuffDb.SaveChanges();

                    #region Связи замещения

                    var empAlter = new EmployeeAlternate
                    {
                        AlternateEmployeeSid = empl2.ad_sid,
                        EmployeeSid = empl3.ad_sid,
                    };
                    employeesAlternats.Add(empAlter);
                    bool checkConstraintWork = false;
                    try
                    {
                        stuffDb.SaveChanges();
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
                        stuffDb.SaveChanges();
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
                        stuffDb.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        checkConstraintWork = true;
                    }
                    Assert.False(checkConstraintWork);
                    var empAlter2 = new EmployeeAlternate
                    {
                        AlternateEmployeeSid = empl1.ad_sid,
                        EmployeeSid = empl3.ad_sid,
                        Unlimited = true
                    };
                    var empAlter3 = new EmployeeAlternate
                    {
                        AlternateEmployeeSid = empl1.ad_sid,
                        EmployeeSid = empl2.ad_sid,
                        Unlimited = true
                    };
                    employeesAlternats.Add(empAlter2);
                    employeesAlternats.Add(empAlter3);
                    stuffDb.SaveChanges();
                    //Max 2 зама и никого не замещает его
                    Assert.AreEqual(empl3.EmployeeReplaceds.Count, 0);
                    Assert.AreEqual(empl3.EmployeeAlternates.Count, 2);
                    //Boxs замещает Maxа и его замещает SuperBoxs
                    Assert.AreEqual(empl2.EmployeeReplaceds.Count, 1);
                    Assert.AreEqual(empl2.EmployeeAlternates.Count, 1);
                    //SuperBoxs замещает 2 а его никто
                    Assert.AreEqual(empl1.EmployeeReplaceds.Count, 2);
                    Assert.AreEqual(empl1.EmployeeAlternates.Count, 0);

                    Assert.AreEqual(empAlter.Alternate.id, empl2.id);
                    Assert.AreEqual(empAlter.Replaced.id, empl3.id);
                    Assert.AreEqual(empAlter2.Alternate.id, empl1.id);
                    Assert.AreEqual(empAlter2.Replaced.id, empl3.id);
                    Assert.AreEqual(empAlter3.Alternate.id, empl1.id);
                    Assert.AreEqual(empAlter3.Replaced.id, empl2.id);

                    //проверка Views
                    var em1 = employeesView.First(it => it.Id == empl1.id);
                    var em2 = employeesView.First(it => it.Id == empl2.id);
                    var em3 = employeesView.First(it => it.Id == empl3.id);
                    var emA1 = employeesAlternatsView.First(it => it.Id == empAlter.Id);
                    var emA2 = employeesAlternatsView.First(it => it.Id == empAlter2.Id);
                    var emA3 = employeesAlternatsView.First(it => it.Id == empAlter3.Id);

                    //Max 2 зама и никого не замещает его
                    Assert.AreEqual(em3.EmployeeReplaceds.Count, 0);
                    Assert.AreEqual(em3.EmployeeAlternates.Count, 2);
                    //Boxs замещает Maxа и его замещает SuperBoxs
                    Assert.AreEqual(em2.EmployeeReplaceds.Count, 1);
                    Assert.AreEqual(em2.EmployeeAlternates.Count, 1);
                    //SuperBoxs замещает 2 а его никто
                    Assert.AreEqual(em1.EmployeeReplaceds.Count, 2);
                    Assert.AreEqual(em1.EmployeeAlternates.Count, 0);

                    Assert.AreEqual(emA1.Alternate.Id, empl2.id);
                    Assert.AreEqual(emA1.Replaced.Id, empl3.id);
                    Assert.AreEqual(emA2.Alternate.Id, empl1.id);
                    Assert.AreEqual(emA2.Replaced.Id, empl3.id);
                    Assert.AreEqual(emA3.Alternate.Id, empl1.id);
                    Assert.AreEqual(emA3.Replaced.Id, empl2.id);

                    //проверка на NavigationProperty
                    //Assert.AreEqual(empl3.EmployeesReplaced.Count(), 0);
                    //Assert.AreEqual(empl3.EmployeeReplaceds.Count(), 2);
                    //Assert.AreEqual(empl2.EmployeesReplaced.Count(), 0);
                    //Assert.AreEqual(empl2.EmployeeReplaceds.Count(), 2);
                    //Assert.AreEqual(empl3.EmployeesReplaced.Count(), 0);
                    //Assert.AreEqual(empl3.EmployeeReplaceds.Count(), 2);

                    #endregion

                    RequestStatus status1 = new RequestStatus
                    {
                        Name = "Новая",
                        Description = "Снова надо каких то обормотов нанимать"
                    };
                    RequestStatus status2 = new RequestStatus
                    {
                        Name = "Старая",
                        Description = "Все отмучились!"
                    };
                    request request = new request
                    {
                        ContactPerson = empl1,
                        ManagerPersom = empl2,
                        ResponsiblePerson = empl3,
                        TeacherPerson = empl1,
                        IdDepartment = 17, // ИТ отдел
                        IdPosition = 25, // Инженер
                        RequestStatus = status1
                    };
                    requestReason.Requests.Add(request);
                    stuffDb.SaveIfNoError();

                    request.RequestStatus = status2;
                    var requestHistory = new request_history
                    {
                        Creator = empl2,
                        Date = DateTime.Now,
                        Request = request,
                        NewRequestStatuses = status2,
                        OldRequestStatuses = status1,
                    };
                    requestHistoryes.Add(requestHistory);
                    stuffDb.SaveIfNoError();



                    Assert.AreEqual(request.SidContactPerson, empl1.ad_sid);
                    Assert.AreEqual(request.SidManager, empl2.ad_sid);
                    Assert.AreEqual(request.SidResponsiblePerson, empl3.ad_sid);
                    Assert.AreEqual(request.SidTeacher, empl1.ad_sid);

                    int newEmployeeCnt = employees.Count();
                    int newEmployeeCntView = employeesView.Count();
                    int newEmployeeAlternatsCnt = employeesAlternats.Count();
                    int newEmployeeAlternatsCntView = employeesAlternatsView.Count();
                    int newCntrequests = requests.Count();
                    int newCntrequestReasons = requestReasons.Count();
                    int newCntrequestStatuses = requestStatuses.Count();
                    int newCntrequestHistoryes = requestHistoryes.Count();
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
                    Assert.AreEqual(newEmployeeCnt, newEmployeeCntView);
                    Assert.AreEqual(newEmployeeAlternatsCnt, newEmployeeAlternatsCntView);

                    Assert.AreEqual(newEmployeeCnt, initEmployeeCnt + 3);
                    Assert.AreEqual(newEmployeeAlternatsCnt, initEmployeeAlternatsCnt + 3);

                    Assert.AreEqual(newCntrequests, initCntrequests + 1);
                    Assert.AreEqual(newCntrequestReasons, initCntrequestReasons + 1);
                    Assert.AreEqual(newCntrequestStatuses , initCntrequestStatuses + 2);
                    Assert.AreEqual(newCntrequestHistoryes, initCntrequestHistoryes + 1);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);


                    employees.Remove(empl3);
                    employees.Remove(empl2);
                    employees.Remove(empl1);
                    employeesAlternats.Remove(empAlter);
                    employeesAlternats.Remove(empAlter2);
                    employeesAlternats.Remove(empAlter3);
                    requests.Remove(request);
                    requestReasons.Remove(requestReason);

                    requestStatuses.Remove(status1);
                    requestStatuses.Remove(status2);

                    requestHistoryes.Remove(requestHistory);

                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();

                    db.SaveChanges();
                    stuffDb.SaveIfNoError();

                    int actualEmploueeCnt = employees.Count();
                    int actualEmployeeAlternatsCnt = employeesAlternats.Count();
                    int actualEmploueeCntView = employeesView.Count();
                    int actualEmployeeAlternatsCntView = employeesAlternatsView.Count();
                    int actualCntrequests = requests.Count();
                    int actualCntrequestReasons = requestReasons.Count();
                    int actualCntrequestStatuses = requestStatuses.Count();
                    int actualCntrequestHistoryes = requestHistoryes.Count();
                    //int actualCnt = .Count();
                    //int actualCnt = .Count();
                    //int actualCnt = .Count();
                    //int actualCnt = .Count();
                    //int actualCnt = .Count();
                    //int actualCnt = .Count();
                    //int actualCnt = .Count();
                    //int actualCnt = .Count();

                    Assert.AreEqual(actualEmploueeCnt, initEmployeeCnt);
                    Assert.AreEqual(actualEmployeeAlternatsCnt, initEmployeeAlternatsCnt);
                    Assert.AreEqual(actualEmploueeCntView, initEmployeeCnt);
                    Assert.AreEqual(actualEmployeeAlternatsCntView, initEmployeeAlternatsCnt);
                    Assert.AreEqual(actualCntrequests , initCntrequests);
                    Assert.AreEqual(actualCntrequestReasons , initCntrequestReasons);
                    Assert.AreEqual(actualCntrequestStatuses , initCntrequestStatuses);
                    Assert.AreEqual(actualCntrequestHistoryes, initCntrequestHistoryes);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                }
            }
        }
        [Test]
        public void TestCoordinations()
        {
            var originalConnectionString = ConfigurationManager.ConnectionStrings["CoordinationDbContext"].ConnectionString;
            var stuffConnectionString = ConfigurationManager.ConnectionStrings["StuffConnectionString"].ConnectionString;

            using (StuffContext stuffDb = new StuffContext(stuffConnectionString + ";Password=sa"))
            {
                using (CoordinationContext db = new CoordinationContext(originalConnectionString + ";Password=sa"))
                {
                    var employees = stuffDb.employees;
                    var emplRoles = stuffDb.employeeRoles;

                    var documentTypes = db.DocumentTypes;

                    var schemesStages = db.WfwSchemeStages;
                    var schemes = db.WfwSchemes;

                    var eventResults = db.WfwEventsResults;
                    var events = db.WfwExecutionEvents;

                    int initDocTypeCnt = documentTypes.Count();

                    int initCntschemesStages = schemesStages.Count();
                    int initCntschemes = schemes.Count();

                    int initCnteventResults = eventResults.Count();
                    int initCntevents = events.Count();
                    int initCntemployees = employees.Count();
                    int initCntemplRoles = emplRoles.Count();
                    //int initCnt = .Count();
                    //int initCnt = .Count();
                    //int initCnt = .Count();
                    //int initCnt = .Count();
                    //int initCnt = .Count();
                    //int initCnt = .Count();
                    //int initCnt = .Count();
                    //int initCnt = .Count();

                    #region new employees

                    var empl1 = new employee
                    {
                        ad_login = "Super boxs",
                        ad_sid = "Super boxs",
                        birth_date = DateTime.Now,
                        creator_sid = "Super boxs",
                        date_came = DateTime.Now,
                        date_fired = DateTime.Now,
                        dattim1 = DateTime.Now,
                        dattim2 = DateTime.Now,
                        display_name = "Super boxs",
                        email = "Super boxs",
                        enabled = true,
                        full_name = "Super boxs",
                        full_name_dat = "Super boxs",
                        full_name_rod = "Super boxs",
                        has_ad_account = true,
                        id_city = 26, // Екб
                        id_department = 17, // ИТ отдел
                        id_emp_state = 3, // Декрет
                        id_manager = 126, // Начальник - Степанов
                        id_organization = 45, // УК Юнит
                        id_position = 25, // Инженер
                        id_position_org = 25,
                        male = true,
                        mobil_num = "Super boxs",
                        name = "Super boxs",
                        newvbie_delivery = true,
                        patronymic = "Super boxs",
                        surname = "Super boxs",
                        work_num = "Super boxs",
                    };
                    var empl2 = new employee
                    {
                        ad_login = "Boxs",
                        ad_sid = "Boxs",
                        birth_date = DateTime.Now,
                        creator_sid = "Boxs",
                        date_came = DateTime.Now,
                        date_fired = DateTime.Now,
                        dattim1 = DateTime.Now,
                        dattim2 = DateTime.Now,
                        display_name = "Boxs",
                        email = "Boxs",
                        enabled = true,
                        full_name = "Boxs",
                        full_name_dat = "Boxs",
                        full_name_rod = "Boxs",
                        has_ad_account = true,
                        id_city = 26, // Екб
                        id_department = 17, // ИТ отдел
                        id_emp_state = 3, // Декрет
                        id_manager = 126, // Начальник - Степанов
                        id_organization = 45, // УК Юнит
                        id_position = 25, // Инженер
                        id_position_org = 25,
                        male = true,
                        mobil_num = "Boxs",
                        name = "Boxs",
                        newvbie_delivery = true,
                        patronymic = "Boxs",
                        surname = "Boxs",
                        work_num = "Boxs",
                    };
                    var empl3 = new employee
                    {
                        ad_login = "Max cool",
                        ad_sid = "Max cool",
                        birth_date = DateTime.Now,
                        creator_sid = "Max cool",
                        date_came = DateTime.Now,
                        date_fired = DateTime.Now,
                        dattim1 = DateTime.Now,
                        dattim2 = DateTime.Now,
                        display_name = "Max cool",
                        email = "Max cool",
                        enabled = true,
                        full_name = "Max cool",
                        full_name_dat = "Max cool",
                        full_name_rod = "Max cool",
                        has_ad_account = true,
                        id_city = 26, // Екб
                        id_department = 17, // ИТ отдел
                        id_emp_state = 3, // Декрет
                        id_manager = 126, // Начальник - Степанов
                        id_organization = 45, // УК Юнит
                        id_position = 25, // Инженер
                        id_position_org = 25,
                        male = true,
                        mobil_num = "Max cool",
                        name = "Max cool",
                        newvbie_delivery = true,
                        patronymic = "Max cool",
                        surname = "Max cool",
                        work_num = "Max cool",
                    };

                    #endregion

                    var emplRole1 = new DALStuff.Models.EmployeeRole
                    {
                        Name = "роль короля мира!",
                        Employee = empl3,
                    };
                    stuffDb.SaveIfNoError();

                    var scheme = new WfwScheme
                    {
                        Action = 1,
                        ContinueLastStage = true,
                        Name = "Да согласуйте это вы уже!",
                    };

                    var schemeStage = new WfwSchemeStage
                    {
                        Name = "попытка номер раз",
                        Level = 0,
                        EmployeeRole = db.EmployeeRoles.OrderByDescending(it=>it.Id).First(),
                        WfwScheme = scheme,
                        
                    };

                    var docType1 = new DocumentType
                    {
                        Description = "Только в сартир.",
                        Name = "Писулька",
                        WfwScheme = scheme,
                    };
                    documentTypes.Add(docType1);

                    var wfwEvResult = new WfwEventResult
                    {
                        Name = "Че то порешали",
                        Success = false,
                        Description = "\"Ну не шмогла я\" - не договорилсь",
                    };


                    var wflEvent = new WfwExecutionEvent
                    {

                    };
                    db.SaveChanges();

                    int newDocTypeCnt = documentTypes.Count();
                    int newCntschemes = schemes.Count();
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
                    Assert.AreEqual(newCntschemes, initCntschemes + 1);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);
                    //Assert.AreEqual(newCnt , initCnt);

                    documentTypes.Remove(docType1);
                    schemes.Remove(scheme);
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();
                    //.Remove();

                    db.SaveChanges();

                    int actualDocTypeCnt = documentTypes.Count();
                    int actualCntschemes = schemes.Count();
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
                    Assert.AreEqual(actualCntschemes, initCntschemes);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                    //Assert.AreEqual(actualCnt , initCnt);
                }
            }
        }
    }
}