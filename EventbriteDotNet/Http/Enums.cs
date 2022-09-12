using System;

namespace EventbriteDotNet.Http
{
    ///<summary>
    /// Types of parameters that can be added to requests
    ///</summary>
    public enum ParameterType
    {
        GetOrPost,
        UrlSegment,
        QueryString
    }
}
