using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff.Models
{
    public class Request
    {
        public int id { get; set; }
        /// <summary>
        /// должность
        /// </summary>
        public int? id_position { get; set; }
        /// <summary>
        /// должность
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// причина увольнения
        /// </summary>
        public int? id_reason { get; set; }
        /// <summary>
        /// причина увольнения
        /// </summary>
        public string reason { get; set; }
        /// <summary>
        /// цель
        /// </summary>
        public string aim { get; set; }
        /// <summary>
        /// руководитель
        /// </summary>
        public string sid_manager { get; set; }
        /// <summary>
        /// руководитель
        /// </summary>
        public string manager { get; set; }
        /// <summary>
        /// наставник
        /// </summary>
        public string sid_teacher { get; set; }
        /// <summary>
        /// наставник
        /// </summary>
        public string teacher { get; set; }
        /// <summary>
        /// отдел
        /// </summary>
        public int? id_department { get; set; }
        /// <summary>
        /// отдел
        /// </summary>
        public string department { get; set; }
        /// <summary>
        /// есть ли подчиненные
        /// </summary>
        public bool? is_subordinates { get; set; }
        /// <summary>
        /// перечисление подчиненных
        /// </summary>
        public string subordinates { get; set; }
        /// <summary>
        /// возлагаемые функции
        /// </summary>
        public string functions { get; set; }
        /// <summary>
        /// взаимодействия
        /// </summary>
        public string interactions { get; set; }
        /// <summary>
        /// есть ли должностные инструкции
        /// </summary>
        public bool? is_instructions { get; set; }
        /// <summary>
        /// показатели успешности
        /// </summary>
        public string success_rates { get; set; }
        /// <summary>
        /// план на испытательном сроке
        /// </summary>
        public string plan_to_test { get; set; }
        /// <summary>
        /// план после испытательного срока
        /// </summary>
        public string plan_after_test { get; set; }
        //////////////////////////////////////////////////////////////////////////////////////////////////////-
        /// <summary>
        /// место работы
        /// </summary>
        public string work_place { get; set; }
        /// <summary>
        /// режим работы
        /// </summary>
        public string work_mode { get; set; }
        /// <summary>
        /// отпуск
        /// </summary>
        public string holiday { get; set; }
        /// <summary>
        /// больничные
        /// </summary>
        public string hospital { get; set; }
        /// <summary>
        /// командировки
        /// </summary>
        public string business_trip { get; set; }
        /// <summary>
        /// сверхурочная работа
        /// </summary>
        public string overtime_work { get; set; }
        /// <summary>
        /// компенсации
        /// </summary>
        public string compensations { get; set; }
        /// <summary>
        /// испытательный срок
        /// </summary>
        public int? probation { get; set; }
        /// <summary>
        /// зп на испытательном
        /// </summary>
        public string salary_to_test { get; set; }
        /// <summary>
        /// зп после испытания
        /// </summary>
        public string salary_after_test { get; set; }
        /// <summary>
        /// бонусы
        /// </summary>
        public string bonuses { get; set; }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// пол
        /// </summary>
        public bool? sex { get; set; }
        /// <summary>
        /// возраст от
        /// </summary>
        public int? age_from { get; set; }
        /// <summary>
        /// возраст до
        /// </summary>
        public int? age_to { get; set; }
        /// <summary>
        /// образование
        /// </summary>
        public string education { get; set; }
        /// <summary>
        /// предыдущие работы
        /// </summary>
        public string last_work { get; set; }
        /// <summary>
        /// обязательные требования
        /// </summary>
        public string requirements { get; set; }
        /// <summary>
        /// навыки и знания
        /// </summary>
        public string knowledge { get; set; }
        /// <summary>
        /// дополнительные пожелания
        /// </summary>
        public string suggestions { get; set; }
        /// <summary>
        /// надо ли мебель
        /// </summary>
        public bool? is_furniture { get; set; }
        /// <summary>
        /// мебель
        /// </summary>
        public string furniture { get; set; }
        /// <summary>
        /// надо ли ПК
        /// </summary>
        public bool? is_pc { get; set; }
        /// <summary>
        /// надо ли телефон
        /// </summary>
        public bool? is_telephone { get; set; }
        /// <summary>
        /// эталон
        /// </summary>
        public bool? is_ethalon { get; set; }
        /// <summary>
        /// сроки выхода на рабору
        /// </summary>
        public DateTime? appearance { get; set; }

        /// <summary>
        /// дата создания
        /// </summary>
        public DateTime? create_datetime { get; set; }
        /// <summary>
        /// дата последнего изменения
        /// </summary>
        public DateTime? last_change_datetime { get; set; }

        /// <summary>
        /// контактное лицо по собеседованию
        /// </summary>
        public string sid_contact_person { get; set; }
        /// <summary>
        /// контактное лицо по собеседованию
        /// </summary>
        public string contact_person { get; set; }
        /// <summary>
        /// оценщик на итоговом собеседовании
        /// </summary>
        public string sid_responsible_person { get; set; }
        /// <summary>
        /// руководитель принимающий окончательное решение
        /// </summary>
        public string responsible_person { get; set; }
        /// <summary>
        /// код статуса
        /// </summary>
        public int id_status { get; set; }
        /// <summary>
        /// статус
        /// </summary>
        public string status { get; set; }

        public bool enabled { get; set; }
        
        /// <summary>
        /// Флаг начатого согласования
        /// </summary>
        public bool IsCoordinationStarted { get; set; }

        /// <summary>
        /// Флаг - согласование на доработке
        /// </summary>
        public bool IsCoordinationPaused { get; set; }
        
    }
}