using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SelectPdf;
using Stuff.Models;
using Stuff.Objects;
using StuffDelivery.Helpers;
using StuffDelivery.Models;
using StuffDelivery.Objects;

namespace StuffDelivery
{
    class Program
    {
        private static bool IsTest = false;

        private static MailAddress defaultMailFrom = new MailAddress("UN1T@un1t.group");
        private static readonly string stuffUrl = ConfigurationManager.AppSettings["stuffUrl"];

        static void Main(string[] args)
        {
            if (!args.Any()) return;

            if (args[0] != null && args[0] == "today") ExecDeliveryBirthdayToday();
            if (args[0] != null && args[0] == "month") ExecDeliveryBirthdayMonth();
            if (args[0] != null && args[0] == "newemps") ExecDeliveryNewEmployees();
            if (args[0] != null && args[0] == "hldwrk") HolidayWorkDelivery();
            if (args[0] != null && args[0] == "hldwrklist") SendHolidayWorkConfirmList();
            if (args[0] != null && args[0] == "itbudget") SendItBudget();
            if (args[0] != null && args[0] == "vendorexp") VendorStateDelivery(VendorStateDeliveryType.Expired);
            if (args[0] != null && args[0] == "vendornewbie") VendorStateDelivery(VendorStateDeliveryType.Newbie);
            if (args[0] != null && args[0] == "vendorupd") VendorStateDelivery(VendorStateDeliveryType.Update);
            if (args[0] != null && args[0] == "engeneerstateexp") EngeneerStateDelivery(EngeneerStateDeliveryType.Expired);
            if (args[0] != null && args[0] == "engeneerstatenewbie") EngeneerStateDelivery(EngeneerStateDeliveryType.Newbie);
            if (args[0] != null && args[0] == "engeneerstateupd") EngeneerStateDelivery(EngeneerStateDeliveryType.Update);
        }

        public enum EngeneerStateDeliveryType : byte { Newbie, Update, Expired }
        public static void EngeneerStateDelivery(EngeneerStateDeliveryType type)
        {
            string stuffUri = ConfigurationManager.AppSettings["stuffUrl"];
            byte expires = (byte)((byte)type == 2 ? 1 : 0);
            byte newbie = (byte)((byte)type == 0 ? 1 : 0);
            byte updated = (byte)((byte)type == 1 ? 1 : 0);
            var engeneerStateList = EngeneerState.GetDeliverList(expires, newbie, updated);
            var addressList = type == EngeneerStateDeliveryType.Expired ?
                AdHelper.GetEmailListByAdGroup(AdGroup.EngeneerStateExpiresDelivery) : AdHelper.GetEmailListByAdGroup(AdGroup.EngeneerStateEdit, AdGroup.EngeneerStateView);
            var mailList = (from s in addressList where !String.IsNullOrEmpty(s) select new MailAddress(s)).ToArray();
            var body = new StringBuilder("Добрый день.<br/>");
            if (engeneerStateList.Any())
            {
                switch (type)
                {
                    case EngeneerStateDeliveryType.Newbie:
                        NewEngeneerStateDelivery(engeneerStateList, stuffUri, body, mailList);
                        break;
                    case EngeneerStateDeliveryType.Update:
                        UpdEngeneerStateDelivery(engeneerStateList, stuffUri, body, mailList);
                        break;
                    case EngeneerStateDeliveryType.Expired:
                        ExpiredEngeneerStateDelivery(engeneerStateList, stuffUri, body, mailList);
                        break;
                }

                expires = (byte)((byte)type == 2 ? 1 : 0);
                newbie = (byte)((byte)type == 0 ? 1 : 0);
                updated = (byte)((byte)type == 1 ? 1 : 0);
                foreach (EngeneerState engeneerState in engeneerStateList)
                {
                    EngeneerState.SetDeliverySent(engeneerState.Id, expires, newbie, updated);
                }
            }
        }

        private static void NewEngeneerStateDelivery(IEnumerable<EngeneerState> engeneerStateList, string stuffUri, StringBuilder body, MailAddress[] mailList)
        {
            foreach (var engeneerState in engeneerStateList)
            {
                body = new StringBuilder("Добрый день.<br/>");
                var subject = string.Format("Новый статус {0} от {1}.", engeneerState.StateName, engeneerState.VendorName);
                body.AppendFormat("У инженера {0} появился новый статус {1} от {2}.<br/>", engeneerState.EngeneerName,
                    engeneerState.StateName,
                    engeneerState.VendorName);
                if (engeneerState.EndDate.ToShortDateString() == "03.03.3333") body.Append("Срок действия - Бессрочно.<br/>");
                else
                {
                    body.AppendFormat("Срок действия до {0}.<br/>", engeneerState.EndDate.ToShortDateString());
                }
                body.AppendFormat("{0}<br/>", engeneerState.StateDescription);
                body.AppendFormat("<p><a href='{0}/EngeneerState/GetImage/{1}'>{0}/EngeneerState/GetImage/{1}</a></p>", stuffUri,
                    engeneerState.Id);
                SendMailSmtp(subject, body.ToString(), true, null, mailList, null, null);
            }
        }
        private static void UpdEngeneerStateDelivery(IEnumerable<EngeneerState> engeneerStateList, string stuffUri, StringBuilder body, MailAddress[] mailList)
        {
            var curPrevPairs = EngeneerState.GetCurPrevPairs(engeneerStateList);
            foreach (var curPrevPair in curPrevPairs)
            {
                body = new StringBuilder("Добрый день.<br/>");
                var subject = string.Format("Обновление статуса {0} от {1}.", curPrevPair.Value.StateName, curPrevPair.Value.VendorName);
                body.AppendFormat("Обновился статус {0} от {1} для инженера {2}.<br/><br/>", curPrevPair.Value.StateName, curPrevPair.Value.VendorName, curPrevPair.Value.EngeneerName);
                body.Append("Новая версия статуса:<br/>");
                body.AppendFormat("{0}<br/>", curPrevPair.Key.UnitOrganizationName);
                body.AppendFormat("{0}<br/>", curPrevPair.Key.VendorName);
                body.AppendFormat("{0}<br/>", curPrevPair.Key.StateName);
                if (curPrevPair.Key.EndDate.ToShortDateString() == "03.03.3333") body.Append("Срок действия - Бессрочно.<br/>");
                else
                {
                    body.AppendFormat("Срок действия до {0}.<br/>", curPrevPair.Key.EndDate.ToShortDateString());
                }
                body.AppendFormat("{0}<br/>", curPrevPair.Key.StateDescription);
                body.AppendFormat("<p><a href='{0}/EngeneerState/GetImage/{1}'>{0}/EngeneerState/GetImage/{1}</a></p>", stuffUri,
                    curPrevPair.Key.Id);
                SendMailSmtp(subject, body.ToString(), true, null, mailList, null, null);
            }
        }
        private static void ExpiredEngeneerStateDelivery(IEnumerable<EngeneerState> engeneerStateList, string stuffUri, StringBuilder body, MailAddress[] mailList)
        {
            foreach (var engeneerState in engeneerStateList)
            {
                body = new StringBuilder("Добрый день.<br/>");
                var subject =
                    string.Format("Срок действия статуса {0} от {1} истекает через 2 месяца", engeneerState.StateName, engeneerState.VendorName);
                body.AppendFormat(
                    "У инженера {0} через 2 месяца истекает срок действия статуса {1} от {2}.<br/>",
                    engeneerState.EngeneerName, engeneerState.StateName, engeneerState.VendorName);
                body.AppendFormat("{0}<br/>", engeneerState.StateDescription);
                body.AppendFormat("<p><a href='{0}/EngeneerState/Edit/{1}'>{0}/EngeneerState/Edit/{1}</a></p>", stuffUri,
                    engeneerState.Id);
                //MemoryStream stream = new MemoryStream(vendorState.Picture.ToArray());
                //var file = new AttachmentFile() { Data = stream.ToArray(), FileName = "state.jpeg", DataMimeType = MediaTypeNames.Image.Jpeg };
                SendMailSmtp(subject, body.ToString(), true, mailList, null, null);
            }
        }

        public enum VendorStateDeliveryType : byte {Newbie, Update, Expired}
        public static void VendorStateDelivery(VendorStateDeliveryType type)
        {
            string stuffUri = ConfigurationManager.AppSettings["stuffUrl"];
            var vendorStateList = VendorState.GetDeliverList((byte)type);
            var addressList = type == VendorStateDeliveryType.Expired ?
                VendorState.GetExpiredMailAddressList() : Employee.GetFullRecipientList();
            var mailList = (from s in addressList where !String.IsNullOrEmpty(s) select new MailAddress(s)).ToArray();
            var body = new StringBuilder("Добрый день.<br/>");
            if (vendorStateList.Any())
            {
                switch (type)
                {
                    case VendorStateDeliveryType.Newbie:
                        NewVendorStateDelivery(vendorStateList, stuffUri, body, mailList);
                        break;
                    case VendorStateDeliveryType.Update:
                        UpdVendorStateDelivery(vendorStateList, stuffUri, body, mailList);
                        break;
                    case VendorStateDeliveryType.Expired:
                        ExpiredVendorStateDelivery(vendorStateList, stuffUri, body, mailList);
                        break;
                }
                
                var responseMessage = new ResponseMessage();
                var complete = VendorState.SetDeliverySent(out responseMessage, (byte)type, vendorStateList.ToArray());
            }
        }

        private static void NewVendorStateDelivery(List<VendorState> vendorStateList, string stuffUri, StringBuilder body, MailAddress[] mailList)
        {
            foreach (var vendorState in vendorStateList)
            {
                body = new StringBuilder("Добрый день.<br/>");
                var subject = string.Format("Новый статус {0} от {1}.",vendorState.StateName,vendorState.VendorName);
                body.AppendFormat("У организации {0} появился новый статус {1} от {2}.<br/>", vendorState.UnitOrganizationName,
                    vendorState.StateName,
                    vendorState.VendorName);
                if (vendorState.EndDate.ToShortDateString() == "03.03.3333") body.Append("Срок действия - Бессрочно.<br/>");
                else
                {
                    body.AppendFormat("Срок действия до {0}.<br/>", vendorState.EndDate.ToShortDateString());
                }
                body.AppendFormat("{0}<br/>", vendorState.StateDescription);
                body.AppendFormat("<p><a href='{0}/VendorState/GetImage/{1}'>{0}/VendorState/GetImage/{1}</a></p>", stuffUri,
                    vendorState.Id);
                SendMailSmtp(subject, body.ToString(), true,  null, mailList, null, null);
            }
        }
        private static void UpdVendorStateDelivery(List<VendorState> vendorStateList, string stuffUri, StringBuilder body, MailAddress[] mailList)
        {
            var curPrevPairs = VendorState.GetCurPrevPairs(vendorStateList);
            foreach (var curPrevPair in curPrevPairs)
            {
                body = new StringBuilder("Добрый день.<br/>");
                var subject = string.Format("Обновление статуса {0} от {1}.",curPrevPair.Value.StateName,curPrevPair.Value.VendorName);
                body.AppendFormat("Обновился статус {0} от {1} для организации {2}.<br/><br/>", curPrevPair.Value.StateName, curPrevPair.Value.VendorName, curPrevPair.Value.UnitOrganizationName);
                body.Append("Новая версия статуса:<br/>");
                body.AppendFormat("{0}<br/>", curPrevPair.Key.UnitOrganizationName);
                body.AppendFormat("{0}<br/>", curPrevPair.Key.VendorName);
                body.AppendFormat("{0}<br/>", curPrevPair.Key.StateName);
                if (curPrevPair.Key.EndDate.ToShortDateString() == "03.03.3333") body.Append("Срок действия - Бессрочно.<br/>");
                else
                {
                    body.AppendFormat("Срок действия до {0}.<br/>", curPrevPair.Key.EndDate.ToShortDateString());
                }
                body.AppendFormat("{0}<br/>", curPrevPair.Key.StateDescription);
                body.AppendFormat("<p><a href='{0}/VendorState/GetImage/{1}'>{0}/VendorState/GetImage/{1}</a></p>", stuffUri,
                    curPrevPair.Key.Id);
                SendMailSmtp(subject, body.ToString(), true,  null, mailList, null, null);
            }
        }
        private static void ExpiredVendorStateDelivery(List<VendorState> vendorStateList, string stuffUri, StringBuilder body, MailAddress[] mailList)
        {
            foreach (var vendorState in vendorStateList)
            {
                body = new StringBuilder("Добрый день.<br/>");
                var subject =
                    string.Format("Срок действия статуса {0} от {1} истекает через 2 месяца",vendorState.StateName,vendorState.VendorName);
                body.AppendFormat(
                    "У оргнизации {0} через 2 месяца истекает срок действия статуса {1} от {2}.<br/>",
                    vendorState.UnitOrganizationName, vendorState.StateName, vendorState.VendorName);
                body.AppendFormat("{0}<br/>", vendorState.StateDescription);
                body.AppendFormat("<p><a href='{0}/VendorState/Edit/{1}'>{0}/VendorState/Edit/{1}</a></p>", stuffUri,
                    vendorState.Id);
                //MemoryStream stream = new MemoryStream(vendorState.Picture.ToArray());
                //var file = new AttachmentFile() { Data = stream.ToArray(), FileName = "state.jpeg", DataMimeType = MediaTypeNames.Image.Jpeg };
                SendMailSmtp(subject, body.ToString(), true, mailList, null, null);
            }
        }

        public static void SendItBudget()
        {
            HtmlToPdf converter = new HtmlToPdf();
            string url = String.Format("{0}/Report/ItBudgetView", stuffUrl);
            PdfDocument doc = converter.ConvertUrl(url);
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);

            var file = new AttachmentFile() { Data = stream.ToArray(), FileName = "it-budget.pdf", DataMimeType = MediaTypeNames.Application.Pdf };
            //var recipients = new MailAddress[] {new MailAddress("Ildar.Gimaltdinov@unitgroup.ru"), new MailAddress("Svetlana.Demysheva@unitgroup.ru"), new MailAddress("Larisa.Ganishina@unitgroup.ru") };
            var recipientsStr = ConfigurationManager.AppSettings["ItBudgetRecipients"].Split('|');
            //string monthName = new TranslitDate().GetMonthName(DateTime.Now.AddMonths(1).Month);
            var recipients = (from s in recipientsStr where !String.IsNullOrEmpty(s) select new MailAddress(s)).ToArray();
            string monthName = TranslitDate.GetMonthNameImenit(DateTime.Now.AddMonths(-1).Month);
            SendMailSmtp(String.Format("ИТ бюджет за {0} {1}", monthName, DateTime.Now.AddMonths(-1).Year), "Добрый день. ИТ бюджет во вложении", true, null, recipients, null, file);
        }

        public static void SendHolidayWorkConfirmList()
        {
            var wd = HolidayWork.CheckTodayIsPreHoliday();
            if (!wd.SendDelivery) return;
            string[] list = HolidayWork.GetConfirms();
            var emails = Employee.GetHolidayWorkDeliveryRecipientList();

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendLine("<div style='font-family: Calibri'>");
            mailBody.AppendLine("<table style='border-collapse: collapse; border: 1px solid black;'>");
            mailBody.AppendLine("<tr style='border: 1px solid black;'><th style='border: 1px solid black;padding: 5px;'>№</th><th style='border: 1px solid black;padding: 5px;'>ФИО сотрудника</th></tr>");
            int i = 0;
            foreach (string s in list)
            {
                i++;
                mailBody.AppendLine(
                    string.Format("<tr style='border: 1px solid black;'><td style='border: 1px solid black;padding: 5px;'>{0}</td><td style='border: 1px solid black;padding: 5px;'>{1}</td></tr>", i, s));
            }
            mailBody.AppendLine("</table>");
            mailBody.AppendLine("</div>");
            var recipients = GetMailAddressesFromList(emails);
            SendMailSmtp("Список сотрудников (доступ в выходные)", mailBody.ToString(), true, null, recipients, null);
        }

        public static void HolidayWorkDelivery()
        {
            var wd = HolidayWork.CheckTodayIsPreHoliday();

            if (!wd.SendDelivery) return;

            var emails = Employee.GetFullRecipientList("EKB");

            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendLine("<div style='font-family: Calibri'>");
            mailBody.AppendLine("<p>Уважаемые коллеги!</p>");
            if (wd.IsSundayOnly)
            {
                mailBody.AppendLine(
                    "<p>Кто планирует выйти на работу в воскресенье, запишитесь до 16:00, отправив ответ на это письмо.</p>");
            }
            else
            {
                mailBody.AppendLine("<p>Кто планирует выйти на работу в праздники, запишитесь до 16:00, отправив ответ на это письмо.</p>"
                    //String.Format("<p>Кто планирует выйти на работу в праздники с {0:dd.MM} по {1:dd.MM}, можете записаться отправив ответное письмо (можно пустое)!</p>", wd.DateStart, wd.DateEnd)
                    );
            }
            mailBody.AppendLine("</div>");
            var recipients = GetMailAddressesFromList(emails);
            var holidayWorkMailFrom = new MailAddress("holiday-work@unitgroup.ru");
            string login = "holiday-work@unitgroup.ru";
            string pass = "1qazXSW@";
            SendMailSmtp("Работа в выходные", mailBody.ToString(), true, null, recipients, holidayWorkMailFrom, login:login, pass:pass);
        }

        public static MailAddress[] GetMailAddressesFromList(IEnumerable<string> emails)
        {
            List<MailAddress> recipients = new List<MailAddress>();
            foreach (string email in emails)
            {
                recipients.Add(new MailAddress(email));
            }

            return recipients.ToArray();
        }

        private static void ExecDeliveryNewEmployees()
        {
            var emails = Employee.GetFullRecipientList();
            var newbie = Employee.GetNewbieList().ToArray();

            if (newbie.Any())
            {
                StringBuilder mailBody = new StringBuilder();
                mailBody.AppendLine("<div style='font-family: Calibri'>");
                mailBody.AppendLine("<p>Уважаемые коллеги!</p>");
                //mailBody.AppendLine("\r\n");
                mailBody.AppendLine(String.Format("<p>У нас новые сотрудники:</p>"));
                //mailBody.AppendLine("\r\n");
                //string stuffUri = ConfigurationManager.AppSettings["stuffUrl"];
                //birthdays = birthdays.OrderBy(e => e.BirthDate.HasValue ? e.BirthDate.Value : new DateTime()).ToArray();
                mailBody.AppendLine("<table style='font-family: Calibri'>");
                foreach (Employee emp in newbie)
                {
                    mailBody.AppendLine(
                        String.Format(
                            "<tr><td><p><a href='{1}/Employee/Index/{2}'>{0}</a>&nbsp;&nbsp;</p></td><td>{3}</td><tr>",
                            emp.FullName, stuffUrl, emp.Id, emp.Position.Name));
                }
                mailBody.AppendLine("</table>");

                var recipients = GetMailAddressesFromList(emails);
                //recipients = new [] {new MailAddress("anton.rehov@unitgroup.ru")};
                mailBody.AppendLine("</div>");
                SendMailSmtp(String.Format("Новые сотрудники"), mailBody.ToString(), true, null, recipients, defaultMailFrom);

                ResponseMessage responseMessage;
                //dep.Creator = new Employee(){AdSid = GetCurUser().Sid};
                bool complete = Employee.SetNewbieDeliverySend(out responseMessage, newbie);
                //if (!complete) throw new Exception(responseMessage.ErrorMessage);
            }
        }

        private static void ExecDeliveryBirthdayMonth()
        {
            var emails = Employee.GetFullRecipientList().ToList();
            var birthdays = Employee.GetNextMonthBirthdayList().ToArray();

            if (birthdays.Any())
            {
                StringBuilder mailBody = new StringBuilder();
                mailBody.AppendLine("<div style='font-family: Calibri'>");
                mailBody.AppendLine("<p>Уважаемые коллеги!</p>");
                //mailBody.AppendLine("\r\n");
                string monthName = TranslitDate.GetMonthNamePredl(DateTime.Now.AddMonths(1).Month);
                mailBody.AppendLine(String.Format("<p>В {0} месяце свои дни рождения празднуют:</p>", monthName));
                //mailBody.AppendLine("\r\n");
                //string stuffUri = ConfigurationManager.AppSettings["stuffUrl"];
                //birthdays = birthdays.OrderBy(e => e.BirthDate.HasValue ? e.BirthDate.Value : new DateTime()).ToArray();
                mailBody.AppendLine("<table style='font-family: Calibri'>");
                foreach (Employee emp in birthdays)
                {
                    //mailBody.AppendLine(String.Format("<tr><td><p>{0}&nbsp;&nbsp;</p></td><td>{1:dd.MM}</td><tr>", emp.FullName, emp.BirthDate.HasValue ? emp.BirthDate.Value : new DateTime()));
                    mailBody.AppendLine(String.Format("<tr><td><p><a href='{2}/Employee/Index/{3}'>{0}</a>&nbsp;&nbsp;</p></td><td>{1:dd.MM}</td><tr>", emp.FullName, emp.BirthDate.HasValue ? emp.BirthDate.Value : new DateTime(), stuffUrl, emp.Id));
                }
                mailBody.AppendLine("</table>");
                List<MailAddress> recipients = new List<MailAddress>();
                foreach (string email in emails)
                {
                    recipients.Add(new MailAddress(email));
                    //recipients.Add(new MailAddress("anton.rehov@unitgroup.ru"));
                }
                mailBody.AppendLine("</div>");
                SendMailSmtp(String.Format("Дни рождения в {0}", monthName), mailBody.ToString(), true, null, recipients.ToArray(), defaultMailFrom);
            }
        }

        private static void ExecDeliveryBirthdayToday()
        {
            var emails = Employee.GetFullRecipientList().ToList();
            var birthdays = Employee.GetTodayBirthdayList().ToArray();

            if (birthdays.Any())
            {
                foreach (var emp in birthdays)
                {
                    emails.RemoveAll(e => e.Equals(emp.Email));
                }

                StringBuilder mailBody = new StringBuilder();
                mailBody.AppendLine("<div style='font-family: Calibri'>");
                mailBody.AppendLine("<p>Доброе утро!</p>");
                //mailBody.AppendLine("\r\n");
                mailBody.AppendLine("<p>Уважаемые коллеги, сегодня день рождения у следующих сотрудников:</p>");
                //mailBody.AppendLine("\r\n");
                //string stuffUri = ConfigurationManager.AppSettings["stuffUrl"];
                birthdays = birthdays.OrderBy(e => e.FullName).ToArray();

                foreach (Employee emp in birthdays)
                {
                    mailBody.AppendLine(String.Format("<p><a href='{3}/Employee/Index/{4}'>{0}</a> - {1} | {2}</p>", emp.FullName, emp.Department.Name, emp.Position.Name, stuffUrl, emp.Id));
                    //mailBody.AppendLine(String.Format("<p>{0}&nbsp;&nbsp;-&nbsp;&nbsp;{1} | {2}</p>", emp.FullName, emp.Department.Name, emp.Position.Name));
                }

                List<MailAddress> recipients = new List<MailAddress>();
                foreach (string email in emails)
                {
                    recipients.Add(new MailAddress(email));
                    //recipients.Add(new MailAddress("anton.rehov@unitgroup.ru"));
                }
                mailBody.AppendLine("</div>");
                SendMailSmtp("Дни рождения сегодня", mailBody.ToString(), true, null, recipients.ToArray(), defaultMailFrom);
            }
        }

        public static void SendMailSmtp(string subject, string body, bool isBodyHtml, MailAddress[] mailTo, MailAddress[] hiddenMailTo, MailAddress mailFrom, AttachmentFile file = null,string login = null, string pass = null, bool isTest = false)
        {
            if (IsTest) isTest = true;

            if ((mailTo == null || !mailTo.Any()) && (hiddenMailTo == null || !hiddenMailTo.Any())) throw new Exception("Не указаны получатели письма!");

            if (mailFrom == null || String.IsNullOrEmpty(mailFrom.Address)) mailFrom = defaultMailFrom;

            MailMessage mail = new MailMessage();

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            if (String.IsNullOrEmpty(login))
            {
                login = "delivery@unitgroup.ru";
                pass = "pRgvD7TL";
            }

            client.Credentials = new NetworkCredential(login, pass);

            mail.From = new MailAddress(login);

            if (mailTo != null)
            {
                foreach (MailAddress mailAddress in mailTo)
                {
                    mail.To.Add(mailAddress);
                }
            }
            if (hiddenMailTo != null)
            {
                foreach (MailAddress mailAddress in hiddenMailTo)
                {
                    mail.Bcc.Add(mailAddress);
                }
            }

            if (isTest)
            {
                mail.To.Clear();
                mail.CC.Clear();
                mail.Bcc.Clear();
                //mail.Bcc.Add(new MailAddress("alexandr.romanov@unitgroup.ru"));
                string[] testMails = ConfigurationManager.AppSettings["TestMailTo"].Split('|');
                foreach (string testMail in testMails)
                {
                    mail.Bcc.Add(new MailAddress(testMail));
                }
                
                //mail.Bcc.Add(new MailAddress("alexander.medvedevskikh@unitgroup.ru"));
            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            if (file != null && file.Data.Length > 0)
            {
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    ms.Read(file.Data, 0, file.Data.Length);

                MemoryStream stream = new MemoryStream(file.Data);

                Attachment attachment = new Attachment(stream, file.FileName, file.DataMimeType);
                    mail.Attachments.Add(attachment);
                    
                    //client.Send(mail);
                //}

                //Attachment attachment = new Attachment(file.FileName, MediaTypeNames.Application.Octet);
                //ContentDisposition disposition = attachment.ContentDisposition;
                //disposition.CreationDate = File.GetCreationTime(file.FileName);
                //disposition.ModificationDate = File.GetLastWriteTime(file.FileName);
                //disposition.ReadDate = File.GetLastAccessTime(file.FileName);
                //disposition.FileName = Path.GetFileName(file.FileName);
                //disposition.Size = new FileInfo(file.FileName).Length;
                //disposition.DispositionType = DispositionTypeNames.Attachment;
                //mail.Attachments.Add(attachment);
            }
            //else
            //{
                client.Send(mail);
            //}


        }
    }
}
