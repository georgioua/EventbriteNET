using EventbriteDotNet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EventbriteDotNet.Http
{
    /// <summary>
    /// http://developer.eventbrite.com/docs/event-details/
    /// </summary>
    class OrganizerRequestHander : RequestBase<Organizer>
    {
        public OrganizerRequestHander(EventbriteContext context) : base(context) { }

        protected override Organizer OnGet(long id)
        {
            var request = new RestRequest("organizers/{id}/");
            request.AddUrlSegment("id", id.ToString());
            request.AddQueryParameter("token", Context.Token);

            Context.OrganizerId = id;
            return this.Execute<Organizer>(request);
        }

        protected override void OnCreate(Organizer entity)
        {
            var request = new RestRequest("organizers/", HttpMethod.Post);
            request.AddQueryParameter("token", Context.Token);
            request.AddObject(entity, "organizer", AcceptedPostFields());

            // execute Event create
            var response = this.Execute(request);

            if(response.IsSuccessStatusCode)
            {
                // get updated response
                var persisted = response.As<Organizer>();
                // persist base properties onto entity
                entity.Id = persisted.Id;
                entity.ResourceUri = persisted.ResourceUri;
                Context.OrganizerId = persisted.Id;
            }
            else
            {
                this.ThrowResponseError(response);
            }
        }

        protected override void OnUpdate(Organizer entity)
        {
            if (entity.Id <= 0)
                throw new ArgumentException("Id not set in Organizer", "entity");

            var request = new RestRequest("organizers/{id}/", HttpMethod.Post);
            request.AddUrlSegment("id", entity.Id.ToString());
            request.AddQueryParameter("token", Context.Token);
            request.AddObject(entity, "organizer", AcceptedPostFields());

            // Execute Event update
            var response = this.Execute(request);

            if (response.IsSuccessStatusCode)
            {
                Context.OrganizerId = entity.Id;
            }
            else 
            {
                this.ThrowResponseError(response);
            }
        }

        protected override Task<Organizer> OnGetAsync(long id)
        {
            var request = new RestRequest("organizers/{id}/");
            request.AddUrlSegment("id", id.ToString());
            request.AddQueryParameter("token", Context.Token);

            if (Context.Page > 1)
                request.AddQueryParameter("page", Context.Page.ToString());

            Context.OrganizerId = id;
            return this.ExecuteAsync<Organizer>(request);
        }

        public IList<Event> GetOrganizerEvents(long id, StatusOptions[] status = null, OrderOptions[] orderBy = null, DateTime? dateStart = null, DateTime? dateEnd = null, bool? onlyPublic = null, string expand = null)
        {
            var request = new RestRequest("organizers/{id}/events/");
            request.AddUrlSegment("id", id.ToString());
            request.AddQueryParameter("token", Context.Token);
            if (status != null && status.Any())
                request.AddQueryParameter("status", status.ToUrlParam());
            if (orderBy != null && orderBy.Any())
                request.AddQueryParameter("order_by", orderBy.ToUrlParam());
            if (dateStart.HasValue)
                request.AddQueryParameter("start_date.range_start", dateStart.ToUrlParam()); //2016-01-31T13:00:00
            if (dateEnd.HasValue)
                request.AddQueryParameter("start_date.range_end", dateStart.ToUrlParam());
            if (onlyPublic.HasValue)
                request.AddQueryParameter("only_public", onlyPublic.ToUrlParam());
            if (!string.IsNullOrEmpty(expand))
                request.AddQueryParameter("expand", expand);

            Context.OrganizerId = id;

            if (Context.Page > 1)
                request.AddQueryParameter("page", Context.Page.ToString());

            var events = this.Execute<PagedEvents>(request);

            Context.Pagination = events.Pagination;

            return events.Events;
        }


        private string[] AcceptedPostFields()
        {
            return new[] 
                {
                    "Name",
                    "Html",
                    "Description",
                    "OrganizerLogoId",
                    "Website",
                    "Twitter",
                    "Facebook", 
                    "Instagram"
                };
        }

        protected override IList<Organizer> OnGet()
        {
            throw new NotImplementedException();
        }

        protected override Task<IList<Organizer>> OnGetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
