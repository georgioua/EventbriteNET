using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventbriteDotNet.Http
{
    /// <summary>
    /// https://www.eventbrite.com/developer/v3/endpoints/media/
    /// </summary>
    class MediaRequestHander : RequestBase<Image>
    {
        public MediaRequestHander(EventbriteContext context) : base(context) { }

        protected override IList<Image> OnGet()
        {
            throw new NotImplementedException();
        }

        protected override Image OnGet(long id)
        {
            var request = new RestRequest("media/{id}/");
            request.AddUrlSegment("id", id.ToString());
            request.AddQueryParameter("token", Context.Token);

            return this.Execute<Image>(request);
        }
        
        protected override Task<IList<Image>> OnGetAsync()
        {
            return Task.Run(() => OnGet());
        }

        protected override Task<Image> OnGetAsync(long id)
        {
            var request = new RestRequest("media/{id}/");
            request.AddUrlSegment("id", id.ToString());
            request.AddQueryParameter("token", Context.Token);

            if (Context.Page > 1)
                request.AddQueryParameter("page", Context.Page.ToString());

            return this.ExecuteAsync<Image>(request);
        }

        protected override void OnCreate(Image entity)
        {
            throw new NotImplementedException();
        }

        protected override void OnUpdate(Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
