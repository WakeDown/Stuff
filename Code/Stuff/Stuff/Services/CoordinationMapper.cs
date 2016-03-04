using System;
using System.Linq;
using DALCoordination.Entities;
using DALStuff.Models;

namespace Stuff.Services
{
    public class CoordinationMapper
    {
        public static Models.Coordination MapCoordinationToModel(WfwDocumentExecution src, Models.Coordination dst = null)
        {
            if (src == null)
                return null;

            if (dst == null)
                dst = new Models.Coordination();

            dst.id = src.Id;
            dst.stat = src.Level;
            dst.sidСreator = src.CreaterSid;
            dst.creator = src.CreatorEmployee != null ? src.CreatorEmployee.FullName : "";
            dst.doc = src.Documents.First(it => it.Enabled).Id;
            dst.endDate = src.EndDate;
            dst.create_datetime = src.StartDate;
            dst.last_change_datetime = null;
            dst.enabled = src.Enabled;

            return dst;
        }

        public static WfwDocumentExecution MapCoordinationToEntity(Models.Coordination src, WfwDocumentExecution dst = null)
        {
            if (src == null)
                return null;

            if (dst == null)
                dst = new WfwDocumentExecution();

            dst.Id  = src.id;
            dst.Level  = src.stat;
            dst.CreaterSid = src.sidСreator;
            if (src.endDate.HasValue)
                dst.EndDate = src.endDate.Value;
            if (src.create_datetime.HasValue)
                dst.StartDate = src.create_datetime.Value;
            dst.Enabled  = src.enabled;

            return dst;
        }
    }
}