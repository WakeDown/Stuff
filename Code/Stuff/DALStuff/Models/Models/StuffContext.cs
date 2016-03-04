using System;
using System.Data.Entity;
using System.Linq;
using DALStuff.Models.Mapping;

namespace DALStuff.Models
{
    public partial class StuffContext : DbContext
    {
        static StuffContext()
        {
            Database.SetInitializer<StuffContext>(null);
        }

        public StuffContext()
            : base("Name=StuffContext")
        {
        }
        public StuffContext(string connString)
            : base(connString)
        {
        }

        public void SaveIfNoError()
        {
            string errMsg = "";
            if (GetValidationErrors().Any())
            {
                errMsg = GetValidationErrors().SelectMany(
                    validationResults => validationResults.ValidationErrors)
                    .Aggregate(errMsg, (current, error) => current + string.Format("Entity Property: {0}, Error {1}", error.PropertyName, error.ErrorMessage));

                throw new Exception(errMsg);
            }
            else
            {
                SaveChanges();
            }
        }

        public DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public DbSet<branch_offices> branch_offices { get; set; }
        public DbSet<budget> budgets { get; set; }
        public DbSet<city> cities { get; set; }
        public DbSet<department> departments { get; set; }
        public DbSet<document_meet_links> document_meet_links { get; set; }
        public DbSet<document_meets> document_meets { get; set; }
        public DbSet<document> documents { get; set; }
        public DbSet<employee_import> employee_import { get; set; }
        public DbSet<employee_states> employee_states { get; set; }
        public DbSet<EmployeeAlternate> employeeAlternates { get; set; }
        public DbSet<EmployeeRole> employeeRoles { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<engeneer_states> engeneer_states { get; set; }
        public DbSet<holiday_work_confirms> holiday_work_confirms { get; set; }
        public DbSet<holiday_work_documents> holiday_work_documents { get; set; }
        public DbSet<language> languages { get; set; }
        public DbSet<org_state_images> org_state_images { get; set; }
        public DbSet<organization> organizations { get; set; }
        public DbSet<photo> photos { get; set; }
        public DbSet<position_import> position_import { get; set; }
        public DbSet<position> positions { get; set; }
        public DbSet<recruit_came_resources> recruit_came_resources { get; set; }
        public DbSet<recruit_candidate_came_types> recruit_candidate_came_types { get; set; }
        public DbSet<recruit_candidate_resume_files> recruit_candidate_resume_files { get; set; }
        public DbSet<recruit_candidates> recruit_candidates { get; set; }
        public DbSet<recruit_question_form_educations> recruit_question_form_educations { get; set; }
        public DbSet<recruit_question_form_facts> recruit_question_form_facts { get; set; }
        public DbSet<recruit_question_form_further_educations> recruit_question_form_further_educations { get; set; }
        public DbSet<recruit_question_form_languages> recruit_question_form_languages { get; set; }
        public DbSet<recruit_question_form_relatives> recruit_question_form_relatives { get; set; }
        public DbSet<recruit_question_form_works> recruit_question_form_works { get; set; }
        public DbSet<recruit_question_forms> recruit_question_forms { get; set; }
        public DbSet<recruit_question_links> recruit_question_links { get; set; }
        public DbSet<recruit_selection_state_history> recruit_selection_state_history { get; set; }
        public DbSet<recruit_selection_states> recruit_selection_states { get; set; }
        public DbSet<recruit_selections> recruit_selections { get; set; }
        public DbSet<recruit_vacancies> recruit_vacancies { get; set; }
        public DbSet<recruit_vacancy_causes> recruit_vacancy_causes { get; set; }
        public DbSet<recruit_vacancy_state_history> recruit_vacancy_state_history { get; set; }
        public DbSet<recruit_vacancy_states> recruit_vacancy_states { get; set; }
        public DbSet<RequestReason> request_reasons { get; set; }
        public DbSet<RequestStatus> request_statuses { get; set; }
        public DbSet<request> requests { get; set; }
        public DbSet<rest_holiday_transfer_days> rest_holiday_transfer_days { get; set; }
        public DbSet<rest_holidays> rest_holidays { get; set; }
        public DbSet<statement_printed> statement_printed { get; set; }
        public DbSet<statement_types> statement_types { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<vendor_state_pictures> vendor_state_pictures { get; set; }
        public DbSet<vendor_states> vendor_states { get; set; }
        public DbSet<vendor> vendors { get; set; }
        public DbSet<wd_holidays> wd_holidays { get; set; }
        public DbSet<wd_short_days> wd_short_days { get; set; }
        public DbSet<wd_work_holidays> wd_work_holidays { get; set; }
        public DbSet<work_days> work_days { get; set; }
        public DbSet<work_hours> work_hours { get; set; }
        public DbSet<CaptureOutputLog> CaptureOutputLogs { get; set; }
        public DbSet<Private_RenamedObjectLog> Private_RenamedObjectLog { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<departments_view> departments_view { get; set; }
        public DbSet<employee_rest_holidays_report> employee_rest_holidays_report { get; set; }
        public DbSet<employees_report> employees_report { get; set; }
        public DbSet<employees_view> employees_view { get; set; }
        public DbSet<recruit_candidates_view> recruit_candidates_view { get; set; }
        public DbSet<recruit_selections_report> recruit_selections_report { get; set; }
        public DbSet<recruit_selections_view> recruit_selections_view { get; set; }
        public DbSet<recruit_vacancies_report> recruit_vacancies_report { get; set; }
        public DbSet<recruit_vacancies_view> recruit_vacancies_view { get; set; }
        public DbSet<users_view> users_view { get; set; }
        public DbSet<TestClass> TestClasses { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new C__RefactorLogMap());
            modelBuilder.Configurations.Add(new branch_officesMap());
            modelBuilder.Configurations.Add(new budgetMap());
            modelBuilder.Configurations.Add(new cityMap());
            modelBuilder.Configurations.Add(new departmentMap());
            modelBuilder.Configurations.Add(new document_meet_linksMap());
            modelBuilder.Configurations.Add(new document_meetsMap());
            modelBuilder.Configurations.Add(new documentMap());
            modelBuilder.Configurations.Add(new employee_importMap());
            modelBuilder.Configurations.Add(new employee_statesMap());
            modelBuilder.Configurations.Add(new employeeAlternateMap());
            modelBuilder.Configurations.Add(new employeeRoleMap());
            modelBuilder.Configurations.Add(new employeeMap());
            modelBuilder.Configurations.Add(new engeneer_statesMap());
            modelBuilder.Configurations.Add(new holiday_work_confirmsMap());
            modelBuilder.Configurations.Add(new holiday_work_documentsMap());
            modelBuilder.Configurations.Add(new languageMap());
            modelBuilder.Configurations.Add(new org_state_imagesMap());
            modelBuilder.Configurations.Add(new organizationMap());
            modelBuilder.Configurations.Add(new photoMap());
            modelBuilder.Configurations.Add(new position_importMap());
            modelBuilder.Configurations.Add(new positionMap());
            modelBuilder.Configurations.Add(new recruit_came_resourcesMap());
            modelBuilder.Configurations.Add(new recruit_candidate_came_typesMap());
            modelBuilder.Configurations.Add(new recruit_candidate_resume_filesMap());
            modelBuilder.Configurations.Add(new recruit_candidatesMap());
            modelBuilder.Configurations.Add(new recruit_question_form_educationsMap());
            modelBuilder.Configurations.Add(new recruit_question_form_factsMap());
            modelBuilder.Configurations.Add(new recruit_question_form_further_educationsMap());
            modelBuilder.Configurations.Add(new recruit_question_form_languagesMap());
            modelBuilder.Configurations.Add(new recruit_question_form_relativesMap());
            modelBuilder.Configurations.Add(new recruit_question_form_worksMap());
            modelBuilder.Configurations.Add(new recruit_question_formsMap());
            modelBuilder.Configurations.Add(new recruit_question_linksMap());
            modelBuilder.Configurations.Add(new recruit_selection_state_historyMap());
            modelBuilder.Configurations.Add(new recruit_selection_statesMap());
            modelBuilder.Configurations.Add(new recruit_selectionsMap());
            modelBuilder.Configurations.Add(new recruit_vacanciesMap());
            modelBuilder.Configurations.Add(new recruit_vacancy_causesMap());
            modelBuilder.Configurations.Add(new recruit_vacancy_state_historyMap());
            modelBuilder.Configurations.Add(new recruit_vacancy_statesMap());
            modelBuilder.Configurations.Add(new request_reasonsMap());
            modelBuilder.Configurations.Add(new request_statusesMap());
            modelBuilder.Configurations.Add(new requestMap());
            modelBuilder.Configurations.Add(new rest_holiday_transfer_daysMap());
            modelBuilder.Configurations.Add(new rest_holidaysMap());
            modelBuilder.Configurations.Add(new statement_printedMap());
            modelBuilder.Configurations.Add(new statement_typesMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new vendor_state_picturesMap());
            modelBuilder.Configurations.Add(new vendor_statesMap());
            modelBuilder.Configurations.Add(new vendorMap());
            modelBuilder.Configurations.Add(new wd_holidaysMap());
            modelBuilder.Configurations.Add(new wd_short_daysMap());
            modelBuilder.Configurations.Add(new wd_work_holidaysMap());
            modelBuilder.Configurations.Add(new work_daysMap());
            modelBuilder.Configurations.Add(new work_hoursMap());
            modelBuilder.Configurations.Add(new CaptureOutputLogMap());
            modelBuilder.Configurations.Add(new Private_RenamedObjectLogMap());
            modelBuilder.Configurations.Add(new TestResultMap());
            modelBuilder.Configurations.Add(new departments_viewMap());
            modelBuilder.Configurations.Add(new employee_rest_holidays_reportMap());
            modelBuilder.Configurations.Add(new employees_reportMap());
            modelBuilder.Configurations.Add(new employees_viewMap());
            modelBuilder.Configurations.Add(new recruit_candidates_viewMap());
            modelBuilder.Configurations.Add(new recruit_selections_reportMap());
            modelBuilder.Configurations.Add(new recruit_selections_viewMap());
            modelBuilder.Configurations.Add(new recruit_vacancies_reportMap());
            modelBuilder.Configurations.Add(new recruit_vacancies_viewMap());
            modelBuilder.Configurations.Add(new users_viewMap());
            modelBuilder.Configurations.Add(new TestClassMap());
            modelBuilder.Configurations.Add(new TestMap());
        }
    }
}
