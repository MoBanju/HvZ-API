using HvZWebAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json.Linq;
using NuGet.ProjectModel;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace HvZWebAPI.Utils;

public class ClaimsTransformer : IClaimsTransformation
{
    private string _resource_client = "react-client";

    public static string ADMIN_ROLE = "admin-client-role";
    public static readonly string PLAYER_ROLE = "participant-client-role";


    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var claimsIdentity = principal.Identity as ClaimsIdentity;

        if (claimsIdentity != null && claimsIdentity.IsAuthenticated && claimsIdentity.HasClaim((claim) => claim.Type == "resource_access"))
        {
            var userRoles = claimsIdentity.FindFirst((claim) => claim.Type == "resource_access");
            if (userRoles != null)
            {
                var content = JObject.Parse(userRoles.Value);

                if (content.ContainsKey(_resource_client)) {
                    foreach (var role in content[_resource_client]["roles"])
                    {
                        claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
                    }
                }
            }

            var sub = claimsIdentity.FindFirst((claim) => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            if(sub != null){

                claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, sub.ToString()));


            }
        }





        return Task.FromResult(principal);
    }
}
