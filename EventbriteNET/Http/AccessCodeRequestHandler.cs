using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventbriteNET.Http
{
    class AccessCodeRequestHandler : RequestBase<AccessCode>
    {
        public AccessCodeRequestHandler(EventbriteContext context) : base(context) { }

        public PagedAccessCodes GetAccessCodesForEvent(long id)
        {
            var request = new RestRequest("events/" + id.ToString() + "/access_codes/");
            request.AddQueryParameter("token", Context.Token);

            if (Context.Page > 1)
                request.AddQueryParameter("page", Context.Page.ToString());

            var accessCodes = this.Execute<PagedAccessCodes>(request);

            return accessCodes;
        }

        public AccessCode GetAccessCodeForEvent(long eventId, long accessCodeId)
        {
            var request = new RestRequest("events/" + eventId.ToString() + "/access_codes/" + accessCodeId);
            request.AddQueryParameter("token", Context.Token);

            var result = this.Execute<AccessCode>(request);

            return result;
        }

        protected override void OnCreate(AccessCode entity)
        {
            var request = new RestRequest("/events/" + Context.EventId + "/access_codes/", HttpMethod.Post);
            request.AddQueryParameter("token", Context.Token);
            request.AddQueryParameter("access_code.code", entity.Code);
            request.AddQueryParameter("access_code.ticket_ids", entity.TicketIds[0].ToString());
            request.AddQueryParameter("access_code.quantity_available", entity.QuantityAvailable.ToString());

            //todo: start + end date

            //execute Access Code create
            var response = this.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                //succcess
            }
            else
            {
                this.ThrowResponseError(response);
            }

        }

        protected override IList<AccessCode> OnGet()
        {
            throw new NotImplementedException();
        }

        protected override AccessCode OnGet(long id)
        {
            throw new NotImplementedException();
        }

        protected override Task<IList<AccessCode>> OnGetAsync()
        {
            throw new NotImplementedException();
        }

        protected override Task<AccessCode> OnGetAsync(long id)
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate(AccessCode entity)
        {
            throw new NotImplementedException();
        }
    }
}
